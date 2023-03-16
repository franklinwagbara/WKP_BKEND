
CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_terrain_tobe_pivotted]
AS
SELECT     Terrain, SUM(CAST(Current_Actual_Year AS decimal)) AS Annual_Total_Production_by_Terrain, Year_of_WP
FROM         dbo.GAS_PRODUCTION_ACTIVITIES
GROUP BY Terrain, Year_of_WP