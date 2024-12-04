using System.Collections.Generic;
using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.Data
{
    public static class MockRepository
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Service> Services { get; set; } = new List<Service>();
        public static List<DoctorServiceRegistration> DoctorServiceRegistrations { get; set; } = new List<DoctorServiceRegistration>();

        static MockRepository()
        {
            // Initialize mock data
            Users.Add(new User { Name = "Admin", Role = "Admin", Email = "admin@hospital.com", Password = "admin123" });
            Users.Add(new User { Name = "Dr. Alice", Role = "Doctor", Email = "alice@hospital.com", Password = "doctor123" });
            Services.Add(new Service { Id = Guid.NewGuid().ToString(), Name = "Cardiology", Description = "Heart-related services", IsActive = true });
            Services.Add(new Service { Id = Guid.NewGuid().ToString(), Name = "Neurology", Description = "Brain and nerve-related services", IsActive = true });
        }
    }
}
