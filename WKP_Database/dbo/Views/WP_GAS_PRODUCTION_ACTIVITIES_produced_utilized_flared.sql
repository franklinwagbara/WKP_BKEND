
/****** Script for SelectTopNRows command from SSMS  *****
CONVERT(decimal(18, 2), a.Annual_Total_Production_by_company) 
                    / b.Annual_Total_Production_by_year * 100 AS Percentage_Production*/
CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared]
AS
SELECT     CompanyName, Year_of_WP, Current_Actual_Year, Utilized, Flared, CONVERT(decimal(18, 2), Flared) / NULLIF(Current_Actual_Year, 0)  * 100 AS Percentage_FLARED
FROM         (SELECT     CompanyName, Year_of_WP, SUM(CAST(Current_Actual_Year AS decimal)) AS Current_Actual_Year, SUM(CAST(Utilized AS decimal)) AS Utilized, 
                                              SUM(CAST(Flared AS decimal)) AS Flared
                       FROM  dbo.GAS_PRODUCTION_ACTIVITIES where ISNUMERIC(Utilized) = 1
                       GROUP BY CompanyName, Year_of_WP) AS SUB