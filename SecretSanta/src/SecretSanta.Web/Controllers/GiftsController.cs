using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Web.Data;
using SecretSanta.Web.ViewModels;

namespace SecretSanta.Web.Controllers
{
    public class GiftsController : Controller
    {
        

        public IActionResult Index()
        {
            return View(MockData.Gifts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GiftViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Gifts.Add(viewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(MockData.Gifts[id]);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MockData.Gifts[viewModel.Id] = viewModel;
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MockData.Gifts.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}