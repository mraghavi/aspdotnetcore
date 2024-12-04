using Microsoft.AspNetCore.Mvc;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Data;
using System.Linq;

namespace HospitalManagementAPI.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        // Get active services for a specific doctor
        [HttpGet("services/{doctorId}")]
        public IActionResult GetDoctorServices(string doctorId)
        {
            var doctor = MockRepository.Users.FirstOrDefault(u => u.Id == doctorId && u.Role == "Doctor");
            if (doctor == null)
            {
                return NotFound("Doctor not found.");
            }

            // Return active services for the doctor
            var services = MockRepository.Services.Where(s => s.IsActive).ToList();
            if (services.Count == 0)
            {
                return NotFound("No active services available for this doctor.");
            }

            return Ok(services);
        }

        // Register for a service (check if the service is active)
        [HttpPost("register-service")]
        public IActionResult RegisterForService([FromBody] DoctorServiceRegistration registration)
        {
            // Check if the service is active before allowing registration
            var service = MockRepository.Services.FirstOrDefault(s => s.Id == registration.ServiceId);
            if (service == null || !service.IsActive)
            {
                return BadRequest("The service is inactive and cannot be registered for.");
            }

            registration.Id = Guid.NewGuid().ToString();
            registration.IsApproved = false; // Pending status
            registration.DoctorName = MockRepository.Users.FirstOrDefault(u => u.Id == registration.DoctorId)?.Name;
            MockRepository.DoctorServiceRegistrations.Add(registration);
            return Ok("Service registration submitted. Status: Pending");
        }

        // Get doctor registrations (with status)
        [HttpGet("doctor-registrations/{doctorId}")]
        public IActionResult GetDoctorRegistrations(string doctorId)
        {
            var registrations = MockRepository.DoctorServiceRegistrations
                .Where(r => r.DoctorId == doctorId)
                .Select(r => new
                {
                    r.ServiceName,
                    Status = r.IsApproved ? "Approved" : "Pending"
                }).ToList();

            if (registrations.Count == 0)
            {
                return NotFound("No registrations found for this doctor.");
            }

            return Ok(registrations);
        }
    }
}
