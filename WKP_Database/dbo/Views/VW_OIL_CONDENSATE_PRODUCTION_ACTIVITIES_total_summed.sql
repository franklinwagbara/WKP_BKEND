CREATE VIEW [dbo].[VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total_summed]
AS
SELECT     Year_of_WP, SUM(Current_year_Actual) AS Current_year_Actual, SUM(Deferment) AS Deferment, SUM(Forecast) AS Forecast, SUM(Cost_Barrel) AS Cost_Barrel
FROM         dbo.VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total
GROUP BY Year_of_WP