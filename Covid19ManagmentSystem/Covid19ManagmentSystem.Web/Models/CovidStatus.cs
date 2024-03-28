using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19ManagmentSystem.Web.Models
{
    public class CovidStatus { 
        [Key]
        public int Id { get; set; }


        [ForeignKey("Person")]
        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } // Mark as virtual for lazy loading

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; } = default(DateTime?);

        [DataType(DataType.Date)]
        public DateTime? RecoveryDate { get; set; } = default(DateTime?);

       
    }

}
