﻿CREATE TABLE [dbo].[HSE_INSPECTION_AND_MAINTENANCE_NEW] (
    [Id]                                                                  INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                                              VARCHAR (200)  NULL,
    [OML_Name]                                                            VARCHAR (200)  NULL,
    [CompanyName]                                                         VARCHAR (500)  NULL,
    [Companyemail]                                                        VARCHAR (500)  NULL,
    [Year_of_WP]                                                          VARCHAR (100)  NULL,
    [ACTUAL_year]                                                         VARCHAR (500)  NULL,
    [PROPOSED_year]                                                       VARCHAR (500)  NULL,
    [Was_Inspection_and_Maintenance_of_each_of_your_facility_carried_out] VARCHAR (3999) NULL,
    [Is_the_inspection_philosophy_Prescriptive_or_RBI_for_each_facility]  VARCHAR (3900) NULL,
    [If_RBI_was_approval_granted]                                         VARCHAR (3999) NULL,
    [If_No_Give_reasonS]                                                  VARCHAR (3999) NULL,
    [Created_by]                                                          VARCHAR (100)  NULL,
    [Updated_by]                                                          VARCHAR (100)  NULL,
    [Date_Created]                                                        DATETIME       NULL,
    [Date_Updated]                                                        DATETIME       NULL,
    [Terrain]                                                             VARCHAR (50)   NULL,
    [Contract_Type]                                                       VARCHAR (50)   NULL,
    [Consession_Type]                                                     VARCHAR (50)   NULL,
    [COMPANY_ID]                                                          VARCHAR (100)  NULL,
        [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_HSE_INSPECTION_AND_MAINTENANCE_NEW] PRIMARY KEY CLUSTERED ([Id] ASC)
);

