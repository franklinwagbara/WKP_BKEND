﻿CREATE TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION] (
    [Id]                                                          INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                                      VARCHAR (200) NULL,
    [OML_Name]                                                    VARCHAR (200) NULL,
    [CompanyName]                                                 VARCHAR (500) NULL,
    [Companyemail]                                                VARCHAR (500) NULL,
    [Year_of_WP]                                                  VARCHAR (100) NULL,
    [Have_you_submitted_all_MoUs_to_DPR]                          VARCHAR (500) NULL,
    [If_NO_why]                                                   VARCHAR (500) NULL,
    [Do_you_have_an_MOU_with_the_communities_for_all_your_assets] VARCHAR (500) NULL,
    [Created_by]                                                  VARCHAR (100) NULL,
    [Updated_by]                                                  VARCHAR (100) NULL,
    [Date_Created]                                                DATETIME      NULL,
    [Date_Updated]                                                DATETIME      NULL,
    [Terrain]                                                     VARCHAR (50)  NULL,
    [Consession_Type]                                             VARCHAR (50)  NULL,
    [Contract_Type]                                               VARCHAR (50)  NULL,
    [MOUResponderFilePath]                                        VARCHAR (200) NULL,
    [MOUOSCPFilePath]                                             VARCHAR (200) NULL,
    [MOUResponderFilename]                                        VARCHAR (100) NULL,
    [MOUOSCPFilename]                                             VARCHAR (100) NULL,
    [MOUResponderInPlace]                                         VARCHAR (50)  NULL,
    [COMPANY_ID]                                                  VARCHAR (100) NULL,
    [CompanyNumber]                                               INT           NULL,
    [Field_ID]                                                    INT           NULL,
    CONSTRAINT [PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_QUESTION] PRIMARY KEY CLUSTERED ([Id] ASC)
);



