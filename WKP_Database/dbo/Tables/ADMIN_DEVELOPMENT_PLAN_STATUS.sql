CREATE TABLE [dbo].[ADMIN_DEVELOPMENT_PLAN_STATUS] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (200) NULL,
    [Desc]         VARCHAR (MAX) NULL,
    [Created_by]   VARCHAR (100) NULL,
    [Updated_by]   VARCHAR (100) NULL,
    [Date_Created] DATETIME      NULL,
    [Date_Updated] DATETIME      NULL
);

