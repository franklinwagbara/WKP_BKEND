﻿CREATE TABLE [dbo].[HSE_DESIGNS_SAFETY] (
    [Id]                           INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                       VARCHAR (200) NULL,
    [OML_Name]                     VARCHAR (200) NULL,
    [CompanyName]                  VARCHAR (500) NULL,
    [Companyemail]                 VARCHAR (500) NULL,
    [Year_of_WP]                   VARCHAR (100) NULL,
    [Current_year]                 VARCHAR (500) NULL,
    [Proposed_year]                VARCHAR (500) NULL,
    [DESIGNS_SAFETY_Type]          VARCHAR (500) NULL,
    [DESIGNS_SAFETY_Proposed_year] VARCHAR (500) NULL,
    [DESIGNS_SAFETY_Current_year]  VARCHAR (500) NULL,
    [Created_by]                   VARCHAR (100) NULL,
    [Updated_by]                   VARCHAR (100) NULL,
    [Date_Created]                 DATETIME      NULL,
    [Date_Updated]                 DATETIME      NULL,
    [Terrain]                      VARCHAR (50)  NULL,
    [Consession_Type]              VARCHAR (50)  NULL,
    [Contract_Type]                VARCHAR (50)  NULL,
    [COMPANY_ID]                   VARCHAR (100) NULL,
        [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_HSE_DESIGNS_SAFETY] PRIMARY KEY CLUSTERED ([Id] ASC)
);

