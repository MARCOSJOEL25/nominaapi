using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using core.models;
using Core.models.Dto;

namespace API.Utils
{
    public class ProfilesMapper : Profile
    {
        public ProfilesMapper()
        {
            CreateMap<employees, DtoEmployees>()
                .ForMember(d => d.user, o => o.MapFrom(s => s.user.userName))
                .ForMember(d => d.job, o => o.MapFrom(s => s.job.nameJob))
                .ForMember(d=>d.ImagesUrl, o=>o.MapFrom<ImagesUrl>())
                .ReverseMap();
        }
        
    }
}