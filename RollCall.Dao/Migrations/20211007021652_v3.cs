using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RollCall.Persistence.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SecurityQuestions",
                newName: "EmployeeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_EmployeeId",
                table: "SecurityQuestions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityQuestions_Employee_EmployeeId",
                table: "SecurityQuestions",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityQuestions_Employee_EmployeeId",
                table: "SecurityQuestions");

            migrationBuilder.DropIndex(
                name: "IX_SecurityQuestions_EmployeeId",
                table: "SecurityQuestions");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "SecurityQuestions",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 10, 2, 19, 19, 18, 589, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2021, 10, 2, 19, 19, 18, 598, DateTimeKind.Local).AddTicks(7011));
        }
    }
}
