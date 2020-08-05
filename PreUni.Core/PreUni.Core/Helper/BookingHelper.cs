using System;

namespace PreUni.Core.Helper
{
    public class BookingHelper
    {
        private DayOfWeek StandardExpireDayOfWeek { get; set; }
        private int standardHour { get; set; }
        private int standardMinute { get; set; }
        private DateTime LastDate { get; set; }

        public BookingHelper(DayOfWeek StandardDayOfWeek, int standardHour = 22, int standardMinute = 00)
        {
            this.StandardExpireDayOfWeek = StandardDayOfWeek;
            this.standardHour = standardHour;
            this.standardMinute = standardMinute;
        }

        public bool IsBookingAvailable(DateTime bookingTime)
        {
            if (!IsOperatingTimeOver(bookingTime))
            {
                if (!IsStandardLastDateTime(bookingTime))
                {
                    return true;
                }
            }
            return false;
        }

        public DateTime GetExpireBookingDateTime(DateTime current)
        {
            //var current = DateTimeHelper.GetCurrentTime();
            int offsetAmount = 0;
            if (current.DayOfWeek != DayOfWeek.Sunday)
                offsetAmount = (int)StandardExpireDayOfWeek - (int)current.DayOfWeek;
            else
                offsetAmount = (int)StandardExpireDayOfWeek - 7;

            var dateTime = new DateTime(current.Year,
                                        current.Month,
                                        current.Day,
                                        standardHour,
                                        standardMinute,
                                        00);
            
            var ExpireBookingDateTime = dateTime.AddDays(offsetAmount);

            LastDate = ExpireBookingDateTime;

            return ExpireBookingDateTime;
        }

        public bool IsStandardLastDateTime(DateTime TargetTime)
        {
            if (TargetTime.DayOfWeek == StandardExpireDayOfWeek
                     && TargetTime.Hour < standardHour)
            {
                return true;
            }
            return false;
        }

        public bool IsOperatingTimeOver(DateTime TargetTime)
        {
            if (DayOfWeek.Sunday == TargetTime.DayOfWeek)
                return true;
            else if (TargetTime.DayOfWeek > StandardExpireDayOfWeek) // StandardDayOfWeek is Fri
                return true;
            else if(TargetTime.DayOfWeek == StandardExpireDayOfWeek
                    && TargetTime.Hour >= standardHour
                    && TargetTime.Minute >= standardMinute)
                return true;
            return false;
        }

        public DateTime? MakeBookingDate(DateTime TargetDateTime)
        {
            var expireDate = GetExpireBookingDateTime(TargetDateTime);

            if (IsOperatingTimeOver(TargetDateTime))
            {
                return expireDate.AddDays(7);
            }
            else if(IsStandardLastDateTime(TargetDateTime))
            {
                return null;
            }
            else
            {
                return expireDate;
            }
        }
    }
}