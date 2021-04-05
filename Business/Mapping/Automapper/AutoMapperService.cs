using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;

namespace Business.Mapping.Automapper
{
    public abstract class AutoMapperService : IAutoMapperService
    {
        public IMapper Mapper
        {
            get { return ObjectMapper.Mapper; }
        }
    }
}
