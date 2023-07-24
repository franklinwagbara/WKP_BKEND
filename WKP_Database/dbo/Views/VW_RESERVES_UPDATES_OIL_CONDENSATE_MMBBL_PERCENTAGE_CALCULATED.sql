CREATE VIEW [dbo].[VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_PERCENTAGE_CALCULATED]
AS
SELECT     c.Contract_Type, c.Total_Production_, c.Year_of_WP, d.Total_Production_ AS Total_Production_percentage, d.Year_of_WP AS Year_of_WP_percentage, 
                      c.Total_Production_ / d.Total_Production_ * 100 AS Percantage_Production
FROM         (SELECT     Contract_Type, SUM(CAST(Total_Production_ AS int)) AS Total_Production_, Year_of_WP
                       FROM          dbo.VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL
                       GROUP BY Contract_Type, Year_of_WP) AS c CROSS JOIN
                      dbo.VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_total_4_percentage_calculation AS d