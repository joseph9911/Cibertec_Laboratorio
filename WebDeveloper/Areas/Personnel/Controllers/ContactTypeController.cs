using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    public class ContactTypeController : PersonBaseController<ContactType>
    {
        // GET: Personnel/ContactType
        public ActionResult Index()
        {
            return View();
        }
    }
}