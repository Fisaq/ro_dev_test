using Microsoft.AspNetCore.Mvc;

namespace RO.DevTest.WebApi.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
