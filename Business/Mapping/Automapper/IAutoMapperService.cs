using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Mapping.Automapper
{
    public interface IAutoMapperService
    {
        IMapper Mapper { get; }
    }
}
