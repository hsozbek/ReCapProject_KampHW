using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name.Length).GreaterThanOrEqualTo(2).WithMessage("{MinLength}");
            RuleFor(c => c.DailyPrice).GreaterThan((decimal)0);

        }
    }
}
