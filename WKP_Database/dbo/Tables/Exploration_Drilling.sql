CREATE TABLE [dbo].[Exploration_Drilling] (
    [Exploration_DrillingId] INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]            VARCHAR (5)   NULL,
    [Proposed_Year]          VARCHAR (5)   NULL,
    [Budget_Allocation]      BIGINT        NULL,
    [Net_Oil_Gas_Sand]       VARCHAR (50)  NULL,
    [Well_Name]              VARCHAR (50)  NULL,
    [Status]                 VARCHAR (50)  NULL,
    [Remarks]                VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Exploration_Drilling] PRIMARY KEY CLUSTERED ([Exploration_DrillingId] ASC)
);

