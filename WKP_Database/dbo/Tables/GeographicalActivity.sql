CREATE TABLE [dbo].[GeographicalActivity] (
    [Geographical_ActivityId] INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year_A]           VARCHAR (MAX) NULL,
    [Proposed_Year_A]         VARCHAR (MAX) NULL,
    [Budget_Allocation_A]     BIGINT        NULL,
    [Remark_A]                VARCHAR (MAX) NULL,
    [Actual_Year_B]           VARCHAR (MAX) NULL,
    [Proposed_Year_B]         VARCHAR (MAX) NULL,
    [Budget_Allocation_B]     BIGINT        NULL,
    [Remark_B]                VARCHAR (MAX) NULL,
    CONSTRAINT [PK_GeographicalActivity] PRIMARY KEY CLUSTERED ([Geographical_ActivityId] ASC)
);

