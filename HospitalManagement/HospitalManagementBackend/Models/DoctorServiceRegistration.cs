namespace HospitalManagementBackend.Models
{
    public class DoctorServiceRegistration
    {
        public Guid Id { get; set; } // Unique identifier for the registration
        public Guid DoctorId { get; set; } // ID of the doctor registering
        public Guid ServiceId { get; set; } // ID of the service
        public bool IsApproved { get; set; } // Approval status
    }
}
