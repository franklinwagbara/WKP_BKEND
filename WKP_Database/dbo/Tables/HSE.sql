CREATE TABLE [dbo].[HSE] (
    [HSE_Id]               INT         IDENTITY (1, 1) NOT NULL,
    [Qty_Spilled]          INT         NULL,
    [Accident_Stat]        BIGINT      NULL,
    [Relevant_Certificate] VARCHAR (5) NULL,
    CONSTRAINT [PK_HSE] PRIMARY KEY CLUSTERED ([HSE_Id] ASC)
);

