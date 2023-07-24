CREATE VIEW [dbo].[WP_OML_INCREMENT_IN_PRODUCTION_INDEX_MN_MAX_RGT_by_YEAR]
AS

SELECT     Year_of_WP, MAX(Scaled_by_Reciprocal_GrandTotal_RGT) AS MAX_RGT, MIN(Scaled_by_Reciprocal_GrandTotal_RGT) AS MIN_RGT
FROM         (SELECT     a.CompanyName, a.Year_of_WP, a.Consession_Type, a.Unscaled_Score, 
                                              b.Unscaled_Score_sum, ISNULL(a.Unscaled_Score / NULLIF (CONVERT(decimal(18, 1), b.Unscaled_Score_sum), 0) * 100, 0) 
                                              AS Scaled_by_Reciprocal_GrandTotal_RGT
                       FROM          (SELECT     CompanyName, Year_of_WP, Consession_Type, 
                                                                      Unscaled_Score
                                               FROM          dbo.WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1) AS a INNER JOIN
                                                  (SELECT     Year_of_WP, Consession_Type, SUM(CAST(Unscaled_Score AS int)) AS Unscaled_Score_sum
                                                   FROM dbo.WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1 AS WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1
                                                    GROUP BY Year_of_WP, Consession_Type) AS b ON a.Year_of_WP = b.Year_of_WP) AS d
GROUP BY Year_of_WP