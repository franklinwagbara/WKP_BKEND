/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT_Completion_Workover]
AS
SELECT     a.OML_ID, a.OML_Name AS oml_name_VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT, a.CompanyName, a.Companyemail, a.Year_of_WP, 
                      a.Exploration_Actual, a.Development_Actual, a.Appraisal_Actual, a.Exploration_Proposed, a.Development_Proposed, a.Appraisal_Proposed, 
                      b.OML_Name AS oml_name_INITIAL_WELL_COMPLETION_JOBS, b.CompanyName AS Expr1, b.Companyemail AS Expr2, b.Year_of_WP AS Expr3, 
                      b.Current_year_Actual_Number, b.Proposed_year_data, c.OML_Name AS OML_name_WORKOVERS_RECOMPLETION_JOBS, c.CompanyName AS Expr4, 
                      c.Companyemail AS Expr5, c.Year_of_WP AS Expr6, c.Current_year_Actual_Number_data, c.Proposed_year_data AS Expr7
FROM         dbo.VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_PIVOT AS a INNER JOIN
                      dbo.INITIAL_WELL_COMPLETION_JOBS AS b ON a.Companyemail = b.Companyemail AND a.OML_Name = b.OML_Name INNER JOIN
                      dbo.WORKOVERS_RECOMPLETION_JOBS AS c ON b.Companyemail = c.Companyemail AND b.OML_Name = c.OML_Name