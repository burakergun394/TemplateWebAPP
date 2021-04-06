using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Mapping.Automapper.MapperProfiles
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();

            CreateMap<Constant, LogoDto>().ReverseMap();

            CreateMap<GeneralInformation, LogoDto>().ReverseMap();
            CreateMap<GeneralInformation, SocialMediaDto>().ReverseMap();
        }
    }
}
