CREATE TABLE [dbo].[SBU_Records] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [SBU_Id]      INT           NULL,
    [Records]     VARCHAR (MAX) NULL,
    [DateCreated] DATETIME      NULL,
    [DateUpdated] DATETIME      NULL,
    CONSTRAINT [PK_SBU_Records] PRIMARY KEY CLUSTERED ([Id] ASC)
);

