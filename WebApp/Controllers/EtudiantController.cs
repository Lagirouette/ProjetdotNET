using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    public class EtudiantController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EtudiantController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EtudiantController()
        {
        }

        public IActionResult Index()
        {
            return View();
        } 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEtudiantViewModel viewModel)
        {
            var etudiant = new Etudiant
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Adresse = viewModel.Adresse,
                Phone = viewModel.Phone,
            };

            await dbContext.Etudiants.AddAsync(etudiant);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Etudiant");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var etudiants = await dbContext.Etudiants.ToListAsync();

            return View(etudiants);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var etudiant = await dbContext.Etudiants.FindAsync(id);

            return View(etudiant);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Etudiant model)
        {
            var etudiant = await dbContext.Etudiants.FindAsync(model.Id);

            if(etudiant is not null)
            {
                etudiant.Name = model.Name;
                etudiant.Email = model.Email;
                etudiant.Adresse = model.Adresse;
                etudiant.Phone = model.Phone;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Etudiant");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var etudiant = await dbContext.Etudiants.FindAsync(id);

            return View(etudiant);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Etudiant model)
        {
            var etudiant = await dbContext.Etudiants.FindAsync(model.Id);

            if (etudiant is not null)
            {
                dbContext.Etudiants.Remove(etudiant);
                await dbContext.SaveChangesAsync();
            }


            return RedirectToAction("List", "Etudiant");
        }
    }
}
