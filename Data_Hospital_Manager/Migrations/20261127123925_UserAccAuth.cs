using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class UserAccAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 27, 14, 39, 25, 294, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 27, 14, 39, 25, 294, DateTimeKind.Local).AddTicks(3575));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 27, 14, 30, 0, 786, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 11, 27, 14, 30, 0, 786, DateTimeKind.Local).AddTicks(4415));
        }
    }
}
