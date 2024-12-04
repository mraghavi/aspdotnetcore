using HospitalManagementBackend.Models;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementBackend.Data;

namespace HospitalManagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase

    {

        // Get all services with corresponding approved doctors
        [HttpGet("services-with-doctors")]
        public IActionResult GetServicesWithDoctors()
        {
            var servicesWithDoctors = MockDataRepository.Services.Select(service => new
            {
                ServiceName = service.Name,
                Doctors = MockDataRepository.DoctorServiceRegistrations
                    .Where(registration => registration.ServiceId == service.Id && registration.IsApproved)
                    .Select(registration => MockDataRepository.Users
                        .FirstOrDefault(user => user.Id == registration.DoctorId)?.Username)
                    .Where(doctorName => !string.IsNullOrEmpty(doctorName))
                    .ToList()
            }).ToList();

            return Ok(servicesWithDoctors);
        }

    }
}
