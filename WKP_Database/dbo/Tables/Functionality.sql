CREATE TABLE [dbo].[Functionality] (
    [FuncId]      VARCHAR (6)   NOT NULL,
    [Description] VARCHAR (50)  NULL,
    [MenuId]      VARCHAR (15)  NULL,
    [Action]      VARCHAR (50)  NULL,
    [SeqNo]       TINYINT       NULL,
    [Status]      VARCHAR (10)  NULL,
    [IconName]    VARCHAR (200) NULL,
    CONSTRAINT [PK_Functionality] PRIMARY KEY CLUSTERED ([FuncId] ASC)
);





