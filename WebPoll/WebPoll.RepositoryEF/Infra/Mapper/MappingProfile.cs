using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPoll.Model;
using WebPoll.Model.Models;
using WebPoll.Repository;

namespace WebPoll.Repository.ModelMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Gender, EntityModel.Gender>();
            CreateMap<EntityModel.Gender, Gender>();

            CreateMap<Music, EntityModel.Music>();
            CreateMap<EntityModel.Music, Music>();

            CreateMap<Artist, EntityModel.Artist>();
            CreateMap<EntityModel.Artist, Artist>();        }
        
    }
}
