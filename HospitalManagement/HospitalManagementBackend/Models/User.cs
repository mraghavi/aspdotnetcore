namespace HospitalManagementBackend.Models
{
    public class User
    {
       
            public Guid Id { get; set; } // Unique identifier for each user
            public string Role { get; set; } // Admin, Doctor, or Patient
            public string Username { get; set; } // Unique username
            public string Password { get; set; } // User password
        
    }
}
