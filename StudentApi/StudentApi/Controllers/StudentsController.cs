using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentApi.Models;
using StudentApi.Repositories;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentRepository _repository = new();
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        // Get all students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _repository.GetAllAsync();
            _logger.LogInformation($"Fetched {students.Count()} students.");
            return Ok(students);
        }

        // Get a specific student by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _repository.GetAsync(id);
            if (student == null)
            {
                _logger.LogWarning($"Student with ID {id} not found.");
                return NotFound();
            }
            _logger.LogInformation($"Fetched student with ID {id}: {student.Name}");
            return Ok(student);
        }

        // Add a new student
        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (student == null)
            {
                _logger.LogError("Received null student");
                return BadRequest("Student is null");
            }

            await _repository.AddAsync(student);
            _logger.LogInformation($"Added new student: {student.Name}, ID: {student.Id}");

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // Update an existing student
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (id != student.Id)
            {
                _logger.LogError($"ID mismatch: {id} != {student.Id}");
                return BadRequest("ID mismatch");
            }

            var updated = await _repository.UpdateAsync(student);
            if (!updated)
            {
                _logger.LogWarning($"Student with ID {id} not found for update.");
                return NotFound();
            }

            _logger.LogInformation($"Updated student with ID {id}: {student.Name}");
            return NoContent();
        }

        // Delete a student
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                _logger.LogWarning($"Student with ID {id} not found for deletion.");
                return NotFound();
            }

            _logger.LogInformation($"Deleted student with ID {id}");
            return NoContent();
        }
    }
}
