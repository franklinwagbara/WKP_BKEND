
CREATE VIEW [dbo].[WP_GEOPHYSICAL_ACTIVITIES_ACQUISITION_count_contract_type]
AS
SELECT     COUNT(Contract_Type) AS Count_Contract_Type, Contract_Type, Year_of_WP, Geo_type_of_data_acquired
FROM         dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION
GROUP BY Contract_Type, Year_of_WP, Geo_type_of_data_acquired