using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    //public partial class UpdateDrillingOpeModel : Migration
    //{
    //    /// <inheritdoc />
    //    protected override void Up(MigrationBuilder migrationBuilder)
    //    {

    //    }

    //    /// <inheritdoc />
    //    protected override void Down(MigrationBuilder migrationBuilder)
    //    {

    //    }
    //}


    public partial class UpdateDrillingOpeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "spud_date",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                type: "nvarchar(max)",
                nullable: true);
                //oldClrType: typeof(DateTime),
                //oldType: "date",
                //oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Core_Cost_Currency",
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
                name: "Core_Cost_Currency",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            migrationBuilder.DropColumn(
                name: "well_cost_currency",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            migrationBuilder.DropColumn(
                name: "spud_date",
                table: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");
                //type: "date",
                //nullable: true,
                //oldClrType: typeof(string),
                //oldType: "nvarchar(max)",
                //oldNullable: true);
        }
    }


}
