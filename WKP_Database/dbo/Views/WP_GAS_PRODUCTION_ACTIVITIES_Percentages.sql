/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_Percentages]
AS
SELECT     Year_of_WP, Actual_Total_Gas_Produced, Utilized_Gas_Produced, Flared_Gas_Produced, CONVERT(decimal(18, 3), Utilized_Gas_Produced) / CONVERT(decimal(18, 
                      3), Actual_Total_Gas_Produced) * 100 AS Percentage_Utilized
FROM         dbo.WP_GAS_PRODUCTION_ACTIVITIES AS a