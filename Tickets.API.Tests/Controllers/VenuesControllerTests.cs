using Moq;
using Tickets.API.Controllers;
using Tickets.API.Models;
using Tickets.API.Services.Interfaces;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.API.Tests.Controllers
{
    public class VenuesControllerTests
    {
        private readonly Mock<IVenueRepository> _venueRepoMock = new();
        private readonly Mock<ISectionRepository> _sectionRepoMock = new();
        private readonly Mock<IValidatorService> _validatorMock = new();

        private VenuesController CreateController() =>
            new VenuesController(_venueRepoMock.Object, _sectionRepoMock.Object, _validatorMock.Object);

        [Fact]
        public async Task GetVenuesAsync_ValidInput_ReturnsPagedVenues()
        {
            // Arrange
            var input = new PaginationInput { PageIndex = 1, PageSize = 20 };
            var pagedVenues = Paged<Venue>.Create(
                pageIndex: input.PageIndex.Value,
                pageSize: input.PageSize.Value,
                totalCount: 0,
                entities: Enumerable.Empty<Venue>());

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _venueRepoMock.Setup(r => r.GetAsync(input.PageIndex, input.PageSize))
                .ReturnsAsync(pagedVenues);

            var controller = CreateController();

            // Act
            var result = await controller.GetVenuesAsync(input);

            // Assert
            Assert.Equal(pagedVenues, result);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _venueRepoMock.Verify(r => r.GetAsync(input.PageIndex, input.PageSize), Times.Once);
        }

        [Fact]
        public async Task GetSectionsByVenueIdAsync_ValidInput_ReturnsPagedSections()
        {
            // Arrange
            var venueId = Guid.NewGuid();
            var input = new GetSectionsByVenueInput
            {
                VenueId = venueId,
                Pagination = new PaginationInput { PageIndex = 0, PageSize = 5 }
            };
            var pagedSections = Paged<Section>.Create(
                pageIndex: input.Pagination.PageIndex.Value,
                pageSize: input.Pagination.PageSize.Value,
                totalCount: 0,
                entities: Enumerable.Empty<Section>());

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _sectionRepoMock.Setup(r => r.GetAsync(venueId, input.Pagination.PageIndex, input.Pagination.PageSize))
                .ReturnsAsync(pagedSections);

            var controller = CreateController();

            // Act
            var result = await controller.GetSectionsByVenueIdAsync(input);

            // Assert
            Assert.Equal(pagedSections, result);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _sectionRepoMock.Verify(r => r.GetAsync(venueId, input.Pagination.PageIndex, input.Pagination.PageSize), Times.Once);
        }
    }
}
