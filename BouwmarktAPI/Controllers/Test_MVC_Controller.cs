using Microsoft.AspNetCore.Mvc;

namespace BouwmarktAPI.Controllers
{
    public class Test_MVC_Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
