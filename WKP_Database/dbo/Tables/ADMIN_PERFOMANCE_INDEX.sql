CREATE TABLE [dbo].[ADMIN_PERFOMANCE_INDEX] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [INDICATOR]        VARCHAR (3000) NULL,
    [INDEX_TYPE]       VARCHAR (MAX)  NULL,
    [Graduation_Scale] VARCHAR (3000) NULL,
    [Weight]           VARCHAR (MAX)  NULL,
    [CONCESSIONTYPE]   VARCHAR (3000) NULL,
    [Created_by]       VARCHAR (100)  NULL,
    [Updated_by]       VARCHAR (100)  NULL,
    [Date_Created]     DATETIME       NULL,
    [Date_Updated]     DATETIME       NULL,
    CONSTRAINT [PK_ADMIN_PERFOMANCE_INDEX] PRIMARY KEY CLUSTERED ([Id] ASC)
);

