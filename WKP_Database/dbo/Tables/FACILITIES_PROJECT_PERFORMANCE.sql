﻿CREATE TABLE [dbo].[FACILITIES_PROJECT_PERFORMANCE] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]             VARCHAR (200) NULL,
    [OML_Name]           VARCHAR (200) NULL,
    [CompanyName]        VARCHAR (500) NULL,
    [Companyemail]       VARCHAR (500) NULL,
    [Year_of_WP]         VARCHAR (100) NULL,
    [List_of_Projects]   VARCHAR (500) NULL,
    [Planned_completion] VARCHAR (500) NULL,
    [Actual_completion]  VARCHAR (500) NULL,
    [FLAG]               VARCHAR (500) NULL,
    [Created_by]         VARCHAR (100) NULL,
    [Updated_by]         VARCHAR (100) NULL,
    [Date_Created]       DATETIME      NULL,
    [Date_Updated]       DATETIME      NULL,
    [Contract_Type]      VARCHAR (50)  NULL,
    [Terrain]            VARCHAR (50)  NULL,
    [Consession_Type]    VARCHAR (50)  NULL,
    [COMPANY_ID]         VARCHAR (100) NULL,
    [CompanyNumber]      INT           NULL,
    [Field_ID]           INT           NULL,
    CONSTRAINT [PK_FACILITIES_PROJECT_PERFORMANCE] PRIMARY KEY CLUSTERED ([Id] ASC)
);



