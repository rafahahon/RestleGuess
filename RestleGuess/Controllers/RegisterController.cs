using Microsoft.AspNetCore.Mvc;
using RestleGuess.Data;
using RestleGuess.Models;
using RestleGuess.Services;

namespace RestleGuess.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _context;

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string user, string email, string senha, string cSenha)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(cSenha))
            {
                ViewBag.Error = "Fill all the boxes.";
                return View("Index");
            }

            if(senha != cSenha)
            {
                ViewBag.Error = "Passwords do not match.";
            }

            if(_context.Usuarios.Any(usuario => usuario.Email == email))
            {
                ViewBag.Error = "Email already registered.";
            }

            byte[] hash = HashService.GerarHashBytes(senha);

            Usuario usuario = new Usuario
            {
                Nome = user,
                Email = email,
                SenhaHash = hash
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}