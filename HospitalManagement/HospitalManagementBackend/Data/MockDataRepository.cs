using HospitalManagementBackend.Models;


namespace HospitalManagementBackend.Data
{
    public static class MockDataRepository
    {
        // Static list to simulate database storage
        public static List<User> Users = new List<User>
        {
            // Pre-populated mock data (optional)
            new User
            {
                Id = Guid.NewGuid(),
                Role = "Admin",
                Username = "admin1",
                Password = "admin123"
            },
            new User
            {
                Id = Guid.NewGuid(),
                Role = "Doctor",
                Username = "doctor1",
                Password = "doc123"
            },
            new User
            {
                Id = Guid.NewGuid(),
                Role = "Patient",
                Username = "patient1",
                Password = "patient123"
            }
        };
    }
}
