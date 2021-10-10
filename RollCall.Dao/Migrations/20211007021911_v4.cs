using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RollCall.Persistence.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 10, 6, 21, 19, 9, 920, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 10, 6, 21, 19, 9, 924, DateTimeKind.Local).AddTicks(4702));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 10, 6, 21, 16, 50, 97, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 10, 6, 21, 16, 50, 110, DateTimeKind.Local).AddTicks(6226));
        }
    }
}
