using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCD2.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Department2Number",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deptid",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeeSSN",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_Department2Number",
                table: "employees",
                column: "Department2Number");

            migrationBuilder.CreateIndex(
                name: "IX_departments_employeeSSN",
                table: "departments",
                column: "employeeSSN",
                unique: true,
                filter: "[employeeSSN] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_employees_employeeSSN",
                table: "departments",
                column: "employeeSSN",
                principalTable: "employees",
                principalColumn: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_Department2Number",
                table: "employees",
                column: "Department2Number",
                principalTable: "departments",
                principalColumn: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_employees_employeeSSN",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_Department2Number",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_Department2Number",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_departments_employeeSSN",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "Department2Number",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "deptid",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "employeeSSN",
                table: "departments");
        }
    }
}
