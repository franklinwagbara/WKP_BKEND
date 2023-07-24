CREATE TABLE [dbo].[ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [categories]      VARCHAR (500) NULL,
    [categories_Desc] VARCHAR (MAX) NULL,
    [Created_by]      VARCHAR (100) NULL,
    [Updated_by]      VARCHAR (100) NULL,
    [Date_Created]    DATETIME      NULL,
    [Date_Updated]    DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Operating_Facilities] PRIMARY KEY CLUSTERED ([Id] ASC)
);

