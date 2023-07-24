CREATE TABLE [dbo].[WorkOvers_Recompletion_Job_Field_Dvelopment_Plans] (
    [WorkOvers_Recompletion_Job_Field_Dvelopment_PlansId]          INT           IDENTITY (1, 1) NOT NULL,
    [How_many_fields_have_FDP]                                     VARCHAR (300) NULL,
    [List_all_the_field_with_FDP]                                  VARCHAR (MAX) NULL,
    [Which_fields_do_you_plan_to_submit_an_FDP]                    VARCHAR (300) NULL,
    [How_many_fields_have_approved_FDP]                            VARCHAR (300) NULL,
    [Number_of_wells_proposed_in_the_FDP]                          VARCHAR (300) NULL,
    [No_of_wells_drilled_in_Current_Year]                          VARCHAR (300) NULL,
    [proposed_number_of_wells_for_Proposed_Year_from_Approved_FDP] VARCHAR (300) NULL,
    [Processing_Fees_Paid]                                         VARCHAR (300) NULL,
    [Year_of_WorkProgram]                                          VARCHAR (300) NULL,
    CONSTRAINT [PK_WorkOvers_Recompletion_Job_Field_Dvelopment_Plans] PRIMARY KEY CLUSTERED ([WorkOvers_Recompletion_Job_Field_Dvelopment_PlansId] ASC)
);

