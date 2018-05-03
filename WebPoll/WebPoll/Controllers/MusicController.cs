using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPoll.Services;
using WebPoll.Model.Models;

namespace WebPoll.Controllers
{
    public class MusicController : Controller
    {
        private readonly Service<Music> _musicService;

        public MusicController(Service<Music> service)
        {
            _musicService = service;
        }

        public IActionResult Index()
        {
            var result = _musicService.GetAll();

            return View(result);
        }

        public IActionResult Details(int ID)
        {
            var result = _musicService.GetById(ID);

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Music music)
        {
            _musicService.Create(music);

            return RedirectToAction("Index");
        }


        public RedirectToActionResult Delete(int ID)
        {
            _musicService.Delete(ID);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var result = _musicService.GetById(ID);

            return View(result);
        }

        [HttpPost]
        public RedirectToActionResult Edit(Music music)
        {
            _musicService.Update(music);

            return RedirectToAction("Index");
        }

    }
}