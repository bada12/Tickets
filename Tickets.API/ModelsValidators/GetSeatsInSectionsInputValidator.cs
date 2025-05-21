using FluentValidation;
using Tickets.API.Models;

namespace Tickets.API.ModelsValidators
{
    public class GetSeatsInSectionsInputValidator : AbstractValidator<GetSeatsInSectionsInput>
    {
        public GetSeatsInSectionsInputValidator()
        {
            RuleFor(_ => _).NotNull();

            RuleFor(_ => _.EventId).NotEmpty();

            RuleFor(_ => _.SectionId).NotEmpty();

            RuleFor(_ => _.Pagination)
                .SetValidator(new PaginationInputValidator());
        }
    }
}
