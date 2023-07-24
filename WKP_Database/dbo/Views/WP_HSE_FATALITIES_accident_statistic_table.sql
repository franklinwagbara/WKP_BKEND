/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[WP_HSE_FATALITIES_accident_statistic_table]
AS
SELECT     CompanyName, Year_of_WP, Fatalities_Type, SUM(CAST(Fatalities_Proposed_year AS int)) AS Fatalities_Proposed_year, SUM(CAST(Fatalities_Current_year AS int)) 
                      AS Fatalities_Current_year, type_of_incidence
FROM         dbo.HSE_FATALITIES
GROUP BY CompanyName, Year_of_WP, type_of_incidence, Fatalities_Type