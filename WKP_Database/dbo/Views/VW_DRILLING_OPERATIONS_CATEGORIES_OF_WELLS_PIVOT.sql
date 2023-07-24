CREATE VIEW [dbo].[VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT]
AS
SELECT     OML_ID, OML_Name, CompanyName, Companyemail, Year_of_WP, MAX(CASE WHEN Category = 'Exploration' THEN Actual_no_drilled_in_current_year END) 
                      AS Exploration_Actual, MAX(CASE WHEN Category = 'Development' THEN Actual_no_drilled_in_current_year END) AS Development_Actual, 
                      MAX(CASE WHEN Category = 'Appraisal' THEN Actual_no_drilled_in_current_year END) AS Appraisal_Actual, 
                      MAX(CASE WHEN Category = 'Exploration' THEN Proposed_No_Drilled END) AS Exploration_Proposed, 
                      MAX(CASE WHEN Category = 'Development' THEN Proposed_No_Drilled END) AS Development_Proposed, 
                      MAX(CASE WHEN Category = 'Appraisal' THEN Proposed_No_Drilled END) AS Appraisal_Proposed
FROM         dbo.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS
GROUP BY OML_ID, OML_Name, CompanyName, Companyemail, Year_of_WP