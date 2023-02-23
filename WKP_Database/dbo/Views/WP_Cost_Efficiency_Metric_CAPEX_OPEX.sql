
CREATE VIEW [dbo].[WP_Cost_Efficiency_Metric_CAPEX_OPEX]
AS

--SELECT     CompanyName, Year_of_WP, SUM(CAST(naira AS int)) AS naira , Consession_Type

SELECT     CompanyName, Year_of_WP, SUM(CAST(naira AS decimal(18, 2))) AS naira , Consession_Type

FROM dbo.BUDGET_CAPEX_OPEX WHERE Consession_Type = 'OML'

GROUP BY CompanyName, Year_of_WP , Consession_Type