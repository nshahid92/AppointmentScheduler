using AppointmentScheduler.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentScheduler.Services
{
    public class AppointmentManager : IAppointmentManager
    {
        private static Dictionary<Guid, Dictionary<string, Appointment>> UserAppointments = new Dictionary<Guid, Dictionary<string, Appointment>>();

        public void CreateAppointment(ScheduleRequest scheduleRequest)
        {
            var calendarDate = scheduleRequest.DateTime;
            var date = calendarDate.ToShortDateString();
            var startTime = calendarDate.TimeOfDay;
            var endTime = startTime.Add(TimeSpan.FromMinutes(30));
            var userUuid = scheduleRequest.UserUuid;
            var appointment = new Appointment
            {
                Date = date,
                StartTime = startTime.ToString(@"hh\:mm"),
                EndTime = endTime.ToString(@"hh\:mm")
            };

            if (!UserAppointments.ContainsKey(userUuid))
            {
                UserAppointments.Add(userUuid, new Dictionary<string, Appointment> { { date, appointment } });
            }
            else if (UserAppointments[userUuid].ContainsKey(date))
            {
                throw new InvalidOperationException("An appointment on the same calendar date already exists");
            }
            else
            {
                UserAppointments[userUuid].Add(date, appointment);
            }
        }

        public IEnumerable<Appointment> GetAppointmentsForUser(Guid userUuid)
        {
            if (!UserAppointments.ContainsKey(userUuid))
            {
                throw new InvalidOperationException("The user with given uuid does not exist in the system");
            }
            else
            {
                var appointments = UserAppointments[userUuid].Select(kvp => kvp.Value);
                return appointments;
            }
        }
    }
}
