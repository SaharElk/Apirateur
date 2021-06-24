using Apirateur.Models.Forms.Auth;
using Client.Data;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Apirateur.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
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

            return RedirectToAction("Index");
        }

    }
}
