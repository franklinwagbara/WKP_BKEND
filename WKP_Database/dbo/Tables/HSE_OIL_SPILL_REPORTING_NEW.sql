﻿CREATE TABLE [dbo].[HSE_OIL_SPILL_REPORTING_NEW] (
    [Id]                              INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                          VARCHAR (200)  NULL,
    [OML_Name]                        VARCHAR (200)  NULL,
    [CompanyName]                     VARCHAR (500)  NULL,
    [Companyemail]                    VARCHAR (500)  NULL,
    [Year_of_WP]                      VARCHAR (100)  NULL,
    [Incident_Oil_Spill_Ref_No]       VARCHAR (500)  NULL,
    [Facility_Equipment]              VARCHAR (500)  NULL,
    [Location]                        VARCHAR (3999) NULL,
    [LGA]                             VARCHAR (3900) NULL,
    [State_]                          VARCHAR (3999) NULL,
    [Date_of_Spill]                   DATETIME       NULL,
    [Type_of_operation_at_spill_site] VARCHAR (3999) NULL,
    [Cause_of_spill]                  VARCHAR (3999) NULL,
    [Volume_of_spill_bbls]            VARCHAR (3999) NULL,
    [Volume_recovered_bbls]           VARCHAR (3999) NULL,
    [Created_by]                      VARCHAR (100)  NULL,
    [Updated_by]                      VARCHAR (100)  NULL,
    [Date_Created]                    DATETIME       NULL,
    [Date_Updated]                    DATETIME       NULL,
    [Terrain]                         VARCHAR (50)   NULL,
    [Consession_Type]                 VARCHAR (50)   NULL,
    [Contract_Type]                   VARCHAR (50)   NULL,
    [COMPANY_ID]                      VARCHAR (100)  NULL,
    [CompanyNumber]                   INT            NULL,
    [Field_ID]                        INT            NULL,
    CONSTRAINT [PK_HSE_OIL_SPILL_REPORTING_NEW] PRIMARY KEY CLUSTERED ([Id] ASC)
);



