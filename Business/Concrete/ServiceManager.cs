using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;
using Business.Abstract;
using Business.Constants;
using Business.Mapping.Automapper;
using Business.Validation.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using FluentValidation;
using FluentValidation.Results;
using Service = Entities.Concrete.Service;

namespace Business.Concrete
{
    public class ServiceManager: AutoMapperService, IServiceService
    {
        private IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }


        public IResult Add(ServiceDto serviceDto)
        {
            var service = Mapper.Map<Entities.Concrete.Service>(serviceDto);

            //var context = new ValidationContext<Service>(service);
            //var validator = new ServiceValidator();
            //var result = validator.Validate(context);

            var errorList = ValidationTool.Validate(new ServiceValidator(), service);

            if (errorList.Any()) return new ErrorResult(errorList);

            //var result = BusinessRules.Run(
            //    new ErrorResult("Hata 1"),
            //    new ErrorResult("Hata 2"),
            //    new ErrorResult("Hata 3"),
            //    new SuccessResult(),
            //    new ErrorResult("Hata 4"),
            //    new SuccessResult());

            //if (!result.IsSuccess)
            //    return result;

            _serviceDal.Add(service);

            return new SuccessResult();
        }

        public IDataResult<List<Service>> GetAll()
        {
            var result = CheckIfServiceCountZero();
            var messages = new List<String>();
            if (result == 0)
            {
                messages.Add(Messages.CountZero);
                return new ErrorDataResult<List<Service>>(messages);
            }

            var serviceList = _serviceDal.GetAll().ToList();

            return new SuccessDataResult<List<Service>>(serviceList);
        }

        private int CheckIfServiceCountZero()
        {
            var result = _serviceDal.GetAll().Count();

            return result;
        }
    }
}
