using System;

namespace AppointmentScheduler.Services.Models
{
    public class ScheduleRequest
    {
        public Guid UserUuid { get; set; }
        public DateTime DateTime { get; set; }
    }
}
