CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year]
AS
SELECT     CompanyName, Production_month, SUM(CAST(Production AS int)) AS Annual_Total_Production_by_company_name, Year_of_WP
FROM         dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities
GROUP BY CompanyName, Production_month, Year_of_WP