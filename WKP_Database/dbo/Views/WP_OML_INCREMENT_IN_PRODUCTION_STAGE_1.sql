/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[WP_OML_INCREMENT_IN_PRODUCTION_STAGE_1]
AS


SELECT     A.CompanyName, A.Year_of_WP AS Year_of_WP_PREVIOUS,A.Consession_Type, A.Production_SUM AS Production_SUM_PREVIOUS_YEAR, 
                      B.Production_SUM AS Production_SUM_CURRENT_YEAR, B.Year_of_WP , (B.Production_SUM - A.Production_SUM) 
                      / CONVERT(decimal(18, 3), A.Production_SUM) * 100 AS Unscaled_Score
FROM         (SELECT     CompanyName, Year_of_WP, Production_SUM , Consession_Type
                       FROM          (SELECT     CompanyName,Consession_Type, CAST(Year_of_WP AS int) AS Year_of_WP, SUM(CAST(Production AS int)) AS Production_SUM
                                               FROM          dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities
                                               GROUP BY CompanyName, Year_of_WP , Consession_Type) AS SUB
                       WHERE      (Year_of_WP = YEAR(CURRENT_TIMESTAMP) - 1)) AS A INNER JOIN
                          (SELECT     CompanyName, Year_of_WP, Production_SUM , Consession_Type
                            FROM          (SELECT     CompanyName, CAST(Year_of_WP AS int) AS Year_of_WP, SUM(CAST(Production AS int)) AS Production_SUM , Consession_Type
                                                    FROM          dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities AS OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_1
                                                    GROUP BY CompanyName, Year_of_WP , Consession_Type) AS SUB
                            WHERE      (Year_of_WP = YEAR(CURRENT_TIMESTAMP))) AS B ON A.CompanyName = B.CompanyName