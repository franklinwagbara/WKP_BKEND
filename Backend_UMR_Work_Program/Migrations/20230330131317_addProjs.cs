using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class addProjs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facility_Name",
                table: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facility_Type",
                table: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proposed_Projects",
                table: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facility_Name",
                table: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS");

            migrationBuilder.DropColumn(
                name: "Facility_Type",
                table: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS");

            migrationBuilder.DropColumn(
                name: "Proposed_Projects",
                table: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS");
        }
    }
}
