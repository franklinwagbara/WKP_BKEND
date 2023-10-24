CREATE TABLE [dbo].[SubmissionRejection] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [PermitNo]    VARCHAR (100)   NOT NULL,
    [RejectionNumber]    VARCHAR (100)   NOT NULL,
    [AppId]       INT            NOT NULL,
    [CompanyId]   INT            NOT NULL,
    [ElpsID]      INT            NULL,
    [DateIssued]  DATETIME2 (0)  NOT NULL,
    [DateExpired] DATETIME2 (0)  NOT NULL,
    [IsRenewed]   BIT            NULL,
    [IsPrinted]     BIT            NOT NULL,
    [RejectedBy]  VARCHAR (100)  NULL,
    [CreatedAt]   DATETIME       NULL,
    CONSTRAINT [PK_SubmissionRejection] PRIMARY KEY CLUSTERED ([Id] ASC)
);