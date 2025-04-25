using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Alter_OfferStatuses_Add_Failed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Status",
                table: "Offers");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Status",
                table: "Offers",
                sql: "[Status] IN (\r\n                    N'Created'\r\n                    ,N'Sent'\r\n                    ,N'Paid'\r\n                    ,N'Declined'\r\n                    ,N'Failed'\r\n                )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Status",
                table: "Offers");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Status",
                table: "Offers",
                sql: "[Status] IN (\r\n                    N'Created'\r\n                    ,N'Sent'\r\n                    ,N'Paid'\r\n                    ,N'Declined'\r\n                )");
        }
    }
}
