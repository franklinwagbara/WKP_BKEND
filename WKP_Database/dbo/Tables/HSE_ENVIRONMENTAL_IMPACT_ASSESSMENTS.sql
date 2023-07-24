CREATE TABLE [dbo].[HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTS] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]               VARCHAR (200) NULL,
    [OML_Name]             VARCHAR (200) NULL,
    [CompanyName]          VARCHAR (500) NULL,
    [Companyemail]         VARCHAR (500) NULL,
    [Year_of_WP]           VARCHAR (100) NULL,
    [ACTUAL_year]          VARCHAR (500) NULL,
    [PROPOSED_year]        VARCHAR (500) NULL,
    [Pre_Impact_]          VARCHAR (500) NULL,
    [In_progress_Started_] VARCHAR (500) NULL,
    [Proposed_]            VARCHAR (500) NULL,
    [Created_by]           VARCHAR (100) NULL,
    [Updated_by]           VARCHAR (100) NULL,
    [Date_Created]         DATETIME      NULL,
    [Date_Updated]         DATETIME      NULL,
    [Terrain]              VARCHAR (50)  NULL,
    [Consession_Type]      VARCHAR (50)  NULL,
    [Contract_Type]        VARCHAR (50)  NULL,
    [CompanyNumber]        INT           NULL,
    [Field_ID]             INT           NULL,
    CONSTRAINT [PK_HSE_ENVIRONMENTAL_IMPACT_ASSESSMENTS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

