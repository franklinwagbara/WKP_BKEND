CREATE VIEW [dbo].[WP_OML_Concession_Rentals_Index_MN_MAX_RGT_by_YEAR]
AS


SELECT     Year, MAX(Scaled_by_Reciprocal_GrandTotal_RGT) AS MAX_RGT, MIN(Scaled_by_Reciprocal_GrandTotal_RGT) AS MIN_RGT
FROM         (SELECT     D.CompanyName, D.Year, D.Consession_Type, D.Unscaled_Score, E.Unscaled_Score_sum, 
                                              ISNULL(D.Unscaled_Score / NULLIF (CONVERT(decimal(18, 1), E.Unscaled_Score_sum), 0) * 100, 0) AS Scaled_by_Reciprocal_GrandTotal_RGT
                       FROM          (SELECT DISTINCT CompanyName, Year, Consession_Type, MAX(Unscaled_Score) AS Unscaled_Score
                                               FROM          (SELECT     CompanyName, Year, Has_the_Concession_Rentals_been_paid, Consession_Type, 
                                                                                              CASE WHEN Has_the_Concession_Rentals_been_paid = 'YES' THEN 100 
                                                                                                                                ELSE '0'
                                                                                                                              END AS Unscaled_Score
                                                                                                                              
                                                                       FROM          dbo.CONCESSION_SITUATION
                                                                       WHERE      (Consession_Type = 'OML')) AS A
                                               GROUP BY CompanyName, Year, Consession_Type) AS D INNER JOIN
                                                  (SELECT     Year, SUM(Unscaled_Score) AS Unscaled_Score_sum
                                                    FROM          (SELECT DISTINCT CompanyName, Year, Consession_Type, MAX(Unscaled_Score) AS Unscaled_Score
                                                                            FROM          (SELECT     CompanyName, Year, Has_the_Concession_Rentals_been_paid, Consession_Type, 
                                                                                                                           CASE WHEN Has_the_Concession_Rentals_been_paid = 'YES' THEN 100 
                                                                                                                                ELSE '0'
                                                                                                                              END AS Unscaled_Score
                                                                                                                              
                                                                                                    FROM          dbo.CONCESSION_SITUATION AS CONCESSION_SITUATION_1
                                                                                                    WHERE      (Consession_Type = 'OML')) AS A_1
                                                                            GROUP BY CompanyName, Year, Consession_Type) AS c
                                                    GROUP BY Year) AS E ON D.Year = E.Year) AS F
GROUP BY Year