CREATE TABLE [dbo].[HSE_MinimumRequirement] (
    [Id]                                INT           IDENTITY (1, 1) NOT NULL,
    [Is_Company_ISO45001_Certified]     VARCHAR (20)  NULL,
    [Provide_ISO45001_Certification_No] VARCHAR (100) NULL,
    [CompanyNumber]                     INT           NULL,
    [DateCreated]                       DATE          NULL,
    [ConcessionID]                      INT           NULL,
    [FieldID]                           INT           NULL,
    [Year]                              INT           NULL,
    CONSTRAINT [PK_HSE_MinimumRequirement] PRIMARY KEY CLUSTERED ([Id] ASC)
);

