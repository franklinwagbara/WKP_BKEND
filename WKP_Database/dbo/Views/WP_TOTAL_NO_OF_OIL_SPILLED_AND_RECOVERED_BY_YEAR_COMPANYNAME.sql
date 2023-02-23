
CREATE VIEW [dbo].[WP_TOTAL_NO_OF_OIL_SPILLED_AND_RECOVERED_BY_YEAR_COMPANYNAME]
AS
SELECT     CompanyName, Year_of_WP, SUM(CAST(Total_Quantity_Spilled AS decimal)) AS Total_Quantity_Spilled, SUM(CAST(Total_Quantity_Recovered AS decimal)) 
                      AS Total_Quantity_Recovered
FROM         dbo.HSE_CAUSES_OF_SPILL
GROUP BY CompanyName, Year_of_WP