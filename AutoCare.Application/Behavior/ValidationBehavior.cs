using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Behavior
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : class
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (validators.Any())
            {

                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(
                    validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResult
                    .Where(r => r.Errors.Count > 0)
                    .SelectMany(r => r.Errors)
                    .ToList();

                if(failures.Count > 0)
                    throw new ValidationException(failures);

            }
            return await next();


        }
    }
}
