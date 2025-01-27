﻿CREATE TABLE [dbo].[HSE_ENVIRONMENTAL_STUDIES_NEW] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                    VARCHAR (200)  NULL,
    [OML_Name]                  VARCHAR (200)  NULL,
    [CompanyName]               VARCHAR (500)  NULL,
    [Companyemail]              VARCHAR (500)  NULL,
    [Year_of_WP]                VARCHAR (100)  NULL,
    [ACTUAL_year]               VARCHAR (500)  NULL,
    [PROPOSED_year]             VARCHAR (500)  NULL,
    [Any_Environmental_Studies] VARCHAR (3999) NULL,
    [If_YES_state_Project_Name] VARCHAR (3900) NULL,
    [Status_]                   VARCHAR (3999) NULL,
    [If_Ongoing]                VARCHAR (3900) NULL,
    [Created_by]                VARCHAR (100)  NULL,
    [Updated_by]                VARCHAR (100)  NULL,
    [Date_Created]              DATETIME       NULL,
    [Date_Updated]              DATETIME       NULL,
    [Terrain]                   VARCHAR (50)   NULL,
    [Contract_Type]             VARCHAR (50)   NULL,
    [Consession_Type]           VARCHAR (50)   NULL,
    [COMPANY_ID]                VARCHAR (100)  NULL,
    [CompanyNumber]             INT            NULL,
    [Field_ID]                  INT            NULL,
    [Field_Name] NVARCHAR(MAX) NULL, 
    [NUPRC_Approval_Status] NVARCHAR(100) NULL, 
    CONSTRAINT [PK_HSE_ENVIRONMENTAL_STUDIES_NEW] PRIMARY KEY CLUSTERED ([Id] ASC)
);

