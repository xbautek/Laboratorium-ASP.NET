using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectData.Migrations
{
    /// <inheritdoc />
    public partial class photoinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    photo_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    Camera = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Resolution = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.photo_id);
                    table.ForeignKey(
                        name: "FK_photos_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 101, "maxcut@gmail.com", "Max", "Cuttler" },
                    { 102, "danieltarka1994@o2.com", "Daniel", "Tarka" }
                });

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "photo_id", "AuthorId", "Camera", "DateAndTime", "Description", "Format", "Resolution" },
                values: new object[,]
                {
                    { 1, 101, "Nikon", new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "My best photo from the Kryspinów lake", "_16x9", "_2560x1440" },
                    { 2, 102, "Sony", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween party photo", "_21x9", "_3840x2160" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_photos_AuthorId",
                table: "photos",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
