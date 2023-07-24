CREATE VIEW [dbo].[WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT]
AS
SELECT     Total_Company_Reserves_Oil, Total_Company_Reserves_Condensate, 
                      Total_Company_Reserves_Oil + Total_Company_Reserves_Condensate AS Total_oil_plus_condensate, Total_Company_Reserves_AG, 
                      Total_Company_Reserves_NAG, Total_Company_Reserves_AG + Total_Company_Reserves_NAG AS Total_AG_NAG, FLAG1, Company_Reserves_Year
FROM         (SELECT     Company_Reserves_Year, SUM(CONVERT(decimal(18, 3), Company_Reserves_Oil)) AS Total_Company_Reserves_Oil, SUM(CONVERT(decimal(18, 3), 
                                              Company_Reserves_Condensate)) AS Total_Company_Reserves_Condensate, SUM(CONVERT(decimal(18, 3), Company_Reserves_AG)) 
                                              AS Total_Company_Reserves_AG, SUM(CONVERT(decimal(18, 3), Company_Reserves_NAG)) AS Total_Company_Reserves_NAG, FLAG1
                       FROM          dbo.RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE
                       WHERE      (FLAG1 = 'COMPANY_CURRENT_RESERVE')
                       GROUP BY Company_Reserves_Year, FLAG1) AS A