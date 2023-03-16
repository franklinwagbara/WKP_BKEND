CREATE TABLE [dbo].[Role] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [RoleId]      VARCHAR (100) NOT NULL,
    [Description] VARCHAR (100) NULL,
    [RoleName]    VARCHAR (100) NULL,
    [Rank]        INT           NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);





