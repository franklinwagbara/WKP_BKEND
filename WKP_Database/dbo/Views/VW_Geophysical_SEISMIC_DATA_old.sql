CREATE VIEW [dbo].[VW_Geophysical_SEISMIC_DATA_old]
AS
SELECT DISTINCT 
                      a.CompanyName, a.Contract_Type, a.COMPANY_EMAIL, b.Actual_year_aquired_data AS Actual_year_aquired_data_ACQUISITION, 
                      b.proposed_year_data AS proposed_year_data_ACQUISITION, b.CompanyName AS companyname_ACQUISITION, b.Companyemail AS companyemail_ACQUISITION, 
                      b.Year_of_WP AS Year_ACQUISITION, c.Actual_year_aquired_data AS Actual_year_aquired_data_PROCESSING, 
                      c.proposed_year_data AS proposed_year_data_PROCESSING, c.CompanyName AS companyname_PROCESSING, c.Companyemail AS companyemail_PROCESSING, 
                      c.Year_of_WP AS Year_PROCESSING
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION AS a INNER JOIN
                      dbo.GEOPHYSICAL_ACTIVITIES_ACQUISITION AS b ON a.COMPANY_EMAIL = b.Companyemail INNER JOIN
                      dbo.GEOPHYSICAL_ACTIVITIES_PROCESSING AS c ON a.COMPANY_EMAIL = c.Companyemail