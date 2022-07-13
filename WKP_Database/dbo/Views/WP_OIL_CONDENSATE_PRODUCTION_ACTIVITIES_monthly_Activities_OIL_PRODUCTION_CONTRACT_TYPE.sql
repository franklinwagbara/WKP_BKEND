﻿CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE]
AS
SELECT DISTINCT 
                      a.Contract_Type, a.Annual_Total_Production_by_company, a.Year_of_WP, b.Annual_Total_Production_by_year, CONVERT(decimal(18, 2), 
                      a.Annual_Total_Production_by_company) / b.Annual_Total_Production_by_year * 100 AS Percentage_Production
FROM         (SELECT     Contract_Type, SUM(CAST(Production AS int)) AS Annual_Total_Production_by_company, Year_of_WP
                       FROM          dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities
                       GROUP BY Contract_Type, Year_of_WP) AS a INNER JOIN
                          (SELECT     SUM(CAST(Production AS int)) AS Annual_Total_Production_by_year, Year_of_WP
                            FROM          dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities AS OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_1
                            GROUP BY Year_of_WP) AS b ON a.Year_of_WP = b.Year_of_WP
