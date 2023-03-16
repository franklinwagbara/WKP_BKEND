/*,Cause ---ORDER BY Year_of_WP*/
CREATE VIEW [dbo].[WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill_total]
AS
SELECT     SUM(CAST(Frequency AS int)) AS sum_accident, Year_of_WP, Consequence
FROM         dbo.HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW
WHERE     (Consequence = 'SPILL') AND (Cause IN ('EQUIPMENT FAILURE', 'HUMAN ERROR', 'MYSTERY SPILLS', 'SABOTAGE'))
GROUP BY Year_of_WP, Consequence