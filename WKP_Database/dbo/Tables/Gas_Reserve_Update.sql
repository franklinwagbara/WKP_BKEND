CREATE TABLE [dbo].[Gas_Reserve_Update] (
    [Gas_ReserveId]      INT          IDENTITY (1, 1) NOT NULL,
    [Reserve1]           VARCHAR (80) NULL,
    [Reserve2]           VARCHAR (80) NULL,
    [Additional_Reserve] VARCHAR (80) NULL,
    [Total_Production]   BIGINT       NULL,
    CONSTRAINT [PK_Gas_Reserve_Update] PRIMARY KEY CLUSTERED ([Gas_ReserveId] ASC)
);

