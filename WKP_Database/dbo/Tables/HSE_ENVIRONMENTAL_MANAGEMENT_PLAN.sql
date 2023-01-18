﻿CREATE TABLE [dbo].[HSE_ENVIRONMENTAL_MANAGEMENT_PLAN] (
    [Id]               INT            NOT NULL,
    [Field_ID]         INT            NULL,
    [OML_Name]         VARCHAR (1000) NULL,
    [OmL_ID]           VARCHAR (100)  NULL,
    [CompanyName]      VARCHAR (200)  NULL,
    [Companyemail]     VARCHAR (100)  NULL,
    [Year_of_WP]       VARCHAR (30)   NULL,
    [COMPANY_ID]       VARCHAR (30)   NULL,
    [CompanyNumber]    INT            NULL,
    [AreThereEMP]      VARCHAR (10)   NULL,
    [FacilityType]     VARCHAR (100)  NULL,
    [FacilityLocation] VARCHAR (200)  NULL,
    [RemarkIfNoEMP]    VARCHAR (500)  NULL,
    [Date_Updated]     DATETIME       NULL,
    [Updated_by]       VARCHAR (100)  NULL,
    [Date_Created]     DATETIME       NULL,
    [Created_by]       VARCHAR (100)  NULL,
    CONSTRAINT [PK_HSE_ENVIRONMENTAL_MANAGEMENT_PLAN] PRIMARY KEY CLUSTERED ([Id] ASC)
);

