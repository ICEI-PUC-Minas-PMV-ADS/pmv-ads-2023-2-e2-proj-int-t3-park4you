using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.cadast_Usuario.ToListAsync());
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(cadast_Usuario cadast_Usuario)
        {
            var dados = await _context.cadast_Usuario
                .FirstOrDefaultAsync(u => u.Email == cadast_Usuario.Email);

            if (dados == null)
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();
            }

            bool senhaOK = BCrypt.Net.BCrypt.Verify(cadast_Usuario.Senha, dados.Senha);

            if (senhaOK)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.NameIdentifier, dados.CPF.ToString()),
                    new Claim(ClaimTypes.Role, dados.Email.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Usuarios");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cadast_Usuario == null)
            {
                return NotFound();
            }

            var cadast_Usuario = await _context.cadast_Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadast_Usuario == null)
            {
                return NotFound();
            }

            return View(cadast_Usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CPF,Nome,Email,Senha,Endereco,Telefone")] cadast_Usuario cadast_Usuario)
        {
            if (ModelState.IsValid)
            {
                cadast_Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(cadast_Usuario.Senha);
                _context.Add(cadast_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadast_Usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cadast_Usuario == null)
            {
                return NotFound();
            }

            var cadast_Usuario = await _context.cadast_Usuario.FindAsync(id);
            if (cadast_Usuario == null)
            {
                return NotFound();
            }
            return View(cadast_Usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CPF,Nome,Email,Senha,Endereco,Telefone")] cadast_Usuario cadast_Usuario)
        {
            if (id != cadast_Usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cadast_Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(cadast_Usuario.Senha);
                    _context.Update(cadast_Usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadast_UsuarioExists(cadast_Usuario.Id))
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
            return View(cadast_Usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cadast_Usuario == null)
            {
                return NotFound();
            }

            var cadast_Usuario = await _context.cadast_Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadast_Usuario == null)
            {
                return NotFound();
            }

            return View(cadast_Usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cadast_Usuario == null)
            {
                return Problem("Entity set 'AppDbContext.cadast_Usuario'  is null.");
            }
            var cadast_Usuario = await _context.cadast_Usuario.FindAsync(id);
            if (cadast_Usuario != null)
            {
                _context.cadast_Usuario.Remove(cadast_Usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cadast_UsuarioExists(int id)
        {
          return _context.cadast_Usuario.Any(e => e.Id == id);
        }
    }
}
