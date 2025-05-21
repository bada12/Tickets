using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class SeatInputValidator : AbstractValidator<SeatInput>
    {
        public SeatInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.SeatId).NotEmpty();

            RuleFor(_ => _.EventId).NotEmpty();

            RuleFor(_ => _.UserId).NotEmpty();
        }
    }
}
