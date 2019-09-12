--setuser 'amm'inistrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_assimilatidip_coniuge]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_assimilatidip_coniuge]
GO
 
--exec [exp_certificazioneunica_assimilatidip_coniuge]   2016
CREATE PROCEDURE [exp_certificazioneunica_assimilatidip_coniuge]
(
	@annodichiarazione int
)
-- estraggo l'elenco dei percipienti, assimilati dipendenti, che hanno eseguito prestazioni mappate con il Record G
-- con l'indicazione del coniuge su ciascun contratto
 
AS BEGIN
	--declare @annodichiarazione int
	--set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1 
 	
	-- Ricordarsi di cambiare ogni anno l'anno delle date
	declare @1gen15  datetime
	set @1gen15 = dateadd(yy, @annoredditi-2000, {d '2000-01-01'})
	
	declare @31dic15 datetime
	set @31dic15 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})


	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #prestazioni_trasmesse
	(
		idcon  varchar(8),
		padre  varchar(8),
		capofila char(1),
		ycon  int,
		ncon int,
		duty varchar(400),
		feegross decimal(19,2),
		idreg int,
		idser int,
		motive770 varchar(10)
	)

	----------------------------------------------------------
    --- Estrazione dati relativi ai percipienti autonomi ----
    ----------------------------------------------------------
    
	INSERT INTO #prestazioni_trasmesse
		(
			idcon,
			ycon,
			ncon,
			duty,
			feegross,
			idreg, 
			idser
		)
	SELECT   co.idcon, co.ycon, co.ncon, co.duty, ce.feegross, co.idreg,  co.idser      
	FROM payroll ce 
		JOIN parasubcontract co ON co.idcon = ce.idcon
                JOIN parasubcontractyear im ON co.idcon = im.idcon AND im.ayear = @annoredditi
		JOIN service ON service.idser = co.idser
		JOIN registry ON registry.idreg = co.idreg
	WHERE ce.flagbalance = 'S'
		AND ce.fiscalyear=@annoredditi
		AND NOT EXISTS (SELECT idlinkedcon from exhibitedcud where idlinkedcon = ce.idcon and fiscalyear = @annoredditi)
		AND EXISTS (SELECT payroll.idpayroll from payroll 
				join expensepayroll on payroll.idpayroll = expensepayroll.idpayroll
				join expenselink ON expenselink.idparent = expensepayroll.idexp
				join expenselast on expenselast.idexp = expenselink.idchild--expense.idexp
				join payment on payment.kpay=expenselast.kpay
				where payroll.idcon = co.idcon and payment.kpaymenttransmission is not null
				AND payroll.fiscalyear = @annoredditi)
		AND service.rec770kind='G'
		AND ce.disbursementdate is not null
		AND (registry.cf IS  NOT NULL) 
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
		
	UPDATE #prestazioni_trasmesse
	SET padre = exhibitedcud.idcon
	FROM exhibitedcud
	WHERE exhibitedcud.idlinkedcon = #prestazioni_trasmesse.idcon
		AND exhibitedcud.fiscalyear = @annoredditi
	
	
	UPDATE #prestazioni_trasmesse
	SET capofila = 'S'
	WHERE idcon = (SELECT TOP 1 idcon FROM #prestazioni_trasmesse A WHERE padre IS NULL AND A.idreg = #prestazioni_trasmesse.idreg)

	CREATE TABLE #coniugi
		(
			idcon varchar(8),
			idfamily int,
			birthdate datetime,
			idaffinity char(1),
			startapplication datetime,
			stopapplication datetime,
			cf varchar(16),
			flagdependent char(1)
		)
		
	INSERT INTO #coniugi
	(
			idcon,
			idfamily,
			birthdate, 
			idaffinity,
			startapplication,
			stopapplication,
			cf,
			flagdependent
		)
	SELECT
		F.idcon,
		F.idfamily, F.birthdate, F.idaffinity,
		ISNULL(F.startapplication, @1gen15),
		ISNULL(F.stopapplication, @31dic15),
		ISNULL(F.cf, ''),
		F.flagdependent 
	FROM parasubcontractfamily F
	JOIN #prestazioni_trasmesse
		ON #prestazioni_trasmesse.idcon = F.idcon
	WHERE ayear = @annoredditi
	AND (F.startapplication is null or year(F.startapplication)<=@annoredditi)
	AND (F.stopapplication is null or year(F.stopapplication)>=@annoredditi)
	--AND (F.flagdependent is null or F.flagdependent = 'S')  
	AND (F.idaffinity = 'C')	
	
	update #prestazioni_trasmesse set motive770 = motive770service.exemptioncode
		from motive770service 
		where motive770service.idser = #prestazioni_trasmesse.idser
		AND motive770service.ayear = @annoredditi-1
		
		--select * from #coniugi
	SELECT 
		registry.idreg		as '#Cod. Anagrafica',
		ltrim(rtrim(registry.title))		as 'Percipiente',
		registry.cf			as 'Codice Fiscale',
		registry.p_iva		as 'Partita IVA',
		registry.foreigncf	as 'Codice Fiscale Estero',
		#prestazioni_trasmesse.ycon as 'Eserc. Contratto',
		#prestazioni_trasmesse.ncon as 'Num. Contratto',
		ltrim(rtrim(#prestazioni_trasmesse.duty)) as 'Mansione',
		#prestazioni_trasmesse.feegross as 'Compenso lordo',
		--service.idser		as '#idser',
		ltrim(rtrim(isnull(service.servicecode770,service.codeser)	+ '	' + service.description))  	as 'Codice Prestazione',
		mod770_exemptioncode.exemptioncode		as 'Codice Causale Esenzione',
		--substring(ltrim(rtrim(mod770_exemptioncode.description)),1,200) as ' Descr. Causale'
		#coniugi.cf as 'CF Coniuge',
		#coniugi.birthdate as 'Data Nascita Coniuge',
		#coniugi.startapplication as 'Inizio Applicazione',
		#coniugi.stopapplication as 'Fine Applicazione',
		#coniugi.flagdependent as 'A Carico'
	FROM #prestazioni_trasmesse
	JOIN registry 
		ON #prestazioni_trasmesse.idreg = registry.idreg
	JOIN service 
		ON #prestazioni_trasmesse.idser = service.idser
	LEFT OUTER JOIN motive770service
		ON motive770service.idser = service.idser
		AND   motive770service.ayear = @annoredditi
	LEFT OUTER JOIN mod770_exemptioncode 
		ON mod770_exemptioncode.exemptioncode = motive770service.exemptioncode
		AND mod770_exemptioncode.ayear = @annoredditi
	LEFT OUTER JOIN #coniugi 
		ON #coniugi.idcon = #prestazioni_trasmesse.idcon
	WHERE #prestazioni_trasmesse.capofila = 'S'
	ORDER BY registry.idreg
	
DROP TABLE #prestazioni_trasmesse
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
 