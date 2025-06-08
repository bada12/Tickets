using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tickets.DataAccess;
using Tickets.Domain.Enums;
using Tickets.Tests.Common;

namespace Tickets.API.Tests.Controllers
{
    public class PaymentsControllerIntegrationTests : IClassFixture<TicketsAPIFactory>
    {
        private readonly TicketsAPIFactory _ticketsAPIFactory;

        public PaymentsControllerIntegrationTests(TicketsAPIFactory ticketsAPIFactory)
        {
            _ticketsAPIFactory = ticketsAPIFactory;
        }

        private async Task SeedOfferAsync(Guid offerId)
        {
            using var scope = _ticketsAPIFactory.Factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TicketsDbContext>();

            var user = ModelCreationHelper.CreateUser();
            var offer = ModelCreationHelper.CreateOffer(id: offerId, userId: user.Id);

            db.Users.Add(user);
            db.Offers.Add(offer);

            await db.SaveChangesAsync();
        }

        [Fact]
        public async Task GetPaymentStatus_ReturnsCorrectStatus()
        {
            // Arrange
            var offerId = Guid.NewGuid();
            await SeedOfferAsync(offerId);

            // Act
            var response = await _ticketsAPIFactory.HttpClient.GetAsync($"/payments/{offerId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var status = JsonSerializer.Deserialize<OfferStatus>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                });

            // Assert
            Assert.Equal(OfferStatus.Created, status);
        }

        [Fact]
        public async Task CompletePayment_ChangesStatusToCompleted()
        {
            // Arrange
            var offerId = Guid.NewGuid();
            await SeedOfferAsync(offerId);

            var request = new HttpRequestMessage(HttpMethod.Post, $"/payments/{offerId}/complete");
            request.Content = new StringContent(JsonSerializer.Serialize(new { PaymentId = offerId }), System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await _ticketsAPIFactory.HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var status = JsonSerializer.Deserialize<OfferStatus>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                });

            // Assert
            Assert.Equal(OfferStatus.Paid, status);
        }

        [Fact]
        public async Task FailPayment_ChangesStatusToFailed()
        {
            // Arrange
            var offerId = Guid.NewGuid();
            await SeedOfferAsync(offerId);

            var request = new HttpRequestMessage(HttpMethod.Post, $"/payments/{offerId}/fail");
            request.Content = new StringContent(JsonSerializer.Serialize(new { PaymentId = offerId }), System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await _ticketsAPIFactory.HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var status = JsonSerializer.Deserialize<OfferStatus>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                });

            // Assert
            Assert.Equal(OfferStatus.Failed, status);
        }
    }
}
