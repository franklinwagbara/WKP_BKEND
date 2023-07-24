CREATE TABLE [dbo].[Menu] (
    [MenuId]      VARCHAR (6)   NOT NULL,
    [Description] VARCHAR (50)  NULL,
    [IconName]    VARCHAR (100) NULL,
    [SeqNo]       TINYINT       NULL,
    [Status]      VARCHAR (10)  NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([MenuId] ASC)
);





