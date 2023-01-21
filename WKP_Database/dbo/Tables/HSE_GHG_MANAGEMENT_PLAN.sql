﻿CREATE TABLE [dbo].[HSE_GHG_MANAGEMENT_PLAN] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [OmL_Name]                VARCHAR (100)  NULL,
    [OmL_ID]                  VARCHAR (100)  NULL,
    [CompanyName]             VARCHAR (1000) NULL,
    [companyemail]            VARCHAR (100)  NULL,
    [Year_of_WP]              VARCHAR (50)   NULL,
    [CompanY_ID]              VARCHAR (50)   NULL,
    [CompanyNumber]           INT            NULL,
    [DoYouHaveGHG]            VARCHAR (10)   NULL,
    [GHGApprovalFilename]     VARCHAR (1000) NULL,
    [GHGApprovalPath]         VARCHAR (5000) NULL,
    [ReasonForNoGHG]          VARCHAR (5000) NULL,
    [DoYouHaveLDRCertificate] VARCHAR (10)   NULL,
    [LDRCertificateFilename]  VARCHAR (1000) NULL,
    [LDRCertificatePath]      VARCHAR (5000) NULL,
    [ReasonForNoLDR]          VARCHAR (3000) NULL,
    [Date_Updated]            DATETIME       NULL,
    [Updated_by]              VARCHAR (100)  NULL,
    [Date_Created]            DATETIME       NULL,
    [Created_by]              VARCHAR (100)  NULL,
    [Field_ID]                INT            NULL,
    CONSTRAINT [PK_HSE_GHG_MANAGEMENT_PLAN] PRIMARY KEY CLUSTERED ([Id] ASC)
);



