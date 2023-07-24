CREATE TABLE [dbo].[PermitApprovals] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [PermitNo]    VARCHAR (50)   NOT NULL,
    [AppID]       INT            NOT NULL,
    [CompanyID]   INT            NOT NULL,
    [ElpsID]      INT            NULL,
    [DateIssued]  DATETIME2 (0)  NOT NULL,
    [DateExpired] DATETIME2 (0)  NOT NULL,
    [IsRenewed]   NVARCHAR (130) NULL,
    [Printed]     BIT            NOT NULL,
    [ApprovedBy]  INT            NULL,
    [CreatedAt]   DATETIME       NULL,
    CONSTRAINT [PK_PermitApprovals] PRIMARY KEY CLUSTERED ([Id] ASC)
);

