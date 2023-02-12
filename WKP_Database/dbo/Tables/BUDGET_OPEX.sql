CREATE TABLE [dbo].[BUDGET_OPEX] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [OmL_Name]                     VARCHAR (1000) NULL,
    [OmL_ID]                       VARCHAR (1000) NULL,
    [CompanyName]                  VARCHAR (1000) NULL,
    [Companyemail]                 VARCHAR (1000) NULL,
    [Year_of_WP]                   VARCHAR (1000) NULL,
    [Company_ID]                   VARCHAR (1000) NULL,
    [CompanyNumber]                INT            NULL,
    [Variable_Cost]                VARCHAR (1000) NULL,
    [Fixed_Cost]                   VARCHAR (1000) NULL,
    [Overheads]                    VARCHAR (1000) NULL,
    [Repairs_and_Maintenance_Cost] VARCHAR (1000) NULL,
    [General_Expenses]             VARCHAR (1000) NULL,
    [Created_by]                   VARCHAR (1000) NULL,
    [Updated_by]                   VARCHAR (1000) NULL,
    [Date_Created]                 DATETIME       NULL,
    [Date_Updated]                 DATETIME       NULL,
    CONSTRAINT [PK_BUDGET_OPEX] PRIMARY KEY CLUSTERED ([Id] ASC)
);

