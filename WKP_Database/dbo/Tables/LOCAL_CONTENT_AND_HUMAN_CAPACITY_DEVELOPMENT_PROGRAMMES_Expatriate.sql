CREATE TABLE [dbo].[LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate] (
    [Id]                                                                                         INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                                                                     VARCHAR (200) NULL,
    [OML_Name]                                                                                   VARCHAR (200) NULL,
    [CompanyName]                                                                                VARCHAR (500) NULL,
    [Companyemail]                                                                               VARCHAR (500) NULL,
    [Year_of_WP]                                                                                 VARCHAR (100) NULL,
    [List_of_Expatriate_positions_that_will_expire]                                              VARCHAR (500) NULL,
    [List_of_Understudies_that_had_successfully_taken_over_from_expatriates_in_the_last_4_years] VARCHAR (500) NULL,
    [Expatriate_Quota_projection_for_proposed_year]                                              VARCHAR (500) NULL,
    [Created_by]                                                                                 VARCHAR (100) NULL,
    [Updated_by]                                                                                 VARCHAR (100) NULL,
    [Date_Created]                                                                               DATETIME      NULL,
    [Date_Updated]                                                                               DATETIME      NULL,
    [Contract_Type]                                                                              VARCHAR (50)  NULL,
    [Terrain]                                                                                    VARCHAR (50)  NULL,
    [Consession_Type]                                                                            VARCHAR (50)  NULL,
    [CompanyNumber]                                                                              INT           NULL,
    [Field_ID]                                                                                   INT           NULL,
    CONSTRAINT [PK_LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_Expatriate] PRIMARY KEY CLUSTERED ([Id] ASC)
);

