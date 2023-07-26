CREATE TABLE [dbo].[EnagementScheduledHistorys] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [wp_date]        NVARCHAR (MAX) NULL,
    [wp_time]        NVARCHAR (MAX) NULL,
    [action]         NVARCHAR (MAX) NOT NULL,
    [actionBy]       NVARCHAR (MAX) NOT NULL,
    [comment]        NVARCHAR (MAX) NOT NULL,
    [createdTime]    DATETIME2 (7)  NOT NULL,
    [PresentationId] INT            NOT NULL,
    CONSTRAINT [PK_EnagementScheduledHistorys] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EnagementScheduledHistorys_ADMIN_DATETIME_PRESENTATION_PresentationId] FOREIGN KEY ([PresentationId]) REFERENCES [dbo].[ADMIN_DATETIME_PRESENTATION] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_EnagementScheduledHistorys_PresentationId]
    ON [dbo].[EnagementScheduledHistorys]([PresentationId] ASC);

