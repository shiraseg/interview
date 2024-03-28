using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Covid19ManagmentSystem.Web.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Person ID must be exactly 9 digits.")]

        public string PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; } = default(DateTime?);
        [Required]
        [RegularExpression(@"^\d{7,10}$", ErrorMessage = "Phone number must be between 7 to 10 digits.")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile phone must be exactly 10 digits.")]

        public string PrivatePhone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int streetNumber { get; set; }
        // Note: These properties are not mapped to the database
        public virtual List<Vaccination>? Vaccinations { get; set; } = new List<Vaccination>();
        public virtual List<CovidStatus>? CovidStatuses { get; set; } = new List<CovidStatus>();
    }
}

