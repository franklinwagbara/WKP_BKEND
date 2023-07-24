CREATE TABLE [dbo].[Initial_Well_Completion_Job] (
    [Initial_Well_CompletionId]                 INT           IDENTITY (1, 1) NOT NULL,
    [Actual_No_Current_Year]                    VARCHAR (300) NULL,
    [Actual_No_Proposed_Year]                   VARCHAR (300) NULL,
    [Budget_Allocation_Proposed_Year]           VARCHAR (300) NULL,
    [Processing_Fees_Paid]                      VARCHAR (300) NULL,
    [Do_you_have_approval_to_complete_the_well] VARCHAR (300) NULL,
    [Remark]                                    VARCHAR (MAX) NULL,
    [Year_of_WorkProgram]                       VARCHAR (300) NULL,
    CONSTRAINT [PK_Initial_Well_Completion] PRIMARY KEY CLUSTERED ([Initial_Well_CompletionId] ASC)
);

