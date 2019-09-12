
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_verify_remunerationstrangers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_verify_remunerationstrangers]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [exp_verify_remunerationstrangers]

	@ayear int

AS BEGIN

DECLARE @regphase int
DECLARE @expensephase int
DECLARE @maxexpensephase int
DECLARE @namemaxexpphase varchar(20)
DECLARE @department varchar(200)

SELECT @regphase = expenseregphase from uniconfig  -- fase del creditore
SELECT @expensephase= expensephase FROM config where ayear = @ayear
SELECT @maxexpensephase = MAX(nphase) FROM expensephase
SELECT @namemaxexpphase = description FROM expensephase WHERE nphase = @maxexpensephase
SELECT @department = department from license


SELECT 
	@department AS 'department', 
	E.ymov AS 'ymov', 
	E.nmov AS 'nmov', 
	E.description AS 'descriptionmov',
	@namemaxexpphase AS 'namemaxexpphase',
	R.title AS 'title', 
	R.idreg AS  'idreg',
	ISNULL(S.description,'') AS descr_service,
	CASE WHEN (ISNULL(EL.idser,0)) > 0 THEN 'Pagamento con Tipo Prestazione Selezionata ma senza la Contabilizzazione di un Compenso'
		 WHEN (ISNULL(ET.idexp,0)) > 0 AND (ISNULL(EL.idser,0)) = 0 THEN 'Pagamento con Ritenute senza un Tipo Prestazione Selezionata e senza la Contabilizzazione di un Compenso'
		 WHEN (ISNULL(ET.idexp,0)) = 0 AND (ISNULL(EL.idser,0)) = 0 THEN 'Pagamento senza Ritenute senza un Tipo Prestazione Selezionata e senza la Contabilizzazione di un Compenso'
	END AS 'motive'
FROM expenselast EL
	JOIN expense E						ON EL.idexp = E.idexp
	JOIN expenselink ELK				ON ELK.idchild = E.idexp	AND ELK.nlevel = @expensephase
	LEFT OUTER JOIN expensetax ET		ON E.idexp = ET.idexp
	LEFT OUTER JOIN service S			ON S.idser = EL.idser
	JOIN registry R						ON E.idreg = R.idreg
	JOIN registryaddress RA				ON R.idreg = RA.idreg
	JOIN address AD						ON AD.idaddress = RA.idaddresskind
WHERE R.idregistryclass = 22	AND RA.idcity IS NULL	AND RA.stop IS NULL	AND AD.codeaddress = '07_SW_DEF'
		AND E.ymov = @ayear	AND E.nphase = @maxexpensephase
		AND ELK.idparent NOT IN (SELECT idexp from expensecasualcontract)	-- verifica che non vi siano compensi contabilizzati
		AND	ELK.idparent NOT IN (SELECT idexp from expenseitineration) 
		AND	ELK.idparent NOT IN (SELECT idexp from expensepayroll) 
		AND	ELK.idparent NOT IN (SELECT idexp from expenseprofservice)


END



GO