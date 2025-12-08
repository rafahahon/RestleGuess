using Microsoft.AspNetCore.Mvc;
using RestleGuess.Data;
using RestleGuess.Services;

namespace RestleGuess.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Error = "Fill all fields.";
                return View("Index");
            }

            byte[] senhaDigitadaHash = HashService.GerarHashBytes(senha);

            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Email == email);

            if(usuario == null)
            {
                ViewBag.Error = "E-mail or password incorrect.";
                return View("Index");
            }

            if(!usuario.SenhaHash.SequenceEqual(senhaDigitadaHash))
            {
                ViewBag.Error = "E-mail or password incorrect.";
                return View("Index");
            }

            HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
            HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}