CREATE VIEW [dbo].[VW_GAS_PRODUCTION_ACTIVITIES_total_summed]
AS
SELECT     Year_of_WP, SUM(Current_Actual_Year) AS Current_Actual_Year, SUM(Utilized) AS Utilized, SUM(Flared) AS Flared, SUM(Forecast_) AS Forecast_
FROM         dbo.VW_GAS_PRODUCTION_ACTIVITIES_total
GROUP BY Year_of_WP