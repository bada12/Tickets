using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tickets.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PriceLevels",
                columns: new[] { "Level", "PriceMultiplier" },
                values: new object[,]
                {
                    { "Adult", 1.0 },
                    { "Child", 0.80000000000000004 },
                    { "VIP", 1.25 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("9d54ee29-d628-4585-8047-6a55835aa7e1"), "User", "user1@mail.com", "First Name 1", "Last Name 1", "PassW0rD1", "name1" },
                    { new Guid("9d54ee29-d628-4585-8047-6a55835aa7e2"), "User", "user2@mail.com", "First Name 2", "Last Name 2", "PassW0rD2", "name2" },
                    { new Guid("9d54ee29-d628-4585-8047-6a55835aa7e3"), "User", "user3@mail.com", "First Name 3", "Last Name 3", "PassW0rD3", "name3" },
                    { new Guid("9d54ee29-d628-4585-8047-6a55835aa7e4"), "Manager", "user4@mail.com", "First Name 4", "Last Name 4", "PassW0rD4", "name4" },
                    { new Guid("9d54ee29-d628-4585-8047-6a55835aa7e5"), "Manager", "user5@mail.com", "First Name 5", "Last Name 5", "PassW0rD5", "name5" },
                    { new Guid("9d54ee29-d628-4585-8047-6a55835aa7e6"), "Manager", "user6@mail.com", "First Name 6", "Last Name 6", "PassW0rD6", "name6" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "Name", "StartTime" },
                values: new object[,]
                {
                    { new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44461"), new Guid("9d54ee29-d628-4585-8047-6a55835aa7e4"), "Event 1", new DateTime(2020, 10, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44462"), new Guid("9d54ee29-d628-4585-8047-6a55835aa7e4"), "Event 2", new DateTime(2020, 12, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44463"), new Guid("9d54ee29-d628-4585-8047-6a55835aa7e5"), "Event 3", new DateTime(2020, 10, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44464"), new Guid("9d54ee29-d628-4585-8047-6a55835aa7e5"), "Event 4", new DateTime(2020, 12, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44465"), new Guid("9d54ee29-d628-4585-8047-6a55835aa7e6"), "Event 5", new DateTime(2020, 10, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44466"), new Guid("9d54ee29-d628-4585-8047-6a55835aa7e6"), "Event 6", new DateTime(2020, 12, 12, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "EventId", "SpotName" },
                values: new object[,]
                {
                    { new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d1"), "Main Street, 1", new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44461"), "Spot 1" },
                    { new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d2"), "Main Street, 2", new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44462"), "Spot 2" },
                    { new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d3"), "Main Street, 3", new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44463"), "Spot 3" },
                    { new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d4"), "Main Street, 4", new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44464"), "Spot 4" },
                    { new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d5"), "Main Street, 5", new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44465"), "Spot 5" },
                    { new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d6"), "Main Street, 6", new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44466"), "Spot 6" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[,]
                {
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7ba1"), "DanceHall", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d6") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7ba2"), "Section 1", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d6") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb0"), "Section 1", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d5") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb1"), "DanceHall", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d1") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb2"), "Section 1", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d1") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb3"), "DanceHall", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d2") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb4"), "Section 1", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d2") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb5"), "DanceHall", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d3") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb6"), "Section 1", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d3") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb7"), "DanceHall", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d4") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb8"), "Section 1", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d4") },
                    { new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb9"), "DanceHall", new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d5") }
                });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Number", "SectionId" },
                values: new object[,]
                {
                    { new Guid("7943755f-3935-41c9-b0e2-000000000001"), null, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb1") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000005"), 1, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb2") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000006"), 2, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb2") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000007"), null, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb3") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000011"), 1, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb4") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000012"), 2, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb4") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000013"), null, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb5") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000017"), 1, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb6") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000018"), 2, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb6") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000019"), null, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb7") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000023"), 1, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb8") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000024"), 2, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb8") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000025"), null, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb9") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000029"), 1, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb0") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000030"), 2, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb0") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000031"), null, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7ba1") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000035"), 1, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7ba2") },
                    { new Guid("7943755f-3935-41c9-b0e2-000000000036"), 2, new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7ba2") }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "OfferId", "Price", "PriceLevel", "RowId", "Status" },
                values: new object[,]
                {
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000000"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000001"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000002"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000003"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000004"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000005"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000006"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000007"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000008"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000009"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000001"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000010"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000011"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000012"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000013"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000014"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000015"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000016"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000017"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000018"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000019"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000005"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000020"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000021"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000022"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000023"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000024"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000025"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000026"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000027"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000028"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000029"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000006"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000030"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000031"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000032"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000033"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000034"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000035"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000036"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000037"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000038"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000039"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000007"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000040"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000041"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000042"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000043"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000044"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000045"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000046"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000047"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000048"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000049"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000011"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000050"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000051"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000052"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000053"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000054"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000055"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000056"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000057"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000058"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000059"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000012"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000060"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000061"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000062"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000063"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000064"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000065"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000066"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000067"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000068"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000069"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000013"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000070"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000071"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000072"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000073"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000074"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000075"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000076"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000077"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000078"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000079"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000017"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000080"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000081"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000082"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000083"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000084"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000085"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000086"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000087"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000088"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000089"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000018"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000090"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000091"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000092"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000093"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000094"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000095"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000096"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000097"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000098"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000099"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000019"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000100"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000101"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000102"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000103"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000104"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000105"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000106"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000107"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000108"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000109"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000023"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000110"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000111"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000112"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000113"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000114"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000115"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000116"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000117"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000118"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000119"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000024"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000120"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000121"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000122"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000123"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000124"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000125"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000126"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000127"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000128"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000129"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000025"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000130"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000131"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000132"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000133"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000134"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000135"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000136"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000137"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000138"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000139"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000029"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000140"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000141"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000142"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000143"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000144"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000145"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000146"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000147"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000148"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000149"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000030"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000150"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000151"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000152"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000153"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000154"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000155"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000156"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000157"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000158"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000159"), null, null, 10m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000031"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000160"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000161"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000162"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000163"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000164"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000165"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000166"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000167"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000168"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000169"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000035"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000170"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000171"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000172"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000173"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000174"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000175"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000176"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000177"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000178"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" },
                    { new Guid("a8da8a6b-8a73-4af3-995d-000000000179"), null, null, 12.5m, "Adult", new Guid("7943755f-3935-41c9-b0e2-000000000036"), "Available" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceLevels",
                keyColumn: "Level",
                keyValue: "Child");

            migrationBuilder.DeleteData(
                table: "PriceLevels",
                keyColumn: "Level",
                keyValue: "VIP");

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000000"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000001"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000002"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000003"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000004"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000005"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000006"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000007"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000008"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000009"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000010"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000011"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000012"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000013"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000014"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000015"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000016"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000017"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000018"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000019"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000020"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000021"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000022"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000023"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000024"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000025"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000026"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000027"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000028"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000029"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000030"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000031"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000032"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000033"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000034"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000035"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000036"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000037"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000038"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000039"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000040"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000041"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000042"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000043"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000044"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000045"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000046"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000047"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000048"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000049"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000050"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000051"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000052"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000053"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000054"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000055"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000056"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000057"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000058"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000059"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000060"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000061"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000062"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000063"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000064"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000065"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000066"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000067"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000068"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000069"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000070"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000071"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000072"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000073"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000074"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000075"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000076"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000077"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000078"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000079"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000080"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000081"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000082"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000083"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000084"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000085"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000086"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000087"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000088"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000089"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000090"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000091"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000092"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000093"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000094"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000095"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000096"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000097"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000098"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000099"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000100"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000101"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000102"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000103"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000104"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000105"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000106"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000107"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000108"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000109"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000110"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000111"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000112"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000113"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000114"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000115"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000116"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000117"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000118"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000119"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000120"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000121"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000122"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000123"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000124"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000125"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000126"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000127"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000128"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000129"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000130"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000131"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000132"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000133"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000134"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000135"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000136"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000137"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000138"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000139"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000140"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000141"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000142"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000143"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000144"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000145"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000146"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000147"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000148"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000149"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000150"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000151"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000152"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000153"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000154"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000155"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000156"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000157"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000158"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000159"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000160"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000161"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000162"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000163"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000164"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000165"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000166"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000167"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000168"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000169"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000170"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000171"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000172"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000173"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000174"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000175"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000176"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000177"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000178"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a8da8a6b-8a73-4af3-995d-000000000179"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d54ee29-d628-4585-8047-6a55835aa7e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d54ee29-d628-4585-8047-6a55835aa7e2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d54ee29-d628-4585-8047-6a55835aa7e3"));

            migrationBuilder.DeleteData(
                table: "PriceLevels",
                keyColumn: "Level",
                keyValue: "Adult");

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000001"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000005"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000006"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000007"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000011"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000012"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000013"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000017"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000018"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000019"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000023"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000024"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000025"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000029"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000030"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000031"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000035"));

            migrationBuilder.DeleteData(
                table: "Rows",
                keyColumn: "Id",
                keyValue: new Guid("7943755f-3935-41c9-b0e2-000000000036"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7ba1"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7ba2"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb0"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb1"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb2"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb3"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb4"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb5"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb6"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb7"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb8"));

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("eadcb033-0a4f-43be-80d8-74eb1a9c7bb9"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d1"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d2"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d3"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d4"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d5"));

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: new Guid("0b126c75-26e9-43ee-9574-37b0b2e7d8d6"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44461"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44462"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44463"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44464"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44465"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f967bee3-2dc1-4c3e-867a-7bf752b44466"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d54ee29-d628-4585-8047-6a55835aa7e4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d54ee29-d628-4585-8047-6a55835aa7e5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d54ee29-d628-4585-8047-6a55835aa7e6"));
        }
    }
}
