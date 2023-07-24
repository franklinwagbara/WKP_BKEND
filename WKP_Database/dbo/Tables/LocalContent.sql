CREATE TABLE [dbo].[LocalContent] (
    [Local_ContentId]             INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Year]                 VARCHAR (5)   NULL,
    [Proposed_Year]               VARCHAR (5)   NULL,
    [List_of_Expiry_Expatriate]   VARCHAR (MAX) NULL,
    [List_of_Understudies]        VARCHAR (MAX) NULL,
    [Expatriate_Quota_Projection] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_LocalContent] PRIMARY KEY CLUSTERED ([Local_ContentId] ASC)
);

