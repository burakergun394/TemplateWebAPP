using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Mapping.Automapper;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class GeneralInformationManager: AutoMapperService, IGeneralInformationService
    {
        private IGeneralInformationDal _generalInformationDal;

        public GeneralInformationManager(IGeneralInformationDal generalInformationDal)
        {
            _generalInformationDal = generalInformationDal;
        }

        public IDataResult<GeneralInformation> Get()
        {
            return new SuccessDataResult<GeneralInformation>(GetSingleData());
        }

        public IDataResult<SocialMediaDto> GetSocialMedia()
        {
            return new SuccessDataResult<SocialMediaDto>(GetDtoWithMapper<SocialMediaDto>(GetSingleData()));
        }

        public IResult InsertOrUpdate(LogoDto logoDto)
        {
            throw new NotImplementedException();
        }

        public IResult Update(GeneralInformation generalInformation)
        {
            var newGeneralInformation = GetEntityWithMapper(generalInformation);
            _generalInformationDal.Update(newGeneralInformation);

            return new SuccessResult();
        }

        public IResult UpdateLogo(LogoDto logoDto)
        {
            var generalInformation = _generalInformationDal.GetAll().SingleOrDefault();

            var generalInformationNew = Mapper.Map<LogoDto, GeneralInformation>(logoDto, generalInformation);

            _generalInformationDal.Update(generalInformationNew);

            return new SuccessResult();
        }

        public IResult UpdateSocialMedia(SocialMediaDto socialMediaDto)
        {
            var generalInformation = GetEntityWithMapper(socialMediaDto);
            
            _generalInformationDal.Update(generalInformation);

            return new SuccessResult();
        }

        private GeneralInformation GetEntityWithMapper<T>(T dto)
        {
            return Mapper.Map<T, GeneralInformation>(dto, GetSingleData());
        }

        private T GetDtoWithMapper<T>(GeneralInformation generalInformation) where T:new()
        {
            return Mapper.Map<GeneralInformation, T>(GetSingleData(), new T());
        }

        private GeneralInformation GetSingleData()
        {
            return _generalInformationDal.GetAll().SingleOrDefault();
        }
        
    }
}
