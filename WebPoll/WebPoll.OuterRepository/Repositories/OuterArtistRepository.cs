using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebPoll.Model.OuterModels;
using WebPoll.OuterRepository.EntityModel;
using WebPoll.OuterRepository.ModelMapper;

namespace WebPoll.OuterRepository
{
    public class OuterArtistRepository : IOuterRepository<OuterArtist>
    {
        private readonly OuterContext _context;
        private readonly IMapper _mapper;

        public OuterArtistRepository(OuterContext context)
        {
            _context = context;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        public ICollection<OuterArtist> GetAll()
        {
            return _mapper.Map<ICollection<Artist>,ICollection<OuterArtist>>( _context.Artists.ToList());
        }
    }
}
