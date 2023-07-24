CREATE TABLE [dbo].[WorkOverJobs] (
    [WorkOver_JobsId]   INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]       VARCHAR (5)   NULL,
    [Proposed_Year]     VARCHAR (5)   NULL,
    [Budget_Allocation] BIGINT        NULL,
    [Remarks]           VARCHAR (MAX) NULL,
    CONSTRAINT [PK_WorkOverJobs] PRIMARY KEY CLUSTERED ([WorkOver_JobsId] ASC)
);

