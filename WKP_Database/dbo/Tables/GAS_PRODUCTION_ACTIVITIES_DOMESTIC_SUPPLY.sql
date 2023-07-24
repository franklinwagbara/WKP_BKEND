CREATE TABLE [dbo].[GAS_PRODUCTION_ACTIVITIES_DOMESTIC_SUPPLY] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]          VARCHAR (200)  NULL,
    [OML_Name]        VARCHAR (200)  NULL,
    [CompanyName]     VARCHAR (500)  NULL,
    [Companyemail]    VARCHAR (500)  NULL,
    [Year_of_WP]      VARCHAR (100)  NULL,
    [ProjectName]     VARCHAR (500)  NULL,
    [Description]     VARCHAR (3000) NULL,
    [Created_by]      VARCHAR (100)  NULL,
    [Updated_by]      VARCHAR (100)  NULL,
    [Date_Created]    DATETIME       NULL,
    [Date_Updated]    DATETIME       NULL,
    [Consession_Type] VARCHAR (50)   NULL,
    [Terrain]         VARCHAR (50)   NULL,
    [Contract_Type]   VARCHAR (50)   NULL,
    [COMPANY_ID]      VARCHAR (100)  NULL,
    [CompanyNumber]   INT            NULL,
    [Field_ID]        INT            NULL
);

