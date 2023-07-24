CREATE TABLE [dbo].[ActualExpenditure] (
    [Actual_ExpenditureId]              INT           IDENTITY (1, 1) NOT NULL,
    [Direct_Exploration_Budget]         VARCHAR (100) NULL,
    [Equivalent_Naira_Dollar_Component] VARCHAR (100) NULL,
    [Other_Activity_Budget]             VARCHAR (100) NULL,
    [UserEmail]                         VARCHAR (100) NULL,
    [UserNumber]                        INT           NULL,
    CONSTRAINT [PK_ActualExpenditure] PRIMARY KEY CLUSTERED ([Actual_ExpenditureId] ASC)
);

