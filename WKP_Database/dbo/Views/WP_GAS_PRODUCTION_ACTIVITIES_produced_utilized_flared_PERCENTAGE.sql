CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_produced_utilized_flared_PERCENTAGE]
AS

SELECT      Year_of_WP, Current_Actual_Year, Utilized, Flared, CONVERT(decimal(18, 2), Flared) / Current_Actual_Year * 100 AS Percentage , 'FLARED' TYPE_
FROM         (SELECT      Year_of_WP, SUM(CAST(Current_Actual_Year AS int)) AS Current_Actual_Year, SUM(CAST(Utilized AS int)) AS Utilized, 
                                              SUM(CAST(Flared AS int)) AS Flared
                       FROM          dbo.GAS_PRODUCTION_ACTIVITIES
                       GROUP BY Year_of_WP) AS SUB
                       
                       union all
                       
                       
SELECT      Year_of_WP, Current_Actual_Year, Utilized, Flared, CONVERT(decimal(18, 2), Utilized) / Current_Actual_Year * 100 AS Percentage , 'UTILIZED' TYPE_
FROM         (SELECT     Year_of_WP, SUM(CAST(Current_Actual_Year AS int)) AS Current_Actual_Year, SUM(CAST(Utilized AS int)) AS Utilized, 
                                              SUM(CAST(Flared AS int)) AS Flared
                       FROM          dbo.GAS_PRODUCTION_ACTIVITIES
                       GROUP BY  Year_of_WP) AS SUB