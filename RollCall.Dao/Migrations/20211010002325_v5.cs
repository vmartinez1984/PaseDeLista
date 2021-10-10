using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RollCall.Persistence.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Employee_EmployeeId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EmployeeId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rol",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DischargeDate",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "Name", "RegistrationDate" },
                values: new object[] { "Admin", "Admin", new DateTime(2021, 10, 9, 19, 23, 24, 382, DateTimeKind.Local).AddTicks(6898) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DischargeDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AreaId", "DischargeDate", "EmployeeNumber", "IsActive", "LastName", "Name", "PhotoInBase64", "RegistrationDate", "ScheduleId" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "", "Administrador", "", new DateTime(2021, 10, 6, 21, 19, 9, 920, DateTimeKind.Local).AddTicks(9988), null });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[] { 3, null, true, "Empleado" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmployeeId", "RegistrationDate" },
                values: new object[] { 1, new DateTime(2021, 10, 6, 21, 19, 9, 924, DateTimeKind.Local).AddTicks(4702) });

            migrationBuilder.CreateIndex(
                name: "IX_User_EmployeeId",
                table: "User",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employee_EmployeeId",
                table: "User",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
