using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet_dev_backend.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace projet_dev_backend.Controllers
{
    public class Endereco_VagaController : Controller
    {
        private readonly AppDbContext _context;

        public IWebHostEnvironment _hostEnvironment { get; }

        public Endereco_VagaController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Endereco_Vaga
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Endereco_Vagas.Include(e => e.Usuario)
                                                      .Include(e => e.Evento);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Endereco_Vaga/Details/5
        [AllowAnonymous] // Qualquer usuario pode acessar essa ação,independente se estiver logado ou não.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Endereco_Vagas == null)
            {
                return NotFound();
            }

            var endereco_Vaga = await _context.Endereco_Vagas
                .Include(e => e.Usuario)
                .Include(e => e.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco_Vaga == null)
            {
                return NotFound();
            }

            return View(endereco_Vaga);
        }

        // GET: Criando e Salvando a Vaga
        [Authorize] // Somente usuários autenticados podem acessar essa ação
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF");
            ViewData["IdEvento"] = new SelectList(_context.Evento, "IdEvento", "NomeEvento");
            return View();
        }

        // POST: Endereco_Vaga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Data,QuantVagas,Valor,Tipo,UsuarioId,IdEvento,ImagemFile")] Endereco_Vaga endereco_Vaga)
        {

            if (ModelState.IsValid)

            //Salvando as imagens da vaga na parta wwwroot/ImagemVaga
            {
                if (endereco_Vaga.ImagemFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(endereco_Vaga.ImagemFile.FileName);
                    string extention = Path.GetExtension(endereco_Vaga.ImagemFile.FileName);
                    endereco_Vaga.ImagemNome = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    string path = Path.Combine(wwwRootPath + "/ImagemVaga/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await endereco_Vaga.ImagemFile.CopyToAsync(fileStream);
                    }
                }

                _context.Add(endereco_Vaga);
                await _context.SaveChangesAsync(); // Aguarde a operação de salvamento no banco de dados

                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", endereco_Vaga.UsuarioId);
            ViewData["IdEvento"] = new SelectList(_context.Evento, "IdEvento", "NomeEvento", endereco_Vaga.IdEvento);
            return View(endereco_Vaga);
        }



        // Configurações do EDITAR do Endereco_Vaga

        // GET: Endereco_Vaga/Edit/5
        [Authorize] // Somente usuários autenticados podem acessar essa ação
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Endereco_Vagas == null)
            {
                return NotFound();
            }

            var endereco_Vaga = await _context.Endereco_Vagas.FindAsync(id);
            if (endereco_Vaga == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", endereco_Vaga.UsuarioId);
            ViewData["IdEvento"] = new SelectList(_context.Evento, "IdEvento", "NomeEvento", endereco_Vaga.IdEvento);
            return View(endereco_Vaga);
        }

        // POST: Endereco_Vaga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Data,QuantVagas,Valor,Tipo,UsuarioId,IdEvento,ImagemFile")] Endereco_Vaga endereco_Vaga)
        {
            if (id != endereco_Vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingVaga = await _context.Endereco_Vagas.FindAsync(endereco_Vaga.Id);

                    if (existingVaga != null)
                    {
                        // Exclua a imagem anterior do sistema de arquivos
                        if (!string.IsNullOrEmpty(existingVaga.ImagemNome))
                        {
                            string oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, "ImagemVaga", existingVaga.ImagemNome);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        if (endereco_Vaga.ImagemFile != null)
                        {
                            string wwwRootPath = _hostEnvironment.WebRootPath;
                            string fileName = Path.GetFileNameWithoutExtension(endereco_Vaga.ImagemFile.FileName);
                            string extention = Path.GetExtension(endereco_Vaga.ImagemFile.FileName);
                            endereco_Vaga.ImagemNome = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                            string path = Path.Combine(wwwRootPath + "/ImagemVaga/", fileName);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await endereco_Vaga.ImagemFile.CopyToAsync(fileStream);
                            }


                            _context.Add(endereco_Vaga);
                            await _context.SaveChangesAsync(); // Aguarde a operação de salvamento no banco de dados

                        }

                        // Atualize os outros campos da vaga
                        _context.Entry(existingVaga).CurrentValues.SetValues(endereco_Vaga);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Endereco_VagaExists(endereco_Vaga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", endereco_Vaga.UsuarioId);
            ViewData["IdEvento"] = new SelectList(_context.Evento, "IdEvento", "NomeEvento", endereco_Vaga.IdEvento);
            return View(endereco_Vaga);
        }


        // GET: Endereco_Vaga/Delete/5
        [Authorize] // Somente usuários autenticados podem acessar essa ação
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Endereco_Vagas == null)
            {
                return NotFound();
            }

            var endereco_Vaga = await _context.Endereco_Vagas
                .Include(e => e.Usuario)
                .Include(e => e.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco_Vaga == null)
            {
                return NotFound();
            }

            return View(endereco_Vaga);
        }

        // POST: Endereco_Vaga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Endereco_Vagas == null)
            {
                return Problem("Entity set 'AppDbContext.Endereco_Vagas' is null.");
            }

            var endereco_Vaga = await _context.Endereco_Vagas.FindAsync(id);

            if (endereco_Vaga != null)
            {
                // Deletando a imagem associada à vaga do wwwRoot/ImagemVaga
                if (!string.IsNullOrEmpty(endereco_Vaga.ImagemNome))
                {
                    string imagemPath = Path.Combine(_hostEnvironment.WebRootPath, "ImagemVaga", endereco_Vaga.ImagemNome);
                    if (System.IO.File.Exists(imagemPath))
                    {
                        System.IO.File.Delete(imagemPath);
                    }
                }

                // Exclua a vaga do banco de dados
                _context.Endereco_Vagas.Remove(endereco_Vaga);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool Endereco_VagaExists(int id)
        {
            return _context.Endereco_Vagas.Any(e => e.Id == id);
        }

        // Ação para lidar com a pesquisa
        [HttpGet]
        public async Task<IActionResult> Pesquisar(string searchTerm, DateTime? checkIn, int? quantity)
        {
            var query = _context.Endereco_Vagas
                .Include(e => e.Usuario)
                .Include(e => e.Evento)
                .AsQueryable();

            // Adicione condições à consulta conforme necessário
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower(); // Garante que o termo de pesquisa esteja em minúsculas
                query = query.Where(v => v.Cidade.ToLower().Contains(searchTerm) || v.Evento.NomeEvento.ToLower().Contains(searchTerm));
            }

            if (checkIn.HasValue)
            {
                query = query.Where(v => v.Data.Date == checkIn.Value.Date);
            }

            if (quantity.HasValue)
            {
                query = query.Where(v => v.QuantVagas >= quantity.Value);
            }

            var resultados = await query.ToListAsync();

            // Retorne os resultados para a view
            return View("Index", resultados);
        }
        // Acao para lidar com a reserva
        [Authorize]
        public async Task<IActionResult> Reservar(int id)
        {
            var vaga = await _context.Endereco_Vagas.FindAsync(id);

            if (vaga == null)
            {
                return NotFound();
            }

            if (vaga.VagasDisponiveis > 0)
            {
                var reserva = new Reserva
                {
                    EnderecoVagaId = vaga.Id,
                    UsuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    DataReserva = DateTime.Now
                };

                _context.Reservas.Add(reserva);
                vaga.VagasReservadas++;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Desculpe, não há vagas disponíveis para reserva.");
            return View("Index", await _context.Endereco_Vagas.Include(e => e.Usuario).Include(e => e.Evento).ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> ReservasVaga(int id)
        {
            var vaga = await _context.Endereco_Vagas.FindAsync(id);

            if (vaga == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reservas
                .Where(r => r.EnderecoVagaId == vaga.Id)
                .Include(r => r.Usuario)
                .ToListAsync();

            return View(reservas);
        }
    }
}
