using System;

namespace PreUni.Core.Model
{
    public class BoardModel
    {
        public int BoardId { get; set; }

        public string UserId { get; set; }
       
        public string LastUserId { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string ImgUrl { get; set; }
       
        public int? BranchCode { get; set; }
    }
}
