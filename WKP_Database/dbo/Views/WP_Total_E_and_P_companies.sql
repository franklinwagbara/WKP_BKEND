CREATE VIEW [dbo].[WP_Total_E_and_P_companies]
AS
SELECT     COUNT(DISTINCT CompanyName) AS E_and_P_companies, Year
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION
GROUP BY Year