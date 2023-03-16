CREATE VIEW [dbo].[WP_Gas_Production_Utilisation_And_Flaring_Forecast]
AS
SELECT     Year_of_WP, Current_Actual_Year, Utilized, Flared, CONVERT(decimal(18, 2), Flared) / Current_Actual_Year * 100 AS Percentage_flared, CONVERT(decimal(18, 2), 
                      Utilized) / Current_Actual_Year * 100 AS Percentage_Utilized
FROM         (SELECT     Year_of_WP, SUM(CAST(proposed_production AS int)) AS Current_Actual_Year, SUM(CAST(proposed_utilization AS int)) AS Utilized, 
                                              SUM(CAST(proposed_flaring AS int)) AS Flared
                       FROM          dbo.GAS_PRODUCTION_ACTIVITIES
                       GROUP BY Year_of_WP) AS SUB