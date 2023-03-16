
CREATE VIEW [dbo].[WP_OML_RESERVE_REPLACEMENT_RATIO_STAGE_1_OLD]
AS
SELECT     CONVERT(VARCHAR(256), CompanyName) AS CompanyName, CONVERT(VARCHAR(256), Year_of_WP) AS Year_of_WP, CONVERT(VARCHAR(256), Consession_Type) 
                      AS Consession_Type, Reserves_as_at_MMbbl, Reserves_as_at_MMbbl_P1, Total_Production_, (CAST(Reserves_as_at_MMbbl AS int) 
                      - CAST(Reserves_as_at_MMbbl_P1 AS int)) /  ISNULL ( NULLIF ( CONVERT(decimal(18, 1), Total_Production_),0),1) * 100 AS Unscaled_Score
FROM         (SELECT     CompanyName, Year_of_WP, Consession_Type, SUM(CAST(Reserves_as_at_MMbbl AS int)) AS Reserves_as_at_MMbbl, 
                                              SUM(CAST(Reserves_as_at_MMbbl_P1 AS int)) AS Reserves_as_at_MMbbl_P1, SUM(CAST(Total_Production_ AS int)) AS Total_Production_
                       FROM          dbo.RESERVES_UPDATES_OIL_CONDENSATE_MMBBL AS RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_1
                       WHERE      (Consession_Type = 'OML') -- and Total_Production_ != 0
                       GROUP BY CompanyName, Year_of_WP, Consession_Type) AS a