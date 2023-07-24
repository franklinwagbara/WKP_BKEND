CREATE VIEW [dbo].[WP_RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE_CURRENT_PLANNED]
AS


SELECT     Total_Company_Reserves_Oil, Total_Company_Reserves_Condensate, 
                      Total_Company_Reserves_Oil + Total_Company_Reserves_Condensate AS Total_oil_plus_condensate, Total_Company_Reserves_AG, 
                      Total_Company_Reserves_NAG, Total_Company_Reserves_AG + Total_Company_Reserves_NAG AS Total_AG_NAG,  Fiveyear_Projection_Year
FROM         (SELECT     Fiveyear_Projection_Year, SUM(CONVERT(decimal(18, 3), Fiveyear_Projection_Oil)) AS Total_Company_Reserves_Oil, SUM(CONVERT(decimal(18, 3), 
                                              Fiveyear_Projection_Condensate)) AS Total_Company_Reserves_Condensate, SUM(CONVERT(decimal(18, 3), Fiveyear_Projection_AG)) 
                                              AS Total_Company_Reserves_AG, SUM(CONVERT(decimal(18, 3), Fiveyear_Projection_NAG)) AS Total_Company_Reserves_NAG
                       FROM          dbo.RESERVES_UPDATES_OIL_CONDENSATE_Fiveyear_Projection
                      
                       GROUP BY Fiveyear_Projection_Year) AS A