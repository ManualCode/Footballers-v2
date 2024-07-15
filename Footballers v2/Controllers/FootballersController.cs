using Footballers_v2.Data;
using Footballers_v2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Footballers_v2.Controllers
{
    public class FootballersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public FootballersController(ApplicationDbContext dbContext)
        { 
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFootballerViewModel viewModel)
        {
            var allowed_countries = new string[] { "Россия", "США", "Италия" };
            if (!allowed_countries.Any(c => c == viewModel.Country))
                ModelState.AddModelError("Country", "Необходимо выбрать страну из предложенных");
            if (!ModelState.IsValid) return View("Add");

            var footballer = new Footballer()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Gender = viewModel.Gender,
                Birthday = viewModel.Birthday,
                TeamName = viewModel.TeamName,
                Country = viewModel.Country
            };
            await dbContext.Footballers.AddAsync(footballer);
            await dbContext.SaveChangesAsync();

            return Redirect("/");
            
        }

        [HttpGet]  
        public async Task<IActionResult> List()
        {
            var footballers = await dbContext.Footballers.ToListAsync();
            return View(footballers);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var footballer = await dbContext.Footballers.FindAsync(id);

            return View(footballer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Footballer viewModel)
        {
            var footballer = await dbContext.Footballers.FindAsync(viewModel.Id);
            if (footballer is not null)
            {
                footballer.FirstName = viewModel.FirstName;
                footballer.LastName = viewModel.LastName;
                footballer.Gender = viewModel.Gender;
                footballer.Birthday = viewModel.Birthday;
                footballer.TeamName = viewModel.TeamName;
                footballer.Country = viewModel.Country;
                
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Footballers");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Footballer viewModel)
        {
            var footballer = await dbContext.Footballers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            
            if (footballer is not null)
            {
                dbContext.Footballers.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Footballers");

        }
    }
}
