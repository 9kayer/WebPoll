using AutoMapper;
using WebPoll.Model.Models;
using WebPoll.Web.DTO;

namespace WebPoll.Web.ModelMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Genre, GenreResponse>();
            CreateMap<GenreRequest, Genre>();

            CreateMap<Music, MusicResponse>();
            CreateMap<MusicRequest, Music>();

            CreateMap<Artist, ArtistResponse>();
            CreateMap<ArtistRequest, Artist>();
        }
        
    }
}
