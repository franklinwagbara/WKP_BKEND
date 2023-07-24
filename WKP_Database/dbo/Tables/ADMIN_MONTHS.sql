CREATE TABLE [dbo].[ADMIN_MONTHS] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Months]       VARCHAR (200) NULL,
    [Created_by]   VARCHAR (100) NULL,
    [Updated_by]   VARCHAR (100) NULL,
    [Date_Created] DATETIME      NULL,
    [Date_Updated] DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_MONTHS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

