using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    public class PhoneNumberTypeController : PersonBaseController<PhoneNumberType>
    {
        // GET: Personnel/PhoneNumberType
        public ActionResult Index()
        {
            return View();
        }
    }
}