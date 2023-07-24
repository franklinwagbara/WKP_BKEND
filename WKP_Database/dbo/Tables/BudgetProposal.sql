CREATE TABLE [dbo].[BudgetProposal] (
    [Budget_ProposalId]            INT           IDENTITY (1, 1) NOT NULL,
    [Direct_Exploration_Budget]    BIGINT        NULL,
    [Other_Activity_Budget]        BIGINT        NULL,
    [Total_Company_Expenditure]    BIGINT        NULL,
    [Oil_Gas_Facility_Maintenance] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_BudgetProposal] PRIMARY KEY CLUSTERED ([Budget_ProposalId] ASC)
);

