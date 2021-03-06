﻿using AutoMapper;
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
            CreateMap<Genre, EntityModel.Genre>();
            CreateMap<EntityModel.Genre, Genre>();

            CreateMap<Music, EntityModel.Music>();
            CreateMap<EntityModel.Music, Music>();

            CreateMap<Artist, EntityModel.Artist>();
            CreateMap<EntityModel.Artist, Artist>();        }
        
    }
}
