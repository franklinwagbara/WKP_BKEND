﻿CREATE TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL] (
    [Id]                              INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                          VARCHAR (200) NULL,
    [OML_Name]                        VARCHAR (200) NULL,
    [CompanyName]                     VARCHAR (500) NULL,
    [Companyemail]                    VARCHAR (500) NULL,
    [Year_of_WP]                      VARCHAR (100) NULL,
    [ACTUAL_year]                     VARCHAR (500) NULL,
    [PROPOSED_year]                   VARCHAR (500) NULL,
    [Description_of_Projects_Planned] VARCHAR (MAX) NULL,
    [Description_of_Projects_Actual]  VARCHAR (MAX) NULL,
    [Created_by]                      VARCHAR (100) NULL,
    [Updated_by]                      VARCHAR (100) NULL,
    [Date_Created]                    DATETIME      NULL,
    [Date_Updated]                    DATETIME      NULL,
    [Consession_Type]                 VARCHAR (50)  NULL,
    [Contract_Type]                   VARCHAR (50)  NULL,
    [Terrain]                         VARCHAR (50)  NULL,
    [COMPANY_ID]                      VARCHAR (100) NULL,
    [CompanyNumber]                   INT           NULL,
<<<<<<< HEAD
    CONSTRAINT [PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL] PRIMARY KEY CLUSTERED ([Id] ASC)
);

=======
    [Field_ID]                        INT           NULL,
    CONSTRAINT [PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_PLANNED_AND_ACTUAL] PRIMARY KEY CLUSTERED ([Id] ASC)
);



>>>>>>> origin/main
