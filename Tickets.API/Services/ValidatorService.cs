
using FluentValidation;
using FluentValidation.Results;

namespace Tickets.API.Services
{
    public class ValidatorService : IValidatorService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ??
                throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task ValidateAsync<TInput>(TInput input) where TInput : class
        {
            IValidator<TInput> inputValidator = _serviceProvider.GetService<IValidator<TInput>>();
            if (inputValidator is null)
            {
                throw new InvalidOperationException("Fluent validator has not been found for the input model.");
            }


            ValidationResult validationResult = await inputValidator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
