CREATE TABLE [dbo].[ApplicationProccesses] (
    [ProccessID]      INT            IDENTITY (1, 1) NOT NULL,
    [CategoryID]      INT            NULL,
    [RoleID]          INT            NULL,
    [SBU_ID]          INT            NULL,
    [Sort]            INT            NULL,
    [CreatedAt]       DATETIME       NULL,
    [CreatedBy]       NVARCHAR (500) NULL,
    [UpdatedAt]       DATETIME       NULL,
    [UpdatedBy]       NVARCHAR (500) NULL,
    [DeleteStatus]    BIT            NOT NULL,
    [DeletedBy]       NVARCHAR (500) NULL,
    [DeletedAt]       DATETIME       NULL,
    [TriggeredBySBU]  INT            NULL,
    [TargetedToSBU]   INT            NULL,
    [ProcessAction]   NVARCHAR (100) NULL,
    [ProcessStatus]   NVARCHAR (100) NULL,
    [TriggeredByRole] INT            NULL,
    [TargetedToRole]  INT            NULL,
    CONSTRAINT [PK_WorkProccess_] PRIMARY KEY CLUSTERED ([ProccessID] ASC)
);

