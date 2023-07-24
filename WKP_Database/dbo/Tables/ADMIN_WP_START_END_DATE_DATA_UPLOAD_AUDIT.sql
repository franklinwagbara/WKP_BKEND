CREATE TABLE [dbo].[ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [start_date]      VARCHAR (200) NULL,
    [end_date]        VARCHAR (200) NULL,
    [categories_Desc] VARCHAR (MAX) NULL,
    [Created_by]      VARCHAR (100) NULL,
    [Updated_by]      VARCHAR (100) NULL,
    [Date_Created]    DATETIME      NULL,
    [Date_Updated]    DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_WP_START_END_DATE_DATA_UPLOAD_AUDIT] PRIMARY KEY CLUSTERED ([Id] ASC)
);

