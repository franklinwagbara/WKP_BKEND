CREATE TABLE [dbo].[DevelopmentDrilling] (
    [Development_DrillingId] INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]            VARCHAR (5)   NULL,
    [Proposed_Year]          VARCHAR (5)   NULL,
    [Budget_Allocation]      BIGINT        NULL,
    [Remarks]                VARCHAR (MAX) NULL,
    CONSTRAINT [PK_DevelopmentDrilling] PRIMARY KEY CLUSTERED ([Development_DrillingId] ASC)
);

