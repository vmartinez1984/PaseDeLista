using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RollCall.Persistence.Migrations
{
    public partial class Reestructuracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "User",
                newName: "DateRegistration");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "SecurityQuestions",
                newName: "DateRegistration");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Schedule",
                newName: "DateRegistration");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Employee",
                newName: "DateRegistration");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "AssistanceLog",
                newName: "DateRegistration");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Assistance",
                newName: "DateRegistration");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AssistanceLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Assistance",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 30, 16, 57, 9, 98, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 30, 16, 57, 9, 108, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "Schedule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "StartTime", "StopTime" },
                values: new object[] { new DateTime(2022, 6, 30, 16, 57, 9, 110, DateTimeKind.Local).AddTicks(112), new DateTime(2022, 6, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 30, 16, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 30, 16, 57, 9, 110, DateTimeKind.Local).AddTicks(6400));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AssistanceLog");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Assistance");

            migrationBuilder.RenameColumn(
                name: "DateRegistration",
                table: "User",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "DateRegistration",
                table: "SecurityQuestions",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "DateRegistration",
                table: "Schedule",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "DateRegistration",
                table: "Employee",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "DateRegistration",
                table: "AssistanceLog",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "DateRegistration",
                table: "Assistance",
                newName: "RegistrationDate");

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2021, 11, 11, 20, 48, 13, 10, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Config",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2021, 11, 11, 20, 48, 13, 15, DateTimeKind.Local).AddTicks(7017));

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
    }
}
