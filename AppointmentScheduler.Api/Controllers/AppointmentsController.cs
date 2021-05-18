using AppointmentScheduler.Services;
using AppointmentScheduler.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppointmentScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentManager appointmentManager;
        public AppointmentsController(IAppointmentManager appointmentManager)
        {
            this.appointmentManager = appointmentManager;
        }

        // GET api/<AppointmentsController>/aeb59805-6525-462f-8d10-301bfb0b153c
        [HttpGet("{uuid}")]
        public ActionResult<IEnumerable<Appointment>> Get(Guid uuid)
        {
            try
            {
                var result = appointmentManager.GetAppointmentsForUser(uuid);

                if (!result.Any())
                {
                    return Ok($"No appointments exist for this user");
                }

                return Ok(result);
            }
            catch (InvalidOperationException exception)
            {
                return StatusCode(404, exception.Message);
            }
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] ScheduleRequest scheduleRequest)
        {
            appointmentManager.CreateAppointment(scheduleRequest);
            return Ok();
        }
    }
}
