﻿CREATE TABLE [dbo].[HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED] (
    [Id]                                INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                            VARCHAR (200)  NULL,
    [OML_Name]                          VARCHAR (200)  NULL,
    [CompanyName]                       VARCHAR (500)  NULL,
    [Companyemail]                      VARCHAR (500)  NULL,
    [Year_of_WP]                        VARCHAR (100)  NULL,
    [FIELD_NAME]                        VARCHAR (500)  NULL,
    [Concession]                        VARCHAR (500)  NULL,
    [facilities]                        VARCHAR (3999) NULL,
    [DEPTH_AND_DISTANCE_FROM_SHORELINE] VARCHAR (3900) NULL,
    [Produced_water_volumes]            VARCHAR (3999) NULL,
    [Disposal_philosophy]               VARCHAR (3900) NULL,
    [DPR_APPROVAL_STATUS]               VARCHAR (3999) NULL,
    [Created_by]                        VARCHAR (100)  NULL,
    [Updated_by]                        VARCHAR (100)  NULL,
    [Date_Created]                      DATETIME       NULL,
    [Date_Updated]                      DATETIME       NULL,
    [Contract_Type]                     VARCHAR (50)   NULL,
    [Terrain]                           VARCHAR (50)   NULL,
    [Consession_Type]                   VARCHAR (50)   NULL,
    [COMPANY_ID]                        VARCHAR (100)  NULL,
    [CompanyNumber]                     INT            NULL,
    [Field_ID]                          INT            NULL,
    CONSTRAINT [PK_HSE_PRODUCED_WATER_MANAGEMENT_NEW_UPDATED] PRIMARY KEY CLUSTERED ([Id] ASC)
);



