
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_trasm_reversale_incasso]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_trasm_reversale_incasso]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- rpt_trasm_reversale_incasso 2013, 1,7
CREATE  PROCEDURE [rpt_trasm_reversale_incasso]
	@ayear	integer,
	@nproceedstransmission	integer,
	@idtreasurer int
AS BEGIN
	
DECLARE @transmissionkind char(1)
SELECT @transmissionkind = transmissionkind FROM proceedstransmission
WHERE proceedstransmission.yproceedstransmission = @ayear
	AND proceedstransmission.nproceedstransmission = @nproceedstransmission

	CREATE TABLE #proceedstransmission
	(
		ydoc				int		,
		ndoc				int		,
		adate				datetime	,
		printdate			datetime	,
		kind				char(1)		,
		yproceedstransmission		int		,
		nproceedstransmission		int		,
		idreg				int		,
		title				varchar(200)	,
		idman      			int		,
		manager				varchar(150)	,
		description			varchar(250)	,
		idtreasurer			int	,
		amount				decimal(19,2)	,
		curramount			decimal(19,2)	,
		totvarannulment decimal(19,2),	
		varannulment_at_date decimal(19,2),	
		treasurerbank			varchar(150)	,
		treasurercab			varchar(50)	,
		treasureraddress		varchar(50)	,
		treasurercap			varchar(5)	,
		treasurercity			varchar(50)	,
		treasurercountry		varchar(2)	,
		treasurercc			varchar(30)	,
		agencycodefortransmission	varchar(20) 	,	
		transmissiondate		datetime	,
		idinc				int		,
		fulfilled			char(1) 	
	)
	
	IF 	@ayear=0 SET @ayear=1900
	
	DECLARE @displayalreadysent	char(1)

	SELECT 	@displayalreadysent = ISNULL(paramvalue ,'N')
	FROM 	reportadditionalparam
	WHERE 	reportname = 'trasm_reversale_incasso'
	AND 	paramname  = 'MostraMovGiaTrasmessi'
	
	DECLARE @displayalreadysent_all	char(1)
	SELECT  @displayalreadysent_all = ISNULL(paramvalue ,'N')
	FROM 	reportadditionalparam
	WHERE 	reportname = 'trasm_reversale_incasso'
	AND 	paramname  = 'MostraTotaliAltriTesorieri'

	INSERT INTO #proceedstransmission
	(
		ydoc,
		ndoc,
		adate,
		printdate,
		kind,
		yproceedstransmission,
		nproceedstransmission,
		idreg,
		idman,
		description,
		amount,
		idtreasurer,
		transmissiondate,
		idinc,
		fulfilled
	)
	SELECT 
	proceeds.ypro,
	proceeds.npro,
	proceeds.adate,
	proceeds.printdate,
	case proceeds.flag&7 
  		when 1 then 'C' 
  		when 2 then 'R' 
 		when 4 then 'M' 
	end,
	proceedstransmission.yproceedstransmission,
	proceedstransmission.nproceedstransmission,
	income.idreg,
	proceedstransmission.idman,
	case isnull(income.doc,'') WHEN '' THEN income.description 
	ELSE income.description + ' Incassato con Doc. ' + income.doc
	END,
	isnull(incometotal.curramount,0.0),
	proceeds.idtreasurer,
	proceedstransmission.transmissiondate,
	income.idinc,
	CASE
		WHEN ((incomelast.flag)&1) = 0 THEN 'N'
		WHEN ((incomelast.flag)&1) = 1 THEN 'S'
	END
	--income.fulfilled
	FROM income 
	JOIN incomelast 
		on incomelast.idinc = income.idinc
	JOIN incometotal  
		on incometotal.idinc = income.idinc and incometotal.ayear=@ayear
	JOIN proceeds
		ON incomelast.kpro = proceeds.kpro
	JOIN proceedstransmission
		ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission
	WHERE 	proceedstransmission.yproceedstransmission = @ayear
		AND proceedstransmission.nproceedstransmission = @nproceedstransmission
	AND (((incomelast.flag&1) = 0) or  @displayalreadysent = 'S' )
	and @transmissionkind = 'I' 
	and proceedstransmission.idtreasurer = @idtreasurer

-- Partendo dalla distinta di tipo 'V', risale alla reversale
	
	INSERT INTO #proceedstransmission
	(
		ydoc,
		ndoc,
		adate,
		printdate,
		kind,
		yproceedstransmission,
		nproceedstransmission,
		idreg,
		idman,
		description,
		amount,
		idtreasurer,
		transmissiondate,
		idinc,
		fulfilled
	)
	SELECT 
	proceeds.ypro,
	proceeds.npro,
	proceeds.adate,
	proceeds.printdate,
	case proceeds.flag&7 
  		when 1 then 'C' 
  		when 2 then 'R' 
 		when 4 then 'M' 
	end,
	proceedstransmission.yproceedstransmission,
	proceedstransmission.nproceedstransmission,
	income.idreg,
	proceedstransmission.idman,
	case isnull(income.doc,'') WHEN '' THEN income.description 
	ELSE income.description + ' Incassato con Doc. ' + income.doc
	END,
	0,-- isnull(incometotal.curramount,0.0),	Per le variazioni non inseriamo l'importo.
	proceeds.idtreasurer,
	proceedstransmission.transmissiondate,
	income.idinc,
	CASE
		WHEN ((incomelast.flag)&1) = 0 THEN 'N'
		WHEN ((incomelast.flag)&1) = 1 THEN 'S'
	END
	--income.fulfilled
	FROM incomevar
	JOIN income 
		on incomevar.idinc = income.idinc
	JOIN incomelast 
		on incomelast.idinc = income.idinc
	JOIN incometotal  
		on incometotal.idinc = income.idinc and incometotal.ayear=@ayear
	JOIN proceeds
		ON incomelast.kpro = proceeds.kpro
	JOIN proceedstransmission
		ON incomevar.kproceedstransmission = proceedstransmission.kproceedstransmission
	WHERE 	proceedstransmission.yproceedstransmission = @ayear
		AND proceedstransmission.nproceedstransmission = @nproceedstransmission
		AND (((incomelast.flag&1) = 0) or  @displayalreadysent = 'S' )
		AND @transmissionkind = 'V' 
		and proceedstransmission.idtreasurer = @idtreasurer
		
	UPDATE  #proceedstransmission 
	SET		totvarannulment = ISNULL(incomevar.amount, 0.0)
	FROM 	incomevar
	WHERE 	ISNULL(incomevar.autokind,0) IN (10,11) -- annullamento parziale o totale
	AND		incomevar.idinc = #proceedstransmission.idinc	
	AND @transmissionkind = 'I' 

	UPDATE  #proceedstransmission 
	SET		varannulment_at_date = ISNULL(incomevar.amount, 0.0)
	FROM 	incomevar
	WHERE 	ISNULL(incomevar.autokind,0) IN (10,11) -- annullamento parziale o totale
	AND		incomevar.idinc = #proceedstransmission.idinc	
	AND		incomevar.adate <= #proceedstransmission.transmissiondate
	AND @transmissionkind = 'I' 
		
	--SELECT * FROM #proceedstransmission 
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

	DECLARE @codestand varchar(20)
	SET @codestand = '07_SW_DEF'
	
	DECLARE @STAND int
	SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand
	
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
		AND registryaddress.idreg in (select idreg FROM #proceedstransmission))
	DELETE #registryaddress
		WHERE #registryaddress.idaddresskind <> @stand
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

SELECT  @transmissiondate = ISNULL((SELECT  transmissiondate FROM proceedstransmission
									WHERE proceedstransmission.yproceedstransmission = @ayear
									AND proceedstransmission.nproceedstransmission = @nproceedstransmission),GetDate())
print   @transmissiondate 

-- Toltale elenchi precedenti
SELECT 	@amount = 	ISNULL(SUM(IT_firstyear.curramount),0.0)
FROM 	income
JOIN 	incomelast 
ON 	incomelast.idinc = income.idinc
JOIN incometotal IT_firstyear
  	ON IT_firstyear.idinc = income.idinc 
	AND ((IT_firstyear.flag & 2) <> 0 )
JOIN incomeyear IY_starting
	ON IY_starting.idinc = IT_firstyear.idinc
  	AND IY_starting.ayear = IT_firstyear.ayear
JOIN  	proceeds
	ON  incomelast.kpro = proceeds.kpro
join proceedstransmission 
	ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
WHERE 	IT_firstyear.ayear = @ayear
	AND proceedstransmission.yproceedstransmission  = @ayear
	AND proceedstransmission.nproceedstransmission < @nproceedstransmission
	AND 
	(
	(proceedstransmission.idtreasurer=@idtreasurer AND @displayalreadysent_all = 'N')
		OR
	(@displayalreadysent_all = 'S')
	)

-- Totale elenchi precedenti = @amount - @totvarannulment = curramountgross
SELECT 	@totvarannulment = ISNULL(SUM(incomevar.amount), 0.0)
FROM 	income
JOIN 	incomelast 
ON 	incomelast.idinc = income.idinc
JOIN    incomevar
	ON incomevar.idinc = income.idinc
JOIN 	proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN 	proceedstransmission
	ON proceeds.kproceedstransmission= proceedstransmission.kproceedstransmission
WHERE ISNULL(incomevar.autokind,0) IN (10,11) -- annullamento parziale o totale 	
	AND proceedstransmission.yproceedstransmission  = @ayear
	AND proceedstransmission.nproceedstransmission < @nproceedstransmission
	AND 
	(
	(proceedstransmission.idtreasurer=@idtreasurer AND @displayalreadysent_all = 'N')
		OR
	(@displayalreadysent_all = 'S')
	)


-- Totale Variazioni
SELECT 	@varannulment_at_date = ISNULL(SUM(incomevar.amount), 0.0)
FROM 	income
JOIN 	incomelast 
ON 	incomelast.idinc = income.idinc
JOIN    incomevar
	ON incomevar.idinc = income.idinc
JOIN 	proceeds
	ON proceeds.kpro = incomelast.kpro
JOIN 	proceedstransmission
	ON proceeds.kproceedstransmission= proceedstransmission.kproceedstransmission
WHERE 	ISNULL(incomevar.autokind,0) IN (10,11) -- annullamento parziale o totale 	
	AND incomevar.adate <= @transmissiondate
	AND proceedstransmission.yproceedstransmission  = @ayear
	AND proceedstransmission.nproceedstransmission < @nproceedstransmission
	AND 
	(
	(proceedstransmission.idtreasurer=@idtreasurer AND @displayalreadysent_all = 'N')
		OR
	(@displayalreadysent_all = 'S')
	)

-- all'importo corrente dei movimenti finanziari al netto delle variazioni di annullamento 
-- (quindi includendo le altre variazioni) sommo le variazioni di annullamento che rientrano nel range di date
-- allo scopo di preservare la storicità della stampa

print   @amount
PRINT   @totvarannulment
PRINT   @varannulment_at_date

SELECT  @curramount = @amount - @totvarannulment +  @varannulment_at_date
print @curramount

SELECT  #proceedstransmission.ydoc				,
	#proceedstransmission.ndoc				,
	#proceedstransmission.adate				,
	#proceedstransmission.printdate				,
	#proceedstransmission.kind				,
	#proceedstransmission.yproceedstransmission		,
	#proceedstransmission.nproceedstransmission		,
	@amount - @totvarannulment 				    'curramountgross',
	@varannulment_at_date  'variation',
	REG.idreg						,
	REG.title 						,
	#proceedstransmission.idman				,
	R.title 				       'manager',   
	#registryaddress.address 				,
	#registryaddress.location 				,
	#registryaddress.cap 					,
	#registryaddress.province				,
	#registryaddress.geo_nation				,
	REG.cf 							,	
	REG.p_iva						,
	#proceedstransmission.description			,
	sum(#proceedstransmission.amount) - isnull(sum(totvarannulment),0) + isnull(sum(varannulment_at_date),0) 'amount',
	ABI.description  			 'treasurerbank',
	cab.description       			 'treasurercab'	,
	T.address  			     'treasureraddress'	,
	T.cap  					  'treasurercap',
	T.city                                   'treasurercity',
	T.country  			      'treasurercountry',
	T.cc 					   'treasurercc',
	T.agencycodefortransmission				,
	#proceedstransmission.transmissiondate			,	
	#proceedstransmission.idinc				,
	#proceedstransmission.fulfilled		,
	T.header	
FROM #proceedstransmission
	LEFT OUTER JOIN registry REG
		ON REG.idreg = #proceedstransmission.idreg
	LEFT OUTER JOIN manager R
		ON R.idman = #proceedstransmission.idman 
	LEFT OUTER JOIN treasurer T
		ON T.idtreasurer = #proceedstransmission.idtreasurer
	LEFT OUTER JOIN bank ABI
		ON ABI.idbank = T.idbank
	LEFT OUTER JOIN cab
		ON cab.idbank = T.idbank
		AND cab.idcab = T.idcab
	LEFT OUTER JOIN #registryaddress
		ON #registryaddress.idreg = #proceedstransmission.idreg
GROUP by idinc,REG.idreg,REG.title,R.title,ABI.description, 
	CAB.description, ydoc,ndoc,adate,printdate,#proceedstransmission.kind,
	yproceedstransmission, nproceedstransmission,curramount,
	#proceedstransmission.title,#proceedstransmission.idman,
	manager,#registryaddress.address,#registryaddress.location,
	#registryaddress.cap,province,geo_nation,cf,p_iva,
	#proceedstransmission.description,treasurerbank,
	treasurercab,T.address,T.cap,
	T.city,t.country,t.cc,
	T.agencycodefortransmission,
	transmissiondate,fulfilled, T.header	
ORDER BY ydoc, ndoc
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
