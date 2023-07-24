CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_Pivotted_by_company_productionmonth_year_breakdown]
AS

  -- Pivot table with one row and five columns  
SELECT CompanyName AS CompanyName, Year_of_WP  as Year_of_WP ,

January,February,March,April,May,June,July,August,September,October,November,December
  
FROM  
(SELECT CompanyName , Year_of_WP, Production_month ,Annual_Total_Production_by_company_name   
    FROM WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_TOBE_Pivotted_by_company_productionmonth_year) AS SourceTable  
PIVOT  
(  
SUM(Annual_Total_Production_by_company_name) 
FOR Production_month IN (January,February,March,April,May,June,July,August,September,October,November,December)  
) AS PivotTable;