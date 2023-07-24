CREATE VIEW [dbo].[VW_company_and_contract_type]
AS
SELECT DISTINCT CompanyName, Contract_Type
FROM         dbo.ADMIN_CONCESSIONS_INFORMATION