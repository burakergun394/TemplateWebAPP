using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static List<String> Validate(IValidator validator, Object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            var errorList = new List<String>();

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    errorList.Add(error.ErrorMessage);
                }
            }

            return errorList;
        }
    }
}
