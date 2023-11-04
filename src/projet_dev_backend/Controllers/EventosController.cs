using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using projet_dev_backend.Models;

namespace projet_dev_backend.Controllers
{
    public class EventosController : Controller
    {
        private readonly AppDbContext _context;

        public IWebHostEnvironment hostEnvironment { get; }

        public EventosController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Evento.Include(e => e.Endereco_Vaga);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evento == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .Include(e => e.Endereco_Vaga)
                .FirstOrDefaultAsync(m => m.IdEvento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            ViewData["Endereco_VagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEvento,NomeEvento,Descricao,Local,Endereco,Data,Hora,GestorId,Endereco_VagaId,ImagemFileEventos")] Evento evento, MemoryStream memoryStream)
        {

            if (ModelState.IsValid)

            {
                //Salvando as imagens da vaga na parta wwwroot/ImagemVaga
                {
                    string wwwRootPath = hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(evento.ImagemFileEvento.FileName);
                    string extention = Path.GetExtension(evento.ImagemFileEvento.FileName);
                    evento.ImagemEvento = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    string path = Path.Combine(wwwRootPath + "/ImagemEventos/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await evento.ImagemFileEvento.CopyToAsync(fileStream);
                    }


                    _context.Add(evento);
                    await _context.SaveChangesAsync(); // Aguarde a operação de salvamento no banco de dados

                    return RedirectToAction(nameof(Index));
                }
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Endereco_VagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro", evento.Endereco_VagaId);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evento == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["Endereco_VagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro", evento.Endereco_VagaId);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEvento,NomeEvento,Descricao,Local,Endereco,Data,Hora,GestorId,Endereco_VagaId,Imagem")] Evento evento)
        {
            if (id != evento.IdEvento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.IdEvento))
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
            ViewData["Endereco_VagaId"] = new SelectList(_context.Endereco_Vagas, "Id", "Bairro", evento.Endereco_VagaId);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evento == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento
                .Include(e => e.Endereco_Vaga)
                .FirstOrDefaultAsync(m => m.IdEvento == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evento == null)
            {
                return Problem("Entity set 'AppDbContext.Evento'  is null.");
            }
            var evento = await _context.Evento.FindAsync(id);
            if (evento != null)
            {
                _context.Evento.Remove(evento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
          return _context.Evento.Any(e => e.IdEvento == id);
    
       }

        public async Task<IActionResult> GetImagem(int id)
        {
            var evento = await _context.Endereco_Vagas.FindAsync(id);

            if (evento != null && evento.Imagem != null)
            {
                return File(evento.Imagem, "image/jpeg"); // Substitua "image/jpeg" pelo tipo MIME apropriado
            }

            // Se a imagem não foi encontrada ou é nula, retorne uma imagem de espaço reservado ou outra resposta adequada.
            // Por exemplo, você pode retornar uma imagem padrão ou uma mensagem de erro.
            return File("~/path-to-placeholder-image.jpg", "image/jpeg"); // Substitua pelo caminho da imagem de espaço reservado
        }

    }

}
