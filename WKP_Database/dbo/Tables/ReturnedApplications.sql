CREATE TABLE [dbo].[ReturnedApplications]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [AppId] INT NULL, 
    [CreatedAt] DATETIME2 NULL,
    [StaffId] INT NULL, 
    [Comment] NVARCHAR(MAX) NULL, 
    [SelectedTables] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_ReturnedApplications] PRIMARY KEY CLUSTERED ([Id] ASC)
)
