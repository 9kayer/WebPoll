using AutoMapper;
using WebPoll.Model.Models;

namespace WebPoll.OuterRepository.ModelMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Genre, EntityModel.Genre>();
            CreateMap<EntityModel.Genre, Genre>();

            CreateMap<Artist, EntityModel.Artist>();
            CreateMap<EntityModel.Artist, Artist>();        }
        
    }
}
