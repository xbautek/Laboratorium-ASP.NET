using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectData.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "author_id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    PhotoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comments_photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "photos",
                        principalColumn: "photo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54184dae-8e3f-47f9-8bbc-c2b237ff2354", "54184dae-8e3f-47f9-8bbc-c2b237ff2354", "admin", "ADMIN" },
                    { "d7d94954-7317-4687-99b3-c042ab336690", "d7d94954-7317-4687-99b3-c042ab336690", "user", "USER" },
                    { "f7d01f2d-7baa-4c13-aa1a-fcd2654ea446", "f7d01f2d-7baa-4c13-aa1a-fcd2654ea446", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "55063f64-92af-472e-99d5-32c543c41907", 0, "c17f59ff-6c37-460d-ac06-192886d9c60d", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAEAACcQAAAAENVCYmF1z0I8kCM48Tx7dq9WonxaUv9ZwMvZGvBuXuX0b18Fk2ZZGhOqlpy0W5/veA==", null, false, "58d2176f-ddb9-4a9d-af61-0b2b210a87a8", false, "admin" },
                    { "5c0363c7-1892-4341-ae7f-29aaeaae99e6", 0, "cc53340b-81f3-4ef7-a08c-5a385b3abe30", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAEAACcQAAAAEB9BedLXLZkIA04VncWMJvvvLxrw9STec1bJIPd5OrMpbwr25IWtiYqY8BKkkdL5mg==", null, false, "bbd77147-b27c-4b5a-a075-ce9f9812a9e5", false, "user" },
                    { "93cfb92f-1204-4786-90d8-6506ef00c814", 0, "c21e1ead-b245-4315-a4f1-8e83cc1b0467", "adamk01@gmail.com", true, false, null, "ADAMK01@GMAIL.COM", "ADAMK01", "AQAAAAEAACcQAAAAEOaenREuxYUHgtcuhohCsQUkxV7Lr5N7tXF1lcOO1hItCRcRXSGxNUhdyven4aiixg==", null, false, "56c8a471-626c-4c49-af99-bebf202183ae", false, "adamk01" },
                    { "df68d24a-19eb-4190-9796-1b5fabd04e50", 0, "e0ebcbd5-75c5-4261-9b61-9a6306b460f4", "test@wsei.edu.pl", true, false, null, "TEST@WSEI.EDU.PL", "TEST", "AQAAAAEAACcQAAAAEHjLiZ5wWCsxaSLLz+e9IRjvdju3cjZX9NwSJVPLc45Ul+rgbKkZOfsIQWTGIvOQvQ==", null, false, "12dc1f12-8131-4cc8-9d86-9585b9f04ea5", false, "test" }
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "author_id", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 101, "maxcut@gmail.com", "Max", "Cuttler" },
                    { 102, "danieltarka1994@o2.com", "Daniel", "Tarka" },
                    { 103, "john.doe@example.com", "John", "Doe" },
                    { 104, "alice.johnson@example.com", "Alice", "Johnson" },
                    { 105, "bob.smith@example.com", "Bob", "Smith" },
                    { 106, "eva.brown@example.com", "Eva", "Brown" },
                    { 107, "mike.anderson@example.com", "Mike", "Anderson" },
                    { 108, "sophia.miller@example.com", "Sophia", "Miller" },
                    { 109, "david.clark@example.com", "David", "Clark" },
                    { 110, "olivia.wilson@example.com", "Olivia", "Wilson" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "54184dae-8e3f-47f9-8bbc-c2b237ff2354", "55063f64-92af-472e-99d5-32c543c41907" },
                    { "d7d94954-7317-4687-99b3-c042ab336690", "5c0363c7-1892-4341-ae7f-29aaeaae99e6" },
                    { "d7d94954-7317-4687-99b3-c042ab336690", "93cfb92f-1204-4786-90d8-6506ef00c814" },
                    { "f7d01f2d-7baa-4c13-aa1a-fcd2654ea446", "df68d24a-19eb-4190-9796-1b5fabd04e50" }
                });

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "photo_id", "AuthorId", "Camera", "DateAndTime", "Description", "Format", "Resolution" },
                values: new object[,]
                {
                    { 1, 101, "Nikon", new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "My best photo from the Kryspinów lake", "_16x9", "_2560x1440" },
                    { 2, 102, "Sony", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween party photo", "_21x9", "_3840x2160" },
                    { 3, 103, "Samsung", new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunny day at the beach", "_16x9", "_2560x1440" },
                    { 4, 104, "iPhone", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snowy mountains adventure", "_21x9", "_3840x2160" },
                    { 5, 105, "Huawei", new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunset over the city", "_16x9", "_2560x1440" },
                    { 6, 106, "LG", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "City lights at night", "_21x9", "_3840x2160" },
                    { 7, 107, "Google Pixel", new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cherry blossom in the park", "_16x9", "_2560x1440" },
                    { 8, 108, "OnePlus", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Majestic mountain view", "_21x9", "_3840x2160" },
                    { 9, 109, "Xiaomi", new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aerial view of the coastline", "_16x9", "_2560x1440" },
                    { 10, 110, "Motorola", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Night sky full of stars", "_21x9", "_3840x2160" }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "comment_id", "Comment", "PhotoId", "UserId" },
                values: new object[,]
                {
                    { 1, "Amazing shot!", 1, "55063f64-92af-472e-99d5-32c543c41907" },
                    { 2, "Spooky atmosphere!", 2, "5c0363c7-1892-4341-ae7f-29aaeaae99e6" },
                    { 3, "Beautiful beach day!", 3, "df68d24a-19eb-4190-9796-1b5fabd04e50" },
                    { 4, "Adventurous journey!", 4, "5c0363c7-1892-4341-ae7f-29aaeaae99e6" },
                    { 5, "Stunning sunset!", 5, "df68d24a-19eb-4190-9796-1b5fabd04e50" },
                    { 6, "City lights are magical!", 6, "55063f64-92af-472e-99d5-32c543c41907" },
                    { 7, "Cherry blossoms are my favorite!", 7, "55063f64-92af-472e-99d5-32c543c41907" },
                    { 8, "Impressive mountain view!", 8, "5c0363c7-1892-4341-ae7f-29aaeaae99e6" },
                    { 9, "Aerial views are mesmerizing!", 9, "55063f64-92af-472e-99d5-32c543c41907" },
                    { 10, "Starry night, truly magical!", 10, "df68d24a-19eb-4190-9796-1b5fabd04e50" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_PhotoId",
                table: "comments",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_photos_AuthorId",
                table: "photos",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
