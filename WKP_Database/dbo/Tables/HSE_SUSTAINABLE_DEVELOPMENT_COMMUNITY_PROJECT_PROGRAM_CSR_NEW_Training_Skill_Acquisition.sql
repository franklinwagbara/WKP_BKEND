CREATE TABLE [dbo].[HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition] (
    [Id]                               INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                           VARCHAR (200)  NULL,
    [OML_Name]                         VARCHAR (200)  NULL,
    [CompanyName]                      VARCHAR (500)  NULL,
    [Companyemail]                     VARCHAR (500)  NULL,
    [Year_of_WP]                       VARCHAR (100)  NULL,
    [CSR_]                             VARCHAR (3000) NULL,
    [Budget_]                          VARCHAR (500)  NULL,
    [Actual_Spent]                     VARCHAR (500)  NULL,
    [Percentage_Completion_]           VARCHAR (500)  NULL,
    [Created_by]                       VARCHAR (100)  NULL,
    [Updated_by]                       VARCHAR (100)  NULL,
    [Date_Created]                     DATETIME       NULL,
    [Date_Updated]                     DATETIME       NULL,
    [Beneficiary_Communities_host]     VARCHAR (MAX)  NULL,
    [Beneficiary_Communities_National] VARCHAR (MAX)  NULL,
    [Actual_proposed]                  VARCHAR (50)   NULL,
    [Actual_Proposed_Year]             VARCHAR (50)   NULL,
    [Contract_Type]                    VARCHAR (50)   NULL,
    [Terrain]                          VARCHAR (50)   NULL,
    [Consession_Type]                  VARCHAR (50)   NULL,
    [COMPANY_ID]                       VARCHAR (100)  NULL,
    [CompanyNumber]                    INT            NULL,
    [Field_ID]                         INT            NULL,
    [Budget_Ngn]                       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_HSE_SUSTAINABLE_DEVELOPMENT_COMMUNITY_PROJECT_PROGRAM_CSR_NEW_Training_Skill_Acquisition] PRIMARY KEY CLUSTERED ([Id] ASC)
);





