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
    public class OuterGenreRepository : IOuterRepository<OuterGenre>
    {
        private readonly OuterContext _context;
        private readonly IMapper _mapper;

        public OuterGenreRepository(OuterContext context)
        {
            _context = context;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        public ICollection<OuterGenre> GetAll()
        {
            return _mapper.Map<ICollection<Genre>,ICollection<OuterGenre>>( _context.Genres.ToList());
        }
    }
}
