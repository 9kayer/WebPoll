using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPoll.Services;
using WebPoll.Models;
using AutoMapper;
using WebPoll.DTO;

namespace WebPoll.Controllers
{
    public class MusicController : Controller
    {
        private readonly Service<Music> _musicService;
        private readonly IMapper _mapper;

        public MusicController(Service<Music> service, IMapper mapper)
        {
            _musicService = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _musicService.GetAll();

            return View(_mapper.Map<ICollection<Music>, ICollection<MusicDTO>>(result));
        }

        public IActionResult Details(int ID)
        {
            var result = _musicService.GetById(ID);

            return View(_mapper.Map<Music, MusicDTO>(result));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(MusicDTO musicDTO)
        {
            _musicService.Create(_mapper.Map<MusicDTO, Music>(musicDTO));

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

            return View(_mapper.Map<Music, MusicDTO>(result));
        }

        [HttpPost]
        public RedirectToActionResult Edit(MusicDTO musicDTO)
        {
            _musicService.Update(_mapper.Map<MusicDTO, Music>(musicDTO));

            return RedirectToAction("Index");
        }

    }
}