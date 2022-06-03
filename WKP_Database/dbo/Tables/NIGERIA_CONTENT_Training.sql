﻿CREATE TABLE [dbo].[NIGERIA_CONTENT_Training] (
    [Id]                         INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                     VARCHAR (200) NULL,
    [OML_Name]                   VARCHAR (200) NULL,
    [CompanyName]                VARCHAR (500) NULL,
    [Companyemail]               VARCHAR (500) NULL,
    [Year_of_WP]                 VARCHAR (100) NULL,
    [Training_]                  VARCHAR (500) NULL,
    [Local_]                     VARCHAR (500) NULL,
    [Foreign_]                   VARCHAR (500) NULL,
    [Created_by]                 VARCHAR (100) NULL,
    [Updated_by]                 VARCHAR (100) NULL,
    [Date_Created]               DATETIME      NULL,
    [Date_Updated]               DATETIME      NULL,
    [Expatriate_quota_positions] VARCHAR (50)  NULL,
    [Utilized_EQ]                VARCHAR (50)  NULL,
    [Nigerian_Understudies]      VARCHAR (50)  NULL,
    [Management_Foriegn]         VARCHAR (50)  NULL,
    [Management_Local]           VARCHAR (50)  NULL,
    [Staff_Foriegn]              VARCHAR (50)  NULL,
    [Staff_Local]                VARCHAR (50)  NULL,
    [Actual_Proposed]            VARCHAR (50)  NULL,
    [Actual_Proposed_Year]       VARCHAR (50)  NULL,
    [Consession_Type]            VARCHAR (50)  NULL,
    [Contract_Type]              VARCHAR (50)  NULL,
    [Terrain]                    VARCHAR (50)  NULL,
    [COMPANY_ID]                 VARCHAR (100) NULL,
        [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_NIGERIA_CONTENT_Training] PRIMARY KEY CLUSTERED ([Id] ASC)
);

