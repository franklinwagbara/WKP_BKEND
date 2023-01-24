﻿CREATE VIEW [dbo].[WP_OML_FATALITY_INDEX_WEIGHTED_SCORE]
AS


SELECT     I.CompanyName, I.Year_of_WP, I.Consession_Type, I.Unscaled_Score, I.Unscaled_Score_sum, I.Scaled_by_Reciprocal_GrandTotal_RGT, I.MAX_RGT, I.MIN_RGT, 
                      I.Recalibrated_Scaled_Index, J.Weight, I.Recalibrated_Scaled_Index * J.Weight AS Weighted_Score, I.INDEX_TYPE
FROM         (SELECT     CompanyName, Year_of_WP, Consession_Type, Unscaled_Score, Unscaled_Score_sum, Scaled_by_Reciprocal_GrandTotal_RGT, MAX_RGT, MIN_RGT, 
                                              MIN_RGT + ISNULL((Scaled_by_Reciprocal_GrandTotal_RGT - MIN_RGT) / NULLIF ((MAX_RGT - MIN_RGT) * (100 - 0), 0), 0) AS Recalibrated_Scaled_Index, 
                                              'Fatality Index' AS INDEX_TYPE
                       FROM          (SELECT     F.CompanyName, F.Year_of_WP, F.Consession_Type, F.Unscaled_Score, F.Unscaled_Score_sum, F.Scaled_by_Reciprocal_GrandTotal_RGT, 
                                                                      G.MAX_RGT, G.MIN_RGT
                                               FROM          (SELECT     D.CompanyName, D.Year_of_WP, D.Consession_Type, D.Unscaled_Score, E.Unscaled_Score_sum, 
                                                                                              ISNULL(D.Unscaled_Score / NULLIF (CONVERT(decimal(18, 1), E.Unscaled_Score_sum), 0) * 100, 0) 
                                                                                              AS Scaled_by_Reciprocal_GrandTotal_RGT
                                                                       FROM          (SELECT DISTINCT CompanyName, Year_of_WP, Consession_Type, MAX(Unscaled_Score) AS Unscaled_Score
                                                                                               FROM          (SELECT     CompanyName, Year_of_WP, Consession_Type, 
                                                                                               
                                                                                                                               CASE WHEN Consequence = 'FATALITY' THEN 0 
                                                                                                                               -- ELSE '100'
                                                                                                                              END AS Unscaled_Score
                                                                                                                              
                                                                                                                       FROM          dbo.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW
                                                                                                                      -- WHERE      (Consession_Type = 'OML')
                                                                                                                      ) AS A
                                                                                               GROUP BY CompanyName, Year_of_WP, Consession_Type) AS D INNER JOIN
                                                                                                  (SELECT     Year_of_WP, SUM(Unscaled_Score) AS Unscaled_Score_sum
                                                                                                    FROM          (SELECT DISTINCT CompanyName, Year_of_WP, Consession_Type, MAX(Unscaled_Score) AS Unscaled_Score
                                                                                                                            FROM          (SELECT     CompanyName, Year_of_WP, Consession_Type, 
                                                                                                                            
                                                                                                                             CASE WHEN Consequence = 'FATALITY' THEN 0 
                                                                                                                               -- ELSE '100'
                                                                                                                              END AS Unscaled_Score
                                                                                                                              
                                                                                                                                                    FROM          dbo.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW AS HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_1
                                                                                                                                                  --  WHERE      (Consession_Type = 'OML')
                                                                                                                                                  ) AS A
                                                                                                                            GROUP BY CompanyName, Year_of_WP, Consession_Type) AS c
                                                                                                    GROUP BY Year_of_WP) AS E ON D.Year_of_WP = E.Year_of_WP) AS F INNER JOIN
                                                                      dbo.WP_OML_INJURY_Index_MN_MAX_RGT_by_Year_of_WP AS G ON F.Year_of_WP = G.Year_of_WP) AS H) AS I INNER JOIN
                          (SELECT     INDEX_TYPE, Weight, CONCESSIONTYPE
                            FROM          dbo.ADMIN_PERFOMANCE_INDEX
                            WHERE      (CONCESSIONTYPE = 'OML') AND (INDEX_TYPE = 'Fatality Index')) AS J ON I.INDEX_TYPE = J.INDEX_TYPE
