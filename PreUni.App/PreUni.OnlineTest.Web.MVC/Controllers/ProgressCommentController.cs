using Microsoft.AspNet.Identity;
using PreUni.College.DAL.Model;
using PreUni.College.DAL.Repository;
using PreUni.Core.Model.Local;
using PreUni.OnlineTest.Web.MVC.CustomAttribute;
using PreUni.OnlineTest.Web.MVC.Helper;
using PreUni.OnlineTest.Web.MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PreUni.OnlineTest.Web.MVC.Controllers
{
    [Authorize]
    //[CustomAuthorize(RoleEnum.Admin, RoleEnum.Teacher,RoleEnum.Head,RoleEnum.Branch)]
    public class ProgressCommentController : ConvertPartialViewToString
    {
        private ITermTestCommentRepository mTermTestCommentRepository;

        public ProgressCommentController(ICreateEFCollegeRepository createCollegeRepository)
        {
            mTermTestCommentRepository = createCollegeRepository.CreateTermTestCommentRepository();
        }

        //
        // GET: /TermTestComment/
        public ActionResult Index(int? classId)
        {
            if (!classId.HasValue)
                return RedirectToAction("Index", "Class");

            var studentList = mTermTestCommentRepository.GetStudentListForProgress(classId.Value);

            if (studentList.Count() == 0)
                return RedirectToAction("HandleNoData", "Home");

            ViewBag.ClassName = mTermTestCommentRepository.GetClassName(classId.Value);
            
            return View(studentList);
        }

        [HttpPost]
        public ActionResult GetNewCommentTabControl(int? studentId, int? commentIdx)
        {
            if (!studentId.HasValue || !commentIdx.HasValue)
                return HttpNotFound();

            var model = new ProgressCommentTabControlViewModel
            {
                StudentID = studentId.Value,
                CommentIndex = commentIdx.Value,
            };
            return PartialView("_TabControl", model); // viewName, targetModel
        }

        [HttpPost]
        public ActionResult GetNewCommentTabContent(int? classId, int? studentId, int? commentIdx)
        {
            if (!classId.HasValue || !studentId.HasValue || !commentIdx.HasValue)
                return HttpNotFound();

            var studentFound = mTermTestCommentRepository.GetStudentListForProgress(classId.Value,studentId).FirstOrDefault();
            
            var model = new ProgressCommentTabContentViewModel
            {
                ProgressCommentVM = studentFound, // it looks weird, but see 
                StudentID = studentId.Value,
                CommentIndex = commentIdx.Value,
            };


            return PartialView("_TabContent", model); // viewName, targetModel
        }

        public ActionResult TestStoreProcedure()
        {
            int ClassID = 38202;
            int StudentID = 4074621;

            var list = mTermTestCommentRepository.GetOnlineQuizScores(ClassID, StudentID);

            var cnt = list.Count();

            return View();
        }

        [HttpPost]
        public ActionResult GetHomeworkMark(int ClassID, int StudentID, int Year, string Term)
        {
            return Json(new
            {
                QuizView = RenderPartialViewToString("_OnlineQuiz",
                                                     mTermTestCommentRepository.GetOnlineQuizScores(ClassID,
                                                                                                    StudentID)),
                HomeworkView = RenderPartialViewToString("_HomeworkMark",
                                                         mTermTestCommentRepository.GetHomeworkMark(ClassID,
                                                                                                   StudentID,
                                                                                                   Year,
                                                                                                   Term))
            });
        }

        /// <summary>
        /// TODO: make these long parameters a ViewModel
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(int ClassID,
                                 int StudentID, 
                                 string Attitude1,
                                 string Attitude2,
                                 string Attitude3,
                                 string Comment,
                                 int Week, 
                                 int Teacher,
                                 string Editor,
                                 int CommentID)
        {
            //PUNC.TEACHER.Models.UserProfile curUser = Session["User"] as PUNC.TEACHER.Models.UserProfile;

            var userName = User.Identity.GetUserName();

            int ReturnCommentID = 0;

            ReturnCommentID = mTermTestCommentRepository.SaveProgressComment(
                                                                               ClassID,
                                                                               StudentID, 
                                                                               Attitude1,
                                                                               Attitude2, 
                                                                               Attitude3,
                                                                               Comment, 
                                                                               Week,
                                                                               Teacher, 
                                                                               Editor,
                                                                               CommentID,
                                                                               userName
                                                                            );

            return Json(new { Result = ReturnCommentID });
        }
    }
}