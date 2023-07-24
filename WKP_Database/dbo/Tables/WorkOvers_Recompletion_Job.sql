CREATE TABLE [dbo].[WorkOvers_Recompletion_Job] (
    [WorkOvers_Recompletion_JobId]                   INT           IDENTITY (1, 1) NOT NULL,
    [Actual_No_Current_Year]                         VARCHAR (300) NULL,
    [Actual_No_Proposed_Year]                        VARCHAR (300) NULL,
    [Budget_Allocation_Proposed_Year]                VARCHAR (300) NULL,
    [Processing_Fees_Paid]                           VARCHAR (300) NULL,
    [Do_you_have_approval_for_workover_recompletion] VARCHAR (300) NULL,
    [Remark]                                         VARCHAR (MAX) NULL,
    [Year_of_WorkProgram]                            VARCHAR (300) NULL,
    CONSTRAINT [PK_WorkOvers_Recompletion_Job] PRIMARY KEY CLUSTERED ([WorkOvers_Recompletion_JobId] ASC)
);

