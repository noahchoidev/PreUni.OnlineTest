namespace PreUni.Core.Model
{
    public class ImageModel
    {
        public int ImageID { get; set; }

        //[Display(Name = "이미지 이름")]
        //[StringLength(50, ErrorMessage = "최대 50자 내로 써주세요!")]
        public string ImageName { get; set; }

        //[Display(Name = "이미지 경로")]
        //[StringLength(200, ErrorMessage = "최대 50자 내로 써주세요!")]
        public string ImagePath { get; set; }

        public int PostID { get; set; }
        
        //public Post Post { get; set; }
    }
}
