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

        public IActionResult Gifts()
        {
            var gifts = MockData.Gifts.OrderBy(g => g.Priority).ToList();
            return View(gifts);
        }

        [HttpPost]
        public IActionResult GiftsDelete(int id)
        {
            MockData.Gifts.Remove(MockData.Gifts.Single(g => g.Id == id));
            return RedirectToAction(nameof(Gifts));
        }

        public IActionResult CreateGift()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGift(GiftViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Id = MockData.Gifts.Max(g => g.Id) + 1;
                MockData.Gifts.Add(viewModel);
                return RedirectToAction(nameof(Gifts));
            }

            return View(viewModel);
        }

        public IActionResult EditGift(int id)
        {
            return View(MockData.Gifts.Single(g => g.Id == id));
        }

        [HttpPost]
        public IActionResult EditGift(GiftViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Gifts[MockData.Gifts.FindIndex(g => g.Id == viewModel.Id)] = viewModel;
                return RedirectToAction(nameof(Gifts));
            }

            return View(viewModel);
        }
    }
}
