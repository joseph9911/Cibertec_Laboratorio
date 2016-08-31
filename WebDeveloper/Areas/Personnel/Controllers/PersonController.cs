using System;
using System.Net;
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

        public ActionResult List(int? page, int? size)
        {
            if (!page.HasValue || !size.HasValue)
            {
                page = 1;
                size = 10;
            }
            return PartialView("_List", _repository.PaginatedList((x=> x.ModifiedDate),page.Value, size.Value));
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Create",person);
            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = new BusinessEntity
            {
                rowguid = person.rowguid,
                ModifiedDate = person.ModifiedDate
            };
            _repository.Add(person);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Edit(int id)
        {
            var person = _repository.GetById(x => x.BusinessEntityID == id);
            if (person == null) return RedirectToAction("Index");
            return PartialView("_Edit",person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", person);
            //person.ModifiedDate = DateTime.Now;
            _repository.Update(person);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Delete(int id)
        {
            var person = _repository.GetById(x=> x.BusinessEntityID==id);
            if (person == null) return RedirectToAction("Index");
            return PartialView("_Delete", person);
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
            return PartialView("_Details", person);
        }

        public int PageSize(int pageSize)
        {
            var totalRecords=_repository.GetList().Count;          
            return totalRecords % pageSize > 0 ? (totalRecords / pageSize) + 1 : totalRecords / pageSize;
        }
    }
}