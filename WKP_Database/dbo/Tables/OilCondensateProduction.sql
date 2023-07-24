CREATE TABLE [dbo].[OilCondensateProduction] (
    [Oil_Condensate_ProductionId] INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]                 VARCHAR (5)   NULL,
    [Deferment]                   VARCHAR (80)  NULL,
    [Forecast]                    VARCHAR (80)  NULL,
    [Cost_Barrel]                 INT           NULL,
    [Remarks]                     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_OilCondensateProduction] PRIMARY KEY CLUSTERED ([Oil_Condensate_ProductionId] ASC)
);

