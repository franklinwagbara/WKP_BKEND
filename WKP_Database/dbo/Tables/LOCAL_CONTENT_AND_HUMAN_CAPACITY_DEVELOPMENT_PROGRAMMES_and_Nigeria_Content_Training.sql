CREATE TABLE [dbo].[LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]        VARCHAR (200) NULL,
    [OML_Name]      VARCHAR (200) NULL,
    [CompanyName]   VARCHAR (500) NULL,
    [Companyemail]  VARCHAR (500) NULL,
    [Year_of_WP]    VARCHAR (100) NULL,
    [Training_]     VARCHAR (500) NULL,
    [Local_]        VARCHAR (500) NULL,
    [Foreign_]      VARCHAR (500) NULL,
    [Created_by]    VARCHAR (100) NULL,
    [Updated_by]    VARCHAR (100) NULL,
    [Date_Created]  DATETIME      NULL,
    [Date_Updated]  DATETIME      NULL,
    [CompanyNumber] INT           NULL,
    [Field_ID]      INT           NULL,
    CONSTRAINT [PK_LOCAL_CONTENT_AND_HUMAN_CAPACITY_DEVELOPMENT_PROGRAMMES_and_Nigeria_Content_Training] PRIMARY KEY CLUSTERED ([Id] ASC)
);

