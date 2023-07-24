CREATE TABLE [dbo].[ADMIN_WP_PENALTIES] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [NO_SHOW]         VARCHAR (3000) NULL,
    [NO_SUBMISSION]   VARCHAR (3000) NULL,
    [categories_Desc] VARCHAR (MAX)  NULL,
    [Created_by]      VARCHAR (100)  NULL,
    [Updated_by]      VARCHAR (100)  NULL,
    [Date_Created]    DATETIME       NULL,
    [Date_Updated]    DATETIME       NULL,
    CONSTRAINT [PK_ADMIN_WP_PENALTIES] PRIMARY KEY CLUSTERED ([Id] ASC)
);

