
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_subcedolino_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_subcedolino_ente]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE       PROCEDURE [rpt_subcedolino_ente]
	@mode char(1),-- E: anche contributi c/ente, D altrimenti
	@idpayroll int
AS
BEGIN

create table #rptcedolino
(
	idreg int, 
	grossamount decimal(19,6),	-- totale dell'importo lordo
	taxablegross decimal(19,6),	-- Valore dell'imponibile Lordo
	taxablenet decimal(19,6),	-- Valore dell'imponibile Netto
	taxdescription varchar(50),	-- Descrizione della ritenuta
	taxablecode varchar(20),	-- Valore del codice dell'imponibile
	taxcode	int , 				 
	tax decimal(19,2),		
	--employtaxgross decimal(19,2),	-- Il lordo della ritenuta
	taxable_percent	decimal(19,6),	-- percentuale dell'imponibile della ritenuta
	deduction decimal(19,2),
	feegross decimal(19,2),		-- compenso lordo,compenso competenza
	idpayroll int,
	flagbalance char(1),		-- Applicazione o meno del conguaglio
	idpayrolltax int,
	datebegincontract datetime,
	dateendcontract datetime,
	abatements decimal(19,2),
	nbracket int,
	idcon varchar(8)
)

CREATE TABLE #computetax
(
	idpayroll int,
	idpayrolltax int,
	totimportotax decimal(19,2),    -- importo totale sul cedolino della ritenuta c/precipiente 
	importotax decimal(19,2),       -- importo della ritenuta c/precipiente per singolo scaglione 
	--employtaxgross decimal(19,2),	-- Importo lordo della ritenuta
	taxable_percent decimal(19,6),	-- Percentuale dell'importo della ritenua
	deduction decimal(19,2),
	abatements decimal(19,2),
	nbracket int,
	taxcode	int
)

if(@mode<>'E')
Begin
	SELECT  
		null as idreg	,
		null as grossamount	,
		null as taxablegross	,
		null as taxablenet,
		null as taxdescription ,
		null as taxablecode ,
		null as taxcode	,				
		null as tax	,	
	--	employtaxgross ,
		null as taxable_percent	,
	--	ritdipversataannua ,
		null as deduction	,
		null as feegross	,
		null as idpayroll	,
		null as flagbalance ,
		null as idpayrolltax	,
		null as datebegincontract	,
		null as dateendcontract ,
		null as nbracket
	FROM  #rptcedolino 
	RETURN

end


	INSERT INTO #rptcedolino(
		idreg, 
		grossamount,
		taxablegross,	
		taxablenet,
		taxdescription,	
		taxablecode,
		taxcode,					
		feegross,			
		idpayroll,
		flagbalance,
		idpayrolltax,
		datebegincontract,
		dateendcontract,
		abatements,	
		nbracket,
		idcon
	)
	SELECT 
		parasubcontract.idreg, 
		parasubcontract.grossamount,			-->importo lordo totale
		payrolltax.taxablegross,			--> importo lordo del singolo cedolino
		payrolltax.taxablenet,
		tax.description,
		tax.taxablecode,
		tax.taxcode,	
		payroll.feegross,				--> compenso lordo competenza
		payroll.idpayroll,	
		payroll.flagbalance,
		payrolltax.idpayrolltax,
		parasubcontract.start,
		parasubcontract.stop,
		payrolltax.abatements,
		payrolltaxbracket.nbracket,
		parasubcontract.idcon
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
		and payrolltax.adminrate>0
	LEFT OUTER JOIN tax
		ON tax.taxcode = payrolltax.taxcode
	LEFT OUTER JOIN payrolltaxbracket		
		on payrolltaxbracket.idpayroll = payrolltax.idpayroll
		AND payrolltaxbracket.idpayrolltax = payrolltax.idpayrolltax
		and payrolltaxbracket.adminrate>0	--> aliquota Amm. > 0
		--AND isnull(payrolltaxbracket.employtax,0)<>0
	WHERE payroll.idpayroll = @idpayroll
		AND (payroll.fiscalyear=parasubcontractyear.ayear)	
		
	INSERT INTO #computetax
	(
		idpayroll ,
		idpayrolltax,
		totimportotax,
		importotax,
		--employtaxgross,
		taxable_percent,
		deduction,
		abatements,	-- detrazioni
		nbracket,
		taxcode
	)
	SELECT 
		payrolltaxbracket.idpayroll,
		payrolltaxbracket.idpayrolltax,
		payrolltax.admintax,
		payrolltaxbracket.admintax,  
		--payrolltax.employtaxgross,
		case when isnull(payrolltaxbracket.taxable,0.0)=0 then 0
			 else round(isnull(payrolltaxbracket.admintax,0.0)/payrolltaxbracket.taxable,6)*100
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
	 WHERE payroll.idpayroll = @idpayroll
	 AND (payroll.fiscalyear=parasubcontractyear.ayear)	

	UPDATE #rptcedolino SET	
		tax= ISNULL((
			SELECT #computetax.importotax  
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



	SELECT  
		C.idreg	,
		grossamount	,
		taxablegross	,
		taxablenet,
		taxdescription ,
		taxablecode ,
		taxcode	,				
		tax	,	
	--	employtaxgross ,
		taxable_percent	,
	--	ritdipversataannua ,
		deduction	,
		C.feegross	,
		C.idpayroll	,
		C.flagbalance ,
		idpayrolltax	,
		datebegincontract	,
		dateendcontract ,
		nbracket
	FROM  #rptcedolino C
	ORDER BY idpayroll,idpayrolltax 

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

