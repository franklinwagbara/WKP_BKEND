CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_contract_type_pivoted]
AS

  -- Pivot table with one row and five columns  
SELECT Contract_Type AS Contract_Type,   
[2010],[2011],[2012],[2013],[2014],[2015],[2016],[2017],[2018],[2019],[2020],[2021],[2022],[2023],[2024],[2025],[2026],[2027],[2028],[2029],[2030]
  
FROM  
(SELECT Contract_Type , Year_of_WP, Annual_Total_Production_by_CONTRACT_TYPE   
    FROM WP_GAS_PRODUCTION_ACTIVITIES_contract_type_tobe_pivoted) AS SourceTable  
PIVOT  
(  
SUM(Annual_Total_Production_by_CONTRACT_TYPE)  
FOR Year_of_WP IN ([2010],[2011],[2012],[2013],[2014],[2015],[2016],[2017],[2018],[2019],[2020],[2021],[2022],[2023],[2024],[2025],[2026],[2027],[2028],[2029],[2030])  
) AS PivotTable;