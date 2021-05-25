using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.ResponseMessages
{
    public static class UnprocessableEntityResponse
    {
        public static IEnumerable<object> Message(List<ValidationFailure> failures) {

            return failures.Select(x => new {
                propertyName = x.PropertyName,
                errorMessage = x.ErrorMessage
            });
        }
    }
}
