
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_avviso_pagamento_elenco]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_avviso_pagamento_elenco]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--	exec rpt_avviso_pagamento_elenco 2013,2,null, 7
CREATE  PROCEDURE [rpt_avviso_pagamento_elenco]
	@ayear smallint,
	@npaymenttransmission int,
	@idregpayment int,
	@idtreasurer int
	
AS BEGIN
/* Versione 1.0.1 del 13/03/2008 ultima modifica: SARA */
CREATE  TABLE #advice
(
	rowtype int,
	idbank varchar(20),
	bank varchar(150),
	idcab varchar(20),
	cab varchar(50),
	description varchar(255),
	iddeputy int,
	deputy varchar(200),
	ypay int,
	npay int,
	ymov int,
	nmov int,
	taxcode varchar(20),
	idexp int,
	idexpprinc int,
	idreg int,
	amount decimal(19,2),
	idpaymethod varchar(20),
	idregistrypaymethod int, 
	paymethod varchar(50),
	methodbankcode varchar(20),
	agencycodefortransmission varchar(20),
	cin varchar(20),
	cc varchar(30),
	paymentdescr varchar(350) ,
	paymentprogr int,
	kpay int,idpaydisposition int,iddetail int,
	titlecfpiva varchar(131)
)

IF (@ayear = 0)
BEGIN
	SET @ayear='1900'
END

DECLARE @idreg int
declare @flag_paymentamount int
declare @automanagekind int

SELECT @flag_paymentamount = flag_paymentamount,
	@automanagekind = automanagekind,
	@idreg = idregauto
FROM config
WHERE ayear = @ayear

DECLARE @paymentdescr varchar(50)
SELECT 	@paymentdescr = (SELECT description FROM expensephase 
			WHERE nphase = (SELECT MAX(nphase) FROM expensephase))
SELECT  @paymentdescr = LTRIM(RTRIM(@paymentdescr))
					
DECLARE @proceedsdescr varchar(50)
SELECT 	@proceedsdescr = description
	FROM incomephase
	WHERE nphase = (SELECT MAX(nphase) FROM incomephase)
SELECT 	@proceedsdescr = LTRIM(RTRIM(@proceedsdescr))


INSERT INTO #advice
(
	rowtype,
	ypay, npay, ymov, nmov,		
	idexpprinc, idreg,
	idpaymethod, amount, paymentprogr,
	kpay,idpaydisposition,iddetail 
)
SELECT
	0,
	expense.ymov, payment.npay, 
	expense.ymov, expense.nmov,
	expense.idexp,expense.idreg,
	expenselast.idpaymethod,expensetotal.curramount, 
	--expenselast.idpay
	expenselast.idpay,		
	payment.kpay,paydisposition.idpaydisposition,null
FROM expense
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN expensetotal
	ON expensetotal.idexp = expense.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN paymethod
	on expenselast.idpaymethod = paymethod.idpaymethod
LEFT OUTER JOIN paydisposition
	ON paydisposition.kpay = payment.kpay
WHERE expense.ymov = @ayear
	AND expensetotal.ayear = @ayear
	AND (	paymenttransmission.npaymenttransmission = @npaymenttransmission
		AND ( payment.idreg = @idregpayment OR @idregpayment IS NULL )
	    )
	AND (paymethod.flag&1)<>0
	AND  paydisposition.idpaydisposition IS NULL
	AND payment.idtreasurer = @idtreasurer
	
INSERT INTO #advice
(
	rowtype,
	ypay, npay, ymov, nmov,		
	idexpprinc, idreg,
	idpaymethod, amount, paymentprogr,
	kpay,idpaydisposition,iddetail 
)
SELECT
	0,
	payment.ypay, payment.npay, 
	null, null,
	null,null,
	expenselast.idpaymethod,
	paydispositiondetail.amount,
	paydispositiondetail.iddetail,		
	payment.kpay,paydisposition.idpaydisposition,paydispositiondetail.iddetail
FROM expenselast
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN paymethod
	on expenselast.idpaymethod = paymethod.idpaymethod
JOIN paydisposition
	ON paydisposition.kpay = payment.kpay
JOIN paydispositiondetail
	ON paydisposition.idpaydisposition = paydispositiondetail.idpaydisposition
WHERE payment.ypay = @ayear
	AND (	paymenttransmission.npaymenttransmission = @npaymenttransmission
		AND ( payment.idreg = @idregpayment OR @idregpayment IS NULL )
	    )
	AND (paymethod.flag&1)<>0
	AND payment.idtreasurer = @idtreasurer
GROUP BY expenselast.idpaymethod,payment.ypay, payment.npay, paydispositiondetail.amount,
	paydispositiondetail.iddetail,		
	payment.kpay,paydisposition.idpaydisposition,paydispositiondetail.iddetail
	
IF (@flag_paymentamount & 4) <> 0 AND (@automanagekind & 1024) = 0
BEGIN
	INSERT INTO #advice
	(
		description,
		rowtype,
		ypay, npay, ymov, nmov, idexp,
		idreg,
		idregistrypaymethod,
		amount,
		taxcode
	)
	SELECT
		tax.description + ' su ' + expense.description + ' (a carico percipiente)',
		1,
		expense.ymov, payment.npay, expense.ymov, expense.nmov, expense.idexp,
		expense.idreg,
		expenselast.idregistrypaymethod, 
		- (expensetax.employtax),
		expensetax.taxcode
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN expensetax
		ON expensetax.idexp = expense.idexp
	JOIN tax
		ON tax.taxcode = expensetax.taxcode
	WHERE expensetax.employtax > 0 and 
		expense.idexp in (select idexpprinc from #advice)
END		
	
IF (@flag_paymentamount & 2)<> 0
BEGIN
INSERT INTO #advice
(
	description, rowtype,
	idreg,
	ypay,npay,ymov,nmov,
	idexp,idregistrypaymethod,  
	amount,
	taxcode
)
SELECT
	tax.description + ' su ' + expense.description  + ' (a carico amministrazione)', 1,
	expense.idreg,
	expense.ymov, payment.npay, expense.ymov, expense.nmov,
	expense.idexp, expenselast.idregistrypaymethod, 
	- (expensetax.admintax),
	expensetax.taxcode
FROM expense
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment
	ON payment.kpay = expenselast.kpay
JOIN expensetax
	ON expensetax.idexp = expense.idexp
JOIN tax
	ON tax.taxcode = expensetax.taxcode
WHERE expensetax.admintax > 0 and 
	expense.idexp in (select idexpprinc from #advice)
END
	
IF (@flag_paymentamount & 1) <> 0
BEGIN
	INSERT INTO #advice
		(
			description,rowtype, idreg,
			ypay, npay, ymov, nmov, idexp,idregistrypaymethod, --regmodcode,
			amount,
			taxcode
		)
	SELECT
		clawback.description + ' su ' + expense.description,	
		1,expense.idreg,
		expense.ymov,payment.npay, expense.ymov,expense.nmov,expense.idexp, expenselast.idregistrypaymethod, --expense.regmodcode,
		- (expenseclawback.amount),
		expenseclawback.idclawback
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN expenseclawback
		ON expenseclawback.idexp = expense.idexp
	JOIN clawback
		ON clawback.idclawback = expenseclawback.idclawback
	WHERE expenseclawback.amount > 0 AND
		expense.idexp in (select idexpprinc from #advice)
END
			
IF (@automanagekind & 1024) <> 0
BEGIN
	INSERT INTO #advice
	(
		description,
		rowtype,idreg,
		ypay, npay, ymov, nmov,
		idexp,
		idregistrypaymethod, 
		amount
	)
	SELECT DISTINCT
		tax.description + ' su ' + expense.description  + ' (a carico percipiente)',
		1, expense.idreg,
		expense.ymov, payment.npay, expense.ymov, expense.nmov,
		expense.idexp,
		expenselast.idregistrypaymethod,
		expensetax.employtax
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN registry
		ON registry.idreg = expense.idreg
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN expensetax
		ON expensetax.idexp = expense.idexp
	JOIN tax
		ON tax.taxcode = expensetax.taxcode
	WHERE expensetax.employtax > 0 and
		expense.idexp in (select idexpprinc from #advice)
END

INSERT INTO #advice
		(  description,
		   rowtype,  idreg,
		  ypay,  npay,  
		  ymov,  nmov,
		  idexp, idregistrypaymethod, 
		  amount
		)
	SELECT
		CASE
			WHEN incomelast.kpro IS NOT NULL 
			THEN income.description + ' su ' + @paymentdescr + ' n.'+ convert(varchar(6),expense.nmov) 
			+ ' - ' + @proceedsdescr + ' n. ' 
			+ CONVERT(varchar(6),income.nmov) + ' - Reversale n. '
			+ CONVERT(varchar(6),proceeds.npro)
			ELSE income.description + ' su ' + @paymentdescr + ' n.'+ convert(varchar(6),expense.nmov) 
			+ ' - ' + @proceedsdescr + ' n. ' 
			+ CONVERT(varchar(6),income.nmov) 
		END,
		1,
		expense.idreg,payment.ypay, payment.npay,
		expense.ymov, expense.nmov, expense.idexp,
		expenselast.idregistrypaymethod, 
		- (incometotal.curramount)
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN income
		ON income.idpayment = expense.idexp
	JOIN incomelast
		ON income.idinc = incomelast.idinc
	JOIN incometotal
		ON income.idinc = incometotal.idinc and ((incometotal.flag & 2) = 2) 
	JOIN incomeyear
		ON incometotal.idinc = incomeyear.idinc and incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN proceeds
		ON incomelast.kpro = proceeds.kpro
	WHERE expense.ymov = @ayear
		AND expenseyear.ayear = @ayear
		AND income.autokind = 14
		AND income.autocode is null
		AND expense.idexp in (select idexpprinc from #advice ) 


UPDATE #advice
SET description =
	CASE
		WHEN (income.nmov is not null AND proceeds.npro is not null )
			THEN
				#advice.description + ' - inc. n. ' 
				+ CONVERT(varchar(6),income.nmov) + ' - rev. n. ' 
				+ CONVERT(varchar(6),proceeds.npro)
			ELSE #advice.description
	END
	FROM #advice
	JOIN income
		ON income.idpayment = #advice.idexp  
	JOIN incomelast
		ON incomelast.idinc = income.idinc
	join proceeds on proceeds.kpro = incomelast.kpro
	JOIN incometotal incometotal_firstyear
  		ON incometotal_firstyear.idinc = income.idinc
  		AND ((incometotal_firstyear.flag & 2) <> 0 )
 	JOIN incomeyear incomeyear_starting
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE income.autokind = 4--'RITEN'
		AND (income.idreg <> @idreg or @idreg is null)
		AND abs(incomeyear_starting.amount) = abs(#advice.amount)

UPDATE #advice
SET description =
	CASE WHEN (income.nmov is not null and proceeds.npro is not null )
		THEN
			#advice.description + ' - inc. n. ' 
			+ CONVERT(varchar(6),income.nmov) + ' - rev. n. ' 
			+ CONVERT(varchar(6),proceeds.npro)
		ELSE #advice.description
	END
	FROM #advice
	JOIN income
		ON income.idpayment = #advice.idexp
	JOIN incomelast
		ON incomelast.idinc = income.idinc
	join proceeds on proceeds.kpro = incomelast.kpro
	JOIN incometotal incometotal_firstyear
  		ON incometotal_firstyear.idinc = income.idinc
  		AND ((incometotal_firstyear.flag & 2) <> 0 )
 	JOIN incomeyear incomeyear_starting
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE income.autokind = 6--'RECUP'
		AND abs(incomeyear_starting.amount) = abs(#advice.amount)

CREATE TABLE #address
(
	idaddresskind int,
	idreg int,
	officename varchar(50), 
	address	varchar(100),	
	location varchar(116), -- geo_city.title = 65 + registryaddress.location = 50 + spazio = 1 TOT 116
	cap varchar(20),
	province varchar(2),
	geo_nation varchar(65),
	idpaydisposition int,
	iddetail int			
)

DECLARE @dateaddress datetime
SET @dateaddress = CONVERT(datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_AVV'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SET @NOSTAND = isnull((select idaddress FROM address WHERE codeaddress = @codenostand),0)

-- Legge i dati dell'indirizzo dalla tabella registryaddress
INSERT INTO #address
(
	idaddresskind,
	idreg,
	officename,
	address,
	location,
	cap,
	province,
	geo_nation
)
SELECT
	idaddresskind,
	idreg, 
	officename, 
	address,
	ISNULL(geo_city.title,'')+' '+ISNULL(registryaddress.location,''),
	registryaddress.cap,
	geo_country.province,
	CASE
		WHEN flagforeign = 'N' then 'Italia'
		ELSE geo_nation.title
	END
FROM registryaddress
left outer join geo_city
	ON geo_city.idcity = registryaddress.idcity
left outer join geo_country
	ON geo_city.idcountry = geo_country.idcountry
left outer join geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE 	registryaddress.active <>'N' 
	AND registryaddress.start = (
		SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind 
		AND cdi.active <>'N' 
		AND cdi.start <= @dateaddress
		and cdi.idreg = registryaddress.idreg
	)
	AND (idreg in (select idreg from #advice))
	
delete #address
	where #address.idaddresskind <> @nostand
	and exists (
		select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.idaddresskind = @nostand
	)
delete #address
	where #address.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.idaddresskind = @stand
	)
delete #address
	where (
		select count(*) from #address r2 
		where #address.idreg=r2.idreg
	)>1

-- Legge i dati dell'indirizzo dalla tabella paydisposition
INSERT INTO #address
(
	address,
	location,
	cap,
	province,
	geo_nation,
	idpaydisposition,
	iddetail
)
SELECT
	address,
	ISNULL(paydispositiondetail.location,''),
	paydispositiondetail.cap,
	paydispositiondetail.province,
	'Italia',
	paydisposition.idpaydisposition,
	iddetail
FROM paydisposition 
JOIN paydispositiondetail
	ON paydisposition.idpaydisposition = paydispositiondetail.idpaydisposition
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = paydispositiondetail.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = paydispositiondetail.idnation
WHERE  paydisposition.kpay in (select kpay from #advice
			where idpaydisposition is NOT null)

DECLARE @idpaymethodabi  int
DECLARE @idpaymethodnoabi int
DECLARE @paymethodabi varchar(50)
DECLARE @footerpaymentadviceabi varchar(600)
SELECT  @paymethodabi = paymethod.description,
	@footerpaymentadviceabi = paymethod.footerpaymentadvice,
	@idpaymethodabi = paymethod.idpaymethod
FROM paymethod
JOIN config
	ON paymethod.idpaymethod = config.idpaymethodabi
WHERE ayear = @ayear

DECLARE @paymethodnoabi varchar(50)
DECLARE @footerpaymentadvicenoabi varchar(600)
SELECT  @paymethodnoabi = paymethod.description,
	@footerpaymentadvicenoabi = paymethod.footerpaymentadvice,
	@idpaymethodnoabi = paymethod.idpaymethod
FROM paymethod
JOIN config
	ON paymethod.idpaymethod = config.idpaymethodnoabi
WHERE ayear = @ayear

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @paramvalue char (1) 
SELECT @paramvalue = paramvalue FROM reportadditionalparam WHERE paramname = 'OmettiNettoZero' AND reportname='avviso_pagamento_elenco'

UPDATE #advice 
	SET titlecfpiva =  	
			CASE WHEN #advice.idpaydisposition IS NULL 
				THEN registry.title + isnull(registry.cf,'') + isnull(registry.p_iva,'')
				ELSE ISNULL(PD.title, ISNULL(PD.surname,'') + ' ' + ISNULL(PD.forename,'')) + isnull(PD.cf,'') + isnull(PD.p_iva,'')
			END,
	idregistrypaymethod =	
			CASE 
				WHEN ( rowtype = 0 and #advice.idpaydisposition IS NULL ) THEN S_MAIN_LAST.idregistrypaymethod
				WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NOT NULL) THEN @idpaymethodabi
				WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NULL) THEN @idpaymethodnoabi
				ELSE S_DETT_LAST.idregistrypaymethod
			END	
FROM #advice
LEFT OUTER JOIN expenselast S_MAIN_LAST
	ON S_MAIN_LAST.idexp = #advice.idexpprinc
LEFT OUTER JOIN expenselast S_DETT_LAST
	ON S_DETT_LAST.idexp = #advice.idexp
LEFT OUTER JOIN paydispositiondetail PD
	ON PD.idpaydisposition = #advice.idpaydisposition AND PD.iddetail = #advice.iddetail
LEFT OUTER JOIN registry
	ON registry.idreg = #advice.idreg

--Questa tabella nasce per omettere nel report quei mandati con Importo Netto a zero, qualora sia configurato il parametro 'OmettiNettoZero' a S.
-- Gli UPDATE precedenti sono stati fatti perhè il calcolo dell'importo Netto deve rispettare quello del report.
CREATE TABLE #mandatidacancellare
(
	titlecfpiva varchar(150),
	rowtype int,
	idregistrypaymethod int, 
	amount decimal(19,2),
	npay int,
	valuta char(1)
)

IF (upper(@paramvalue) = 'S')
BEGIN
	INSERT INTO #mandatidacancellare(npay, rowtype, titlecfpiva, idregistrypaymethod, amount, valuta)
	SELECT 
	#advice.npay, 
	rowtype, 
	#advice.titlecfpiva,
	#advice.idregistrypaymethod,
	CASE 
		WHEN #advice.idpaydisposition IS NOT NULL  THEN PD.amount
		ELSE #advice.amount
	END AS amount,
	'N'
	FROM #advice
	LEFT OUTER JOIN paydisposition P
		ON P.idpaydisposition = #advice.idpaydisposition
	LEFT OUTER JOIN paydispositiondetail PD
		ON PD.idpaydisposition = #advice.idpaydisposition
		AND PD.iddetail = #advice.iddetail

	INSERT INTO #mandatidacancellare(npay, titlecfpiva, idregistrypaymethod,  valuta)
	SELECT npay, titlecfpiva, idregistrypaymethod,  'S'
	FROM #mandatidacancellare
	WHERE ( rowtype = 0 OR amount < 0 )
	GROUP BY npay, titlecfpiva, idregistrypaymethod
	HAVING SUM(amount) = 0

	DELETE FROM #advice
	WHERE EXISTS (SELECT * FROM #mandatidacancellare M1
					WHERE M1.valuta = 'S' AND
					M1.npay = #advice.npay AND  M1.titlecfpiva = #advice.titlecfpiva AND M1.idregistrypaymethod = #advice.idregistrypaymethod)
END

DELETE FROM #advice where (SELECT SUM(AD.amount) FROM #advice AD
							WHERE #advice.ypay = AD.ypay
							AND #advice.npay = AD.npay
							GROUP BY AD.ypay,AD.npay) = 0   -- Vengono eliminati tutti gli avvisi il cui netto = 0  

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

SELECT
	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN #advice.ymov
		ELSE NULL
	END
	AS ymov, 
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN #advice.nmov
		ELSE NULL
	END
	AS nmov,
	#advice.ypay, 
	#advice.npay,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN S_MAIN.doc
		ELSE NULL
	END
	AS doc, 
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN S_MAIN.docdate
		ELSE NULL
	END
	AS docdate,
	CASE WHEN ( rowtype = 0 and #advice.idpaydisposition IS NULL )	THEN S_MAIN.description
	     WHEN ( #advice.idpaydisposition IS NOT NULL )		THEN P.description
	     ELSE #advice.description
	END AS description,
	#advice.idreg,-- nel report non è usato
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN registry.title
		ELSE ISNULL(PD.title, ISNULL(PD.surname,'') + ' ' + ISNULL(PD.forename,''))
	END
	as title,
	#advice.titlecfpiva,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN #address.address
		ELSE AD.address
	END
	as address,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN #address.location
		ELSE AD.location
	END
	as location,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN #address.cap
		ELSE AD.cap
	END
	as cap,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN #address.province
		ELSE AD.province
	END
	as province,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN #address.geo_nation
		ELSE AD.geo_nation
	END
	as geo_nation,
	-- serve solo ai fini del raggruppamento
	#advice.idregistrypaymethod,
	CASE
		WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NOT NULL) THEN @paymethodabi
		WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NULL) THEN @paymethodnoabi
		ELSE ISNULL(paymethod.description, '') 
	END AS paymethod, 
	CASE
		WHEN (#advice.idpaydisposition IS NOT NULL)THEN NULL  
		ELSE S_MAIN_LAST.cin
	END as cin,
	CASE
		WHEN #advice.idpaydisposition IS NOT NULL 	THEN PD.abi
		ELSE S_MAIN_LAST.idbank
	END as idbank,
	CASE
		WHEN #advice.idpaydisposition IS NOT NULL THEN bancadisposition.description
		ELSE bancacreditore.description
	END AS bank,
	CASE
		WHEN #advice.idpaydisposition IS NOT NULL THEN PD.cab
		ELSE S_MAIN_LAST.idcab
	END as idcab,
	CASE
		WHEN #advice.idpaydisposition IS NOT NULL THEN sportellodisposition.description
		ELSE sportellocreditore.description
	END as cab,
	CASE
		WHEN (#advice.idpaydisposition IS NOT NULL) THEN NULL	
		ELSE S_MAIN_LAST.cc
	END as cc,
	CASE
		WHEN (#advice.idpaydisposition IS NOT NULL) THEN NULL	
		ELSE S_MAIN_LAST.iban
	END as iban,
	CASE
		WHEN (S_MAIN_LAST.iddeputy IS NOT NULL AND S_MAIN_LAST.iban IS NOT NULL)
			THEN ISNULL(S_MAIN_LAST.paymentdescr,'') + ' intestato a ' + ISNULL(deputy.title,'') + ', delegato del Beneficiario' 
		WHEN (S_MAIN_LAST.iddeputy IS NOT NULL AND S_MAIN_LAST.iban IS NULL)
			THEN ISNULL(S_MAIN_LAST.paymentdescr,'') + ' ' + ISNULL(deputy.title,'')
-- in presenza di delegato va mostrato SOLO nome e cognome
			-- + ' ' + ISNULL(deputy.cf,'') + ' '
			-- + ISNULL(CONVERT(varchar(2),DAY(deputy.birthdate)),'') + '-' + ISNULL(CONVERT(varchar(2),MONTH(deputy.birthdate)),'')
			-- + '-' + ISNULL(CONVERT(varchar(4),YEAR(deputy.birthdate)),'')
		WHEN (#advice.idpaydisposition IS NOT NULL)
			THEN isnull(PD.motive,P.motive) -- se la causale del dettaglio è null prende quella del principale
		ELSE ISNULL(S_MAIN_LAST.paymentdescr,'')
	END as paymentdescr,
 	CASE WHEN #advice.idpaydisposition IS NOT NULL 
		THEN PD.amount
		ELSE #advice.amount
	END
	AS amount,
	treasurerbank.description as treasurerbank,
	treasurercab.description as treasurercab,
	treasurer.address as treasureraddress,
	treasurer.cap as treasurercap,
	treasurer.city as treasurercity,
	treasurer.country as treasurercountry,
	treasurer.cc as treasurercc,
	treasurer.agencycodefortransmission,
	treasurer.header,
	payment.printdate as data,
	#advice.rowtype as tiporiga,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN ISNULL(registryreference.phonenumber,'')
		ELSE null
	END
	AS phone,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN ISNULL(registryreference.faxnumber,'')
		ELSE null
	END
	AS fax,
 	CASE WHEN #advice.idpaydisposition IS NULL 
		THEN ISNULL(registryreference.email,'')
		ELSE null
	END
	AS email,
	#advice.paymentprogr,
 	CASE 	WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NOT NULL) THEN @footerpaymentadviceabi
		WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NULL) THEN @footerpaymentadvicenoabi
		ELSE paymethod.footerpaymentadvice   
	END
	AS footerpaymentadvice,
 	CASE 	
		-- è una disposizione e c'è l'IBAN => Bonifico
		WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NOT NULL) THEN 'N'
		-- è una disposizione e NON c'è l'iban => Sportello
		WHEN (#advice.idpaydisposition IS NOT NULL AND PD.iban IS NULL) THEN 'S'
		-- è un mandato normale con modalità sportello
		WHEN ((paymethod.flag & 8 <>0) and (paymethod.flag & 1 <>0) ) THEN 'S'
		ELSE 'N'
	END
	AS suppress_sezionecassiere
FROM #advice
LEFT OUTER JOIN paydisposition P
	ON P.idpaydisposition = #advice.idpaydisposition
LEFT OUTER JOIN paydispositiondetail PD
	ON PD.idpaydisposition = #advice.idpaydisposition
	AND PD.iddetail = #advice.iddetail
LEFT OUTER JOIN expense S_MAIN
	ON S_MAIN.idexp = #advice.idexpprinc
LEFT OUTER JOIN expenselast S_MAIN_LAST
	ON S_MAIN_LAST.idexp = #advice.idexpprinc
LEFT OUTER JOIN expense S_DETT
	ON S_DETT.idexp = #advice.idexp
LEFT OUTER JOIN expenselast S_DETT_LAST
	ON S_DETT_LAST.idexp = #advice.idexp
LEFT OUTER JOIN #address
	ON #address.idreg = #advice.idreg
LEFT OUTER JOIN #address AD
	ON AD.idpaydisposition = #advice.idpaydisposition
	AND AD.iddetail = #advice.iddetail
LEFT OUTER JOIN payment
	ON payment.ypay = #advice.ypay
	AND payment.npay = #advice.npay
LEFT OUTER JOIN treasurer
	ON treasurer.idtreasurer = payment.idtreasurer
LEFT OUTER JOIN bank treasurerbank
	ON treasurerbank.idbank = treasurer.idbank
LEFT OUTER JOIN cab treasurercab
	ON treasurercab.idbank = treasurer.idbank
	AND treasurercab.idcab = treasurer.idcab
LEFT OUTER JOIN registry
	ON registry.idreg = #advice.idreg
LEFT OUTER JOIN paymethod
	ON paymethod.idpaymethod = S_MAIN_LAST.idpaymethod
LEFT OUTER JOIN bank bancacreditore
	ON bancacreditore.idbank = S_MAIN_LAST.idbank
LEFT OUTER JOIN bank bancadisposition
	ON bancadisposition.idbank = PD.abi
LEFT OUTER JOIN cab sportellocreditore
	ON sportellocreditore.idbank = S_MAIN_LAST.idbank
	AND sportellocreditore.idcab = S_MAIN_LAST.idcab
LEFT OUTER JOIN cab sportellodisposition
	ON sportellodisposition.idbank = PD.abi
	AND sportellodisposition.idcab = PD.cab
LEFT OUTER JOIN registryreference
	ON registryreference.idreg = S_MAIN.idreg
	AND registryreference.flagdefault = 'S'
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = S_MAIN_LAST.iddeputy
ORDER BY #advice.npay ASC, 
	#advice.rowtype  ASC,
	registry.title ASC
	--#advice.regmodcode ASC
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

