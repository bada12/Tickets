using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class PaymentInputValidator : AbstractValidator<PaymentInput>
    {
        public PaymentInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.PaymentId).NotEmpty();
        }
    }
}
