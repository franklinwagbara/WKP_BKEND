CREATE TABLE [dbo].[ApplicationSBUApproval]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AppId] INT NULL, 
    [StaffID] INT NULL, 
    [Comment] NVARCHAR(MAX) NULL, 
    [Status] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME NULL, 
    [UpdatedDate] DATETIME NULL, 
    [AppAction] NVARCHAR(50) NULL, 
    [DeskID] INT NULL
)
