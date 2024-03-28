using Covid19ManagmentSystem.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Covid19ManagmentSystem.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<CovidStatus> Statuses { get; set; }
    }
}
