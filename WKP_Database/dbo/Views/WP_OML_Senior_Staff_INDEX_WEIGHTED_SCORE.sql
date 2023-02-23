
CREATE VIEW [dbo].[WP_OML_Senior_Staff_INDEX_WEIGHTED_SCORE]
AS



SELECT     H.CompanyName, H.Utilized, H.Produced, H.Unscaled_Score, H.Unscaled_Score_sum, H.Scaled_by_Reciprocal_GrandTotal_RGT, 
                      H.Year_of_WP, H.MAX_RGT, H.MIN_RGT, H.Recalibrated_Scaled_Index, I.INDEX_TYPE, I.Weight, H.Recalibrated_Scaled_Index * I.Weight AS Weighted_Score, 
                      H.Consession_Type
FROM         (SELECT     E.CompanyName, E.Utilized, E.Produced, E.Unscaled_Score, E.Unscaled_Score_sum, E.Scaled_by_Reciprocal_GrandTotal_RGT,
 
         F.Year_of_WP, F.MAX_RGT, F.MIN_RGT, F.MIN_RGT + ISNULL((E.Scaled_by_Reciprocal_GrandTotal_RGT - F.MIN_RGT) / NULLIF ((F.MAX_RGT - F.MIN_RGT) * (100 - 0), 0),0) AS Recalibrated_Scaled_Index, 'Senior Staff' AS INDEX_TYPE, 'OML' AS Consession_Type
                     
                     
                       FROM          (SELECT     b.CompanyName, b.Year_of_WP, b.Utilized, b.Produced, b.Unscaled_Score, d.Unscaled_Score_sum, 

                                            --  b.Unscaled_Score / CONVERT(decimal(18, 1), d.Unscaled_Score_sum) * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT

											  ISNULL( b.Unscaled_Score / NULLIF(d.Unscaled_Score_sum, 0), 0)  * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT
                                               FROM          (SELECT     CompanyName, Year_of_WP, Utilized, Produced, 
											   
											   -- Utilized / CONVERT(decimal(18, 1), Produced) * 100 AS Unscaled_Score
											   ISNULL( Utilized / NULLIF(Produced, 0), 0)  * 100 AS Unscaled_Score

                                                                       FROM          (SELECT     CompanyName, Year_of_WP, SUM(CAST(total_no_of_nigeria_senior_staff AS NUMERIC(20,2) )) AS Utilized, SUM(CAST(total_no_of_senior_staff AS NUMERIC(20,2) )) 
                                                                                              AS Produced
                                                                       FROM          dbo.NIGERIA_CONTENT_QUESTION
                                                                                               GROUP BY CompanyName, Year_of_WP) AS a) AS b INNER JOIN
                                                                          (SELECT     Year_of_WP, SUM(Unscaled_Score) AS Unscaled_Score_sum
                                                                            FROM          (SELECT     CompanyName, Year_of_WP, Utilized, Produced, 
																			
																			-- Utilized / CONVERT(decimal(18, 1), Produced) * 100 AS Unscaled_Score
																			ISNULL( Utilized / NULLIF(Produced, 0), 0)  * 100 AS Unscaled_Score
                                                                                                    FROM          (  
                                                                                                    

																									SELECT  CompanyName, Year_of_WP, SUM(CAST(total_no_of_nigeria_senior_staff AS NUMERIC(20,2) )) AS Utilized, 
                                                                                                                           SUM(CAST(total_no_of_senior_staff AS NUMERIC(20,2) )) AS Produced , Consession_Type
                                                                                                    FROM          dbo.NIGERIA_CONTENT_QUESTION AS NIGERIA_CONTENT_QUESTION_1
                                                                                                                      WHERE      Consession_Type = 'OML'
                                                                                                                            GROUP BY CompanyName, Year_of_WP , Consession_Type
                                                                                                                            
                                                                                                                            )AS a_1   ) AS c
                                                                            GROUP BY Year_of_WP) AS d ON b.Year_of_WP = d.Year_of_WP) AS E INNER JOIN
                                                  (SELECT     Year_of_WP, MAX_RGT, MIN_RGT
                                                    FROM          dbo.WP_OML_Senior_Staff_INDEX_MN_MAX_RGT_by_YEAR) AS F ON E.Year_of_WP = F.Year_of_WP) AS H INNER JOIN
                          (SELECT     INDEX_TYPE, Weight, CONCESSIONTYPE
                            FROM          dbo.ADMIN_PERFOMANCE_INDEX
                            WHERE      (CONCESSIONTYPE = 'OML') AND (INDEX_TYPE = 'Senior Staff')) AS I ON H.INDEX_TYPE = I.INDEX_TYPE