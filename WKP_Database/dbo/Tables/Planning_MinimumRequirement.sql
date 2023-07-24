CREATE TABLE [dbo].[Planning_MinimumRequirement] (
    [Id]                                INT          IDENTITY (1, 1) NOT NULL,
    [ReservesRevenue_GrossProduction]   VARCHAR (50) NULL,
    [ReservesRevenue_RemainingReserves] VARCHAR (50) NULL,
    [CompanyNumber]                     INT          NULL,
    [ConcessionID]                      INT          NULL,
    [FieldID]                           INT          NULL,
    [DateCreated]                       DATE         NULL,
    [Year]                              INT          NULL,
    CONSTRAINT [PK_Planning_MinimumRequirement] PRIMARY KEY CLUSTERED ([Id] ASC)
);

