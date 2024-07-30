using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestWeb.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "182626e1-f149-4fbe-b9ff-658fd289bcf4", "50afddf5-8b71-4c92-998c-d7cdc2050a66", "User", "user" },
                    { "925591ae-e21c-46b7-b49c-602b5cdd55b5", "16a01200-2d36-4c95-98b1-91bc55f0097a", "Admin", "admin" },
                    { "a979da36-e0af-413a-a0b8-040177c45527", "a7ddb957-5a43-485e-a229-25653d2e9b33", "Sales", "sales" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "182626e1-f149-4fbe-b9ff-658fd289bcf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "925591ae-e21c-46b7-b49c-602b5cdd55b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a979da36-e0af-413a-a0b8-040177c45527");
        }
    }
}
