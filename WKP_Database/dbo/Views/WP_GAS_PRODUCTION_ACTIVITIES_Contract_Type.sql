﻿CREATE VIEW [dbo].[WP_GAS_PRODUCTION_ACTIVITIES_Contract_Type]
AS
SELECT     Year_of_WP, Contract_Type, SUM(CAST(Current_Actual_Year AS int)) AS Actual_Total_Gas_Produced, SUM(CAST(Utilized AS int)) AS Utilized_Gas_Produced, 
                      SUM(CAST(Flared AS int)) AS Flared_Gas_Produced
FROM         dbo.GAS_PRODUCTION_ACTIVITIES
GROUP BY Year_of_WP, Contract_Type
