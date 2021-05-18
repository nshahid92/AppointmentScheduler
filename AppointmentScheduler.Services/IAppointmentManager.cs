using AppointmentScheduler.Services.Models;
using System;
using System.Collections.Generic;

namespace AppointmentScheduler.Services
{
    public interface IAppointmentManager
    {
        void CreateAppointment(ScheduleRequest scheduleRequest);

        IEnumerable<Appointment> GetAppointmentsForUser(Guid userUuid);
    }
}
