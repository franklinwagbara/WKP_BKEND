CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_PROPOSED]
AS


SELECT DISTINCT 
                      a.CompanyName, a.Contract_Type, a.Terrain, a.Annual_Total_Production_by_company, a.Annual_Avg_Daily_Production, a.Year_of_WP, 
                      b.Annual_Total_Production_by_year, CONVERT(decimal(18, 2), a.Annual_Total_Production_by_company) 
                      / b.Annual_Total_Production_by_year * 100 AS Percentage_Production
FROM         (SELECT     CompanyName, Contract_Type, Terrain, SUM(CAST(Production AS int)) AS Annual_Total_Production_by_company, SUM(CONVERT(decimal(18, 2), 
                                              Avg_Daily_Production)) / COUNT(Avg_Daily_Production) AS Annual_Avg_Daily_Production, Year_of_WP
                       FROM          dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED
                       GROUP BY CompanyName, Contract_Type, Terrain, Year_of_WP) AS a INNER JOIN
                          (SELECT     SUM(CAST(Production AS int)) AS Annual_Total_Production_by_year, Year_of_WP
                            FROM          dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_PROPOSED AS OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_1
                            GROUP BY Year_of_WP) AS b ON a.Year_of_WP = b.Year_of_WP