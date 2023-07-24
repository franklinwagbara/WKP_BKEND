CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted]
AS
SELECT     TOP (100) PERCENT Terrain, SUM(CAST(Production AS int)) AS Annual_Total_Production_by_company, Year_of_WP
FROM         dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities
GROUP BY Terrain, Year_of_WP
ORDER BY Year_of_WP