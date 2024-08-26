using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class GenresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
