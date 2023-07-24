CREATE TABLE [dbo].[NigerianContent] (
    [Nigerian_ContentId]        INT           IDENTITY (1, 1) NOT NULL,
    [Mgt_Local]                 INT           NULL,
    [Mgt_Expatriates]           INT           NULL,
    [Staff_Local]               INT           NULL,
    [Staff_Expatriates]         INT           NULL,
    [Valid_Expatriate]          VARCHAR (5)   NULL,
    [Nbr_of_Released_Staff]     INT           NULL,
    [Reason_For_NonExpatriate]  VARCHAR (MAX) NULL,
    [Succession_Plan_in_Place]  VARCHAR (5)   NULL,
    [Succession_PlanName]       VARCHAR (100) NULL,
    [Succession_PlanTimeLine]   VARCHAR (100) NULL,
    [Succession_PlanUnderStudy] VARCHAR (100) NULL,
    [Position_Occupied]         VARCHAR (100) NULL,
    CONSTRAINT [PK_NigerianContent] PRIMARY KEY CLUSTERED ([Nigerian_ContentId] ASC)
);

