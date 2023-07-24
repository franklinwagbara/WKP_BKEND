CREATE TABLE [dbo].[Development_And_Productions] (
    [Id]                                                INT           NOT NULL,
    [FieldHistory]                                      VARCHAR (300) NULL,
    [Do_You_Have_Any_SubsurfacePlan]                    VARCHAR (10)  NULL,
    [Type_Of_SubsurfacePlan]                            VARCHAR (100) NULL,
    [FiveYears_Projection_Of_Anticipated_Dev_Schemes]   VARCHAR (500) NULL,
    [Have_You_Submitted_AnnualReseves_BookingStatus]    NCHAR (10)    NULL,
    [Do_You_Have_Reserves_Growth_Strategy_Plan]         NCHAR (10)    NULL,
    [Number_Of_Shut_In_Wells]                           INT           NULL,
    [How_Many_ShutIn_Wells_Are_Planned_To_Reactivate]   INT           NULL,
    [How_Many_Wells_Do_You_Plan_To_Complete]            INT           NULL,
    [How_Many_Wells_Do_You_Plan_To_Abandon]             INT           NULL,
    [Number_Of_Well_Interventions_Planned_For_The_Year] INT           NULL,
    [CompanyNumber]                                     INT           NULL,
    [ConcessionID]                                      INT           NULL,
    [FieldID]                                           INT           NULL,
    [DateCreated]                                       DATE          NULL,
    [Year]                                              INT           NULL,
    CONSTRAINT [PK_Development_And_Productions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

