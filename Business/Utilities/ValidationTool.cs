using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Utilities
{
    public static class ValidationTool
    {
        public static IEnumerable<ValidationFailure> Validate<T>(IValidator<T> validator,T entity)
        {
            
            var validationResult = validator.Validate(entity);
            if (validationResult.Errors.Count > 0)
            {
                foreach (var error in validationResult.Errors)
                {
                    yield return error;
                }
                
            }
        }

    }
}
