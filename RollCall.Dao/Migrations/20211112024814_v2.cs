using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RollCall.Persistence.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 11, 20, 48, 13, 10, DateTimeKind.Local).AddTicks(7743), false, "Users", "2" },
                    { 2, new DateTime(2021, 11, 11, 20, 48, 13, 15, DateTimeKind.Local).AddTicks(7017), false, "Employees", "50" }
                });

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RegistrationDate", "StartTime", "StopTime" },
                values: new object[] { new DateTime(2021, 11, 11, 20, 48, 13, 19, DateTimeKind.Local).AddTicks(7922), new DateTime(2021, 11, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 11, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 11, 11, 20, 48, 13, 21, DateTimeKind.Local).AddTicks(3397));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RegistrationDate", "StartTime", "StopTime" },
                values: new object[] { new DateTime(2021, 11, 4, 15, 41, 50, 23, DateTimeKind.Local).AddTicks(4400), new DateTime(2021, 11, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 4, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 11, 4, 15, 41, 50, 28, DateTimeKind.Local).AddTicks(4337));
        }
    }
}
