using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class DeleteSeatFromCartInputValidator : AbstractValidator<DeleteSeatFromCartInput>
    {
        public DeleteSeatFromCartInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.CartId).NotEmpty();

            RuleFor(_ => _.EventId).NotEmpty();

            RuleFor(_ => _.SeatId).NotEmpty();
        }
    }
}
