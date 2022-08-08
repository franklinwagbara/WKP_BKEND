﻿CREATE TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_MMBBL] (
    [Id]                              INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                          VARCHAR (200) NULL,
    [OML_Name]                        VARCHAR (200) NULL,
    [CompanyName]                     VARCHAR (500) NULL,
    [Companyemail]                    VARCHAR (500) NULL,
    [Year_of_WP]                      VARCHAR (100) NULL,
    [Reserves_as_at_MMbbl_P1]         VARCHAR (500) NULL,
    [Additional_Reserves_as_at_]      VARCHAR (500) NULL,
    [Total_Production_]               VARCHAR (500) NULL,
    [Reserves_as_at_MMbbl]            VARCHAR (500) NULL,
    [Created_by]                      VARCHAR (100) NULL,
    [Updated_by]                      VARCHAR (100) NULL,
    [Date_Created]                    DATETIME      NULL,
    [Date_Updated]                    DATETIME      NULL,
    [Reserves_as_at_MMbbl_condensate] VARCHAR (50)  NULL,
    [Reserves_as_at_MMbbl_gas]        VARCHAR (50)  NULL,
    [Consession_Type]                 VARCHAR (50)  NULL,
    [Contract_Type]                   VARCHAR (50)  NULL,
    [Terrain]                         VARCHAR (50)  NULL,
    [CompanyNumber]                   INT           NULL,
    [Field_ID]                        INT           NULL,
    CONSTRAINT [PK_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL] PRIMARY KEY CLUSTERED ([Id] ASC)
);



