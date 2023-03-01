/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[WP_OML_COMPLIANCE_INDEX_CALCULATIONS]
AS
SELECT     CompanyName, Consession_Type, Year_of_WP, SUM(Divisional_Sum) AS Total_Sum_All_Division
FROM         (SELECT     Id, CompanyName, Consession_Type, Year_of_WP, Divisions, Penalty_Factor_for_Warning, Number_of_Occurrence_of_Warnings, 
                                              Penalty_Factor_for_Sanction, Number_of_Occurrence_of_Sanctions, Penalty_Factor_for_Waivers, Number_of_Occurrence_of_Waivers, 
                                              Compliance_index_for_each_division, POWER(1 - CONVERT(decimal(18, 3), Penalty_Factor_for_Warning) / 100, Number_of_Occurrence_of_Warnings) 
                                              AS Penalty_Factor_for_Warning_Calculation, POWER(1 - CONVERT(decimal(18, 3), Penalty_Factor_for_Sanction) / 100, 
                                              Number_of_Occurrence_of_Sanctions) AS Penalty_Factor_for_Sanction_Calculation, POWER(1 - CONVERT(decimal(18, 3), Penalty_Factor_for_Waivers) 
                                              / 100, Number_of_Occurrence_of_Waivers) AS Penalty_Factor_for_Waivers_Calculation, POWER(1 - CONVERT(decimal(18, 3), Penalty_Factor_for_Warning)
                                               / 100, Number_of_Occurrence_of_Warnings) + POWER(1 - CONVERT(decimal(18, 3), Penalty_Factor_for_Sanction) / 100, 
                                              Number_of_Occurrence_of_Sanctions) + POWER(1 - CONVERT(decimal(18, 3), Penalty_Factor_for_Waivers) / 100, Number_of_Occurrence_of_Waivers) 
                                              AS Divisional_Sum, Created_by, Updated_by, Date_Created, Date_Updated
                       FROM          dbo.ADMIN_COMPLIANCE_INDEX_TABLE
                       WHERE      (Consession_Type = 'OML')) AS a
GROUP BY CompanyName, Consession_Type, Year_of_WP