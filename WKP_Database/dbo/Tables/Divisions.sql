CREATE TABLE [dbo].[Divisions] (
    [Division_PK]  INT          IDENTITY (1, 1) NOT NULL,
    [DivisionId]   INT          NOT NULL,
    [DivisionName] VARCHAR (80) NULL,
    CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED ([Division_PK] ASC)
);

