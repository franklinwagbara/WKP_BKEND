﻿CREATE VIEW [dbo].[WP_OML_Oil_spill_reported_Index_MN_MAX_RGT_by_Year_of_WP]
AS


SELECT     Year_of_WP, MAX(Scaled_by_Reciprocal_GrandTotal_RGT) AS MAX_RGT, MIN(Scaled_by_Reciprocal_GrandTotal_RGT) AS MIN_RGT
FROM         (SELECT     D.CompanyName, D.Year_of_WP, D.Consession_Type, D.Unscaled_Score, E.Unscaled_Score_sum, 
                                              ISNULL(D.Unscaled_Score / NULLIF (CONVERT(decimal(18, 1), E.Unscaled_Score_sum), 0) * 100, 0) AS Scaled_by_Reciprocal_GrandTotal_RGT
                       FROM          (SELECT DISTINCT CompanyName, Year_of_WP, Consession_Type, MAX(Unscaled_Score) AS Unscaled_Score
                                               FROM          (SELECT     CompanyName, Year_of_WP, Oil_spill_reported, Consession_Type, 
                                                                                              CASE WHEN Oil_spill_reported = 'YES' THEN 100 
                                                                                                                                ELSE '0'
                                                                                                                              END AS Unscaled_Score
                                                                                                                              
                                                                       FROM          dbo.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW
                                                                       WHERE      (Consession_Type = 'OML')) AS A
                                               GROUP BY CompanyName, Year_of_WP, Consession_Type) AS D INNER JOIN
                                                  (SELECT     Year_of_WP, SUM(Unscaled_Score) AS Unscaled_Score_sum
                                                    FROM          (SELECT DISTINCT CompanyName, Year_of_WP, Consession_Type, MAX(Unscaled_Score) AS Unscaled_Score
                                                                            FROM          (SELECT     CompanyName, Year_of_WP, Oil_spill_reported, Consession_Type, 
                                                                                                                           CASE WHEN Oil_spill_reported = 'YES' THEN 100 
                                                                                                                                ELSE '0'
                                                                                                                              END AS Unscaled_Score
                                                                                                                              
                                                                                                    FROM          dbo.HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW AS HSE_COMMUNITY_DISTURBANCES_AND_OIL_SPILL_COST_NEW_1
                                                                                                    WHERE      (Consession_Type = 'OML')) AS A_1
                                                                                                    
                                                                            GROUP BY CompanyName, Year_of_WP, Consession_Type) AS c
                                                    GROUP BY Year_of_WP) AS E ON D.Year_of_WP = E.Year_of_WP) AS F
GROUP BY Year_of_WP
