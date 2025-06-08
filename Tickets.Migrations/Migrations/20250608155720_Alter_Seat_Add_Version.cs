using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Offer_Add_Version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Offers",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Offers");
        }
    }
}
