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
                    { "1d020b29-d905-4466-bda2-6a261daa34bf", "1d020b29-d905-4466-bda2-6a261daa34bf", "user", "USER" },
                    { "2b090bad-a9b9-4cb2-b134-577031a6efb2", "2b090bad-a9b9-4cb2-b134-577031a6efb2", "guest", "GUEST" },
                    { "a81ad496-ec11-4ba4-8c1e-ab7bfe14bc46", "a81ad496-ec11-4ba4-8c1e-ab7bfe14bc46", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f52dbc7-dc23-4ef2-94ce-649ef86dc21f", 0, "3ea9f769-28d3-4eb8-bdd8-1e57b803631f", "guest@wsei.edu.pl", true, false, null, "GUEST@WSEI.EDU.PL", "GUEST", "AQAAAAEAACcQAAAAEHV0KBjwVjfFECa5w/OEI3v1fZ2dOthe8Xz1kZbI7Jf2ZBWYhhyTrh7hTTxBLHOpyg==", null, false, "1e3e18a9-72d6-4fbb-afdb-789b326ad117", false, "guest" },
                    { "46b1fa49-b265-4e5d-acad-91c965e3a0ae", 0, "0cfddf7a-f83c-41d2-9000-686f74ef054e", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAEAACcQAAAAECRSCo1zN65h4+OM94toh0Xwn9UkVp53GdIJmupxJUC2XTB4vVgT1JVKw62RQXh3WA==", null, false, "0858ac14-63a4-4ff7-ba06-4ad3861e6902", false, "user" },
                    { "4d8f9321-672c-4191-9c0a-9bcd00630a42", 0, "547827d1-1f86-41ca-ac2e-e602e4c5ed20", "adamk01@gmail.com", true, false, null, "ADAMK01@GMAIL.COM", "ADAMK01", "AQAAAAEAACcQAAAAEBAfWWqzsK6XztCfE7VmyDuZQz7hlFtSx/uMUJV+cZaSEeC3qsATrnSOsgECMEaB5Q==", null, false, "ab6271b0-3269-4b8c-8bff-f3fbb49d6017", false, "adamk01" },
                    { "fec01f71-68a6-4858-9ed6-b2a4b10a6ba9", 0, "2d6d9628-913e-43b5-9e66-2ae96797d612", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAEAACcQAAAAEHyJy4/EZ91RaFbw7aA09HEUNWjz+4mgAwtZcSWsyjCd5Gixzd5I3ErUDaPKVM5oUA==", null, false, "9500a2d2-56d6-4b1e-8e2b-93d74c56e2b3", false, "admin" }
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
                    { "2b090bad-a9b9-4cb2-b134-577031a6efb2", "3f52dbc7-dc23-4ef2-94ce-649ef86dc21f" },
                    { "1d020b29-d905-4466-bda2-6a261daa34bf", "46b1fa49-b265-4e5d-acad-91c965e3a0ae" },
                    { "1d020b29-d905-4466-bda2-6a261daa34bf", "4d8f9321-672c-4191-9c0a-9bcd00630a42" },
                    { "a81ad496-ec11-4ba4-8c1e-ab7bfe14bc46", "fec01f71-68a6-4858-9ed6-b2a4b10a6ba9" }
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
                    { 1, "Amazing shot!", 1, "4d8f9321-672c-4191-9c0a-9bcd00630a42" },
                    { 2, "Spooky atmosphere!", 2, "46b1fa49-b265-4e5d-acad-91c965e3a0ae" },
                    { 3, "Beautiful beach day!", 3, "3f52dbc7-dc23-4ef2-94ce-649ef86dc21f" },
                    { 4, "Adventurous journey!", 4, "46b1fa49-b265-4e5d-acad-91c965e3a0ae" },
                    { 5, "Stunning sunset!", 5, "3f52dbc7-dc23-4ef2-94ce-649ef86dc21f" },
                    { 6, "City lights are magical!", 6, "fec01f71-68a6-4858-9ed6-b2a4b10a6ba9" },
                    { 7, "Cherry blossoms are my favorite!", 7, "fec01f71-68a6-4858-9ed6-b2a4b10a6ba9" },
                    { 8, "Impressive mountain view!", 8, "46b1fa49-b265-4e5d-acad-91c965e3a0ae" },
                    { 9, "Aerial views are mesmerizing!", 9, "4d8f9321-672c-4191-9c0a-9bcd00630a42" },
                    { 10, "Starry night, truly magical!", 10, "3f52dbc7-dc23-4ef2-94ce-649ef86dc21f" }
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
