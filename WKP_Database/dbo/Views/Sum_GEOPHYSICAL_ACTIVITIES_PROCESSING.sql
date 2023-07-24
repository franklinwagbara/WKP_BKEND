
CREATE VIEW [dbo].[Sum_GEOPHYSICAL_ACTIVITIES_PROCESSING]
AS
SELECT     CompanyName, OML_Name, Terrain, Name_of_Contractor, SUM(CAST(Quantum_Approved AS float)) AS Quantum_Approved, 
                      SUM(CAST(Geo_Quantum_of_Data AS float)) AS Quantum_Processed, Year_of_WP, Geo_Type_of_Data_being_Processed
FROM         dbo.GEOPHYSICAL_ACTIVITIES_PROCESSING
GROUP BY Year_of_WP, Geo_Type_of_Data_being_Processed, CompanyName, OML_Name, Terrain, Name_of_Contractor