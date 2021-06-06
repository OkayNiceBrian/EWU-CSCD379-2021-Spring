using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        /*public IActionResult Gifts(int userId)
        {
            var gifts = MockData.Gifts.OrderBy(g => g.Priority).ToList();
            return View(gifts);
        }*/
    }
}
