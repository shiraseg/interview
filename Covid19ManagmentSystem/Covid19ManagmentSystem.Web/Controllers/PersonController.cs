using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19ManagmentSystem.Web.Data;
using Covid19ManagmentSystem.Web.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Covid19ManagmentSystem.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public PersonController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Person
        public async Task<IActionResult> Index(string searchString)
        {
            var persons = await _context.Persons.ToListAsync();
            if(!String.IsNullOrEmpty(searchString))
            {
                persons = persons.Where(i => i.PersonId.Contains(searchString)).ToList();
            }
            return View(persons);
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Person person = _context.Persons
               .Include(e => e.Vaccinations)
               .Include(e => e.CovidStatuses)
               .Where(e => e.Id == id).FirstOrDefault();
            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            var model = new Person();
            model.Vaccinations.Add(new Vaccination() { Id = 1 }); // Add an empty vaccination initially
            model.CovidStatuses.Add(new CovidStatus() { Id =  1}); // Add an empty Covid status initially
            return View(model);
        }


        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            for (int i = 0; i < person.Vaccinations.Count; i++)
            {
                var vaccin = person.Vaccinations[i];
                if (vaccin.Type == null || vaccin.Date == null)
                {
                    person.Vaccinations.RemoveAt(i);
                }
            }
            for (int i = 0; i < person.CovidStatuses.Count; i++)
            {
                var status = person.CovidStatuses[i];
                if (status.StartDate == null)
                {
                    person.CovidStatuses.RemoveAt(i);
                }
            }
            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      



        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Person person = _context.Persons
              .Include(e => e.Vaccinations)
              .Include(e => e.CovidStatuses)
              .Where(e => e.Id == id).FirstOrDefault();
            if (person.Vaccinations.Count == 0)
                person.Vaccinations.Add(new Vaccination() { Id = 1 }); // Add an empty vaccination initially
            if (person.CovidStatuses.Count == 0)
                person.CovidStatuses.Add(new CovidStatus() { Id = 1 }); // Add an empty Covid status initially
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Person person)
        {   try
            {
                for (int i = 0; i < person.Vaccinations.Count; i++)
                {
                    var vaccin = person.Vaccinations[i];
                    if (vaccin.Type == null || vaccin.Date == null)
                    {
                        person.Vaccinations.RemoveAt(i);
                    }
                }
                for (int i = 0; i < person.CovidStatuses.Count; i++)
                {
                    var status = person.CovidStatuses[i];
                    if (status.StartDate == null)
                    {
                        person.CovidStatuses.RemoveAt(i);
                    }
                }

                _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
