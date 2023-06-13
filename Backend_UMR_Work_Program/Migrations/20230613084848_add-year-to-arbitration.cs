using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class addyeartoarbitration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Table_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Step",
                table: "Table_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSection",
                table: "Table_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "LEGAL_ARBITRATION",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OSCPUploadName",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OSCPUploadPath",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eMUploadName",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eMUploadPath",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Section",
                table: "Table_Details");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "Table_Details");

            migrationBuilder.DropColumn(
                name: "SubSection",
                table: "Table_Details");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "LEGAL_ARBITRATION");

            migrationBuilder.DropColumn(
                name: "OSCPUploadName",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN");

            migrationBuilder.DropColumn(
                name: "OSCPUploadPath",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN");

            migrationBuilder.DropColumn(
                name: "eMUploadName",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN");

            migrationBuilder.DropColumn(
                name: "eMUploadPath",
                table: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN");
        }
    }
}
