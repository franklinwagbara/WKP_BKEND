CREATE TABLE [dbo].[ADMIN_SUBMISSION_WINDOW] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [OPEN_DATE]            DATETIME      NULL,
    [CLOSE_DATE]           DATETIME      NULL,
    [Open_date_only]       VARCHAR (100) NULL,
    [Open_time_only]       VARCHAR (100) NULL,
    [Close_date_only]      VARCHAR (100) NULL,
    [Close_time_only]      VARCHAR (100) NULL,
    [Year]                 VARCHAR (10)  NULL,
    [Created_by]           VARCHAR (100) NULL,
    [Date_Created]         DATETIME      NULL,
    [LAST_LOGIN_DATE]      DATETIME      NULL,
    [STATUS_]              VARCHAR (200) NULL,
    [FLAG_PASSWORD_CHANGE] VARCHAR (500) NULL,
    CONSTRAINT [PK_ADMIN_SUBMISSION_WINDOW] PRIMARY KEY CLUSTERED ([Id] ASC)
);

