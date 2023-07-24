CREATE TABLE [dbo].[ADMIN_WORK_PROGRAM_REPORT] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Report_Content]  VARCHAR (MAX)  NULL,
    [Report_Content_] NVARCHAR (MAX) NULL,
    [Created_by]      VARCHAR (100)  NULL,
    [Updated_by]      VARCHAR (100)  NULL,
    [Date_Created]    DATETIME       NULL,
    [Date_Updated]    DATETIME       NULL,
    CONSTRAINT [PK_ADMIN_WORK_PROGRAM_REPORT] PRIMARY KEY CLUSTERED ([Id] ASC)
);

