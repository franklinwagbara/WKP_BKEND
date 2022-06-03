﻿CREATE TABLE [dbo].[ADMIN_DIVISIONAL_REPRESENTATIVE] (
    [Id]                    INT           IDENTITY (1, 1) NOT NULL,
    [COMPANYNAME]           VARCHAR (200) NULL,
    [COMPANY_ID]            VARCHAR (200) NULL,
    [PRESENTED]             VARCHAR (200) NULL,
    [COMPANYEMAIL]          VARCHAR (200) NULL,
    [MEETINGROOM]           VARCHAR (200) NULL,
    [CHAIRPERSON]           VARCHAR (200) NULL,
    [SCRIBE]                VARCHAR (200) NULL,
    [STATUS]                VARCHAR (100) NULL,
    [YEAR]                  VARCHAR (100) NULL,
    [DATETIME_PRESENTATION] DATETIME      NULL,
    [CLOSE_DATE]            DATETIME      NULL,
    [CREATED_BY]            VARCHAR (100) NULL,
    [Updated_by]            VARCHAR (100) NULL,
    [Date_Created]          DATETIME      NULL,
    [Date_Updated]          DATETIME      NULL,
    [Submitted]             VARCHAR (50)  NULL,
    [wp_date]               VARCHAR (50)  NULL,
    [wp_time]               VARCHAR (50)  NULL,
    [CHAIRPERSONEMAIL]      VARCHAR (500) NULL,
    [SCRIBEEMAIL]           VARCHAR (500) NULL,
    [OPEN_DATE]             DATETIME      NULL,
    [DIV_REP_NAME]          VARCHAR (500) NULL,
    [DIV_REP_DIV]           VARCHAR (500) NULL,
    [DIV_REP_EMAIL]         VARCHAR (500) NULL,
        [CompanyNumber]      INT        NULL          

    CONSTRAINT [PK_ADMIN_DIVISIONAL_REPRESENTATIVE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

