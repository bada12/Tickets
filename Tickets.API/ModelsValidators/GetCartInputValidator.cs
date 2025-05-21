using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class GetCartInputValidator : AbstractValidator<GetCartInput>
    {
        public GetCartInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.CartId).NotEmpty();
        }
    }
}
