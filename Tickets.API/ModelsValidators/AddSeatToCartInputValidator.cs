using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class AddSeatToCartInputValidator : AbstractValidator<AddSeatToCartInput>
    {
        public AddSeatToCartInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.CartId).NotEmpty();

            RuleFor(_ => _.SeatInput)
                .SetValidator(new SeatInputValidator());
        }
    }
}
