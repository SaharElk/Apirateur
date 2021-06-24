using Apirateur.Infrastructure.Session;
using Apirateur.Models.Forms.Contact;
using Client.Data;
using Client.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apirateur.Controllers
{
    
    public class ContactController : Controller
    {
        private readonly ISessionManager _sessionManager;
        private readonly IContactRepository _contactRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ContactController(ISessionManager sessionManager, IContactRepository contactRepository, ICategoryRepository categoryRepository)
        {
            _sessionManager = sessionManager;
            _contactRepository = contactRepository;
            _categoryRepository = categoryRepository;
        }



        // GET: ContactController
        public ActionResult Index()
        {

            //return View();
            return RedirectToAction("Index", "Home");
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            if (_sessionManager.User is null)
            {
                return RedirectToAction("Login", "Auth");
            }

            CreateContactForm form = new CreateContactForm() { Categories = GetCategories() };
            return View(form);
        }

        // POST: ContactController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CreateContactForm form)
        {
            if (!ModelState.IsValid)
            {
                form.Categories = GetCategories(form.CategoryId);
                return View(form);
            }

            Contact contact = new Contact(
                form.LastName,
                form.FirstName,
                form.Email,
                form.CategoryId, 
                _sessionManager.User.Id
            );

            _contactRepository.Insert(contact);

            return RedirectToAction("Index");

        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IList<SelectListItem> GetCategories(int? id = null)
        {
            IEnumerable<Category> categories = _categoryRepository.Get();
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem("Select a category", "0"));
            items.AddRange(categories.Select(c => new SelectListItem(c.Name, c.Id.ToString()) { Selected = (id.HasValue && c.Id == id.Value) }));
            return items;
        }
    }
}
