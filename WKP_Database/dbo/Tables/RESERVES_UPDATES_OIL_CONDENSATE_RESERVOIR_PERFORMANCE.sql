﻿CREATE TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE] (
    [Id]                                       INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                   VARCHAR (200) NULL,
    [OML_Name]                                 VARCHAR (200) NULL,
    [CompanyName]                              VARCHAR (500) NULL,
    [Companyemail]                             VARCHAR (500) NULL,
    [Year_of_WP]                               VARCHAR (100) NULL,
    [Reservoir_Performance_Timeline]           VARCHAR (500) NULL,
    [Reservoir_Performance_Reservoir]          VARCHAR (500) NULL,
    [Reservoir_Performance_Reservoir_Pressure] VARCHAR (500) NULL,
    [Reservoir_Performance_WCT]                VARCHAR (100) NULL,
    [Reservoir_Performance_GOR]                VARCHAR (500) NULL,
    [Reservoir_Performance_Sand_Cut]           VARCHAR (500) NULL,
    [Created_by]                               VARCHAR (100) NULL,
    [Updated_by]                               VARCHAR (100) NULL,
    [Date_Created]                             DATETIME      NULL,
    [Date_Updated]                             DATETIME      NULL,
    [Contract_Type]                            VARCHAR (50)  NULL,
    [Terrain]                                  VARCHAR (50)  NULL,
    [Consession_Type]                          VARCHAR (50)  NULL,
        [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_RESERVES_UPDATES_OIL_CONDENSATE_RESERVOIR_PERFORMANCE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

