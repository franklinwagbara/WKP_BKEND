CREATE VIEW [dbo].[WP_COUNT_PRESENTATION_CATERGORY_BY_YEAR_old]
AS
SELECT     TOP (100) PERCENT COUNT(Status_) AS count, Year, Status_
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION
WHERE     (Status_ IN ('presented', 'Failed to show up', 'Update Required', 'Showed up but could not present', 'Not invited'))
GROUP BY Year, Status_
ORDER BY Year