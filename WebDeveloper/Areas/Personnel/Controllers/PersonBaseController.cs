using System.Web.Mvc;
using WebDeveloper.Filters;
using WebDeveloper.Repository;

namespace WebDeveloper.Areas.Personnel.Controllers
{   
    [Authorize] 
    [ExceptionControl]
    public class PersonBaseController<T> : Controller where T: class 
    {
        protected IRepository<T>  _repository;
        public PersonBaseController()
        {
            _repository = new BaseRepository<T>();
        }
    }
}