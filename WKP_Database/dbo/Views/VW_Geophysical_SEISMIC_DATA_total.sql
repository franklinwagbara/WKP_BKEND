CREATE VIEW [dbo].[VW_Geophysical_SEISMIC_DATA_total]
AS
SELECT     Contract_Type, SUM(CAST(Actual_year_aquired_data_ACQUISITION AS int)) AS Actual_year_aquired_data_ACQUISITION, 
                      SUM(CAST(proposed_year_data_ACQUISITION AS int)) AS proposed_year_data_ACQUISITION, SUM(CAST(Actual_year_aquired_data_PROCESSING AS int)) 
                      AS Actual_year_aquired_data_PROCESSING, SUM(CAST(proposed_year_data_PROCESSING AS int)) AS proposed_year_data_PROCESSING, Year_ACQUISITION
FROM         dbo.VW_Geophysical_SEISMIC_DATA
GROUP BY Contract_Type, Year_ACQUISITION