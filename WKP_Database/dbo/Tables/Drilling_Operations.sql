CREATE TABLE [dbo].[Drilling_Operations] (
    [Drilling_OperationsId]               INT           IDENTITY (1, 1) NOT NULL,
    [Do_you_have_approval_to_drill]       VARCHAR (300) NULL,
    [Comment_drill_approval]              VARCHAR (300) NULL,
    [Category_of_wells_drilled]           VARCHAR (300) NULL,
    [Actual_no_drilled_current_year]      VARCHAR (300) NULL,
    [Actual_no_drilled_next_year]         VARCHAR (300) NULL,
    [Processing_field_paid]               VARCHAR (300) NULL,
    [No_of_wells_cored]                   VARCHAR (300) NULL,
    [Comment]                             VARCHAR (MAX) NULL,
    [Any_new_discoveries]                 VARCHAR (300) NULL,
    [Any_new_discoveries_comment]         VARCHAR (300) NULL,
    [Hydrocarbon_counts]                  VARCHAR (300) NULL,
    [Number_of_exploration_wells_drilled] VARCHAR (300) NULL,
    [Status]                              VARCHAR (300) NULL,
    [Net_Oil_Gas_Sand]                    VARCHAR (300) NULL,
    [Cost_of_drilling_foot]               VARCHAR (300) NULL,
    [Year_of_WorkProgram]                 VARCHAR (300) NULL,
    CONSTRAINT [PK_Drilling_Operations] PRIMARY KEY CLUSTERED ([Drilling_OperationsId] ASC)
);

