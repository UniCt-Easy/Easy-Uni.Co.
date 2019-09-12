if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avviso_pagamento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avviso_pagamento]
GO
  
------------------------------------------------------------------
------ NON MANUTENERE PIU'---------------------------------------
------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE   PROCEDURE [rpt_avviso_pagamento]
	@ayear smallint, 
	@npaybegin int, 
	@npayend int
AS BEGIN
IF (@ayear=0)
BEGIN
 SET @ayear='1900'
END
CREATE TABLE #avviso
(
	ymov int,		
	nmov int,
	ypay int,
	npay int,
	idexp varchar(40),
	idexpprinc varchar(40),
	description varchar(255),
	idreg int,
	idpaymethod varchar(20),
	regmodcode varchar(50),
	paymethod varchar(50),
	methodbankcode varchar(20),
	cin varchar(20),
	idbank varchar(20),
	bank varchar(150),
	idcab varchar(20),
	cab varchar(50),
	cc varchar(30),
	iddeputy int,
	deputy varchar(200),
	paymentdescr varchar(350),
	amount decimal(19,2),
	tiporiga int,
	taxcode varchar(20),
	paymentprogr int,
	footerpaymentadvice varchar(400)  
)
CREATE TABLE #indirizzo
(
	idaddresskind varchar(6),
	idreg int,
	officename varchar(50),
	address varchar(100),
	location varchar(120),
	cap varchar(20),
	province varchar(2),
	geo_nation varchar(65)	 
)
DECLARE @addressdate datetime
SET @addressdate= convert(datetime, '31-12-'+ convert(varchar(4),@ayear), 105)
DECLARE @NOSTAND varchar(6)
SET @NOSTAND = 'AVPAG'
DECLARE @STAND varchar(6)
SET @STAND 	= 'STAND'
DECLARE @phasecassa char(1)
SELECT @phasecassa = MAX(nphase) FROM expensephase
DECLARE @paymentdescr char(50)
SELECT @paymentdescr = description
FROM expensephase
WHERE nphase = @phasecassa
DECLARE @idreg int
SELECT @idreg = idreg 
FROM registry
WHERE residence = 'R'
	
DECLARE @flagtax char(1)
DECLARE @flagadmintax char(1)
DECLARE @flagclawback char(1)
DECLARE @admintaxkind char(1)
DECLARE @employtaxkind char(1)
SELECT 
	@flagtax = flagtax,
	@flagadmintax = flagadmintax,
	@flagclawback = flagclawback,
	@employtaxkind = employtaxkind,
	@admintaxkind = admintaxkind
FROM expensesetup
WHERE ayear = @ayear
	
INSERT INTO #avviso
(
	ymov,
	nmov,
	ypay,
	npay,
	idexpprinc,
	idreg,
	idpaymethod,
	amount,
	tiporiga,
	paymentprogr 
)
SELECT
	expense.ymov,
	expense.nmov,
	expense.ypay,
	expense.npay,
	expense.idexp,
	expense.idreg,
	expense.idpaymethod,
	expensetotal.curramount,
	0,
	expense.idpay
FROM expense
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
WHERE expense.ypay = @ayear
	AND expensetotal.ayear = @ayear
	AND expense.npay BETWEEN @npaybegin AND @npayend
	AND expense.idpaymethod in (select idpaymethod from paymethod where flagpaymentadvice = 'S')
IF @flagtax = 'S' and @employtaxkind <> '2'
	BEGIN
		INSERT INTO #avviso
		(
			ymov,
			nmov,
			ypay,
			npay,
			idexp,
			tiporiga,
			idreg,
			regmodcode,
			description,
			amount,
			taxcode
		)
		SELECT
			expense.ymov,
			expense.nmov,
			expense.ypay,
			expense.npay,
			expense.idexp,
			1,
			expense.idreg,
			expense.regmodcode,
			tax.description + ' su ' + expense.description + ' (a carico percipiente)',
			- SUM(expensetax.employtax),
			expensetax.taxcode
			from expense
			JOIN expensetax
				on expensetax.idexp = expense.idexp
			JOIN tax
				on tax.taxcode = expensetax.taxcode
		WHERE expense.idexp in (select idexpprinc from #avviso ) 
		GROUP BY expense.ymov, expense.nmov, expense.ypay, expense.npay, expense.idexp,
			expense.idreg,
			expense.regmodcode,
			tax.description, expense.description,
			 expensetax.taxcode
		HAVING SUM(expensetax.employtax) > 0
	END
	
IF @flagadmintax = 'S'
	BEGIN
		INSERT INTO #avviso
		(
			ymov,
			nmov,
			ypay,
			npay,
			idexp,
			tiporiga,
			idreg,
			regmodcode,
			description,
			amount,
			taxcode
		)
		SELECT
			expense.ymov,
			expense.nmov,
			expense.ypay,
			expense.npay,
			expense.idexp,
			1,
			expense.idreg,
			expense.regmodcode,
			tax.description + ' su ' + expense.description  + ' (a carico amministrazione)',
			- SUM(expensetax.employtax),
			expensetax.taxcode
		FROM expense
		JOIN expensetax
			ON expensetax.idexp = expense.idexp
		JOIN tax
			ON tax.taxcode = expensetax.taxcode
		WHERE (expensetax.admintax > 0)
			and expense.idexp in (select idexpprinc from #avviso ) 
		GROUP BY expense.ymov, expense.nmov, expense.ypay, expense.npay, expense.idexp,
			expense.idreg,  expense.regmodcode,
			tax.description, expense.description,
			expensetax.taxcode
		HAVING SUM(expensetax.admintax) > 0
	END
	
	if @flagclawback = 'S'
	BEGIN
		INSERT INTO #avviso
		(
			ymov,
			nmov,
			ypay,
			npay,
			idexp,
			tiporiga,
			idreg,
			regmodcode,
			description,
			amount,
			taxcode
		)
		SELECT
			expense.ymov,
			expense.nmov,
			expense.ypay,
			expense.npay,
			expense.idexp,
			1,
			expense.idreg,
			expense.regmodcode,
			clawback.description + ' su ' + expense.description,
			- (expenseclawback.amount),
			expenseclawback.idclawback
		FROM expense
		JOIN expenseclawback
			ON expenseclawback.idexp = expense.idexp
		JOIN clawback
			ON clawback.idclawback = expenseclawback.idclawback
		WHERE expense.idexp in (select idexpprinc from #avviso ) 
			AND expenseclawback.amount > 0
	END
	
	IF (@employtaxkind = '2')
	BEGIN
		  INSERT INTO #avviso
			  (
			  ymov,
			  nmov,
			  ypay,
			  npay,
			  idexp,
			  tiporiga,
			  idreg,
			  regmodcode,
			  description,
			  amount
			  )
		  SELECT DISTINCT 
			expense.ymov,
			expense.nmov,
			expense.ypay,
			expense.npay,
			expense.idexp,
			1,
			expense.idreg,
			expense.regmodcode,
			tax.description + ' su ' + expense.description  + ' (a carico percipiente)',
			SUM(expensetax.employtax)
		FROM expense
		JOIN registry
			ON registry.idreg = expense.idreg
		JOIN expensetax
			ON expensetax.idexp = expense.idexp
		JOIN tax
			ON tax.taxcode = expensetax.taxcode
		WHERE expense.idexp in (select idexpprinc from #avviso ) 
		GROUP BY expense.ymov, expense.nmov, expense.ypay, expense.npay,
			expense.idexp, expense.idreg,  expense.regmodcode,
			tax.description, expense.description
		HAVING SUM(expensetax.employtax) > 0
	END
UPDATE  #avviso
SET description =
CASE
	WHEN (income.nmov is not null AND income.npro is not null )
		THEN
			#avviso.description + ' - inc. n. ' 
			+ convert(varchar(6),income.nmov) + ' - rev. n. ' 
			+ convert(varchar(6),income.npro)
		ELSE #avviso.description
END
FROM #avviso
JOIN income
ON income.idpayment = #avviso.idexp
	AND income.autokind = 'RITEN'
	AND (income.idreg <> @idreg or @idreg is null)
	AND income.nphase = (SELECT MAX(nphase) FROM incomephase)
	AND abs(income.amount) = abs(#avviso.amount)
UPDATE #avviso
SET description =
	CASE WHEN (income.nmov is not null and income.npro is not null )
		THEN
			#avviso.description + ' - inc. n. ' 
			+ convert(varchar(6),income.nmov) + ' - rev. n. ' 
			+ convert(varchar(6),income.npro)
		ELSE #avviso.description
	END
FROM #avviso
JOIN income
	ON income.idpayment = #avviso.idexp
	AND income.autokind = 'RECUP'
	AND income.nphase = (select max(nphase) from incomephase)
	AND abs(income.amount) = abs(#avviso.amount)
INSERT INTO #indirizzo
SELECT
	idaddresskind,
	idreg, 
	officename, 
	address,
	location = isnull(geo_city.title,'')+' '+isnull(registryaddress.location,''),
	cap = registryaddress.cap,
	province = geo_country.province,
	geo_nation 	=
	case 
		when flagforeign = 'N' then 'Italia'
		else geo_nation.title
	end
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE  registryaddress.active <>'N' 
	AND registryaddress.start = (
		SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind 
		AND cdi.active <>'N' 
		AND cdi.start <= @addressdate
		and cdi.idreg = registryaddress.idreg
	)
	and (idreg in (select idreg from #avviso))
DELETE #indirizzo
	WHERE #indirizzo.idaddresskind <> @nostand
	AND EXISTS (
		SELECT * FROM #indirizzo r2 
		WHERE #indirizzo.idreg=r2.idreg
		and r2.idaddresskind = @nostand
	)
DELETE #indirizzo
	WHERE #indirizzo.idaddresskind not in (@nostand, @stand)
	AND EXISTS (
		SELECT * FROM #indirizzo r2 
		WHERE #indirizzo.idreg=r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE #indirizzo
	WHERE (
		select count(*) from #indirizzo r2 
		WHERE #indirizzo.idreg=r2.idreg
	)>1
SELECT
	#avviso.ymov, 
	#avviso.nmov, 
	#avviso.ypay, 
	#avviso.npay, 
	S_MAIN.doc ,
	S_MAIN.docdate ,
	CASE 
		WHEN tiporiga = 0 THEN S_MAIN.description
		ELSE #avviso.description
	END AS description,
	#avviso.idreg,
	registry.title as title,
	#indirizzo.address, 
	#indirizzo.location, 
	#indirizzo.cap,
	#indirizzo.province,  
	#indirizzo.geo_nation, 
	CASE 
		WHEN tiporiga = 0 THEN S_MAIN.regmodcode
		ELSE S_DETT.regmodcode
	END	AS regmodcode,
	isnull(paymethod.description, '') as paymethod, 
	CASE
		WHEN paymethod.allowdeputy = 'S' THEN NULL
		ELSE S_MAIN.cin
	END as cin,
	CASE
		WHEN paymethod.allowdeputy = 'S' THEN NULL
		ELSE S_MAIN.idbank
	END as idbank,
	CASE
		WHEN paymethod.allowdeputy = 'S' THEN NULL
		ELSE bancacreditore.description
	END AS bank,
	CASE
		WHEN paymethod.allowdeputy = 'S' THEN NULL
		ELSE S_MAIN.idcab
	END as idcab,
	CASE
		WHEN paymethod.allowdeputy = 'S' THEN NULL
		ELSE sportellocreditore.description
	END as cab,
	CASE
		WHEN paymethod.allowdeputy = 'S' THEN NULL
		ELSE S_MAIN.cc
	END as cc,
	CASE
		WHEN paymethod.allowdeputy = 'S' AND S_MAIN.iddeputy IS NOT NULL
		THEN ISNULL(S_MAIN.paymentdescr,'') + ' ' + ISNULL(deputy.title,'')
		+ ' ' + ISNULL(deputy.cf,'') + ' '
		+ ISNULL(CONVERT(varchar(2),DAY(deputy.birthdate)),'') + '-' + ISNULL(CONVERT(varchar(2),MONTH(deputy.birthdate)),'')
		+ '-' + ISNULL(CONVERT(varchar(4),YEAR(deputy.birthdate)),'')
		ELSE ISNULL(S_MAIN.paymentdescr,'')
	END as paymentdescr,
	#avviso.amount,
	treasurerbank.description as treasurerbank,
	treasurercab.description as treasurercab,
	treasurer.address as treasureraddress,
	treasurer.cap as treasurercap,
	treasurer.city as treasurercity,
	treasurer.country as treasurercountry,
	treasurer.cc as treasurercc,
	treasurer.header,
	payment.printdate as data,
	#avviso.tiporiga,
	@flagtax as flagtax,
	@flagadmintax as flagadmintax,
	@flagclawback as flagclawback,
	(ISNULL(registryreference.phoneprefix,'') + ISNULL(registryreference.phonenumber,'')) as phone,
	(ISNULL(registryreference.faxprefix,'') + ISNULL(registryreference.faxnumber,'')) as fax,
	registryreference.email,
	#avviso.paymentprogr,
	paymethod.footerpaymentadvice
FROM #avviso
LEFT OUTER JOIN expense S_MAIN
	ON S_MAIN.idexp = #avviso.idexpprinc
LEFT OUTER JOIN expense S_DETT
	ON S_DETT.idexp = #avviso.idexp
LEFT OUTER JOIN #indirizzo
	ON #indirizzo.idreg = #avviso.idreg
LEFT OUTER JOIN payment
	ON payment.ypay = #avviso.ypay
	AND payment.npay = #avviso.npay
LEFT OUTER JOIN treasurer
	ON treasurer.idtreasurer = payment.idtreasurer
LEFT OUTER JOIN bank treasurerbank
	ON treasurerbank.idbank = treasurer.idbank
LEFT OUTER JOIN cab treasurercab
	ON treasurercab.idbank = treasurer.idbank
	AND treasurercab.idcab = treasurer.idcab
LEFT OUTER JOIN registry
	ON registry.idreg = #avviso.idreg
LEFT OUTER JOIN paymethod
	ON paymethod.idpaymethod = S_MAIN.idpaymethod
LEFT OUTER JOIN bank bancacreditore
	ON bancacreditore.idbank = S_MAIN.idbank
LEFT OUTER JOIN cab sportellocreditore
	ON sportellocreditore.idbank = S_MAIN.idbank
	AND sportellocreditore.idcab = S_MAIN.idcab
LEFT OUTER JOIN registryreference
	ON registryreference.idreg = #avviso.idreg
	AND registryreference.flagdefault = 'S'
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = S_MAIN.iddeputy
ORDER BY #avviso.npay ASC,#avviso.title ASC,#avviso.regmodcode ASC,isnull(paymethod.description, '') DESC
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

