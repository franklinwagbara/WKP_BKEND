CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities_by_ContractType_tobe_pivoted]
AS
SELECT     Contract_Type, SUM(CAST(Production AS int)) AS Annual_Total_Production_by_CONTRACT_TYPE, Year_of_WP
FROM         dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES_monthly_Activities
GROUP BY Contract_Type, Year_of_WP