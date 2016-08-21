using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Filters;
using WebDeveloper.Repository;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    [ExceptionControl]
    public class PersonBase1Controller<T> : Controller where T: class
    {
        protected IRepository<T> _repository;
        public PersonBase1Controller()
        {
            _repository = new BaseRepository<T>();
        }

    }
}