CREATE TABLE [dbo].[ApplicationCategories] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [FriendlyName] NVARCHAR (50) NULL,
    [Price]        INT           NULL,
    [CreatedAt]    DATETIME      NULL,
    [CreatedBy]    INT           NULL,
    [UpdatedAt]    DATETIME      NULL,
    [UpdatedBy]    INT           NULL,
    [DeleteStatus] BIT           NULL,
    [DeletedBy]    INT           NULL,
    [DeletedAt]    DATETIME      NULL,
    CONSTRAINT [PK_ApplicationCategories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

