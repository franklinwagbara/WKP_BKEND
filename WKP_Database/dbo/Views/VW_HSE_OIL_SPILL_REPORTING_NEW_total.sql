CREATE VIEW [dbo].[VW_HSE_OIL_SPILL_REPORTING_NEW_total]
AS
SELECT     Contract_Type, Year_of_WP, SUM(CAST(Volume_of_spill_bbls AS int)) AS Volume_of_spill_bbls, SUM(CAST(Volume_recovered_bbls AS int)) 
                      AS Volume_recovered_bbls
FROM         dbo.VW_HSE_OIL_SPILL_REPORTING_NEW
GROUP BY Contract_Type, Year_of_WP