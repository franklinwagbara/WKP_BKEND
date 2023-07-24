CREATE TABLE [dbo].[WORK_PROGRAM_FLOW] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]        VARCHAR (200) NULL,
    [OML_Name]      VARCHAR (200) NULL,
    [CompanyName]   VARCHAR (500) NULL,
    [Companyemail]  VARCHAR (500) NULL,
    [Year_of_WP]    VARCHAR (100) NULL,
    [Descriptions]  VARCHAR (MAX) NULL,
    [Value]         VARCHAR (MAX) NULL,
    [Comment]       VARCHAR (MAX) NULL,
    [Created_by]    VARCHAR (100) NULL,
    [Updated_by]    VARCHAR (100) NULL,
    [Date_Created]  DATETIME      NULL,
    [Date_Updated]  DATETIME      NULL,
    [Flag1]         VARCHAR (500) NULL,
    [CompanyNumber] INT           NULL,
    CONSTRAINT [PK_WORK_PROGRAM_FLOW] PRIMARY KEY CLUSTERED ([Id] ASC)
);

