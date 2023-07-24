CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Five_Year_Trend_for_Companies_Reserve_Replacement_Ratio]
AS

  
  -- Pivot table with one row and five columns  
SELECT CompanyName AS CompanyName,   
[2010],[2011],[2012],[2013],[2014],[2015],[2016],[2017],[2018],[2019],[2020],[2021],[2022],[2023],[2024],[2025],[2026],[2027],[2028],[2029],[2030]
  
FROM  
(SELECT CompanyName , Year_of_WP, SUM(CAST(Production AS int)) AS Production   
    FROM OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities group by CompanyName , Year_of_WP) AS SourceTable  
PIVOT  
(  
SUM(Production)  
FOR Year_of_WP IN ([2010],[2011],[2012],[2013],[2014],[2015],[2016],[2017],[2018],[2019],[2020],[2021],[2022],[2023],[2024],[2025],[2026],[2027],[2028],[2029],[2030])  
) AS PivotTable;