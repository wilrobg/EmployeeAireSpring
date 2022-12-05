using Microsoft.AspNetCore.Mvc;

namespace Employee.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
