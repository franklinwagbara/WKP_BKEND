CREATE TABLE [dbo].[ADMIN_TRAINING_NIGERIA_CONTENT] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [categories]   VARCHAR (200) NULL,
    [Created_by]   VARCHAR (100) NULL,
    [Updated_by]   VARCHAR (100) NULL,
    [Date_Created] DATETIME      NULL,
    [Date_Updated] DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_TRAINING_NIGERIA_CONTENT] PRIMARY KEY CLUSTERED ([Id] ASC)
);

