using PreUni.Core.Model.Local;

namespace PreUni.Core.Model
{
    public class BoardIndexViewModel
    {
        public int? BoardId { get; set; }

        //public int CategoryId { get; set; }
        //public string Category { get; set; }

        public string UserID { get; set; }

        public string LastUserId { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public string BoardDate { get; set; }

        public string ImgUrl { get; set; }

        public string BranchName { get; set; }

        public int? BranchCode { get; set; }

        public StateEnum BranchState { get; set; } // ALL,NSW,SA,VIC,ETC

        public int UserState { get; set; }

    }

    public class EditBoardViewModel
    {
        public int BoardId { get; set; }

        //public int CategoryID { get; set; }
        //public string Category { get; set; }

        public string UserId { get; set; }

        public string LastUserId { get; set; }


        public string Title { get; set; }


        public string Contents { get; set; }

        public string BoardEdittedDate { get; set; }

        public string ImgUrl { get; set; }

        public string BranchName { get; set; }

        public int? BranchCode { get; set; }

        public StateEnum BranchState { get; set; } // ALL,NSW,SA,VIC,ETC

        public int UserState { get; set; }

    }

    public class BoardItemViewModel
    {
        public int BoardId { get; set; }

        public string BoardNumber { get; set; }


        //public string Category { get; set; }

        public string LastUserId { get; set; }


        public string Title { get; set; }


        public string Contents { get; set; }

        public string BoardDate { get; set; }

        public string ImgUrl { get; set; }

        public StateEnum BranchState { get; set; } // ALL,NSW,SA,VIC,ETC

        public int UserState { get; set; }
    }
}
