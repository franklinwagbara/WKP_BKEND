CREATE TABLE [dbo].[OilSpill_Incident] (
    [Oil_Spill_IncidentId]                                  INT           IDENTITY (1, 1) NOT NULL,
    [Number_Qty_Spilled]                                    INT           NULL,
    [Qty_Recovered]                                         INT           NULL,
    [Pre_Impact]                                            VARCHAR (80)  NULL,
    [Proposed_Year]                                         VARCHAR (5)   NULL,
    [InProgress_StartedYr]                                  VARCHAR (5)   NULL,
    [Possible_Cost]                                         VARCHAR (MAX) NULL,
    [Total_Days_Lost]                                       INT           NULL,
    [Effect_on_Operation]                                   VARCHAR (MAX) NULL,
    [Nbr_of_Fatality]                                       INT           NULL,
    [Cost_Involved]                                         INT           NULL,
    [Action_Plan]                                           VARCHAR (MAX) NULL,
    [Proof_Of_Submission_Of_Valid_OSCP]                     VARCHAR (300) NULL,
    [Evidence_Of_QuaterlySubmissions_Of_OilField_Chemicals] VARCHAR (500) NULL,
    [Evidence_Of_MOUs_With_CAN]                             VARCHAR (500) NULL,
    CONSTRAINT [PK_OilSpill_Incident] PRIMARY KEY CLUSTERED ([Oil_Spill_IncidentId] ASC)
);

