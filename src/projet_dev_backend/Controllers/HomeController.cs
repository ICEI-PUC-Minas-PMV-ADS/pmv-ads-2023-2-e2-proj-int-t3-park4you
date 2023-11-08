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

        public IActionResult Index(string searchTerm)
        {
            // Consulta o banco de dados para obter as vagas disponíveis
            var vagasDisponiveis = _context.Endereco_Vagas.ToList();

            // Se houver um termo de pesquisa, filtre as vagas com base nele
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower(); // Converter o termo de pesquisa para minúsculas
                vagasDisponiveis = vagasDisponiveis.Where(v => v.Cidade.ToLower().Contains(searchTerm) || v.UF.ToLower().Contains(searchTerm)).ToList();
            }

            if (vagasDisponiveis.Count == 0)
            {
                // Nenhuma vaga foi encontrada para o termo de pesquisa
                TempData["SearchMessage"] = "Nenhuma vaga encontrada para o termo de pesquisa.";
            }

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
