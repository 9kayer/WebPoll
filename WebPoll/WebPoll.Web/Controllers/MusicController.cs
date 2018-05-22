using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPoll.Web.DTO;
using WebPoll.Web.Services;
using AutoMapper;
using WebPoll.Model.Models;

namespace WebPoll.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Musics")]
    public class MusicController : Controller
    {
        private MusicService _service;
        private IMapper _mapper;

        public MusicController(MusicService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Music
        [HttpGet]
        public ICollection<MusicResponse> Get()
        {
            return _mapper.Map<ICollection<Music>, ICollection<MusicResponse>>(_service.GetAll());
        }

        // GET: api/Music/{id}
        [HttpGet("{id}")]
        public MusicResponse Get(int id)
        {
            return _mapper.Map<Music, MusicResponse>(_service.GetById(id));
        }
        
        // POST: api/Music
        [HttpPost]
        public void Post([FromBody]MusicRequest musicRequest)
        {
            _service.Create(_mapper.Map<MusicRequest, Music>(musicRequest));
        }

        // PUT: api/Music/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]MusicRequest musicRequest)
        {
            _service.Update(_mapper.Map<MusicRequest, Music>(musicRequest));
        }

        // DELETE: api/Music/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
