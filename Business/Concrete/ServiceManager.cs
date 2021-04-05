using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;
using Business.Abstract;
using Business.Constants;
using Business.Mapping.Automapper;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
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

            var service = Mapper.Map<Entities.Concrete.Service>(serviceDto); ;

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
