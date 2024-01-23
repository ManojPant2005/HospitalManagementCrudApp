using System.ComponentModel.DataAnnotations;

namespace WebServerPractical1.Data.Entities
{ 
     public class Department : BaseEntity
         {
            [Required]
            public string Name { get; set; }

            [StringLength(200)]
            public string? Description { get; set; }

            public virtual ICollection<Doctor>? Doctors { get; set; }
        }
 }

