﻿CREATE TABLE [dbo].[LEGAL_LITIGATION] (
    [Id]                                  INT            IDENTITY (1, 1) NOT NULL,
    [OML_ID]                              VARCHAR (200)  NULL,
    [OML_Name]                            VARCHAR (200)  NULL,
    [CompanyName]                         VARCHAR (500)  NULL,
    [Companyemail]                        VARCHAR (500)  NULL,
    [Year_of_WP]                          VARCHAR (100)  NULL,
    [Terrain]                             VARCHAR (50)   NULL,
    [Contract_Type]                       VARCHAR (50)   NULL,
    [Consession_Type]                     VARCHAR (50)   NULL,
    [AnyLitigation]                       VARCHAR (20)   NULL,
    [Case_Number]                         VARCHAR (200)  NULL,
    [Names_of_Parties]                    VARCHAR (3000) NULL,
    [Jurisdiction]                        VARCHAR (50)   NULL,
    [Name_of_Court]                       VARCHAR (3000) NULL,
    [Summary_of_the_case]                 VARCHAR (3000) NULL,
    [Any_orders_made_so_far_by_the_court] VARCHAR (3000) NULL,
    [Potential_outcome]                   VARCHAR (3000) NULL,
    [Created_by]                          VARCHAR (100)  NULL,
    [Updated_by]                          VARCHAR (100)  NULL,
    [Date_Created]                        DATETIME       NULL,
    [Date_Updated]                        DATETIME       NULL,
    [COMPANY_ID]                          VARCHAR (100)  NULL,
    [CompanyNumber]                       INT            NULL,
    [Field_ID]                            INT            NULL,
    [Year]                                NVARCHAR (MAX) NULL,
    [Any_subsisting_orders_of_court]      VARCHAR (3000) NULL,
    [Order_of_the_court]                  VARCHAR (MAX)  NULL,
    CONSTRAINT [PK_LEGAL_LITIGATION] PRIMARY KEY CLUSTERED ([Id] ASC)
);



