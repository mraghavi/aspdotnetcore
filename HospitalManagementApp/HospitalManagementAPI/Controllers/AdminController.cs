using Microsoft.AspNetCore.Mvc;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Data;
using System.Linq;

namespace HospitalManagementAPI.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // Get all users
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            if (MockRepository.Users == null || !MockRepository.Users.Any())
                return NotFound("No users found.");

            return Ok(MockRepository.Users);
        }

        // Get all services
        [HttpGet("services")]
        public IActionResult GetServices()
        {
            if (MockRepository.Services == null || !MockRepository.Services.Any())
                return NotFound("No services found.");

            return Ok(MockRepository.Services);
        }

        // Create a new service
        [HttpPost("services")]
        public IActionResult CreateService([FromBody] Service service)
        {
            if (service == null || string.IsNullOrEmpty(service.Name) || string.IsNullOrEmpty(service.Description))
            {
                return BadRequest("Service name and description are required.");
            }

            service.Id = Guid.NewGuid().ToString();
            MockRepository.Services.Add(service);
            return CreatedAtAction(nameof(GetServices), new { id = service.Id }, service); // Added CreatedAtAction for better RESTful practice
        }

        // Edit an existing service
        [HttpPut("services/{id}")]
        public IActionResult EditService(string id, [FromBody] Service updatedService)
        {
            var service = MockRepository.Services.FirstOrDefault(s => s.Id == id);
            if (service == null) return NotFound("Service not found");

            service.Name = updatedService.Name;
            service.Description = updatedService.Description;
            service.IsActive = updatedService.IsActive;

            return Ok(new { message = "Service updated", service });
        }

        // Delete a service (mark as inactive)
        [HttpDelete("services/{id}")]
        public IActionResult DeleteService(string id)
        {
            var service = MockRepository.Services.FirstOrDefault(s => s.Id == id);
            if (service == null) return NotFound("Service not found");

            // Mark the service as inactive instead of deleting
            service.IsActive = false;
            return Ok(new { message = "Service marked as inactive", service });
        }

        // Get doctor registrations
        [HttpGet("doctor-registrations")]
        public IActionResult GetDoctorRegistrations()
        {
            if (MockRepository.DoctorServiceRegistrations == null || !MockRepository.DoctorServiceRegistrations.Any())
                return NotFound("No doctor registrations found.");

            return Ok(MockRepository.DoctorServiceRegistrations);
        }

        // Approve doctor registration (check if the service is active)
        [HttpPut("doctor-registrations/approve/{id}")]
        public IActionResult ApproveDoctorRegistration(string id)
        {
            var registration = MockRepository.DoctorServiceRegistrations.FirstOrDefault(r => r.Id == id);
            if (registration == null) return NotFound("Registration not found");

            // Check if the associated service is active
            var service = MockRepository.Services.FirstOrDefault(s => s.Id == registration.ServiceId);
            if (service == null || !service.IsActive)
            {
                return BadRequest("The associated service is inactive and cannot be approved.");
            }

            registration.IsApproved = true;
            return Ok(new { message = "Registration approved", registration });
        }
    }
}
