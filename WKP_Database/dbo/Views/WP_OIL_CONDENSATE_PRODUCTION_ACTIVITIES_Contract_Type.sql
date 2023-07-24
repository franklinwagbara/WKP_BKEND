
CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Contract_Type]
AS
SELECT     Year_of_WP, SUM(CAST(Total_Reconciled_National_Crude_Oil_Production AS decimal)) AS Total_Reconciled_National_Crude_Oil_Production, Contract_Type
FROM         dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES
GROUP BY Year_of_WP, Contract_Type