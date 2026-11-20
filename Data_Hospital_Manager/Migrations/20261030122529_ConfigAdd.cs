using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class ConfigAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "BedsCount", "CreatedOn", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Cityville", 100, new DateTime(2026, 10, 30, 14, 25, 29, 331, DateTimeKind.Local).AddTicks(6004), "hos@pital.con", false, "City Hospital", "123-456-7890" },
                    { 2, "456 Elm St, Countyville", 200, new DateTime(2026, 10, 30, 14, 25, 29, 331, DateTimeKind.Local).AddTicks(6046), "hos@pital.com", false, "County General", "987-654-3210" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
