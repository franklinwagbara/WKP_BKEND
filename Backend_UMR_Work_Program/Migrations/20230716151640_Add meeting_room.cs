using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class Addmeeting_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MEETINGROOM",
                table: "EnagementScheduledHistorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MEETINGROOM",
                table: "EnagementScheduledHistorys");
        }
    }
}
