CREATE TABLE [dbo].[RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE] (
    [Id]                                   INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                               VARCHAR (200) NULL,
    [OML_Name]                             VARCHAR (200) NULL,
    [CompanyName]                          VARCHAR (500) NULL,
    [Companyemail]                         VARCHAR (500) NULL,
    [Year_of_WP]                           VARCHAR (100) NULL,
    [Company_Reserves_Year]                VARCHAR (500) NULL,
    [Company_Reserves_Oil]                 VARCHAR (500) NULL,
    [Company_Reserves_Condensate]          VARCHAR (500) NULL,
    [Company_Reserves_AG]                  VARCHAR (100) NULL,
    [Company_Reserves_NAG]                 VARCHAR (500) NULL,
    [Company_Reserves_AnnualOilProduction] VARCHAR (500) NULL,
    [Consession_Type]                      VARCHAR (50)  NULL,
    [Contract_Type]                        VARCHAR (50)  NULL,
    [Terrain]                              VARCHAR (50)  NULL,
    [CompanyNumber]                        INT           NULL,
    [Field_ID]                             INT           NULL,
    CONSTRAINT [PK_RESERVES_UPDATES_OIL_CONDENSATE_CURRENT_RESERVE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

