﻿CREATE TABLE [dbo].[HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]          VARCHAR (200)  NULL,
    [OML_Name]        VARCHAR (200)  NULL,
    [CompanyName]     VARCHAR (500)  NULL,
    [Companyemail]    VARCHAR (500)  NULL,
    [Year_of_WP]      VARCHAR (100)  NULL,
    [ACTUAL_year]     VARCHAR (500)  NULL,
    [PROPOSED_year]   VARCHAR (500)  NULL,
    [Type_of_Report]  VARCHAR (3999) NULL,
    [Quarter_1]       VARCHAR (3900) NULL,
    [Quarter_2]       VARCHAR (3999) NULL,
    [Quarter_3]       VARCHAR (3999) NULL,
    [Quarter_4]       VARCHAR (3900) NULL,
    [Created_by]      VARCHAR (100)  NULL,
    [Updated_by]      VARCHAR (100)  NULL,
    [Date_Created]    DATETIME       NULL,
    [Date_Updated]    DATETIME       NULL,
    [Consession_Type] VARCHAR (50)   NULL,
    [Contract_Type]   VARCHAR (50)   NULL,
    [Terrain]         VARCHAR (50)   NULL,
    [CompanyNumber]   INT            NULL,
    [Field_ID]        INT            NULL,
    CONSTRAINT [PK_HSE_ENVIRONMENTAL_COMPLIANCE_MONITORING_TYPE_OF_REPORT_NEW] PRIMARY KEY CLUSTERED ([Id] ASC)
);



