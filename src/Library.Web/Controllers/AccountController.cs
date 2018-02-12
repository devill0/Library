using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}