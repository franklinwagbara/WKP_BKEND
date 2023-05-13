CREATE TABLE [dbo].[OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment] (
    [Id]                                    INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                VARCHAR (200)  NULL,
    [OML_Name]                              VARCHAR (200)  NULL,
    [CompanyName]                           VARCHAR (500)  NULL,
    [Companyemail]                          VARCHAR (500)  NULL,
    [Year_of_WP]                            VARCHAR (100)  NULL,
    [Name]                                  VARCHAR (500)  NULL,
    [Objective]                             VARCHAR (500)  NULL,
    [Existing_Alternatives]                 VARCHAR (500)  NULL,
    [DPR_Consent]                           VARCHAR (MAX)  NULL,
    [Cost]                                  VARCHAR (500)  NULL,
    [Benefits]                              VARCHAR (500)  NULL,
    [Challenges]                            VARCHAR (500)  NULL,
    [Timeline]                              VARCHAR (500)  NULL,
    [Created_by]                            VARCHAR (100)  NULL,
    [Updated_by]                            VARCHAR (100)  NULL,
    [Date_Created]                          DATETIME       NULL,
    [Date_Updated]                          DATETIME       NULL,
    [Consession_Type]                       VARCHAR (50)   NULL,
    [Terrain]                               VARCHAR (50)   NULL,
    [Contract_Type]                         VARCHAR (50)   NULL,
    [COMPANY_ID]                            VARCHAR (100)  NULL,
    [CompanyNumber]                         INT            NULL,
    [Field_ID]                              INT            NULL,
    [EvidenceOfInspectionAndUgradeFilename] NVARCHAR (MAX) NULL,
    [EvidenceOfInspectionAndUgradePath]     NVARCHAR (MAX) NULL,
    [Inspection_Regime]                     VARCHAR(MAX)            NULL,
    CONSTRAINT [PK_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_New_Technology_Conformity_Assessment] PRIMARY KEY CLUSTERED ([Id] ASC)
);



