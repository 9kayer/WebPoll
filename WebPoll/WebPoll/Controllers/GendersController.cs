using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPoll.Infra.DataBaseContext;
using WebPoll.Models;
using WebPoll.Services;
using AutoMapper;
using WebPoll.DTO;

namespace WebPoll.Controllers
{
    public class GenderController : Controller
    {
        private readonly Service<Gender> _genderService;
        private readonly IMapper _mapper;
        public GenderController(Service<Gender> genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _genderService.GetAll();

            return View( _mapper.Map<ICollection<Gender>, ICollection<GenderDTO>>(result) );
        }

        public IActionResult Details(int ID)
        {
            var result = _genderService.GetById(ID);

            return View( _mapper.Map<Gender,GenderDTO>(result) );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(GenderDTO genderDTO)
        {
            _genderService.Create( _mapper.Map<GenderDTO, Gender>(genderDTO) );

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

            return View( _mapper.Map<Gender, GenderDTO>(result) );
        }

        [HttpPost]
        public RedirectToActionResult Edit(GenderDTO genderDTO)
        {
            _genderService.Update( _mapper.Map<GenderDTO, Gender>(genderDTO) );
            return RedirectToAction("Index");
        }
    }
}
