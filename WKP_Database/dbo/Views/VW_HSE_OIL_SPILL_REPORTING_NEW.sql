CREATE VIEW [dbo].[VW_HSE_OIL_SPILL_REPORTING_NEW]
AS
SELECT DISTINCT a.CompanyName, a.Contract_Type, a.COMPANY_EMAIL, b.Year_of_WP, b.Volume_of_spill_bbls, b.Volume_recovered_bbls, b.Companyemail
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION AS a INNER JOIN
                      dbo.HSE_OIL_SPILL_REPORTING_NEW AS b ON a.COMPANY_EMAIL = b.Companyemail