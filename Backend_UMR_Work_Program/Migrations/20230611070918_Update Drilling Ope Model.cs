using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_UMR_Work_Program.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDrillingOpeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualExpenditure",
                columns: table => new
                {
                    Actual_ExpenditureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direct_Exploration_Budget = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Equivalent_Naira_Dollar_Component = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Other_Activity_Budget = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UserEmail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UserNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualExpenditure", x => x.Actual_ExpenditureId);
                });

            migrationBuilder.CreateTable(
                name: "ActualProposed_Year",
                columns: table => new
                {
                    ActualProposedYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualProposedYear = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualProposed_Year", x => x.ActualProposedYearId);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_BUDGET_CAPEX_OPEX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_BUDGET_CAPEX_OPEX", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CATEGORIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CATEGORIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CHAIRPERSON",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHAIRPERSON = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CHAIRPERSONEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CHAIRPERSON", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_COMPANY_CODE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    GUID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IsActive = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserNumber = table.Column<int>(type: "int", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_COMPANY_CODE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_COMPANY_DETAILS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Address_of_Company = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Name_of_MD_CEO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Phone_NO_of_MD_CEO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Contact_Person = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Phone_No = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Email_Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Alternate_Contact_Person = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Phone_No_alt = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Email_Address_alt = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FLAG = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_Created = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    check_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_COMPANY_DETAILS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_COMPANY_INFORMATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PASSWORDS = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS_ = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FLAG_PASSWORD_CHANGE = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CATEGORY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DESIGNATION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PHONE_NO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DELETED_STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_BY = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DELETED_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FLAG1 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FLAG2 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    UPDATED_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EMAIL_REMARK = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    ELPS_ID = table.Column<int>(type: "int", nullable: true),
                    CompanyAddress = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_COMPANY_INFORMATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_COMPANY_INFORMATION_AUDIT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PASSWORDS = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS_ = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FLAG_PASSWORD_CHANGE = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CATEGORY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DESIGNATION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PHONE_NO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DELETED_STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_BY = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DELETED_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FLAG1 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FLAG2 = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    UPDATED_BY = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    UPDATED_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_COMPANY_INFORMATION_AUDIT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_COMPANY_INFORMATION_old_18052020",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PASSWORDS = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS_ = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FLAG_PASSWORD_CHANGE = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CATEGORY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DESIGNATION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PHONE_NO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_COMPANY_INFORMATION_old_18052020", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_COMPLIANCE_INDEX_TABLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Divisions = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Penalty_Factor_for_Warning = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Number_of_Occurrence_of_Warnings = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Penalty_Factor_for_Sanction = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Number_of_Occurrence_of_Sanctions = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Penalty_Factor_for_Waivers = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Number_of_Occurrence_of_Waivers = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Compliance_index_for_each_division = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_COMPLIANCE_INDEX_TABLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CONCESSION_STATUS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_ = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Status_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CONCESSION_STATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CONCESSIONS_INFORMATION",
                columns: table => new
                {
                    Consession_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    COMPANY_EMAIL = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Concession_Unique_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Equity_distribution = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Concession_Held = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Area = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year_of_Grant_Award = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Date_of_Expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    Geological_location = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Comment = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Status_ = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag1 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag2 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    submitted = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    OPEN_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CLOSE_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_BY = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DELETED_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EMAIL_REMARK = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    ConcessionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Field_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CONCESSIONS_INFORMATIONs", x => x.Consession_Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_AUDIT",
                columns: table => new
                {
                    Consession_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Equity_distribution = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Concession_Held = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Area = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year_of_Grant_Award = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Date_of_Expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    Geological_location = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Comment = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Status_ = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag1 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag2 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_EMAIL = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    submitted = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Concession_Unique_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OPEN_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CLOSE_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_BY = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DELETED_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CONCESSIONS_INFORMATION_AUDIT", x => x.Consession_Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_BK_23112021",
                columns: table => new
                {
                    Consession_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Equity_distribution = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Concession_Held = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Area = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year_of_Grant_Award = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Date_of_Expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    Geological_location = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Comment = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Status_ = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag1 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag2 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_EMAIL = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    submitted = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Concession_Unique_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OPEN_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CLOSE_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DELETED_BY = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DELETED_DATE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EMAIL_REMARK = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CONCESSIONS_INFORMATION_", x => x.Consession_Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_HISTORY",
                columns: table => new
                {
                    Consession_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equity_distribution = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Concession_Held = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Area = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_Grant_Award = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_of_Expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    Geological_location = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Comment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Status_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Flag1 = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Flag2 = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_EMAIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CONCESSIONS_INFORMATION_HISTORY", x => x.Consession_Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_old_18052020",
                columns: table => new
                {
                    Consession_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Equity_distribution = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Concession_Held = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Area = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year_of_Grant_Award = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Date_of_Expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    Geological_location = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Comment = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Status_ = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag1 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Flag2 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_EMAIL = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    submitted = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_CONCESSIONS_INFORMATION", x => x.Consession_Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_DATETIME_PRESENTATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANYNAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PRESENTED = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    COMPANYEMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MEETINGROOM = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CHAIRPERSON = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    SCRIBE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    YEAR = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DATETIME_PRESENTATION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLOSE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Submitted = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wp_date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wp_time = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CHAIRPERSONEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    SCRIBEEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    MOM = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    MOM_UPLOAD_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    MOM_UPLOADED_BY = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DATE_TIME_TEXT = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DIVISION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PHONE_NO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LAST_RUN_DATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EMAIL_REMARK = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DAYS_TO_GO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LAST_RUN_TIME = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Created_BY_COMPANY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_DATETIME_PRESENTATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_DEVELOPMENT_PLAN_STATUS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_DIVISION_REP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DIVISION = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DIVISIONEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_DIVISION_REP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_DIVISION_REP_LIST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DIV_REP_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    DIV_REP_EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DIVISION = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_DIVISIONAL_REPRESENTATIVE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANYNAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PRESENTED = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    COMPANYEMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MEETINGROOM = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CHAIRPERSON = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    SCRIBE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    YEAR = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DATETIME_PRESENTATION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLOSE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Submitted = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wp_date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wp_time = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CHAIRPERSONEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    SCRIBEEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    DIV_REP_NAME = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DIV_REP_DIV = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DIV_REP_EMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_DIVISIONAL_REPRESENTATIVE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_DIVISIONAL_REPS_PRESENTATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANYNAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PRESENTED = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    COMPANYEMAIL = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MEETINGROOM = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CHAIRPERSON = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    SCRIBE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    STATUS = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    YEAR = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DATETIME_PRESENTATION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLOSE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATED_BY = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Submitted = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wp_date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wp_time = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CHAIRPERSONEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    SCRIBEEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    MOM = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    MOM_UPLOAD_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    MOM_UPLOADED_BY = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DATE_TIME_TEXT = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DIVISION = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PHONE_NO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LAST_RUN_DATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LAST_RUN_TIME = table.Column<DateTime>(type: "datetime", nullable: true),
                    EMAIL_REMARK = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DAYS_TO_GO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    REPRESENTATIVE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    REPRESENTATIVE_EMAIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_DIVISIONAL_REPS_PRESENTATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_EMAIL_DAYS",
                columns: table => new
                {
                    SN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAYS_ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email_ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Deleted_Date = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Deleted_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_ENVIROMENTAL_STUDIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_ENVIROMENTAL_STUDIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOING",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOING", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_ENVIRONMENTAL_STUDY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_ENVIRONMENTAL_STUDY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_FEILDDEVELOPMENTPLAN_WELLORGAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsActive = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_FIVE_YEAR_TREND",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_FIVE_YEAR_TREND", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_GASPRODUCTION_UTILIZED_MMSCF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsActive = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_HSE_CONDITION_OF_EQUIPMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_HSE_CONDITION_OF_EQUIPMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_HSE_OSP REGISTRATIONS_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_HSE_OSP REGISTRATIONS_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_HSE_OSP_REGISTRATIONS_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_HSE_OSP_REGISTRATIONS_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_INSPECTION_MAINTENANCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_INSPECTION_MAINTENANCE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_LIST_OF_OMLS_OPLS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_LIST_OF_OMLS_OPLS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_LITIGATION_JURISDICTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsActive = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_MEETING_ROOM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEETING_ROOM = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_MEETING_ROOM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_MONTHS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Months = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_MONTHS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_ONGOING_COMPLETED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PERFOMANCE_INDEX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INDICATOR = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    INDEX_TYPE = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Graduation_Scale = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Weight = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CONCESSIONTYPE = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PERFOMANCE_INDEX", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PRESENTATION_CATEGORIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PRESENTATION_CATEGORIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PRESENTATION_TIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pt = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PRESENTATION_TIME", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_water",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_water", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_ZONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PRODUCED_WATER_MANAGEMENT_ZONE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_PUBLIC_HOLIDAY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    public_holidays = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_PUBLIC_HOLIDAY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_QUARTER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_QUARTER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_REASON_FOR_ADDITION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REASON_FOR_ADDITION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_REASON_FOR_ADDITION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_REASON_FOR_DECLINE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REASON_FOR_DECLINE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_REASON_FOR_DECLINE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_SCHEDULED_STATUS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCHEDULED_STATUS = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_SCHEDULED_STATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_SCRIBE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCRIBE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    SCRIBEEMAIL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_SCRIBE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_STRATEGIC_PLANS_ON_COMPANY_BASIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_STRATEGIC_PLANS_ON_COMPANY_BASIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_SUBMISSION_WINDOW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPEN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLOSE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    Open_date_only = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Open_time_only = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Close_date_only = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Close_time_only = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUS_ = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FLAG_PASSWORD_CHANGE = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_SUBMISSION_WINDOW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_Terrain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_Terrain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_TRAINING_LOCAL_CONTENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_TRAINING_LOCAL_CONTENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_TRAINING_NIGERIA_CONTENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_TRAINING_NIGERIA_CONTENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_TYPE_OF_TEST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TESTTYPE = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    TEST_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_TYPE_OF_TEST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WASTE_MANAGEMENT_FACILITY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WASTE_MANAGEMENT_FACILITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WELL_CATEGORIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    welltype = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WELL_CATEGORIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WELL_Trajectory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    welltype = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WELL_Trajectory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WELL_TYPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    welltype = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WELL_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WORK_PROGRAM_REPORT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report_Content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Report_Content_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WORK_PROGRAM_REPORT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WORK_PROGRAM_REPORT_History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report_Content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Report_Content_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WORK_PROGRAM_REPORT_History", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WP_PENALTIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NO_SHOW = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    NO_SUBMISSION = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WP_PENALTIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WP_PENALTIES_AUDIT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NO_SHOW = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    NO_SUBMISSION = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WP_PENALTIES_AUDIT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WP_START_END_DATE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    end_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WP_START_END_DATE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WP_START_END_DATE_AUDIT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    end_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WP_START_END_DATE_AUDIT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WP_START_END_DATE_DATA_UPLOAD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    end_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WP_START_END_DATE_DATA_UPLOAD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    end_date = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_YEAR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_YEAR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ADMIN_YES_NO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categories = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    categories_Desc = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN_YES_NO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FriendlyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDeskHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    AppAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TriggeredBySBU = table.Column<int>(type: "int", nullable: true),
                    TriggeredByRole = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetedToSBU = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDeskHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDocument",
                columns: table => new
                {
                    AppDocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ElpsDocTypeID = table.Column<int>(type: "int", nullable: false),
                    DocName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    DocType = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDocuments_UT", x => x.AppDocID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationProccesses",
                columns: table => new
                {
                    ProccessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    SBU_ID = table.Column<int>(type: "int", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    TriggeredBySBU = table.Column<int>(type: "int", nullable: true),
                    TriggeredByRole = table.Column<int>(type: "int", nullable: true),
                    TargetedToSBU = table.Column<int>(type: "int", nullable: true),
                    TargetedToRole = table.Column<int>(type: "int", nullable: true),
                    ProcessAction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProcessStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProccess_", x => x.ProccessID);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ConcessionID = table.Column<int>(type: "int", nullable: true),
                    FieldID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    YearOfWKP = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PaymentStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CurrentDesk = table.Column<int>(type: "int", nullable: true),
                    Submitted = table.Column<bool>(type: "bit", nullable: true),
                    ApprovalRef = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CurrentUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowStageId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Appraisal_Drilling",
                columns: table => new
                {
                    Appraisal_DrillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Budget_Allocation = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appraisal_Drilling", x => x.Appraisal_DrillingId);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    AuditLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditAction = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserID = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.AuditLogID);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_ACTUAL_EXPENDITURE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Budget_for_Direct_Exploration_and_Production_Activities = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_for_other_Activities = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equivalent_Naira_and_Dollar_Component_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Budget_for_Direct_Exploration_and_Production_Activities_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budget_for_Direct_Exploration_and_Production_Activities_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budget_for_other_Activities_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budget_for_other_Activities_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Equivalent_Naira_and_Dollar_Component_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Equivalent_Naira_and_Dollar_Component_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_ACTUAL_EXPENDITURE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_CAPEX",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OmL_Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    OmL_ID = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Company_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Acquisition = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Processing = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Reprocessing = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    Exploratory_Well_Drilling = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Appraisal_Well_Drilling = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Development_Well_Drilling = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Workover_Operations = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Completions = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Flowlines = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Pipelines = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Generators = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Turbines_Compressors = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Buildings = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Other_Equipment = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Civil_Works = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Other_Costs = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_CAPEX", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_CAPEX_OPEX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Item_Type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Item_Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    naira = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    dollar = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Dollar_equivalent = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    remarks = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_CAPEX_OPEX", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_OPEX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OmL_Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    OmL_ID = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Company_ID = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Variable_Cost = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Fixed_Cost = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Overheads = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Repairs_and_Maintenance_Cost = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    General_Expenses = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_OPEX", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DEVELOPMENT_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DEVELOPMENT_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    WORKOVER_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    WORKOVER_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPLETION_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPLETION_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACQUISITION_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ACQUISITION_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROCESSING_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROCESSING_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    REPROCESSING_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    REPROCESSING_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    EXPLORATION_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    EXPLORATION_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    APPRAISAL_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    APPRAISAL_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CONCEPT_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CONCEPT_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FEED_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FEED_COST_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DETAILED_ENGINEERING_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DETAILED_ENGINEERING_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROCUREMENT_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROCUREMENT_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CONSTRUCTION_FABRICATION_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CONSTRUCTION_FABRICATION_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    INSTALLATION_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    INSTALLATION_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    UPGRADE_MAINTENANCE_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    UPGRADE_MAINTENANCE_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DECOMMISSIONING_ABANDONMENT = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_PERFORMANCE_PRODUCTION_COST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DIRECT_COST_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DIRECT_COST_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    INDIRECT_COST_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    INDIRECT_COST_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_PERFORMANCE_PRODUCTION_COST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year_of_Proposal = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_for_Direct_Exploration_and_Production_Activities_Naira = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_for_Direct_Exploration_and_Production_Activities_Dollars = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_for_other_Activities_Naira = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_for_other_Activities_Dollars = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Total_Company_Expenditure_Dollars = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetProposal",
                columns: table => new
                {
                    Budget_ProposalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direct_Exploration_Budget = table.Column<long>(type: "bigint", nullable: true),
                    Other_Activity_Budget = table.Column<long>(type: "bigint", nullable: true),
                    Total_Company_Expenditure = table.Column<long>(type: "bigint", nullable: true),
                    Oil_Gas_Facility_Maintenance = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetProposal", x => x.Budget_ProposalId);
                });

            migrationBuilder.CreateTable(
                name: "Class_Table",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Table", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_CONCESSIONS_FIELDS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Concession_Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Field_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_CONCESSIONS_FIELDS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_FIELDS",
                columns: table => new
                {
                    Field_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Concession_ID = table.Column<int>(type: "int", nullable: true),
                    Field_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Field_Location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_FIELDS", x => x.Field_ID);
                });

            migrationBuilder.CreateTable(
                name: "CompletionJobs",
                columns: table => new
                {
                    Completion_JobsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Budget_Allocation = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletionJobs", x => x.Completion_JobsId);
                });

            migrationBuilder.CreateTable(
                name: "CONCESSION_SITUATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Concession_Held = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Area = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    No_of_discovered_field = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    No_of_field_producing = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Name_of_Company = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equity_distribution = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Geological_location = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Has_Signature_Bonus_been_paid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    If_No_why_sig = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_the_Concession_Rentals_been_paid = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    If_No_why_concession = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Is_there_an_application_for_renewal = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    If_No_why_renewal = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Budget_actual_for_license_or_lease = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    proposed_budget_for_each_license_lease = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Five_year_proposal = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Did_you_meet_the_minimum_work_programme = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_of_Grant_Expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_of_Expiration = table.Column<DateTime>(type: "datetime", nullable: true),
                    How_Much_Signature_Bonus_have_been_paid_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    How_Much_Concession_Rental_have_been_paid_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    How_Much_Renewal_Bonus_have_been_paid_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Has_Assignment_of_Interest_Fee_been_paid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    relinquishment_retention = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    area_in_square_meter_based_on_company_records = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    AdminConcession_ID = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONCESSION_SITUATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcessionSituation",
                columns: table => new
                {
                    Concession_situationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concession_Held = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Date_Grant_Expiration = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Area = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nbr_discovered_Field = table.Column<int>(type: "int", nullable: true),
                    Budget_Proposal = table.Column<long>(type: "bigint", nullable: true),
                    Company_Category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Equity_Shares = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nbr_Field_Producing = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcessionSituation", x => x.Concession_situationId);
                });

            migrationBuilder.CreateTable(
                name: "ConcessionSituationTwo",
                columns: table => new
                {
                    ConcessionSituationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ContractType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    SignatureBonus = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    NoSignatureBonusReason = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ConcessionRentals = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    NoConcessionRentalsReason = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ApplicationRenewal = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    NoApplicationRenewalReason = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ActualBudgetCurrentYr = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FiveYrsProposal = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcessionSituationTwo", x => x.ConcessionSituationId);
                });

            migrationBuilder.CreateTable(
                name: "Contract_Type",
                columns: table => new
                {
                    Contract_TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract_Type", x => x.Contract_TypeId);
                });

            migrationBuilder.CreateTable(
                name: "CSR",
                columns: table => new
                {
                    CSR_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MOU_with_Community = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Reason_WithOut_MOU = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    All_MOU_Submitted = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CSR_Projects = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_Spent = table.Column<long>(type: "bigint", nullable: true),
                    Budget = table.Column<long>(type: "bigint", nullable: true),
                    Percentage_Completion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSR", x => x.CSR_Id);
                });

            migrationBuilder.CreateTable(
                name: "Data_Type",
                columns: table => new
                {
                    DataTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data_Type", x => x.DataTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DECOMMISSIONING_ABANDONMENTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OmlId = table.Column<int>(type: "int", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WpYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: true),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalCostUsd = table.Column<double>(type: "float", nullable: false),
                    AnnualObigationUsd = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DECOMMISSIONING_ABANDONMENTs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DecommissioningAbandonment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decommissioning = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Abandonment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Cumulative_DA_Annual_Payment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Accrued_DA_Annual_Payment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CAPEX = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    OPEX = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    ConcessionID = table.Column<int>(type: "int", nullable: true),
                    FieldID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecommissioningAbandonment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Development_And_Productions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FieldHistory = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Do_You_Have_Any_SubsurfacePlan = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Type_Of_SubsurfacePlan = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FiveYears_Projection_Of_Anticipated_Dev_Schemes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Have_You_Submitted_AnnualReseves_BookingStatus = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Do_You_Have_Reserves_Growth_Strategy_Plan = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Number_Of_Shut_In_Wells = table.Column<int>(type: "int", nullable: true),
                    How_Many_ShutIn_Wells_Are_Planned_To_Reactivate = table.Column<int>(type: "int", nullable: true),
                    How_Many_Wells_Do_You_Plan_To_Complete = table.Column<int>(type: "int", nullable: true),
                    How_Many_Wells_Do_You_Plan_To_Abandon = table.Column<int>(type: "int", nullable: true),
                    Number_Of_Well_Interventions_Planned_For_The_Year = table.Column<int>(type: "int", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    ConcessionID = table.Column<int>(type: "int", nullable: true),
                    FieldID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Development_And_Productions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentDrilling",
                columns: table => new
                {
                    Development_DrillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Budget_Allocation = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentDrilling", x => x.Development_DrillingId);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Division_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DivisionName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Division_PK);
                });

            migrationBuilder.CreateTable(
                name: "DRILLING_EACH_WELL_COST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    well_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    well_cost = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QUATER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Surface_cordinates_for_each_well_in_degrees = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DRILLING_EACH_WELL_COST_PROPOSED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    well_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    well_cost = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Surface_cordinates_for_each_well_in_degrees = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QUATER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Drilling_Operations",
                columns: table => new
                {
                    Drilling_OperationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Do_you_have_approval_to_drill = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Comment_drill_approval = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Category_of_wells_drilled = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Actual_no_drilled_current_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Actual_no_drilled_next_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Processing_field_paid = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    No_of_wells_cored = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Any_new_discoveries = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Any_new_discoveries_comment = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Hydrocarbon_counts = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Number_of_exploration_wells_drilled = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Status = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Net_Oil_Gas_Sand = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Cost_of_drilling_foot = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Year_of_WorkProgram = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drilling_Operations", x => x.Drilling_OperationsId);
                });

            migrationBuilder.CreateTable(
                name: "DRILLING_OPERATIONS_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Well_Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_year_Actual_Status_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_year_Actual_Net_Oil_Gas_sand_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_Budget_Allocation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Do_you_have_approval_to_drill = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Give_reasons = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Actual_No_Drilled_in_Current_Year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Proposed_No_Drilled = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Processing_Fees_Paid = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    No_of_wells_cored = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    State_the_field_where_Discovery_was_made = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Any_New_Discoveries = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Hydrocarbon_Counts = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Budeget_Allocation_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budeget_Allocation_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRILLING_OPERATIONS_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Category = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Actual_No_Drilled_in_Current_Year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Proposed_No_Drilled = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Processing_Fees_Paid = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    No_of_wells_cored = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    well_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    well_trajectory = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    spud_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    well_cost = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    well_cost_currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_of_Days_to_Total_Depth = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Well_Status_and_Depth = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    well_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QUATER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Any_New_Discoveries = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Hydrocarbon_Counts = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State_the_field_where_Discovery_was_made = table.Column<string>(type: "varchar(4999)", unicode: false, maxLength: 4999, nullable: true),
                    Core_Cost_USD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Core_Cost_Curreny = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Core_Depth_Interval = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Propose_well_names = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Actual_wells_name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Terrain_Drill = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Water_depth = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    True_vertical_depth = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Depth_refrence = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Rig_type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Rig_Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Target_reservoir = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Surface_cordinates_for_each_well_in_degrees = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Location_name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Proposed_cost_per_well = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Basin = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Measured_depth = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FieldDiscoveryUploadFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    HydrocarbonCountUploadFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Cored = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_Proposed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    WellName = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exploration_Drilling",
                columns: table => new
                {
                    Exploration_DrillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Budget_Allocation = table.Column<long>(type: "bigint", nullable: true),
                    Net_Oil_Gas_Sand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Well_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exploration_Drilling", x => x.Exploration_DrillingId);
                });

            migrationBuilder.CreateTable(
                name: "FACILITIES_PROJECT_PERFORMANCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    List_of_Projects = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Planned_completion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_completion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FLAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    reasonForNoEvidence = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    areThereEvidenceOfDesignSafetyCaseApproval = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidenceOfDesignSafetyCaseApprovalPath = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidenceOfDesignSafetyCaseApprovalFilename = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACILITIES_PROJECT_PERFORMANCE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityConstruction",
                columns: table => new
                {
                    Facility_ConstructionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Capital_Expenditure = table.Column<long>(type: "bigint", nullable: true),
                    Proposed_Capital_Expenditure = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Facility_Calibration = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityConstruction", x => x.Facility_ConstructionId);
                });

            migrationBuilder.CreateTable(
                name: "FIELD_DEVELOPMENT_FIELDS_AND_STATUS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Field_Name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Development_Plan_Status = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Field_Name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Development_Plan_Status = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FIELD_DEVELOPMENT_PLAN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    How_many_fields_have_FDP = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    List_all_the_field_with_FDP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Which_fields_do_you_plan_to_submit_an_FDP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    How_many_fields_have_approved_FDP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Number_of_wells_proposed_in_the_FDP = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    No_of_wells_drilled_in_current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_number_of_wells_from_approved_FDP = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Processing_Fees_paid = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    how_many_fields_in_concession = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Noof_Producing_Fields = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Uploaded_approved_FDP_Document = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Are_they_oil_or_gas_wells = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    FDPDocumentFilename = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELD_DEVELOPMENT_PLAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Proposed_Development_well_name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Field_Name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Oil = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Condensate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functionality",
                columns: table => new
                {
                    FuncId = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MenuId = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Action = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SeqNo = table.Column<byte>(type: "tinyint", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IconName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functionality", x => x.FuncId);
                });

            migrationBuilder.CreateTable(
                name: "GAS_PRODUCTION_ACTIVITIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Current_Actual_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Utilized = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Flared = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Forecast_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    How_many_NAG_fields_have_approved_Gas_FDP = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_wells_drilled_and_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_production_and_flare_historical_performance = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_plant_capacity = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Ongoing_and_planned_Gas_plant_projects = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Domestic_gas_obligation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Planned_projects_for_domestic_supply = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_Field_Development_Plan_Approval = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_wells_drilled_and_wells_planned = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    AG_NAG_and_Condensate_in_place_volumes_and_Reserves_Reserves_for_reservoirs_and_Fields = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Maturation_plans_for_leads_and_prospects_leading_to_reserves_growth = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_production_status_for_all_Gas_and_condensate_Reservoirs = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_gas_production_utilisation_and_Flare_volumes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Sources_of_Gas_utilisation_should_be_clearly_stated = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_Production_and_flare_historical_Performance_5_years_Performance_and_Plan = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Substantiate_flare_reduction_methods_with_projects = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Annotate_clearly_reasons_for_increase_or_reduction_in_Gas_production_utilisation_and_flare_profiles = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_pressures_for_Gas_and_condensate_Reservoirs = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Production_forecast_for_all_Gas_and_condensate_reservoirs = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_compositional_Analysis = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Feed_gas_Volumes_into_the_Processing_Facility = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Gas_Plant_Capacity_NEW = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Plant_Utilization_Capacity = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Plant_maintenance_activities = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ongoing_and_planned_Gas_plant_projects_NEW = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    LNG_and_NGLs_Production_forecast = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Custody_Transfer_status = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    License_Renewal_Status_for_all_Gas_plants = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Pipeline_license_renewal_staus = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Domestic_Gas_Supply_DSO = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Projects_planned_for_Domestic_supply_Gas_to_power_industries_etc = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    penaltyfeepaid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Amount_Paid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    proposed_production = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    proposed_utilization = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    proposed_flaring = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas_flare_Royalty_payment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas_Sales_Royalty_Payment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    No_of_gas_well_planned = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    No_of_gas_well_drilled = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Is_there_a_gas_plant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    No_of_ongoing_projects = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    No_of_plannned_projects = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Is_there_a_license_to_operate_a_gas_plant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Domestic_Gas_obligation_met = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Has_annual_NDR_subscription_fee_been_paid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    When_was_the_date_of_your_last_NDR_submission = table.Column<DateTime>(type: "date", nullable: true),
                    Upload_NDR_payment_receipt = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Are_you_up_to_date_with_your_NDR_data_submission = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NDRFilename = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    number_of_gas_wells_completed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    number_of_gas_wells_tested = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    AnnualForecastCondensate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualForecastGasAg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualForecastGasNag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualForecastOil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GAS_PRODUCTION_ACTIVITIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ProjectName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Gas_Production_Activity",
                columns: table => new
                {
                    Gas_Production_ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Utilized = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Forecast = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Flared = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas_Production_Activity", x => x.Gas_Production_ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Gas_Reserve_Update",
                columns: table => new
                {
                    Gas_ReserveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reserve1 = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Reserve2 = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Additional_Reserve = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Total_Production = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas_Reserve_Update", x => x.Gas_ReserveId);
                });

            migrationBuilder.CreateTable(
                name: "GeographicalActivity",
                columns: table => new
                {
                    Geographical_ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year_A = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Proposed_Year_A = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Budget_Allocation_A = table.Column<long>(type: "bigint", nullable: true),
                    Remark_A = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_Year_B = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Proposed_Year_B = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Budget_Allocation_B = table.Column<long>(type: "bigint", nullable: true),
                    Remark_B = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicalActivity", x => x.Geographical_ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Geophysical_Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_Year_Acquired = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_Allocation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Any_acquired_geophysical_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Area_of_Coverage = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Method_of_Acquisition = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Data_Acquired = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Quantum_of_Data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Quantum_Carry_Forward = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Record_Length_of_Data = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Completion_Status = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Activity_Timeline = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_Processed_Reprocessed_Interpreted_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year_processing = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Budget_Allocation_pro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Any_Ongoing_Processing_Project = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Data_being_Processed = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Quantum_of_Data_pro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Quantum_Carry_Forward_pro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Completion_Status_pro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Activity_Timeline_pro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks_pro = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geophysical_Activities_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GEOPHYSICAL_ACTIVITIES_ACQUISITION",
                columns: table => new
                {
                    Geophysical_ActivitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Geo_acquired_geophysical_data = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_area_of_coverage = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_method_of_acquisition = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_type_of_data_acquired = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Record_Length_of_Data = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Completion_Status = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Quantum = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Quantum_carry_forward = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Activity_Timeline = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_year_aquired_data = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year_data = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Budeget_Allocation = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Budeget_Allocation_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budeget_Allocation_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name_of_Contractor = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quantum_Approved = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Quantum_Planned = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas_flare_Royalty_payment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas_Sales_Royalty_Payment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QUATER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    No_of_Folds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geophysical_Activities", x => x.Geophysical_ActivitiesId);
                });

            migrationBuilder.CreateTable(
                name: "GEOPHYSICAL_ACTIVITIES_PROCESSING",
                columns: table => new
                {
                    Geophysical_Activities_ProcessingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Geo_Any_Ongoing_Processing_Project = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Type_of_Data_being_Processed = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Quantum_of_Data = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Quantum_of_Data_carry_over = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Completion_Status = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Geo_Activity_Timeline = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_year_aquired_data = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year_data = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Budeget_Allocation = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Budeget_Allocation_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budeget_Allocation_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Processed_Actual = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Processed_Proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Reprocessed_Actual = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Reprocessed_Proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Interpreted_Actual = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Interpreted_Proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name_of_Contractor = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quantum_Approved = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Quantum_Planned = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QUATER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    No_of_Folds = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Type_of_Processing = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GEOPHYSICAL_ACTIVITIES_PROCESSING", x => x.Geophysical_Activities_ProcessingId);
                });

            migrationBuilder.CreateTable(
                name: "HSE",
                columns: table => new
                {
                    HSE_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty_Spilled = table.Column<int>(type: "int", nullable: true),
                    Accident_Stat = table.Column<long>(type: "bigint", nullable: true),
                    Relevant_Certificate = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE", x => x.HSE_Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ACCIDENT_INCIDENCE_REPORTING_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Was_there_any_accident_incidence = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_YES_were_they_reported = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    UploadIncidentStatisticsFilename = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    UploadIncidentStatisticsPath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ACCIDENT_INCIDENCE_REPORTING_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Accident_Incidence = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Location = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Investigation = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Date_ = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Cause = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Consequence = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Lesson_Learnt = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Frequency = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    facility = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equipment_type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equipment_description = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Equipment_serial_number = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Equipment_tag_number = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Equipment_manufacturer = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equipment_Installation_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Last_inspection_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Last_Inspection_Type_Performed = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Next_Inspection_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Proposed_Inspection_Type = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Equipment_Inspected_as_and_when_due = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    State_reason = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Condition_of_Equipment = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Function_Test_Result = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Inspection_Report_Review = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    facility = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equipment_type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equipment_description = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Equipment_serial_number = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Equipment_tag_number = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Equipment_manufacturer = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equipment_Installation_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Last_inspection_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Last_Inspection_Type_Performed = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Likelihood_of_Failure = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Consequence_of_Failure = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Maximum_Inspection_Interval = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Next_Inspection_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Proposed_Inspection_Type = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    RBI_Assessment_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Equipment_Inspected_as_and_when_due = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    State_reason = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Condition_of_Equipment = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Function_Test_Result = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Inspection_Report_Review = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_CAUSES_OF_SPILL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    no_of_spills_reported = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Total_Quantity_Spilled = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Total_Quantity_Recovered = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Corrosion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Equipment_Failure = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Erossion_waves_sand = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Human_Error = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Mystery = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Operational_Maintenance_Error = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Sabotage = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    YTBD = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_CAUSES_OF_SPILL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_CLIMATE_CHANGE_AND_AIR_QUALITY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DoyouhaveGHG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    GHGFilePath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GHGFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_CLIMATE_CHANGE_AND_AIR_QUALITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Possible_causes_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Effect_on_your_operations_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Cost_involved_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Total_days_lost_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    No_of_casual_Fatality_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Action_plan_for_PROPOSED_YEAR = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Was_there_any_Community_Related_Disturbances_within_your_operational_area = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_YES_Give_details_on_Community_Related_Disturbances_within_your_operational_area = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Was_any_Oil_Spill_recorded_within_your_operational_area = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Possible_causes = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Effect_on_your_operations = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Cost_involved = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Total_days_lost = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    No_of_casual_Fatality = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Action_Plan_for_ = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Oil_spill_reported = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_ = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    NUMBER = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Quantity_spilled = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quantity_Recovered = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_DESIGNS_SAFETY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DESIGNS_SAFETY_Type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DESIGNS_SAFETY_Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DESIGNS_SAFETY_Current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_DESIGNS_SAFETY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_EFFLUENT_MONITORING_COMPLIANCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OmL_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AreThereEvidentOfSampling = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EvidenceOfSamplingFilename = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    EvidenceOfSamplingPath = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    ReasonForNoEvidenceSampling = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created_by = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_EFFLUENT_MONITORING_COMPLIANCE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Name_of_Chemical = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    DPR_Approved = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quarter_1 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Quarter_2 = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quarter_3 = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quarter_4 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Are_you_a_Producing_or_Non_Producing_Company = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_YES_have_you_registered_your_Point_Sources = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    If_NO_give_reasons_for_not_registering_your_Point_Sources = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Have_you_submitted_your_Environmental_Compliance_Report = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_NO_Give_reasons_for_non_SUBMISSION = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Have_you_submitted_your_Chemical_Usage_Inventorization_Report = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_NO_Give_reasons_for_non_submission_2 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Report = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quarter_1 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Quarter_2 = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quarter_3 = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Quarter_4 = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Pre_Impact_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    In_progress_Started_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    OmL_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    AreThereEMP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    FacilityType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FacilityLocation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    RemarkIfNoEMP = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_MANAGEMENT_PLAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EMSFilePath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    AUDITFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EMSFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AUDITFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    YEAR_ = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Type_of_Study_IA_or_EES = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_STUDIES_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Any_Environmental_Studies = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_YES_state_Project_Name = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Status_ = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Field_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUPRC_Approval_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    If_Ongoing = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_STUDIES_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    field_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    type_of_study = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    study_title = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    current_study_status = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    DPR_approval_Status = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_FATALITIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Current_year_DATA = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year_DATA = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fatalities_Type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fatalities_Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fatalities_Current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    type_of_incidence = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_FATALITIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_GHG_MANAGEMENT_PLAN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OmL_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OmL_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    companyemail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanY_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    DoYouHaveGHG = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    GHGApprovalFilename = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    GHGApprovalPath = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    ReasonForNoGHG = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    DoYouHaveLDRCertificate = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    LDRCertificateFilename = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    LDRCertificatePath = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    ReasonForNoLDR = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_GHG_MANAGEMENT_PLAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_HOST_COMMUNITIES_DEVELOPMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoYouHaveEvidenceOfReg = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EvidenceOfRegTrustFundFilename = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    EvidenceOfRegTrustFundPath = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    ReasonForNoEvidenceOfRegTF = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    DoYouHaveEvidenceOfPay = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EvidenceOfPayTrustFundFilename = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    EvidenceOfPayTrustFundPath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    ReasonForNoEvidenceOfPayTF = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    UploadCommDevPlanApprovalFilename = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    UploadCommDevPlanApprovalPath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    OmL_ID = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_HOST_COMMUNITIES_DEVELOPMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Facility_Type = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Type_of_Inspection_and_Maintenance = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    When_was_it_carried_out = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name_of_facility = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    was_the_inspection_and_maintenemce = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    If_RBI_was_approval_granted = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    If_No_Give_reasonS = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_INSPECTION_AND_MAINTENANCE_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Was_Inspection_and_Maintenance_of_each_of_your_facility_carried_out = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Is_the_inspection_philosophy_Prescriptive_or_RBI_for_each_facility = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    If_RBI_was_approval_granted = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_No_Give_reasonS = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_INSPECTION_AND_MAINTENANCE_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_MANAGEMENT_POSITION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OrganogramrFilePath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    PromotionLetterFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrganogramrFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PromotionLetterFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_MANAGEMENT_POSITION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_MinimumRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Company_ISO45001_Certified = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Provide_ISO45001_Certification_No = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    ConcessionID = table.Column<int>(type: "int", nullable: true),
                    FieldID = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_MinimumRequirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_OCCUPATIONAL_HEALTH_MANAGEMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OHMplanFilePath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    OHMplanCommunicationFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OHMplanFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OHMplanCommunicationFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SMSFileUploadname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    ReasonWhyOhmWasNotCommunicatedToStaff = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    WasOhmPolicyCommunicatedToStaff = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ReasonForNoOhm = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    DoYouHaveAnOhm = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_OCCUPATIONAL_HEALTH_MANAGEMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_OIL_SPILL_INCIDENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Number_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Quantity_spilled_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Quantity_Recovered_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_OIL_SPILL_INCIDENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_OIL_SPILL_REPORTING_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Incident_Oil_Spill_Ref_No = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Facility_Equipment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Location = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    LGA = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    State_ = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Date_of_Spill = table.Column<DateTime>(type: "datetime", nullable: true),
                    Type_of_operation_at_spill_site = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Cause_of_spill = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Volume_of_spill_bbls = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Volume_recovered_bbls = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_OIL_SPILL_REPORTING_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_OPERATIONS_SAFETY_CASE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Reason_If_No_Evidence = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    Evidence_of_Operations_Safety_Case_Approval = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Does_the_Facility_Have_a_Valid_Safety_Case = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Type_of_Facility = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Location_of_Facility = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Name_Of_Facility = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Number_of_Facilities = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_OPERATIONS_SAFETY_CASE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_OSP_REGISTRATIONS_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DESCRIPTION_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    VALUES_ = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_OSP_REGISTRATIONS_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_POINT_SOURCE_REGISTRATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_Name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    OML_ID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company_Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company_Number = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company_ID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    are_there_point_source_permit = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidence_of_PSP_filename = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidence_of_PSP_path = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    reason_for_no_PSP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_POINT_SOURCE_REGISTRATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_PRODUCED_WATER_MANAGEMENT_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Within_which_zone_are_you_operating = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    how_do_you_handle_your_produced_water = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Export_to_Terminal_with_fluid = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_PRODUCED_WATER_MANAGEMENT_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FIELD_NAME = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Concession = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    facilities = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    DEPTH_AND_DISTANCE_FROM_SHORELINE = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Produced_water_volumes = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Disposal_philosophy = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    DPR_APPROVAL_STATUS = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_QUALITY_CONTROL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DoyouhaveQualityControl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    QualityControlFilePath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QualityControlFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Valid_Accreditation_Letter_For_QualityControl = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_QUALITY_CONTROL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_QUESTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty_Spilled = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Accident_Stat = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Relevant_Certificate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_QUESTIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_REMEDIATION_FUND",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_Name = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    OML_ID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company_Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company_Number = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company_ID = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidenceOfPaymentFilename = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidenceOfPaymentPath = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    evidenceOfPreviousYearsPaymentFilename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evidenceOfPreviousYearsPaymentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reasonForNoRemediation = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    areThereRemediationFund = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_REMEDIATION_FUND", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SAFETY_CULTURE_TRAINING",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SafetyCurrentYearFilePath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    SafetyLast2YearsFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SafetyCurrentYearFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SafetyLast2YearsFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    AreThereTrainingPlansForHSE = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    EvidenceOfTrainingPlanFilename = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    EvidenceOfTrainingPlanPath = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SAFETY_CULTURE_TRAINING", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SAFETY_STUDIES_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Did_you_carry_out_safety_studies = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    State_Project_Name_for_which_studies_was_carried_out = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    List_the_studies = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    List_identified_Major_Accident_Hazards_for_the_study = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    List_the_Safeguards_based_on_the_identified_Major_Accident_Hazards = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SMSFileUploadPath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DoyouhaveSMSinPlace = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SAFETY_STUDIES_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CSR_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_Spent_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Percentage_Completion_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CSR_ = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Budget_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_Spent = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Percentage_Completion_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Beneficiary_Communities = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_Proposed_Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CSR_ = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Budget_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_Ngn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actual_Spent = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Percentage_Completion_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Beneficiary_Communities_host = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Beneficiary_Communities_National = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_Proposed_Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CSR_ = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Budget_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_Ngn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actual_Spent = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Percentage_Completion_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Beneficiary_Communities_host = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Beneficiary_Communities_National = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_Proposed_Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Type_of_project_excuted = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Year_GMou_was_signed = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Project_Location = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Component_of_project = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Actual_Budget_Total_Dollars = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Beneficiary_Community = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Status_Of_Project = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    MOUUploadFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MOUUploadFilename = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Description_of_Projects_Planned = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description_of_Projects_Actual = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Have_you_submitted_all_MoUs_to_DPR = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    If_NO_why = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Do_you_have_an_MOU_with_the_communities_for_all_your_assets = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MOUResponderFilePath = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MOUOSCPFilePath = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MOUResponderFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MOUOSCPFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MOUResponderInPlace = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NameOfCommunity = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Year_GMou_was_signed = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ScholarshipYear = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ComponentOfScholarship = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Actual_Budget_Total_Dollars = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_Budget_Total_Naira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSUploadFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SSUploadFilename = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NameOfCommunity = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Year_GMou_was_signed = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TrainingYear = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ComponentOfTraining = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Actual_Budget_Total_Dollars = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_Budget_Total_Naira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfTraining = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    TSUploadFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TSUploadFilename = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    facility = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    study_type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    facility_location = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    approval_status = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    remarks = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    type_of_facility = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    number_of_facilities = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_WASTE_MANAGEMENT_DZs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OML_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companyemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year_of_WP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COMPANY_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Evidence_of_pay_of_DDCFilename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evidence_of_pay_of_DDCPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Waste_Contractor_Names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produce_Water_Manegent_Plan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evidence_of_Reinjection_Permit_Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evidence_of_Reinjection_Permit_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason_for_No_Evidence_of_Reinjection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Do_You_Have_Previous_Year_Waste_Inventory_Report = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evidence_of_EWD_Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evidence_of_EWD_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason_for_No_Evidence_of_EWD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTUAL_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROPOSED_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Waste_Service_Permit_Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Waste_Service_Permit_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_WASTE_MANAGEMENT_DZs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_WASTE_MANAGEMENT_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Do_you_have_Waste_Management_facilities = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    If_YES_is_the_facility_registered = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    If_NO_give_reasons_for_not_being_registered = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Commitment_To_Waste_Management = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    How_Much_Is_Budgeted_For_Waste_MGT_Plan = table.Column<double>(type: "float", nullable: true),
                    Evidence_Of_Submission_Of_Journey_MGT_Plan = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Are_Registered_Point_Sources_Valid = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Evidence_Of_Submission_Of_PreviousYears_Waste_Release = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_WASTE_MANAGEMENT_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_WASTE_MANAGEMENT_SYSTEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    WasteManagementPlanFilePath = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    DecomCertificateFilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    WasteManagementPlanFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DecomCertificateFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_WASTE_MANAGEMENT_SYSTEM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTUAL_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PROPOSED_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Facility = table.Column<string>(type: "varchar(3999)", unicode: false, maxLength: 3999, nullable: true),
                    Approved_or_Not_Approve = table.Column<string>(type: "varchar(3900)", unicode: false, maxLength: 3900, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    LOCATION = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Initial_Well_Completion_Job",
                columns: table => new
                {
                    Initial_Well_CompletionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_No_Current_Year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Actual_No_Proposed_Year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Budget_Allocation_Proposed_Year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Processing_Fees_Paid = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Do_you_have_approval_to_complete_the_well = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Remark = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Year_of_WorkProgram = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Initial_Well_Completion", x => x.Initial_Well_CompletionId);
                });

            migrationBuilder.CreateTable(
                name: "INITIAL_WELL_COMPLETION_JOBS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Do_you_have_approval_to_complete_the_well = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_year_Actual_Number = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_year_Budget_Allocation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Processing_Fees_paid = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Budeget_Allocation_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budeget_Allocation_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QUATER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    oil_or_gas_wells = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Actual_Completion_Date = table.Column<DateTime>(type: "date", nullable: true),
                    Proposed_Completion_Date = table.Column<DateTime>(type: "date", nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Proposed_Completion_Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proposed_Initial_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proposed_Well_Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INITIAL_WELL_COMPLETION_JOBS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legal",
                columns: table => new
                {
                    Legal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Sanctioned = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Company_Fined = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Company_FinedReason = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legal", x => x.Legal_Id);
                });

            migrationBuilder.CreateTable(
                name: "LEGAL_ARBITRATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AnyLitigation = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Case_Number = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Names_of_Parties = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Jurisdiction = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name_of_Court = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Summary_of_the_case = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Any_orders_made_so_far_by_the_court = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Potential_outcome = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEGAL_ARBITRATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LEGAL_LITIGATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AnyLitigation = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Case_Number = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Names_of_Parties = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Jurisdiction = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name_of_Court = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Summary_of_the_case = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Any_orders_made_so_far_by_the_court = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Any_subsisting_orders_of_court = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_of_the_court = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Potential_outcome = table.Column<string>(type: "varchar(3000)", unicode: false, maxLength: 3000, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEGAL_LITIGATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_Current_year_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_Current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Training_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Local_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Foreign_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    List_of_Expatriate_positions_that_will_expire = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    List_of_Understudies_that_had_successfully_taken_over_from_expatriates_in_the_last_4_years = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Expatriate_Quota_projection_for_proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Training_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Local_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Foreign_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalContent",
                columns: table => new
                {
                    Local_ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    List_of_Expiry_Expatriate = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    List_of_Understudies = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Expatriate_Quota_Projection = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalContent", x => x.Local_ContentId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IconName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SeqNo = table.Column<byte>(type: "tinyint", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    read = table.Column<int>(type: "int", nullable: true),
                    companyID = table.Column<int>(type: "int", nullable: true),
                    sender_id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppId = table.Column<int>(type: "int", nullable: true),
                    staffID = table.Column<int>(type: "int", nullable: true),
                    UserType = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MyDesks",
                columns: table => new
                {
                    DeskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessID = table.Column<int>(type: "int", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    HasWork = table.Column<bool>(type: "bit", nullable: false),
                    HasPushed = table.Column<bool>(type: "bit", nullable: false),
                    FromStaffID = table.Column<int>(type: "int", nullable: true),
                    FromSBU = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    FromRoleId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    LastJobDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyDesk_UT", x => x.DeskID);
                });

            migrationBuilder.CreateTable(
                name: "NDPR_SUBSCRIPTION_FEE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_annual_NDR_subscription_fee_been_paid = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Did_you_process_data_for_current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Data_Type = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Volume_of_data_processed = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NDPR_SUBSCRIPTION_FEE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NDR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_annual_NDR_subscription_fee_been_paid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    When_was_the_date_of_your_last_NDR_submission = table.Column<DateTime>(type: "date", nullable: true),
                    Upload_NDR_payment_receipt = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Are_you_up_to_date_with_your_NDR_data_submission = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NDRFilename = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "NDR_Data_Population",
                columns: table => new
                {
                    NDRDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Data_Type = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Processed_Data = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Reason_Non_Processed_Data = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Subscription_Fee_Upload = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Annual_Sub_Fee = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Reason_For_Non_Payment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NDR_Data_Population", x => x.NDRDataId);
                });

            migrationBuilder.CreateTable(
                name: "NDR_DATA_POPULATION_ON_BLOCK_BASIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_YEAR_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NDR_DATA_POPULATION_ON_BLOCK_BASIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NIGERIA_CONTENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Do_you_have_a_valid_Expatriate_Quota_for_your_foreign_staff = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    If_NO_why = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Is_there_a_succession_plan_in_place = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Number_of_staff_released_within_the_year_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIGERIA_CONTENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NIGERIA_CONTENT_QUESTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Do_you_have_a_valid_Expatriate_Quota_for_your_foreign_staff = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    If_NO_why = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Is_there_a_succession_plan_in_place = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Number_of_staff_released_within_the_year_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    total_no_of_nigeria_senior_staff = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    total_no_of_senior_staff = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    total_no_of_top_nigerian_management_staff = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    total_no_of_top_management_staff = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIGERIA_CONTENT_QUESTION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NIGERIA_CONTENT_Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Training_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Local_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Foreign_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Expatriate_quota_positions = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Utilized_EQ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nigerian_Understudies = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Management_Foriegn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Management_Local = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Staff_Foriegn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Staff_Local = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_Proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_Proposed_Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIGERIA_CONTENT_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NIGERIA_CONTENT_Upload_Succession_Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Name_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Understudy_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Timeline_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Position_Occupied_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Actual_proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_Proposed_Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIGERIA_CONTENT_Upload_Succession_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NigerianContent",
                columns: table => new
                {
                    Nigerian_ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mgt_Local = table.Column<int>(type: "int", nullable: true),
                    Mgt_Expatriates = table.Column<int>(type: "int", nullable: true),
                    Staff_Local = table.Column<int>(type: "int", nullable: true),
                    Staff_Expatriates = table.Column<int>(type: "int", nullable: true),
                    Valid_Expatriate = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Nbr_of_Released_Staff = table.Column<int>(type: "int", nullable: true),
                    Reason_For_NonExpatriate = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Succession_Plan_in_Place = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Succession_PlanName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Succession_PlanTimeLine = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Succession_PlanUnderStudy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Position_Occupied = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NigerianContent", x => x.Nigerian_ContentId);
                });

            migrationBuilder.CreateTable(
                name: "OIL_AND_GAS_FACILITY_MAINTENANCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_capital_expenditure_Current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_Capital_Expenditure = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Major_Projects = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Objective_Drivers_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Approval_License_Permits = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CAPEX_Oversight = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_Performance = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Completion_Status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Conceptual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FEED = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Detailed_Engineering = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Construction_Commissioning_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Production_Product_Offtakers = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Challenges = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Project_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Conformity_Assessment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    New_Technology_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_it_been_adopted_by_DPR_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Comment_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Planned_ongoing_and_routine_maintenance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_AND_GAS_FACILITY_MAINTENANCE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_capital_expenditure_Current_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_Capital_Expenditure = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Actual_capital_expenditure_Current_year_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_capital_expenditure_Current_year_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Proposed_Capital_Expenditure_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Proposed_Capital_Expenditure_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Major_Projects = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Objective_Drivers_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Approval_License_Permits = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CAPEX_Oversight = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Budget_Performance = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Completion_Status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Conceptual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FEED = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Detailed_Engineering = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Construction_Commissioning_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Production_Product_Offtakers = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Challenges = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Project_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Conformity_Assessment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    New_Technology_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_it_been_adopted_by_DPR_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Comment_ = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Planned_ongoing_and_routine_maintenance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Actual_capital_expenditure_Current_year_NGN = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_capital_expenditure_Current_year_USD = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_Capital_Expenditure_NGN = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_Capital_Expenditure_USD = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Project_Stage = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Nigerian_Content_Value = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Product_Off_takers = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_Proposed_year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Actual_Proposed = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Facility_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facility_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proposed_Projects = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Current_year_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Deferment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Forecast = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Cost_Barrel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fiveyear_NAG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Did_you_carry_out_any_well_test = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Test = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Maximum_Efficiency_Rate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Number_of_Test_Carried_out = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Number_of_Producing_Wells = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Daily_Production_ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Is_any_of_your_field_straddling = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    How_many_fields_straddle = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Straddling_Fields_OC = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Prod_Status_OC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Straddling_Field_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Name_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Prod_Status_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_DPR_been_notified = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_the_other_party_been_notified = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_the_CA_been_signed = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Committees_been_inaugurated = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Participation_been_determined = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_the_PUA_been_signed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Is_there_a_Joint_Development = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_the_UUOA_been_signed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Total_Reconciled_National_Crude_Oil_Production = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Oil_Royalty_Payment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    straddle_field_producing = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    what_concession_field_straddling = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas_AG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Gas_NAG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Current_year_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Deferment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Forecast = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Cost_Barrel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fiveyear_NAG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Did_you_carry_out_any_well_test = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Test = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Maximum_Efficiency_Rate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Number_of_Test_Carried_out = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Number_of_Producing_Wells = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Daily_Production_ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Is_any_of_your_field_straddling = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    How_many_fields_straddle = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Straddling_Fields_OC = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Prod_Status_OC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Straddling_Field_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Name_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Prod_Status_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_DPR_been_notified = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_the_other_party_been_notified = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_the_CA_been_signed = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Committees_been_inaugurated = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Participation_been_determined = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_the_PUA_been_signed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Is_there_a_Joint_Development = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_the_UUOA_been_signed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Total_Reconciled_National_Crude_Oil_Production = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProductionOilCondensateAGNAGUploadFilePath = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ProductionOilCondensateAGNAGUFilename = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Production_month_id = table.Column<int>(type: "int", nullable: true),
                    Production_month = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Production = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Avg_Daily_Production = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas_AG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Gas_NAG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Production_month_id = table.Column<int>(type: "int", nullable: true),
                    Production_month = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Production = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Avg_Daily_Production = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gas_AG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Gas_NAG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    CondensateProd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Objective = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Existing_Alternatives = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    DPR_Consent = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Cost = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Benefits = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Challenges = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Inspection_Regime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenceOfInspectionAndUgradePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvidenceOfInspectionAndUgradeFilename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Operating_Facilities = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Current_year_Actual = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Deferment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Forecast = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Cost_Barrel = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fiveyear_NAG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Did_you_carry_out_any_well_test = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Type_of_Test = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Maximum_Efficiency_Rate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Number_of_Test_Carried_out = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Number_of_Producing_Wells = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Daily_Production_ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Is_any_of_your_field_straddling = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    How_many_fields_straddle = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Straddling_Fields_OC = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Prod_Status_OC = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Straddling_Field_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Name_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Prod_Status_OP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_DPR_been_notified = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_the_other_party_been_notified = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Has_the_CA_been_signed = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Committees_been_inaugurated = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Participation_been_determined = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_the_PUA_been_signed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Is_there_a_Joint_Development = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Has_the_UUOA_been_signed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Total_Reconciled_National_Crude_Oil_Production = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Oil_Royalty_Payment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    straddle_field_producing = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    what_concession_field_straddling = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PUAUploadFilePath = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UUOAUploadFilePath = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PUAUploadFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UUOAUploadFilename = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OilCondensateProduction",
                columns: table => new
                {
                    Oil_Condensate_ProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Deferment = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Forecast = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Cost_Barrel = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilCondensateProduction", x => x.Oil_Condensate_ProductionId);
                });

            migrationBuilder.CreateTable(
                name: "OilSpill_Incident",
                columns: table => new
                {
                    Oil_Spill_IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number_Qty_Spilled = table.Column<int>(type: "int", nullable: true),
                    Qty_Recovered = table.Column<int>(type: "int", nullable: true),
                    Pre_Impact = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    InProgress_StartedYr = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Possible_Cost = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Total_Days_Lost = table.Column<int>(type: "int", nullable: true),
                    Effect_on_Operation = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Nbr_of_Fatality = table.Column<int>(type: "int", nullable: true),
                    Cost_Involved = table.Column<int>(type: "int", nullable: true),
                    Action_Plan = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Proof_Of_Submission_Of_Valid_OSCP = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Evidence_Of_QuaterlySubmissions_Of_OilField_Chemicals = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Evidence_Of_MOUs_With_CAN = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilSpill_Incident", x => x.Oil_Spill_IncidentId);
                });

            migrationBuilder.CreateTable(
                name: "PermitApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermitNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AppID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ElpsID = table.Column<int>(type: "int", nullable: true),
                    DateIssued = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    DateExpired = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    IsRenewed = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    uploaded_presentation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planning_MinimumRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservesRevenue_GrossProduction = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ReservesRevenue_RemainingReserves = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    ConcessionID = table.Column<int>(type: "int", nullable: true),
                    FieldID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planning_MinimumRequirement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRESENTATION_UPLOAD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    uploaded_presentation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    check_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    upload_extension = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    original_filemane = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRESENTATION_UPLOAD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserve_Update_Oil_Condensate",
                columns: table => new
                {
                    Reserve_UpdateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P1_Reserve = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Reserves = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Additional_Reserves = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Total_Production = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve_Update_Oil_Condensate", x => x.Reserve_UpdateId);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_REPLACEMENT_RATIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    RESERVES_REPLACEMENT_RATIO_VALUE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Trend_Year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_REPLACEMENT_RATIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_DEPLETION_RATE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CONDENSATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NAG = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AG = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_DEPLETION_RATE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_LIFE_INDEX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OIL = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CONDENSATE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NAG = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AG = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_LIFE_INDEX", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_as_at_MMbbl_P1 = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Additional_Reserves_as_at_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Total_Production_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_as_at_MMbbl = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Company_Reserves_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_AnnualOilProduction = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Current_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Current_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Current_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Current_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Current_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Current_AnnualOilProduction = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fiveyear_Projection_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_AnnualOilProduction = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Annual_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_AnnualOilProduction = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_Was_there_any_Reserve_Addition = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_Reason_for_Addition = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_Addition_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_Was_there_a_decline_in_reserve = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_Reason_for_Decline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_Decline_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_Reservoir = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_ReservoirPressure = table.Column<string>(name: "Reservoir_Performance_Reservoir Pressure", type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_WCT = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reservoir_Performance_GOR = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_Sand_Cut = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Annual_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Annual_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Annual_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_AnnualOilProduction = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fiveyear_Projection_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Fiveyear_Projection_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Fiveyear_Projection_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_MMBBL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_as_at_MMbbl_P1 = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Additional_Reserves_as_at_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Total_Production_ = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_as_at_MMbbl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reserves_as_at_MMbbl_condensate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Reserves_as_at_MMbbl_gas = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_Addition_Was_there_any_Reserve_Addition = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_Reason_for_Addition = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Addition_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_Addition_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_Decline_Was_there_a_decline_in_reserve = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_Reason_for_Decline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reserves_Decline_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reserves_Decline_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reservoir_Performance_Timeline = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_Reservoir = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_Reservoir_Pressure = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_WCT = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Reservoir_Performance_GOR = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Reservoir_Performance_Sand_Cut = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_Year = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_Oil = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_Condensate = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_AG = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_NAG = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Company_Reserves_AnnualOilProduction = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FLAG1 = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    FLAG2 = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Company_Reserves_AnnualGasProduction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_AnnualCondensateProduction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_AnnualGasAGProduction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Company_Reserves_AnnualGasNAGProduction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RoleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ROLES_",
                columns: table => new
                {
                    SN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    RoleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ROLES_SUPER_ADMIN",
                columns: table => new
                {
                    SN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email_ = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Deleted_Date = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Deleted_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Royalty",
                columns: table => new
                {
                    Royalty_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Concession_ID = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    Crude_Oil_Royalty = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Gas_Sales_Royalty = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Gas_Flare_Payment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Concession_Rentals = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Miscellaneous = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Year = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "date", nullable: true),
                    Last_Qntr_Royalty = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    OmlName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Royalty", x => x.Royalty_ID);
                });

            migrationBuilder.CreateTable(
                name: "SafetyManagement",
                columns: table => new
                {
                    Safety_ManagementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fatalities = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Current_Facilities = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Previous_Facilities = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Design_Safety_Control = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Current_Year = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Previous_Year = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyManagement", x => x.Safety_ManagementId);
                });

            migrationBuilder.CreateTable(
                name: "SBU_ApplicationComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SBU_ID = table.Column<int>(type: "int", nullable: true),
                    AppID = table.Column<int>(type: "int", nullable: true),
                    SBU_Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ActionStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Staff_ID = table.Column<int>(type: "int", nullable: true),
                    SBU_Tables = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBU_ApplicationComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SBU_Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SBU_Id = table.Column<int>(type: "int", nullable: true),
                    Records = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBU_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SBU_Submission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    SBU_ID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBU_Submission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffElpsID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Staff_SBU = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    StaffEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteStatus = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    SignaturePath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    SignatureName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AdminCompanyInfo_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.StaffID);
                });

            migrationBuilder.CreateTable(
                name: "STRATEGIC_PLANS_ON_COMPANY_BASIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ACTIVITIES = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    N_1_Q1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_1_Q2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_1_Q3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_1_Q4 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_2_Q1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_2_Q2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_2_Q3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_2_Q4 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_3_Q1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_3_Q2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_3_Q3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_3_Q4 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_4_Q1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_4_Q2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_4_Q3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_4_Q4 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_5_Q1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_5_Q2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_5_Q3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    N_5_Q4 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STRATEGIC_PLANS_ON_COMPANY_BASIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrategicBusinessUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SBU_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SBU_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Tier = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategicBusinessUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedDocuments",
                columns: table => new
                {
                    SubDocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppID = table.Column<int>(type: "int", nullable: true),
                    LocalDocID = table.Column<int>(type: "int", nullable: true),
                    ElpsDocID = table.Column<int>(type: "int", nullable: true),
                    YearOfWKP = table.Column<int>(type: "int", nullable: true),
                    DocSource = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DocumentCategory = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DocumentName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedDocuments", x => x.SubDocID);
                });

            migrationBuilder.CreateTable(
                name: "SubstainableDevelopment",
                columns: table => new
                {
                    Substainable_DevelopmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descript_of_Project_Planned = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Descript_of_Project_Actual = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstainableDevelopment", x => x.Substainable_DevelopmentId);
                });

            migrationBuilder.CreateTable(
                name: "Table_1",
                columns: table => new
                {
                    sn = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Table_Details",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    TableSchema = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    SBU_ID = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Details", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_fruitanalysis",
                columns: table => new
                {
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TrainingForStaff",
                columns: table => new
                {
                    Training_For_StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mgt_Staff_Local = table.Column<int>(type: "int", nullable: true),
                    Mgt_Staff_Foreign = table.Column<int>(type: "int", nullable: true),
                    Senior_Staff_Local = table.Column<int>(type: "int", nullable: true),
                    Senior_Staff_Foreign = table.Column<int>(type: "int", nullable: true),
                    Junior_Staff_Local = table.Column<int>(type: "int", nullable: true),
                    Junior_Staff_Foreign = table.Column<int>(type: "int", nullable: true),
                    Partner_Staff_Local = table.Column<int>(type: "int", nullable: true),
                    Partner_Staff_Foreign = table.Column<int>(type: "int", nullable: true),
                    Regulator_Staff_Local = table.Column<int>(type: "int", nullable: true),
                    Regulator_Staff_Foreign = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingForStaff", x => x.Training_For_StaffId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginPk = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    UserType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Client = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LoginTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    LoginMessage = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginPk, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    UserType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserRole = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    LoginCount = table.Column<int>(type: "int", nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WORK_PROGRAM_FLOW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Descriptions = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Flag1 = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORK_PROGRAM_FLOW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOverJobs",
                columns: table => new
                {
                    WorkOver_JobsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Proposed_Year = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Budget_Allocation = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOverJobs", x => x.WorkOver_JobsId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOvers_Recompletion_Job",
                columns: table => new
                {
                    WorkOvers_Recompletion_JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actual_No_Current_Year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Actual_No_Proposed_Year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Budget_Allocation_Proposed_Year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Processing_Fees_Paid = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Do_you_have_approval_for_workover_recompletion = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Remark = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Year_of_WorkProgram = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOvers_Recompletion_Job", x => x.WorkOvers_Recompletion_JobId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOvers_Recompletion_Job_Field_Dvelopment_Plans",
                columns: table => new
                {
                    WorkOvers_Recompletion_Job_Field_Dvelopment_PlansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    How_many_fields_have_FDP = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    List_all_the_field_with_FDP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Which_fields_do_you_plan_to_submit_an_FDP = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    How_many_fields_have_approved_FDP = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Number_of_wells_proposed_in_the_FDP = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    No_of_wells_drilled_in_Current_Year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_number_of_wells_for_Proposed_Year_from_Approved_FDP = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Processing_Fees_Paid = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Year_of_WorkProgram = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOvers_Recompletion_Job_Field_Dvelopment_Plans", x => x.WorkOvers_Recompletion_Job_Field_Dvelopment_PlansId);
                });

            migrationBuilder.CreateTable(
                name: "WORKOVERS_RECOMPLETION_JOBS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OML_ID = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    OML_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Companyemail = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Year_of_WP = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Current_year_Actual_Number_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Proposed_year_data = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Current_year_Budget_Allocation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Processing_Fees_paid = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Do_you_have_approval_for_the_workover_recompletion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Actual_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    proposed_year = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Created_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Updated_by = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: true),
                    Date_Updated = table.Column<DateTime>(type: "datetime", nullable: true),
                    Budeget_Allocation_NGN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Budeget_Allocation_USD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Consession_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Terrain = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QUATER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    oil_or_gas_wells = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    COMPANY_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompanyNumber = table.Column<int>(type: "int", nullable: true),
                    Field_ID = table.Column<int>(type: "int", nullable: true),
                    DaysForCompletion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CompletionWellName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proposed_Workover_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKOVERS_RECOMPLETION_JOBS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleFunctionalityRef",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "varchar(20)", nullable: false),
                    FuncId = table.Column<string>(type: "varchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFunctionalityRef", x => new { x.RoleId, x.FuncId });
                    table.ForeignKey(
                        name: "FK_RoleFunctionalityRef_Functionality",
                        column: x => x.FuncId,
                        principalTable: "Functionality",
                        principalColumn: "FuncId");
                    table.ForeignKey(
                        name: "FK_RoleFunctionalityRef_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunctionalityRef_FuncId",
                table: "RoleFunctionalityRef",
                column: "FuncId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualExpenditure");

            migrationBuilder.DropTable(
                name: "ActualProposed_Year");

            migrationBuilder.DropTable(
                name: "ADMIN_ACCIDENT_INCIDENCE_REPORT_CAUSE");

            migrationBuilder.DropTable(
                name: "ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE");

            migrationBuilder.DropTable(
                name: "ADMIN_BUDGET_CAPEX_OPEX");

            migrationBuilder.DropTable(
                name: "ADMIN_CATEGORIES");

            migrationBuilder.DropTable(
                name: "ADMIN_CHAIRPERSON");

            migrationBuilder.DropTable(
                name: "ADMIN_COMPANY_CODE");

            migrationBuilder.DropTable(
                name: "ADMIN_COMPANY_DETAILS");

            migrationBuilder.DropTable(
                name: "ADMIN_COMPANY_INFORMATION");

            migrationBuilder.DropTable(
                name: "ADMIN_COMPANY_INFORMATION_AUDIT");

            migrationBuilder.DropTable(
                name: "ADMIN_COMPANY_INFORMATION_old_18052020");

            migrationBuilder.DropTable(
                name: "ADMIN_COMPLIANCE_INDEX_TABLE");

            migrationBuilder.DropTable(
                name: "ADMIN_CONCESSION_STATUS");

            migrationBuilder.DropTable(
                name: "ADMIN_CONCESSIONS_INFORMATION");

            migrationBuilder.DropTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_AUDIT");

            migrationBuilder.DropTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_BK_23112021");

            migrationBuilder.DropTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_HISTORY");

            migrationBuilder.DropTable(
                name: "ADMIN_CONCESSIONS_INFORMATION_old_18052020");

            migrationBuilder.DropTable(
                name: "ADMIN_DATETIME_PRESENTATION");

            migrationBuilder.DropTable(
                name: "ADMIN_DEVELOPMENT_PLAN_STATUS");

            migrationBuilder.DropTable(
                name: "ADMIN_DIVISION_REP");

            migrationBuilder.DropTable(
                name: "ADMIN_DIVISION_REP_LIST");

            migrationBuilder.DropTable(
                name: "ADMIN_DIVISIONAL_REPRESENTATIVE");

            migrationBuilder.DropTable(
                name: "ADMIN_DIVISIONAL_REPS_PRESENTATION");

            migrationBuilder.DropTable(
                name: "ADMIN_EMAIL_DAYS");

            migrationBuilder.DropTable(
                name: "ADMIN_ENVIROMENTAL_STUDIES");

            migrationBuilder.DropTable(
                name: "ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING");

            migrationBuilder.DropTable(
                name: "ADMIN_ENVIROMENTAL_STUDIES_IF_ONGOING");

            migrationBuilder.DropTable(
                name: "ADMIN_ENVIRONMENTAL_STUDY");

            migrationBuilder.DropTable(
                name: "ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI");

            migrationBuilder.DropTable(
                name: "ADMIN_FEILDDEVELOPMENTPLAN_WELLORGAS");

            migrationBuilder.DropTable(
                name: "ADMIN_FIVE_YEAR_TREND");

            migrationBuilder.DropTable(
                name: "ADMIN_GASPRODUCTION_UTILIZED_MMSCF");

            migrationBuilder.DropTable(
                name: "ADMIN_HSE_CONDITION_OF_EQUIPMENT");

            migrationBuilder.DropTable(
                name: "ADMIN_HSE_OSP REGISTRATIONS_NEW");

            migrationBuilder.DropTable(
                name: "ADMIN_HSE_OSP_REGISTRATIONS_NEW");

            migrationBuilder.DropTable(
                name: "ADMIN_INSPECTION_MAINTENANCE");

            migrationBuilder.DropTable(
                name: "ADMIN_LIST_OF_OMLS_OPLS");

            migrationBuilder.DropTable(
                name: "ADMIN_LITIGATION_JURISDICTION");

            migrationBuilder.DropTable(
                name: "ADMIN_MEETING_ROOM");

            migrationBuilder.DropTable(
                name: "ADMIN_MONTHS");

            migrationBuilder.DropTable(
                name: "ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities");

            migrationBuilder.DropTable(
                name: "ADMIN_ONGOING_COMPLETED");

            migrationBuilder.DropTable(
                name: "ADMIN_PERFOMANCE_INDEX");

            migrationBuilder.DropTable(
                name: "ADMIN_PRESENTATION_CATEGORIES");

            migrationBuilder.DropTable(
                name: "ADMIN_PRESENTATION_TIME");

            migrationBuilder.DropTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_EXPORT_TO");

            migrationBuilder.DropTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_how_do_you_handle_your_produced_water");

            migrationBuilder.DropTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_TYPE_OF_REPORT");

            migrationBuilder.DropTable(
                name: "ADMIN_PRODUCED_WATER_MANAGEMENT_ZONE");

            migrationBuilder.DropTable(
                name: "ADMIN_PUBLIC_HOLIDAY");

            migrationBuilder.DropTable(
                name: "ADMIN_QUARTER");

            migrationBuilder.DropTable(
                name: "ADMIN_REASON_FOR_ADDITION");

            migrationBuilder.DropTable(
                name: "ADMIN_REASON_FOR_DECLINE");

            migrationBuilder.DropTable(
                name: "ADMIN_SCHEDULED_STATUS");

            migrationBuilder.DropTable(
                name: "ADMIN_SCRIBE");

            migrationBuilder.DropTable(
                name: "ADMIN_STRATEGIC_PLANS_ON_COMPANY_BASIS");

            migrationBuilder.DropTable(
                name: "ADMIN_SUBMISSION_WINDOW");

            migrationBuilder.DropTable(
                name: "ADMIN_Terrain");

            migrationBuilder.DropTable(
                name: "ADMIN_TRAINING_LOCAL_CONTENT");

            migrationBuilder.DropTable(
                name: "ADMIN_TRAINING_NIGERIA_CONTENT");

            migrationBuilder.DropTable(
                name: "ADMIN_TYPE_OF_TEST");

            migrationBuilder.DropTable(
                name: "ADMIN_WASTE_MANAGEMENT_FACILITY");

            migrationBuilder.DropTable(
                name: "ADMIN_WELL_CATEGORIES");

            migrationBuilder.DropTable(
                name: "ADMIN_WELL_Trajectory");

            migrationBuilder.DropTable(
                name: "ADMIN_WELL_TYPE");

            migrationBuilder.DropTable(
                name: "ADMIN_WORK_PROGRAM_REPORT");

            migrationBuilder.DropTable(
                name: "ADMIN_WORK_PROGRAM_REPORT_History");

            migrationBuilder.DropTable(
                name: "ADMIN_WP_PENALTIES");

            migrationBuilder.DropTable(
                name: "ADMIN_WP_PENALTIES_AUDIT");

            migrationBuilder.DropTable(
                name: "ADMIN_WP_START_END_DATE");

            migrationBuilder.DropTable(
                name: "ADMIN_WP_START_END_DATE_AUDIT");

            migrationBuilder.DropTable(
                name: "ADMIN_WP_START_END_DATE_DATA_UPLOAD");

            migrationBuilder.DropTable(
                name: "ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT");

            migrationBuilder.DropTable(
                name: "ADMIN_YEAR");

            migrationBuilder.DropTable(
                name: "ADMIN_YES_NO");

            migrationBuilder.DropTable(
                name: "ApplicationCategories");

            migrationBuilder.DropTable(
                name: "ApplicationDeskHistories");

            migrationBuilder.DropTable(
                name: "ApplicationDocument");

            migrationBuilder.DropTable(
                name: "ApplicationProccesses");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationSBUApproval");

            migrationBuilder.DropTable(
                name: "Appraisal_Drilling");

            migrationBuilder.DropTable(
                name: "AuditTrails");

            migrationBuilder.DropTable(
                name: "BUDGET_ACTUAL_EXPENDITURE");

            migrationBuilder.DropTable(
                name: "BUDGET_CAPEX");

            migrationBuilder.DropTable(
                name: "BUDGET_CAPEX_OPEX");

            migrationBuilder.DropTable(
                name: "BUDGET_OPEX");

            migrationBuilder.DropTable(
                name: "BUDGET_PERFORMANCE_DEVELOPMENT_DRILLING_ACTIVITIES");

            migrationBuilder.DropTable(
                name: "BUDGET_PERFORMANCE_EXPLORATORY_ACTIVITIES");

            migrationBuilder.DropTable(
                name: "BUDGET_PERFORMANCE_FACILITIES_DEVELOPMENT_PROJECT");

            migrationBuilder.DropTable(
                name: "BUDGET_PERFORMANCE_PRODUCTION_COST");

            migrationBuilder.DropTable(
                name: "BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT");

            migrationBuilder.DropTable(
                name: "BudgetProposal");

            migrationBuilder.DropTable(
                name: "Class_Table");

            migrationBuilder.DropTable(
                name: "COMPANY_CONCESSIONS_FIELDS");

            migrationBuilder.DropTable(
                name: "COMPANY_FIELDS");

            migrationBuilder.DropTable(
                name: "CompletionJobs");

            migrationBuilder.DropTable(
                name: "CONCESSION_SITUATION");

            migrationBuilder.DropTable(
                name: "ConcessionSituation");

            migrationBuilder.DropTable(
                name: "ConcessionSituationTwo");

            migrationBuilder.DropTable(
                name: "Contract_Type");

            migrationBuilder.DropTable(
                name: "CSR");

            migrationBuilder.DropTable(
                name: "Data_Type");

            migrationBuilder.DropTable(
                name: "DECOMMISSIONING_ABANDONMENTs");

            migrationBuilder.DropTable(
                name: "DecommissioningAbandonment");

            migrationBuilder.DropTable(
                name: "Development_And_Productions");

            migrationBuilder.DropTable(
                name: "DevelopmentDrilling");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "DRILLING_EACH_WELL_COST");

            migrationBuilder.DropTable(
                name: "DRILLING_EACH_WELL_COST_PROPOSED");

            migrationBuilder.DropTable(
                name: "Drilling_Operations");

            migrationBuilder.DropTable(
                name: "DRILLING_OPERATIONS_");

            migrationBuilder.DropTable(
                name: "DRILLING_OPERATIONS_CATEGORIES_OF_WELLS");

            migrationBuilder.DropTable(
                name: "Exploration_Drilling");

            migrationBuilder.DropTable(
                name: "FACILITIES_PROJECT_PERFORMANCE");

            migrationBuilder.DropTable(
                name: "FacilityConstruction");

            migrationBuilder.DropTable(
                name: "FIELD_DEVELOPMENT_FIELDS_AND_STATUS");

            migrationBuilder.DropTable(
                name: "FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP");

            migrationBuilder.DropTable(
                name: "FIELD_DEVELOPMENT_PLAN");

            migrationBuilder.DropTable(
                name: "FIELD_DEVELOPMENT_PLAN_EXCESSIVE_RESERVES");

            migrationBuilder.DropTable(
                name: "GAS_PRODUCTION_ACTIVITIES");

            migrationBuilder.DropTable(
                name: "GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY");

            migrationBuilder.DropTable(
                name: "Gas_Production_Activity");

            migrationBuilder.DropTable(
                name: "Gas_Reserve_Update");

            migrationBuilder.DropTable(
                name: "GeographicalActivity");

            migrationBuilder.DropTable(
                name: "Geophysical_Activities");

            migrationBuilder.DropTable(
                name: "GEOPHYSICAL_ACTIVITIES_ACQUISITION");

            migrationBuilder.DropTable(
                name: "GEOPHYSICAL_ACTIVITIES_PROCESSING");

            migrationBuilder.DropTable(
                name: "HSE");

            migrationBuilder.DropTable(
                name: "HSE_ACCIDENT_INCIDENCE_REPORTING_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ASSET_REGISTER_TEMPLATE_PRESCRIPTIVE_EQUIPMENT_INSPECTION_STRATEGY_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ASSET_REGISTER_TEMPLATE_RBI_EQUIPMENT_INSPECTION_STRATEGY_NEW");

            migrationBuilder.DropTable(
                name: "HSE_CAUSES_OF_SPILL");

            migrationBuilder.DropTable(
                name: "HSE_CLIMATE_CHANGE_AND_AIR_QUALITY");

            migrationBuilder.DropTable(
                name: "HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST");

            migrationBuilder.DropTable(
                name: "HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW");

            migrationBuilder.DropTable(
                name: "HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW");

            migrationBuilder.DropTable(
                name: "HSE_DESIGNS_SAFETY");

            migrationBuilder.DropTable(
                name: "HSE_EFFLUENT_MONITORING_COMPLIANCE");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_CHEMICAL_USAGE_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTS");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_MANAGEMENT_PLAN");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_STUDIES_FIVE_YEAR_STRATEGIC_PLAN_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_STUDIES_NEW");

            migrationBuilder.DropTable(
                name: "HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED");

            migrationBuilder.DropTable(
                name: "HSE_FATALITIES");

            migrationBuilder.DropTable(
                name: "HSE_GHG_MANAGEMENT_PLAN");

            migrationBuilder.DropTable(
                name: "HSE_HOST_COMMUNITIES_DEVELOPMENT");

            migrationBuilder.DropTable(
                name: "HSE_INSPECTION_AND_MAINTENANCE_FACILITY_TYPE_NEW");

            migrationBuilder.DropTable(
                name: "HSE_INSPECTION_AND_MAINTENANCE_NEW");

            migrationBuilder.DropTable(
                name: "HSE_MANAGEMENT_POSITION");

            migrationBuilder.DropTable(
                name: "HSE_MinimumRequirement");

            migrationBuilder.DropTable(
                name: "HSE_OCCUPATIONAL_HEALTH_MANAGEMENT");

            migrationBuilder.DropTable(
                name: "HSE_OIL_SPILL_INCIDENT");

            migrationBuilder.DropTable(
                name: "HSE_OIL_SPILL_REPORTING_NEW");

            migrationBuilder.DropTable(
                name: "HSE_OPERATIONS_SAFETY_CASE");

            migrationBuilder.DropTable(
                name: "HSE_OSP_REGISTRATIONS_NEW");

            migrationBuilder.DropTable(
                name: "HSE_POINT_SOURCE_REGISTRATION");

            migrationBuilder.DropTable(
                name: "HSE_PRODUCED_WATER_MANAGEMENT_NEW");

            migrationBuilder.DropTable(
                name: "HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED");

            migrationBuilder.DropTable(
                name: "HSE_QUALITY_CONTROL");

            migrationBuilder.DropTable(
                name: "HSE_QUESTIONS");

            migrationBuilder.DropTable(
                name: "HSE_REMEDIATION_FUND");

            migrationBuilder.DropTable(
                name: "HSE_SAFETY_CULTURE_TRAINING");

            migrationBuilder.DropTable(
                name: "HSE_SAFETY_STUDIES_NEW");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Scholarships");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_MOU");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_SCHOLASHIP_SCHEME");

            migrationBuilder.DropTable(
                name: "HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME");

            migrationBuilder.DropTable(
                name: "HSE_TECHNICAL_SAFETY_CONTROL_STUDIES_NEW");

            migrationBuilder.DropTable(
                name: "HSE_WASTE_MANAGEMENT_DZs");

            migrationBuilder.DropTable(
                name: "HSE_WASTE_MANAGEMENT_NEW");

            migrationBuilder.DropTable(
                name: "HSE_WASTE_MANAGEMENT_SYSTEM");

            migrationBuilder.DropTable(
                name: "HSE_WASTE_MANAGEMENT_TYPE_OF_FACILITY_NEW");

            migrationBuilder.DropTable(
                name: "Initial_Well_Completion_Job");

            migrationBuilder.DropTable(
                name: "INITIAL_WELL_COMPLETION_JOBS");

            migrationBuilder.DropTable(
                name: "Legal");

            migrationBuilder.DropTable(
                name: "LEGAL_ARBITRATION");

            migrationBuilder.DropTable(
                name: "LEGAL_LITIGATION");

            migrationBuilder.DropTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES");

            migrationBuilder.DropTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training");

            migrationBuilder.DropTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate");

            migrationBuilder.DropTable(
                name: "LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Training");

            migrationBuilder.DropTable(
                name: "LocalContent");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MyDesks");

            migrationBuilder.DropTable(
                name: "NDPR_SUBSCRIPTION_FEE");

            migrationBuilder.DropTable(
                name: "NDR");

            migrationBuilder.DropTable(
                name: "NDR_Data_Population");

            migrationBuilder.DropTable(
                name: "NDR_DATA_POPULATION_ON_BLOCK_BASIS");

            migrationBuilder.DropTable(
                name: "NIGERIA_CONTENT");

            migrationBuilder.DropTable(
                name: "NIGERIA_CONTENT_QUESTION");

            migrationBuilder.DropTable(
                name: "NIGERIA_CONTENT_Training");

            migrationBuilder.DropTable(
                name: "NIGERIA_CONTENT_Upload_Succession_Plan");

            migrationBuilder.DropTable(
                name: "NigerianContent");

            migrationBuilder.DropTable(
                name: "OIL_AND_GAS_FACILITY_MAINTENANCE");

            migrationBuilder.DropTable(
                name: "OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE");

            migrationBuilder.DropTable(
                name: "OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECTS");

            migrationBuilder.DropTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES");

            migrationBuilder.DropTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_FIVE_YEAR_PROJECTION");

            migrationBuilder.DropTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities");

            migrationBuilder.DropTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED");

            migrationBuilder.DropTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment");

            migrationBuilder.DropTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities");

            migrationBuilder.DropTable(
                name: "OIL_CONDENSATE_PRODUCTION_ACTIVITIES_UNITIZATION");

            migrationBuilder.DropTable(
                name: "OilCondensateProduction");

            migrationBuilder.DropTable(
                name: "OilSpill_Incident");

            migrationBuilder.DropTable(
                name: "PermitApprovals");

            migrationBuilder.DropTable(
                name: "PICTURE_UPLOAD_COMMUNITY_DEVELOPMENT_PROJECTS");

            migrationBuilder.DropTable(
                name: "Planning_MinimumRequirement");

            migrationBuilder.DropTable(
                name: "PRESENTATION_UPLOAD");

            migrationBuilder.DropTable(
                name: "ProcessActions");

            migrationBuilder.DropTable(
                name: "ProcessStatuses");

            migrationBuilder.DropTable(
                name: "Reserve_Update_Oil_Condensate");

            migrationBuilder.DropTable(
                name: "RESERVES_REPLACEMENT_RATIO");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_DEPLETION_RATE");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_LIFE_INDEX");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Company_Annual_PRODUCTION");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_MMBBL");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_Reserves_DECLINE");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE");

            migrationBuilder.DropTable(
                name: "RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE");

            migrationBuilder.DropTable(
                name: "RoleFunctionalityRef");

            migrationBuilder.DropTable(
                name: "ROLES_");

            migrationBuilder.DropTable(
                name: "ROLES_SUPER_ADMIN");

            migrationBuilder.DropTable(
                name: "Royalty");

            migrationBuilder.DropTable(
                name: "SafetyManagement");

            migrationBuilder.DropTable(
                name: "SBU_ApplicationComments");

            migrationBuilder.DropTable(
                name: "SBU_Records");

            migrationBuilder.DropTable(
                name: "SBU_Submission");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "STRATEGIC_PLANS_ON_COMPANY_BASIS");

            migrationBuilder.DropTable(
                name: "StrategicBusinessUnits");

            migrationBuilder.DropTable(
                name: "SubmittedDocuments");

            migrationBuilder.DropTable(
                name: "SubstainableDevelopment");

            migrationBuilder.DropTable(
                name: "Table_1");

            migrationBuilder.DropTable(
                name: "Table_Details");

            migrationBuilder.DropTable(
                name: "tbl_fruitanalysis");

            migrationBuilder.DropTable(
                name: "TrainingForStaff");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserMaster");

            migrationBuilder.DropTable(
                name: "WORK_PROGRAM_FLOW");

            migrationBuilder.DropTable(
                name: "WorkOverJobs");

            migrationBuilder.DropTable(
                name: "WorkOvers_Recompletion_Job");

            migrationBuilder.DropTable(
                name: "WorkOvers_Recompletion_Job_Field_Dvelopment_Plans");

            migrationBuilder.DropTable(
                name: "WORKOVERS_RECOMPLETION_JOBS");

            migrationBuilder.DropTable(
                name: "Functionality");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
