using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class addnewfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Budget_NGN",
                table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition",
                newName: "Budget_Ngn");

            migrationBuilder.AddColumn<string>(
                name: "EvidenceOfInspectionAndUgradeFilename",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvidenceOfInspectionAndUgradePath",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inspection_Regime",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvidenceOfInspectionAndUgradeFilename",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment");

            migrationBuilder.DropColumn(
                name: "EvidenceOfInspectionAndUgradePath",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment");

            migrationBuilder.DropColumn(
                name: "Inspection_Regime",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment");

            migrationBuilder.RenameColumn(
                name: "Budget_Ngn",
                table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition",
                newName: "Budget_NGN");
        }
    }
}
