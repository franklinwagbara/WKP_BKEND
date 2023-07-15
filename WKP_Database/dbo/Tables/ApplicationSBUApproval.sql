CREATE TABLE [dbo].[ApplicationSBUApproval]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [AppId] INT NULL, 
    [StaffID] INT NULL, 
    [Comment] NVARCHAR(MAX) NULL, 
    [Status] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME2 NULL, 
    [UpdatedDate] DATETIME2 NULL, 
    [AppAction] NVARCHAR(50) NULL, 
    [DeskID] INT NULL,
    [SBUID] INT NULL, 
    CONSTRAINT [PK_ApplicationSBUApproval] PRIMARY KEY CLUSTERED ([Id] ASC)
)
