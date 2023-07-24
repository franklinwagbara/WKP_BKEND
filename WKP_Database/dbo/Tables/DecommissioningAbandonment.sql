CREATE TABLE [dbo].[DecommissioningAbandonment] (
    [Id]                           INT           IDENTITY (1, 1) NOT NULL,
    [Decommissioning]              VARCHAR (500) NULL,
    [Abandonment]                  VARCHAR (500) NULL,
    [Cumulative_DA_Annual_Payment] VARCHAR (500) NULL,
    [Accrued_DA_Annual_Payment]    VARCHAR (500) NULL,
    [CAPEX]                        VARCHAR (500) NULL,
    [OPEX]                         VARCHAR (500) NULL,
    [CompanyNumber]                INT           NULL,
    [ConcessionID]                 INT           NULL,
    [FieldID]                      INT           NULL,
    [DateCreated]                  DATE          NULL,
    [Year]                         INT           NULL,
    CONSTRAINT [PK_DecommissioningAbandonment] PRIMARY KEY CLUSTERED ([Id] ASC)
);

