using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RoomName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Owner = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: true),
                    reservation_date = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "reservations",
                columns: new[] { "Id", "Address", "City", "reservation_date", "Owner", "price", "RoomName" },
                values: new object[,]
                {
                    { 1, "Wysłouchów 22", "Kraków", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan Kowalski", 500m, "44" },
                    { 2, "Polna 44", "Miechów", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna Nowak", 123123m, "546" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
