CREATE TABLE [dbo].[RoleFunctionalityRef] (
    [RoleId] VARCHAR (100) NOT NULL,
    [FuncId] VARCHAR (6)   NOT NULL,
    CONSTRAINT [PK_RoleFunctionalityRef] PRIMARY KEY CLUSTERED ([RoleId] ASC, [FuncId] ASC),
    CONSTRAINT [FK_RoleFunctionalityRef_Functionality] FOREIGN KEY ([FuncId]) REFERENCES [dbo].[Functionality] ([FuncId]),
    CONSTRAINT [FK_RoleFunctionalityRef_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId])
);

