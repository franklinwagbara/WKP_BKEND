CREATE TABLE [dbo].[UserMaster] (
    [UserId]       INT           IDENTITY (1, 1) NOT NULL,
    [UserEmail]    VARCHAR (80)  NULL,
    [UserType]     VARCHAR (20)  NULL,
    [FirstName]    VARCHAR (50)  NULL,
    [LastName]     VARCHAR (50)  NULL,
    [UserRole]     VARCHAR (50)  NULL,
    [CreatedBy]    VARCHAR (80)  NULL,
    [UpdatedBy]    VARCHAR (80)  NULL,
    [CreatedOn]    DATETIME      NULL,
    [UpdatedOn]    DATETIME      NULL,
    [Status]       VARCHAR (10)  NULL,
    [LastLogin]    DATETIME      NULL,
    [LoginCount]   INT           NULL,
    [PasswordHash] VARCHAR (MAX) NULL,
    [PhoneNumber]  VARCHAR (20)  NULL,
    [CompanyName]  VARCHAR (100) NULL,
    [DivisionId]   INT           NULL,
    [Comment]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED ([UserId] ASC)
);





