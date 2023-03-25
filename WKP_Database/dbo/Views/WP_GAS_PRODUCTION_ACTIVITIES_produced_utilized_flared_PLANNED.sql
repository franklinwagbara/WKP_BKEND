/****** Script for SelectTopNRows command from SSMS  *****
CONVERT(decimal(18, 2), a.Annual_Total_Production_by_company) 
                    / b.Annual_Total_Production_by_year * 100 AS Percentage_Production*/
CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PLANNED]
AS

SELECT     CompanyName, Year_of_WP, Current_Actual_Year, Utilized, Flared, ISNULL(CONVERT(decimal(18, 2), Flared) / Current_Actual_Year * 100,0) AS Percentage_FLARED
FROM         (SELECT     CompanyName, Year_of_WP, SUM(CAST(proposed_production AS int)) AS Current_Actual_Year, SUM(CAST(proposed_utilization AS int)) AS Utilized, 
                                              SUM(CAST(proposed_flaring AS int)) AS Flared
                       FROM          dbo.GAS_PRODUCTION_ACTIVITIES
                       GROUP BY CompanyName, Year_of_WP) AS SUB