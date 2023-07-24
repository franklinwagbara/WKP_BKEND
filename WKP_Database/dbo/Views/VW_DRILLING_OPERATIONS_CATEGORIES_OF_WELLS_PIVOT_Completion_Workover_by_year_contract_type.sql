/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover_by_year_contract_type]
AS
SELECT     Contract_Type, Year_of_WP, SUM(CAST(Exploration_Actual AS int)) AS Exploration_Actual, SUM(CAST(Development_Actual AS int)) AS Development_Actual, 
                      SUM(CAST(Appraisal_Actual AS int)) AS Appraisal_Actual, SUM(CAST(Exploration_Proposed AS int)) AS Exploration_Proposed, 
                      SUM(CAST(Development_Proposed AS int)) AS Development_Proposed, SUM(CAST(Appraisal_Proposed AS int)) AS Appraisal_Proposed, 
                      SUM(CAST(Current_year_Actual_Number AS int)) AS Current_year_Actual_Number_INITIAL_WELL_COMPLETION_JOBS, SUM(CAST(Proposed_year_data AS int)) 
                      AS Proposed_year_data_INITIAL_WELL_COMPLETION_JOBS, SUM(CAST(Current_year_Actual_Number_data AS int)) 
                      AS Current_year_Actual_Number_data_WORKOVERS_RECOMPLETION_JOBS, SUM(CAST(Expr7 AS int)) AS Proposed_WORKOVERS_RECOMPLETION_JOBS
FROM         dbo.[VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover _join_Contracttype]
GROUP BY Contract_Type, Year_of_WP