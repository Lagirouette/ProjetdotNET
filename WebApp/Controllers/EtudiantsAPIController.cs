using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EtudiantsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtudiantsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EtudiantsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiant>>> GetListEtudiants()
        {
            return await _context.Etudiants.ToListAsync();
        }

        // GET: api/EtudiantsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> GetSingleEtudiant(Guid id)
        {
            var etudiant = await _context.Etudiants.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return etudiant;
        }

        // PUT: api/EtudiantsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeEtudiant(Guid id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EtudiantsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etudiant>> NewEtudiant(Etudiant etudiant)
        {
            _context.Etudiants.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.Id }, etudiant);
        }

        // DELETE: api/EtudiantsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(Guid id)
        {
            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtudiantExists(Guid id)
        {
            return _context.Etudiants.Any(e => e.Id == id);
        }
    }
}
