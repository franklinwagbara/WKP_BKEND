CREATE TABLE [dbo].[NDR_Data_Population] (
    [NDRDataId]                 INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]               VARCHAR (5)   NULL,
    [Proposed_Year]             VARCHAR (5)   NULL,
    [Data_Type]                 VARCHAR (5)   NULL,
    [Processed_Data]            VARCHAR (5)   NULL,
    [Reason_Non_Processed_Data] VARCHAR (MAX) NULL,
    [Subscription_Fee_Upload]   VARCHAR (MAX) NULL,
    [Annual_Sub_Fee]            VARCHAR (5)   NULL,
    [Reason_For_Non_Payment]    VARCHAR (MAX) NULL,
    CONSTRAINT [PK_NDR_Data_Population] PRIMARY KEY CLUSTERED ([NDRDataId] ASC)
);

