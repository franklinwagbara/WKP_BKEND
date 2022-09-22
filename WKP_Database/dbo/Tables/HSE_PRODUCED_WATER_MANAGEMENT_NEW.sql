﻿CREATE TABLE [dbo].[HSE_PRODUCED_WATER_MANAGEMENT_NEW] (
    [Id]                                    INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                VARCHAR (200)  NULL,
    [OML_Name]                              VARCHAR (200)  NULL,
    [CompanyName]                           VARCHAR (500)  NULL,
    [Companyemail]                          VARCHAR (500)  NULL,
    [Year_of_WP]                            VARCHAR (100)  NULL,
    [ACTUAL_year]                           VARCHAR (500)  NULL,
    [PROPOSED_year]                         VARCHAR (500)  NULL,
    [Within_which_zone_are_you_operating]   VARCHAR (3999) NULL,
    [how_do_you_handle_your_produced_water] VARCHAR (3900) NULL,
    [Export_to_Terminal_with_fluid]         VARCHAR (3999) NULL,
    [Created_by]                            VARCHAR (100)  NULL,
    [Updated_by]                            VARCHAR (100)  NULL,
    [Date_Created]                          DATETIME       NULL,
    [Date_Updated]                          DATETIME       NULL,
    [Consession_Type]                       VARCHAR (50)   NULL,
    [Terrain]                               VARCHAR (50)   NULL,
    [Contract_Type]                         VARCHAR (50)   NULL,
    [COMPANY_ID]                            VARCHAR (100)  NULL,
    [CompanyNumber]                         INT            NULL,
    [Field_ID]                              INT            NULL,
    CONSTRAINT [PK_HSE_PRODUCED_WATER_MANAGEMENT_NEW] PRIMARY KEY CLUSTERED ([Id] ASC)
);



