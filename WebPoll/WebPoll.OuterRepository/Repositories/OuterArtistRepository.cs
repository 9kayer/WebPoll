using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebPoll.Model.Models;
using WebPoll.OuterRepository.ModelMapper;

namespace WebPoll.OuterRepository
{
    public class OuterArtistRepository : IOuterRepository<Artist>
    {
        private readonly OuterContext _context;
        private readonly IMapper _mapper;

        public OuterArtistRepository(OuterContext context)
        {
            _context = context;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        public ICollection<Artist> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Artist>,ICollection<Artist>>( _context.Artists.ToList());
        }
    }
}
