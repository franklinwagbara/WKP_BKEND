CREATE TABLE [dbo].[HSE_EFFLUENT_MONITORING_COMPLIANCE] (
    [Id]                          INT            IDENTITY (1, 1) NOT NULL,
    [Field_ID]                    INT            NULL,
    [OML_Name]                    VARCHAR (200)  NULL,
    [OmL_ID]                      VARCHAR (100)  NULL,
    [CompanyName]                 VARCHAR (300)  NULL,
    [Companyemail]                VARCHAR (100)  NULL,
    [Year_of_WP]                  VARCHAR (10)   NULL,
    [COMPANY_ID]                  VARCHAR (50)   NULL,
    [CompanyNumber]               VARCHAR (50)   NULL,
    [AreThereEvidentOfSampling]   VARCHAR (10)   NULL,
    [EvidenceOfSamplingFilename]  VARCHAR (1000) NULL,
    [EvidenceOfSamplingPath]      VARCHAR (5000) NULL,
    [ReasonForNoEvidenceSampling] VARCHAR (1000) NULL,
    [Date_Updated]                DATETIME       NULL,
    [Updated_by]                  VARCHAR (1000) NULL,
    [Date_Created]                DATETIME       NULL,
    [Created_by]                  VARCHAR (1000) NULL,
    CONSTRAINT [PK_HSE_EFFLUENT_MONITORING_COMPLIANCE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

