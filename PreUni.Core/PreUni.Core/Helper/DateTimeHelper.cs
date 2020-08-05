using PreUni.Core.Model.Local;
using System;
using System.Collections.Generic;

namespace PreUni.Core.Helper
{
    public static class DateTimeHelper
    {
        public static int[] MakeYearList(int yearLength)
        {
            int[] years = new int[yearLength];

            years[0] = DateTime.Now.AddYears(1).Year;
            for (int i = 1; i < years.Length; i++)
            {
                int date = (i - 1) * (-1);
                years[i] = DateTime.Now.AddYears(date).Year;
            }
            return years;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns>This return values can be the number of total 8. </returns>
        public static string GetCurrentTerm(DateTime target)
        {
            // Set 8 boundaries to distingish the terms using the passed date
            var month = target.Month;
            month = month == 12 ? 0 : month;
            var day = target.Day;

            var list = new List<int[]>();

            var summer_S = new int[3] { 0, 24, 1 }; // Month, Day, Indicator for Order ( 0 means December)
            var summer_E = new int[3] { 1, 24, 1 };
            list.Add(summer_S);
            list.Add(summer_E);

            var autumn_S = new int[3] { 4, 10, 3 };
            var autumn_E = new int[3] { 4, 27, 3 };
            list.Add(autumn_S);
            list.Add(autumn_E);

            var winter_S = new int[3] { 7, 6, 5 };
            var winter_E = new int[3] { 7, 17, 5 };
            list.Add(winter_S);
            list.Add(winter_E);

            var spring_S = new int[3] { 9, 28, 7 };
            var spring_E = new int[3] { 10, 9, 7 };
            list.Add(spring_S);
            list.Add(spring_E);

            int result = 0; //  new int[2];

            foreach (var item in list)
            {
                if (month > item[0])
                {
                    continue;
                }
                else if (month == item[0])
                {
                    if (day > item[1])
                    {
                        continue;
                    }
                    else if (day == item[1])
                    {
                        result = item[2];
                        return ConvertDigitintoTerm(result);
                    }
                    else
                    {
                        result = item[2] - 1;
                        return ConvertDigitintoTerm(result);
                    }
                }
                else
                {
                    result = item[2] - 1;
                    return ConvertDigitintoTerm(result);
                }
            }

            result = 8;
            return ConvertDigitintoTerm(result);
        }

        static public string ConvertDigitintoTerm(int target)
        {
            switch (target)
            {
                case 1:
                    return "Winter";
                case 2:
                    return "1";
                case 3:
                    return "Spring";
                case 4:
                    return "2";
                case 5:
                    return "Summer";
                case 6:
                    return "3";
                case 7:
                    return "Autumn";
                default:
                    return "4";
            }
        }

        public static DateTime GetCurrentTime()
        {
            //Set time
            DateTime serverTime = DateTime.Now;
            var today = TimeZoneInfo.ConvertTime(serverTime, TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time"));
            return today;
        }

        public static int calculateTotalWeek(DateTime StartDate, DateTime EndDate)
        {
            bool check = true;
            int totalweek = 1;
            DateTime movingWeek = StartDate;

            while (check)
            {
                movingWeek = movingWeek.AddDays(7);

                if (movingWeek <= EndDate)
                    totalweek++;
                else
                    check = false;
            }
            return totalweek;
        }

        public static int CalculateCurrentWeekFromTermStartDate(DateTime termStartDate, DateTime currentDate)
        {
            bool checkWeek = true;

            if (termStartDate.AddDays(-7) >= currentDate)
                return -1;
            else if (currentDate < termStartDate)
                return 0;

            int week = 1;
            DateTime movingByWeek = termStartDate;

            while (checkWeek)
            {
                movingByWeek = movingByWeek.AddDays(7);
                if (currentDate < movingByWeek)
                    checkWeek = false;
                else
                    week++;

                //if (week > TermInfoConstant.TERMDURATION)
                //    return TermInfoConstant.TERMDURATION;
            }
            return week;
        }
    }
}