
CREATE VIEW [dbo].[WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type]
AS
SELECT     Geo_type_of_data_acquired, SUM(CAST(Actual_year_aquired_data AS decimal)) AS Actual_year_aquired_data, SUM(CAST(proposed_year_data AS decimal)) 
                      AS proposed_year_data, Year_of_WP, Contract_Type
FROM         dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION
GROUP BY Geo_type_of_data_acquired, Year_of_WP, Contract_Type