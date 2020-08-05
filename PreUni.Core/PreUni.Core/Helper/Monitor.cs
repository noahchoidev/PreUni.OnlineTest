using System;
using System.IO;
using System.Web;

namespace PreUni.Core.Helper
{
    static public class Monitor
    {
        public static void logging(string user, string log)
        {
            //Set time
            var now = DateTimeHelper.GetCurrentTime();

            var SaveDir = new DirectoryInfo(string.Format("{0}Infra\\SystemLog.txt", HttpContext.Current.Server.MapPath("~")));

            string appendText = "|| Time : " + now.ToString("dd/MM/yy hh:mm:ss") + " || User : " + user + " || Log : " + log + Environment.NewLine;
            //File.AppendAllText(SaveDir.ToString(), appendText);
        }
    }
}
