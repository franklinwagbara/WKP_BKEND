﻿CREATE TABLE [dbo].[HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]             VARCHAR (200)  NULL,
    [OML_Name]           VARCHAR (200)  NULL,
    [CompanyName]        VARCHAR (500)  NULL,
    [Companyemail]       VARCHAR (500)  NULL,
    [Year_of_WP]         VARCHAR (100)  NULL,
    [ACTUAL_year]        VARCHAR (500)  NULL,
    [PROPOSED_year]      VARCHAR (500)  NULL,
    [Year_]              VARCHAR (3999) NULL,
    [NUMBER]             VARCHAR (3900) NULL,
    [Quantity_spilled]   VARCHAR (3999) NULL,
    [Quantity_Recovered] VARCHAR (3900) NULL,
    [Created_by]         VARCHAR (100)  NULL,
    [Updated_by]         VARCHAR (100)  NULL,
    [Date_Created]       DATETIME       NULL,
    [Date_Updated]       DATETIME       NULL,
    [Consession_Type]    VARCHAR (50)   NULL,
    [Contract_Type]      VARCHAR (50)   NULL,
    [Terrain]            VARCHAR (50)   NULL,
    [CompanyNumber]      INT            NULL,
<<<<<<< HEAD
    CONSTRAINT [PK_HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW] PRIMARY KEY CLUSTERED ([Id] ASC)
);

=======
    [Field_ID]           INT            NULL,
    CONSTRAINT [PK_HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NUMBER_AND_QUALITY_NEW] PRIMARY KEY CLUSTERED ([Id] ASC)
);



>>>>>>> origin/main
