
CREATE VIEW [dbo].[WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_and_count]
AS
SELECT     dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type.Count_Contract_Type, 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type.Contract_Type, 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type.Year_of_WP, 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type.Geo_type_of_data_acquired, 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type.Actual_year_aquired_data, 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type.proposed_year_data
FROM         dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type INNER JOIN
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type ON 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type.Contract_Type = dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type.Contract_Type
                       AND 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type.Year_of_WP = dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type.Year_of_WP
                       AND 
                      dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type.Geo_type_of_data_acquired = dbo.WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_sum_contract_type.Geo_type_of_data_acquired