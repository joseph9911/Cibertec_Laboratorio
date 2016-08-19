using System.Web.Mvc;
using WebDeveloper.Filters;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    [Authorize]
    [ExceptionControl]
    public class PersonBaseController : Controller
    {
    }
}