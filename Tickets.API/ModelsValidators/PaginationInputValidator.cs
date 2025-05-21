using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class PaginationInputValidator : AbstractValidator<PaginationInput>
    {
        public PaginationInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.PageIndex).Must(_ => _.Value >= 0).When(_ => _.PageIndex.HasValue);

            RuleFor(_ => _.PageSize).Must(_ => _.Value >= 0).When(_ => _.PageSize.HasValue);
        }
    }
}
