CREATE TABLE [dbo].[ApplicationDeskHistories] (
    [Id]              INT            IDENTITY (10849, 1) NOT NULL,
    [AppId]           INT            NOT NULL,
    [StaffID]         INT            NULL,
    [Comment]         VARCHAR (MAX)  NOT NULL,
    [Status]          NVARCHAR (50)  NOT NULL,
    [CreatedAt]       DATETIME2 (0)  NOT NULL,
    [ActionDate]      DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [AppAction]       NVARCHAR (MAX) NULL,
    [Message]         NVARCHAR (MAX) NULL,
    [TargetedTo]      NVARCHAR (MAX) NULL,
    [TriggeredBy]     NVARCHAR (MAX) NULL,
    [TriggeredByRole] INT            NULL,
    [TargetedToSBU]   INT            NULL,
    [TriggeredBySBU]  INT            NULL,
    [TargetedToRole]  INT            NULL,
    [SelectedTables] NVARCHAR(MAX) NULL, 
    [ActionByCompany] BIT NULL, 
    [CompanyId] INT NULL, 
    [isPublic] BIT NULL, 
    CONSTRAINT [PK_ApplicationDeskHistories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

