
CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_contract_type_tobe_pivoted]
AS
SELECT     Contract_Type, SUM(CAST(Current_Actual_Year AS decimal)) AS Annual_Total_Production_by_CONTRACT_TYPE, Year_of_WP
FROM         dbo.GAS_PRODUCTION_ACTIVITIES
GROUP BY Contract_Type, Year_of_WP