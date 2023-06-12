using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSpud_DatetoDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "Core_Cost_Curreny",
            //    table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
            //    newName: "Core_Cost_Currency");

            migrationBuilder.AlterColumn<DateTime>(
                name: "spud_date",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "Core_Cost_Currency",
            //    table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
            //    newName: "Core_Cost_Curreny");

            migrationBuilder.AlterColumn<string>(
                name: "spud_date",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
