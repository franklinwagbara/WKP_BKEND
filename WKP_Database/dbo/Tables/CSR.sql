CREATE TABLE [dbo].[CSR] (
    [CSR_Id]                INT           IDENTITY (1, 1) NOT NULL,
    [MOU_with_Community]    VARCHAR (5)   NULL,
    [Reason_WithOut_MOU]    VARCHAR (MAX) NULL,
    [All_MOU_Submitted]     VARCHAR (5)   NULL,
    [CSR_Projects]          VARCHAR (MAX) NULL,
    [Actual_Spent]          BIGINT        NULL,
    [Budget]                BIGINT        NULL,
    [Percentage_Completion] INT           NULL,
    CONSTRAINT [PK_CSR] PRIMARY KEY CLUSTERED ([CSR_Id] ASC)
);

