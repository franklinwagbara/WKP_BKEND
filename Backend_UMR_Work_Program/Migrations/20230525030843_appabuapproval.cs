using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class appabuapproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Inspection_Regime",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Any_subsisting_orders_of_court",
                table: "LEGAL_LITIGATION",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_of_the_court",
                table: "LEGAL_LITIGATION",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "evidenceOfPreviousYearsPaymentFilename",
                table: "HSE_REMEDIATION_FUND",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "evidenceOfPreviousYearsPaymentPath",
                table: "HSE_REMEDIATION_FUND",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationSBUApproval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AppAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeskID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSBUApproval", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationSBUApproval");

            migrationBuilder.DropColumn(
                name: "Any_subsisting_orders_of_court",
                table: "LEGAL_LITIGATION");

            migrationBuilder.DropColumn(
                name: "Order_of_the_court",
                table: "LEGAL_LITIGATION");

            migrationBuilder.DropColumn(
                name: "evidenceOfPreviousYearsPaymentFilename",
                table: "HSE_REMEDIATION_FUND");

            migrationBuilder.DropColumn(
                name: "evidenceOfPreviousYearsPaymentPath",
                table: "HSE_REMEDIATION_FUND");

            migrationBuilder.AlterColumn<int>(
                name: "Inspection_Regime",
                table: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
