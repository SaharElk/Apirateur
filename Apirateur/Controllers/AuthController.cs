using Apirateur.Infrastructure.Session;
using Apirateur.Models.Forms.Auth;
using Client.Data;
using Client.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apirateur.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISessionManager _sessionManager;

        public AuthController(IAuthRepository authRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _sessionManager = sessionManager;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            User user = new User(form.LastName, form.FirstName, form.Email, form.Password);
            _authRepository.Register(user);

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            User user = _authRepository.Login(form.Email, form.Password);

            if (user is null)
            {
                ModelState.AddModelError("", "Email or password invalid");
                return View(form);
            }

            _sessionManager.User = new UserSession 
            { 
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            };

            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            _sessionManager.Clear();
            return RedirectToAction("Login");
        }

    }
}
