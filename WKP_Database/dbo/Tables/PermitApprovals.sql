CREATE TABLE [dbo].[PermitApprovals] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [PermitNo]    VARCHAR (100)   NOT NULL,
    [ApprovalNumber]    VARCHAR (100)   NOT NULL,
    [AppID]       INT            NOT NULL,
    [CompanyID]   INT            NOT NULL,
    [ElpsID]      INT            NULL,
    [DateIssued]  DATETIME2 (0)  NOT NULL,
    [DateExpired] DATETIME2 (0)  NOT NULL,
    [IsRenewed]   BIT            NULL,
    [IsPrinted]     BIT            NOT NULL,
    [ApprovedBy]  VARCHAR (100)  NULL,
    [CreatedAt]   DATETIME       NULL,
    CONSTRAINT [PK_PermitApprovals] PRIMARY KEY CLUSTERED ([Id] ASC)
);

