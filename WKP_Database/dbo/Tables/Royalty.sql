CREATE TABLE [dbo].[Royalty] (
    [Royalty_ID]         INT            IDENTITY (1, 1) NOT NULL,
    [CompanyNumber]      INT            NULL,
    [Concession_ID]      INT            NULL,
    [Field_ID]           INT            NULL,
    [Crude_Oil_Royalty]  VARCHAR (100)  NULL,
    [Gas_Sales_Royalty]  VARCHAR (100)  NULL,
    [Gas_Flare_Payment]  VARCHAR (100)  NULL,
    [Concession_Rentals] VARCHAR (100)  NULL,
    [Miscellaneous]      VARCHAR (100)  NULL,
    [Year]               VARCHAR (20)   NULL,
    [Status]             VARCHAR (50)   NULL,
    [Date_Created]       DATE           NULL,
    [Last_Qntr_Royalty]  VARCHAR (1000) NULL,
    [OmlName]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Royalty] PRIMARY KEY CLUSTERED ([Royalty_ID] ASC)
);

