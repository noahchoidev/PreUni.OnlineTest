using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using PreUni.College.DAL.Repository;
using PreUni.OnlineTest.Web.MVC.ViewModel;
using PreUni.College.DAL.NewcollegeDbConnection;
using PreUni.College.DAL.Repository.Interface;
using System.Data.Entity;
using System;
using PreUni.Core.Model;
using System.Collections.Generic;
using PreUni.OnlineTest.Web.MVC.Helper;
using Microsoft.AspNet.Identity;
using PreUni.OnlineTest.Web.MVC.CustomAttribute;
using System.Web;
using PreUni.OnlineTest.UserDAL.IdentityManagers;
using Microsoft.AspNet.Identity.Owin;
using PreUni.Core.Model.Local;
using PreUni.Core.Helper;

namespace PreUni.OnlineTest.Web.MVC.Controllers
{
    // TODO : Change it into Enum data type
    [CustomAuthorize(Roles = "Admin,Developer,Tutor,Teacher,Head")]
    public class AssessmentController : Controller
    {
        #region == User Manager==

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        } 

        #endregion


        #region ==Private Properties==

        private IWritingMarkingRepository mWritingMarkingRepository;
        private IBranchRepository mBranchRepository;
        private IClassRepository mClassRepository;

        #endregion


        #region ==Constructor==

        public AssessmentController(ICreateEFCollegeRepository createCollegeRepository)
        {
            mWritingMarkingRepository = createCollegeRepository.CreateWritingMarkingRepository();
            mBranchRepository = createCollegeRepository.CreateBranchRepository();
            mClassRepository = createCollegeRepository.CreateClassRepository();
        }

        #endregion


        #region ==Action View==

        // GET: Assessment
        public async Task<ActionResult> Index()
        {
            // * Make Year List
            var years = DateTimeHelper.MakeYearList(3); // 3 means length of years user wants.
            ViewBag.YearList = years.OrderByDescending(x => x).ToList();

            // * Set a current Term for selection
            var currentTerm = DateTimeHelper.GetCurrentTerm(DateTime.Now);

            // Get a Cookie data for Writing Filtering Search Model
            var WritingSearchFilterModel = new WritingSearchFilterViewModel
            {
                Year = DateTime.Now.Year,
                Term = currentTerm,
                TestNo = 1,
                IsGeneralTest = true,
            };

            HttpCookie cookie = Request.Cookies["WritingFilterCookie"];
            if (cookie != null)
                GetWritingSearchFilterViewModelFromCookie(cookie, WritingSearchFilterModel);

            return View(WritingSearchFilterModel);
        }

        public ActionResult STTCReWriting()
        {
            // * Make Year List
            var years = DateTimeHelper.MakeYearList(3); // 3 means length of years user wants.
            ViewBag.YearList = years.OrderByDescending(x => x).ToList();

            // * Set a current Term for selection
            var currentTerm = DateTimeHelper.GetCurrentTerm(DateTime.Now);

            // Get a Cookie data for Writing Filtering Search Model
            var WritingSearchFilterModel = new WritingSearchFilterViewModel
            {
                Year = DateTime.Now.Year,
                Term = currentTerm,
                TestNo = 6,
                IsGeneralTest = true,
            };

            HttpCookie cookie = Request.Cookies["ReWritingFilterCookie"];
            if (cookie != null)
                GetWritingSearchFilterViewModelFromCookie(cookie, WritingSearchFilterModel);

            return View(WritingSearchFilterModel);
        }

        public async Task<ActionResult> MarkNow(int? WritingMarkingID, int? StudentID, int? TestID)
        {
            if (   !WritingMarkingID.HasValue 
                || !StudentID.HasValue 
                || !TestID.HasValue)
                return HttpNotFound();

            var subjectID = mWritingMarkingRepository.Get(x => x.ID == WritingMarkingID.Value).FirstOrDefault().SubjectID;

            var marker = User.Identity.GetUserName();
            var ResultList = mWritingMarkingRepository.GetThisStudentWritingPaper(StudentID, TestID, 1); // marker :  subjecttID == 7 ? 1:0
            var paperFound = ResultList.FirstOrDefault();

            if (paperFound == null)
                return HttpNotFound();

            if (paperFound.IsFinish != 1)
                return RedirectToAction("Index");

            var UserFullName = User.GetFullName();
            var _OnlineWritingViewModel = new OnlineWritingViewModel
            {
                ID = paperFound.ID,
                StudentID = StudentID.Value,
                TestID = TestID.Value,
                TEST_NAME = paperFound.TestName,
                Year = paperFound.Year,
                Term = paperFound.Term,
                WritingText = paperFound.WritingText,
                Mark = paperFound.Mark,
                Comment = paperFound.Comment,
                IsFinish = paperFound.IsFinish,
                Marker = paperFound.Marker ?? UserFullName,
                Score = paperFound.Score == null ? 0 : paperFound.Score.Value,
                IsGeneralTest = subjectID == 7 ? true : false,
                TestTypeID = paperFound.TestTypeID,
                TEST_NO = (int)paperFound.TestNo
            };

            return View(_OnlineWritingViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> MarkNow(OnlineWritingViewModel passedVM)
        {
            if (!ModelState.IsValid)
                return View();

            var calculateScoreFromMark = SubjectMarkingHelper.CalculateWritingScore(passedVM.Mark);

            var modelFound = new tblOnlineStudentWriting
            {
                ID = passedVM.ID,
                StudentID = passedVM.StudentID,
                TestID = passedVM.TestID,
                Mark = passedVM.Mark,
                Comment = passedVM.Comment,
                Marker = string.IsNullOrEmpty(passedVM.Marker) ? User.Identity.GetUserName(): passedVM.Marker,
                Score = calculateScoreFromMark,
            };

            // TODO: Make subject data-type into Enum-Type and  SubjectID 7 means Writing
            mWritingMarkingRepository.UpdateStudentWritingMarkForstatics(passedVM.TestID, 
                                                                         passedVM.IsGeneralTest == true ? 7:14, 
                                                                         passedVM.StudentID, 
                                                                         passedVM.Mark);

            await mWritingMarkingRepository.UpdateWritingPaper(modelFound);
            
            if(passedVM.TestTypeID == 17)
                return RedirectToAction("STTCReWriting", "Assessment");
            else
                return RedirectToAction("index", "Assessment");
        }

        #endregion


        #region ==Partial View==

        [HttpPost]
        public ActionResult GetWritingTest(int? studentID, int? TestID, int IsGeneralArea)
        {
            if (!studentID.HasValue || !TestID.HasValue)
                return HttpNotFound();

            IEnumerable<OnlineWritingModel> ResultList;

            var UserEmail = User.Identity.GetUserName();

            ResultList = mWritingMarkingRepository.GetThisStudentWritingPaper(studentID, TestID, IsGeneralArea); 

            var paperFound = ResultList.FirstOrDefault();

            if (paperFound == null)
                return PartialView("_TestTabContent", new OnlineWritingViewModel());

            string FullName = User.GetFullName();

            var _OnlineWritingViewModel = new OnlineWritingViewModel
            {
                ID = paperFound.ID,
                StudentID = studentID.Value,
                StudentName = paperFound.StudentName,
                TestID = TestID.Value,
                TEST_NAME = paperFound.TestName,
                Year = paperFound.Year,
                Term = paperFound.Term,
                WritingText = paperFound.WritingText,
                OriginalMark = paperFound.OriginalMark,
                Mark = paperFound.Mark,
                Comment = paperFound.Comment,
                IsFinish = paperFound.IsFinish,
                IsGeneralTest = IsGeneralArea == 1 ? true : false,
                //TODO : Change it into FullName
                Marker = paperFound.Marker ?? FullName,
                Score = paperFound.Score == null ? 0 : paperFound.Score.Value,
                TestTypeID = paperFound.TestTypeID
            };

            return PartialView("_TestTabContent", _OnlineWritingViewModel);
        }

        // Not Implemented yet
        [HttpPost]
        public ActionResult GetAllWritingOfStudent(WritingSearchFilterViewModel WritingSearchFilterModel)
        {
            var UserEmail = User.Identity.GetUserName();

            // This respotisoty requires 3 params to communicate database. This design is not good to generalize later on, but for now, 
            // in order to reduce frequent visit to database, this is going to be used for a while.
            // var ResultList = mWritingMarkingRepository.GetOnlineWritingListResults(WritingSearchFilterModel.TestTypeID, 
            //                                                                        WritingSearchFilterModel.Year, 
            //                                                                        WritingSearchFilterModel.Term,
            //                                                                        WritingSearchFilterModel.TestNo
            //                                                                        ); // marker

            // * Store Procedure for getting this data list has been already extracted based on the User in this case 'teacher'
            //  = But, later on, the processing should be handled in this function because it is suppoed be here as it is.
            //  - Thus, I left the next row for future successor.
            var teacherID = User.Identity.GetUserId<int>();

            // Do the filtering to get the teacher's writing-paper-list

            var ResultList = mWritingMarkingRepository.UpdateWritinWithUserEmail(
                                                                                    WritingSearchFilterModel.TestTypeID,
                                                                                    WritingSearchFilterModel.Year,
                                                                                    WritingSearchFilterModel.Term,
                                                                                    WritingSearchFilterModel.TestNo,
                                                                                    UserEmail,
                                                                                    WritingSearchFilterModel.IsGeneralTest 
                                                                                        ? 7:14
                                                                                );

            ViewBag.NumOfTestDone = ResultList.Where(x => x.IsFinish == 1).Count(); // 1 means Finished
            ViewBag.TotalNumOfTestDone = ResultList.Count();

            ViewBag.NumOfMarkingDone = ResultList.Where(x => x.IsFinish == 1 && x.Mark != null).Count();

            // custom-filtering                                  
            if (WritingSearchFilterModel.TestNo.HasValue)
                ResultList = ResultList.Where(x => x.TestNo == WritingSearchFilterModel.TestNo.Value);

            // custom-filtering
            if (WritingSearchFilterModel.ClassID.HasValue)
                ResultList = ResultList.Where(x => x.ClassID == WritingSearchFilterModel.ClassID.Value);

            if(WritingSearchFilterModel.IsFinish.HasValue)
                ResultList = WritingSearchFilterModel.IsFinish.Value == 1 ?
                                ResultList.Where(x => x.IsFinish == 1) :
                                ResultList.Where(x => x.IsFinish == 0);

            if (!string.IsNullOrEmpty(WritingSearchFilterModel.BranchCode))
                ResultList = ResultList.Where(x => x.BranchCode == WritingSearchFilterModel.BranchCode);

            if (WritingSearchFilterModel.IsMarked.HasValue)
            {
                var IsMarked_Filter = WritingSearchFilterModel.IsMarked.Value;
                if(IsMarked_Filter == 1)
                    ResultList = ResultList.Where(x => x.IsFinish == 1 && x.Mark != null);
                else
                    ResultList = ResultList.Where(x => x.IsFinish == 1 && x.Mark == null);
            }

            var myRoles = this.GetUserRole();

            // * Refactoring Process
            if(UserInfoHelper.ExistsTargetRoleFromMyRoles(myRoles,RoleEnum.Admin,RoleEnum.Head))
                ResultList = ResultList.OrderBy(x => x.BranchName).ThenBy(y => y.ClassDay).ThenBy(c => c.StudentName);

            ViewBag.IsAccessAvailableForWritingNum = false;
            if(UserInfoHelper.ExistsTargetRoleFromMyRoles(myRoles, RoleEnum.Admin))
                ViewBag.IsAccessAvailableForWritingNum = true;

            return PartialView("_WritingIndex", ResultList);
        }

        #endregion


        #region ==Json View==

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Term"></param>
        /// <param name="Subject">Subject means 'Test_Type_ID'</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetBranchForSelectOptions(BranchSelectionTriggerModel triggerModel)
        {
            var Term = TermHelper.stringMakeTermFormatAndGet(triggerModel.Term);

            var query = mClassRepository.Get(x => x.Year == triggerModel.Year);
            query = query.Where(x => x.Term == Term);


            /****************************************************************************
             * Added by Joon
             * To Show only user's branch if user is not admin
             ****************************************************************************/
            // Get Branch info from a current user
            var currentUser = UserManager.FindById(User.Identity.GetUserId<int>());
            var myRoles = this.GetUserRole();
            if (!UserInfoHelper.ExistsTargetRoleFromMyRoles(myRoles, RoleEnum.Admin))
                query = query.Where(x => x.BRANCHCODE == currentUser.BranchCode.ToString());
            /****************************************************************************/

            if (string.IsNullOrEmpty(triggerModel.TestType))
            query = query.Where(x => x.Subject == triggerModel.TestType);

            var classInfoList = await query.ToListAsync();

            var branchList = await mBranchRepository.GetAllAsync();

            // This is heavy processing. 
            var bracnCodeList = classInfoList.GroupBy(x => x.BRANCHCODE)
                                             .Select(x => x.FirstOrDefault())
                                             .Join(branchList, a => a.BRANCHCODE, b => b.BranchCode, (a, b) => new
                                             {
                                                 a.BRANCHCODE,
                                                 b.BranchName,
                                             })
                                             .Select(x => new Core.Model.BranchViewModel
                                             {
                                                 BranchCode = x.BRANCHCODE,
                                                 BranchName = x.BranchName,
                                             })
                                             .OrderBy(x => x.BranchName); ;

            return Json(bracnCodeList);
        }

        [HttpPost]
        public async Task<JsonResult> GetClassForSelectOptions(ClassSelectionTriggerModel triggerModel) // int Year, string Term, string TestType, string BranchCode
        {
            triggerModel.Term = TermHelper.stringMakeTermFormatAndGet(triggerModel.Term);

            var query = mClassRepository.Get(x => x.Year == triggerModel.Year);

            query = query.Where(x => x.Term == triggerModel.Term);
            query = query.Where(x => x.Subject == triggerModel.TestType);
            query = query.Where(x => x.BRANCHCODE == triggerModel.BranchCode);

            var classInfoList = await query.ToListAsync();

            var classList = classInfoList.Where(a=>!a.Day.Contains("Drop"))
                                         .Select(x => new ViewModel.ClassViewModel
            {
                ClassID = x.ClassID,
                ClassName = x.Day + " " + x.ClassNo
            }).OrderBy(o => o.ClassName);

            return Json(classList);
        }

        public JsonResult SetWritingModelFilterCookie(string CookieNaame, WritingSearchFilterViewModel WritingSearchFilterModel)
        {
            //Make a WritingFilterModel
            HttpCookie cookie = Request.Cookies[CookieNaame]; // "WritingFilterCookie"
            if(cookie == null)
                cookie = new HttpCookie(CookieNaame);

            string objFilterString = "";
            objFilterString += string.Join(",", WritingSearchFilterModel.TestTypeID,
                                                WritingSearchFilterModel.Year,
                                                WritingSearchFilterModel.Term,
                                                WritingSearchFilterModel.TestNo ?? -1,
                                                WritingSearchFilterModel.BranchCode,
                                                WritingSearchFilterModel.ClassID ?? -1,
                                                WritingSearchFilterModel.IsFinish ?? -1,
                                                WritingSearchFilterModel.IsGeneralTest);

            cookie.Value = objFilterString;
            cookie.Expires = DateTime.Now.AddMinutes(2440);

            if (cookie == null)
                Response.Cookies.Add(cookie);
            else
                Response.SetCookie(cookie);

            return Json(true);
        }

        #endregion


        #region ==Helpers==

        private WritingSearchFilterViewModel GetWritingSearchFilterViewModelFromCookie(HttpCookie cookie, WritingSearchFilterViewModel WritingSearchFilterModel)
        {
            string objCartListString = cookie.Value.ToString();
            string[] cookieList = objCartListString.Split(',');

            // TODO: Delete this magic number , 2 means Selective Trial Test Course 
            WritingSearchFilterModel.TestTypeID = int.TryParse(cookieList[0], out int testTypeID) ?
                testTypeID : 2;

            WritingSearchFilterModel.Year = int.TryParse(cookieList[1], out int year) ?
                year : DateTime.Now.Year;
            
            WritingSearchFilterModel.Term = cookieList[2];
            
            WritingSearchFilterModel.TestNo = string.IsNullOrEmpty(cookieList[3]) ? 
                null : (Int32.TryParse(cookieList[3], out var tempVal) ? tempVal : (int?)null);
            
            WritingSearchFilterModel.BranchCode = cookieList[4];
            
            WritingSearchFilterModel.ClassID = string.IsNullOrEmpty(cookieList[5]) ? 
                null : (Int32.TryParse(cookieList[5], out var tempVal2) ? tempVal2 : (int?)null);
            
            WritingSearchFilterModel.IsFinish = string.IsNullOrEmpty(cookieList[6]) ? 
                null : (Int32.TryParse(cookieList[6], out var tempVal3) ? tempVal3 : (int?)null);

            WritingSearchFilterModel.IsGeneralTest = bool.TryParse(cookieList[7], out bool tempVal4) ? tempVal4 : true;

            return WritingSearchFilterModel;
        }

        #endregion
    }
}