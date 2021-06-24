using Client.Forms.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apirateur.Controllers
{
    public class AuthController : Controller
    {
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

            return RedirectToAction("Index");
        }


    }
}
