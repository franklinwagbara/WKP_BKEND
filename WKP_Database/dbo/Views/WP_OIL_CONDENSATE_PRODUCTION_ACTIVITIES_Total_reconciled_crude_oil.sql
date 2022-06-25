﻿
CREATE VIEW [dbo].[WP_OIL_CONDENSATE_PRODUCTION_ACTIVITIES_Total_reconciled_crude_oil]
AS
SELECT     Year_of_WP, SUM(CAST(CAST(Total_Reconciled_National_Crude_Oil_Production AS decimal) AS int)) AS Total_Reconciled_National_Crude_Oil_Production
FROM         dbo.OIL_CONDENSATE_PRODUCTION_ACTIVITIES
GROUP BY Year_of_WP
