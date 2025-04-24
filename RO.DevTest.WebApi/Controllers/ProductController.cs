using Microsoft.AspNetCore.Mvc;

namespace RO.DevTest.WebApi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
