﻿CREATE TABLE [dbo].[HSE_ENVIRONMENTAL_MANAGEMENT_SYSTEM] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]          VARCHAR (200)  NULL,
    [OML_Name]        VARCHAR (200)  NULL,
    [CompanyName]     VARCHAR (500)  NULL,
    [Companyemail]    VARCHAR (500)  NULL,
    [Year_of_WP]      VARCHAR (100)  NULL,
    [EMSFilePath]     VARCHAR (3000) NULL,
    [AUDITFilePath]   VARCHAR (500)  NULL,
    [Created_by]      VARCHAR (100)  NULL,
    [Updated_by]      VARCHAR (100)  NULL,
    [Date_Created]    DATETIME       NULL,
    [Date_Updated]    DATETIME       NULL,
    [Consession_Type] VARCHAR (50)   NULL,
    [Terrain]         VARCHAR (50)   NULL,
    [Contract_Type]   VARCHAR (50)   NULL,
    [EMSFilename]     VARCHAR (100)  NULL,
    [AUDITFilename]   VARCHAR (100)  NULL,
    [COMPANY_ID]      VARCHAR (100)  NULL,
<<<<<<< HEAD
    [CompanyNumber]   INT            NULL
);

=======
    [CompanyNumber]   INT            NULL,
    [Field_ID]        INT            NULL
);



>>>>>>> origin/main
