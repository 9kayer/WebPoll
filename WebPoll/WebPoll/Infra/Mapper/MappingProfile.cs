using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.DTO;
using WebPoll.Models;

namespace WebPoll.Infra.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Gender, GenderDTO>();
            CreateMap<GenderDTO, Gender>();

            CreateMap<Music, MusicDTO>();
            CreateMap<MusicDTO, Music>();

            CreateMap<Artist, ArtistDTO>();
            CreateMap<ArtistDTO, Artist>();        }
        
    }
}
