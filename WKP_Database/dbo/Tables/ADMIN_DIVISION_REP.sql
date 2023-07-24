CREATE TABLE [dbo].[ADMIN_DIVISION_REP] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [NAME]          VARCHAR (200) NULL,
    [DIVISION]      VARCHAR (MAX) NULL,
    [Created_by]    VARCHAR (100) NULL,
    [Updated_by]    VARCHAR (100) NULL,
    [Date_Created]  DATETIME      NULL,
    [Date_Updated]  DATETIME      NULL,
    [DIVISIONEMAIL] VARCHAR (500) NULL,
    CONSTRAINT [PK_ADMIN_DIVISION_REP] PRIMARY KEY CLUSTERED ([Id] ASC)
);

