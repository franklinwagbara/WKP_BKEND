CREATE TABLE [dbo].[AccountDesks]
(
	[AccountDeskID] INT IDENTITY (1, 1) NOT NULL,
    [ProcessID] INT NULL, 
    [AppId] INT NOT NULL, 
    [CreatedAt] DATETIME2 NULL, 
    [UpdatedAt] DATETIME2 NULL, 
    [Comment] NVARCHAR(MAX) NULL, 
    [LastJobDate] DATETIME2 NOT NULL, 
    [ProcessStatus] NVARCHAR(MAX) NULL, 
    [StaffID] INT NOT NULL, 
    [PaymentId] INT NOT NULL, 
    [isApproved] BIT NOT NULL,
    CONSTRAINT [PK_AccountDesks] PRIMARY KEY CLUSTERED ([AccountDeskID] ASC)
)
