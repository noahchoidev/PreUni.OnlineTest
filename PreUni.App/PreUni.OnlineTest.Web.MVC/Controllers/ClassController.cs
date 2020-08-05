using Microsoft.AspNet.Identity.Owin;
using PreUni.Core.Model;
using PreUni.OnlineTest.UserDAL.IdentityManagers;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PreUni.College.DAL.CollegeDbConnection;
using PreUni.OnlineTest.Web.MVC.CustomAttribute;
using PreUni.OnlineTest.Web.MVC.Helper;
using System.Threading.Tasks;
using PreUni.Core.Model.Local;
using PreUni.Core.Helper;

namespace PreUni.OnlineTest.Web.MVC.Controllers
{
    [CustomAuthorize(Roles = "Admin,Developer,Tutor,Tearcher,User,Head")]
    public class ClassController : Controller
    {
        
        #region ==Default Contructor==
        #endregion


        #region ==Identity Login Provider==

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public ApplicationRoleManager RoleManager
        {
            get => _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            private set => _roleManager = value;
        }

        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? Request.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            private set => _signInManager = value;
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        #endregion


        #region ==Action View==

        // GET: Class
        public async Task<ActionResult> Index()
        {
            //TODO: Change it not bring it from DB instead, loally use static helper functions
            //TODO: Get rid of Magic Number like YES
            CollegeDbContext DBCon = new CollegeDbContext();
            var curTerm = DBCon.TableTermInfoes.Where(x => x.IS_CURRENT == "YES").FirstOrDefault();

            var years = DateTimeHelper.MakeYearList(10);
            ViewBag.YearList = years;

            ViewBag.selectedTerm = curTerm.Term;

            // Get the current User-Role for admin-area (Other-Class in View)
            bool IsAccessible = false;
            var myRoles = this.GetUserRole();
            if (UserInfoHelper.ExistsTargetRoleFromMyRoles(myRoles,RoleEnum.Admin, RoleEnum.Head))
                IsAccessible = true;

            ViewBag.IsAccessible = IsAccessible;

            return View();
        }

        #endregion


        #region ==Partial View==

        /// <summary>
        /// This is Ajax Call Method. 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="term"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MyCLassList(int year, string term, string grade)
        {
            CollegeDbContext DBCon = new CollegeDbContext();

            // 로긴 유저 정보 필요
            var currentUserID = System.Web.HttpContext.Current.User.Identity.GetUserId<int>();

            var myClasses = from ci in DBCon.MGTableClassInfoes
                            join t in DBCon.MGTableTeachers on ci.TeacherID1 equals t.TeacherID
                            join cs in DBCon.CourseSubjectClassSubjects on ci.Subject equals cs.ClassSubject into ccs
                            from classSbj in ccs.DefaultIfEmpty()
                            where t.PUNCUserId == currentUserID // curUser.UserId
                                && ci.Year == year
                                && ci.Term == term
                                //&& ci.Grade < 7
                                && ci.BRANCHCODE == t.BRANCHCODE
                            select new ClassViewModel
                            {
                                ClassID = ci.ClassID,
                                Year = ci.Year,
                                Term = ci.Term,
                                Grade = ci.Grade,
                                Subject = ci.Subject,
                                Day = ci.Day,
                                ClassNo = ci.ClassNo,
                                CourseSubjectId = classSbj.CourseSubjectId
                            };

            // Filter from param
            if (grade != "a")
            {
                int gradeInt = Convert.ToInt32(grade);
                myClasses = myClasses.Where(x => x.Grade == gradeInt);
            }

            // Sorting
            myClasses = from m in myClasses
                        orderby m.Grade, m.Subject, m.ClassNo
                        select m;

            ViewBag.selectedYearOther = year;
            ViewBag.selectedTermOther = term;
            ViewBag.selectedGrade = grade;

            return PartialView("_MyClassesPartial", myClasses); // Params: viewName, Model
        }

        [HttpPost]
        public ActionResult OtherCLassList(int year, string term, string grade, string searchString)
        {
            // web.config 에 세팅된 현재 지점코드 가져오기
            var curBranch = System.Configuration.ConfigurationManager.AppSettings["currentBranch"];

            CollegeDbContext DBCon = new CollegeDbContext();

            // 로긴 유저 정보 사용한 쿼리 (userid, branchcode 필요)
            // 로긴 유저 정보 필요
            var currentUserID = System.Web.HttpContext.Current.User.Identity.GetUserId<int>();

            var otherClasses = from ci in DBCon.MGTableClassInfoes
                               join t in DBCon.MGTableTeachers on ci.TeacherID1 equals t.TeacherID into teachers
                               from classTea in teachers.DefaultIfEmpty()
                               join cs in DBCon.CourseSubjectClassSubjects on ci.Subject equals cs.ClassSubject into ccs
                               from classSbj in ccs.DefaultIfEmpty()
                               where
                                   ci.Year == year
                                   && ci.Term == term
                                   && ci.Grade < 7
                                   && (ci.Subject.Contains("EM") || ci.Subject.Contains("Transition"))
                                   && !ci.Day.Equals("Cyberschool")
                                   && ci.BRANCHCODE == curBranch
                               select new ClassViewModel
                               {
                                   ClassID = ci.ClassID,
                                   Year = ci.Year,
                                   Term = ci.Term,
                                   Grade = ci.Grade,
                                   Subject = ci.Subject,
                                   Day = ci.Day,
                                   StartDate = ci.Day1Start,
                                   ClassNo = ci.ClassNo,
                                   CourseSubjectId = classSbj.CourseSubjectId
                               };

            // Filter by grade;
            if (grade != "a")
            {
                int gradeInt = Convert.ToInt32(grade);
                otherClasses = otherClasses.Where(x => x.Grade == gradeInt);
            }

            // Filter by search-string
            if (!string.IsNullOrEmpty(searchString))
            {
                otherClasses = otherClasses.Where(x => x.Subject.ToLower().Contains(searchString.ToLower())
                                                    || x.ClassNo.ToString() == searchString
                                                 );
            }

            otherClasses = from o in otherClasses
                           orderby o.Grade, o.Subject, o.StartDate, o.Day, o.ClassNo
                           select o;

            ViewBag.selectedYearOther = year;
            ViewBag.selectedTermOther = term;
            ViewBag.selectedGrade = grade;

            return PartialView("_OtherClassesPartial", otherClasses);
        }
        #endregion


        #region ==Json View==
        
        public JsonResult GetYearSelectData()
        {
            CollegeDbContext DBCon = new CollegeDbContext();

            var yearLst = (from v in DBCon.MGTableClassInfoes
                           select v.Year)
                           .Distinct().ToList();

            yearLst = yearLst.OrderByDescending(x => x).ToList();

            return Json(yearLst);
        }

        #endregion


        #region ==Helpers==


        #endregion
    }
}