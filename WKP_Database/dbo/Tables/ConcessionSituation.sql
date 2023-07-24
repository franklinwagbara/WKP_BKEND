CREATE TABLE [dbo].[ConcessionSituation] (
    [Concession_situationId] INT           IDENTITY (1, 1) NOT NULL,
    [Concession_Held]        VARCHAR (MAX) NULL,
    [Date_Grant_Expiration]  VARCHAR (50)  NULL,
    [Area]                   VARCHAR (50)  NULL,
    [Nbr_discovered_Field]   INT           NULL,
    [Budget_Proposal]        BIGINT        NULL,
    [Company_Category]       VARCHAR (50)  NULL,
    [Equity_Shares]          VARCHAR (50)  NULL,
    [Nbr_Field_Producing]    INT           NULL,
    CONSTRAINT [PK_ConcessionSituation] PRIMARY KEY CLUSTERED ([Concession_situationId] ASC)
);

