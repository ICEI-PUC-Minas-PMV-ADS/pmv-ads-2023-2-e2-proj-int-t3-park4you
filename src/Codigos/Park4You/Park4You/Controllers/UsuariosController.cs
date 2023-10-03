using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Park4You.Models;

namespace Park4You.Controllers

/// Criar Usuário
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dados = await _context.cadast_Usuario.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(cadast_Usuario cadast_Usuario)
        {
            if (ModelState.IsValid)
            {
                _context.cadast_Usuario.Add(cadast_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cadast_Usuario);
        }
        // Editar
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.cadast_Usuario.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, cadast_Usuario cadast_Usuario)
        {
            if (id != cadast_Usuario.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.cadast_Usuario.Update(cadast_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();

        }
        // Visualizar
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.cadast_Usuario.FindAsync(id);

            if (dados == null)

                return NotFound();

            return View(dados);
        }
        // Apagar 

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.cadast_Usuario.FindAsync(id);

            if (dados == null)

                return NotFound();

            return View(dados);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.cadast_Usuario.FindAsync(id);

            if (dados == null)

                return NotFound();

            _context.cadast_Usuario.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}