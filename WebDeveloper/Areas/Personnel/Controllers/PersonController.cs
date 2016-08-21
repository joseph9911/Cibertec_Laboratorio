using System;
using System.Web.Mvc;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    public class PersonController : PersonBaseController<Person>
    {      
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x=>x.ModifiedDate), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return View(person);
            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = new BusinessEntity
            {
                rowguid = person.rowguid,
                ModifiedDate = person.ModifiedDate
            };
            _repository.Add(person);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var person = _repository.GetById(x => x.BusinessEntityID == id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid) return View(person);
            _repository.Update(person);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var person = _repository.GetById(x=> x.BusinessEntityID==id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }

        [HttpPost]
        public ActionResult Delete(Person person)
        {
            person = _repository.GetById(x => x.BusinessEntityID == person.BusinessEntityID);
            _repository.Delete(person);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var person = _repository.GetById(x => x.BusinessEntityID == id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }
    }
}