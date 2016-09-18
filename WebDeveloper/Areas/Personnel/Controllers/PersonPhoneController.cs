using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Model;
using WebDeveloper.Repository;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    public class PersonPhoneController : PersonBaseController<PersonPhone>
    {

        public PersonPhoneController(IRepository<PersonPhone> repository) : base(repository)
        {

        }

        // GET: Personnel/PersonPhone
        public ActionResult Index()
        {
            return View();
        }
    }
}