CREATE VIEW [dbo].[WP_Total_E_and_P_companies_old]
AS
SELECT     COUNT(Year) AS E_and_P_companies, Year
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION
GROUP BY Year