using Moq;
using Tickets.API.Controllers;
using Tickets.API.Models;
using Tickets.API.Services;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.API.Tests.Controllers
{
    public class EventsControllerTests
    {
        private readonly Mock<IEventRepository> _eventRepoMock = new();
        private readonly Mock<ISectionRepository> _sectionRepoMock = new();
        private readonly Mock<IValidatorService> _validatorMock = new();

        private EventsController CreateController() =>
            new EventsController(_eventRepoMock.Object, _sectionRepoMock.Object, _validatorMock.Object);

        [Fact]
        public async Task GetEventsAsync_ValidInput_ReturnsPagedEvents()
        {
            // Arrange
            var input = new PaginationInput { PageIndex = 1, PageSize = 10 };
            var pagedEvents = Paged<Event>.Create(
                pageIndex: input.PageIndex.Value,
                pageSize: input.PageSize.Value,
                totalCount: 0,
                entities: Enumerable.Empty<Event>());

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _eventRepoMock.Setup(r => r.GetAsync(input.PageIndex, input.PageSize))
                .ReturnsAsync(pagedEvents);

            var controller = CreateController();

            // Act
            var result = await controller.GetEventsAsync(input);

            // Assert
            Assert.Equal(pagedEvents, result);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _eventRepoMock.Verify(r => r.GetAsync(input.PageIndex, input.PageSize), Times.Once);
        }

        [Fact]
        public async Task GetSeatsInSectionsAsync_ValidInput_ReturnsPagedSeats()
        {
            // Arrange
            var input = new GetSeatsInSectionsInput
            {
                SectionId = Guid.NewGuid(),
                Pagination = new PaginationInput { PageIndex = 0, PageSize = 5 }
            };

            var pagedSeats = Paged<Seat>.Create(
                pageIndex: input.Pagination.PageIndex.Value,
                pageSize: input.Pagination.PageSize.Value,
                totalCount: 0,
                entities: Enumerable.Empty<Seat>());

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _sectionRepoMock.Setup(r => r.GetSeatsAsync(
                    input.SectionId,
                    input.Pagination.PageIndex,
                    input.Pagination.PageSize))
                .ReturnsAsync(pagedSeats);

            var controller = CreateController();

            // Act
            var result = await controller.GetSeatsInSectionsAsync(input);

            // Assert
            Assert.Equal(pagedSeats, result);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _sectionRepoMock.Verify(r => r.GetSeatsAsync(
                input.SectionId,
                input.Pagination.PageIndex,
                input.Pagination.PageSize), Times.Once);
        }
    }
}
