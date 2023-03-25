
CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_contract_type_basis]
AS
SELECT DISTINCT 
                      a.Contract_Type, a.Total_GAS_Production_by_company, a.Year_of_WP, b.Total_GAS_Production_by_year, CONVERT(decimal(18, 2), 
                      a.Total_GAS_Production_by_company) / b.Total_GAS_Production_by_year * 100 AS Percentage_Production
FROM         (SELECT     Contract_Type, SUM(CAST(Current_Actual_Year AS decimal)) AS Total_GAS_Production_by_company, Year_of_WP
                       FROM          dbo.GAS_PRODUCTION_ACTIVITIES
                       GROUP BY Contract_Type, Year_of_WP) AS a INNER JOIN
                          (SELECT     SUM(CAST(Current_Actual_Year AS decimal)) AS Total_GAS_Production_by_year, Year_of_WP
                            FROM          dbo.GAS_PRODUCTION_ACTIVITIES AS GAS_PRODUCTION_ACTIVITIES_1
                            GROUP BY Year_of_WP) AS b ON a.Year_of_WP = b.Year_of_WP