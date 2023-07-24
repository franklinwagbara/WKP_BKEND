CREATE TABLE [dbo].[ADMIN_GASPRODUCTION_UTILIZED_MMSCF] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Category]     VARCHAR (50)  NOT NULL,
    [IsActive]     VARCHAR (50)  NULL,
    [Created_by]   VARCHAR (100) NULL,
    [Updated_by]   VARCHAR (100) NULL,
    [Date_Created] DATETIME      NULL,
    [Date_Updated] DATETIME      NULL
);

