using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet_dev_backend.Models;

namespace projet_dev_backend.Controllers
{
    public class ReservaController : Controller
    {
        private readonly AppDbContext _context;

        public ReservaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reserva
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Reservas.Include(r => r.EnderecoVaga).Include(r => r.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.EnderecoVaga)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            ViewData["EnderecoVagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF");
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataReserva,EnderecoVagaId,UsuarioId,Valor,DataCancelamento")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoVagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro", reserva.EnderecoVagaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", reserva.UsuarioId);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["EnderecoVagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro", reserva.EnderecoVagaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", reserva.UsuarioId);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataReserva,EnderecoVagaId,UsuarioId,Valor,DataCancelamento")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoVagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro", reserva.EnderecoVagaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", reserva.UsuarioId);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.EnderecoVaga)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'AppDbContext.Reservas'  is null.");
            }
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
          return _context.Reservas.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Reservar(int? id)
        {
            if (id == null || _context.Endereco_Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.Endereco_Vagas
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vaga == null)
            {
                return NotFound();
            }

            // Passe os dados necessários para a página de reserva (por exemplo, informações da vaga)
            ViewData["VagaId"] = vaga.Id;
            ViewData["VagaDescricao"] = $"{vaga.Logradouro}, {vaga.Bairro}, {vaga.Cidade}, {vaga.UF}";
            
                var reservaModel = new Reserva
                 {
                EnderecoVagaId = vaga.Id,
                // Outros campos da reserva
                  };
            return View("Reservar"); // Corrigido aqui
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarReserva([Bind("EnderecoVagaId, NomeCliente, OutrosCampos")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                // Adicione lógica para confirmar a reserva, por exemplo, salvar no banco de dados
                _context.Add(reserva);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Se houver erros de validação, redirecione de volta para a página de reserva
            return View("Reservar", reserva);
        }


    }

}
