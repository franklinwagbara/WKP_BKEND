CREATE TABLE [dbo].[Contract_Type] (
    [Contract_TypeId] INT          IDENTITY (1, 1) NOT NULL,
    [ContractType]    VARCHAR (20) NULL,
    CONSTRAINT [PK_Contract_Type] PRIMARY KEY CLUSTERED ([Contract_TypeId] ASC)
);

