using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IConstantService
    {
        IDataResult<Constant> Get();
        IDataResult<LogoDto> GetLogo();
    }
}
