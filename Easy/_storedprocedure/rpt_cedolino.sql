
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_cedolino]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_cedolino]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE       PROCEDURE [rpt_cedolino]
	@idreg   int, 
	@ayear	 int,
	@start   datetime,
	@stop    datetime,
	@mode char(1),-- E: anche contributi c/ente, D altrimenti
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
BEGIN

if(@idreg = 0) SET @idreg = null
--exec rpt_cedolino 0, 2015, {ts '2015-01-01 00:00:00'}, {ts '2015-02-26 00:00:00'},'E', NULL, NULL, NULL, NULL, NULL
-- exec rpt_cedolino 29298, 2015, {ts '2015-08-01 00:00:00'}, {ts '2015-08-31 00:00:00'},'E', NULL, NULL, NULL, NULL, NULL
create table #rptcedolino
(
	idreg int, 
	surname770 varchar(50),
	forename770 varchar(50),
	cf varchar(16) NULL,
	birthdate smalldatetime,
	service varchar(50),
	datebegin datetime,
	dateend	datetime,
	duty varchar(150),
	grossamount decimal(19,6),	-- totale dell'importo lordo
	taxablegross decimal(19,6),	-- Valore dell'imponibile Lordo
	taxablenet decimal(19,6),	-- Valore dell'imponibile Netto
	taxdescription varchar(50),	-- Descrizione della ritenuta
	taxablecode varchar(20),	-- Valore del codice dell'imponibile
	taxcode	int , 				 
	tax decimal(19,2),		
	employtaxgross decimal(19,2),	-- Il lordo della ritenuta
	taxable_percent	decimal(19,6),	-- percentuale dell'imponibile della ritenuta
	ritdipversataannua decimal(19,2),
	deduction decimal(19,2),
	feegross decimal(19,2),		-- compenso lordo,compenso competenza
	idpayroll int,
	flagbalance char(1),		-- Applicazione o meno del conguaglio
	idpayrolltax int,
	datebegincontract datetime,
	dateendcontract datetime,
	abatements decimal(19,2),
	nbracket int,
	idcon varchar(8),
	fiscalyear int,
	disbursementdate datetime,
	ypayment int,
	npayment int,
	ncon	varchar(20),
	ycon int,
	iban varchar(50)
)

CREATE TABLE #computetax
(
	idpayroll int,
	idpayrolltax int,
	totimportotax decimal(19,2),    -- importo totale sul cedolino della ritenuta c/precipiente 
	importotax decimal(19,2),       -- importo della ritenuta c/precipiente per singolo scaglione 
	employtaxgross decimal(19,2),	-- Importo lordo della ritenuta
	taxable_percent decimal(19,6),	-- Percentuale dell'importo della ritenua
	deduction decimal(19,2),
	abatements decimal(19,2),
	nbracket int,
	taxcode	int
)
CREATE TABLE #indirizzopagamento
(
	idaddresskind int,
	idreg int,
	address	varchar(100) ,
	geo_city varchar(120),	
	geo_country char(2),		
	cap varchar(20)	
)
 INSERT INTO #rptcedolino
(
	idreg, 
	surname770,
	forename770,
	cf,
	birthdate,
	service,
	datebegin,
	dateend,
	duty,
	grossamount,
	taxablegross,	
	taxablenet,
	taxdescription,	
	taxablecode,
	taxcode,					
	ritdipversataannua,
	feegross,			
	idpayroll,
	flagbalance,
	idpayrolltax,
	datebegincontract,
	dateendcontract,
	abatements,	
	nbracket,
	idcon,
	fiscalyear,
	disbursementdate,
	ncon, ycon
)
SELECT 
	parasubcontract.idreg, 
	registry.surname,
	registry.forename,
	registry.cf,
	registry.birthdate,
	service.description,	
	payroll.start,
	payroll.stop,
	parasubcontract.duty,
	parasubcontract.grossamount,			-->importo lordo totale
	payrolltax.taxablegross,			--> importo lordo del singolo cedolino
	payrolltax.taxablenet,
	tax.description,
	tax.taxablecode,
	tax.taxcode,						
	isnull(payrolltax.annualpayedemploytax,0.0),
	payroll.feegross,				--> compenso lordo competenza
	payroll.idpayroll,	
	payroll.flagbalance,
	payrolltax.idpayrolltax,
	parasubcontract.start,
	parasubcontract.stop,
	payrolltax.abatements,
	payrolltaxbracket.nbracket,
	parasubcontract.idcon,
	payroll.fiscalyear,
	payroll.disbursementdate,
	parasubcontract.ncon, parasubcontract.ycon
from registry
JOIN parasubcontract 
	ON registry.idreg=parasubcontract.idreg
join parasubcontractyear 
	on parasubcontractyear.idcon=parasubcontract.idcon  
JOIN service
	ON service.idser=parasubcontract.idser
JOIN payroll
	ON payroll.idcon=parasubcontract.idcon
LEFT OUTER JOIN payrolltax			-- Facciamo il LEFT OUTER JOIN in modo da prendere anche i cedolini dei Boristi esenti non soggetti a ritenuta.
	ON payrolltax.idpayroll=payroll.idpayroll
	--and payrolltax.employrate>0
	and payrolltax.employtax<>0 --> in questo modo prendiamo anche le riteute con aliquota 0 e importo negativo, vedi arretrati Addizionale Regionale da CAF o IRPEF da dichiarazione C.A.F.
LEFT OUTER JOIN tax
	ON tax.taxcode = payrolltax.taxcode
LEFT OUTER JOIN payrolltaxbracket		
	on payrolltaxbracket.idpayroll = payrolltax.idpayroll
	AND payrolltaxbracket.idpayrolltax = payrolltax.idpayrolltax
	and ( payrolltaxbracket.employrate>0	--> aliquota dip. > 0
		or tax.taxkind=5 and payrolltaxbracket.employtax<>0	 --> trattasi di Arretrati
		or tax.taxablecode in('BONUSFISCALE','ADDIRPEF')	 --> Bonus renzi
		)
	--AND isnull(payrolltaxbracket.employtax,0)<>0
WHERE	(registry.idreg=@idreg OR @idreg is null)
	AND parasubcontractyear.ayear=@ayear
	AND (payroll.start>=@start AND payroll.stop<=@stop)
	AND (payroll.fiscalyear=@ayear)	
	AND payroll.flagbalance<>'S'
	AND isnull(payroll.flagcomputed,'N'	)='S'	-- Prendiamo SOLO i cedolini calcolati.
	AND (@idsor01 IS NULL OR parasubcontract.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR parasubcontract.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR parasubcontract.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR parasubcontract.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR parasubcontract.idsor05 = @idsor05)


INSERT INTO #computetax
(
	idpayroll ,
	idpayrolltax,
	totimportotax,
	importotax,
	employtaxgross,
	taxable_percent,
	deduction,
	abatements,	-- detrazioni
	nbracket,
	taxcode
)
SELECT 
	payrolltaxbracket.idpayroll,
	payrolltaxbracket.idpayrolltax,
	payrolltax.employtax,
	payrolltaxbracket.employtax,  
	payrolltax.employtaxgross,
	case when isnull(payrolltaxbracket.taxable,0.0)=0 then 0
	     else round(isnull(payrolltaxbracket.employtax,0.0)/payrolltaxbracket.taxable,6)*100
	end,
	payrolltax.deduction,
	payrolltax.abatements,
	payrolltaxbracket.nbracket,
	payrolltax.taxcode
FROM payrolltax
join payroll
	on payrolltax.idpayroll=payroll.idpayroll
join payrolltaxbracket		
	on payrolltaxbracket.idpayroll = payrolltax.idpayroll
	and payrolltaxbracket.idpayrolltax = payrolltax.idpayrolltax

JOIN parasubcontract 
	ON payroll.idcon=parasubcontract.idcon
JOIN registry
	ON registry.idreg=parasubcontract.idreg
join parasubcontractyear 
	on parasubcontractyear.idcon=parasubcontract.idcon  
JOIN tax
	ON tax.taxcode = payrolltax.taxcode
where payroll.flagbalance<>'S'-- and isnull(payrolltaxbracket.employtax,0)<>0
	AND (payroll.start>=@start AND payroll.stop<=@stop)	
	AND (payroll.fiscalyear=@ayear)		
	and (payrolltaxbracket.employrate>0	--> aliquota dip. > 0
		or tax.taxkind=5 and payrolltaxbracket.employtax<>0	 --> trattasi di arretrati
		or tax.taxablecode in('BONUSFISCALE','ADDIRPEF')
		)
	and (registry.idreg=@idreg OR @idreg is null)
	AND parasubcontractyear.ayear=@ayear
	AND isnull(payroll.flagcomputed,'N'	)='S'	-- Prendiamo SOLO i cedolini calcolati.
	AND (@idsor01 IS NULL OR parasubcontract.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR parasubcontract.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR parasubcontract.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR parasubcontract.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR parasubcontract.idsor05 = @idsor05)



UPDATE #rptcedolino SET	
	tax= ISNULL((
		SELECT #computetax.importotax  
		FROM  #computetax
		WHERE  #computetax.idpayroll=#rptcedolino.idpayroll
			AND #computetax.idpayrolltax=#rptcedolino.idpayrolltax
			AND #computetax.nbracket=#rptcedolino.nbracket),0.0),
	
	employtaxgross= ISNULL((
		SELECT  #computetax.employtaxgross  
		FROM  #computetax
		WHERE  #computetax.idpayroll=#rptcedolino.idpayroll
			AND #computetax.idpayrolltax=#rptcedolino.idpayrolltax
			AND #computetax.nbracket=#rptcedolino.nbracket),0.0),
	taxable_percent=ISNULL((
		SELECT   #computetax.taxable_percent
		FROM #computetax
		WHERE  #computetax.idpayroll=#rptcedolino.idpayroll
			AND #computetax.idpayrolltax=#rptcedolino.idpayrolltax
			AND #computetax.nbracket=#rptcedolino.nbracket),0.0),
	deduction=ISNULL((
		SELECT   #computetax.deduction
		FROM #computetax
		WHERE  #computetax.idpayroll=#rptcedolino.idpayroll
			AND #computetax.idpayrolltax=#rptcedolino.idpayrolltax
			AND #computetax.nbracket=#rptcedolino.nbracket),0.0)

-- per le ritenute 'IRPEF' e le addizionali su 1 o più scaglioni prendo 
-- l'importo totale e non i singoli scaglioni
-- Laddove ci sono più scaglioni non visualizzo l'aliquota perchè non ha senso. 2° UPDATE
UPDATE  #rptcedolino 
SET  	tax =  ISNULL((
		SELECT #computetax.totimportotax  
		FROM   #computetax
		WHERE  #computetax.idpayroll=#rptcedolino.idpayroll
			AND #computetax.taxcode=#rptcedolino.taxcode
			AND #computetax.idpayrolltax=#rptcedolino.idpayrolltax
			AND #computetax.nbracket=#rptcedolino.nbracket),0.0)
WHERE   taxablecode IN ('IRPEF','ADDIRPEF')

UPDATE  #rptcedolino 
SET     taxable_percent = 0
WHERE   taxablecode IN ('IRPEF','ADDIRPEF')
AND     (SELECT count(*) 
		FROM  #rptcedolino R1 
		WHERE 
		 #rptcedolino.idpayroll  = R1.idpayroll AND
		 #rptcedolino.taxcode  = R1.taxcode AND	
		 #rptcedolino.idpayrolltax  = R1.idpayrolltax) >1

-- Per la ritenuta IRPEF mi serve solo una riga ,il valore di ta l'ho preso sopra
delete from #rptcedolino where (taxablecode IN('IRPEF','ADDIRPEF') and nbracket>1)

UPDATE #rptcedolino SET	
	tax= ISNULL((SELECT sum(isnull(i.tax,0) )
		FROM #rptcedolino as i 
		WHERE  i.idpayroll=#rptcedolino.idpayroll
			AND i.idpayrolltax=#rptcedolino.idpayrolltax
			AND i.taxablecode='IRPEF'),0.0)
	WHERE taxablecode='IRPEF'
UPDATE #rptcedolino SET	
	tax= ISNULL((SELECT sum(isnull(i.tax,0) )
		FROM #rptcedolino as i 
		WHERE  i.idpayroll=#rptcedolino.idpayroll
			AND i.idpayrolltax=#rptcedolino.idpayrolltax
			AND i.taxablecode='ADDIRPEF'),0.0)
	WHERE taxablecode='ADDIRPEF'

	

UPDATE #rptcedolino SET ypayment= payment.ypay, npayment = payment.npay, iban = expenselast.iban
				from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild
				join payment on payment.kpay=expenselast.kpay
    WHERE #rptcedolino.idpayroll = payroll.idpayroll


INSERT INTO #indirizzopagamento
(	idaddresskind,
	idreg	,
	address	,
	geo_city	,	
	geo_country	,		
	cap	)
SELECT
	idaddresskind,
	idreg, 
	registryaddress.address,
	case 
		when flagforeign = 'S' then isnull(geo_nation.title,'')+' '+isnull(registryaddress.location,'')
		else
		geo_city.title
	end,
	case
		when flagforeign = 'S' then ' '
		else
		geo_country.province
		end,	
	case	
		when flagforeign = 'S' then ' '
		else
		registryaddress.cap
	end
FROM registryaddress
left outer join geo_city
	ON geo_city.idcity = registryaddress.idcity
left outer join geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE 
	( registryaddress.active <>'N' 
	AND registryaddress.start = 
			(SELECT MAX(cdi.start) 
			FROM registryaddress cdi 
			WHERE cdi.idaddresskind = registryaddress.idaddresskind
			AND cdi.active <>'N' 
			AND ((cdi.stop is null) OR (cdi.stop >= @start)) 
			and cdi.idreg = registryaddress.idreg))
	AND (idreg IN (select idreg from  #rptcedolino))

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_CER'

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF'

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

delete #indirizzopagamento
	where #indirizzopagamento.idaddresskind <> @nostand
	and exists (
		select * from #indirizzopagamento r2 
		where #indirizzopagamento.idreg=r2.idreg
		and r2.idaddresskind = @nostand
	)

delete #indirizzopagamento
	where #indirizzopagamento.idaddresskind not in (@nostand, @stand)
	and exists (
		select * from #indirizzopagamento r2 
		where #indirizzopagamento.idreg=r2.idreg
		and r2.idaddresskind = @stand
	)
delete #indirizzopagamento
	where (
		select count(*) from #indirizzopagamento r2 
		where #indirizzopagamento.idreg=r2.idreg
	)>1

-- Cancello quelle righe per cui 'taxcode' è valorizzato ma l'importo della ritenuta è zero. Faccio la delete perchè in seguito all'introduzione del
-- LEFT OUTER JOIN nella SELECT principale potrei avere anche l'IRAP tra le ritenute.

-- Questa delete non la facciamo più, perchè consideriamo le rit c/dip in base all'aliquita, e non più in base all'importo. Vedi task 5432
-- DELETE FROM #rptcedolino where taxablecode is not null and isnull(tax,0) = 0

SELECT  
	C.idreg	,
	surname770	,
	forename770	,
	cf	,
	birthdate	,
	I.address	,
	I.geo_city	,
	I.geo_country	,	
	I.cap	,		
	service ,
	datebegin	,
	dateend	,
	duty	,
	grossamount	,
	taxablegross	,
	taxablenet,
	taxdescription ,
	taxablecode ,
	taxcode	,				
	tax	,	
	employtaxgross ,
	taxable_percent	,
	ritdipversataannua ,
	deduction	,
	feegross	,
	idpayroll	,
	flagbalance ,
	idpayrolltax	,
	datebegincontract	,
	dateendcontract ,
	nbracket,
	fiscalyear,
	disbursementdate,
	ypayment,
	npayment,
	C.ncon, C.ycon,
	C.iban
FROM  #rptcedolino C
LEFT OUTER JOIN #indirizzopagamento I
	ON C.idreg = I.idreg
ORDER BY idpayroll,idpayrolltax 

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

