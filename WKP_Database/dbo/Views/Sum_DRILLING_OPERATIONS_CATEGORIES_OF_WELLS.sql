
CREATE VIEW [dbo].[Sum_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS]
AS
SELECT DISTINCT 
                      CompanyName, OML_Name, well_name, spud_date, Year_of_WP, Category, well_cost, Number_of_Days_to_Total_Depth, Well_Status_and_Depth, Contract_Type, 
                      Terrain
FROM         dbo.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS