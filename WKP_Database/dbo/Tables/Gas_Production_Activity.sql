CREATE TABLE [dbo].[Gas_Production_Activity] (
    [Gas_Production_ActivityId] INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]               VARCHAR (5)   NULL,
    [Utilized]                  VARCHAR (80)  NULL,
    [Forecast]                  VARCHAR (80)  NULL,
    [Flared]                    VARCHAR (80)  NULL,
    [Remarks]                   VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Gas_Production_Activity] PRIMARY KEY CLUSTERED ([Gas_Production_ActivityId] ASC)
);

