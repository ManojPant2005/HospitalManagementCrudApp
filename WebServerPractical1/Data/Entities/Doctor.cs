using System.ComponentModel.DataAnnotations;

namespace WebServerPractical1.Data.Entities
{
    public class Doctor : BaseEntity
    {
        [Key]
        public int DoctorID { get; set; }       
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public double Salary { get; set; }
        public byte[]? Picture { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Bio { get; set; }

        [Range(1, 1000, ErrorMessage = "Please select Department")]
        public int DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
