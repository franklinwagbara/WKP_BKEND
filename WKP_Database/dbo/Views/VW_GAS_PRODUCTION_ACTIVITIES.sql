CREATE VIEW [dbo].[VW_GAS_PRODUCTION_ACTIVITIES]
AS
SELECT DISTINCT a.CompanyName, a.Contract_Type, a.COMPANY_EMAIL, b.Year_of_WP, b.Current_Actual_Year, b.Utilized, b.Flared, b.Forecast_, b.Companyemail
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION AS a INNER JOIN
                      dbo.GAS_PRODUCTION_ACTIVITIES AS b ON a.COMPANY_EMAIL = b.Companyemail