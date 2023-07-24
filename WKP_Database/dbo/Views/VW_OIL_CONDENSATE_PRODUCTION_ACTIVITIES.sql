CREATE VIEW [dbo].[VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES]
AS
SELECT DISTINCT 
                      a.CompanyName, a.Contract_Type, a.COMPANY_EMAIL, b.Year_of_WP, b.Current_year_Actual, b.Deferment, b.Forecast, b.Cost_Barrel, b.Companyemail
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION AS a INNER JOIN
                      dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES AS b ON a.COMPANY_EMAIL = b.Companyemail