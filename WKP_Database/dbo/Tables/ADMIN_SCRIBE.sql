CREATE TABLE [dbo].[ADMIN_SCRIBE] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [SCRIBE]          VARCHAR (200) NULL,
    [SCRIBEEMAIL]     VARCHAR (500) NULL,
    [categories_Desc] VARCHAR (MAX) NULL,
    [Created_by]      VARCHAR (100) NULL,
    [Updated_by]      VARCHAR (100) NULL,
    [Date_Created]    DATETIME      NULL,
    [Date_Updated]    DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_SCRIBE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

