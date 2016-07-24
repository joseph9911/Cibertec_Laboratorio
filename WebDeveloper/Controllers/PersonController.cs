using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Model;
using WebDeveloper.Repository;

namespace WebDeveloper.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        private PersonRepository _person = new PersonRepository();        
        public ActionResult Index()
        {
            return View(_person.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return View(person);
            _person.Add(person);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var person = _person.GetById(id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid) return View(person);
            _person.Update(person);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var person = _person.GetById(id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }

        [HttpPost]
        public ActionResult Delete(Person person)
        {            
            _person.Delete(person);
            return RedirectToAction("Index");
        }
    }
}