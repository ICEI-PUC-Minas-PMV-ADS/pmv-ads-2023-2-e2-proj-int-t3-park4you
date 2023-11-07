using Microsoft.AspNetCore.Mvc;
using projet_dev_backend.Models;
using System.Diagnostics;
using System.Linq;

namespace projet_dev_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Consulta o banco de dados para obter as vagas disponíveis
            var vagasDisponiveis = _context.Endereco_Vagas.ToList();

            return View(vagasDisponiveis);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
