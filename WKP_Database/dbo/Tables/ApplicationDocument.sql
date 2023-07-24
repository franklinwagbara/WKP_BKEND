CREATE TABLE [dbo].[ApplicationDocument] (
    [CategoryId]    INT           NULL,
    [AppDocID]      INT           IDENTITY (1, 1) NOT NULL,
    [ElpsDocTypeID] INT           NOT NULL,
    [DocName]       VARCHAR (200) NOT NULL,
    [DocType]       VARCHAR (8)   NOT NULL,
    [CreatedAt]     DATETIME      NOT NULL,
    [UpdatedAt]     DATETIME      NULL,
    [DeleteStatus]  BIT           NOT NULL,
    [DeletedBy]     INT           NULL,
    [DeletedAt]     DATETIME      NULL,
    CONSTRAINT [PK_ApplicationDocuments_UT] PRIMARY KEY CLUSTERED ([AppDocID] ASC)
);

