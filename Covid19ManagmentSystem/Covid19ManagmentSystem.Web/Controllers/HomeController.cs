using Covid19ManagmentSystem.Web.Data;
using Covid19ManagmentSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Covid19ManagmentSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reports()
        {
            // Calculate the date range for the last month
            DateTime endDate = DateTime.Today.AddDays(-1); // Yesterday
            DateTime startDate = endDate.AddMonths(-1).AddDays(1); // One month ago from yesterday


            // Generate a list of dates for the past month
            List<DateTime> dates = Enumerable.Range(0, (endDate - startDate).Days + 1)
                                              .Select(offset => startDate.AddDays(offset))
                                              .ToList();

            // Initialize a list to hold the sick patient counts per day
            var sickPatientsCountPerDay = new List<(DateTime Date, int SickCount)>();

            // Iterate over each date and count the number of sick patients
            foreach (var date in dates)
            {
                int sickCount = _context.Statuses
                    .Where(cs => cs.StartDate <= date && (cs.RecoveryDate == null || cs.RecoveryDate >= date))
                    .Count();
              
                sickPatientsCountPerDay.Add((Date: date, SickCount: sickCount));
            }

            //return activePatientsCountsPerDay;
            // Retrieve all persons with their vaccinations included
            List<Person> persons = _context.Persons
                    .Include(p => p.Vaccinations)
                    .ToList();

            // Filter the persons based on whether they have no vaccinations
           int personsWithNoVaccinations = persons
                    .Count(p => p.Vaccinations == null || p.Vaccinations.Count == 0);

            var patientStatistics = new PatientStatistics
            {
                SickPatientsCountPerDay = sickPatientsCountPerDay,
                PersonsWithNoVaccinationsCount = personsWithNoVaccinations
            };
            return View(patientStatistics);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class PatientStatistics
    {
        public List<(DateTime Date, int SickCount)> SickPatientsCountPerDay { get; set; }
        public int PersonsWithNoVaccinationsCount { get; set; }
    }
}
