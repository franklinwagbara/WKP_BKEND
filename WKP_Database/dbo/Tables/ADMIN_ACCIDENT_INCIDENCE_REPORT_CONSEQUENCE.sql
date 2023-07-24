CREATE TABLE [dbo].[ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [categories]      VARCHAR (3000) NULL,
    [categories_Desc] VARCHAR (MAX)  NULL,
    [Created_by]      VARCHAR (100)  NULL,
    [Updated_by]      VARCHAR (100)  NULL,
    [Date_Created]    DATETIME       NULL,
    [Date_Updated]    DATETIME       NULL,
    CONSTRAINT [PK_ADMIN_ACCIDENT_INCIDENCE_REPORT_CONSEQUENCE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

