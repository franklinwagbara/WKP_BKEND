


/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES]
AS
--WITH params AS (select Sum(CAST(Utilized AS decimal)) AS util  from dbo.GAS_PRODUCTION_ACTIVITIES where ISNUMERIC(Utilized) = 1)
SELECT     Year_of_WP, SUM(CAST(Current_Actual_Year AS decimal)) AS Actual_Total_Gas_Produced, SUM(CAST(Flared AS decimal))
                       AS Flared_Gas_Produced, (select Sum(CAST(Utilized AS decimal)) AS util  from dbo.GAS_PRODUCTION_ACTIVITIES where ISNUMERIC(Utilized) = 1) AS Utilized_Gas_Produced
FROM         dbo.GAS_PRODUCTION_ACTIVITIES
GROUP BY Year_of_WP