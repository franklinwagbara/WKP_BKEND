CREATE VIEW [dbo].[WP_Cost_Efficiency_Metric_NET_PRODUCTION_OLD]
AS
SELECT     CompanyName, Year_of_WP, SUM(CAST(Production AS int)) AS Production
FROM         dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities AS OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_1
WHERE     (Consession_Type = 'OML')
GROUP BY CompanyName, Year_of_WP