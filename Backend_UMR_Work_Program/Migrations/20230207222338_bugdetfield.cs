using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    public partial class bugdetfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_BUDGET_OPEXes",
            //    table: "BUDGET_OPEXes");

            //migrationBuilder.RenameTable(
            //    name: "BUDGET_OPEXes",
            //    newName: "BUDGET_OPEX");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Year_of_WP",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Variable_Cost",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Updated_by",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Repairs_and_Maintenance_Cost",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Overheads",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "OmL_Name",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "OmL_ID",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "General_Expenses",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Fixed_Cost",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "Date_Updated",
            //    table: "BUDGET_OPEX",
            //    type: "datetime",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "Date_Created",
            //    table: "BUDGET_OPEX",
            //    type: "datetime",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Created_by",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Companyemail",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Company_ID",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "CompanyName",
            //    table: "BUDGET_OPEX",
            //    type: "varchar(1000)",
            //    unicode: false,
            //    maxLength: 1000,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_BUDGET_OPEX",
            //    table: "BUDGET_OPEX",
            //    column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BUDGET_OPEX",
                table: "BUDGET_OPEX");

            migrationBuilder.RenameTable(
                name: "BUDGET_OPEX",
                newName: "BUDGET_OPEXes");

            migrationBuilder.AlterColumn<string>(
                name: "Year_of_WP",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Variable_Cost",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Updated_by",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Repairs_and_Maintenance_Cost",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Overheads",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OmL_Name",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OmL_ID",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "General_Expenses",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fixed_Cost",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Updated",
                table: "BUDGET_OPEXes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Created",
                table: "BUDGET_OPEXes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Companyemail",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company_ID",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "BUDGET_OPEXes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BUDGET_OPEXes",
                table: "BUDGET_OPEXes",
                column: "Id");
        }
    }
}
