
CREATE VIEW [dbo].[Sum_GEOPHYSICAL_ACTIVITIES_ACQUISITION]
AS
SELECT     CompanyName, OML_Name, Terrain, Name_of_Contractor, SUM(CAST(Quantum_Approved AS float)) AS Quantum_Approved, SUM(CAST(Quantum AS float)) 
                      AS Quantum, Year_of_WP, Geo_type_of_data_acquired
FROM         dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION
GROUP BY Year_of_WP, Geo_type_of_data_acquired, CompanyName, OML_Name, Terrain, Name_of_Contractor