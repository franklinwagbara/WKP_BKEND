CREATE TABLE [dbo].[NDR] (
    [Id]                                               INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                           VARCHAR (200) NULL,
    [OML_Name]                                         VARCHAR (200) NULL,
    [CompanyName]                                      VARCHAR (500) NULL,
    [Companyemail]                                     VARCHAR (500) NULL,
    [COMPANY_ID]                                       VARCHAR (100) NULL,
    [Year_of_WP]                                       VARCHAR (100) NULL,
    [Has_annual_NDR_subscription_fee_been_paid]        VARCHAR (50)  NULL,
    [When_was_the_date_of_your_last_NDR_submission]    DATE          NULL,
    [Upload_NDR_payment_receipt]                       VARCHAR (200) NULL,
    [Are_you_up_to_date_with_your_NDR_data_submission] VARCHAR (20)  NULL,
    [NDRFilename]                                      VARCHAR (500) NULL,
    [Created_by]                                       VARCHAR (100) NULL,
    [Updated_by]                                       VARCHAR (100) NULL,
    [Date_Created]                                     DATETIME      NULL,
    [Date_Updated]                                     DATETIME      NULL,
    [Contract_Type]                                    VARCHAR (50)  NULL,
    [Terrain]                                          VARCHAR (50)  NULL,
    [Consession_Type]                                  VARCHAR (50)  NULL,
    [CompanyNumber]                                    INT           NULL,
    [Field_ID]                                         INT           NULL
);

