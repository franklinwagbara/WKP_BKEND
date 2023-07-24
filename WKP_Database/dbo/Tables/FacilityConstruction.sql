CREATE TABLE [dbo].[FacilityConstruction] (
    [Facility_ConstructionId]      INT           IDENTITY (1, 1) NOT NULL,
    [Actual_Capital_Expenditure]   BIGINT        NULL,
    [Proposed_Capital_Expenditure] BIGINT        NULL,
    [Remarks]                      VARCHAR (MAX) NULL,
    [Facility_Calibration]         VARCHAR (MAX) NULL,
    CONSTRAINT [PK_FacilityConstruction] PRIMARY KEY CLUSTERED ([Facility_ConstructionId] ASC)
);

