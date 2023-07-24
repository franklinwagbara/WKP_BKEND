CREATE TABLE [dbo].[COMPANY_FIELDS] (
    [Field_ID]       INT          IDENTITY (1, 1) NOT NULL,
    [CompanyNumber]  INT          NULL,
    [Concession_ID]  INT          NULL,
    [Field_Name]     VARCHAR (50) NULL,
    [Field_Location] VARCHAR (50) NULL,
    [Date_Created]   DATETIME     NULL,
    [Date_Updated]   DATETIME     NULL,
    [DeletedStatus]  BIT          NULL,
    CONSTRAINT [PK_COMPANY_FIELDS] PRIMARY KEY CLUSTERED ([Field_ID] ASC)
);

