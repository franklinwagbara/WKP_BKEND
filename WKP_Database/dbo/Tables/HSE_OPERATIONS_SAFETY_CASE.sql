CREATE TABLE [dbo].[HSE_OPERATIONS_SAFETY_CASE] (
    [Id]                                          INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                      VARCHAR (50)   NULL,
    [OML_Name]                                    VARCHAR (500)  NULL,
    [CompanyName]                                 VARCHAR (500)  NULL,
    [Companyemail]                                VARCHAR (500)  NULL,
    [Year_of_WP]                                  VARCHAR (30)   NULL,
    [Reason_If_No_Evidence]                       VARCHAR (2000) NULL,
    [Evidence_of_Operations_Safety_Case_Approval] VARCHAR (3000) NULL,
    [Does_the_Facility_Have_a_Valid_Safety_Case]  VARCHAR (10)   NULL,
    [Type_of_Facility]                            VARCHAR (100)  NULL,
    [Location_of_Facility]                        VARCHAR (1000) NULL,
    [Name_Of_Facility]                            VARCHAR (1000) NULL,
    [Number_of_Facilities]                        VARCHAR (10)   NULL,
    [Date_Created]                                DATETIME       NULL,
    [Created_by]                                  VARCHAR (100)  NULL,
    [Updated_by]                                  VARCHAR (100)  NULL,
    [Date_Updated]                                DATETIME       NULL,
    [COMPANY_ID]                                  VARCHAR (1000) NULL,
    [CompanyNumber]                               INT            NULL,
    [Field_ID]                                    INT            NULL,
    CONSTRAINT [PK_HSE_OPERATIONS_SAFETY_CASE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

