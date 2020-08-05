using System;

namespace PreUni.Core.Model
{
    public class ScanningTimeModel
    {
        public int ID { get; set; }
        
        public TimeSpan? StartTime { get; set; }
        
        public TimeSpan? EndTime { get; set; }
    }
}
