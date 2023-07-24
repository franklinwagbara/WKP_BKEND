CREATE TABLE [dbo].[DRILLING_EACH_WELL_COST] (
    [Id]                                          INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                      VARCHAR (200) NULL,
    [OML_Name]                                    VARCHAR (200) NULL,
    [CompanyName]                                 VARCHAR (500) NULL,
    [Companyemail]                                VARCHAR (500) NULL,
    [Year_of_WP]                                  VARCHAR (100) NULL,
    [well_name]                                   VARCHAR (500) NULL,
    [well_cost]                                   VARCHAR (50)  NULL,
    [Created_by]                                  VARCHAR (100) NULL,
    [Updated_by]                                  VARCHAR (100) NULL,
    [Date_Created]                                DATETIME      NULL,
    [Date_Updated]                                DATETIME      NULL,
    [Consession_Type]                             VARCHAR (50)  NULL,
    [QUATER]                                      VARCHAR (50)  NULL,
    [Surface_cordinates_for_each_well_in_degrees] VARCHAR (100) NULL,
    [COMPANY_ID]                                  VARCHAR (100) NULL,
    [CompanyNumber]                               INT           NULL,
    [Field_ID]                                    INT           NULL
);

