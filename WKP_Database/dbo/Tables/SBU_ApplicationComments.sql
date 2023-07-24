CREATE TABLE [dbo].[SBU_ApplicationComments] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [SBU_ID]       INT           NULL,
    [AppID]        INT           NULL,
    [SBU_Comment]  VARCHAR (MAX) NULL,
    [ActionStatus] VARCHAR (50)  NULL,
    [DateCreated]  DATETIME      NULL,
    [DateUpdated]  DATETIME      NULL,
    [Staff_ID]     INT           NULL,
    [SBU_Tables]   VARCHAR (MAX) NULL,
    CONSTRAINT [PK_SBU_ApplicationComments] PRIMARY KEY CLUSTERED ([Id] ASC)
);

