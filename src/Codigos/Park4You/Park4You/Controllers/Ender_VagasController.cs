using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Park4You.Models;

namespace Park4You.Controllers
{
    [Authorize]
    public class Ender_VagasController : Controller
    {
        private readonly AppDbContext _context;
        public Ender_VagasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.endereco_Vaga.ToListAsync();

            return View(dados);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Endereco_Vaga endereco_Vaga)
        {
            if (ModelState.IsValid)
            {
                _context.endereco_Vaga.Add(endereco_Vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(endereco_Vaga);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.endereco_Vaga.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Endereco_Vaga endereco_Vaga)
        {
            if (id != endereco_Vaga.Id)
                return NotFound();


            if (ModelState.IsValid)
            {

                _context.endereco_Vaga.Update(endereco_Vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)

        {

            if (id == null)
                return NotFound();


            var dados = await _context.endereco_Vaga.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)

        {

            if (id == null)
                return NotFound();


            var dados = await _context.endereco_Vaga.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)

        {

            if (id == null)
                return NotFound();


            var dados = await _context.endereco_Vaga.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.endereco_Vaga.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

