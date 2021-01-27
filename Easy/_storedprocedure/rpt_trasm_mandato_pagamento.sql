
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_trasm_mandato_pagamento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_trasm_mandato_pagamento]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [rpt_trasm_mandato_pagamento]
	@ayear int,
	@npaymenttransmission int,
	@idtreasurer int	
AS BEGIN

--	exec rpt_trasm_mandato_pagamento 2013, 2,7

DECLARE @transmissionkind char(1)
SELECT @transmissionkind = transmissionkind FROM paymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @ayear
	AND paymenttransmission.npaymenttransmission = @npaymenttransmission

CREATE TABLE #paymenttransmission
(
	ydoc int,
	ndoc int,
	adate datetime,
	printdate datetime,
	kind char(1),
	ypaymenttransmission int,
	npaymenttransmission int,
	curramount decimal(19,2),
	totvarannulment decimal(19,2),	
	varannulment_at_date decimal(19,2),	
	idreg int,
	title varchar(200),
	idman int,
	idpaymethod varchar(20),
	methoddescription varchar(50),
	bban varchar (50),
	iban  varchar(50),
	paydescription varchar(150),
	description varchar(210),
	amount decimal(19,2),
	idtreasurer int,
	transmissiondate datetime,
	idexp int,
	fulfilled varchar(1)
)

DECLARE @displayalreadysent char(1)
/*
DECLARE @idtreasurer int
SELECT @idtreasurer = idtreasurer FROM paymenttransmission 
	WHERE ypaymenttransmission = @ayear 
	AND npaymenttransmission = @npaymenttransmission 
*/	
SELECT @displayalreadysent = ISNULL(paramvalue ,'N')
FROM reportadditionalparam
WHERE reportname = 'trasm_mandato_pagamento'
AND paramname = 'MostraMovGiaTrasmessi'


	
	DECLARE @displayalreadysent_all	char(1)
	SELECT  @displayalreadysent_all = ISNULL(paramvalue ,'N')
	FROM 	reportadditionalparam
	WHERE 	reportname = 'trasm_mandato_pagamento'
	AND 	paramname  = 'MostraTotaliAltriTesorieri'
	
IF @ayear = 0
BEGIN
	SET @ayear = 1900
END

INSERT INTO #paymenttransmission
(
	ydoc,
	ndoc,
	adate,
	printdate,
	kind,
	ypaymenttransmission,
	npaymenttransmission,
	idreg,
    idman,
	idpaymethod,
	paydescription,
	bban,
	iban,
	description,
	amount,
	idtreasurer,
	transmissiondate,
	idexp,
	fulfilled
)
SELECT DISTINCT
payment.ypay,
payment.npay,
payment.adate,
payment.printdate,
case payment.flag&7 
  when 1 then 'C' 
  when 2 then 'R' 
  when 4 then 'M' 
end,
paymenttransmission.ypaymenttransmission,
paymenttransmission.npaymenttransmission,
expense.idreg,
paymenttransmission.idman,
expenselast.idpaymethod,
CASE 
	WHEN isnull(expenselast.idbank,'')<>''
		THEN isnull(expenselast.cin,'') + ' ' + 
		isnull(expenselast.idbank,'') + ' ' + 
		isnull(expenselast.idcab,'') + ' ' + 
		isnull(expenselast.cc,'')
	ELSE expenselast.paymentdescr
END,
CASE 
	WHEN ( ISNULL(expenselast.idbank,'')<>''AND 
	       ISNULL(expenselast.cin,'')<> ''AND 
	       ISNULL(expenselast.idcab,'')<> ''AND
	       ISNULL(expenselast.cc,'')<> '')
	THEN expenselast.cin  + 
	     expenselast.idbank  + 
	     expenselast.idcab + 
	     expenselast.cc
	ELSE NULL
END as bban,
CASE 
	WHEN ISNULL(expenselast.idbank,'')<>'' AND ISNULL(expenselast.iban,'')<>'' 
	THEN expenselast.iban
	ELSE NULL
END,
CASE ISNULL(expense.doc,'') WHEN '' THEN expense.description 
ELSE expense.description + ' Pagato con Doc. ' + expense.doc
END,
ISNULL(expensetotal.curramount,0.0),
payment.idtreasurer,
paymenttransmission.transmissiondate,
expense.idexp,
CASE
	WHEN ((expenselast.flag)&1) = 0 THEN 'N'
	WHEN ((expenselast.flag)&1) = 1 THEN 'S'
END
FROM expense 
JOIN expenselast 
	ON expenselast.idexp = expense.idexp
JOIN expensetotal  
	ON expensetotal.idexp=expense.idexp 
JOIN payment
	ON expenselast.kpay = payment.kpay
JOIN paymenttransmission
	ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @ayear
	AND expensetotal.ayear=@ayear
	AND paymenttransmission.npaymenttransmission = @npaymenttransmission
	AND (((expenselast.flag&1) = 0) or  @displayalreadysent = 'S' )
	and @transmissionkind = 'I' 
	and paymenttransmission.idtreasurer = @idtreasurer
-- Partendo dalla distinta di tipo 'V', risale al mandato
INSERT INTO #paymenttransmission
(
	ydoc,
	ndoc,
	adate,
	printdate,
	kind,
	ypaymenttransmission,
	npaymenttransmission,
	idreg,
    idman,
	idpaymethod,
	paydescription,
	bban,
	iban,
	description,
	amount,
	idtreasurer,
	transmissiondate,
	idexp,
	fulfilled
)
SELECT DISTINCT
		payment.ypay,
		payment.npay,
		payment.adate,
		payment.printdate,
		case payment.flag&7 
		  when 1 then 'C' 
		  when 2 then 'R' 
		  when 4 then 'M' 
		end,
		paymenttransmission.ypaymenttransmission,
		paymenttransmission.npaymenttransmission,
		expense.idreg,
		paymenttransmission.idman,
		expenselast.idpaymethod,
		CASE 
			WHEN isnull(expenselast.idbank,'')<>''
				THEN isnull(expenselast.cin,'') + ' ' + 
				isnull(expenselast.idbank,'') + ' ' + 
				isnull(expenselast.idcab,'') + ' ' + 
				isnull(expenselast.cc,'')
			ELSE expenselast.paymentdescr
		END,
		CASE 
			WHEN ( ISNULL(expenselast.idbank,'')<>''AND 
				   ISNULL(expenselast.cin,'')<> ''AND 
				   ISNULL(expenselast.idcab,'')<> ''AND
				   ISNULL(expenselast.cc,'')<> '')
			THEN expenselast.cin  + 
				 expenselast.idbank  + 
				 expenselast.idcab + 
				 expenselast.cc
			ELSE NULL
		END as bban,
		CASE 
			WHEN ISNULL(expenselast.idbank,'')<>'' AND ISNULL(expenselast.iban,'')<>'' 
			THEN expenselast.iban
			ELSE NULL
		END,
		CASE ISNULL(expense.doc,'') WHEN '' THEN expense.description 
		ELSE expense.description + ' Pagato con Doc. ' + expense.doc
		END,
		0,	--ISNULL(expensetotal.curramount,0.0),	Per le variazioni non inseriamo l'importo.
		payment.idtreasurer,
		paymenttransmission.transmissiondate,
		expense.idexp,
		CASE
			WHEN ((expenselast.flag)&1) = 0 THEN 'N'
			WHEN ((expenselast.flag)&1) = 1 THEN 'S'
		END
FROM expensevar
JOIN expense 
	ON expensevar.idexp = expense.idexp
JOIN expenselast 
	ON expenselast.idexp = expense.idexp
JOIN expensetotal  
	ON expensetotal.idexp=expense.idexp 
JOIN payment
	ON expenselast.kpay = payment.kpay
JOIN paymenttransmission
	ON expensevar.kpaymenttransmission = paymenttransmission.kpaymenttransmission
WHERE paymenttransmission.ypaymenttransmission = @ayear
	AND expensetotal.ayear=@ayear
	AND paymenttransmission.npaymenttransmission = @npaymenttransmission
	AND (((expenselast.flag&1) = 0) or  @displayalreadysent = 'S' )
	AND @transmissionkind = 'V' 
	and paymenttransmission.idtreasurer = @idtreasurer

UPDATE  #paymenttransmission 
SET		totvarannulment = ISNULL(expensevar.amount, 0.0)
FROM 	expensevar
WHERE 	ISNULL(expensevar.autokind,0) IN (10,11) -- annullamento parziale o totale
AND		expensevar.idexp = #paymenttransmission.idexp	
AND		@transmissionkind = 'I' 

UPDATE  #paymenttransmission 
SET		varannulment_at_date = ISNULL(expensevar.amount, 0.0)
FROM 	expensevar
WHERE 	ISNULL(expensevar.autokind,0) IN (10,11) -- annullamento parziale o totale
AND		expensevar.idexp = #paymenttransmission.idexp	
AND		expensevar.adate <= #paymenttransmission.transmissiondate
AND		@transmissionkind = 'I' 	

	
CREATE TABLE #registryaddress
(
	idreg 			int,
	idaddresskind 		int,
	address 		varchar(100),
	location 		varchar(120),
	cap 			varchar(20),
	province 		varchar(2),
	geo_nation 		varchar(65)
)
	
DECLARE @dateaddress smalldatetime
SELECT 	@dateaddress= convert( smalldatetime, '31-12-'+ convert(varchar(4),@ayear), 105)

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_AVV'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SET @NOSTAND = isnull((select idaddress FROM address WHERE codeaddress = @codenostand),0)

print 	@dateaddress
	
INSERT INTO #registryaddress
(
	idreg,
	idaddresskind,
	address,
	location,
	cap,
	province,
	geo_nation
)
SELECT 
registryaddress.idreg,
registryaddress.idaddresskind,
registryaddress.address,
ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,''),
registryaddress.cap,
geo_country.province,
ISNULL(geo_nation.title,'Italia')
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE ( registryaddress.active <>'N' 
	AND registryaddress.start = 
		(SELECT MAX(cdi.start) 
		FROM registryaddress cdi 
		WHERE cdi.idaddresskind = registryaddress.idaddresskind
		AND cdi.active <>'N' 
		AND cdi.start <= @dateaddress
		AND cdi.stop is null
		AND cdi.idreg = registryaddress.idreg)
	AND registryaddress.idreg in (SELECT idreg FROM #paymenttransmission))

DELETE #registryaddress
	WHERE #registryaddress.idaddresskind <> @nostand
	AND EXISTS(
		SELECT * FROM #registryaddress r2 
		WHERE #registryaddress.idreg = r2.idreg
		AND r2.idaddresskind = @nostand
	)
DELETE #registryaddress
	WHERE #registryaddress.idaddresskind NOT IN (@nostand, @stand)
	AND EXISTS(
		SELECT * FROM #registryaddress r2 
		WHERE #registryaddress.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)

DELETE #registryaddress
	WHERE (
		SELECT COUNT(*) FROM #registryaddress r2 
		WHERE #registryaddress.idreg = r2.idreg
	)>1

DECLARE @transmissiondate datetime
DECLARE @amount decimal(19,2)
DECLARE @totvarannulment decimal(19,2)
DECLARE @varannulment_at_date decimal(19,2)
DECLARE @curramount decimal(19,2)

SELECT  @transmissiondate = ISNULL((SELECT  transmissiondate FROM paymenttransmission
									WHERE paymenttransmission.ypaymenttransmission = @ayear
									AND paymenttransmission.npaymenttransmission = @npaymenttransmission),GetDate())


-- Toltale elenchi precedenti
SELECT 	@amount = ISNULL(SUM(ET_firstyear.curramount), 0.0)
FROM 	expense
JOIN 	expenselast 
ON 	expenselast.idexp = expense.idexp
JOIN expensetotal ET_firstyear
  	ON ET_firstyear.idexp = expense.idexp 
	AND ((ET_firstyear.flag & 2) <> 0 )
JOIN expenseyear EY_starting
	ON EY_starting.idexp = ET_firstyear.idexp
  	AND EY_starting.ayear = ET_firstyear.ayear
JOIN 	payment
	ON payment.kpay = expenselast.kpay
JOIN 	paymenttransmission
	ON payment.kpaymenttransmission= paymenttransmission.kpaymenttransmission
WHERE 	ET_firstyear.ayear = @ayear
	AND paymenttransmission.ypaymenttransmission  = @ayear
	AND paymenttransmission.npaymenttransmission < @npaymenttransmission
	AND 
	(
	(paymenttransmission.idtreasurer=@idtreasurer AND @displayalreadysent_all = 'N')
		OR
	(@displayalreadysent_all = 'S')
	)

-- Totale elenchi precedenti = @amount - @totvarannulment = curramountgross

-- le variazioni di annullamento parziale o totale sono le uniche che si possono fare dopo la trasmissione	
-- in questa formula non considero la data contabile della variazione 
SELECT 	@totvarannulment = ISNULL(SUM(expensevar.amount), 0.0)
FROM 	expense
JOIN 	expenselast 
ON 	expenselast.idexp = expense.idexp
JOIN    expensevar
	ON expensevar.idexp = expense.idexp
JOIN 	payment
	ON payment.kpay = expenselast.kpay
JOIN 	paymenttransmission
	ON payment.kpaymenttransmission= paymenttransmission.kpaymenttransmission
WHERE 	ISNULL(expensevar.autokind,0) IN (10,11) -- annullamento parziale o totale
	AND paymenttransmission.ypaymenttransmission  = @ayear
	AND paymenttransmission.npaymenttransmission < @npaymenttransmission
	AND 
	(
	(paymenttransmission.idtreasurer=@idtreasurer AND @displayalreadysent_all = 'N')
		OR
	(@displayalreadysent_all = 'S')
	)


-- Totale variazioni

-- le variazioni di annullamento parziale o totale sono considerate in base alla loro data
SELECT 	@varannulment_at_date = ISNULL(SUM(expensevar.amount), 0.0)
FROM 	expense
JOIN 	expenselast 
ON 	expenselast.idexp = expense.idexp
JOIN    expensevar
	ON expensevar.idexp = expense.idexp
JOIN 	payment
	ON payment.kpay = expenselast.kpay
JOIN 	paymenttransmission
	ON payment.kpaymenttransmission= paymenttransmission.kpaymenttransmission
WHERE 	ISNULL(expensevar.autokind,0) IN (10,11) -- annullamento parziale o totale
	AND expensevar.adate <= @transmissiondate
	AND paymenttransmission.ypaymenttransmission  = @ayear
	AND paymenttransmission.npaymenttransmission < @npaymenttransmission
	AND 
	(
	(paymenttransmission.idtreasurer=@idtreasurer AND @displayalreadysent_all = 'N')
		OR
	(@displayalreadysent_all = 'S')
	)


-- all'importo corrente dei movimenti finanziari al netto delle variazioni di annullamento 
-- (quindi includendo le altre variazioni) sommo le variazioni di annullamento che rientrano nel range di date
-- allo scopo di preservare la storicità della stampa

/*

print   @amount
PRINT   @totvarannulment
PRINT   @varannulment_at_date
Questo @curramount è calcolato ma MAI usato
SELECT  @curramount = @amount - @totvarannulment +  @varannulment_at_date
print   @curramount
*/
SELECT 
	#paymenttransmission.idexp,
	#paymenttransmission.ydoc,
	#paymenttransmission.ndoc,
	#paymenttransmission.adate,
	#paymenttransmission.printdate,
	#paymenttransmission.kind,
	#paymenttransmission.ypaymenttransmission,
	#paymenttransmission.npaymenttransmission,
	@amount - @totvarannulment 	 'curramountgross',
	@varannulment_at_date  'variation',
	REG.idreg,
	REG.title,
	#paymenttransmission.idman,
	R.title 		 		'manager',
	#registryaddress.address,
	#registryaddress.location,
	#registryaddress.cap,
	#registryaddress.province,
	#registryaddress.geo_nation,
	REG.cf,
	REG.p_iva,
	#paymenttransmission.idpaymethod,
	paymethod.description 			 'methoddescription', 
	#paymenttransmission.paydescription,
	#paymenttransmission.bban,
	#paymenttransmission.iban,		
	#paymenttransmission.description,
	sum(#paymenttransmission.amount) - isnull(sum(totvarannulment),0) + isnull(sum(varannulment_at_date),0) as 'amount',
	ABI.description 			 'treasurerbank',
	cab.description 			 'treasurercab',
	T.address 				 'treasureraddress',
	T.cap 					 'treasurercap',
	T.city 					 'treasurercity',
	T.country 				 'treasurercountry',
	T.cc 					 'treasurercc',
	T.agencycodefortransmission,
	#paymenttransmission.transmissiondate,
	#paymenttransmission.fulfilled,
	T.header			
FROM #paymenttransmission 
LEFT OUTER JOIN registry REG
	ON REG.idreg = #paymenttransmission.idreg
LEFT OUTER JOIN manager R
	ON R.idman = #paymenttransmission.idman 
LEFT OUTER JOIN treasurer T
	ON T.idtreasurer = #paymenttransmission.idtreasurer
LEFT OUTER JOIN bank ABI
	ON ABI.idbank = T.idbank
LEFT OUTER JOIN cab
	ON cab.idbank = T.idbank
	AND cab.idcab = T.idcab
LEFT OUTER JOIN #registryaddress
	ON #registryaddress.idreg = #paymenttransmission.idreg
LEFT OUTER JOIN paymethod
ON paymethod.idpaymethod = #paymenttransmission.idpaymethod
group by idexp,REG.idreg,REG.title,#paymenttransmission.idpaymethod,
methoddescription,
paydescription,ydoc,ndoc,adate,printdate,#paymenttransmission.kind,ypaymenttransmission,npaymenttransmission,
R.title,#paymenttransmission.idman,#registryaddress.address,#registryaddress.location,
#paymenttransmission.iban,#paymenttransmission.bban,
#registryaddress.cap,#registryaddress.province,#registryaddress.geo_nation,
REG.cf,REG.p_iva,#paymenttransmission.description,paymethod.description, ABI.description, cab.description,
T.address,T.cap,T.city,T.country,T.cc,
T.agencycodefortransmission,transmissiondate,fulfilled,curramount,T.header	
ORDER BY ydoc, ndoc
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
