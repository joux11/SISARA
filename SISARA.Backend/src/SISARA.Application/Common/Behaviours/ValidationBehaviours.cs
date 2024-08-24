using FluentValidation;
using MediatR;
using SISARA.Application.Common.Base;
using ValidationException  = SISARA.Application.Common.Exceptions.ValidationException;

namespace SISARA.Application.Common.Behaviours
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validatiors;
        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validatiors)
        {
            _validatiors = validatiors;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validatiors.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validatiors.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResults
                    .Where(x => x.Errors.Any())
                    .SelectMany(x => x.Errors)
                    .GroupBy(x => x.PropertyName)
                    .Select(x => new BaseError()
                    {
                        PropertyName = x.Key,
                        Errors = x.Select(e => e.ErrorMessage).ToList()
                    }).ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
