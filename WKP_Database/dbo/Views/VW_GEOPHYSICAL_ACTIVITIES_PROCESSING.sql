CREATE VIEW [dbo].[VW_GEOPHYSICAL_ACTIVITIES_PROCESSING]
AS
SELECT     a.OML_Name, a.CompanyName, a.Companyemail, a.Year, a.Geological_location, b.Geo_Type_of_Data_being_Processed, b.Geo_Quantum_of_Data, 
                      b.Geo_Completion_Status, b.OML_Name AS OML_Name_, b.Companyemail AS companyemail_, b.Year_of_WP
FROM         dbo.CONCESSION_SITUATION AS a INNER JOIN
                      dbo.GEOPHYSICAL_ACTIVITIES_PROCESSING AS b ON a.OML_Name = b.OML_Name AND a.Companyemail = b.Companyemail AND a.Year = b.Year_of_WP