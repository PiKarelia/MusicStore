using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSt.Context.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Guid", "IsDeleted", "Name" },
                values: new object[] { new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f"), false, "artist" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Guid", "Email", "IsDeleted", "Login", "Password" },
                values: new object[] { new Guid("e2d11f90-81ed-4eb8-a691-377396be8f6c"), "dj.music@yopmail.com", false, "dj.music@yopmail.com", "73fb1f36b321b11a7d9606d5b22e7701" });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "Guid", "ClaimType", "ClaimValue", "Discriminator", "RoleGuid" },
                values: new object[] { new Guid("2bddc6f2-78c2-4c39-b25a-f4bfa9933070"), "music", "add", "RoleClaim", new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleGuid", "UserGuid" },
                values: new object[] { new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f"), new Guid("e2d11f90-81ed-4eb8-a691-377396be8f6c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Claims",
                keyColumn: "Guid",
                keyValue: new Guid("2bddc6f2-78c2-4c39-b25a-f4bfa9933070"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleGuid", "UserGuid" },
                keyValues: new object[] { new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f"), new Guid("e2d11f90-81ed-4eb8-a691-377396be8f6c") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Guid",
                keyValue: new Guid("e06f16e2-1af4-4d62-9790-ceb7b705298f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Guid",
                keyValue: new Guid("e2d11f90-81ed-4eb8-a691-377396be8f6c"));
        }
    }
}
