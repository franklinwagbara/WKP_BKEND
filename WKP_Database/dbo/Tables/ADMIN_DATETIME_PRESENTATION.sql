﻿CREATE TABLE [dbo].[ADMIN_DATETIME_PRESENTATION] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [COMPANYNAME]             VARCHAR (200)  NULL,
    [COMPANY_ID]              VARCHAR (200)  NULL,
    [PRESENTED]               VARCHAR (200)  NULL,
    [COMPANYEMAIL]            VARCHAR (200)  NULL,
    [MEETINGROOM]             VARCHAR (200)  NULL,
    [CHAIRPERSON]             VARCHAR (200)  NULL,
    [SCRIBE]                  VARCHAR (200)  NULL,
    [STATUS]                  VARCHAR (100)  NULL,
    [YEAR]                    VARCHAR (100)  NULL,
    [DATETIME_PRESENTATION]   DATETIME       NULL,
    [CLOSE_DATE]              DATETIME       NULL,
    [CREATED_BY]              VARCHAR (100)  NULL,
    [Updated_by]              VARCHAR (100)  NULL,
    [Date_Created]            DATETIME       NULL,
    [Date_Updated]            DATETIME       NULL,
    [Submitted]               VARCHAR (50)   NULL,
    [wp_date]                 VARCHAR (50)   NULL,
    [wp_time]                 VARCHAR (50)   NULL,
    [CHAIRPERSONEMAIL]        VARCHAR (500)  NULL,
    [SCRIBEEMAIL]             VARCHAR (500)  NULL,
    [OPEN_DATE]               DATETIME       NULL,
    [MOM]                     VARCHAR (500)  NULL,
    [MOM_UPLOAD_DATE]         DATETIME       NULL,
    [MOM_UPLOADED_BY]         VARCHAR (500)  NULL,
    [DATE_TIME_TEXT]          VARCHAR (100)  NULL,
    [DIVISION]                VARCHAR (50)   NULL,
    [PHONE_NO]                VARCHAR (50)   NULL,
    [LAST_RUN_DATE]           VARCHAR (50)   NULL,
    [EMAIL_REMARK]            VARCHAR (50)   NULL,
    [DAYS_TO_GO]              VARCHAR (50)   NULL,
    [LAST_RUN_TIME]           DATETIME       NULL,
    [Date_Created_BY_COMPANY] VARCHAR (50)   NULL,
    [CompanyNumber]           INT            NULL,
    [adminAproved]            BIT            NULL,
    [companyAproved]          BIT            NULL,
    [isDeleted]               BIT            NULL,
    [numOfHistories]          INT            DEFAULT ((0)) NOT NULL,
    [comment]                 NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ADMIN_DATETIME_PRESENTATION] PRIMARY KEY CLUSTERED ([Id] ASC)
);







