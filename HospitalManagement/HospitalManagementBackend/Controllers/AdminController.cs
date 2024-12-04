using HospitalManagementBackend.Models;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementBackend.Data;

namespace HospitalManagementBackend.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        // Get all doctors and patients
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var users = MockDataRepository.Users
                .Where(u => u.Role == "Doctor" || u.Role == "Patient")
                .Select(u => new { u.Username, u.Role })
                .ToList();

            return Ok(users);
        }

        // Add a service
        [HttpPost("add-service")]
        public IActionResult AddService([FromBody] Service newService)
        {
            if (MockDataRepository.Services.Any(s => s.Name == newService.Name))
            {
                return BadRequest("Service already exists.");
            }

            newService.Id = Guid.NewGuid();
            MockDataRepository.Services.Add(newService);
            return Ok(newService);
        }

        // Remove a service
        [HttpDelete("remove-service/{id}")]
        public IActionResult RemoveService(Guid id)
        {
            var service = MockDataRepository.Services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound("Service not found.");
            }

            MockDataRepository.Services.Remove(service);
            return Ok("Service removed successfully.");
        }

        // Get pending doctor registrations
        [HttpGet("pending-registrations")]
        public IActionResult GetPendingRegistrations()
        {
            var pendingRegistrations = MockDataRepository.DoctorServiceRegistrations
                .Where(r => !r.IsApproved)
                .Select(r => new
                {
                    r.Id,
                    DoctorId = MockDataRepository.Users.FirstOrDefault(u => u.Id == r.DoctorId)?.Username,
                    ServiceName = MockDataRepository.Services.FirstOrDefault(s => s.Id == r.ServiceId)?.Name
                }).ToList();

            return Ok(pendingRegistrations);
        }

        // Approve a doctor’s registration
        [HttpPut("approve-registration/{id}")]
        public IActionResult ApproveRegistration(Guid id)
        {
            var registration = MockDataRepository.DoctorServiceRegistrations.FirstOrDefault(r => r.Id == id);
            if (registration == null)
            {
                return NotFound("Registration not found.");
            }

            registration.IsApproved = true;
            return Ok("Registration approved.");
        }
    }
}
