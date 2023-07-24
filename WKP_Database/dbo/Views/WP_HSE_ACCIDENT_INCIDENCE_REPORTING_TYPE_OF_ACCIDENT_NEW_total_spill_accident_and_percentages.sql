
CREATE VIEW [dbo].[WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_total_spill_accident_and_percentages]
AS
SELECT     a.sum_accident AS [sum_accident_from total], a.Year_of_WP, a.Consequence, b.sum_accident, CONVERT(decimal(18, 3), b.sum_accident) / CONVERT(decimal(18, 3), 
                      NULLIF(a.sum_accident, 0)) * 100 AS Percentage_Spill, b.Year_of_WP AS Year_of_WP_from_total, b.Consequence AS Expr1, b.Cause
FROM         dbo.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill_total AS a INNER JOIN
                      dbo.WP_HSE_ACCIDENT_INCIDENCE_REPORTING_TYPE_OF_ACCIDENT_NEW_consequence_is_spill AS b ON a.Year_of_WP = b.Year_of_WP