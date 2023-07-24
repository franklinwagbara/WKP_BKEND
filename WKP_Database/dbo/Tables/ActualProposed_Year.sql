CREATE TABLE [dbo].[ActualProposed_Year] (
    [ActualProposedYearId] INT         IDENTITY (1, 1) NOT NULL,
    [ActualProposedYear]   VARCHAR (6) NOT NULL,
    CONSTRAINT [PK_ActualProposed_Year] PRIMARY KEY CLUSTERED ([ActualProposedYearId] ASC)
);

