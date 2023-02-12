using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    public partial class Step4Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Field_ID",
                table: "HSE_WASTE_MANAGEMENT_DZs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_by",
                table: "HSE_REMEDIATION_FUND",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Created",
                table: "HSE_REMEDIATION_FUND",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Updated",
                table: "HSE_REMEDIATION_FUND",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Field_ID",
                table: "HSE_REMEDIATION_FUND",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_by",
                table: "HSE_REMEDIATION_FUND",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Field_ID",
                table: "HSE_POINT_SOURCE_REGISTRATION",
                type: "int",
                nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Field_ID",
            //    table: "BUDGET_OPEXes",
            //    type: "int",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Field_ID",
                table: "BUDGET_CAPEX",
                type: "int",
                nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_RESERVES_UPDATES_DEPLETION_RATE",
            //    table: "RESERVES_UPDATES_DEPLETION_RATE",
            //    column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_RESERVES_UPDATES_DEPLETION_RATE",
            //    table: "RESERVES_UPDATES_DEPLETION_RATE");

            migrationBuilder.DropColumn(
                name: "Field_ID",
                table: "HSE_WASTE_MANAGEMENT_DZs");

            migrationBuilder.DropColumn(
                name: "Created_by",
                table: "HSE_REMEDIATION_FUND");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "HSE_REMEDIATION_FUND");

            migrationBuilder.DropColumn(
                name: "Date_Updated",
                table: "HSE_REMEDIATION_FUND");

            migrationBuilder.DropColumn(
                name: "Field_ID",
                table: "HSE_REMEDIATION_FUND");

            migrationBuilder.DropColumn(
                name: "Updated_by",
                table: "HSE_REMEDIATION_FUND");

            migrationBuilder.DropColumn(
                name: "Field_ID",
                table: "HSE_POINT_SOURCE_REGISTRATION");

            //migrationBuilder.DropColumn(
            //    name: "Field_ID",
            //    table: "BUDGET_OPEXes");

            migrationBuilder.DropColumn(
                name: "Field_ID",
                table: "BUDGET_CAPEX");
        }
    }
}
