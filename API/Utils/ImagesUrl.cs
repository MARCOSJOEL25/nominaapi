using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using core.models;
using Core.models.Dto;
using Microsoft.Extensions.Configuration;

namespace API.Utils
{
    public class ImagesUrl : IValueResolver<employees, DtoEmployees, string>
    {
        private readonly IConfiguration _Config;
        public ImagesUrl(IConfiguration config)
        {
            _Config = config;
        }

        public string Resolve(employees source, DtoEmployees destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImagesUrl))
            {
                return _Config["ApiUrl"] + source.ImagesUrl;
            }

            return null;
        }
    }
}