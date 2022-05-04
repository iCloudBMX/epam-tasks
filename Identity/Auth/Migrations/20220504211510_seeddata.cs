using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26ddbd46-4930-4963-b6d8-3670fd07116c", "b7142014-9b3a-4417-ae45-186a8d0e2aac", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e88d0ff-8925-430d-afcf-e56f051f080d", "9d87975f-2aae-4f1b-b8a3-168cfed6f3d2", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e88d0ff-8925-430d-afcf-e56f051f080d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26ddbd46-4930-4963-b6d8-3670fd07116c");
        }
    }
}
