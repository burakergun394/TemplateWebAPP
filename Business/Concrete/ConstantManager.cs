using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.Mapping.Automapper;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ConstantManager: AutoMapperService,IConstantService
    {
        private IConstantDal _constantDal;

        public ConstantManager(IConstantDal constantDal)
        {
            _constantDal = constantDal;
        }

        public IDataResult<Constant> Get()
        {
            var result = CheckIfCountZero();
            var messages = new List<String>();
            if (result == 0)
            {
                messages.Add(Messages.CountZero);
                return new ErrorDataResult<Constant>(messages);
            }

            return new SuccessDataResult<Constant>(_constantDal.GetAll().SingleOrDefault());
        }

        private int CheckIfCountZero()
        {
            return _constantDal.GetAll().Count();
        }
    }
}
