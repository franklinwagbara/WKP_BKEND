CREATE TABLE [dbo].[ADMIN_TYPE_OF_TEST] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [TESTTYPE]     VARCHAR (200) NULL,
    [TEST_Desc]    VARCHAR (MAX) NULL,
    [Created_by]   VARCHAR (100) NULL,
    [Updated_by]   VARCHAR (100) NULL,
    [Date_Created] DATETIME      NULL,
    [Date_Updated] DATETIME      NULL,
    CONSTRAINT [PK_ADMIN_TYPE_OF_TEST] PRIMARY KEY CLUSTERED ([Id] ASC)
);

