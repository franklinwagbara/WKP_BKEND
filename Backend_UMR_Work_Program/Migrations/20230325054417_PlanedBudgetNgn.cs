using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class PlanedBudgetNgn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actual_Budget_Total_Naira",
                table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME",
                type: "nvarchar(max)",
                nullable: true);

            // migrationBuilder.AddColumn<string>(
            //     name: "Actual_Budget_Total_Naira",
            //     table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME",
            //     type: "nvarchar(max)",
            //     nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Budget_NGN",
                table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actual_Budget_Total_Naira",
                table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME");

            // migrationBuilder.DropColumn(
            //     name: "Actual_Budget_Total_Naira",
            //     table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME");

            migrationBuilder.DropColumn(
                name: "Budget_NGN",
                table: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition");
        }
    }
}
