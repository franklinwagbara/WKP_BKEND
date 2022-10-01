﻿CREATE TABLE [dbo].[OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE] (
    [Id]                                          INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                      VARCHAR (200) NULL,
    [OML_Name]                                    VARCHAR (200) NULL,
    [CompanyName]                                 VARCHAR (500) NULL,
    [Companyemail]                                VARCHAR (500) NULL,
    [Year_of_WP]                                  VARCHAR (100) NULL,
    [Actual_capital_expenditure_Current_year]     VARCHAR (500) NULL,
    [Proposed_Capital_Expenditure]                VARCHAR (500) NULL,
    [Remarks]                                     VARCHAR (500) NULL,
    [Actual_year]                                 VARCHAR (500) NULL,
    [Proposed_year]                               VARCHAR (500) NULL,
    [Created_by]                                  VARCHAR (100) NULL,
    [Updated_by]                                  VARCHAR (100) NULL,
    [Date_Created]                                DATETIME      NULL,
    [Date_Updated]                                DATETIME      NULL,
    [Actual_capital_expenditure_Current_year_NGN] VARCHAR (50)  NULL,
    [Actual_capital_expenditure_Current_year_USD] VARCHAR (50)  NULL,
    [Proposed_Capital_Expenditure_NGN]            VARCHAR (50)  NULL,
    [Proposed_Capital_Expenditure_USD]            VARCHAR (50)  NULL,
    [Contract_Type]                               VARCHAR (50)  NULL,
    [Terrain]                                     VARCHAR (50)  NULL,
    [Consession_Type]                             VARCHAR (50)  NULL,
    [COMPANY_ID]                                  VARCHAR (100) NULL,
    [CompanyNumber]                               INT           NULL,
<<<<<<< HEAD
    CONSTRAINT [PK_OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

=======
    [Field_ID]                                    INT           NULL,
    CONSTRAINT [PK_OIL_AND_GAS_FACILITY_MAINTENANCE_EXPENDITURE] PRIMARY KEY CLUSTERED ([Id] ASC)
);



>>>>>>> origin/main
