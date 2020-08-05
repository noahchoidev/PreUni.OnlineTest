namespace PreUni.Core.Helper
{
    static public class StringManager
    {
        static public string GetUserNameDeleteAlpha(string UserName)
        {
            var idxOfAlpha = UserName.IndexOf('@'); // 8
            if (idxOfAlpha == -1)
                return null;

            var idxOfLast = UserName.Length;

            UserName = UserName.Remove(idxOfAlpha, idxOfLast - idxOfAlpha);

            return UserName;
        }
    }
}