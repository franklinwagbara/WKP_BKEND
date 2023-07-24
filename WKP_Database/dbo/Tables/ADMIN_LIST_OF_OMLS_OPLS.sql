CREATE TABLE [dbo].[ADMIN_LIST_OF_OMLS_OPLS] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]        VARCHAR (200) NULL,
    [OML_Name]      VARCHAR (200) NULL,
    [CompanyName]   VARCHAR (500) NULL,
    [Companyemail]  VARCHAR (500) NULL,
    [Created_by]    VARCHAR (100) NULL,
    [Updated_by]    VARCHAR (100) NULL,
    [Date_Created]  DATETIME      NULL,
    [Date_Updated]  DATETIME      NULL,
    [CompanyNumber] INT           NULL,
    CONSTRAINT [PK_ADMIN_LIST_OF_OMLS_OPLS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

