CREATE TABLE [dbo].[ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [categories]      VARCHAR (200) NULL,
    [categories_Desc] VARCHAR (MAX) NULL,
    [Created_by]      VARCHAR (100) NULL,
    [Updated_by]      VARCHAR (100) NULL,
    [Date_Created]    DATETIME      NULL,
    [Date_Updated]    DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_Fatalities_Casualties_ManOverboard_TRI_LTI] PRIMARY KEY CLUSTERED ([Id] ASC)
);

