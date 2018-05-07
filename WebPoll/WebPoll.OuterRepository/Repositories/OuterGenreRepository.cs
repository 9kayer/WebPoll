using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebPoll.Model.Models;
using WebPoll.OuterRepository.ModelMapper;

namespace WebPoll.OuterRepository
{
    public class OuterGenreRepository : IOuterRepository<Genre>
    {
        private readonly OuterContext _context;
        private readonly IMapper _mapper;

        public OuterGenreRepository(OuterContext context)
        {
            _context = context;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        public ICollection<Genre> GetAll()
        {
            return _mapper.Map<ICollection<EntityModel.Genre>,ICollection<Genre>>( _context.Genres.ToList());
        }
    }
}
