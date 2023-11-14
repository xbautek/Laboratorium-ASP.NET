using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    photo_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    Camera = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Resolution = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.photo_id);
                });

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "photo_id", "Author", "Camera", "DateAndTime", "Description", "Format", "Resolution" },
                values: new object[,]
                {
                    { 1, "Max Pietrucha", "Nikon", new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "My best photo from the Kryspinów lake", "_16x9", "_2560x1440" },
                    { 2, "Alex Sulek", "Sony", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween party photo", "_21x9", "_3840x2160" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "photos");
        }
    }
}
