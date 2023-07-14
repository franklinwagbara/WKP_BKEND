using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class AddEnagerr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adminAproved",
                table: "ADMIN_DATETIME_PRESENTATION");

            migrationBuilder.DropColumn(
                name: "companyAproved",
                table: "ADMIN_DATETIME_PRESENTATION");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "adminAproved",
                table: "ADMIN_DATETIME_PRESENTATION",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "companyAproved",
                table: "ADMIN_DATETIME_PRESENTATION",
                type: "bit",
                nullable: true);
        }
    }
}
