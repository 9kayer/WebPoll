using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebPoll.Model.Models;
using WebPoll.Services;

namespace WebPoll.Controllers
{
    public class GenreController : Controller
    {
        private readonly GenreService _genderService;
        public GenreController(GenreService genderService)
        {
            _genderService = genderService;
        }

        public IActionResult Index()
        {
            var result = _genderService.GetAll();

            return View(result);
        }

        public IActionResult Details(int ID)
        {
            var result = _genderService.GetById(ID);

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Genre gender)
        {
            _genderService.Create(gender);

            return RedirectToAction("Index");
        }


        public RedirectToActionResult Delete(int ID)
        {
            _genderService.Delete(ID);
      
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var result = _genderService.GetById(ID);

            return View(result);
        }

        [HttpPost]
        public RedirectToActionResult Edit(Genre gender)
        {
            _genderService.Update(gender);
            return RedirectToAction("Index");
        }
    }
}
