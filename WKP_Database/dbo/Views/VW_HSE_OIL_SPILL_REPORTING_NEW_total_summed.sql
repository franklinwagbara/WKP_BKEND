/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[VW_HSE_OIL_SPILL_REPORTING_NEW_total_summed]
AS
SELECT     Year_of_WP, SUM(Volume_of_spill_bbls) AS Volume_of_spill_bbls, SUM(Volume_recovered_bbls) AS Volume_recovered_bbls
FROM         dbo.VW_HSE_OIL_SPILL_REPORTING_NEW_total
GROUP BY Year_of_WP