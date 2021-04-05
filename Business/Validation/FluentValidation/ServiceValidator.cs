using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class ServiceValidator: AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.NameRequired);
        }
    }
}
