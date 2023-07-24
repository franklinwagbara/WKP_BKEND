CREATE TABLE [dbo].[ADMIN_COMPLIANCE_INDEX_TABLE] (
    [Id]                                 INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName]                        VARCHAR (3000) NULL,
    [Consession_Type]                    VARCHAR (3000) NULL,
    [Year_of_WP]                         VARCHAR (3000) NULL,
    [Divisions]                          VARCHAR (3000) NULL,
    [Penalty_Factor_for_Warning]         VARCHAR (3000) NULL,
    [Number_of_Occurrence_of_Warnings]   VARCHAR (3000) NULL,
    [Penalty_Factor_for_Sanction]        VARCHAR (3000) NULL,
    [Number_of_Occurrence_of_Sanctions]  VARCHAR (3000) NULL,
    [Penalty_Factor_for_Waivers]         VARCHAR (3000) NULL,
    [Number_of_Occurrence_of_Waivers]    VARCHAR (3000) NULL,
    [Compliance_index_for_each_division] VARCHAR (3000) NULL,
    [Created_by]                         VARCHAR (100)  NULL,
    [Updated_by]                         VARCHAR (100)  NULL,
    [Date_Created]                       DATETIME       NULL,
    [Date_Updated]                       DATETIME       NULL,
    [CompanyNumber]                      INT            NULL,
    CONSTRAINT [PK_ADMIN_COMPLIANCE_INDEX_TABLE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

