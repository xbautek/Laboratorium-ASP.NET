using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectData.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3b284f6-7b20-4154-a906-bf1baa907c09", "f1979f16-a3f2-4e6b-a3a5-97fdf0c76c59" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3b284f6-7b20-4154-a906-bf1baa907c09");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1979f16-a3f2-4e6b-a3a5-97fdf0c76c59");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "authors",
                newName: "author_id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6d866b4-d311-408b-87fb-301d1c7677b7", "d6d866b4-d311-408b-87fb-301d1c7677b7", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f83d2ed6-218c-4496-a4cf-f60136f47ed9", 0, "8b63dac6-098a-4878-89cb-186833460454", "test@wsei.edu.pl", true, false, null, "TEST@WSEI.EDU.PL", "TEST", "AQAAAAEAACcQAAAAEIbrUTVyvNcf+UVpB/JhQOoqvcJ0s1Asi7CTsMagaOOa4Li20BmmBA0cn0rnCTvkzg==", null, false, "c2bda3af-18ab-428d-975d-adf92f33f962", false, "test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d6d866b4-d311-408b-87fb-301d1c7677b7", "f83d2ed6-218c-4496-a4cf-f60136f47ed9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d6d866b4-d311-408b-87fb-301d1c7677b7", "f83d2ed6-218c-4496-a4cf-f60136f47ed9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6d866b4-d311-408b-87fb-301d1c7677b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f83d2ed6-218c-4496-a4cf-f60136f47ed9");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "authors",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3b284f6-7b20-4154-a906-bf1baa907c09", "a3b284f6-7b20-4154-a906-bf1baa907c09", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f1979f16-a3f2-4e6b-a3a5-97fdf0c76c59", 0, "9d7ba146-ed02-4ecc-b911-529312d37490", "test@wsei.edu.pl", true, false, null, "TEST@WSEI.EDU.PL", "TEST", "AQAAAAEAACcQAAAAEIyvL8zHqmP0ShscGXN4+pRrrI+V539C+/oah6Lm7F/l4tIdx0X7NvP7Es10/RCviw==", null, false, "ea3f4b3b-8c70-47ca-b61f-3a1633e5ac69", false, "test" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3b284f6-7b20-4154-a906-bf1baa907c09", "f1979f16-a3f2-4e6b-a3a5-97fdf0c76c59" });
        }
    }
}
