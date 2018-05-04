using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPoll.Services;
using WebPoll.Model.Models;

namespace WebPoll.Controllers
{
    public class ArtistController : Controller
    {
        private ArtistService _artistService;

        public ArtistController(ArtistService service)
        {
            _artistService = service;
        }

        public IActionResult Index()
        {
            var result = _artistService.GetAll();

            return View(result);
        }

        public IActionResult Details(int ID)
        {
            var result = _artistService.GetById(ID);

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Artist artist)
        {
            _artistService.Create(artist);

            return RedirectToAction("Index");
        }


        public RedirectToActionResult Delete(int ID)
        {
            _artistService.Delete(ID);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var result = _artistService.GetById(ID);

            return View(result);
        }

        [HttpPost]
        public RedirectToActionResult Edit(Artist artist)
        {
            _artistService.Update(artist);

            return RedirectToAction("Index");
        }

    }
}