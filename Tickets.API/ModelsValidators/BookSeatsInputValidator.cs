using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class BookSeatsInputValidator : AbstractValidator<BookSeatsInput>
    {
        public BookSeatsInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.CartId).NotEmpty();
        }
    }
}
