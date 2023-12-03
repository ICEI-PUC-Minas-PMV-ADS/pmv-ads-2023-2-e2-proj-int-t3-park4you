using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Park4You.Models;
using projet_dev_backend.Models;

namespace projet_dev_backend.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }
        private bool CPFJaCadastrado(string cpf)
        {
            return _context.Usuarios.Any(u => u.CPF == cpf);
        }
       
        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return View(await _context.Usuarios.ToListAsync());
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuarios Usuarios)
        {
            var dados = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == Usuarios.Email);

            if (dados == null)
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();
            }

            bool senhaOK = BCrypt.Net.BCrypt.Verify(Usuarios.Senha, dados.Senha);

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

            return RedirectToAction("Login", "usuario");
        }


        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuario/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CPF,Nome,Email,Senha,Telefone,Perfil")] Usuarios usuario)
        {
            if (!ValidarCPF(usuario.CPF))
            {
                ModelState.AddModelError("CPF", "CPF inválido. Deve conter apenas números.");
            }

            if (!ValidarEmail(usuario.Email))
            {
                ModelState.AddModelError("Email", "E-mail inválido.");
            }

            if (!ValidarSenha(usuario.Senha))
            {
                ModelState.AddModelError("Senha", "A senha deve ter no mín. 8 caracteres, com uma letra maiúscula e uma minúscula.");
            }

            if (CPFJaCadastrado(usuario.CPF))
            {
                ModelState.AddModelError("CPF", "CPF já cadastrado.");
            }

            if (!ValidarTelefone(usuario.Telefone))
            {
                ModelState.AddModelError("Telefone", "Telefone inválido. Deverá inserir o DDD antes do número.");
            }
            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CPF,Nome,Email,Senha,Telefone, Perfil")] Usuarios Usuarios)
        {
            if (id != Usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(Usuarios.Senha);
                    _context.Update(Usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(Usuarios.Id))
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
            return View(Usuarios);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.Usuarios'  is null.");
            }
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios != null)
            {
                _context.Usuarios.Remove(usuarios);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }
        private bool ValidarCPF(string cpf)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cpf, @"^\d{11}$");
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarSenha(string senha)
        {
            return senha.Length >= 6 && senha.Any(char.IsUpper) && senha.Any(char.IsLower);
        }

        private bool ValidarTelefone(string telefone)
        {
            string numeros = new string(telefone.Where(char.IsDigit).ToArray());
            return numeros.Length >= 10;
        }

    }
}
