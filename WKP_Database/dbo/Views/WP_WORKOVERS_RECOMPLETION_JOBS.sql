
CREATE VIEW [dbo].[WP_WORKOVERS_RECOMPLETION_JOBS]
AS
SELECT     SUM(CAST(Current_year_Actual_Number_data AS decimal)) AS Current_year_Actual_Number_data, SUM(CAST(Proposed_year_data AS decimal)) AS Proposed_year_data, 
                      Year_of_WP
FROM         dbo.WORKOVERS_RECOMPLETION_JOBS
GROUP BY Year_of_WP