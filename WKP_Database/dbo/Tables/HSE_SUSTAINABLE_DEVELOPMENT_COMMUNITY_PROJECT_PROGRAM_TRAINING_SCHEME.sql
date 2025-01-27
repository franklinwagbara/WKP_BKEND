﻿CREATE TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME] (
    [Id]                          INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                      VARCHAR (200)  NULL,
    [OML_Name]                    VARCHAR (200)  NULL,
    [CompanyName]                 VARCHAR (500)  NULL,
    [Companyemail]                VARCHAR (500)  NULL,
    [Year_of_WP]                  VARCHAR (100)  NULL,
    [NameOfCommunity]             VARCHAR (3000) NULL,
    [Year_GMou_was_signed]        VARCHAR (20)   NULL,
    [TrainingYear]                VARCHAR (20)   NULL,
    [ComponentOfTraining]         VARCHAR (3000) NULL,
    [Actual_Budget_Total_Dollars] VARCHAR (500)  NULL,
    [StatusOfTraining]            VARCHAR (500)  NULL,
    [TSUploadFilePath]            VARCHAR (500)  NULL,
    [Created_by]                  VARCHAR (100)  NULL,
    [Updated_by]                  VARCHAR (100)  NULL,
    [Date_Created]                DATETIME       NULL,
    [Date_Updated]                DATETIME       NULL,
    [Consession_Type]             VARCHAR (50)   NULL,
    [Terrain]                     VARCHAR (50)   NULL,
    [Contract_Type]               VARCHAR (50)   NULL,
    [TSUploadFilename]            VARCHAR (500)  NULL,
    [COMPANY_ID]                  VARCHAR (100)  NULL,
    [CompanyNumber]               INT            NULL,
    [Field_ID]                    INT            NULL,
    [Actual_Budget_Total_Naira]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_TRAINING_SCHEME] PRIMARY KEY CLUSTERED ([Id] ASC)
);



