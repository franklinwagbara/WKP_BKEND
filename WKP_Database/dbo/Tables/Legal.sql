CREATE TABLE [dbo].[Legal] (
    [Legal_Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Company_Sanctioned]  VARCHAR (5)   NULL,
    [Company_Fined]       VARCHAR (5)   NULL,
    [Company_FinedReason] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Legal] PRIMARY KEY CLUSTERED ([Legal_Id] ASC)
);

