using StudentApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Repositories
{
    public class StudentRepository
    {
        private readonly List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Honey", Age = 20, Course = "Mathematics" },
            new Student { Id = 2, Name = "Bunny", Age = 22, Course = "Physics" }
        };

        // Get all students asynchronously
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await Task.FromResult(_students);
        }

        // Get a student by ID asynchronously
        public async Task<Student> GetAsync(int id)
        {
            return await Task.FromResult(_students.FirstOrDefault(student => student.Id == id));
        }

        // Add a student asynchronously
        public async Task AddAsync(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;  // Ensure unique IDs
            _students.Add(student);
            await Task.CompletedTask;
        }

        // Update a student asynchronously
        public async Task<bool> UpdateAsync(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing == null) return await Task.FromResult(false);

            existing.Name = student.Name;
            existing.Age = student.Age;
            existing.Course = student.Course;
            return await Task.FromResult(true);
        }

        // Delete a student asynchronously
        public async Task<bool> DeleteAsync(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return await Task.FromResult(false);

            _students.Remove(student);
            return await Task.FromResult(true);
        }
    }
}
