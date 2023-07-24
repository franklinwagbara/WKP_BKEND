CREATE TABLE [dbo].[COMPANY_CONCESSIONS_FIELDS] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [CompanyNumber]   INT          NULL,
    [Concession_Name] VARCHAR (20) NULL,
    [Field_Name]      VARCHAR (50) NULL,
    [Created_On]      DATETIME     NULL,
    CONSTRAINT [PK_COMPANY_CONCESSIONS_FIELDS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

