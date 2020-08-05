using System;

namespace PreUni.Core.Model
{
    abstract public class BasicEntity
    {
        public DateTime? EditedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
