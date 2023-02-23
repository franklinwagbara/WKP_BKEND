CREATE TABLE [dbo].[HSE_POINT_SOURCE_REGISTRATION] (
    [Id]                            INT            IDENTITY (1, 1) NOT NULL,
    [OML_Name]                      VARCHAR (3000) NULL,
    [OML_ID]                        VARCHAR (MAX)  NULL,
    [CompanyName]                   VARCHAR (MAX)  NULL,
    [Company_Email]                 VARCHAR (MAX)  NULL,
    [Year_of_WP]                    VARCHAR (MAX)  NULL,
    [Company_Number]                VARCHAR (MAX)  NULL,
    [Company_ID]                    VARCHAR (MAX)  NULL,
    [are_there_point_source_permit] VARCHAR (MAX)  NULL,
    [evidence_of_PSP_filename]      VARCHAR (MAX)  NULL,
    [evidence_of_PSP_path]          VARCHAR (MAX)  NULL,
    [reason_for_no_PSP]             VARCHAR (MAX)  NULL,
    [Field_ID]                      INT            NULL,
    CONSTRAINT [PK_HSE_POINT_SOURCE_REGISTRATION] PRIMARY KEY CLUSTERED ([Id] ASC)
);

