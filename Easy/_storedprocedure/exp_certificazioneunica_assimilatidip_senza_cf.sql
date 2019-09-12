--setuser 'amm'inistrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazioneunica_assimilatidip_senza_cf]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazioneunica_assimilatidip_senza_cf]
GO
 
--exec [exp_certificazioneunica_assimilatidip_senza_cf]   2016
CREATE PROCEDURE [exp_certificazioneunica_assimilatidip_senza_cf]
(
	@annodichiarazione int
)
-- estraggo l'elenco dei percipienti, autonomi, che hanno eseguito prestazioni mappate con il Record G
 
AS BEGIN
	--declare @annodichiarazione int
	--set @annodichiarazione = 2015

	declare @annoredditi int
	set @annoredditi = @annodichiarazione -1 

	declare @31dic14 datetime
	set @31dic14 = dateadd(yy, @annoredditi-2000, {d '2000-12-31'})

	declare @expensephase int
	select  @expensephase = expensephase from config where ayear = @annodichiarazione-1

	DECLARE @maxexpensephase char(1)
	SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

	CREATE TABLE #prestazioni_trasmesse
	(
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
			ycon,
			ncon,
			duty,
			feegross,
			idreg, 
			idser
		)
	SELECT   co.ycon, co.ncon, co.duty, ce.feegross, co.idreg,  co.idser      
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
		AND (registry.cf IS   NULL) 
		AND (ISNULL(im.flagexcludefromcertificate,'N') = 'N')
		
		
	update #prestazioni_trasmesse set motive770 = motive770service.exemptioncode
		from motive770service 
		where motive770service.idser = #prestazioni_trasmesse.idser
		AND motive770service.ayear = @annoredditi-1
		
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
		mod770_exemptioncode.exemptioncode		as 'Codice Causale'--,
		--substring(ltrim(rtrim(mod770_exemptioncode.description)),1,200) as ' Descr. Causale'
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
	ORDER BY registry.idreg
	
DROP TABLE #prestazioni_trasmesse
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 
 