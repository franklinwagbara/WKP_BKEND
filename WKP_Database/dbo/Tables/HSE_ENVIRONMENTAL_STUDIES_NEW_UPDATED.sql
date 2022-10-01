﻿CREATE TABLE [dbo].[HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]               VARCHAR (200)  NULL,
    [OML_Name]             VARCHAR (200)  NULL,
    [CompanyName]          VARCHAR (500)  NULL,
    [Companyemail]         VARCHAR (500)  NULL,
    [Year_of_WP]           VARCHAR (100)  NULL,
    [field_name]           VARCHAR (500)  NULL,
    [type_of_study]        VARCHAR (500)  NULL,
    [study_title]          VARCHAR (3999) NULL,
    [current_study_status] VARCHAR (3900) NULL,
    [DPR_approval_Status]  VARCHAR (3999) NULL,
    [Created_by]           VARCHAR (100)  NULL,
    [Updated_by]           VARCHAR (100)  NULL,
    [Date_Created]         DATETIME       NULL,
    [Date_Updated]         DATETIME       NULL,
    [Consession_Type]      VARCHAR (50)   NULL,
    [Contract_Type]        VARCHAR (50)   NULL,
    [Terrain]              VARCHAR (50)   NULL,
    [COMPANY_ID]           VARCHAR (100)  NULL,
    [CompanyNumber]        INT            NULL,
<<<<<<< HEAD
    CONSTRAINT [PK_HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED] PRIMARY KEY CLUSTERED ([Id] ASC)
);

=======
    [Field_ID]             INT            NULL,
    CONSTRAINT [PK_HSE_ENVIRONMENTAL_STUDIES_NEW_UPDATED] PRIMARY KEY CLUSTERED ([Id] ASC)
);



>>>>>>> origin/main
