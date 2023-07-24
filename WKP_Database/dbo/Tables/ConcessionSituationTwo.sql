CREATE TABLE [dbo].[ConcessionSituationTwo] (
    [ConcessionSituationId]      INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName]                VARCHAR (200) NULL,
    [ContractType]               VARCHAR (100) NULL,
    [Terrain]                    VARCHAR (MAX) NULL,
    [SignatureBonus]             VARCHAR (5)   NULL,
    [NoSignatureBonusReason]     VARCHAR (MAX) NULL,
    [ConcessionRentals]          VARCHAR (5)   NULL,
    [NoConcessionRentalsReason]  VARCHAR (MAX) NULL,
    [ApplicationRenewal]         VARCHAR (5)   NULL,
    [NoApplicationRenewalReason] VARCHAR (MAX) NULL,
    [ActualBudgetCurrentYr]      VARCHAR (MAX) NULL,
    [FiveYrsProposal]            VARCHAR (MAX) NULL,
    [CompanyNumber]              INT           NULL,
    CONSTRAINT [PK_ConcessionSituationTwo] PRIMARY KEY CLUSTERED ([ConcessionSituationId] ASC)
);

