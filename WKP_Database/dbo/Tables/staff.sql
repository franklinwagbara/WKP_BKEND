CREATE TABLE [dbo].[staff] (
    [StaffID]             INT            IDENTITY (1, 1) NOT NULL,
    [StaffElpsID]         VARCHAR (100)  NULL,
    [Staff_SBU]           INT            NULL,
    [RoleID]              INT            NULL,
    [LocationID]          INT            NULL,
    [StaffEmail]          VARCHAR (50)   NULL,
    [FirstName]           VARCHAR (30)   NULL,
    [LastName]            VARCHAR (30)   NULL,
    [CreatedAt]           DATETIME       NULL,
    [ActiveStatus]        BIT            NULL,
    [UpdatedAt]           DATETIME       NULL,
    [DeleteStatus]        BIT            NULL,
    [DeletedBy]           INT            NULL,
    [DeletedAt]           DATETIME       NULL,
    [CreatedBy]           INT            NULL,
    [UpdatedBy]           INT            NULL,
    [SignaturePath]       VARCHAR (1000) NULL,
    [SignatureName]       VARCHAR (100)  NULL,
    [AdminCompanyInfo_ID] INT            NULL,
    CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED ([StaffID] ASC)
);





