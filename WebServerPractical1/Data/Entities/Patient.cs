using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebServerPractical1.Data.Entities
{
    [Table(name: "Patient", Schema = "public")]
    public class Patient
    {
        [Key]
        public string Id { get; set; }

        [Required]

        public string FirstName { get; set; }

        [Required]

        public string LastName { get; set; }


        public string Email { get; set; }


        public string PhoneNumber { get; set; }


        public string? AlternatePhoneNumber { get; set; }


        public string AddressFirstLine { get; set; }

        public string? AddressSecondLine { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}