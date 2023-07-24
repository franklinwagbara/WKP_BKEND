/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE_OLD]
AS
SELECT     H.CompanyName, H.Quantum_Acquired, H.Quantum_Approved, H.Unscaled_Score, H.Unscaled_Score_sum, H.Scaled_by_Reciprocal_GrandTotal_RGT, 
                      H.Year_of_WP, H.MAX_RGT, H.MIN_RGT, H.Recalibrated_Scaled_Index, I.INDEX_TYPE, I.Weight, H.Recalibrated_Scaled_Index * I.Weight AS Weighted_Score, 
                      H.Consession_Type
FROM         (SELECT     E.CompanyName, E.Quantum_Acquired, E.Quantum_Approved, E.Unscaled_Score, E.Unscaled_Score_sum, E.Scaled_by_Reciprocal_GrandTotal_RGT, 
                                              F.Year_of_WP, F.MAX_RGT, F.MIN_RGT, F.MIN_RGT + (E.Scaled_by_Reciprocal_GrandTotal_RGT - F.MIN_RGT) / NULLIF ((F.MAX_RGT - F.MIN_RGT) 
                                              * (100 - 0), 0) AS Recalibrated_Scaled_Index, 'Acquisition Index' AS INDEX_TYPE, 'OPL' AS Consession_Type
                       FROM          (SELECT     b.CompanyName, b.Year_of_WP, b.Quantum_Acquired, b.Quantum_Approved, b.Unscaled_Score, d.Unscaled_Score_sum, 
                                                                      b.Unscaled_Score / CONVERT(decimal(18, 1), d.Unscaled_Score_sum) * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT
                                               FROM          (SELECT     CompanyName, Year_of_WP, Quantum_Acquired, Quantum_Approved, Quantum_Acquired / CONVERT(decimal(18, 1), 
                                                                                              Quantum_Approved) * 100 AS Unscaled_Score
                                                                       FROM          (SELECT     CompanyName, Year_of_WP, SUM(CAST(Quantum AS int)) AS Quantum_Acquired, SUM(CAST(Quantum_Approved AS int)) 
                                                                                                                      AS Quantum_Approved
                                                                                               FROM          dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION
                                                                                               GROUP BY CompanyName, Year_of_WP) AS a) AS b INNER JOIN
                                                                          (SELECT     Year_of_WP, SUM(Unscaled_Score) AS Unscaled_Score_sum
                                                                            FROM          (SELECT     CompanyName, Year_of_WP, Quantum_Acquired, Quantum_Approved, Quantum_Acquired / CONVERT(decimal(18, 1), 
                                                                                                                           Quantum_Approved) * 100 AS Unscaled_Score
                                                                                                    FROM          (SELECT     CompanyName, Year_of_WP, SUM(CAST(Quantum AS int)) AS Quantum_Acquired, 
                                                                                                                                                   SUM(CAST(Quantum_Approved AS int)) AS Quantum_Approved
                                                                                                                            FROM          dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION AS GEOPHYSICAL_ACTIVITIES_ACQUISITION_1
                                                                                                                            WHERE      (Consession_Type = 'OPL')
                                                                                                                            GROUP BY CompanyName, Year_of_WP) AS a) AS c
                                                                            GROUP BY Year_of_WP) AS d ON b.Year_of_WP = d.Year_of_WP) AS E INNER JOIN
                                                  (SELECT     Year_of_WP, MAX_RGT, MIN_RGT
                                                    FROM          dbo.WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR) AS F ON E.Year_of_WP = F.Year_of_WP) AS H INNER JOIN
                          (SELECT     INDEX_TYPE, Weight, CONCESSIONTYPE
                            FROM          dbo.ADMIN_PERFOMANCE_INDEX
                            WHERE      (CONCESSIONTYPE = 'OPL') AND (INDEX_TYPE = 'Acquisition Index')) AS I ON H.INDEX_TYPE = I.INDEX_TYPE