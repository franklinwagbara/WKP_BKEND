
CREATE VIEW [dbo].[WP_OML_Reserve_Replacement_Ratio_INDEX_MN_MAX_RGT_by_YEAR]
AS

SELECT     Year_of_WP, MAX(Scaled_by_Reciprocal_GrandTotal_RGT) AS MAX_RGT, MIN(Scaled_by_Reciprocal_GrandTotal_RGT) AS MIN_RGT
FROM         (SELECT     a.CompanyName, a.Year_of_WP, a.Consession_Type, a.Reserves_as_at_MMbbl_P1, a.Reserves_as_at_MMbbl, a.Total_Production_, a.Unscaled_Score, 
                                              b.Unscaled_Score_sum, ISNULL(a.Unscaled_Score / NULLIF (CONVERT(decimal(18, 1), b.Unscaled_Score_sum), 0) * 100, 0) 
                                              AS Scaled_by_Reciprocal_GrandTotal_RGT
                       FROM          (SELECT     CompanyName, Year_of_WP, Consession_Type, Reserves_as_at_MMbbl_P1, Reserves_as_at_MMbbl, Total_Production_, 
                                                                      Unscaled_Score
                                               FROM          dbo.WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1) AS a INNER JOIN
                                                  (SELECT     Year_of_WP, Consession_Type, SUM(CAST(Unscaled_Score AS NUMERIC(20,2) )) AS Unscaled_Score_sum
                                                    FROM          dbo.WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1 AS WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1_1
                                                    GROUP BY Year_of_WP, Consession_Type) AS b ON a.Year_of_WP = b.Year_of_WP) AS d
GROUP BY Year_of_WP