CREATE TABLE [dbo].[ProcessStatuses] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [StatusName] NVARCHAR (MAX) NULL,
    [CreatedBy]  NVARCHAR (MAX) NULL,
    [CreateOn]   DATETIME2 (7)  NOT NULL,
    [UpdatedBy]  NVARCHAR (MAX) NULL,
    [UpdatedOn]  DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_ProcessStatuses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

