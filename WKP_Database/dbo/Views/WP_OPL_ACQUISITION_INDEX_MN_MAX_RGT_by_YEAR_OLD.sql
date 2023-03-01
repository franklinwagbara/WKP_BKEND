CREATE VIEW [dbo].[WP_OPL_ACQUISITION_INDEX_MN_MAX_RGT_by_YEAR_OLD]
AS
SELECT     Year_of_WP, MAX(Scaled_by_Reciprocal_GrandTotal_RGT) AS MAX_RGT, MIN(Scaled_by_Reciprocal_GrandTotal_RGT) AS MIN_RGT
FROM         (SELECT     b.CompanyName, b.Year_of_WP, b.Quantum_Acquired, b.Quantum_Approved, b.Unscaled_Score, d.Unscaled_Score_sum, 
                                              b.Unscaled_Score / CONVERT(decimal(18, 1), d.Unscaled_Score_sum) * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT
                       FROM          (SELECT     CompanyName, Year_of_WP, Quantum_Acquired, Quantum_Approved, Quantum_Acquired / CONVERT(decimal(18, 1), Quantum_Approved) 
                                                                      * 100 AS Unscaled_Score
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
                                                                                                    GROUP BY CompanyName, Year_of_WP) AS a_1) AS c
                                                    GROUP BY Year_of_WP) AS d ON b.Year_of_WP = d.Year_of_WP) AS f
GROUP BY Year_of_WP