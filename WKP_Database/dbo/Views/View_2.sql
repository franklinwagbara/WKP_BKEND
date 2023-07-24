CREATE VIEW [dbo].[View_2]
AS
SELECT     name, SUM(age) AS age
FROM         dbo.Table_1
GROUP BY name