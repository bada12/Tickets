using Tickets.Domain.Entities;
using PriceLevelEnum = Tickets.Domain.Enums.PriceLevel;

namespace Tickets.Tests.Common
{
    public static class ModelCreationHelper
    {
        public static User CreateUser(
            Guid? id = null,
            string firstName = null,
            string lastName = null,
            string email = null,
            string username = null,
            string password = null)
        {
            User user = new User(
                id: id ?? Guid.NewGuid(),
                firstName: firstName ?? $"First name: {Guid.NewGuid()}",
                lastName: lastName ?? $"Last name: {Guid.NewGuid()}",
                email: email ?? $"email_{Guid.NewGuid()}@mail.com",
                username: username ?? $"username: {Guid.NewGuid()}",
                password: password ?? $"password{Guid.NewGuid()}");

            return user;
        }

        public static Manager CreateManager(
            Guid? id = null,
            string firstName = null,
            string lastName = null,
            string email = null,
            string username = null,
            string password = null)
        {
            Manager manager = new Manager(
                id: id ?? Guid.NewGuid(),
                firstName: firstName ?? $"First name: {Guid.NewGuid()}",
                lastName: lastName ?? $"Last name: {Guid.NewGuid()}",
                email: email ?? $"email_{Guid.NewGuid()}@mail.com",
                username: username ?? $"username: {Guid.NewGuid()}",
                password: password ?? $"password{Guid.NewGuid()}");

            return manager;
        }

        public static Event CreateEvent(
            Guid? id = null,
            string name = null,
            Guid? createdBy = null,
            DateTime startTime = default)
        {
            Event @event = new(
                id: id ?? Guid.NewGuid(),
                name: name ?? $"Event: {Guid.NewGuid()}",
                createdBy: createdBy ?? Guid.NewGuid(),
                startTime: startTime);

            return @event;
        }

        public static Venue CreateVenue(
            Guid? id = null,
            Guid? eventId = null,
            string spotName = null,
            string address = null)
        {
            Venue venue = new(
                id: id ?? Guid.NewGuid(),
                eventId: eventId ?? Guid.NewGuid(),
                spotName: spotName ?? $"Spot name: {Guid.NewGuid()}",
                address: address ?? $"address: {Guid.NewGuid()}");

            return venue;
        }

        public static Section CreateSection(
            Guid? id = null,
            Guid? venueId = null,
            string name = null)
        {
            Section section = new(
                id: id ?? Guid.NewGuid(),
                venueId: venueId ?? Guid.NewGuid(),
                name: name ?? $"Section: {Guid.NewGuid()}");
            return section;
        }

        public static Row CreateRow(
            Guid? id = null,
            int? number = 1,
            Guid? sectionId = null)
        {
            Row row = new(
                id: id ?? Guid.NewGuid(),
                number: number,
                sectionId: sectionId ?? Guid.NewGuid());
            return row;
        }

        public static Seat CreateSeat(
            Guid? id = null,
            int? number = 1,
            Guid? rowId = null,
            decimal price = 1M)
        {
            Seat seat = new(
                id: id ?? Guid.NewGuid(),
                number: number,
                rowId: rowId ?? Guid.NewGuid(),
                price: price);
            return seat;
        }

        public static PriceLevel CreatePriceLevel(
            PriceLevelEnum priceLevel = PriceLevelEnum.Adult,
            double priceMultiplier = 1)
        {
            PriceLevel priceLevelEntity = new(
                priceLevel: priceLevel,
                priceMultiplier: priceMultiplier);
            return priceLevelEntity;
        }

        public static Offer CreateOffer(
            Guid? id = null,
            Guid? userId = null,
            DateTime? timestamp = null)
        {
            Offer offer = new(
                id: id ?? Guid.NewGuid(),
                userId: userId ?? Guid.NewGuid(),
                timestamp: timestamp ?? DateTime.UtcNow);

            offer.Version = Guid.NewGuid().ToByteArray();

            return offer;
        }
    }
}
