CREATE VIEW [dbo].[VW_GAS_PRODUCTION_ACTIVITIES_total]
AS
SELECT     Contract_Type, SUM(CAST(Current_Actual_Year AS int)) AS Current_Actual_Year, SUM(CAST(Utilized AS int)) AS Utilized, SUM(CAST(Flared AS int)) AS Flared, 
                      SUM(CAST(Forecast_ AS int)) AS Forecast_, Year_of_WP
FROM         dbo.VW_GAS_PRODUCTION_ACTIVITIES
GROUP BY Contract_Type, Year_of_WP