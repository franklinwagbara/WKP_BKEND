CREATE TABLE [dbo].[SubmittedDocuments] (
    [SubDocID]         INT           IDENTITY (1, 1) NOT NULL,
    [AppID]            INT           NULL,
    [LocalDocID]       INT           NULL,
    [ElpsDocID]        INT           NULL,
    [YearOfWKP]        INT           NULL,
    [DocSource]        VARCHAR (MAX) NULL,
    [DocumentCategory] VARCHAR (100) NULL,
    [DocumentName]     VARCHAR (150) NULL,
    [CreatedBy]        VARCHAR (20)  NULL,
    [CreatedAt]        DATETIME      NULL,
    [UpdatedAt]        DATETIME      NULL,
    CONSTRAINT [PK_SubmittedDocuments] PRIMARY KEY CLUSTERED ([SubDocID] ASC)
);





