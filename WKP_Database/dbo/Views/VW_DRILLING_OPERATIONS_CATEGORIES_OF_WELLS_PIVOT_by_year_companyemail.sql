CREATE VIEW [dbo].[VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_by_year_companyemail]
AS
SELECT     Companyemail, Year_of_WP, SUM(CAST(Exploration_Actual AS int)) AS Exploration_Actual, SUM(CAST(Development_Actual AS int)) AS Development_Actual, 
                      SUM(CAST(Appraisal_Actual AS int)) AS Appraisal_Actual, SUM(CAST(Exploration_Proposed AS int)) AS Exploration_Proposed, 
                      SUM(CAST(Development_Proposed AS int)) AS Development_Proposed, SUM(CAST(Appraisal_Proposed AS int)) AS Appraisal_Proposed
FROM         dbo.VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT
GROUP BY Companyemail, Year_of_WP