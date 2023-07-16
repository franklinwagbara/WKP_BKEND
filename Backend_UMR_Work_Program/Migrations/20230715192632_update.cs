using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "AppId",
            //    table: "ApplicationSBUApproval",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AddColumn<int>(
            //    name: "SBUID",
            //    table: "ApplicationSBUApproval",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_staff_Staff_SBU",
            //    table: "staff",
            //    column: "Staff_SBU");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationSBUApproval_SBUID",
            //    table: "ApplicationSBUApproval",
            //    column: "SBUID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationSBUApproval_StaffID",
            //    table: "ApplicationSBUApproval",
            //    column: "StaffID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ApplicationSBUApproval_StrategicBusinessUnits_SBUID",
            //    table: "ApplicationSBUApproval",
            //    column: "SBUID",
            //    principalTable: "StrategicBusinessUnits",
            //    principalColumn: "Id");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_ApplicationSBUApproval_staff_StaffID",
        //        table: "ApplicationSBUApproval",
        //        column: "StaffID",
        //        principalTable: "staff",
        //        principalColumn: "StaffID");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_staff_StrategicBusinessUnits_Staff_SBU",
        //        table: "staff",
        //        column: "Staff_SBU",
        //        principalTable: "StrategicBusinessUnits",
        //        principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ApplicationSBUApproval_StrategicBusinessUnits_SBUID",
            //    table: "ApplicationSBUApproval");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ApplicationSBUApproval_staff_StaffID",
            //    table: "ApplicationSBUApproval");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_staff_StrategicBusinessUnits_Staff_SBU",
            //    table: "staff");

            //migrationBuilder.DropIndex(
            //    name: "IX_staff_Staff_SBU",
            //    table: "staff");

            //migrationBuilder.DropIndex(
            //    name: "IX_ApplicationSBUApproval_SBUID",
            //    table: "ApplicationSBUApproval");

            //migrationBuilder.DropIndex(
            //    name: "IX_ApplicationSBUApproval_StaffID",
            //    table: "ApplicationSBUApproval");

            //migrationBuilder.DropColumn(
            //    name: "SBUID",
            //    table: "ApplicationSBUApproval");

            //migrationBuilder.AlterColumn<int>(
            //    name: "AppId",
            //    table: "ApplicationSBUApproval",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);
        }
    }
}
