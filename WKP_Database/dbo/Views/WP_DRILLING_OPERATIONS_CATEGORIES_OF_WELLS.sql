
CREATE VIEW [dbo].[WP_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS]
AS
SELECT     TOP (100) PERCENT SUM(CAST(Actual_No_Drilled_in_Current_Year AS decimal)) AS Actual_No_Drilled_in_Current_Year, SUM(CAST(Proposed_No_Drilled AS decimal)) 
                      AS Proposed_No_Drilled, Year_of_WP, Category
FROM         dbo.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS
WHERE     (Category IN ('Exploration', 'Appraisal', 'Development', '1st Appraisal', '2nd Appraisal', 'Ordinary Appraisal '))
GROUP BY Year_of_WP, Category
ORDER BY Year_of_WP