CREATE VIEW [dbo].[WP_Cost_Efficiency_Metric_CAPEX_OPEX_OLD]
AS
SELECT     CompanyName, Year_of_WP, SUM(CAST(naira AS int)) AS naira
FROM         dbo.BUDGET_CAPEX_OPEX
GROUP BY CompanyName, Year_of_WP