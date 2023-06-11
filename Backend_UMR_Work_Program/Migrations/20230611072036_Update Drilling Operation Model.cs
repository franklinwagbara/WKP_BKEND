using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDrillingOperationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "spud_date",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Core_Cost_Curreny",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "well_cost_currency",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Core_Cost_Curreny",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            migrationBuilder.DropColumn(
                name: "well_cost_currency",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "spud_date",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                type: "date",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
