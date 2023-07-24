CREATE TABLE [dbo].[Reserve_Update_Oil_Condensate] (
    [Reserve_UpdateId]    INT          IDENTITY (1, 1) NOT NULL,
    [P1_Reserve]          VARCHAR (80) NULL,
    [Reserves]            VARCHAR (80) NULL,
    [Additional_Reserves] VARCHAR (80) NULL,
    [Total_Production]    BIGINT       NULL,
    CONSTRAINT [PK_Reserve_Update_Oil_Condensate] PRIMARY KEY CLUSTERED ([Reserve_UpdateId] ASC)
);

