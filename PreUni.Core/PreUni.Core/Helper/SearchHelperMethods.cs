using PreUni.Core.Model.DisplayName;
using PreUni.Core.Model.ViewModel;
using System;

namespace PreUni.Core.Helper
{
    public static class SearchHelperMethods
    {
        static public CalendarViewModel GetFilteredDate(string startDate, string endDate)
        {
            var targetDate = new CalendarViewModel();

            if (IsDefaultValue(endDate))
            {
                endDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                var viewEndDate = DateTime.Now.ToString("yyyy-MM-dd");

                targetDate.EndDate = viewEndDate;
            }
            else
                targetDate.EndDate = endDate;

            if (IsDefaultValue(startDate) || IsDefaultStartDate(startDate))
                targetDate.StartDate = LocalConstants.DefaultDate;
            else
                targetDate.StartDate = startDate;

            return targetDate;
        }

        static public string GetSearchedString(string searching)
        {
            if (IsDefaultValue(searching))
                searching = null;
            else
                searching = searching.ToLower();

            return searching;
        }

        static private bool IsDefaultValue(string val)
            => val == LocalConstants.DefaultValue ? true : false;

        static private bool IsDefaultStartDate(string date)
            => date == LocalConstants.DefaultValue || date == LocalConstants.DefaultDate ? true : false;
    }
}

#region Original Version
//if (startDate == "-1" || startDate == "1992-01-01")
//{
//    startDate = "1992-01-01";
//    ViewBag.StartDate = null;
//}
//else
//{
//    ViewBag.StartDate = targetDate.StartDate;
//}
            
#endregion