using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCD2.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_employees_employeeSSN",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_dependents_employees_ESSN",
                table: "dependents");

            migrationBuilder.DropIndex(
                name: "IX_dependents_ESSN",
                table: "dependents");

            migrationBuilder.DropIndex(
                name: "IX_departments_employeeSSN",
                table: "departments");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeSSN",
                table: "dependents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_deptid",
                table: "employees",
                column: "deptid",
                unique: true,
                filter: "[deptid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dependents_EmployeeSSN",
                table: "dependents",
                column: "EmployeeSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_dependents_employees_EmployeeSSN",
                table: "dependents",
                column: "EmployeeSSN",
                principalTable: "employees",
                principalColumn: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_deptid",
                table: "employees",
                column: "deptid",
                principalTable: "departments",
                principalColumn: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dependents_employees_EmployeeSSN",
                table: "dependents");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_deptid",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_deptid",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_dependents_EmployeeSSN",
                table: "dependents");

            migrationBuilder.DropColumn(
                name: "EmployeeSSN",
                table: "dependents");

            migrationBuilder.CreateIndex(
                name: "IX_dependents_ESSN",
                table: "dependents",
                column: "ESSN");

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
                name: "FK_dependents_employees_ESSN",
                table: "dependents",
                column: "ESSN",
                principalTable: "employees",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
