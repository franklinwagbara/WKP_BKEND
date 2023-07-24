CREATE TABLE [dbo].[SafetyManagement] (
    [Safety_ManagementId]   INT           IDENTITY (1, 1) NOT NULL,
    [Fatalities]            VARCHAR (MAX) NULL,
    [Current_Facilities]    VARCHAR (MAX) NULL,
    [Previous_Facilities]   VARCHAR (MAX) NULL,
    [Design_Safety_Control] VARCHAR (MAX) NULL,
    [Current_Year]          VARCHAR (MAX) NULL,
    [Previous_Year]         VARCHAR (MAX) NULL,
    CONSTRAINT [PK_SafetyManagement] PRIMARY KEY CLUSTERED ([Safety_ManagementId] ASC)
);

