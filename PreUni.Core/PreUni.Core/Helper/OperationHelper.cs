using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.Core.Helper
{
    static public class OperationHelper
    {
        static public bool IsWorkingTime(DateTime now)
        {
            if (((int)now.DayOfWeek == 4 && now.Hour < 18) || (int)now.DayOfWeek < 4)
            {
                return true;
            }
            return false;
        }

        static public string GiveOperationTimeMessage(DateTime now)
        {
            if (IsWorkingTime(now))
            {
                return "Order will be prepared by this Friday";
            }
            else
            {
                return "Order will be prepared after Weekends";
            }
        }
    }
}
