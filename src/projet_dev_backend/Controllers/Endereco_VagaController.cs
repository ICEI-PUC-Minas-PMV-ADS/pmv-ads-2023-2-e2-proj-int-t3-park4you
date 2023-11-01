﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet_dev_backend.Models;


namespace projet_dev_backend.Controllers
{
    public class Endereco_VagaController : Controller
    {
        private readonly AppDbContext _context;

        public Endereco_VagaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Endereco_Vaga
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Endereco_Vagas.Include(e => e.usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Endereco_Vaga/Details/5
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
            if (endereco_Vaga.ImagemFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await endereco_Vaga.ImagemFile.CopyToAsync(memoryStream);
                    endereco_Vaga.Imagem = memoryStream.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(endereco_Vaga);
                await _context.SaveChangesAsync(); // Aguarde a operação de salvamento no banco de dados

                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "CPF", endereco_Vaga.UsuarioId);
            return View(endereco_Vaga);
        }



        // GET: Endereco_Vaga/Edit/5
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
                if (endereco_Vaga.ImagemFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await endereco_Vaga.ImagemFile.CopyToAsync(memoryStream);
                        endereco_Vaga.Imagem = memoryStream.ToArray();
                    }
                }

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

                if (enderecoVaga != null && enderecoVaga.Imagem != null)
                {
                    return File(enderecoVaga.Imagem, "image/jpeg"); // Substitua "image/jpeg" pelo tipo MIME apropriado
                }

                // Se a imagem não foi encontrada ou é nula, retorne uma imagem de espaço reservado ou outra resposta adequada.
                // Por exemplo, você pode retornar uma imagem padrão ou uma mensagem de erro.
                return File("~/path-to-placeholder-image.jpg", "image/jpeg"); // Substitua pelo caminho da imagem de espaço reservado
            }

            // ...
        

    }
}
