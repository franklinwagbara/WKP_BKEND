CREATE TABLE [dbo].[FlowStages] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Action]          NVARCHAR (100) NULL,
    [SBUId]           INT            NULL,
    [Status]          NVARCHAR (50)  NULL,
    [TargetedRole]    NVARCHAR (50)  NULL,
    [TargetedSBU]     NVARCHAR (50)  NULL,
    [IsArchived]      SMALLINT       NULL,
    [TriggeredByRole] NVARCHAR (50)  NULL,
    [TriggeredBySBU]  NVARCHAR (50)  NULL,
    CONSTRAINT [PK_FlowStages] PRIMARY KEY CLUSTERED ([Id] ASC)
);

