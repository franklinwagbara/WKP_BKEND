CREATE TABLE [dbo].[Applications] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [ReferenceNo]      VARCHAR (50)   NOT NULL,
    [CompanyID]        INT            NOT NULL,
    [ConcessionID]     INT            NULL,
    [FieldID]          INT            NULL,
    [CategoryID]       INT            NOT NULL,
    [YearOfWKP]        INT            NOT NULL,
    [Status]           NVARCHAR (25)  NOT NULL,
    [PaymentStatus]    VARCHAR (50)   NOT NULL,
    [CurrentDesk]      INT            NULL,
    [Submitted]        BIT            NULL,
    [ApprovalRef]      VARCHAR (50)   NULL,
    [CreatedAt]        DATETIME       NULL,
    [SubmittedAt]      DATETIME       NULL,
    [UpdatedAt]        DATETIME       NULL,
    [DeletedBy]        INT            NULL,
    [DeleteStatus]     BIT            NULL,
    [DeletedAt]        DATETIME       NULL,
    [FlowStageId]      INT            NULL,
    [CurrentUserEmail] NVARCHAR (100) NULL,
    [ProcessingStage]  NCHAR (100)    NULL,
    CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED ([Id] ASC)
);



