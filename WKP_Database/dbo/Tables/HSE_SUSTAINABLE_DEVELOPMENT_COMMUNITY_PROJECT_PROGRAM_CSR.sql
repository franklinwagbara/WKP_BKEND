CREATE TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                 VARCHAR (200) NULL,
    [OML_Name]               VARCHAR (200) NULL,
    [CompanyName]            VARCHAR (500) NULL,
    [Companyemail]           VARCHAR (500) NULL,
    [Year_of_WP]             VARCHAR (100) NULL,
    [ACTUAL_year]            VARCHAR (500) NULL,
    [PROPOSED_year]          VARCHAR (500) NULL,
    [CSR_]                   VARCHAR (500) NULL,
    [Budget_]                VARCHAR (500) NULL,
    [Actual_Spent_]          VARCHAR (500) NULL,
    [Percentage_Completion_] VARCHAR (500) NULL,
    [Consession_Type]        VARCHAR (50)  NULL,
    [Terrain]                VARCHAR (50)  NULL,
    [Contract_Type]          VARCHAR (50)  NULL,
    [CompanyNumber]          INT           NULL,
    [Field_ID]               INT           NULL,
    CONSTRAINT [PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR] PRIMARY KEY CLUSTERED ([Id] ASC)
);

