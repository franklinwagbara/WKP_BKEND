﻿CREATE TABLE [dbo].[BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT] (
    [Id]                                                              INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                                          VARCHAR (200) NULL,
    [OML_Name]                                                        VARCHAR (200) NULL,
    [CompanyName]                                                     VARCHAR (500) NULL,
    [Companyemail]                                                    VARCHAR (500) NULL,
    [Year_of_WP]                                                      VARCHAR (100) NULL,
    [Year_of_Proposal]                                                VARCHAR (500) NULL,
    [Budget_for_Direct_Exploration_and_Production_Activities_Naira]   VARCHAR (500) NULL,
    [Budget_for_Direct_Exploration_and_Production_Activities_Dollars] VARCHAR (500) NULL,
    [Budget_for_other_Activities_Naira]                               VARCHAR (500) NULL,
    [Budget_for_other_Activities_Dollars]                             VARCHAR (500) NULL,
    [Total_Company_Expenditure_Dollars]                               VARCHAR (500) NULL,
    [Actual_year]                                                     VARCHAR (100) NULL,
    [Proposed_year]                                                   VARCHAR (100) NULL,
    [Created_by]                                                      VARCHAR (100) NULL,
    [Updated_by]                                                      VARCHAR (100) NULL,
    [Date_Created]                                                    DATETIME      NULL,
    [Date_Updated]                                                    DATETIME      NULL,
    [Contract_Type]                                                   VARCHAR (50)  NULL,
    [Terrain]                                                         VARCHAR (50)  NULL,
    [Consession_Type]                                                 VARCHAR (50)  NULL,
    [COMPANY_ID]                                                      VARCHAR (100) NULL,
    [CompanyNumber]                                                   INT           NULL,
<<<<<<< HEAD
    CONSTRAINT [PK_BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT] PRIMARY KEY CLUSTERED ([Id] ASC)
);

=======
    [Field_ID]                                                        INT           NULL,
    CONSTRAINT [PK_BUDGET_PROPOSAL_IN_NAIRA_AND_DOLLAR_COMPONENT] PRIMARY KEY CLUSTERED ([Id] ASC)
);



>>>>>>> origin/main
