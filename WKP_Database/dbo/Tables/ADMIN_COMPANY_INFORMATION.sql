﻿CREATE TABLE [dbo].[ADMIN_COMPANY_INFORMATION] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [COMPANY_NAME]         VARCHAR (500) NULL,
    [EMAIL]                VARCHAR (500) NULL,
    [PASSWORDS]            VARCHAR (500) NULL,
    [Created_by]           VARCHAR (100) NULL,
    [Date_Created]         DATETIME      NULL,
    [LAST_LOGIN_DATE]      DATETIME      NULL,
    [STATUS_]              VARCHAR (200) NULL,
    [FLAG_PASSWORD_CHANGE] VARCHAR (500) NULL,
    [CATEGORY]             VARCHAR (50)  NULL,
    [NAME]                 VARCHAR (500)  NULL,
    [DESIGNATION]          VARCHAR (50)  NULL,
    [PHONE_NO]             VARCHAR (50)  NULL,
    [COMPANY_ID]           VARCHAR (50)  NULL,
    [DELETED_STATUS]       VARCHAR (100) NULL,
    [DELETED_BY]           VARCHAR (200) NULL,
    [DELETED_DATE]         VARCHAR (100) NULL,
    [FLAG1]                VARCHAR (200) NULL,
    [FLAG2]                VARCHAR (200) NULL,
    [UPDATED_BY]           VARCHAR (200) NULL,
    [UPDATED_DATE]         VARCHAR (100) NULL,
    [EMAIL_REMARK]         VARCHAR (100) NULL,
    [CompanyNumber]        INT           NULL,
    [ELPS_ID]              INT           NULL,
    [CompanyAddress]       VARCHAR (150) NULL,
    CONSTRAINT [PK_ADMIN_COMPANY_INFORMATION] PRIMARY KEY CLUSTERED ([Id] ASC)
);

