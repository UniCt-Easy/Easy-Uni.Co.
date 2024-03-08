
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_reversale_incasso_siope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_reversale_incasso_siope]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
CREATE   PROCEDURE [rpt_reversale_incasso_siope]
	@ayear int,
	@printkind char(1),
	@startnpro int,
	@stopnpro int,
	@printdate datetime,
	@official char(1),
	@oneprint char(1),
	@idtreasurer int
AS
BEGIN

-- exec rpt_reversale_incasso_siope 2015, 'I', 1, 1000, null, 'N', 'N',4
IF 	@ayear=0  SET @ayear='1900'

CREATE TABLE #printing (npro int)
		
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printing (npro) 
	SELECT npro FROM proceeds WHERE (ypro = @ayear) and (printdate is null) and idtreasurer = @idtreasurer
END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printing (npro) 
	SELECT npro FROM proceeds WHERE (ypro=@ayear) and (npro BETWEEN @startnpro AND @stopnpro)
	AND ((printdate IS NULL) OR (@oneprint = 'N')) and idtreasurer = @idtreasurer
END

/*
DECLARE @assessmentphasecode tinyint
SELECT  @assessmentphasecode = assessmentphasecode
FROM 	config
WHERE 	ayear = @ayear
IF 	@assessmentphasecode IS NULL
BEGIN
	SELECT @assessmentphasecode = incomefinphase
	FROM uniconfig
END


DECLARE @assessmentphase varchar(50)
SELECT 	@assessmentphase = description
	FROM incomephase
	WHERE nphase = @assessmentphasecode
SELECT 	@assessmentphase = LTRIM(RTRIM(@assessmentphase))
*/

-- lettura della fase di riferimento valorizzata come parametro aggiuntivo, codice e descrizione
DECLARE @paramphasecode varchar(2)
SELECT 	@paramphasecode =  paramvalue  FROM reportadditionalparam 
	WHERE reportname='reversale_incasso' and paramname='FaseDaVisualizzare'

DECLARE @phasecode int 

IF  (ISNUMERIC(ISNULL(@paramphasecode,'')) = 1 AND CONVERT(int, @paramphasecode)>0)
	SELECT @phasecode = CONVERT (int, @paramphasecode)
ELSE
	SELECT @phasecode = MAX(nphase) FROM incomephase

DECLARE @phasedescription varchar(50)
SELECT 	@phasedescription = description
	FROM incomephase
	WHERE nphase = @phasecode
SELECT 	@phasedescription = LTRIM(RTRIM(@phasedescription))


DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase) FROM incomephase

DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase


DECLARE @phaseexpense varchar(50)
SELECT 	@phaseexpense = description
	FROM expensephase
	WHERE nphase = @maxexpensephase
SELECT 	@phaseexpense = LTRIM(RTRIM(@phaseexpense))

DECLARE @incomeregphase	tinyint
SELECT @incomeregphase = incomeregphase FROM  uniconfig


CREATE TABLE #proceeds
(
	idinc int,
	ypro int, npro int, npro_treasurer int,
	ymov int, nmov int,
	parentymov int, parentnmov int,
	parentdescription varchar(255),
	idman int,
	description varchar(255),
	idreg int,
	codeupb varchar(50),
	titleupb varchar(150),
	idupb varchar(36),
	ayear int,
	idfin int,
	codefin	varchar(50),
	fintitle varchar(150),
	nlevel tinyint,
	paridfin int,
	amount float,
	idtreasurer int,
	data datetime,
	adate datetime,
    accountkind char(1),        
	kind char(1),
	flagarrear char(1),
	rowkind int,
	autokind int, 
	detaildescription varchar(255),
	detailamount float,
	annulmentdate datetime,
	doc varchar(50), 
	docdate datetime,
	nbill int,
	billadate datetime,
	cupcode varchar(15),
	cupcodeincome varchar(15),
	idstamphandling int,
	flagbankitaliaproceeds char(1),
	flag_ccp char(1),
	multibill varchar(8000))

					
DECLARE @admintaxkind1 int
SELECT  @admintaxkind1 = (automanagekind & 0xf) FROM config WHERE ayear = @ayear

DECLARE @idreg int 
SELECT  @idreg = idregauto FROM config WHERE ayear = @ayear 

INSERT INTO #proceeds
	(
	rowkind, 
	idinc,	idreg,	ypro, npro,npro_treasurer, ymov,	nmov,
	parentymov, parentnmov,parentdescription,
	idman,	description,	idupb,	ayear,	idfin,
	codefin,	fintitle, nlevel,paridfin,	
	amount,
	idtreasurer,	data,	adate,
	accountkind,kind,	
	flagarrear,
	annulmentdate,
	doc,	docdate, nbill, billadate, cupcode, cupcodeincome,
	idstamphandling,	flagbankitaliaproceeds,	flag_ccp 
	)
SELECT  
	0,
	income.idinc, income.idreg, income.ymov, proceeds.npro, proceeds.npro_treasurer, income.ymov, income.nmov,
	parentincome.ymov, parentincome.nmov,parentincome.description,
	income.idman, income.description, incomeyear.idupb, incomeyear.ayear, fin.idfin,
	fin.codefin, fin.title, fin.nlevel, fin.paridfin,
	incometotal.curramount,
	proceeds.idtreasurer, proceeds.printdate,proceeds.adate,
        case proceeds.flag&8 when 0 then 'I' else 'F' end,
	case proceeds.flag&7 
		when 1 then 'C' 
		when 2 then 'R' 
		when 4 then 'M' 
	end,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	proceeds.annulmentdate,
	income.doc,
	income.docdate,	incomelast.nbill, bill.adate, finlast.cupcode, RegPhase.cupcode,
	proceeds.idstamphandling,
	CASE
		WHEN (incomelast.flag&8) <> 0 THEN 'S' -- RISCOSSIONE PRESSO TPS
		ELSE 'N'
	END,
	CASE
		WHEN (incomelast.flag&4) <> 0 THEN 'S' --PRELIEVO DA CONTO CORRENTE POSTALE
		ELSE 'N'
	END 
FROM income
JOIN incomeyear
	ON incomeyear.idinc = income.idinc
	AND incomeyear.ayear = @ayear
JOIN incometotal
	ON incometotal.idinc = incomeyear.idinc
	AND incometotal.ayear = incomeyear.ayear
JOIN incomelast
	ON incomelast.idinc = income.idinc
JOIN incomelink
	ON incomelink.idchild = incomelast.idinc
	AND incomelink.nlevel = @phasecode
JOIN income parentincome
	ON parentincome.idinc = incomelink.idparent

JOIN incomelink as RegPhaseILK	-- Dobbiamo risalire alla fase del creditore
	ON RegPhaseILK.idchild = incomelast.idinc
	AND RegPhaseILK.nlevel = @incomeregphase
JOIN income RegPhase			-- fase del Creditore
	ON RegPhase.idinc = RegPhaseILK.idparent 
 JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN fin
	ON fin.idfin = incomeyear.idfin
JOIN finlast
	ON finlast.idfin = incomeyear.idfin
LEFT OUTER JOIN bill
	ON incomelast.nbill = bill.nbill and bill.ybill = @ayear and bill.billkind = 'C'
WHERE income.ymov = @ayear	
	--AND proceeds.npro  in (select npro from #printing)
	and proceeds.ypro=@ayear and proceeds.idtreasurer=@idtreasurer
	and ( (@printkind='A' and proceeds.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or proceeds.printdate is null) and (proceeds.npro between @startnpro and @stopnpro))
		)


create table #Myincomebill(idinc int,  nbill int, amount decimal(19,2))
insert into #Myincomebill(idinc,  nbill, amount)
select incomebill.idinc,  incomebill.nbill, incomebill.amount from incomebill
join incomelast
	on incomebill.idinc = incomelast.idinc
join income
	on incomelast.idinc = income.idinc
JOIN proceeds
	ON proceeds.kpro = incomelast.kpro
WHERE income.ymov = @ayear
	--AND proceeds.npro  in (select npro from #printing)
	and proceeds.ypro=@ayear and proceeds.idtreasurer=@idtreasurer
	and ( (@printkind='A' and proceeds.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or proceeds.printdate is null) and (proceeds.npro between @startnpro and @stopnpro))
		)


DECLARE @idincbill int
DECLARE @nbill int 
DECLARE @amountbill decimal(19,2)


DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT idinc, nbill, amount FROM #Myincomebill
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @idincbill,  @nbill, @amountbill
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#proceeds set
	  multibill = isnull(multibill,'') + 'N.'+isnull(convert(varchar(10),@nbill),'') +  ' Importo € '+ isnull(convert(varchar(20),@amountbill),'')+'. '
	 WHERE idinc = @idincbill and nbill is null
		FETCH NEXT FROM cursore 
		INTO @idincbill,  @nbill, @amountbill
	END
CLOSE cursore

DECLARE @dateaddress datetime
SELECT  @dateaddress= CONVERT( datetime, '31-12-'+ CONVERT(varchar(4),@ayear), 105)

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

CREATE TABLE #address
(
	idaddresskind int, idreg int, address varchar(100), location varchar(120),
	cap varchar(20), province varchar(2), nation varchar(65)	
)	

INSERT INTO #address (idreg, idaddresskind, address, location, cap, province, nation)
SELECT 
	registryaddress.idreg, registryaddress.idaddresskind, registryaddress.address,
	isnull(geo_city.title,'')+' '+isnull(registryaddress.location,''),
	registryaddress.cap, geo_country.province, geo_nation.title
FROM registryaddress
left outer join geo_city
	ON geo_city.idcity = registryaddress.idcity
left outer join geo_country
	ON geo_city.idcountry = geo_country.idcountry
left outer join geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE 
	(
	    registryaddress.active <>'N' 
	AND registryaddress.start = 
	(SELECT MAX(cdi.start) 
	FROM registryaddress cdi 
	WHERE cdi.idaddresskind = registryaddress.idaddresskind
	AND cdi.active <>'N' 
	AND ((cdi.stop is null) OR (cdi.stop >= @dateaddress)) 
	and cdi.idreg = registryaddress.idreg))
	AND (idreg IN (select idreg from  #proceeds))
	
DELETE #address
	WHERE #address.idaddresskind <> @stand
	AND EXISTS(
		SELECT * FROM #address r2 
		WHERE #address.idreg = r2.idreg
		AND r2.idaddresskind = @stand
	)
DELETE #address
	WHERE (
		SELECT COUNT(*) FROM #address r2 
		WHERE #address.idreg = r2.idreg
	)>1


INSERT INTO #proceeds
	(
	ypro, npro, npro_treasurer,ymov, nmov, 
	--parentymov,parentnmov,parentdescription, 
	autokind, idreg, detaildescription, detailamount, data,adate, accountkind,kind, rowkind, annulmentdate,
	idstamphandling,flagbankitaliaproceeds,	flag_ccp)
SELECT DISTINCT
	income.ymov, proceeds.npro, proceeds.npro_treasurer, income.ymov, income.nmov, 
	--parentincome.ymov, parentincome.nmov,parentincome.description, 
	income.autokind, income.idreg,
	CASE 
		WHEN payment.npay IS NOT NULL 
		THEN tax.description + ' (a carico percipiente) - mand. n. ' + CONVERT(varchar(6), payment.npay)
		ELSE tax.description + ' (a carico percipiente)'
	END,
	expensetax.employtax, proceeds.printdate, proceeds.adate, 
        case proceeds.flag&8 when 0 then 'I' else 'F' end,
	case proceeds.flag&7 
		when 1 then 'C' 
		when 2 then 'R' 
		when 4 then 'M' 
	end,
	1, proceeds.annulmentdate,
	proceeds.idstamphandling,
	CASE
		WHEN (incomelast.flag&8) <> 0 THEN 'S'
		ELSE 'N'
	END,
	CASE
		WHEN (incomelast.flag&4) <> 0 THEN 'S' --PRELIEVO DA CONTO CORRENTE POSTALE
		ELSE 'N'
	END 
	FROM income
	JOIN incomeyear
		ON incomeyear.idinc = income.idinc
	JOIN incomelast
		ON incomelast.idinc = income.idinc
	--JOIN incomelink
		--ON incomelink.idchild = incomelast.idinc
		--AND incomelink.nlevel = @phasecode
	--JOIN income parentincome
		--ON parentincome.idinc = incomelink.idparent
	JOIN proceeds
		ON proceeds.kpro = incomelast.kpro
	JOIN expensetax
		ON expensetax.idexp = income.idpayment
	JOIN tax
		ON tax.taxcode = expensetax.taxcode
	JOIN expense
		ON expense.idexp = income.idpayment
	JOIN expenselast
		ON expenselast.idexp = expense.idexp
	left outer join payment
		on payment.kpay = expenselast.kpay
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  		ON incometotal_firstyear.idinc = income.idinc
  		AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE income.ymov = @ayear
	AND (income.idreg <> @idreg OR @idreg IS NULL)
		AND expensetax.employtax > 0
		AND expensetax.employtax = incomeyear_starting.amount 
		AND incomeyear.ayear = @ayear
	--AND proceeds.npro  in (select npro from #printing)
	and proceeds.ypro=@ayear and proceeds.idtreasurer=@idtreasurer
	and ( (@printkind='A' and proceeds.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or proceeds.printdate is null) and (proceeds.npro between @startnpro and @stopnpro))
		)


DECLARE @paymentphase	char(1)
SELECT  @paymentphase = MAX(nphase) FROM expensephase



IF @admintaxkind1 <> 4
BEGIN

	INSERT INTO #proceeds
		(
		ypro, npro,npro_treasurer,  ymov, nmov, 
		--parentymov, parentnmov, parentdescription,  
		autokind, idreg, detaildescription, 
		detailamount, data,adate, accountkind,kind, rowkind, annulmentdate,idstamphandling,flagbankitaliaproceeds,
		flag_ccp
	)
	SELECT DISTINCT
		income.ymov, proceeds.npro,proceeds.npro_treasurer, income.ymov, income.nmov, 
		income.autokind, income.idreg,
		CASE
			WHEN payment.npay IS NOT NULL 
			THEN tax.description + ' (a carico amministrazione) - mand. n. ' + CONVERT(varchar(6), payment.npay)
			ELSE tax.description + ' (a carico amministrazione)'
		END,
		expensetax.admintax, proceeds.printdate, proceeds.adate, 
                case proceeds.flag&8 when 0 then 'I' else 'F' end,
		case proceeds.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		1, proceeds.annulmentdate,
		proceeds.idstamphandling,
		CASE
			WHEN (incomelast.flag&8) <> 0 THEN 'S'
		ELSE 'N'
		END,
		CASE
		WHEN (incomelast.flag&4) <> 0 THEN 'S' --PRELIEVO DA CONTO CORRENTE POSTALE
		ELSE 'N'
	END 
	FROM income
	JOIN incomeyear			ON incomeyear.idinc = income.idinc
	JOIN incomelast		ON incomelast.idinc = income.idinc
	JOIN proceeds		ON proceeds.kpro = incomelast.kpro
	JOIN expensetax		ON expensetax.idexp = income.idpayment
	JOIN tax			ON tax.taxcode = expensetax.taxcode 
	JOIN expense		ON expense.idpayment = income.idpayment
							AND expense.autocode = income.autocode
	JOIN expenselast	ON expenselast.idexp = expense.idexp
	left outer join payment		on payment.kpay = expenselast.kpay
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
  						ON incometotal_firstyear.idinc = income.idinc
  							AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
						ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  							AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE income.ymov = @ayear
		AND expensetax.admintax > 0
		AND expensetax.admintax = incomeyear_starting.amount 
		and income.idreg = @idreg	
		AND expense.idreg = @idreg
		AND expense.nphase = @paymentphase
		AND incomeyear.ayear = @ayear
		and expense.ymov = @ayear
			--AND proceeds.npro  in (select npro from #printing)
	and proceeds.ypro=@ayear and proceeds.idtreasurer=@idtreasurer
	and ( (@printkind='A' and proceeds.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or proceeds.printdate is null) and (proceeds.npro between @startnpro and @stopnpro))
		)

END
ELSE
BEGIN

	INSERT INTO #proceeds
		(
		ypro, npro, npro_treasurer, ymov, nmov, 
		--parentymov, parentnmov, parentdescription, 
		autokind, idreg, detaildescription, detailamount,
		data,adate,accountkind,kind, rowkind, annulmentdate,
		idstamphandling,flagbankitaliaproceeds,
		flag_ccp
		)
	SELECT DISTINCT
		income.ymov, proceeds.npro, proceeds.npro_treasurer, income.ymov, income.nmov, 
		--parentincome.ymov, parentincome.nmov,parentincome.description, 
		income.autokind, income.idreg,
		CASE
			WHEN expenselast.kpay IS NOT NULL 
			THEN tax.description + ' (a carico amministrazione) - mand. n. ' + CONVERT(varchar(6), payment.npay)
			ELSE tax.description + ' (a carico amministrazione)'
		END,
		expensetax.admintax, proceeds.printdate, proceeds.adate, 
                case proceeds.flag&8 when 0 then 'I' else 'F' end,
		case proceeds.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		1, proceeds.annulmentdate,
		proceeds.idstamphandling,
		CASE
		WHEN (incomelast.flag&8) <> 0 THEN 'S'
		ELSE 'N'
		END,
		CASE
		WHEN (incomelast.flag&4) <> 0 THEN 'S' --PRELIEVO DA CONTO CORRENTE POSTALE
		ELSE 'N'
	END 
	FROM income
	JOIN incomeyear				ON incomeyear.idinc = income.idinc
	JOIN incomelast				ON incomelast.idinc = income.idinc
	--JOIN incomelink
		--ON incomelink.idchild = incomelast.idinc
		--AND incomelink.nlevel = @phasecode
	--JOIN income parentincome
		--ON parentincome.idinc = incomelink.idparent
	JOIN proceeds				ON proceeds.kpro = incomelast.kpro
	JOIN expensetax				ON expensetax.idexp = income.idpayment
	JOIN tax					ON expensetax.taxcode = tax.taxcode
	JOIN expense				ON expense.idexp = income.idpayment
	JOIN expenselast			ON expenselast.idexp = expense.idexp
	left outer join payment		on payment.kpay = expenselast.kpay
	--LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)  		ON incometotal_firstyear.idinc = income.idinc
  	--												AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK)			ON incomeyear_starting.idinc = income.idinc
  																AND incomeyear_starting.ayear = income.ymov
	WHERE income.ymov = @ayear
		AND (income.idreg <> @idreg OR @idreg IS NULL)
		AND incomeyear.ayear = @ayear
		AND expensetax.admintax > 0
		AND expensetax.admintax = incomeyear_starting.amount 
			and proceeds.ypro=@ayear and proceeds.idtreasurer=@idtreasurer
	and ( (@printkind='A' and proceeds.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or proceeds.printdate is null) and (proceeds.npro between @startnpro and @stopnpro))
		)
END

INSERT INTO #proceeds (ypro, npro, npro_treasurer,  ymov, nmov, 
	--parentymov,parentnmov,parentdescription,
	autokind, idreg, detaildescription, detailamount, data,adate, accountkind, kind, rowkind, annulmentdate,
	idstamphandling	, flagbankitaliaproceeds,
		flag_ccp 
	)
	SELECT DISTINCT
		income.ymov, proceeds.npro, proceeds.npro_treasurer, income.ymov,income.nmov, 
		--parentincome.ymov, parentincome.nmov,parentincome.description, 
		income.autokind, income.idreg,
		CASE
			WHEN payment.npay IS NOT NULL 
			THEN clawback.description + ' (a carico percipiente) - mand. n. ' + CONVERT(varchar(6), payment.npay)
			ELSE clawback.description + ' (a carico percipiente)'
		END,
		expenseclawback.amount, proceeds.printdate, proceeds.adate, 
                case proceeds.flag&8 when 0 then 'I' else 'F' end, 
		case proceeds.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		1, proceeds.annulmentdate,
		proceeds.idstamphandling,
		CASE
		WHEN (incomelast.flag&8) <> 0 THEN 'S'
		ELSE 'N'
		END,
		CASE
		WHEN (incomelast.flag&4) <> 0 THEN 'S' --PRELIEVO DA CONTO CORRENTE POSTALE
		ELSE 'N'
	END 
	FROM income
	JOIN incomeyear				ON incomeyear.idinc = income.idinc
	JOIN incomelast				ON incomelast.idinc = income.idinc
	--JOIN incomelink
		--ON incomelink.idchild = incomelast.idinc
		--AND incomelink.nlevel = @phasecode
	--JOIN income parentincome
		--ON parentincome.idinc = incomelink.idparent
	JOIN proceeds				ON proceeds.kpro = incomelast.kpro
	JOIN expenseclawback		ON expenseclawback.idexp = income.idpayment
		AND expenseclawback.idclawback= income.autocode
	JOIN clawback				ON clawback.idclawback = expenseclawback.idclawback
	JOIN expense				ON expense.idexp = income.idpayment 
	JOIN expenselast			ON expenselast.idexp = expense.idexp
	left outer join payment		on payment.kpay = expenselast.kpay
	--LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
 -- 		ON incometotal_firstyear.idinc = income.idinc
 -- 		AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = income.idinc
  		AND incomeyear_starting.ayear = income.ymov
	WHERE income.ymov = @ayear
		AND incomeyear.ayear = @ayear
		AND expenseclawback.amount > 0
		AND expenseclawback.amount = incomeyear_starting.amount 
		and proceeds.ypro=@ayear and proceeds.idtreasurer=@idtreasurer
	and ( (@printkind='A' and proceeds.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or proceeds.printdate is null) and (proceeds.npro between @startnpro and @stopnpro))
		)


-- per gli automatismi generici e da CSA  riporto il riferimento al PAGAMENTO e al mandato principale 
INSERT INTO #proceeds (ypro, npro, npro_treasurer, ymov, nmov, 
	--parentymov,parentnmov,parentdescription,
	autokind, idreg, detaildescription, detailamount, data,adate,accountkind, kind, rowkind, annulmentdate,
	idstamphandling,flagbankitaliaproceeds,
		flag_ccp 
	)
	SELECT DISTINCT
		income.ymov, proceeds.npro,  proceeds.npro_treasurer, income.ymov,income.nmov, 
		--parentincome.ymov, parentincome.nmov,parentincome.description, 
		income.autokind, income.idreg,
		CASE
			WHEN payment.npay IS NOT NULL 
			THEN @phaseexpense  +   
			     ' eserc. ' + CONVERT(varchar(4), expense.ymov) + ' n. ' + 
			     CONVERT(varchar(6), expense.nmov) +  
			     ' - mand. n. ' + CONVERT(varchar(6), payment.npay)+
			     ': ' + expense.description 
			ELSE @phaseexpense +  
			     ' eserc. ' + CONVERT(varchar(4), expense.ymov) + ' n. ' + 
			     CONVERT(varchar(6), expense.nmov) + 
			     ': ' + expense.description 
		END,
		incometotal_firstyear.curramount, proceeds.printdate, proceeds.adate, 
                case proceeds.flag&8 when 0 then 'I' else 'F' end, 
		case proceeds.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		1, proceeds.annulmentdate,
		proceeds.idstamphandling,
		CASE
		WHEN (incomelast.flag&8) <> 0 THEN 'S'
		ELSE 'N'
		END,
		CASE
		WHEN (incomelast.flag&4) <> 0 THEN 'S' --PRELIEVO DA CONTO CORRENTE POSTALE
		ELSE 'N'
	END 
	FROM income
	JOIN incomeyear					ON incomeyear.idinc = income.idinc
	JOIN incomelast					ON incomelast.idinc = income.idinc
	JOIN proceeds					ON proceeds.kpro = incomelast.kpro
	JOIN expense					ON expense.idexp = income.idpayment 
	JOIN expenselast				ON expenselast.idexp = expense.idexp
	LEFT OUTER JOIN payment			on payment.kpay = expenselast.kpay
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)  		ON incometotal_firstyear.idinc = income.idinc
  							AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
  							AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	WHERE income.ymov = @ayear
		AND incomeyear.ayear = @ayear
		AND isnull(income.autokind,0) IN (14,20,21,30,31) -- automatismo generico o da CSA
		--AND income.autocode is null
		and proceeds.ypro=@ayear and proceeds.idtreasurer=@idtreasurer
	and ( (@printkind='A' and proceeds.printdate is null) OR
		   (@printkind<>'A' and (@oneprint='N' or proceeds.printdate is null) and (proceeds.npro between @startnpro and @stopnpro))
		)

DECLARE @descrlastfase varchar(50)	
SET @descrlastfase = (SELECT description FROM incomephase WHERE nphase = (SELECT MAX(nphase) FROM incomephase))

IF (@official = 'S')
BEGIN
	UPDATE #proceeds
		SET data = @printdate
		WHERE ypro = @ayear
		--AND npro  in (select npro from #printing)
		AND data is null
END


DECLARE @codefin varchar(1)
SELECT 	@codefin = paramvalue FROM reportadditionalparam 
WHERE reportname='reversale_incasso' and paramname='MostraPrimoLivelloOperativo'

IF (@codefin='S')
BEGIN
	DECLARE @nlevel	tinyint
	SELECT  @nlevel = MIN(nlevel) 
		FROM finlevel 
		WHERE ayear=@ayear AND (flag&2)<>0
		
	UPDATE  #proceeds
		SET 	codefin = fin.codefin,
			fintitle = fin.title
		FROM #proceeds	
		JOIN finlink
			ON finlink.idchild = #proceeds.idfin AND finlink.nlevel = @nlevel	
		JOIN fin 
			ON fin.idfin = finlink.idparent
END

SELECT 
	#proceeds.idreg ,
	#proceeds.ymov ,
	#proceeds.nmov ,
	@maxincomephase as maxincomephase,
	#proceeds.parentymov ,
	#proceeds.parentnmov ,
	#proceeds.parentdescription,
	@phasecode as codfaseaccertamento, 
	@phasedescription as faseaccertamento ,
	#proceeds.ypro ,
	#proceeds.npro ,
	#proceeds.npro_treasurer ,
	#proceeds.idinc ,
	#proceeds.doc ,
	#proceeds.docdate ,
	#proceeds.idman ,
	manager.title as manager,	
	#proceeds.description ,
	upb.codeupb ,
	upb.title as titleupb ,
	#proceeds.idupb ,
	--  income -> upb -> fin
	isnull(#proceeds.cupcodeincome, isnull(upb.cupcode, #proceeds.cupcode) )	as cupcode,
	registry.title as registry,
	registry.cf,
	registry.p_iva,
	registry.birthdate,
	isnull(geo_comune1.title, '') + ' ' + isnull(registry.location,'') as birthplace,
	isnull(geo_provincia1.province, '') as birthprovince,
	isnull(geo_nazione1.title, 'Italia') as birthnation,
	#address.address,
	#address.location,
	#address.cap,
	#address.province  as provincia,
	#address.nation,
	#proceeds.ayear,
	CASE
		WHEN finlast.idacc IS NULL  THEN #proceeds.codefin 
		WHEN patrimony.codepatrimony IS NOT NULL THEN CONCAT ('SP: ',patrimony.codepatrimony)
		WHEN placcount.codeplaccount IS NOT NULL THEN CONCAT ('CE: ',placcount.codeplaccount)					
		ELSE #proceeds.codefin 
	END  as codefin,
	CASE
		WHEN finlast.idacc IS NULL THEN #proceeds.fintitle
		ELSE isnull(patrimony.title,placcount.title)
	END  as fintitle,
	CASE
		WHEN finlast.idacc IS NULL THEN #proceeds.nlevel
		ELSE isnull(patrimony.nlevel,placcount.nlevel)
	END  as nlevel,
	#proceeds.amount ,
	treasurerbank.description as treasurerbank,
	treasurercab.description as treasurercab,
	treasurer.address as treasureraddress,
	treasurer.cap as treasurercap,
	treasurer.city as treasurercity,
	treasurer.country as treasurercountry,
	treasurer.cc as treasurercc,
	treasurer.agencycodefortransmission,
	treasurer.header,
 	proceeds.txt  as notes,	
	#proceeds.data ,
	#proceeds.adate ,
	#proceeds.accountkind ,
	#proceeds.kind ,
	#proceeds.flagarrear ,
	#proceeds.rowkind ,
	autokind.code as 'autokind',
	#proceeds.detaildescription ,
	#proceeds.detailamount ,
	#proceeds.annulmentdate ,
	@descrlastfase AS descrlastfase ,
	#proceeds.nbill,
	#proceeds.billadate, 
	#proceeds.multibill,
	stamphandling.description as stamphandling,
	#proceeds.flagbankitaliaproceeds,
	#proceeds.flag_ccp,
	registry.ccp 
FROM #proceeds 
JOIN proceeds			ON proceeds.ypro = #proceeds.ypro	AND proceeds.npro = #proceeds.npro
LEFT OUTER JOIN upb			on upb.idupb = #proceeds.idupb
LEFT OUTER JOIN treasurer	on treasurer.idtreasurer = #proceeds.idtreasurer
LEFT OUTER JOIN manager		ON manager.idman = #proceeds.idman
LEFT OUTER JOIN registry	ON registry.idreg = #proceeds.idreg
LEFT OUTER JOIN bank treasurerbank		ON treasurerbank.idbank = treasurer.idbank
LEFT OUTER JOIN cab treasurercab		ON treasurercab.idbank = treasurer.idbank
									AND treasurercab.idcab = treasurer.idcab
LEFT OUTER JOIN #address			ON #address.idreg = #proceeds.idreg
LEFT OUTER JOIN geo_city geo_comune1		ON geo_comune1.idcity = registry.idcity
LEFT OUTER JOIN geo_country geo_provincia1	ON geo_comune1.idcountry = geo_provincia1.idcountry
LEFT OUTER JOIN geo_nation geo_nazione1		ON geo_nazione1.idnation = registry.idnation
LEFT OUTER JOIN autokind					ON autokind.idautokind = #proceeds.autokind
LEFT OUTER JOIN stamphandling			ON stamphandling.idstamphandling = #proceeds.idstamphandling
LEFT OUTER JOIN finlast
	ON finlast.idfin = #proceeds.idfin
LEFT OUTER JOIN account
	ON finlast.idacc = account.idacc
LEFT OUTER JOIN patrimony
	ON account.idpatrimony = patrimony.idpatrimony
LEFT OUTER JOIN placcount
	ON account.idplaccount = placcount.idplaccount
ORDER BY #proceeds.npro ASC, 
	registry ASC, 
	nmov ASC, 
	rowkind ASC, 
	autokind ASC
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


