CREATE VIEW [dbo].[VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_total]
AS
SELECT     Contract_Type, SUM(CAST(Current_year_Actual AS int)) AS Current_year_Actual, SUM(CAST(Deferment AS int)) AS Deferment, SUM(CAST(Forecast AS int)) AS Forecast, 
                      SUM(CAST(Cost_Barrel AS int)) AS Cost_Barrel, Year_of_WP
FROM         dbo.VW_OIL_CONDENSATE_PRODUCTION_ACTIVITIES
GROUP BY Contract_Type, Year_of_WP