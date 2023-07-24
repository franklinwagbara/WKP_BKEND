CREATE VIEW [dbo].[VW_DRILLING_OPERATIONS_CATEGORIES_OF_WELLS_appraisal]
AS
SELECT     TOP (1000) Id, OML_ID, OML_Name, CompanyName, Companyemail, Year_of_WP, Category, Actual_No_Drilled_in_Current_Year, Proposed_No_Drilled, 
                      Processing_Fees_Paid, Comments, No_of_wells_cored, Actual_year, proposed_year, Created_by, Updated_by, Date_Created, Date_Updated
FROM         dbo.DRILLING_OPERATIONS_CATEGORIES_OF_WELLS
WHERE     (Category = 'Appraisal')