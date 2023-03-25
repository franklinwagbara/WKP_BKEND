CREATE VIEW [dbo].[VW_SEISMIC_DATA_QUANTUM]
AS
SELECT     a.OML_Name, a.CompanyName, a.Companyemail, a.Year, a.Geological_location, b.Geo_type_of_data_acquired, b.Quantum, b.OML_Name AS OML_Name_, 
                      b.Companyemail AS companyemail_, b.Year_of_WP
FROM         dbo.CONCESSION_SITUATION AS a INNER JOIN
                      dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION AS b ON a.OML_Name = b.OML_Name AND a.Companyemail = b.Companyemail AND a.Year = b.Year_of_WP