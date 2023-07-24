CREATE TABLE [dbo].[ADMIN_FEILDDEVELOPMENTPLAN_WELLORGAS] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Category]     VARCHAR (20)  NOT NULL,
    [IsActive]     VARCHAR (20)  NULL,
    [Created_by]   VARCHAR (100) NULL,
    [Updated_by]   VARCHAR (100) NULL,
    [Date_Created] DATETIME      NULL,
    [Date_Updated] DATETIME      NULL
);

