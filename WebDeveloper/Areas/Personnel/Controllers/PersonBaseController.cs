using System.Web.Mvc;
using WebDeveloper.Filters;
using WebDeveloper.Repository;

namespace WebDeveloper.Areas.Personnel.Controllers
{   
    [Authorize] 
    [ExceptionControl]
    [OutputCache(Duration =0)]
    public class PersonBaseController<T> : Controller where T: class 
    {
        protected IRepository<T>  _repository;

        //public PersonBaseController()
        //{
        //    _repository = new BaseRepository<T>();
        //}
        
            //PARA INYECCION DE DEPENDENCIAS
        public PersonBaseController(IRepository<T> repository)
        {
            _repository = repository;
        }
    }
}