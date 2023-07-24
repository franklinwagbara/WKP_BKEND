CREATE TABLE [dbo].[ADMIN_REASON_FOR_DECLINE] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [REASON_FOR_DECLINE] VARCHAR (200) NULL,
    [Created_by]         VARCHAR (100) NULL,
    [Updated_by]         VARCHAR (100) NULL,
    [Date_Created]       DATETIME      NULL,
    [Date_Updated]       DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_REASON_FOR_DECLINE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

