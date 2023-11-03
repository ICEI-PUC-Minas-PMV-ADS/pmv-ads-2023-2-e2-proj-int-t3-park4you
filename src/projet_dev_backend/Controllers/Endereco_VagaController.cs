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

namespace projet_dev_backend.Controllers
{
    public class Endereco_VagaController : Controller
    {
        private readonly AppDbContext _context;

        public IWebHostEnvironment _hostEnvironment { get; }

        public Endereco_VagaController(AppDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Endereco_Vaga
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Endereco_Vagas.Include(e => e.usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Endereco_Vaga/Details/5
        [Authorize] // Somente usuários autenticados podem acessar essa ação
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Endereco_Vagas == null)
            {
                return NotFound();
            }

            var endereco_Vaga = await _context.Endereco_Vagas
                .Include(e => e.usuario)
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
            return View();
        }

        // POST: Endereco_Vaga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Data,QuantVagas,Valor,Tipo,UsuarioId,ImagemFile")] Endereco_Vaga endereco_Vaga)
        {
          
            if (ModelState.IsValid)

                //Salvando as imagens da vaga na parta wwwroot/ImagemVaga
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(endereco_Vaga.ImagemFile.FileName);
                string extention = Path.GetExtension(endereco_Vaga.ImagemFile.FileName);
                endereco_Vaga.ImagemNome = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwwRootPath + "/imagem/", fileName); 
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await endereco_Vaga.ImagemFile.CopyToAsync(fileStream);
                }


                _context.Add(endereco_Vaga);
                await _context.SaveChangesAsync(); // Aguarde a operação de salvamento no banco de dados

                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", endereco_Vaga.UsuarioId);
            return View(endereco_Vaga);
        }



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
            return View(endereco_Vaga);
        }

        // POST: Endereco_Vaga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Data,QuantVagas,Valor,Tipo,UsuarioId,ImagemFile")] Endereco_Vaga endereco_Vaga)
        {
            if (id != endereco_Vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Verifique se um novo arquivo de imagem foi fornecido
                

                try
                {
                    _context.Update(endereco_Vaga);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
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
                .Include(e => e.usuario)
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
                return Problem("Entity set 'AppDbContext.Endereco_Vagas'  is null.");
            }
            var endereco_Vaga = await _context.Endereco_Vagas.FindAsync(id);
            if (endereco_Vaga != null)
            {
                _context.Endereco_Vagas.Remove(endereco_Vaga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Endereco_VagaExists(int id)
        {
          return _context.Endereco_Vagas.Any(e => e.Id == id);
        }

            // ...

            public async Task<IActionResult> GetImagem(int id)
            {
                var enderecoVaga = await _context.Endereco_Vagas.FindAsync(id);

               

                // Se a imagem não foi encontrada ou é nula, retorne uma imagem de espaço reservado ou outra resposta adequada.
                // Por exemplo, você pode retornar uma imagem padrão ou uma mensagem de erro.
                return File("~/path-to-placeholder-image.jpg", "image/jpeg"); // Substitua pelo caminho da imagem de espaço reservado
            }

            // ...
        

    }
}
