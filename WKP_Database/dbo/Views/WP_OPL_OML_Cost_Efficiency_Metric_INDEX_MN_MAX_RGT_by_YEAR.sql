
CREATE VIEW [dbo].[WP_OPL_OML_Cost_Efficiency_Metric_INDEX_MN_MAX_RGT_by_YEAR]
AS

SELECT     Year_of_WP, MAX(Scaled_by_Reciprocal_GrandTotal_RGT) AS MAX_RGT, MIN(Scaled_by_Reciprocal_GrandTotal_RGT) AS MIN_RGT
FROM         (SELECT     b.CompanyName, b.Year_of_WP, b.CAPEX_PLUS_OPEX, b.Production, b.Unscaled_Score, d.Unscaled_Score_sum, 
                                             -- b.Unscaled_Score / CONVERT(decimal(18, 1), d.Unscaled_Score_sum) * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT
											   ISNULL( b.Unscaled_Score / NULLIF(d.Unscaled_Score_sum, 0), 0)  * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT
                       FROM          (SELECT     CompanyName, Year_of_WP, CAPEX_PLUS_OPEX, Production,
					   
					--   Production / CONVERT(decimal(18, 1), CAPEX_PLUS_OPEX) * 100 AS Unscaled_Score
																	    ISNULL( Production / NULLIF(CAPEX_PLUS_OPEX, 0), 0)  * 100 AS Unscaled_Score


                                               FROM          (SELECT     CompanyName, Year_of_WP, SUM(CAST(CAPEX_PLUS_OPEX AS  NUMERIC(20,2) )) AS CAPEX_PLUS_OPEX, SUM(CAST(Production AS  NUMERIC(20,2) )) 
                                                                                              AS Production
                                                                       FROM          dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION
                                                                       GROUP BY CompanyName, Year_of_WP) AS a) AS b INNER JOIN
                                                  (SELECT     Year_of_WP, SUM(Unscaled_Score) AS Unscaled_Score_sum
                                                    FROM          (SELECT     CompanyName, Year_of_WP, CAPEX_PLUS_OPEX, Production,
													
													--Production / CONVERT(decimal(18, 1), CAPEX_PLUS_OPEX) * 100 AS Unscaled_Score
													
											  ISNULL( Production / NULLIF(CAPEX_PLUS_OPEX, 0), 0)  * 100 AS Unscaled_Score


                                                                            FROM          (SELECT     CompanyName, Year_of_WP, CAPEX_PLUS_OPEX, Production
                                                                                                    FROM          dbo.WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION AS WP_Cost_Efficiency_Metric_CAPEX_OPEX_PRODUCTION_1)
                                                                                                    AS a_1) AS c
                                                    GROUP BY Year_of_WP) AS d ON b.Year_of_WP = d.Year_of_WP) AS f
GROUP BY Year_of_WP