﻿namespace HospitalManagementAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin, Doctor, Patient

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

   
   
}
