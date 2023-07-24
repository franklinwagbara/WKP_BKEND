CREATE VIEW [dbo].[WP_GEOPHYSICAL_ACTIVITIES_PROCESSING]
AS

SELECT     Geo_Type_of_Data_being_Processed, Year_of_WP, SUM(CAST(Processed_Actual AS decimal(18,2))) AS Processed_Actual, SUM(CAST(Processed_Proposed AS decimal(18,2))) 
                      AS Processed_Proposed, SUM(CAST(Reprocessed_Actual AS decimal(18,2))) AS Reprocessed_Actual, SUM(CAST(Reprocessed_Proposed AS decimal(18,2))) AS Reprocessed_Proposed, 
                      SUM(CAST(Interpreted_Actual AS decimal(18,2))) AS Interpreted_Actual, SUM(CAST(Interpreted_Proposed AS decimal(18,2))) AS Interpreted_Proposed
FROM         dbo.GEOPHYSICAL_ACTIVITIES_PROCESSING
GROUP BY Geo_Type_of_Data_being_Processed, Year_of_WP