CREATE TABLE [dbo].[SBU_Submission] (
    [Id]            INT            NOT NULL,
    [AppId]         INT            NOT NULL,
    [StaffID]       INT            NOT NULL,
    [SBU_ID]        INT            NOT NULL,
    [CreatedAt]     DATETIME2 (7)  NULL,
    [UpdatedAt]     DATETIME2 (7)  NULL,
    [Comment]       NVARCHAR (MAX) NULL,
    [ProcessStatus] NVARCHAR (100) NULL,
    CONSTRAINT [PK_SBU_Submission] PRIMARY KEY CLUSTERED ([Id] ASC)
);

