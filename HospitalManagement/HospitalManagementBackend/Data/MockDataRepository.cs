using HospitalManagementBackend.Models;

namespace HospitalManagementBackend.Data
{
    public static class MockDataRepository
    {
        // Static users
        public static List<User> Users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Role = "Admin", Username = "admin1", Password = "admin123" },
            new User { Id = Guid.NewGuid(), Role = "Doctor", Username = "doctor1", Password = "doc123" },
            new User { Id = Guid.NewGuid(), Role = "Patient", Username = "patient1", Password = "patient123" }
        };

        // Static services
        public static List<Service> Services = new List<Service>();

        // Static doctor service registrations
        public static List<DoctorServiceRegistration> DoctorServiceRegistrations = new List<DoctorServiceRegistration>();
    }
}
