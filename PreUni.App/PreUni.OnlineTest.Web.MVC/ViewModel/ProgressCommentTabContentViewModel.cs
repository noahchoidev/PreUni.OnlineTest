using PreUni.College.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.OnlineTest.Web.MVC.ViewModel
{
    public class ProgressCommentTabContentViewModel
    {
        public ProgressCommentVM ProgressCommentVM { get; set; }

        public int StudentID { get; set; }

        public int CommentIndex { get; set; }
    }
}