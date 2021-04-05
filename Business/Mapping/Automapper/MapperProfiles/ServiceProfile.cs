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
    public class ServiceProfile :Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
