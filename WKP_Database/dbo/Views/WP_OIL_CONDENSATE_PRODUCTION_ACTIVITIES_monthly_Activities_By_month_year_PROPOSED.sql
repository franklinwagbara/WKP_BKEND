CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_By_month_year_PROPOSED]
AS


SELECT     TOP (100) PERCENT Production_month_id, Production_month, SUM(CAST(Production AS int)) AS Annual_Total_Production_by_company, SUM(CONVERT(decimal(18, 2), 
                      Avg_Daily_Production)) / COUNT(Avg_Daily_Production) AS Annual_Avg_Daily_Production, Year_of_WP
FROM         dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED
GROUP BY Production_month, Production_month_id, Year_of_WP
ORDER BY Production_month_id