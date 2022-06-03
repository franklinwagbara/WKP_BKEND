﻿CREATE TABLE [dbo].[BUDGET_ACTUAL_EXPENDITURE] (
    [Id]                                                          INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                                      VARCHAR (200) NULL,
    [OML_Name]                                                    VARCHAR (200) NULL,
    [CompanyName]                                                 VARCHAR (500) NULL,
    [Companyemail]                                                VARCHAR (500) NULL,
    [Year_of_WP]                                                  VARCHAR (100) NULL,
    [Budget_for_Direct_Exploration_and_Production_Activities]     VARCHAR (500) NULL,
    [Budget_for_other_Activities]                                 VARCHAR (500) NULL,
    [Equivalent_Naira_and_Dollar_Component_]                      VARCHAR (500) NULL,
    [Actual_year]                                                 VARCHAR (100) NULL,
    [Proposed_year]                                               VARCHAR (100) NULL,
    [Created_by]                                                  VARCHAR (100) NULL,
    [Updated_by]                                                  VARCHAR (100) NULL,
    [Date_Created]                                                DATETIME      NULL,
    [Date_Updated]                                                DATETIME      NULL,
    [Budget_for_Direct_Exploration_and_Production_Activities_NGN] VARCHAR (50)  NULL,
    [Budget_for_Direct_Exploration_and_Production_Activities_USD] VARCHAR (50)  NULL,
    [Budget_for_other_Activities_NGN]                             VARCHAR (50)  NULL,
    [Budget_for_other_Activities_USD]                             VARCHAR (50)  NULL,
    [Equivalent_Naira_and_Dollar_Component_NGN]                   VARCHAR (50)  NULL,
    [Equivalent_Naira_and_Dollar_Component_USD]                   VARCHAR (50)  NULL,
    [Contract_Type]                                               VARCHAR (50)  NULL,
    [Terrain]                                                     VARCHAR (50)  NULL,
    [Consession_Type]                                             VARCHAR (50)  NULL,
    [COMPANY_ID]                                                  VARCHAR (100) NULL,
            [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_BUDGET_ACTUAL_EXPENDITURE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

