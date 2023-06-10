CREATE TABLE [dbo].[Payments]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [AppId] INT NOT NULL, 
    [CompanyNumber] INT NOT NULL, 
    [ConcessionId] INT NULL, 
    [FieldId] INT NULL, 
    [TypeOfPaymentId] INT NOT NULL, 
    [AmountNGN] NVARCHAR(MAX) NOT NULL, 
    [AmountUSD] NVARCHAR(MAX) NOT NULL, 
    [TransactionDate] DATETIME2 NOT NULL, 
    [TransactionId] INT NULL, 
    [RRR] INT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [AppReceiptId] NVARCHAR(MAX) NULL, 
    [TXNMessage] NVARCHAR(MAX) NULL, 
    [AccountNumber] NVARCHAR(MAX) NULL, 
    [BankCode] NVARCHAR(MAX) NULL, 
    [Status] NVARCHAR(MAX) NULL, 
    [Currency] NVARCHAR(MAX) NULL, 
    [PaymentDate] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_PAYMENTS] PRIMARY KEY CLUSTERED ([ID] ASC)
);
