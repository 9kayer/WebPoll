using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebPoll.Web.Services;
using WebPoll.Web.DTO;
using AutoMapper;
using WebPoll.Model.Models;

namespace WebPoll.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Artist")]
    public class ArtistController : Controller
    {
        private ArtistService _service;
        private IMapper _mapper;

        public ArtistController(ArtistService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ICollection<ArtistResponse> Get()
        {
            return _mapper.Map<ICollection<Artist>, ICollection<ArtistResponse>>( _service.GetAll() );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ArtistResponse Get(int id)
        {
            return _mapper.Map<Artist, ArtistResponse>(_service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ArtistRequest artistRequest)
        {
            _service.Create(_mapper.Map<ArtistRequest, Artist>(artistRequest));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ArtistRequest artistRequest)
        {
            _service.Update(_mapper.Map<ArtistRequest, Artist>(artistRequest));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}