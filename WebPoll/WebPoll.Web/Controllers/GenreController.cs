using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPoll.Model.Models;
using WebPoll.Web.Services;
using AutoMapper;
using WebPoll.Web.DTO;
using System.Collections;

namespace WebPoll.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Genre")]
    public class GenreController : Controller
    {
        private GenreService _service;
        private IMapper _mapper;

        public GenreController(GenreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Genre
        [HttpGet]
        public ICollection<GenreResponse> Get()
        {
            return _mapper.Map<ICollection<Genre>, ICollection<GenreResponse>>(_service.GetAll());
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public GenreResponse Get(int id)
        {
            return _mapper.Map<Genre,GenreResponse>(_service.GetById(id));
        }
        
        // POST: api/Genre
        [HttpPost]
        public void Post([FromBody]GenreRequest genreRequest)
        {
            _service.Create( _mapper.Map<GenreRequest, Genre>(genreRequest) );
        }
        
        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]GenreRequest genreRequest)
        {
            _service.Update(_mapper.Map<GenreRequest, Genre>(genreRequest));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
