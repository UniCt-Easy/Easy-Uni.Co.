
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_mandato_pagamento_siope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_mandato_pagamento_siope]
GO
--	exec rpt_mandato_pagamento_siope 2029,'I', 2, 2,  N'03/04/2019 00:00:00','N','N',4
----exec rpt_mandato_pagamento_siope 2019,'I', 2, 2,  N'03/04/2019 00:00:00','N','N',4
--setuser 'amministrazione'
CREATE     PROCEDURE [rpt_mandato_pagamento_siope]
	@ayear int,
	@printkind char(1),
	@startnpay int,
	@stopnpay int,
	@printdate datetime,
	@official char(1),
	@oneprint char(1),
	@idtreasurer INT
AS						      
BEGIN						
CREATE TABLE #printing
(
	npay int 
)
CREATE TABLE #address
(
	addresskind int, idreg int, officename varchar(50), address varchar(100),
	location varchar(120), cap varchar(20), province varchar(2), nation varchar(65)	
)	

CREATE TABLE #payment
(
	idfin int, 
	idexp int, ymov smallint, nmov int, 
	parentymov int, parentnmov int,
	parentdescription varchar(255),
	description varchar(255),
	idman int,
	ypay smallint, npay int, npay_treasurer int,
	doc varchar(35), docdate date,
	ayear smallint,
	codeupb varchar(50), titleupb varchar(150), idupb varchar(36),
	codefin	varchar(50), fintitle varchar(150), nlevel tinyint, paridfin int,
	amount decimal(19,2),
	curramount decimal(19,2),
	idreg int, cf varchar(16), p_iva varchar(15),
	birthdate date, birthplace varchar(120), birthprovince varchar(2), birthnation varchar(65),
	address	 varchar(100), location varchar(120), cap varchar(20), province varchar(2), nation varchar(65),
	flaghuman char(1),idregistrypaymethod int, 
	paymethod varchar(50),
	cin varchar(20), idbank varchar(20), bank varchar(150), idcab varchar(20), 
	cab varchar(50), cc varchar(30),iban varchar(50),biccode varchar(20),
-- Inizio Gestione del Delegato
	codicedelegato	int, delegato varchar(200),
-- Fine Gestione del Delegato
	paymentdescr varchar(300),
	idtreasurer int, idtreasurerbank varchar(20), idtreasurercab varchar(20),
	printdate date,
	adate date,
	kind char(1),
	flagarrear char(1),
	rowkind smallint, autokind tinyint,
	taxcode	varchar(20),
	npro int,
	idstamphandling int,
	idinc int,
	nbill int,
	billadate date,
	idpayment int,
	autocode int,
	detaildescription varchar(255),
	detailamount float,
	cupcodeupb varchar(15),
	cupcodeexpense varchar(15),
	cupcodedetail varchar(15),
	decrtemp varchar(100),	
	cigcodeexpense varchar(10),
	cigcodemandate varchar(10),
	extracode varchar(10),
	multibill varchar(8000),
	idchargehandling int,
	handlingbankcode varchar(30),handlingpayment_kind varchar(100), handlingmotive varchar(100)
)

IF @ayear=0 BEGIN SET @ayear='1900' END

DECLARE @dateindi date
SELECT 	@dateindi= @printdate

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_AVV'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SET @NOSTAND = isnull((select idaddress FROM address WHERE codeaddress = @codenostand),0)

DECLARE @MostraPrimoLivOp varchar(1)
SELECT 	@MostraPrimoLivOp =  paramvalue  FROM reportadditionalparam 
WHERE   reportname='mandato_pagamento' and paramname='MostraPrimoLivelloOperativo'

SET @MostraPrimoLivOp = UPPER(@MostraPrimoLivOp)
DECLARE @ModalitaVisualizzazioneBilancioEP varchar(1)
SELECT 	@ModalitaVisualizzazioneBilancioEP =  isnull(paramvalue,'N')  FROM reportadditionalparam 
WHERE   reportname='mandato_pagamento' and paramname='ModalitaVisualizzazioneBilancioEP'

DECLARE @TrattamentoDelleSpesePredefinito varchar(1)
SELECT 	@TrattamentoDelleSpesePredefinito =  paramvalue  FROM reportadditionalparam 
WHERE   reportname='mandato_pagamento' and paramname='TrattamentoDelleSpesePredefinito'
declare @idchargehandling_default int
declare @handlingbankcode varchar(30)
declare @handlingpayment_kind varchar(100)
declare @handlingmotive varchar(100)
if ((@TrattamentoDelleSpesePredefinito is not null) and ISNUMERIC(@TrattamentoDelleSpesePredefinito)=1)
begin	
	set @idchargehandling_default = convert(int, @TrattamentoDelleSpesePredefinito)
	select @handlingbankcode = handlingbankcode, @handlingpayment_kind = payment_kind, @handlingmotive = motive
	from chargehandling where idchargehandling = @idchargehandling_default
end

/*DECLARE @admintaxkind char(1)
SELECT 	@admintaxkind = admintaxkind
	FROM config			
	WHERE ayear = @ayear	*/

DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase) FROM incomephase

DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

DECLARE @paymentdescr varchar(50)
SELECT 	@paymentdescr = (SELECT description FROM expensephase 
			WHERE nphase = (SELECT MAX(nphase) FROM expensephase))
SELECT  @paymentdescr = LTRIM(RTRIM(@paymentdescr))
					
DECLARE @proceedsdescr varchar(50)
SELECT 	@proceedsdescr = description
	FROM incomephase
	WHERE nphase = (SELECT MAX(nphase) FROM incomephase)
SELECT 	@proceedsdescr = LTRIM(RTRIM(@proceedsdescr))

DECLARE @idreg int
SELECT 	@idreg = idregauto 
	FROM config
	WHERE ayear =  @ayear 
						
DECLARE @flag_paymentamount tinyint
DECLARE @automanagekind int
SELECT 	@automanagekind = automanagekind,	
	@flag_paymentamount = flag_paymentamount
FROM config
WHERE ayear = @ayear  		

-- lettura della fase di riferimento valorizzata come parametro aggiuntivo, codice e descrizione
DECLARE @paramphasecode varchar(2)
SELECT 	@paramphasecode =  paramvalue  FROM reportadditionalparam 
	WHERE reportname='mandato_pagamento' and paramname='FaseDaVisualizzare'

DECLARE @phasecode int 

IF  (ISNUMERIC(ISNULL(@paramphasecode,'')) = 1 AND CONVERT(int, @paramphasecode)>0)
	SELECT @phasecode = CONVERT (int, @paramphasecode)
ELSE
	SELECT @phasecode = MAX(nphase) FROM expensephase


DECLARE @phasedescription varchar(50)
SELECT 	@phasedescription = description
	FROM expensephase
	WHERE nphase = @phasecode
SELECT 	@phasedescription = LTRIM(RTRIM(@phasedescription))

DECLARE @expenseregphase	tinyint
SELECT @expenseregphase = expenseregphase FROM  uniconfig

-- main : importo positivo, movimento principale
-- ritenute: importo negativo, da sottrarre
-- contributi: importo negativo, da sottrarre
-- recuperi: importo negativo, da sottrarre
-- varspeserit: importo positivo, (??)
-- revegen: importo negativo
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printing (npay) SELECT npay from  payment where (ypay=@ayear) and (printdate is null) and idtreasurer = @idtreasurer
END

IF @printkind <> 'A'
BEGIN
	INSERT INTO #printing (npay) SELECT npay from  payment where (ypay=@ayear) and (npay BETWEEN @startnpay AND @stopnpay)
	AND ((printdate IS NULL) OR (@oneprint = 'N')) and idtreasurer = @idtreasurer
END
	
DECLARE @admintaxkind1 int
SELECT  @admintaxkind1 = (automanagekind & 0xf) FROM config WHERE ayear = @ayear

INSERT INTO #payment
(
	idfin, 
	idexp, ymov, nmov, description, idman,
	parentymov, parentnmov,parentdescription,
	ypay, npay, npay_treasurer, doc, docdate,
	ayear, idupb, codefin, fintitle, nlevel, paridfin,		
	amount,
	idreg, cf, p_iva, birthdate,
	birthplace, birthprovince, birthnation,
	flaghuman,	
	idregistrypaymethod,
	paymethod,
	cin, idbank, bank, idcab, cab, cc,iban,biccode,
	paymentdescr,
	idtreasurer, idtreasurerbank, idtreasurercab,
	printdate, adate, kind, flagarrear, rowkind, idstamphandling,nbill,billadate, idpayment, autocode,
	cupcodeexpense,
	cupcodeupb,decrtemp,
	cigcodeexpense, extracode,
	idchargehandling,handlingbankcode,handlingpayment_kind,handlingmotive
)
SELECT 
	expenseyear.idfin,
	expense.idexp, expense.ymov, expense.nmov, expense.description, expense.idman,
	parentexpense.ymov,parentexpense.nmov,parentexpense.description,
	payment.ypay, payment.npay,payment.npay_treasurer, expense.doc, expense.docdate,
	expenseyear.ayear, expenseyear.idupb, fin.codefin, fin.title, fin.nlevel, fin.paridfin,
	expensetotal.curramount,
	expense.idreg, registry.cf, registry.p_iva, registry.birthdate,
	ISNULL(geo_city1.title, '') +' ' + ISNULL(registry.location,''),
	ISNULL(geo_country1.province, ''),
	ISNULL(geo_nation1.title, 'Italia'),
	registryclass.flaghuman, 
	expenselast.idregistrypaymethod, 
	paymethod.description,
	expenselast.cin,
	expenselast.idbank ,
	registrybank.description ,
	expenselast.idcab,
	registrycab.description,
	expenselast.cc,
	expenselast.iban,
	expenselast.biccode,
	CASE WHEN paymethod.allowdeputy = 'S' AND expenselast.iddeputy IS NOT NULL 
	     THEN ISNULL(expenselast.paymentdescr,'') + ' ' + ISNULL(deputy.title,'')
		+ ' ' + ISNULL(deputy.cf,'') + ' '
		+ ISNULL(CONVERT(varchar(2),DAY(deputy.birthdate)),'') + '-' + ISNULL(CONVERT(varchar(2),MONTH(deputy.birthdate)),'')
		+ '-' + ISNULL(CONVERT(varchar(4),YEAR(deputy.birthdate)),'')
	     ELSE ISNULL(expenselast.paymentdescr,'')
	END,
	treasurer.idtreasurer, treasurer.idbank, treasurer.idcab,
	payment.printdate, 
	payment.adate, 
	CASE
		when (( payment.flag & 1)<>0) then 'C'
		when (( payment.flag & 2)<>0) then 'R'
		when (( payment.flag & 4)<>0) then 'M'
	End,
   	CASE
		when (( expensetotal.flag & 1)=0) then 'C'
		when (( expensetotal.flag & 1)=1) then 'R'
	End,
	0,
	payment.idstamphandling,
	expenselast.nbill,
	bill.adate,
	expense.idpayment, 
	expense.autocode,
	RegPhase.cupcode,
	isnull(upb.cupcode, finlast.cupcode),
	'main',
	RegPhase.cigcode,
	expenselast.extracode,
	ISNULL(expenselast.idchargehandling,@idchargehandling_default),
	case when expenselast.idchargehandling is null then @handlingbankcode	else chargehandling.handlingbankcode end ,
	case when expenselast.idchargehandling is null then @handlingpayment_kind else chargehandling.payment_kind end,
	case when expenselast.idchargehandling is null then @handlingmotive else chargehandling.motive end
FROM expense
JOIN expenseyear			ON expenseyear.idexp = expense.idexp	AND expenseyear.ayear = @ayear
JOIN expensetotal			ON expensetotal.idexp = expenseyear.idexp	AND expensetotal.ayear = expenseyear.ayear
JOIN fin					ON fin.idfin = expenseyear.idfin
JOIN finlast				ON finlast.idfin = expenseyear.idfin
JOIN upb					ON upb.idupb = expenseyear.idupb
JOIN expenselast			ON expense.idexp = expenselast.idexp
JOIN expenselink			ON expenselink.idchild = expenselast.idexp	AND expenselink.nlevel = @phasecode
JOIN expense parentexpense	ON parentexpense.idexp = expenselink.idparent 
JOIN expenselink as RegPhaseELK	-- Dobbiamo risalire alla fase del creditore
				ON RegPhaseELK.idchild = expenselast.idexp	AND RegPhaseELK.nlevel = @expenseregphase
JOIN expense RegPhase			-- fase del Creditore
						ON RegPhase.idexp = RegPhaseELK.idparent 

JOIN payment			ON payment.kpay = expenselast.kpay
JOIN treasurer			ON treasurer.idtreasurer = payment.idtreasurer
JOIN registry			ON registry.idreg = expense.idreg
LEFT OUTER JOIN paymethod				ON paymethod.idpaymethod = expenselast.idpaymethod
LEFT OUTER JOIN bank registrybank		ON registrybank.idbank = expenselast.idbank 
LEFT OUTER JOIN cab registrycab			ON registrycab.idbank = expenselast.idbank	AND registrycab.idcab = expenselast.idcab
LEFT OUTER JOIN geo_city geo_city1		ON geo_city1.idcity = registry.idcity
LEFT OUTER JOIN geo_country geo_country1		ON geo_city1.idcountry = geo_country1.idcountry
LEFT OUTER JOIN geo_nation geo_nation1			ON geo_nation1.idnation = registry.idnation
LEFT OUTER JOIN registryclass 					ON registry.idregistryclass=registryclass.idregistryclass
LEFT OUTER JOIN registry deputy					ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN bill					ON expenselast.nbill = bill.nbill and bill.ybill = @ayear and bill.billkind = 'D'
LEFT OUTER JOIN chargehandling			ON expenselast.idchargehandling = chargehandling.idchargehandling
WHERE expense.ymov = @ayear
	and payment.ypay=@ayear and payment.idtreasurer=@idtreasurer
	--AND payment.npay  in (select npay from #printing)
	and ( (@printkind='A' and payment.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or payment.printdate is null) and (payment.npay between @startnpay and @stopnpay))
		)


create table #Myexpensebill(idexp int,  nbill int, amount decimal(19,2))
insert into #Myexpensebill(idexp,  nbill, amount)
select expensebill.idexp,  expensebill.nbill, expensebill.amount from expensebill
join expenselast		on expensebill.idexp = expenselast.idexp
join expense			on expenselast.idexp = expense.idexp
JOIN payment			ON payment.kpay = expenselast.kpay
WHERE expense.ymov = @ayear
	and payment.ypay=@ayear and payment.idtreasurer=@idtreasurer
	--AND payment.npay  in (select npay from #printing)
	and ( (@printkind='A' and payment.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or payment.printdate is null) and (payment.npay between @startnpay and @stopnpay))
		)

DECLARE @idexpbill int
DECLARE @nbill int 
DECLARE @amountbill decimal(19,2)


DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT idexp, nbill, amount FROM #Myexpensebill
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @idexpbill,  @nbill, @amountbill
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#payment set
	  multibill = isnull(multibill,'') + 'N.'+isnull(convert(varchar(10),@nbill),'') +  ' Importo € '+ isnull(convert(varchar(20),@amountbill),'')+'. '
	 WHERE idexp = @idexpbill and nbill is null
		FETCH NEXT FROM cursore 
		INTO @idexpbill,  @nbill, @amountbill
	END
CLOSE cursore



declare @fasecontrattopassivo int
select @fasecontrattopassivo = expensephase from config where ayear=@ayear

-- Valorizza codice cup da eventuali -----
-- contabilizzazioni di dettagli ordine --
UPDATE #payment SET cupcodedetail = 
	   (SELECT MAX (cupcode )
		  FROM mandatedetail
		 WHERE (idexp_taxable IN (SELECT idparent 
									FROM expenselink 
								   WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo) 
			OR idexp_iva IN (SELECT idparent 
							   FROM expenselink 
							  WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo))
		   AND cupcode IS NOT NULL)
where cupcodeexpense is null

-- Valorizza il codice CIG eventualmente presente del contratto passivo
UPDATE #payment SET cigcodemandate = 
	   (SELECT MAX( mandate.cigcode )
			FROM mandate
			JOIN mandatedetail
				ON	mandate.idmankind = mandatedetail.idmankind 
				AND mandate.yman = mandatedetail.yman 
				AND mandate.nman = mandatedetail.nman
		 WHERE (mandatedetail.idexp_taxable IN (SELECT idparent 
									FROM expenselink 
								   WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo) 
			OR mandatedetail.idexp_iva IN (SELECT idparent 
							   FROM expenselink 
							  WHERE idchild = #payment.idexp and nlevel=@fasecontrattopassivo))
		 )
where cigcodeexpense is null		 

-- Valorizza il codice CIG eventualmente presente nella fattura
UPDATE #payment SET cigcodemandate = 
	   (SELECT MAX( invoicedetail.cigcode )
			FROM invoicedetail 
		 WHERE (invoicedetail.idexp_taxable = #payment.idexp
				OR invoicedetail.idexp_iva =#payment.idexp)
		)	
where cigcodeexpense is null and cigcodemandate is null		 

-- Valorizza il codice CUP eventualmente presente nella fattura
UPDATE #payment SET cupcodedetail = 
	   (SELECT MAX( invoicedetail.cupcode )
			FROM invoicedetail 
		 WHERE (invoicedetail.idexp_taxable = #payment.idexp
				OR invoicedetail.idexp_iva =#payment.idexp)
		)	
where cupcodeexpense is null and cupcodedetail is null		

/*	flag_paymentamount (bit 0: flagclawback ai fini del mandato  sottrai i recuperi, 
			    bit 1 = flagadmintax ai fini del mandato  sottrai i contributi
			    bit 2: flagtax ai fini del mandato  sottrai le ritenute, 
				)
automanagekind (int)
	bit  0; mask 1; 0x01: admintaxkind 0 - no contr.
	bit  1; mask 2; 0x02: admintaxkind 1 - mov. spesa + mov. entrata
	bit  2; mask 4; 0x04: admintaxkind 2 - var. spesa + mov. entrata
	bit  3; mask 8; 0x08: admintaxkind 3 - liq. diretta
	bit  4; mask 16; 0x10: clawbackkind 0, 1 - no / si
	bit  5; -: inutilizzato
	bit  6; -: inutilizzato
	bit  7; -: inutilizzato
	bit  8; mask 256; 0x100: employtaxkind 0 - no
	bit  9; mask 512; 0x200: employtaxkind 1 - mov. entrata
	bit 10; mask 1024; 0x400: employtaxkind 2 - var. spesa negativa
	bit 11; -: inutilizzato

*/
IF ((@flag_paymentamount&4)<>0 AND (@automanagekind & 1024)= 0) 
	--inserisce le var. spese relative alle ritenute ove le ritenute sono da sottrarre al mov. spesa se non sono create delle var. di spesa
BEGIN
	--sottrai ritenute  con var. spese negative
	INSERT INTO #payment
	(
		idexp, ymov, nmov, ypay, npay,npay_treasurer, 
		--parentymov,parentnmov,parentdescription,
		idstamphandling, printdate, adate, kind, rowkind,
		idreg, idregistrypaymethod,
		description,
		amount,
		taxcode,
		decrtemp,
		idtreasurer
	)
	SELECT
		expense.idexp, expense.ymov, expense.nmov, payment.ypay, payment.npay,payment.npay_treasurer, 
		--parentexpense.ymov,parentexpense.nmov,parentexpense.description,
		payment.idstamphandling, payment.printdate, payment.adate, 
		CASE
			when (( payment.flag & 1)<>0) then 'C'
			when (( payment.flag & 2)<>0) then 'R'
			when (( payment.flag & 4)<>0) then 'M'
		End,
		1,
		expense.idreg, expenselast.idregistrypaymethod,
		tax.description + ' su ' + @paymentdescr + ' n.'+ convert(varchar(6),expense.nmov) + ' (a carico percipiente)',
		- SUM(expensetax.employtax), 
		expensetax.taxcode,
		'ritenute',
		treasurer.idtreasurer
	FROM expense
	JOIN expenselast				ON expense.idexp = expenselast.idexp
	--JOIN expenselink
		--ON expenselink.idchild = expenselast.idexp
		--AND expenselink.nlevel = @phasecode
	--JOIN expense parentexpense
		--ON parentexpense.idexp = expenselink.idparent
	JOIN expenseyear				ON expenseyear.idexp = expense.idexp
	JOIN payment					ON payment.kpay = expenselast.kpay
	JOIN treasurer					ON treasurer.idtreasurer = payment.idtreasurer
	JOIN expensetax					ON expensetax.idexp = expense.idexp
	JOIN tax						ON tax.taxcode = expensetax.taxcode
	WHERE expense.ymov = @ayear
		AND expenseyear.ayear = @ayear
		and payment.ypay=@ayear and payment.idtreasurer=@idtreasurer
	--AND payment.npay  in (select npay from #printing)
	and ( (@printkind='A' and payment.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or payment.printdate is null) and (payment.npay between @startnpay and @stopnpay))
		)
	GROUP BY expense.ymov, expense.nmov, 
		--parentexpense.ymov,parentexpense.nmov,parentexpense.description,
		payment.ypay, payment.npay, payment.npay_treasurer, expense.idexp, expense.idreg, 
		expenselast.idregistrypaymethod, 
		tax.description, payment.idstamphandling, payment.printdate, payment.adate, 
		payment.flag, 
		expensetax.taxcode, treasurer.idtreasurer
	HAVING SUM(expensetax.employtax) > 0 

END

IF ((@flag_paymentamount&2)<>0) --sottrai i contributi dal mandato ove il flag lo specifica
BEGIN
	INSERT INTO #payment
	(
		idexp, ymov, nmov, ypay, npay,npay_treasurer, 
		--parentymov, parentnmov,parentdescription,
		idstamphandling, printdate,adate, kind, rowkind,
		idreg, idregistrypaymethod,
		description,
		amount,
		taxcode,
		decrtemp,
		idtreasurer
	)
	SELECT
		expense.idexp, expense.ymov, expense.nmov, payment.ypay, payment.npay,payment.npay_treasurer, 
		--parentexpense.ymov,parentexpense.nmov,parentexpense.description,
		payment.idstamphandling, payment.printdate, payment.adate,
		CASE
			when (( payment.flag & 1)<>0) then 'C'
			when (( payment.flag & 2)<>0) then 'R'
			when (( payment.flag & 4)<>0) then 'M'
		End,
		1,
		expense.idreg, expenselast.idregistrypaymethod, 
		tax.description + ' su ' + @paymentdescr + ' n.'+ convert(varchar(6),expense.nmov) + ' (a carico amministrazione)',
		- SUM(expensetax.admintax),
		expensetax.taxcode,
		'contributi',
		treasurer.idtreasurer
	FROM expense
	JOIN expenselast			ON expense.idexp = expenselast.idexp
	--JOIN expenselink
		--ON expenselink.idchild = expenselast.idexp
		--AND expenselink.nlevel = @phasecode
	--JOIN expense parentexpense
		--ON parentexpense.idexp = expenselink.idparent
	JOIN expenseyear			ON expenseyear.idexp = expense.idexp
	JOIN payment				ON payment.kpay = expenselast.kpay
	JOIN treasurer				ON treasurer.idtreasurer = payment.idtreasurer
	JOIN expensetax				ON expensetax.idexp = expense.idexp
	JOIN tax					ON tax.taxcode = expensetax.taxcode
	WHERE expense.ymov = @ayear
		AND expenseyear.ayear = @ayear
		and payment.ypay=@ayear and payment.idtreasurer=@idtreasurer
	--AND payment.npay  in (select npay from #printing)
	and ( (@printkind='A' and payment.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or payment.printdate is null) and (payment.npay between @startnpay and @stopnpay))
		)
	GROUP BY expense.ymov, expense.nmov,  
		--parentexpense.ymov,parentexpense.nmov,parentexpense.description,
		payment.ypay, payment.npay, payment.npay_treasurer, expense.idexp, expense.idreg,
		expenselast.idregistrypaymethod,
		tax.description, payment.idstamphandling, payment.printdate, payment.adate,payment.flag, expensetax.taxcode,treasurer.idtreasurer
	HAVING SUM(expensetax.admintax) > 0

END
 
IF ((@flag_paymentamount&1)<>0) -- sottrai i recuperi
BEGIN
	INSERT INTO #payment
		(
		idexp, ymov, nmov, ypay, npay,npay_treasurer, 
		--parentymov,parentnmov,parentdescription,
		idstamphandling, printdate,adate, kind, rowkind,
		idreg, idregistrypaymethod,
		description,
		amount,
		taxcode,
		decrtemp,
		idtreasurer
		)
	SELECT
		expense.idexp, expense.ymov, expense.nmov, payment.ypay, payment.npay,payment.npay_treasurer, 
		--parentexpense.ymov,parentexpense.nmov,parentexpense.description,
		payment.idstamphandling, payment.printdate, payment.adate, 
		CASE
			when (( payment.flag & 1)<>0) then 'C'
			when (( payment.flag & 2)<>0) then 'R'
			when (( payment.flag & 4)<>0) then 'M'
		End,
		1,
		expense.idreg, expenselast.idregistrypaymethod, 
		clawback.description + ' su ' + @paymentdescr + ' n.'+ convert(varchar(6),expense.nmov),
		- (expenseclawback.amount),
		expenseclawback.idclawback,
		'recuperi',
		treasurer.idtreasurer
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	--JOIN expenselink
		--ON expenselink.idchild = expenselast.idexp
		--AND expenselink.nlevel = @phasecode
	--JOIN expense parentexpense
		--ON parentexpense.idexp = expenselink.idparent
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN treasurer
		ON treasurer.idtreasurer = payment.idtreasurer
	JOIN expenseclawback
		ON expenseclawback.idexp = expense.idexp
	JOIN clawback
		ON clawback.idclawback = expenseclawback.idclawback
	WHERE expense.ymov = @ayear
		AND expenseyear.ayear = @ayear
		AND expenseclawback.amount > 0
		and payment.ypay=@ayear and payment.idtreasurer=@idtreasurer
	--AND payment.npay  in (select npay from #printing)
	and ( (@printkind='A' and payment.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or payment.printdate is null) and (payment.npay between @startnpay and @stopnpay))
		)

END

IF (( @automanagekind & 1024)<>0 ) --var. spesa negativa  per le ritenute
BEGIN
	INSERT INTO #payment
		(
		idexp, ymov, nmov, ypay, npay,npay_treasurer, 
		idstamphandling, printdate, adate, kind, rowkind, 
		idreg, idregistrypaymethod,
		description,
		amount,decrtemp,
		idtreasurer
		)
	  SELECT 
		  expense.idexp,  expense.ymov, expense.nmov, payment.ypay, payment.npay,payment.npay_treasurer, 
		  payment.idstamphandling, payment.printdate, payment.adate, 
		  CASE
			when (( payment.flag & 1)<>0) then 'C'
			when (( payment.flag & 2)<>0) then 'R'
			when (( payment.flag & 4)<>0) then 'M'
		  End,
		  1,
		  expense.idreg, expenselast.idregistrypaymethod, 
		  tax.description + ' su ' + @paymentdescr + 'n.'+ convert(varchar(6),expense.nmov) + ' (a carico percipiente)' as XX,
		  SUM(expensetax.employtax),
		 'varspeserit',
		 treasurer.idtreasurer
	  FROM expense
	  JOIN expenselast				ON expense.idexp = expenselast.idexp	
	  JOIN expenseyear				ON expenseyear.idexp = expense.idexp
	  JOIN payment					ON payment.kpay = expenselast.kpay
	JOIN treasurer					ON treasurer.idtreasurer = payment.idtreasurer
	  JOIN expensetax				ON expensetax.idexp = expense.idexp				  
	  JOIN tax						ON tax.taxcode = expensetax.taxcode
	  WHERE expense.ymov = @ayear		  
		  AND expenseyear.ayear = @ayear
		  and payment.ypay=@ayear and payment.idtreasurer=@idtreasurer
	--AND payment.npay  in (select npay from #printing)
	and ( (@printkind='A' and payment.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or payment.printdate is null) and (payment.npay between @startnpay and @stopnpay))
		)
	  GROUP BY expense.ymov, expense.nmov,  
		payment.ypay, payment.npay,payment.npay_treasurer, 
		expense.idexp,expense.idreg, expenselast.idregistrypaymethod, 
		tax.description + ' su ' + @paymentdescr + 'n.'+ convert(varchar(6),expense.nmov) + ' (a carico percipiente)' ,
		idstamphandling,payment.printdate,payment.adate, payment.flag,	payment.annulmentdate,treasurer.idtreasurer
	  HAVING SUM(expensetax.employtax)>0
END

/*;with lista_incassi(idinc,exp_nmov)as(
select I.idinc,E.nmov	 from expenselast EL
	JOIN income		ON income.idpayment = EL.idexp
	join expense E  ON E.idexp=EL.idexp
	JOIN incomelast  ON income.idinc = incomelast.idinc
union all
    select distinct E.idproceeds,null 	
		from expenselast EL
		JOIN expense E	ON E.idexp = expenselast.idexp
		join income I on I.idinc = E.idproceeds
		where I.idpayment is null
)
*/
INSERT INTO #payment
		(
		idexp, ymov, nmov, ypay, npay,npay_treasurer, 
		idstamphandling, printdate,adate, kind, rowkind,
		idreg, idregistrypaymethod,
		description,
		amount,decrtemp,
		idtreasurer
		)
	SELECT
		expense.idexp, expense.ymov, expense.nmov, payment.ypay, payment.npay,
		payment.npay_treasurer, 
		payment.idstamphandling, payment.printdate, payment.adate, 
		CASE
			when (( payment.flag & 1)<>0) then 'C'
			when (( payment.flag & 2)<>0) then 'R'
			when (( payment.flag & 4)<>0) then 'M'
		End,
		1,
		expense.idreg, expenselast.idregistrypaymethod, 
		income.description
				 + isnull(' su ' + @paymentdescr + ' n.'+ convert(varchar(6),expense.nmov) ,'')
			+ ' - ' + @proceedsdescr + ' n. ' + CONVERT(varchar(6),income.nmov) 
			+ isnull(  ' - Reversale n. '		+ CONVERT(varchar(6),proceeds.npro) ,''),			
		- (incometotal.curramount),
		'revegen',
		treasurer.idtreasurer
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN treasurer
		ON treasurer.idtreasurer = payment.idtreasurer
	JOIN income
		ON income.idpayment = expense.idexp
	JOIN incomelast
		ON income.idinc = incomelast.idinc
	JOIN incometotal
		ON income.idinc = incometotal.idinc 
	JOIN incomeyear
		ON incometotal.idinc = incomeyear.idinc and incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN proceeds
		ON incomelast.kpro = proceeds.kpro
	WHERE expense.ymov = @ayear
		AND expenseyear.ayear = @ayear
		AND income.autokind in (7,14,20,21,30,31) -- automatismi generici (14) e CSA (20) --ricavo lordi
		--AND income.autocode is null		
		and (incomelast.flag & 32 = 0 )-- Incasso con spese accessorie
		and payment.ypay=@ayear and payment.idtreasurer=@idtreasurer
	--AND payment.npay  in (select npay from #printing)
	and ( (@printkind='A' and payment.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or payment.printdate is null) and (payment.npay between @startnpay and @stopnpay))
		)

/*
INSERT INTO #payment
		(
		idexp, ymov, nmov, ypay, npay,
		idstamphandling, printdate, kind, rowkind,
		idreg, idregistrypaymethod,
		description,
		amount,decrtemp
		)
	SELECT 
		null, null, null, payment.ypay, payment.npay,
		payment.idstamphandling, payment.printdate, 
		CASE
			when (( payment.flag & 1)<>0) then 'C'
			when (( payment.flag & 2)<>0) then 'R'
			when (( payment.flag & 4)<>0) then 'M'
		End,
		1,
		expense.idreg, expenselast.idregistrypaymethod, 
		income.description
				 --+ isnull(' su ' + @paymentdescr + ' n.'+ convert(varchar(6),expense.nmov) ,'')
			+ ' - ' + @proceedsdescr + ' n. ' + CONVERT(varchar(6),income.nmov) 
			+ isnull(  ' - Reversale n. '		+ CONVERT(varchar(6),proceeds.npro) ,''),			
		- (incometotal.curramount),
		'importflow'
	FROM expense
	JOIN expenselast
		ON expense.idexp = expenselast.idexp
	JOIN expenseyear
		ON expenseyear.idexp = expense.idexp
	JOIN payment
		ON payment.kpay = expenselast.kpay
	JOIN income
		ON income.idinc = expense.idproceeds
	JOIN incomelast
		ON income.idinc = incomelast.idinc
	JOIN incometotal
		ON income.idinc = incometotal.idinc 
	JOIN incomeyear
		ON incometotal.idinc = incomeyear.idinc and incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN proceeds
		ON incomelast.kpro = proceeds.kpro
	WHERE expense.ymov = @ayear
		AND expenseyear.ayear = @ayear
		AND incomeyear.ayear = @ayear
		AND payment.npay  in (select npay from #printing)
*/		
--select * from #payment
IF (@MostraPrimoLivOp='S')
BEGIN

	DECLARE @nlevel tinyint
	SELECT @nlevel = MIN(nlevel) 
		FROM finlevel 
		WHERE ayear=@ayear AND (flag&2)<>0

	UPDATE  #payment
		SET codefin = fin.codefin,
		    fintitle = fin.title
		FROM #payment
		JOIN finlink
			ON #payment.idfin = finlink.idchild 
		JOIN fin
			ON finlink.idparent = fin.idfin
		WHERE finlink.nlevel = @nlevel
			and finlink.idparent = #payment.paridfin

END

--select * from  #payment


DECLARE @idexp int
DECLARE @amount	decimal(19,2)
DECLARE @nummov int
DECLARE @numdocinc int
DECLARE @autokind tinyint
DECLARE @ident int
DECLARE @idpayment int 
DECLARE @autocode int
DECLARE @rowkind int
DECLARE @incomeamount decimal(19,2)

DECLARE assegna CURSOR FOR
SELECT 
	r.idexp,r.amount,r.idpayment,r.autocode,r.rowkind
	FROM #payment r
	--WHERE rowkind > 0
OPEN assegna
FETCH NEXT FROM assegna
INTO @idexp,@amount,@idpayment,@autocode,@rowkind

WHILE (@@FETCH_STATUS = 0)
BEGIN
	SET @nummov = NULL;
	SET @numdocinc = NULL;
	SET @ident = NULL;
	-- se la configurazione dei contributi prevede un automatismo di spesa e uno di entrata su partita di giro
	-- per gli automatismi dei contributi indico la reversale del corrispondente automatismo di entrata
	IF  ((@rowkind = 0) AND (@admintaxkind1 <> 4) AND (@idpayment IS NOT NULL) AND (@autocode IS NOT NULL))
	BEGIN
		SET @ident = (SELECT TOP 1 income.idinc 
			FROM income 
			JOIN incometotal
				ON income.idinc = incometotal.idinc and ((incometotal.flag & 2) = 2) 
			JOIN incomeyear
				ON incometotal.idinc = incomeyear.idinc and incometotal.ayear = incomeyear.ayear
		WHERE income.idpayment = @idpayment 
		AND income.autokind = 4 
		AND income.autocode = @autocode
		AND nphase = @maxincomephase
		AND incomeyear.ayear = @ayear
		AND income.idreg     = @idreg
		AND income.idinc NOT IN (SELECT ISNULL(idinc,0) FROM #payment)) 
	END
	
	IF (@rowkind > 0)
	BEGIN
		SET @ident = (SELECT TOP 1 income.idinc 
			FROM income 
			JOIN incometotal
				ON income.idinc = incometotal.idinc and ((incometotal.flag & 2) = 2) 
			JOIN incomeyear
				ON incometotal.idinc = incomeyear.idinc and incometotal.ayear = incomeyear.ayear
		WHERE income.idpayment = @idexp AND income.autokind = 4 AND nphase = @maxincomephase
		AND incomeyear.ayear = @ayear
		AND (income.idreg <> @idreg OR @idreg IS NULL)
		and incomeyear.amount = ABS(@amount) AND income.idinc NOT IN (SELECT ISNULL(idinc,0) FROM #payment))
	END
	
	IF (@ident IS NOT NULL)
	BEGIN
		SELECT @nummov = income.nmov, @numdocinc = proceeds.npro , @incomeamount= incometotal.curramount
		FROM income
		JOIN incomelast
			ON income.idinc = incomelast.idinc
		JOIN incometotal
			ON incometotal.idinc = incomelast.idinc
		JOIN proceeds
			ON proceeds.kpro = incomelast.kpro
		WHERE incomelast.idinc = @ident

		UPDATE  #payment
		SET curramount=
			CASE
			WHEN @nummov IS NOT NULL AND @numdocinc IS NOT NULL and rowkind > 0 AND (@idpayment IS  NULL) AND (@autocode IS  NULL)
			THEN -@incomeamount
			ELSE NULL
			END,
			description =
			CASE
			WHEN @nummov IS NOT NULL AND @numdocinc IS NOT NULL
			THEN
				 #payment.description + ' - ' + @proceedsdescr + ' n. ' 
				+ CONVERT(varchar(6),@nummov) + ' - Reversale n. '
				+ CONVERT(varchar(6),@numdocinc)
			ELSE
				#payment.description 
			END,
		idinc = @ident,
		autokind = 4,
		npro = @numdocinc
		WHERE CURRENT OF assegna
	END
	

	SET @nummov = NULL;
	SET @numdocinc = NULL;
	SET @ident = NULL;

	SET @ident = (SELECT TOP 1 income.idinc 
			FROM income 
			JOIN incometotal
				ON income.idinc = incometotal.idinc and ((incometotal.flag & 2) = 2) 
			JOIN incomeyear
				ON incometotal.idinc = incomeyear.idinc and incometotal.ayear = incomeyear.ayear
		WHERE income.idpayment = @idexp AND income.autokind = 6  AND nphase = @maxincomephase  -- automatismi recuperi (6) 
		AND incomeyear.ayear = @ayear
		and incomeyear.amount = ABS(@amount) AND income.idinc NOT IN (SELECT ISNULL(idinc,0) FROM #payment))
	IF (@ident IS NOT NULL)
	BEGIN
		SELECT @nummov = income.nmov, @numdocinc = proceeds.npro,   @incomeamount= incometotal.curramount,
		@autokind = income.autokind
		FROM income
		JOIN incomelast
			ON income.idinc = incomelast.idinc
		JOIN incometotal
			ON incometotal.idinc = incomelast.idinc
		JOIN proceeds
			ON proceeds.kpro = incomelast.kpro
		WHERE incomelast.idinc = @ident
		UPDATE  #payment SET 
			curramount=
			CASE 
			WHEN @nummov IS NOT NULL AND @numdocinc IS NOT NULL and rowkind > 0 
					AND (@idpayment IS  NULL) AND (@autocode IS  NULL)
			THEN -@incomeamount
			ELSE NULL
			END,
			description = CASE
				WHEN @nummov IS NOT NULL AND @numdocinc IS NOT NULL
				THEN
					 #payment.description + ' - ' + @proceedsdescr + ' n. ' 
					+ CONVERT(varchar(6),@nummov) + ' - Reversale n. '
					+ CONVERT(varchar(6),@numdocinc)
				ELSE
					#payment.description 
				END,
			idinc = @ident,
			autokind = @autokind,
			npro = @numdocinc
			WHERE CURRENT OF assegna
	END
	FETCH NEXT FROM assegna
	INTO @idexp,@amount,@idpayment,@autocode,@rowkind
END
CLOSE assegna
DEALLOCATE assegna

INSERT INTO #address
SELECT
	idaddresskind,
	idreg, 
	officename, 
	address,
	ISNULL(geo_city.title,'')+' ' +ISNULL(registryaddress.location,''),
	registryaddress.cap,
	geo_country.province,
	case when flagforeign = 'N' then 'Italia' else geo_nation.title end
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE 
	(
	    registryaddress.active <>'N' 
	AND registryaddress.start = 
	(SELECT MAX(cdi.start) 
	FROM registryaddress cdi 
	WHERE cdi.idaddresskind = registryaddress.idaddresskind
	AND cdi.active <>'N' 
	AND ((cdi.stop is null) OR (cdi.stop >= @dateindi)) 
	and cdi.idreg = registryaddress.idreg))
	AND (idreg IN (select idreg from  #payment))

delete #address
	where #address.addresskind <> @nostand
	and exists (
		select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.addresskind = @nostand
	)
delete #address
	where #address.addresskind not in (@nostand, @stand)
	and exists (
		select * from #address r2 
		where #address.idreg=r2.idreg
		and r2.addresskind = @stand
	)
delete #address
	where (
		select count(*) from #address r2 
		where #address.idreg=r2.idreg
	)>1
IF @official = 'S' 
BEGIN 
	print 'Updating...'
	UPDATE #payment
	SET printdate =	@printdate
	WHERE ypay = @ayear
	--AND npay  in (select npay from #printing)
	AND printdate is null
END

UPDATE #payment SET
paymentdescr = (SELECT paymentdescr FROM #payment p
				 WHERE #payment.ymov = p.ymov
				 AND #payment.nmov = p.nmov
				 AND #payment.ypay = p.ypay
				 AND #payment.npay = p.npay
				 AND #payment.idexp = p.idexp
				 AND rowkind = 0),
paymethod = (SELECT paymethod FROM #payment p
				 WHERE #payment.ymov = p.ymov
				 AND #payment.nmov = p.nmov
				 AND #payment.ypay = p.ypay
				 AND #payment.npay = p.npay
				 AND #payment.idexp = p.idexp
				 AND rowkind = 0),
iban= (SELECT iban FROM #payment p
				 WHERE #payment.ymov = p.ymov
				 AND #payment.nmov = p.nmov
				 AND #payment.ypay = p.ypay
				 AND #payment.npay = p.npay
				 AND #payment.idexp = p.idexp
				 AND rowkind = 0)
WHERE rowkind > 0

SELECT
	#payment.ymov, #payment.nmov, #payment.ypay, #payment.npay,
	#payment.npay_treasurer,#payment.idexp,@maxexpensephase as fasemax,
	#payment.parentymov, #payment.parentnmov,@phasecode as codfaseimpegno, @phasedescription as faseimpegno,
	#payment.parentdescription,
	#payment.doc, 
	CONVERT(datetime, #payment.docdate)   as docdate, 
	#payment.idman, manager.title as manager,	
	#payment.description,
	upb.codeupb, upb.title as titleupb, #payment.idupb, 
	--  expense -> mandatedetail -> upb -> fin
	isnull(#payment.cupcodeexpense, ISNULL(#payment.cupcodedetail,#payment.cupcodeupb) )	as cupcode,
	ISNULL(cigcodeexpense, ISNULL(cigcodemandate,'')) as cigcode,
	#payment.idreg, registry.title as registry,	
	#address.address, #address.location, #address.cap, #address.province, #address.nation, 
	#payment.cf, #payment.p_iva, 
	CONVERT(datetime, #payment.birthdate)  as birthdate, #payment.birthplace, #payment.birthprovince, #payment.birthnation,
	#payment.flaghuman, registrypaymethod.regmodcode,
	ISNULL(#payment.extracode,registrypaymethod.extracode) as extracode, -- codice contabilità speciale, girofondo in banca d'Italia
	#payment.paymethod,
	#payment.cin, #payment.idbank, #payment.bank, #payment.idcab, #payment.cab, #payment.cc,
	#payment.iban,#payment.biccode,
	CASE WHEN RTRIM(LTRIM(#payment.paymentdescr))='' THEN NULL ELSE RTRIM(LTRIM(#payment.paymentdescr)) END AS paymentdescr, 
	#payment.ayear,
	CASE
		WHEN finlast.idacc IS NULL  THEN #payment.codefin + ' ('+ #payment.fintitle +')'
		WHEN patrimony.codepatrimony IS NOT NULL and @ModalitaVisualizzazioneBilancioEP = 'F'/*bilancio + EP*/
				 THEN	#payment.codefin + '/'+ #payment.fintitle +
						CHAR(13) +'EP:' + account.codeacc + '/'+account.title + CHAR(13) +'SP: '+patrimony.codepatrimony +'/'+ patrimony.title  
		
		WHEN patrimony.codepatrimony IS NOT NULL and @ModalitaVisualizzazioneBilancioEP = 'E' /*solo EP*/
				THEN	'EP:'+ account.codeacc + '/'+account.title +	CHAR(13) +'SP: '+patrimony.codepatrimony +'/'+ patrimony.title 
		
		WHEN placcount.codeplaccount IS NOT NULL and @ModalitaVisualizzazioneBilancioEP = 'F'/*bilancio + EP*/
				THEN	#payment.codefin + '/'+ #payment.fintitle +
						CHAR(13)+'EP:' + account.codeacc + '/'+account.title  + CHAR(13) + 'CE: '+placcount.codeplaccount + '/'+placcount.title 
		
		WHEN placcount.codeplaccount IS NOT NULL and @ModalitaVisualizzazioneBilancioEP = 'E' /*solo EP*/
				THEN 'EP:' + account.codeacc + '/'+account.title + CHAR(13) + 'CE: '+placcount.codeplaccount + '/'+placcount.title
		ELSE #payment.codefin 
	END +REPLICATE(' ',500) as codefin,
	#payment.fintitle as fintitle,-- nn è più usato nel report 
	#payment.nlevel,
	isnull(#payment.curramount,#payment.amount) as amount,
	--#payment.decrtemp,
	--#payment.amount as amount_old,
	treasurerbank.description as  treasurerbank,
	treasurercab.description as treasurercab,
	treasurer.address as treasureraddress,
	treasurer.cap as treasurercap,
	treasurer.city as treasurercity,
	treasurer.country as treasurercountry,
	treasurer.cc as treasurercc,
	treasurer.agencycodefortransmission	,
	treasurer.header,	
	payment.txt as notes,
	CONVERT(datetime, #payment.printdate)  as printdate, 
	CONVERT(datetime, #payment.adate)  as adate,
	 #payment.kind, #payment.flagarrear, #payment.rowkind, #payment.autokind, #payment.npro,
	stamphandling.description as stamphandling,
	CONVERT(datetime, payment.annulmentdate)   as annulmentdate,	
	@paymentdescr as descrlastfase,
	#payment.nbill	,
	CONVERT(datetime,#payment.billadate)   as billadate,
	#payment.multibill,
	#payment.idchargehandling, #payment.handlingbankcode, #payment.handlingpayment_kind, #payment.handlingmotive
	--,payment.LT
FROM #payment
JOIN payment
	ON payment.ypay = #payment.ypay
	AND payment.npay = #payment.npay
LEFT OUTER JOIN registrypaymethod
	ON registrypaymethod.idreg = #payment.idreg
	AND registrypaymethod.idregistrypaymethod = #payment.idregistrypaymethod
LEFT OUTER JOIN paymethod
	ON registrypaymethod.idpaymethod = paymethod.idpaymethod
LEFT OUTER JOIN #address
	ON #address.idreg = #payment.idreg
LEFT OUTER JOIN registry
	ON registry.idreg = #payment.idreg
LEFT OUTER JOIN treasurer
	ON treasurer.idtreasurer = #payment.idtreasurer
LEFT OUTER JOIN manager 
	on manager.idman = #payment.idman
LEFT OUTER JOIN upb
	on upb.idupb = #payment.idupb
LEFT OUTER JOIN bank treasurerbank
	ON treasurerbank.idbank = #payment.idtreasurerbank
LEFT OUTER JOIN cab treasurercab
	ON treasurercab.idbank = #payment.idtreasurerbank
	AND treasurercab.idcab = #payment.idtreasurercab
LEFT OUTER JOIN stamphandling
	ON stamphandling.idstamphandling = #payment.idstamphandling
LEFT OUTER JOIN finlast
	ON finlast.idfin = #payment.idfin
LEFT OUTER JOIN account
	ON finlast.idacc = account.idacc
LEFT OUTER JOIN patrimony
	ON account.idpatrimony = patrimony.idpatrimony
LEFT OUTER JOIN placcount
	ON account.idplaccount = placcount.idplaccount

ORDER BY #payment.npay ASC, 
	registry.title ASC,
	registrypaymethod.regmodcode ASC,
	#payment.nmov ASC, 
	#payment.rowkind ASC,
        #payment.npro ASC 
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 	
