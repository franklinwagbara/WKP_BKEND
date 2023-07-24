CREATE TABLE [dbo].[ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [categories]      VARCHAR (3000) NULL,
    [categories_Desc] VARCHAR (MAX)  NULL,
    [Created_by]      VARCHAR (100)  NULL,
    [Updated_by]      VARCHAR (100)  NULL,
    [Date_Created]    DATETIME       NULL,
    [Date_Updated]    DATETIME       NULL,
    CONSTRAINT [PK_ADMIN_ENVIROMENTAL_STUDIES_APPROVED_ONGOING] PRIMARY KEY CLUSTERED ([Id] ASC)
);

