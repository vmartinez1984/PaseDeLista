using System;

namespace RollCall.Core.Entities
{
    public class ScheduleEntity : Base02Entity
    {
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
    }
}