CREATE TABLE [dbo].[CompletionJobs] (
    [Completion_JobsId] INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]       VARCHAR (5)   NULL,
    [Proposed_Year]     VARCHAR (5)   NULL,
    [Budget_Allocation] BIGINT        NULL,
    [Remarks]           VARCHAR (MAX) NULL,
    CONSTRAINT [PK_CompletionJobs] PRIMARY KEY CLUSTERED ([Completion_JobsId] ASC)
);

