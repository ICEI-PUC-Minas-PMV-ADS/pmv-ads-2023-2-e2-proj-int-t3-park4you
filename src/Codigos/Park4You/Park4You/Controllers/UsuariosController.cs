using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Park4You.Models;

namespace Park4You.Controllers
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
    }
}
