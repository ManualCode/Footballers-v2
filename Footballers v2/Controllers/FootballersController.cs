using Footballers_v2.Data;
using Footballers_v2.Enums;
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
        public async Task<IActionResult> Add()
        {
            ViewData["ListTeamNames"] = await dbContext.Footballers
                .Select(x => x.TeamName).Distinct().ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Footballer viewModel)
        {
            if (!ModelState.IsValid) 
            {
                ViewData["ListTeamNames"] = await dbContext.Footballers
                .Select(x => x.TeamName).Distinct().ToListAsync();
                return View("Add");
            }

            await dbContext.Footballers.AddAsync(new Footballer()
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Gender = viewModel.Gender,
                Birthday = viewModel.Birthday,
                TeamName = viewModel.TeamName,
                Country = ((Country)int.Parse(viewModel.Country)).ToString()
            });
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
            ViewData["ListTeamNames"] = await dbContext.Footballers
                .Select(x => x.TeamName).Distinct().ToListAsync();
            return View(footballer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Footballer viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ListTeamNames"] = await dbContext.Footballers
                .Select(x => x.TeamName).Distinct().ToListAsync();
                return View(viewModel);
            }

            var footballer = await dbContext.Footballers.FindAsync(viewModel.Id);
            
            if (footballer is not null)
            {
                footballer.FirstName = viewModel.FirstName;
                footballer.LastName = viewModel.LastName;
                footballer.Gender = viewModel.Gender;
                footballer.Birthday = viewModel.Birthday;
                footballer.TeamName = viewModel.TeamName;
                footballer.Country = ((Country)int.Parse(viewModel.Country)).ToString();

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Footballers");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Footballer viewModel)
        {
            var footballer = await dbContext.Footballers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            
            if (footballer is not null)
            {
                dbContext.Footballers.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Footballers");

        }
    }
}
