﻿CREATE TABLE [dbo].[NDPR_SUBSCRIPTION_FEE] (
    [Id]                                        INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                    VARCHAR (200) NULL,
    [OML_Name]                                  VARCHAR (200) NULL,
    [CompanyName]                               VARCHAR (500) NULL,
    [Companyemail]                              VARCHAR (500) NULL,
    [Year_of_WP]                                VARCHAR (100) NULL,
    [Has_annual_NDR_subscription_fee_been_paid] VARCHAR (500) NULL,
    [Did_you_process_data_for_current_year]     VARCHAR (500) NULL,
    [Data_Type]                                 VARCHAR (500) NULL,
    [Volume_of_data_processed]                  VARCHAR (500) NULL,
    [Actual_year]                               VARCHAR (500) NULL,
    [Proposed_year]                             VARCHAR (500) NULL,
    [Created_by]                                VARCHAR (100) NULL,
    [Updated_by]                                VARCHAR (100) NULL,
    [Date_Created]                              DATETIME      NULL,
    [Date_Updated]                              DATETIME      NULL,
    [Contract_Type]                             VARCHAR (50)  NULL,
    [Terrain]                                   VARCHAR (50)  NULL,
    [Consession_Type]                           VARCHAR (50)  NULL,
    [CompanyNumber]                             INT           NULL,
    CONSTRAINT [PK_NDPR_SUBSCRIPTION_FEE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

