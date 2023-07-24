CREATE TABLE [dbo].[ADMIN_COMPANY_DETAILS] (
    [Id]                       INT           IDENTITY (1, 1) NOT NULL,
    [COMPANY_NAME]             VARCHAR (200) NULL,
    [EMAIL]                    VARCHAR (200) NULL,
    [Address_of_Company]       VARCHAR (500) NULL,
    [Name_of_MD_CEO]           VARCHAR (500) NULL,
    [Phone_NO_of_MD_CEO]       VARCHAR (500) NULL,
    [Contact_Person]           VARCHAR (500) NULL,
    [Phone_No]                 VARCHAR (200) NULL,
    [Email_Address]            VARCHAR (200) NULL,
    [Alternate_Contact_Person] VARCHAR (500) NULL,
    [Phone_No_alt]             VARCHAR (100) NULL,
    [Email_Address_alt]        VARCHAR (500) NULL,
    [FLAG]                     VARCHAR (50)  NULL,
    [Created_by]               VARCHAR (50)  NULL,
    [Date_Created]             VARCHAR (50)  NULL,
    [check_status]             VARCHAR (50)  NULL,
    [CompanyNumber]            INT           NULL,
    [CompanyId]                VARCHAR (50)  NULL,
    CONSTRAINT [PK_ADMIN_COMPANY_DETAILS] PRIMARY KEY CLUSTERED ([Id] ASC)
);

