
CREATE VIEW [dbo].[WP_OPL_Aggregated_Score_ALL_COMPANIES_WITHOUT_INDEX_TYPE]
AS
SELECT     CompanyName, Consession_Type, Year_of_WP, Recalibrated_Scaled_Index_SUM, Weight_SUM, Weighted_Score_SUM, 
                     -- Weighted_Score_SUM / CONVERT(decimal(18, 3), Weight_SUM) AS OPL_Aggregated_Score

					    ISNULL(Weighted_Score_SUM / NULLIF(Weight_SUM, 0), 0) AS OPL_Aggregated_Score
FROM         (SELECT     CompanyName, Consession_Type, Year_of_WP, SUM(CAST(Recalibrated_Scaled_Index AS NUMERIC(20,2) )) AS Recalibrated_Scaled_Index_SUM, 
                                              SUM(CAST(Weight AS NUMERIC(20,2) )) AS Weight_SUM, SUM(CAST(Weighted_Score AS NUMERIC(20,2) )) AS Weighted_Score_SUM
                       FROM          (SELECT     CompanyName, Consession_Type, Year_of_WP, INDEX_TYPE, Recalibrated_Scaled_Index, Weight, Weighted_Score
                                               FROM          dbo.WP_OPL_ACQUSITION_INDEX_WEIGHTED_SCORE
                                               UNION ALL
                                               --SELECT     CompanyName, Consession_Type, Year_of_WP, INDEX_TYPE, Recalibrated_Scaled_Index, Weight, Weighted_Score
                                               --FROM         dbo.WP_OPL_COMPLIANCE_INDEX_WEIGHTED_SCORE
                                               --UNION ALL
                                               SELECT     CompanyName, Consession_Type, Year_of_WP, INDEX_TYPE, Recalibrated_Scaled_Index, Weight, Weighted_Score
                                               FROM         dbo.WP_OPL_EXPLORATORY_DRILLING_INDEX_WEIGHTED_SCORE
                                               UNION ALL
                                               SELECT     CompanyName, Consession_Type, Year_of_WP, INDEX_TYPE, Recalibrated_Scaled_Index, Weight, Weighted_Score
                                               FROM         dbo.WP_OPL_DISCOVERY_INDEX_WEIGHTED_SCORE
                                               UNION ALL
                                               SELECT     CompanyName, Consession_Type, Year AS YEAR_OF_WP, INDEX_TYPE, Recalibrated_Scaled_Index, Weight, Weighted_Score
                                               FROM         dbo.WP_OPL_CONCESSION_RENTALS_INDEX_WEIGHTED_SCORE) AS SUM_ALL
                       GROUP BY CompanyName, Consession_Type, Year_of_WP) AS OPL_Aggregated_Score