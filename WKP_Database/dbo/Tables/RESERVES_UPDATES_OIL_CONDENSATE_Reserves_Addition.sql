﻿CREATE TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition] (
    [Id]                                               INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                           VARCHAR (200) NULL,
    [OML_Name]                                         VARCHAR (200) NULL,
    [CompanyName]                                      VARCHAR (500) NULL,
    [Companyemail]                                     VARCHAR (500) NULL,
    [Year_of_WP]                                       VARCHAR (100) NULL,
    [Reserves_Addition_Was_there_any_Reserve_Addition] VARCHAR (500) NULL,
    [Reserves_Addition_Reason_for_Addition]            VARCHAR (500) NULL,
    [Reserves_Addition_Oil]                            VARCHAR (500) NULL,
    [Reserves_Addition_Condensate]                     VARCHAR (500) NULL,
    [Reserves_Addition_AG]                             VARCHAR (100) NULL,
    [Reserves_Addition_NAG]                            VARCHAR (500) NULL,
    [Created_by]                                       VARCHAR (100) NULL,
    [Updated_by]                                       VARCHAR (100) NULL,
    [Date_Created]                                     DATETIME      NULL,
    [Date_Updated]                                     DATETIME      NULL,
    [Contract_Type]                                    VARCHAR (50)  NULL,
    [Consession_Type]                                  VARCHAR (50)  NULL,
    [Terrain]                                          VARCHAR (50)  NULL,
    [COMPANY_ID]                                       VARCHAR (100) NULL,
        [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition] PRIMARY KEY CLUSTERED ([Id] ASC)
);

