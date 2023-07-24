CREATE VIEW [dbo].[VW_Geophysical_SEISMIC_DATA_total_summed]
AS
SELECT     Year_ACQUISITION, SUM(Actual_year_aquired_data_ACQUISITION) AS Actual_year_aquired_data_ACQUISITION, SUM(proposed_year_data_ACQUISITION) 
                      AS proposed_year_data_ACQUISITION, SUM(Actual_year_aquired_data_PROCESSING) AS Actual_year_aquired_data_PROCESSING, 
                      SUM(proposed_year_data_PROCESSING) AS proposed_year_data_PROCESSING
FROM         dbo.VW_Geophysical_SEISMIC_DATA_total
GROUP BY Year_ACQUISITION