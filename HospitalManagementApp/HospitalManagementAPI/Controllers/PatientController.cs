using Microsoft.AspNetCore.Mvc;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Data;

namespace HospitalManagementAPI.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        [HttpGet("services")]
        public IActionResult GetApprovedServices()
        {
            var approved = MockRepository.DoctorServiceRegistrations
                .Where(r => r.IsApproved)
                .GroupBy(r => r.ServiceName)
                .Select(group => new
                {
                    ServiceName = group.Key,
                    Doctors = group.Select(r => r.DoctorName).ToList()
                }).ToList();

            return Ok(approved);
        }
    }
}
