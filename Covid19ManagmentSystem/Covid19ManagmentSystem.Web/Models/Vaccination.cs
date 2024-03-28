using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19ManagmentSystem.Web.Models
{
    public class Vaccination
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Person")]
        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } // Mark as virtual for lazy loading

    
        public VaccineType? Type { get; set; } = null;

        [DataType(DataType.Date)]

        public DateTime? Date { get; set; } = default(DateTime?);
    }
}
