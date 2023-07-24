CREATE VIEW [dbo].[WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION]
AS
SELECT     dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX.CompanyName, dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX.Year_of_WP, 
                      dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX.naira AS CAPEX_PLUS_OPEX, dbo.WP_Cost_Efficiency_Metric_NET_PRODUCTION.Production
FROM         dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX INNER JOIN
                      dbo.WP_Cost_Efficiency_Metric_NET_PRODUCTION ON 
                      dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX.CompanyName = dbo.WP_Cost_Efficiency_Metric_NET_PRODUCTION.CompanyName AND 
                      dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX.Year_of_WP = dbo.WP_Cost_Efficiency_Metric_NET_PRODUCTION.Year_of_WP