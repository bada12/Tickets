using Tickets.Domain.Entities;
using Tickets.Domain.Enums;

namespace Tickets.DataAccess
{
    public static class DataGenerator
    {
        static DataGenerator()
        {
            PriceLevels = GetPriceLevels().ToList();
            Users = GetUsers().ToList();
            Managers = GetManagers().ToList();
            Events = GetEvents().ToList();
            Venues = GetVenues().ToList();
            Sections = GetSections().ToList();
            Rows = GetRows().ToList();
            Seats = GetSeats().ToList();
        }

        public static List<Domain.Entities.PriceLevel> PriceLevels { get; }

        public static List<User> Users { get; }

        public static List<Manager> Managers { get; }

        public static List<Event> Events { get; }

        public static List<Venue> Venues { get; }

        public static List<Section> Sections { get; }

        public static List<Row> Rows { get; }

        public static List<Seat> Seats { get; }

        private static IEnumerable<Domain.Entities.PriceLevel> GetPriceLevels()
        {
            yield return new Domain.Entities.PriceLevel(Domain.Enums.PriceLevel.Child, 0.8);

            yield return new Domain.Entities.PriceLevel(Domain.Enums.PriceLevel.Adult, 1);

            yield return new Domain.Entities.PriceLevel(Domain.Enums.PriceLevel.VIP, 1.25);
        }

        private static IEnumerable<User> GetUsers()
        {
            yield return new User(
                id: Guid.Parse("9d54ee29-d628-4585-8047-6a55835aa7e1"),
                firstName: "First Name 1",
                lastName: "Last Name 1",
                email: "user1@mail.com",
                username: "name1",
                password: "PassW0rD1");

            yield return new User(
                id: Guid.Parse("9d54ee29-d628-4585-8047-6a55835aa7e2"),
                firstName: "First Name 2",
                lastName: "Last Name 2",
                email: "user2@mail.com",
                username: "name2",
                password: "PassW0rD2");

            yield return new User(
                id: Guid.Parse("9d54ee29-d628-4585-8047-6a55835aa7e3"),
                firstName: "First Name 3",
                lastName: "Last Name 3",
                email: "user3@mail.com",
                username: "name3",
                password: "PassW0rD3");
        }

        private static IEnumerable<Manager> GetManagers()
        {
            yield return new Manager(
                id: Guid.Parse("9d54ee29-d628-4585-8047-6a55835aa7e4"),
                firstName: "First Name 4",
                lastName: "Last Name 4",
                email: "user4@mail.com",
                username: "name4",
                password: "PassW0rD4");

            yield return new Manager(
                id: Guid.Parse("9d54ee29-d628-4585-8047-6a55835aa7e5"),
                firstName: "First Name 5",
                lastName: "Last Name 5",
                email: "user5@mail.com",
                username: "name5",
                password: "PassW0rD5");

            yield return new Manager(
                id: Guid.Parse("9d54ee29-d628-4585-8047-6a55835aa7e6"),
                firstName: "First Name 6",
                lastName: "Last Name 6",
                email: "user6@mail.com",
                username: "name6",
                password: "PassW0rD6");
        }

        public static IEnumerable<Event> GetEvents()
        {
            yield return new Event(
                id: Guid.Parse("f967bee3-2dc1-4c3e-867a-7bf752b44461"),
                name: "Event 1",
                createdBy: Managers[0].Id,
                startTime: new DateTime(2020, 10, 10, 18, 00, 00));

            yield return new Event(
                id: Guid.Parse("f967bee3-2dc1-4c3e-867a-7bf752b44462"),
                name: "Event 2",
                createdBy: Managers[0].Id,
                startTime: new DateTime(2020, 12, 12, 18, 00, 00));

            yield return new Event(
                id: Guid.Parse("f967bee3-2dc1-4c3e-867a-7bf752b44463"),
                name: "Event 3",
                createdBy: Managers[1].Id,
                startTime: new DateTime(2020, 10, 10, 18, 00, 00));

            yield return new Event(
                id: Guid.Parse("f967bee3-2dc1-4c3e-867a-7bf752b44464"),
                name: "Event 4",
                createdBy: Managers[1].Id,
                startTime: new DateTime(2020, 12, 12, 18, 00, 00));

            yield return new Event(
                id: Guid.Parse("f967bee3-2dc1-4c3e-867a-7bf752b44465"),
                name: "Event 5",
                createdBy: Managers[2].Id,
                startTime: new DateTime(2020, 10, 10, 18, 00, 00));

            yield return new Event(
                id: Guid.Parse("f967bee3-2dc1-4c3e-867a-7bf752b44466"),
                name: "Event 6",
                createdBy: Managers[2].Id,
                startTime: new DateTime(2020, 12, 12, 18, 00, 00));
        }

        private static IEnumerable<Venue> GetVenues()
        {
            yield return new Venue(
                id: Guid.Parse("0b126c75-26e9-43ee-9574-37b0b2e7d8d1"),
                eventId: Events[0].Id,
                spotName: "Spot 1",
                address: "Main Street, 1");

            yield return new Venue(
                id: Guid.Parse("0b126c75-26e9-43ee-9574-37b0b2e7d8d2"),
                eventId: Events[1].Id,
                spotName: "Spot 2",
                address: "Main Street, 2");

            yield return new Venue(
                id: Guid.Parse("0b126c75-26e9-43ee-9574-37b0b2e7d8d3"),
                eventId: Events[2].Id,
                spotName: "Spot 3",
                address: "Main Street, 3");

            yield return new Venue(
                id: Guid.Parse("0b126c75-26e9-43ee-9574-37b0b2e7d8d4"),
                eventId: Events[3].Id,
                spotName: "Spot 4",
                address: "Main Street, 4");

            yield return new Venue(
                id: Guid.Parse("0b126c75-26e9-43ee-9574-37b0b2e7d8d5"),
                eventId: Events[4].Id,
                spotName: "Spot 5",
                address: "Main Street, 5");

            yield return new Venue(
                id: Guid.Parse("0b126c75-26e9-43ee-9574-37b0b2e7d8d6"),
                eventId: Events[5].Id,
                spotName: "Spot 6",
                address: "Main Street, 6");
        }

        private static IEnumerable<Section> GetSections()
        {
            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb1"),
                venueId: Venues[0].Id,
                name: "DanceHall");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb2"),
                venueId: Venues[0].Id,
                name: "Section 1");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb3"),
                venueId: Venues[1].Id,
                name: "DanceHall");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb4"),
                venueId: Venues[1].Id,
                name: "Section 1");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb5"),
                venueId: Venues[2].Id,
                name: "DanceHall");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb6"),
                venueId: Venues[2].Id,
                name: "Section 1");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb7"),
                venueId: Venues[3].Id,
                name: "DanceHall");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb8"),
                venueId: Venues[3].Id,
                name: "Section 1");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb9"),
                venueId: Venues[4].Id,
                name: "DanceHall");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7bb0"),
                venueId: Venues[4].Id,
                name: "Section 1");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7ba1"),
                venueId: Venues[5].Id,
                name: "DanceHall");

            yield return new Section(
                id: Guid.Parse("eadcb033-0a4f-43be-80d8-74eb1a9c7ba2"),
                venueId: Venues[5].Id,
                name: "Section 1");
        }

        private static IEnumerable<Row> GetRows()
        {
            for (int i = 0; i < Sections.Count; i++)
            {
                int multiplier = i * 3;

                if (i % 2 == 0)
                {
                    yield return new Row(
                        id: Guid.Parse($"7943755f-3935-41c9-b0e2-{(multiplier + 1).ToString().PadLeft(12, '0')}"),
                        number: null,
                        sectionId: Sections[i].Id);
                }
                else
                {
                    yield return new Row(
                        id: Guid.Parse($"7943755f-3935-41c9-b0e2-{(multiplier + 2).ToString().PadLeft(12, '0')}"),
                        number: 1,
                        sectionId: Sections[i].Id);

                    yield return new Row(
                        id: Guid.Parse($"7943755f-3935-41c9-b0e2-{(multiplier + 3).ToString().PadLeft(12, '0')}"),
                        number: 2,
                        sectionId: Sections[i].Id);
                }
            }
        }

        private static IEnumerable<Seat> GetSeats()
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i % 3 == 0)
                    {
                        yield return new Seat(
                            id: Guid.Parse($"a8da8a6b-8a73-4af3-995d-{(i * 10 + j).ToString().PadLeft(12, '0')}"),
                            number: null,
                            rowId: Rows[i].Id,
                            price: 10);
                    }
                    else
                    {
                        yield return new Seat(
                            id: Guid.Parse($"a8da8a6b-8a73-4af3-995d-{(i * 10 + j).ToString().PadLeft(12, '0')}"),
                            number: null,
                            rowId: Rows[i].Id,
                            price: 12.5M);
                    }
                }
            }
        }
    }
}
