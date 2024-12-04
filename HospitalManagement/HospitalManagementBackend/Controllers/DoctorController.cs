using HospitalManagementBackend.Models;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementBackend.Data;

namespace HospitalManagementBackend.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        // Get all services
        [HttpGet("services")]
        public IActionResult GetServices()
        {
            return Ok(MockDataRepository.Services);
        }

        // Register for a service
        [HttpPost("register-service")]
        public IActionResult RegisterForService([FromBody] DoctorServiceRegistration registration)
        {
            var doctor = MockDataRepository.Users.FirstOrDefault(u => u.Id == registration.DoctorId && u.Role == "Doctor");
            var service = MockDataRepository.Services.FirstOrDefault(s => s.Id == registration.ServiceId);

            if (doctor == null || service == null)
            {
                return BadRequest("Invalid doctor or service.");
            }

            registration.Id = Guid.NewGuid();
            registration.IsApproved = false; // Set to false initially
            MockDataRepository.DoctorServiceRegistrations.Add(registration);
            return Ok(registration);
        }
        // Get pending registrations for a doctor
        [HttpGet("pending-services/{doctorId}")]
        public IActionResult GetPendingServices(Guid doctorId)
        {
            var pendingRegistrations = MockDataRepository.DoctorServiceRegistrations
                .Where(r => r.DoctorId == doctorId && !r.IsApproved)
                .Select(r => MockDataRepository.Services.FirstOrDefault(s => s.Id == r.ServiceId))
                .ToList();

            return Ok(pendingRegistrations);
        }


        // Get approved services for a doctor
        [HttpGet("approved-services/{doctorId}")]
        public IActionResult GetApprovedServices(Guid doctorId)
        {
            var approvedServices = MockDataRepository.DoctorServiceRegistrations
                .Where(r => r.DoctorId == doctorId && r.IsApproved)
                .Select(r => MockDataRepository.Services.FirstOrDefault(s => s.Id == r.ServiceId))
                .ToList();

            return Ok(approvedServices);
        }
    }
}
