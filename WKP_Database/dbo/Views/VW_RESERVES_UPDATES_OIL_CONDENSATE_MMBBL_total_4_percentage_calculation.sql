CREATE VIEW [dbo].[VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL_total_4_percentage_calculation]
AS
SELECT     Total_Production_, Year_of_WP
FROM         (SELECT     SUM(CAST(Total_Production_ AS int)) AS Total_Production_, Year_of_WP
                       FROM          dbo.VW_RESERVES_UPDATES_OIL_CONDENSATE_MMBBL
                       GROUP BY Year_of_WP) AS d