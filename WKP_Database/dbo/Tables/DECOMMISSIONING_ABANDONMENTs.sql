CREATE TABLE [dbo].[DECOMMISSIONING_ABANDONMENTs] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [OmlId]              INT            NULL,
    [CompanyEmail]       NVARCHAR (MAX) NOT NULL,
    [WpYear]             NVARCHAR (MAX) NOT NULL,
    [FieldId]            INT            NULL,
    [ApprovalStatus]     NVARCHAR (MAX) NOT NULL,
    [ApprovalCostUsd]    NVARCHAR (MAX) NOT NULL,
    [AnnualObigationUsd] NVARCHAR (MAX) NOT NULL,
    [DateCreated]        DATETIME2 (7)  NULL,
    [DateUpdated]        DATETIME2 (7)  NULL,
    [CreatedBy]          NVARCHAR (MAX) NULL,
    [UpdatedBy]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_DECOMMISSIONING_ABANDONMENTs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

