CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_Terrain_Pivoted_PLANNED]
AS


  -- Pivot table with one row and five columns  
SELECT Terrain AS Terrain,   
[2010],[2011],[2012],[2013],[2014],[2015],[2016],[2017],[2018],[2019],[2020],[2021],[2022],[2023],[2024],[2025],[2026],[2027],[2028],[2029],[2030]
  
FROM  
(SELECT Terrain , Year_of_WP, Annual_Total_Production_by_company   
    FROM WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_tobe_Pivoted_PLANNED) AS SourceTable  
	       
PIVOT  
(  
SUM(Annual_Total_Production_by_company)  
FOR Year_of_WP IN ([2010],[2011],[2012],[2013],[2014],[2015],[2016],[2017],[2018],[2019],[2020],[2021],[2022],[2023],[2024],[2025],[2026],[2027],[2028],[2029],[2030])  
) AS PivotTable;