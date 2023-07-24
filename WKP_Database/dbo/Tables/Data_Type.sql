CREATE TABLE [dbo].[Data_Type] (
    [DataTypeId]   INT          IDENTITY (1, 1) NOT NULL,
    [DataType]     VARCHAR (5)  NULL,
    [Created_by]   VARCHAR (50) NULL,
    [Date_Created] DATETIME     NULL,
    CONSTRAINT [PK_Data_Type] PRIMARY KEY CLUSTERED ([DataTypeId] ASC)
);

