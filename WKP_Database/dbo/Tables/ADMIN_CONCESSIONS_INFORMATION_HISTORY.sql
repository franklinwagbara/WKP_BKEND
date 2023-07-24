CREATE TABLE [dbo].[ADMIN_CONCESSIONS_INFORMATION_HISTORY] (
    [Consession_Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Company_ID]          VARCHAR (200) NULL,
    [CompanyName]         VARCHAR (500) NULL,
    [Equity_distribution] VARCHAR (MAX) NULL,
    [Concession_Held]     VARCHAR (500) NULL,
    [Area]                VARCHAR (500) NULL,
    [Contract_Type]       VARCHAR (500) NULL,
    [Year_of_Grant_Award] VARCHAR (100) NULL,
    [Date_of_Expiration]  DATETIME      NULL,
    [Geological_location] VARCHAR (200) NULL,
    [Comment]             VARCHAR (500) NULL,
    [Status_]             VARCHAR (500) NULL,
    [Flag1]               VARCHAR (500) NULL,
    [Flag2]               VARCHAR (500) NULL,
    [Created_by]          VARCHAR (100) NULL,
    [Updated_by]          VARCHAR (100) NULL,
    [Date_Created]        DATETIME      NULL,
    [Date_Updated]        DATETIME      NULL,
    [COMPANY_EMAIL]       VARCHAR (50)  NULL,
    [CompanyNumber]       INT           NULL,
    CONSTRAINT [PK_ADMIN_CONCESSIONS_INFORMATION_HISTORY] PRIMARY KEY CLUSTERED ([Consession_Id] ASC)
);

