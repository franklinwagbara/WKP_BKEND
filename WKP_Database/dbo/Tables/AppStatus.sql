CREATE TABLE [dbo].[AppStatus]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [AppId] INT NOT NULL, 
    [CompanyId] INT NOT NULL, 
    [FieldId] INT NULL, 
    [ConcessionId] INT NOT NULL, 
    [SBUId] INT NULL, 
    [DeskId] INT NULL, 
    [Status] NVARCHAR(200) NULL, 
    [CreatedAt] DATETIME NULL,
    [InternalStatus] NVARCHAR(200) NULL, 
    [UpdatedAt] DATETIME NULL, 
    CONSTRAINT [PK_AppStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
)
