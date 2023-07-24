CREATE TABLE [dbo].[ADMIN_CHAIRPERSON] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [CHAIRPERSON]      VARCHAR (200) NULL,
    [CHAIRPERSONEMAIL] VARCHAR (500) NULL,
    [categories_Desc]  VARCHAR (MAX) NULL,
    [Created_by]       VARCHAR (100) NULL,
    [Updated_by]       VARCHAR (100) NULL,
    [Date_Created]     DATETIME      NULL,
    [Date_Updated]     DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_CHAIRPERSON] PRIMARY KEY CLUSTERED ([Id] ASC)
);

