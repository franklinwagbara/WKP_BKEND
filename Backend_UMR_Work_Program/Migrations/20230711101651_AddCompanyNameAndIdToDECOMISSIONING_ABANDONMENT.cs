using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyNameAndIdToDECOMISSIONING_ABANDONMENT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Payments_PaymentType_TypeOfPaymentId",
            //    table: "Payments");

            //migrationBuilder.DropTable(
            //    name: "PaymentType");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Currency",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "FileName",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "FilePath",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsConfirmed",
            //    table: "Payments",
            //    type: "bit",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "OrderId",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PaymentEvidenceFileName",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PaymentEvidenceFilePath",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "RemitaRequest",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "RemitaResponse",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "ServiceCharge",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "COMPANY_ID",
                table: "DECOMMISSIONING_ABANDONMENTs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "DECOMMISSIONING_ABANDONMENTs",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "ActionByCompany",
            //    table: "ApplicationDeskHistories",
            //    type: "bit",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "CompanyId",
            //    table: "ApplicationDeskHistories",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "isPublic",
            //    table: "ApplicationDeskHistories",
            //    type: "bit",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "AccountDesks",
            //    columns: table => new
            //    {
            //        AccountDeskID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProcessID = table.Column<int>(type: "int", nullable: true),
            //        AppId = table.Column<int>(type: "int", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LastJobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ProcessStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        StaffID = table.Column<int>(type: "int", nullable: false),
            //        PaymentId = table.Column<int>(type: "int", nullable: false),
            //        isApproved = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AccountDesks", x => x.AccountDeskID);
            //        table.ForeignKey(
            //            name: "FK_AccountDesks_Payments_PaymentId",
            //            column: x => x.PaymentId,
            //            principalTable: "Payments",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AccountDesks_staff_StaffID",
            //            column: x => x.StaffID,
            //            principalTable: "staff",
            //            principalColumn: "StaffID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Fees",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AmountNGN = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AmountUSD = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        TypeOfPaymentId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Fees", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Fees_TypeOfPayments_TypeOfPaymentId",
            //            column: x => x.TypeOfPaymentId,
            //            principalTable: "TypeOfPayments",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LateSubmission",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Late = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LateSubmission", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ReturnedApplications",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AppId = table.Column<int>(type: "int", nullable: false),
            //        Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        StaffId = table.Column<int>(type: "int", nullable: false),
            //        SelectedTables = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ReturnedApplications", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ReturnedApplications_Applications_AppId",
            //            column: x => x.AppId,
            //            principalTable: "Applications",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ReturnedApplications_staff_StaffId",
            //            column: x => x.StaffId,
            //            principalTable: "staff",
            //            principalColumn: "StaffID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_MyDesks_StaffID",
            //    table: "MyDesks",
            //    column: "StaffID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Applications_CompanyID",
            //    table: "Applications",
            //    column: "CompanyID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Applications_ConcessionID",
            //    table: "Applications",
            //    column: "ConcessionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Applications_FieldID",
            //    table: "Applications",
            //    column: "FieldID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationDeskHistories_CompanyId",
            //    table: "ApplicationDeskHistories",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ApplicationDeskHistories_StaffID",
            //    table: "ApplicationDeskHistories",
            //    column: "StaffID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AccountDesks_PaymentId",
            //    table: "AccountDesks",
            //    column: "PaymentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AccountDesks_StaffID",
            //    table: "AccountDesks",
            //    column: "StaffID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Fees_TypeOfPaymentId",
            //    table: "Fees",
            //    column: "TypeOfPaymentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ReturnedApplications_AppId",
            //    table: "ReturnedApplications",
            //    column: "AppId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ReturnedApplications_StaffId",
            //    table: "ReturnedApplications",
            //    column: "StaffId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ApplicationDeskHistories_ADMIN_COMPANY_INFORMATION_CompanyId",
            //    table: "ApplicationDeskHistories",
            //    column: "CompanyId",
            //    principalTable: "ADMIN_COMPANY_INFORMATION",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ApplicationDeskHistories_staff_StaffID",
            //    table: "ApplicationDeskHistories",
            //    column: "StaffID",
            //    principalTable: "staff",
            //    principalColumn: "StaffID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Applications_ADMIN_COMPANY_INFORMATION_CompanyID",
            //    table: "Applications",
            //    column: "CompanyID",
            //    principalTable: "ADMIN_COMPANY_INFORMATION",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Applications_ADMIN_CONCESSIONS_INFORMATION_ConcessionID",
            //    table: "Applications",
            //    column: "ConcessionID",
            //    principalTable: "ADMIN_CONCESSIONS_INFORMATION",
            //    principalColumn: "Consession_Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Applications_COMPANY_FIELDS_FieldID",
            //    table: "Applications",
            //    column: "FieldID",
            //    principalTable: "COMPANY_FIELDS",
            //    principalColumn: "Field_ID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MyDesks_staff_StaffID",
            //    table: "MyDesks",
            //    column: "StaffID",
            //    principalTable: "staff",
            //    principalColumn: "StaffID",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Payments_TypeOfPayments_TypeOfPaymentId",
            //    table: "Payments",
            //    column: "TypeOfPaymentId",
            //    principalTable: "TypeOfPayments",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ApplicationDeskHistories_ADMIN_COMPANY_INFORMATION_CompanyId",
            //    table: "ApplicationDeskHistories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ApplicationDeskHistories_staff_StaffID",
            //    table: "ApplicationDeskHistories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Applications_ADMIN_COMPANY_INFORMATION_CompanyID",
            //    table: "Applications");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Applications_ADMIN_CONCESSIONS_INFORMATION_ConcessionID",
            //    table: "Applications");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Applications_COMPANY_FIELDS_FieldID",
            //    table: "Applications");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_MyDesks_staff_StaffID",
            //    table: "MyDesks");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Payments_TypeOfPayments_TypeOfPaymentId",
            //    table: "Payments");

            //migrationBuilder.DropTable(
            //    name: "AccountDesks");

            //migrationBuilder.DropTable(
            //    name: "Fees");

            //migrationBuilder.DropTable(
            //    name: "LateSubmission");

            //migrationBuilder.DropTable(
            //    name: "ReturnedApplications");

            //migrationBuilder.DropIndex(
            //    name: "IX_MyDesks_StaffID",
            //    table: "MyDesks");

            //migrationBuilder.DropIndex(
            //    name: "IX_Applications_CompanyID",
            //    table: "Applications");

            //migrationBuilder.DropIndex(
            //    name: "IX_Applications_ConcessionID",
            //    table: "Applications");

            //migrationBuilder.DropIndex(
            //    name: "IX_Applications_FieldID",
            //    table: "Applications");

            //migrationBuilder.DropIndex(
            //    name: "IX_ApplicationDeskHistories_CompanyId",
            //    table: "ApplicationDeskHistories");

            //migrationBuilder.DropIndex(
            //    name: "IX_ApplicationDeskHistories_StaffID",
            //    table: "ApplicationDeskHistories");

            //migrationBuilder.DropColumn(
            //    name: "FileName",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "FilePath",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "IsConfirmed",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "OrderId",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "PaymentEvidenceFileName",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "PaymentEvidenceFilePath",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "RemitaRequest",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "RemitaResponse",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "ServiceCharge",
            //    table: "Payments");

            migrationBuilder.DropColumn(
                name: "COMPANY_ID",
                table: "DECOMMISSIONING_ABANDONMENTs");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "DECOMMISSIONING_ABANDONMENTs");

            //migrationBuilder.DropColumn(
            //    name: "ActionByCompany",
            //    table: "ApplicationDeskHistories");

            //migrationBuilder.DropColumn(
            //    name: "CompanyId",
            //    table: "ApplicationDeskHistories");

            //migrationBuilder.DropColumn(
            //    name: "isPublic",
            //    table: "ApplicationDeskHistories");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Currency",
            //    table: "Payments",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.CreateTable(
            //    name: "PaymentType",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentType", x => x.Id);
            //    });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Payments_PaymentType_TypeOfPaymentId",
            //    table: "Payments",
            //    column: "TypeOfPaymentId",
            //    principalTable: "PaymentType",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
