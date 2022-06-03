﻿CREATE TABLE [dbo].[HSE_FATALITIES] (
    [Id]                       INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                   VARCHAR (200) NULL,
    [OML_Name]                 VARCHAR (200) NULL,
    [CompanyName]              VARCHAR (500) NULL,
    [Companyemail]             VARCHAR (500) NULL,
    [Year_of_WP]               VARCHAR (100) NULL,
    [Current_year_DATA]        VARCHAR (500) NULL,
    [Proposed_year_DATA]       VARCHAR (500) NULL,
    [Current_year]             VARCHAR (500) NULL,
    [Proposed_year]            VARCHAR (500) NULL,
    [Fatalities_Type]          VARCHAR (500) NULL,
    [Fatalities_Proposed_year] VARCHAR (500) NULL,
    [Fatalities_Current_year]  VARCHAR (500) NULL,
    [Created_by]               VARCHAR (100) NULL,
    [Updated_by]               VARCHAR (100) NULL,
    [Date_Created]             DATETIME      NULL,
    [Date_Updated]             DATETIME      NULL,
    [type_of_incidence]        VARCHAR (50)  NULL,
    [Terrain]                  VARCHAR (50)  NULL,
    [Contract_Type]            VARCHAR (50)  NULL,
    [Consession_Type]          VARCHAR (50)  NULL,
    [COMPANY_ID]               VARCHAR (100) NULL,
        [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_HSE_FATALITIES] PRIMARY KEY CLUSTERED ([Id] ASC)
);

