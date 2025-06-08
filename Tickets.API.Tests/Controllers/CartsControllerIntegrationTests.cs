using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using Tickets.API.Models;
using Tickets.DataAccess;
using Tickets.Domain.Enums;
using Tickets.Tests.Common;

namespace Tickets.API.Tests.Controllers
{
    public class CartsControllerIntegrationTests : IClassFixture<TicketsAPIFactory>
    {
        private readonly TicketsAPIFactory _ticketsAPIFactory;

        public CartsControllerIntegrationTests(TicketsAPIFactory ticketsAPIFactory)
        {
            _ticketsAPIFactory = ticketsAPIFactory;
        }

        private async Task SeedDataAsync(
            SeatInput seatInput)
        {
            using var scope = _ticketsAPIFactory.Factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TicketsDbContext>();

            var manager = ModelCreationHelper.CreateManager();
            var @event = ModelCreationHelper.CreateEvent(id: seatInput.EventId, createdBy: manager.Id);
            var venue = ModelCreationHelper.CreateVenue(eventId: seatInput.EventId);
            var section = ModelCreationHelper.CreateSection(venueId: venue.Id);
            var row = ModelCreationHelper.CreateRow(sectionId: section.Id, number: null);
            var seat = ModelCreationHelper.CreateSeat(id: seatInput.SeatId, number: int.MinValue, rowId: row.Id);

            var user = ModelCreationHelper.CreateUser(id: seatInput.UserId);

            db.Managers.Add(manager);
            db.Events.Add(@event);
            db.Venues.Add(venue);
            db.Sections.Add(section);
            db.Rows.Add(row);
            db.Users.Add(user);
            db.Seats.Add(seat);

            await db.SaveChangesAsync();
        }

        [Theory]
        [InlineData(1000)]
        public async Task BookSameSeat_ConcurrentRequests_ShouldOnlySucceedOnce(int parallelRequests)
        {
            // Arrange
            Guid cartId = Guid.NewGuid();
            Guid eventId = Guid.NewGuid();
            Guid seatId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            PriceLevel priceLevel = PriceLevel.Adult;

            var input = new SeatInput(
                EventId: eventId,
                SeatId: seatId,
                PriceLevel: priceLevel,
                UserId: userId);

            await SeedDataAsync(input);

            var json = JsonSerializer.Serialize(input);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            ConcurrentBag<HttpResponseMessage> responses = [];

            // Act 
            await Parallel.ForAsync(0, parallelRequests, async (_, _) =>
            {
                HttpResponseMessage responseMessage = await _ticketsAPIFactory
                    .HttpClient
                    .PostAsync($"/orders/carts/{cartId}", content);

                responses.Add(responseMessage);
            });

            // Assert
            var successCount = responses.Count(r => r.IsSuccessStatusCode);
            var errorCount = responses.Count(r => !r.IsSuccessStatusCode);

            Assert.Equal(1, successCount);
            Assert.Equal(parallelRequests - 1, errorCount);
        }
    }
}
