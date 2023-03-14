using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = CleanArquitecture.Application.Exceptions.ValidationException;

namespace CleanArquitecture.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_validators.Any())
            {
                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
                ValidationResult[] validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                IList<ValidationFailure> failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if(failures.Count != 0) { throw new ValidationException(failures); }
            }
            return await next();
        }
    }
}
