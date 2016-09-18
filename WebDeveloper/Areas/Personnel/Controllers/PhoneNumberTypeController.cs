using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Model;
using WebDeveloper.Repository;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    public class PhoneNumberTypeController : PersonBaseController<PhoneNumberType>
    {

        public PhoneNumberTypeController(IRepository<PhoneNumberType> repository) : base(repository)
        {

        }

        // GET: Personnel/PhoneNumberType
        public ActionResult Index()
        {
            return View();
        }
    }
}