CREATE TABLE [dbo].[PRESENTATION_UPLOAD] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                VARCHAR (200)  NULL,
    [OML_Name]              VARCHAR (200)  NULL,
    [CompanyName]           VARCHAR (500)  NULL,
    [Companyemail]          VARCHAR (500)  NULL,
    [Year_of_WP]            VARCHAR (100)  NULL,
    [uploaded_presentation] VARCHAR (500)  NULL,
    [Created_by]            VARCHAR (100)  NULL,
    [Updated_by]            VARCHAR (100)  NULL,
    [Date_Created]          DATETIME       NULL,
    [Date_Updated]          DATETIME       NULL,
    [Contract_Type]         VARCHAR (50)   NULL,
    [Terrain]               VARCHAR (50)   NULL,
    [Consession_Type]       VARCHAR (50)   NULL,
    [check_status]          VARCHAR (50)   NULL,
    [upload_extension]      VARCHAR (50)   NULL,
    [original_filemane]     VARCHAR (2500) NULL,
    [COMPANY_ID]            VARCHAR (300)  NULL,
    [CompanyNumber]         INT            NULL,
    [Field_ID]              INT            NULL,
    CONSTRAINT [PK_PRESENTATION_UPLOAD] PRIMARY KEY CLUSTERED ([Id] ASC)
);

