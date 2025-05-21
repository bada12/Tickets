using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class GetSectionsByVenueInputValidator : AbstractValidator<GetSectionsByVenueInput>
    {
        public GetSectionsByVenueInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.VenueId).NotEmpty();

            RuleFor(_ => _.Pagination)
                .SetValidator(new PaginationInputValidator());
        }
    }
}
