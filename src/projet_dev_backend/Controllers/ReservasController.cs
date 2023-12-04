using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http; // Adicionado para IFormFile
using projet_dev_backend.Models;

namespace projet_dev_backend.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;

        public ReservasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reservas/Create
        public IActionResult Create(int? id)
        {
            if (id == null || _context.Endereco_Vagas == null)
            {
                return NotFound();
            }

            var vaga = _context.Endereco_Vagas
                .Include(v => v.Usuario)
                .FirstOrDefault(v => v.Id == id);

            if (vaga == null)
            {
                return NotFound();
            }

            var reserva = new Reserva
            {
                DataReserva = DateTime.Now,
                EnderecoVagaId = vaga.Id,
                UsuarioId = ObterUsuarioLogadoId(), // Adapte isso conforme necessário
                Valor = CalcularValorReserva(vaga), // Use sua lógica para calcular o valor da reserva
            };

            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataReserva,EnderecoVagaId,UsuarioId,Valor")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                // Adicione a lógica necessária para atualizar as vagas reservadas na classe Endereco_Vaga
                var vaga = await _context.Endereco_Vagas.FindAsync(reserva.EnderecoVagaId);
                if (vaga != null)
                {
                    vaga.VagasReservadas++;
                    _context.Entry(vaga).State = EntityState.Modified;
                }

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EnderecoVagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro", reserva.EnderecoVagaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", reserva.UsuarioId);
            return View(reserva);
        }

        private decimal CalcularValorReserva(Endereco_Vaga vaga)
        {
            // Adapte esta lógica conforme necessário para calcular o valor da reserva
            // Por exemplo, você pode usar informações da vaga (tamanho, localização, etc.) para calcular o valor
            return vaga.Valor; // Isso é apenas um exemplo, substitua pela lógica real
        }

        private int ObterUsuarioLogadoId()
        {
            // Adapte este método conforme necessário para obter o ID do usuário logado
            // Este é um exemplo simples, você pode usar o serviço de autenticação do ASP.NET Core para obter o ID do usuário
            return 1; // ID de exemplo, substitua pela lógica real
        }
    }
}