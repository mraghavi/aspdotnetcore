namespace HospitalManagementAPI.Models
{
    public class DoctorServiceRegistration
    {
        public string Id { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public bool IsApproved { get; set; }
    }
}
