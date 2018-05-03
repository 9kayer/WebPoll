using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPoll.Services;
using WebPoll.Models;
using AutoMapper;
using System.Collections;
using WebPoll.DTO;

namespace WebPoll.Controllers
{
    public class ArtistController : Controller
    {
        private Service<Artist> _artistService;
        private readonly IMapper _mapper;

        public ArtistController(Service<Artist> service, IMapper mapper)
        {
            _artistService = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _artistService.GetAll();

            return View(_mapper.Map<ICollection<Artist>, ICollection<ArtistDTO>>(result) );
        }

        public IActionResult Details(int ID)
        {
            var result = _artistService.GetById(ID);

            return View(_mapper.Map<Artist,ArtistDTO>(result));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(ArtistDTO artistDTO)
        {
            _artistService.Create( _mapper.Map<ArtistDTO, Artist>(artistDTO) );

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

            return View( _mapper.Map<Artist, ArtistDTO>(result) );
        }

        [HttpPost]
        public RedirectToActionResult Edit(ArtistDTO artistDTO)
        {
            _artistService.Update( _mapper.Map<ArtistDTO, Artist>(artistDTO) );

            return RedirectToAction("Index");
        }

    }
}