/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE_chart]
AS
SELECT     TOP (1000) Contract_Type, Year_of_WP, CAST(ROUND(Percentage_Production, 0) AS int) AS Percentage_Production
FROM         dbo.WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_OIL_PRODUCTION_CONTRACT_TYPE