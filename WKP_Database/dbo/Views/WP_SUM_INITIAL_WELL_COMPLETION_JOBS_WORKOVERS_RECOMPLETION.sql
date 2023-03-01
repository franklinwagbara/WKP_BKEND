CREATE VIEW [dbo].[WP_SUM_INITIAL_WELL_COMPLETION_JOBS_WORKOVERS_RECOMPLETION]
AS
SELECT     a.Current_year_Actual_Number_data + b.Current_year_Actual_Number AS Actual_Year, a.Proposed_year_data + b.Proposed_year_data AS Proposed_Year, 
                      a.Year_of_WP AS Year_of_WP_W, b.Year_of_WP AS Year_of_WP_I
FROM         dbo.WP_WORKOVERS_RECOMPLETION_JOBS AS a INNER JOIN
                      dbo.WP_INITIAL_WELL_COMPLETION_JOBS AS b ON a.Year_of_WP = b.Year_of_WP