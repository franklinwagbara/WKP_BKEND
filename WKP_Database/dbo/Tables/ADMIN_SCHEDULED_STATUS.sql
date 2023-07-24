CREATE TABLE [dbo].[ADMIN_SCHEDULED_STATUS] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [SCHEDULED_STATUS] VARCHAR (200) NULL,
    [categories_Desc]  VARCHAR (MAX) NULL,
    [Created_by]       VARCHAR (100) NULL,
    [Updated_by]       VARCHAR (100) NULL,
    [Date_Created]     DATETIME      NULL,
    [Date_Updated]     DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_SCHEDULED_STATUS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

