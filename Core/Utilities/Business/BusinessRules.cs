using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params  IResult[] results)
        {
            var errorList = new List<string>();
            
            foreach (var result in results)
            {
                if (!result.IsSuccess)
                {
                    errorList.Add(result.Message);
                }
            }

            return errorList.Any() ? new ErrorResult(errorList) : new SuccessResult();
        }
        public static IDataResult<T> Run<T>(params IDataResult<T>[] results)
        {
            var errorList = new List<string>();

            foreach (var result in results)
            {
                if (!result.IsSuccess)
                {
                    errorList.Add(result.Message);
                }
            }

            return errorList.Any() ? new ErrorDataResult<T>(errorList) : new SuccessDataResult<T>();
        }
    }
}
