using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mapping_Inhiritance.Migrations
{
    public partial class TPCCMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeBase",
                table: "EmployeeBase");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EmployeeBase");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "EmployeeBase");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EmployeeBase");

            migrationBuilder.RenameTable(
                name: "EmployeeBase",
                newName: "PartTimeEmployees");

            migrationBuilder.AlterColumn<int>(
                name: "HourRate",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHours",
                table: "PartTimeEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartTimeEmployees",
                table: "PartTimeEmployees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FullTimeEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeEmployees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartTimeEmployees",
                table: "PartTimeEmployees");

            migrationBuilder.RenameTable(
                name: "PartTimeEmployees",
                newName: "EmployeeBase");

            migrationBuilder.AlterColumn<int>(
                name: "HourRate",
                table: "EmployeeBase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountOfHours",
                table: "EmployeeBase",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EmployeeBase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "EmployeeBase",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "EmployeeBase",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeBase",
                table: "EmployeeBase",
                column: "Id");
        }
    }
}
