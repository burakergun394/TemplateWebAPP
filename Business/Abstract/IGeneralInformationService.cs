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
    public interface IGeneralInformationService
    {
        IDataResult<GeneralInformation> Get();
        IDataResult<SocialMediaDto> GetSocialMedia();
        IResult InsertOrUpdate(LogoDto logoDto);
        IResult Update(GeneralInformation generalInformation);
        IResult UpdateLogo(LogoDto logoDto);
        IResult UpdateSocialMedia(SocialMediaDto socialMediaDto);
    }
}
