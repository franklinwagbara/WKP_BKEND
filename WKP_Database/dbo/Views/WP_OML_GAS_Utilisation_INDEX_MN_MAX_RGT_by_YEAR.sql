

CREATE VIEW [dbo].[WP_OML_GAS_Utilisation_INDEX_MN_MAX_RGT_by_YEAR]
AS


SELECT     Year_of_WP, MAX(Scaled_by_Reciprocal_GrandTotal_RGT) AS MAX_RGT, MIN(Scaled_by_Reciprocal_GrandTotal_RGT) AS MIN_RGT
FROM         (SELECT     b.CompanyName, b.Year_of_WP, b.Utilized, b.Produced, b.Unscaled_Score, d.Unscaled_Score_sum, 
                                             -- b.Unscaled_Score / CONVERT(decimal(18, 1), d.Unscaled_Score_sum) * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT

											  ISNULL( b.Unscaled_Score / NULLIF(d.Unscaled_Score_sum, 0), 0)  * 100 AS Scaled_by_Reciprocal_GrandTotal_RGT

                       FROM          (SELECT     CompanyName, Year_of_WP, Utilized, Produced,
					   
					   --Utilized / CONVERT(decimal(18, 1), Produced) * 100 AS Unscaled_Score

					    ISNULL( Utilized / NULLIF(Produced, 0), 0)  * 100 AS Unscaled_Score

                                               FROM          (SELECT     CompanyName, Year_of_WP, SUM(CAST(Utilized AS NUMERIC(20,2) )) AS Utilized, SUM(CAST(Current_Actual_Year AS NUMERIC(20,2) )) 
                                                                                              AS Produced
                                                                       FROM          dbo.GAS_PRODUCTION_ACTIVITIES
                                                                       GROUP BY CompanyName, Year_of_WP) AS a) AS b INNER JOIN
                                                  (SELECT     Year_of_WP, SUM(Unscaled_Score) AS Unscaled_Score_sum
                                                    FROM          (SELECT     CompanyName, Year_of_WP, Utilized, Produced, 
													
												--	Utilized / CONVERT(decimal(18, 1), Produced) * 100 AS Unscaled_Score

												 ISNULL( Utilized / NULLIF(Produced, 0), 0)  * 100 AS Unscaled_Score

                                                                            FROM          (SELECT     CompanyName, Year_of_WP, SUM(CAST(Utilized AS NUMERIC(20,2) )) AS Utilized, 
                                                                                                                           SUM(CAST(Current_Actual_Year AS NUMERIC(20,2) )) AS Produced
                                                                                                    FROM          dbo.GAS_PRODUCTION_ACTIVITIES AS GAS_PRODUCTION_ACTIVITIES_1
                                                                                                    WHERE      (Consession_Type = 'OML')
                                                                                                    GROUP BY CompanyName, Year_of_WP) AS a_1) AS c
                                                    GROUP BY Year_of_WP) AS d ON b.Year_of_WP = d.Year_of_WP) AS f
GROUP BY Year_of_WP