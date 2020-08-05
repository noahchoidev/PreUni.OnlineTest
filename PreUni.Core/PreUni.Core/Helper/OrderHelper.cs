using System;

namespace PreUni.Core.Helper
{
    static public class OrderHelper
    {
        static public string GenerateOrderNo(int branchCode)
        {
            var currentTime = DateTimeHelper.GetCurrentTime();
            string orderNo = string.Empty;

            orderNo = currentTime.Year.ToString()
                      + "-"
                      + currentTime.Month.ToString("d2")
                      + "-"
                      + branchCode.ToString() // .ToString("d2")
                      + "-"
                      + new Random().Next().ToString("d4"); //+ orderSeqs.OrderSeq.ToString("d4");

            return orderNo;
        }

        static public bool IsHolidayTerm(string TermName)
        {
            if (Int32.TryParse(TermName, out int term))
                return false;
            else
                return true;
        }
    }
}