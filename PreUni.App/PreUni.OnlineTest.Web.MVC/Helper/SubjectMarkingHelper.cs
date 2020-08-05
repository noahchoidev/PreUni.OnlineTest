namespace PreUni.OnlineTest.Web.MVC.Helper
{
    public static class SubjectMarkingHelper
    {
        /// <summary>
        /// Calculate and reutrn total score using paseed mark, which consists of 5 consecutive char. 
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public static int CalculateWritingScore(string mark)
        {
            int totalScore = 0;

            // Split mark and store it into container
            foreach(char item in mark)
            {
                if(int.TryParse(item.ToString(),out int target))
                    totalScore += target;
            }

            return totalScore;
        }
    }
}