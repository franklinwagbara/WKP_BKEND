CREATE VIEW [dbo].[VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover _join_Contracttype]
AS
SELECT DISTINCT 
                      a.CompanyName, a.Contract_Type, a.COMPANY_EMAIL, b.oml_name_VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT, b.CompanyName AS Expr8, 
                      b.Companyemail, b.Year_of_WP, b.Exploration_Actual, b.Development_Actual, b.Appraisal_Actual, b.Exploration_Proposed, b.Development_Proposed, 
                      b.Appraisal_Proposed, b.oml_name_INITIAL_WELL_COMPLETION_JOBS, b.Expr1, b.Expr2, b.Expr3, b.Current_year_Actual_Number, b.Proposed_year_data, 
                      b.OML_name_WORKOVERS_RECOMPLETION_JOBS, b.Expr4, b.Expr5, b.Expr6, b.Current_year_Actual_Number_data, b.Expr7
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION AS a INNER JOIN
                      dbo.VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover AS b ON a.COMPANY_EMAIL = b.Companyemail