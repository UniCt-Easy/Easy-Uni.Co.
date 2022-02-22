
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_giornale_cassa_ep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure rpt_giornale_cassa_ep
go
-- setuser'amministrazione'
-- exec rpt_giornale_cassa_ep 2020, {ts '2020-12-30 00:00:00'}, {ts '2020-12-31 00:00:00'}, 'N','S', 2, 'N', 'S'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO 

create  PROCEDURE [rpt_giornale_cassa_ep]
	@ayear				int,
	@start	 			datetime,
	@stop				datetime,
	@showupb			char(1),
	@includigirofondi	char(1),
	@idtreasurer		int,
	@documentiesitati	char(1),--Considera tutti i mandati e reversali dell'esercizio esitati nell'esercizio
	@includenextyearop	char(1) --Considera  storni e copertura bollette di quest'anno effettuate in anno successivo
AS
BEGIN
---setuser 'amm'
-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
-- exec rpt_giornale_cassa_ep 2020, {ts '2020-12-30 00:00:00'}, {ts '2020-12-31 00:00:00'}, 'N','N', 2 , 'N','N'
	DECLARE @floatfund		decimal(19,2)
	if(@idtreasurer is null)
	Begin
		SELECT @floatfund = ISNULL(startfloatfund, 0)
		FROM surplus
		WHERE ayear = @ayear
	End	
	Else
	Begin
		SELECT @floatfund = 
			ISNULL(amount,0)
		FROM treasurerstart
		WHERE 	ayear = @ayear and (idtreasurer = @idtreasurer	 or @idtreasurer is null)		
	end

	DECLARE	@newxayear 		int
	SET @newxayear = @ayear +1

	DECLARE @31dicCurr datetime
	SET @31dicCurr = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)

	DECLARE @tot_payment_comp	decimal(19,2)
	SELECT 	@tot_payment_comp = SUM(amount)
	FROM 	historypaymentview 
	WHERE 	competencydate < @start
		AND ymov = @ayear
		AND ( (totflag & 1) =0)-- Competenza
		AND (idtreasurer = @idtreasurer	 or @idtreasurer is null)		

	DECLARE @tot_proceeds_comp	decimal(19,2)
	SELECT 	@tot_proceeds_comp = SUM(amount)
	FROM 	historyproceedsview 
	WHERE 	competencydate < @start
		AND ( (totflag & 1) =0)-- Competenza
		AND ymov = @ayear
		AND (idtreasurer = @idtreasurer	 or @idtreasurer is null)		

	DECLARE @tot_proceeds_esitato	decimal(19,2)
	SELECT 	@tot_proceeds_esitato = SUM(bk.amount)
	FROM 	historyproceedsview HPV
	LEFT JOIN banktransaction bk
		ON bk.idinc = HPV.idinc and bk.yban = @ayear AND bk.kind = 'C'
	WHERE 	HPV.competencydate < @start
		AND HPV.ymov = @ayear
		AND bk.transactiondate <= @stop
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)		

	DECLARE @tot_payment_esitato	decimal(19,2)
	SELECT 	@tot_payment_esitato = SUM(bk.amount)
	FROM 	historypaymentview HPV
	LEFT JOIN banktransaction bk
		ON bk.idexp = HPV.idexp and bk.yban = @ayear AND bk.kind = 'D'
	WHERE 	HPV.competencydate < @start
		AND HPV.ymov = @ayear
		AND bk.transactiondate <= @stop
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)		
	
	DECLARE @codphase_payment tinyint
	SELECT 	@codphase_payment = MAX(nphase) FROM expensephase

	DECLARE @var_payment_comp	decimal(19,2)
	SELECT  @var_payment_comp = SUM(EV.amount)
    	FROM    expensevar EV
	JOIN historypaymentview HPV
		ON  HPV.idexp = EV.idexp
    	WHERE EV.yvar = @ayear
		AND ( (totflag & 1) =0)-- Competenza
		AND HPV.ymov  = @ayear
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)		
	AND (
	(HPV.competencydate < @start
  		AND ( 
			((EV.autokind <> 11) AND(EV.autokind <> 10)) 
			OR EV.autokind is null
          		         )
	)
	OR
	(EV.adate < @start
		AND ((EV.autokind = 11)OR(EV.autokind = 10)) 
	) 
	)

	DECLARE @codphase_proceeds tinyint
	SELECT 	@codphase_proceeds = MAX(nphase) FROM incomephase

	DECLARE @var_proceeds_comp	decimal(19,2)
	SELECT 	@var_proceeds_comp = SUM(IV.amount)
		FROM incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
   	WHERE   IV.yvar = @ayear
		AND HPV.ymov = @ayear
		AND (HPV.idtreasurer = @idtreasurer or @idtreasurer is null)		
		AND ( (totflag & 1) =0)-- Competenza
    		AND (
			(HPV.competencydate < @start
		  		AND ( 
					(   (IV.autokind <> 11) AND(IV.autokind <> 10)  ) 
					OR IV.autokind is null
		          		         )
			)
			OR
			(IV.adate < @start
				AND (   (IV.autokind = 11)OR(IV.autokind = 10)  ) 
			) 
		)
	

	
	DECLARE @tot_payment_resid	decimal(19,2)
	SELECT 	@tot_payment_resid = SUM(amount)
	FROM 	historypaymentview 
	WHERE 	competencydate < @start
		AND ( (totflag & 1) =1)-- Residuo
		AND ymov = @ayear
		AND (idtreasurer = @idtreasurer	 or @idtreasurer is null)		
	
	DECLARE @tot_proceeds_resid	decimal(19,2)
	SELECT 	@tot_proceeds_resid = SUM(amount)
	FROM 	historyproceedsview 
	WHERE 	competencydate < @start
		AND ( (totflag & 1) =1)-- Residuo
		AND ymov = @ayear
		AND (idtreasurer = @idtreasurer	 or @idtreasurer is null)		
	
	DECLARE @var_payment_resid	decimal(19,2)
	SELECT  @var_payment_resid = SUM(EV.amount)
	FROM expensevar EV
	JOIN historypaymentview HPV
		ON HPV.idexp = EV.idexp
	WHERE EV.yvar = @ayear
		AND HPV.ymov = @ayear
		AND (HPV.idtreasurer = @idtreasurer			 or @idtreasurer is null)		
		AND ( (totflag & 1) =1)-- Residuo
	    	AND (
		(HPV.competencydate < @start
	  		AND ( 
				(   (EV.autokind <> 11) AND(EV.autokind <> 10)  ) 
				OR EV.autokind is null
	          		         )
		)
		OR
		(EV.adate  < @start
			AND (   (EV.autokind = 11)OR(EV.autokind = 10)  ) 
		) 
	)

	DECLARE @var_proceeds_resid	decimal(19,2)
	SELECT 	@var_proceeds_resid = SUM(IV.amount)
    	FROM 	incomevar IV
	JOIN 	historyproceedsview HPV
		ON  HPV.idinc = IV.idinc
    	WHERE IV.yvar = @ayear
		AND (HPV.idtreasurer = @idtreasurer			 or @idtreasurer is null)		
		AND HPV.ymov = @ayear
		AND ( (totflag & 1) =1)-- Residuo
    		AND (
		(HPV.competencydate < @start
	  		AND ( 
				(   (IV.autokind <> 11) AND(IV.autokind <> 10)) 
				OR IV.autokind is null
	          		)
		)
		OR
		(IV.adate < @start
			AND ((IV.autokind = 11)OR(IV.autokind = 10)  ) 
		) 
	)

	DECLARE @girofondi_pay	decimal(19,2)
	DECLARE @girofondi_pro	decimal(19,2)
		-- Inseriamo i Girofondi 
	IF(@idtreasurer is not null) and (@includigirofondi = 'S')
	Begin
		--> Girofondi -
		SELECT @girofondi_pay = sum(amount)
		FROM moneytransfer   
		WHERE ytransfer = @ayear AND idtreasurersource = @idtreasurer
			and adate <  @start
		--> Girofondi + 
		SELECT @girofondi_pro = sum(amount)
		FROM moneytransfer   
		WHERE ytransfer = @ayear AND idtreasurerdest = @idtreasurer
			and adate  < @start
	End

	SELECT @tot_payment_comp   = 
		ISNULL(@tot_payment_comp,0) + 
		ISNULL(@var_payment_comp, 0) +
		isnull(@girofondi_pay,0)
   
    	SELECT @tot_proceeds_comp  = 
		ISNULL(@tot_proceeds_comp, 0) + 
		ISNULL(@var_proceeds_comp, 0) +
		isnull(@girofondi_pro,0)

	SELECT @tot_payment_resid  = 
		ISNULL(@tot_payment_resid,0) + 
		ISNULL(@var_payment_resid, 0)

    	SELECT @tot_proceeds_resid = 
		ISNULL(@tot_proceeds_resid, 0) + 
		ISNULL(@var_proceeds_resid, 0)

	
	CREATE TABLE #journal
	(
		operationorder		int,
		adate				datetime,
		nmov				int,
		description			varchar(max),
		codefin				varchar(50),
		codeupb				varchar(50),
		registry			varchar(100),
		npro				int,
		docdate				datetime,
		doc					varchar(max),
		competency_proceeds	decimal(19,2),
		residual_proceeds	decimal(19,2),
		competency_payment	decimal(19,2),
		residual_payment	decimal(19,2),
		floatfund			decimal(19,2),
		idmov				varchar(40),
		autokind 			tinyint,
		operationkind 		varchar(40),
		idfin				int,
		esitatoR			decimal(19,2),
		esitatoM			decimal(19,2),
		esitato				char(1)
	)
	
	DECLARE @cashvaliditykind 	tinyint
	SELECT	@cashvaliditykind = cashvaliditykind
	FROM 	config
	WHERE 	ayear = @ayear


	INSERT INTO #journal
	(
		adate,
		nmov,
		npro,
		docdate,
		registry,
		description,
		doc,
		codefin,  idfin,
		codeupb,
		competency_proceeds,
		residual_proceeds,
		idmov,
		operationorder,
		esitato
	)  
	SELECT
		HPV.adate,
		HPV.nmov,
		HPV.npro,
		HPV.competencydate,
		registry.title,
		HPV.description,
		CASE
			WHEN 	HPV.doc IS NOT NULL AND 
				HPV.docdate IS NULL THEN
				'Inc. ' + HPV.doc
			WHEN 	HPV.doc IS NOT NULL AND
				HPV.docdate IS NOT NULL THEN
				'Inc. ' + HPV.doc + 
				' del ' + CONVERT(varchar(20), HPV.docdate, 105)
			ELSE
				(NULL)
		END,
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) = 0) then HPV.amount  ELSE (NULL) END,
		CASE WHEN ( (totflag & 1) = 1) then HPV.amount  ELSE (NULL) END,
		HPV.idinc,
		2,
		'N'
	FROM historyproceedsview HPV
	JOIN fin
		ON fin.idfin = HPV.idfin
	JOIN registry
		ON registry.idreg = HPV.idreg
	JOIN upb
		ON upb.idupb = HPV.idupb
	WHERE HPV.competencydate BETWEEN @start AND @stop
		AND HPV.ymov = @ayear
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)		

if ( @cashvaliditykind = 4 and @documentiesitati='S')
Begin
	INSERT INTO #journal
	(
		adate,
		nmov,
		npro,
		docdate,
		registry,
		description,
		doc,
		codefin,  idfin,
		codeupb,
		competency_proceeds,
		residual_proceeds,
		idmov,
		operationorder,
		esitato
	)  
	SELECT
		HPV.adate,
		HPV.nmov,
		HPV.npro,
		@31dicCurr,--HPV.competencydate,
		registry.title,
		HPV.description,
		CASE
			WHEN 	HPV.doc IS NOT NULL AND 
				HPV.docdate IS NULL THEN
				'Inc. ' + HPV.doc
			WHEN 	HPV.doc IS NOT NULL AND
				HPV.docdate IS NOT NULL THEN
				'Inc. ' + HPV.doc + 
				' del ' + CONVERT(varchar(20), HPV.docdate, 105)
			ELSE
				(NULL)
		END,
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) = 0) then HPV.amount  ELSE (NULL) END, -- Competenza
		CASE WHEN ( (totflag & 1) = 1) then HPV.amount  ELSE (NULL) END, -- Residui
		HPV.idinc,
		2,
		'S'
	FROM historyproceedsview HPV
	JOIN fin
		ON fin.idfin = HPV.idfin
	JOIN registry
		ON registry.idreg = HPV.idreg
	JOIN upb
		ON upb.idupb = HPV.idupb
	WHERE  year(HPV.competencydate ) = @newxayear -- Considera gli incassi esitati l'anno successivo, come incassi esitati l'anno corrente affinchÃ¨ influiscano sulla cassa dell'anno corrente
		AND HPV.ymov = @ayear
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)	
end

	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #journal
		(
			adate,
			nmov,
			npro,
			docdate,
			registry,
			description,
			doc,
			codefin,idfin,
			codeupb,
			competency_proceeds,
			residual_proceeds,
			idmov,
			autokind,
			operationorder,
			esitato
		)
	    	SELECT
			IV.adate,
			HPV.nmov,
			HPV.npro,
			HPV.competencydate,
			registry.title,
			IV.description,
			CASE
			    WHEN IV.doc IS NOT NULL AND 
				 IV.docdate IS NULL THEN
				 'Inc. ' + IV.doc
			    WHEN IV.doc IS NOT NULL AND
				 IV.docdate IS NOT NULL THEN
				 'Inc. ' + IV.doc + 
				 ' del ' + CONVERT(varchar(20), IV.docdate, 105)
			    ELSE
				(NULL)
			END,
			fin.codefin, HPV.idfin,
			upb.codeupb,
			CASE 
				WHEN ( (totflag & 1) =0) then IV.amount  ELSE (NULL) END,
			CASE 
				WHEN ( (totflag & 1) =1) then IV.amount  ELSE (NULL) END,
			HPV.idinc,
			IV.autokind,
			3,
			'N'
		FROM incomevar  IV
			JOIN historyproceedsview HPV 
				ON HPV.idinc = IV.idinc
			JOIN fin
				ON fin.idfin = HPV.idfin
			JOIN upb
				ON upb.idupb = HPV.idupb
			JOIN registry
				ON registry.idreg = HPV.idreg
		WHERE IV.yvar = @ayear
			AND HPV.ymov = @ayear
			AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)		
			AND isnull(IV.autokind,'') <>'22' 
			AND (
			(HPV.competencydate BETWEEN @start AND @stop
					AND ( 
					((IV.autokind <> 11) AND(IV.autokind <> 10)) 
					OR IV.autokind IS NULL)
			)
			OR
			(IV.adate  BETWEEN @start AND @stop
				AND ((IV.autokind = 11) OR (IV.autokind = 10)) 
				))
	END

	INSERT INTO #journal
	(
		adate,
		nmov,
		npro,
		docdate,
		registry,
		description,
		doc,
		codefin,idfin,
		codeupb,
		competency_payment,
		residual_payment,
		idmov,
		operationorder,
		esitato
	)
	SELECT							
		HPV.adate,
		HPV.nmov,
		HPV.npay,
		HPV.competencydate,
		registry.title,
		HPV.description,
		CASE
			WHEN HPV.doc IS NOT NULL AND 
				HPV.docdate IS NULL THEN
				'Pag. ' + HPV.doc
			WHEN HPV.doc IS NOT NULL AND
				HPV.docdate IS NOT NULL THEN
				'Pag. ' + HPV.doc + 
				' del ' + CONVERT(varchar(20), HPV.docdate, 105)
			ELSE
		(NULL)
		END,
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) =0) then HPV.amount  ELSE NULL END,
		CASE WHEN ( (totflag & 1) =1) then HPV.amount  ELSE NULL END,
		HPV.idexp,
		4,
		'N'
		FROM historypaymentview HPV
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE HPV.competencydate BETWEEN @start AND @stop
			AND HPV.ymov  = @ayear
			AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)		

if ( @cashvaliditykind = 4 and @documentiesitati='S')
Begin
	INSERT INTO #journal
	(
		adate,
		nmov,
		npro,
		docdate,
		registry,
		description,
		doc,
		codefin,idfin,
		codeupb,
		competency_payment,
		residual_payment,
		idmov,
		operationorder,
		esitato
	)
	SELECT							
		HPV.adate,
		HPV.nmov,
		HPV.npay,
		@31dicCurr,--HPV.competencydate,
		registry.title,
		HPV.description,
		CASE
			WHEN HPV.doc IS NOT NULL AND 
				HPV.docdate IS NULL THEN
				'Pag. ' + HPV.doc
			WHEN HPV.doc IS NOT NULL AND
				HPV.docdate IS NOT NULL THEN
				'Pag. ' + HPV.doc + 
				' del ' + CONVERT(varchar(20), HPV.docdate, 105)
			ELSE
		(NULL)
		END,
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) =0) then HPV.amount  ELSE NULL END,
		CASE WHEN ( (totflag & 1) =1) then HPV.amount  ELSE NULL END,
		HPV.idexp,
		4,
		'S'
		FROM historypaymentview HPV
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE  year(HPV.competencydate ) = @newxayear -- Considera i pagamenti esitati l'anno successivo, come pagamenti esitati l'anno corrente affinchÃ¨ influiscano sulla cassa dell'anno corrente
			AND HPV.ymov  = @ayear
			AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)	
End	

	IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #journal
		(
			adate,
			nmov,
			npro,
			docdate,
			registry,
			description,
			doc,
			codefin,idfin,
			codeupb,
			competency_payment,
			residual_payment,
			idmov,
			autokind,
			operationorder,
			esitato
		)
		SELECT
			EV.adate,
			HPV.nmov,
			HPV.npay,
			HPV.competencydate,
			registry.title,
			EV.description,
			CASE
			    WHEN EV.doc IS NOT NULL AND 
				    EV.docdate IS NULL THEN
				    'Pag. ' + EV.doc
			    WHEN EV.doc IS NOT NULL AND
				    EV.docdate IS NOT NULL THEN
				    'Pag. ' + EV.doc + 
				    ' del ' + CONVERT(varchar(20), EV.docdate, 105)
			    ELSE
			NULL
			END,
			fin.codefin,HPV.idfin,
			upb.codeupb,
			CASE WHEN ( (totflag & 1) =0) then EV.amount  ELSE (NULL) END,
			CASE WHEN ( (totflag & 1) =1) then EV.amount  ELSE (NULL) END,
			HPV.idexp,
			EV.autokind,
			5,
			'N'
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp 	= EV.idexp
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE EV.yvar = @ayear
			AND  HPV.ymov 	= @ayear
			AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)		
			AND isnull(EV.autokind,'') <>'22' 
		AND (
			(HPV.competencydate BETWEEN @start AND @stop
	  		AND ( 
				((EV.autokind <> 11) AND(EV.autokind <> 10)  ) 
				OR EV.autokind is null
	          		 )
			)
			OR
			(EV.adate  BETWEEN @start AND @stop
				AND ((EV.autokind = 11)OR(EV.autokind = 10)  ) 
			) 
		)
	END

Print 'Inseriamo l''esitato'
if (@documentiesitati = 'N')
begin
	UPDATE #journal 
	SET esitatoR = (SELECT SUM(amount) from banktransaction WHERE yban = @ayear and kind = 'C' and transactiondate <= @stop and idinc = idmov)
	WHERE operationorder = 2 --  and 3 -- verificare se 3 serve
	UPDATE #journal 
	SET esitatoM = (SELECT SUM(amount) from banktransaction WHERE yban = @ayear and kind = 'D' and transactiondate <= @stop and idexp = idmov)
	WHERE operationorder =  4 -- and 5 -- verificare se 5 serve
end

if (@documentiesitati = 'S')
begin
	UPDATE #journal 
	SET esitatoR = (SELECT SUM(amount) from banktransaction WHERE yban = @ayear and kind = 'C' and transactiondate <= cast(cast(CONVERT(varchar(10), @ayear) + 1 as nvarchar(4)) + '-12-31' as date) and idinc = idmov)
	WHERE operationorder = 2 --  and 3 -- verificare se 3 serve
	UPDATE #journal 
	SET esitatoM = (SELECT SUM(amount) from banktransaction WHERE yban = @ayear and kind = 'D' and transactiondate <= cast(cast(CONVERT(varchar(10), @ayear) + 1 as nvarchar(4)) + '-12-31' as date) and idexp = idmov)
	WHERE operationorder =  4 -- and 5 -- verificare se 5 serve
end

	-- Inseriamo i Girofondi 
IF ((@idtreasurer is not null) and (@includigirofondi = 'S'))
Begin
	--> Girofondi - 
	INSERT INTO #journal
	(
		adate,docdate,-- devo per forza valorizzare docdate perchÃ¨ il report raggruppa e quindi ordina per docdate, se non la valorizziamo,i girofondi sarnno sempre le prime op. del report
		npro,
		description,
		competency_payment,
		operationorder
	)  
	SELECT
		adate,adate,
		ntransfer,
		description,
		amount,
		6
	FROM moneytransfer   
	WHERE ytransfer = @ayear AND idtreasurersource = @idtreasurer and adate BETWEEN @start AND @stop

	--> Girofondi + 
	INSERT INTO #journal
	(
		adate,docdate,
		npro,
		description,
		competency_proceeds,
		operationorder
	)  
	SELECT
		adate,adate,
		ntransfer,
		description,
		amount,
		7
	FROM moneytransfer   
	WHERE ytransfer = @ayear AND idtreasurerdest = @idtreasurer and adate BETWEEN @start AND @stop
End


	UPDATE #journal
		SET floatfund = @floatfund
	
	UPDATE #journal 
		SET docdate = adate
		WHERE 
		operationorder = 3
		AND
		((autokind = 11)OR(autokind=10))
	
	UPDATE #journal 
		SET docdate = adate
		WHERE 
		operationorder = 5
		AND ((autokind = 11)OR(autokind=10))

	CREATE TABLE #journalcompact
	(
		operationorder		int,
		npro				int,
		docdate				datetime,
		registry			varchar(100),
		description			varchar(max),
		doc                 varchar(max), 
		idfin				int, 
		codeupb				varchar(50),
		competency_proceeds	decimal(19,2),
		residual_proceeds	decimal(19,2),
		competency_payment	decimal(19,2),
		residual_payment	decimal(19,2),
		floatfund			decimal(19,2),
		esitatoR			decimal(19,2),
		esitatoM			decimal(19,2),
		autokind 			tinyint,
		esitato				char(1)
	)	
	

	DECLARE @minlevel tinyint 
	SELECT  @minlevel =  MIN(nlevel) FROM finlevel WHERE (flag&2)<>0 and ayear = @ayear

	INSERT INTO #journalcompact
	(
		operationorder,
		npro, 
		docdate,
		idfin,  -- codefin, 				
		codeupb,
		competency_proceeds,
		residual_proceeds,
		competency_payment,
		residual_payment,
		floatfund,
		esitatoR,
		esitatoM,
		registry,
		autokind,
		esitato
	)
	SELECT 
		operationorder,
		npro,
		docdate,
		FLK.idparent,  
		codeupb,                      
		ISNULL(SUM(competency_proceeds),0.0),
		ISNULL(SUM(residual_proceeds),0.0),
		ISNULL(SUM(competency_payment),0.0),
		ISNULL(SUM(residual_payment),0.0),
		floatfund	,
		ISNULL(SUM(esitatoR),0.0),
		ISNULL(SUM(esitatoM),0.0),
		registry,
		autokind,
		esitato
	FROM  	#journal
	JOIN finlink FLK
		ON #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel
	GROUP BY docdate,npro,codeupb, FLK.idparent, 
		 floatfund,operationorder,registry,
		autokind,esitato	
	
	--SELECT * FROM #journal order by npro
	--SELECT * FROM #journalcompact order by npro

---- compattamento dei campi doc e descrizione ove possibile
	--------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------


	CREATE TABLE #descrizioni(npro int,description varchar(max),operationorder int, registry varchar(400),doc varchar(max), autokind int, idfin int, codeupb varchar(50), longdescription varchar(max), longdoc varchar(max))

	insert into #descrizioni(npro,description,operationorder, registry,doc, autokind, idfin, codeupb, longdescription, longdoc)
	SELECT    DISTINCT  	npro,description,operationorder,registry,doc,
			autokind,FLK.idparent as idfin, 
			codeupb,(select DISTINCT SUBSTRING(ISNULL(D.description,'') +';',1,6000)  FROM #journal D WHERE  #journal.npro = D.npro AND
	  #journal.operationorder = D.operationorder AND #journal.registry = D.registry AND
	  #journal.idfin = D.idfin AND
	  #journal.codeupb = D.codeupb   FOR XML PATH('')) as longdescription ,(select DISTINCT SUBSTRING(ISNULL(D.doc,'') +';',1,1000)  FROM #journal D WHERE  #journal.npro = D.npro AND
	  #journal.operationorder = D.operationorder AND #journal.registry = D.registry AND
	  #journal.idfin = D.idfin AND
	  #journal.codeupb = D.codeupb   FOR XML PATH(''))  as  longdoc
		FROM #journal 
		JOIN finlink FLK
			ON #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel

	
	--SELECT * FROM #descrizioni

	 UPDATE  #journalcompact  SET description = ISNULL(D.longdescription,#journalcompact.description) , doc = ISNULL(D.longdoc,#journalcompact.doc)
	 FROM #descrizioni D WHERE 
	 #journalcompact.npro = D.npro AND
	 #journalcompact.operationorder = D.operationorder AND
	 #journalcompact.registry = D.registry AND
	 #journalcompact.idfin = D.idfin AND
	 #journalcompact.codeupb = D.codeupb  
 
	--SELECT * FROM #journalcompact WHERE description is not null
	--------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------

	DECLARE @descphase_proceeds	varchar(50)
	SELECT 	@descphase_proceeds 	= description FROM incomephase
	WHERE 	nphase = @codphase_proceeds

	DECLARE @descphase_payment	varchar(50)
	SELECT 	@descphase_payment 	= description FROM expensephase
	WHERE 	nphase = @codphase_payment

	INSERT INTO #journalcompact
	(
		operationorder	,
		npro,
		docdate,
		registry,description,doc,idfin,codeupb,
		competency_proceeds	,
		residual_proceeds	,
		competency_payment	,
		residual_payment	,
		esitatoR,
		esitatoM,
		floatfund		,
		autokind,
		esitato)
	VALUES
	(
		1,
		null,
		DATEADD(day, -1, @start),
		null, null, null, null, null, 
		@tot_proceeds_comp,
		@tot_proceeds_resid,
		@tot_payment_comp,
		@tot_payment_resid,
		@tot_proceeds_esitato,
		@tot_payment_esitato,
		@floatfund,null,null
	)

		--Aggiungo i girofondi, perchÃ¨ non hanno bilancio/upb
	INSERT INTO #journalcompact(
		operationorder,description,
		npro, 
		docdate,
		competency_proceeds,
		competency_payment,
		floatfund
	)
	SELECT 
		operationorder,description,
		npro,
		docdate,
		ISNULL(competency_proceeds,0),
		ISNULL(competency_payment,0),
		floatfund
	FROM  	#journal
	where operationorder in (6,7)

	DECLARE @treasurer_header varchar(150)
	SELECT @treasurer_header = header
	FROM treasurer
	where idtreasurer = @idtreasurer



	IF @documentiesitati='S'
	begin	
		UPDATE #journalcompact
		Set esitatoR = ISNULL(competency_proceeds,0) + ISNULL(residual_proceeds,0),
		esitatoM = ISNULL(competency_payment,0) + ISNULL(residual_payment,0)
		WHERE #journalcompact.esitato = 'S'
	end

    -- parametro includi movimentazione bollette in anno successivo 
	-- se il parametro vale N devo vedere importo apertura e storni sospesi al 31 /12 (o alla data stop della stampa), 
	-- importo coperto su trasmesso al 31 /12 (o data stop della stampa) 
	DECLARE @partite_pendenti_attive decimal(19,2) 
	DECLARE @coperto_partite_pendenti_attive decimal(19,2)
	DECLARE @esitato_partite_pendenti_attive decimal(19,2)
	IF (ISNULL(@includenextyearop,'N') = 'N') 
		BEGIN		
		  ---    APERTURE E STORNI: CONSIDERO APERTURE NEL PERIODO DELLA STAMPA E TUTTI GLI EVENTUALI STORNI
		  ---    CONSIDERO APERTURE NELL'ANNO E NON SOLO IL RANGE DELLA STAMPA
			SELECT  @partite_pendenti_attive = 
			SUM(isnull(bankimportbill.amount,0))
			FROM bankimportbill join bill on bill.ybill = bankimportbill.ybill and bill.nbill = bankimportbill.nbill  and bill.billkind = bankimportbill.billkind 
			WHERE bill.ybill = @ayear 
				AND bill.billkind='C' 
				AND bill.active = 'S'
				AND
				(	(year(bill.adate) = @ayear AND (bill.adate <= @stop)) 
				    OR  (@stop is null)
				)
				AND (bankimportbill.adate <= @stop  or @stop is null)
				AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)

		 -- IMPORTO ESITATO DELLE PARTITE PENDENTI ATTIVE

		 SELECT  @esitato_partite_pendenti_attive = 
			SUM(isnull(billtransaction.amount,0))
			FROM billtransaction join bill on bill.ybill = billtransaction.ybill and bill.nbill = billtransaction.nbill  and bill.billkind = billtransaction.billkind 
			WHERE bill.ybill = @ayear 
				AND bill.billkind='C' 
				AND bill.active = 'S'
				AND
				(	(year(bill.adate) = @ayear AND (bill.adate <= @stop)) 
				    OR  (@stop is null)
				)
				AND (billtransaction.adate <= @stop  or @stop is null)
				AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)

		 --  --- IMPORTO COPERTO RIFERITO AI SOLI INCASSI TRASMESSI 
		 --  --- 1) IMPORTO COPERTO DA INCASSI TRASMESSI
			--SELECT  @coperto_partite_pendenti_attive = isnull(
			--	   (SELECT SUM(incomeview.curramount) 
			--		FROM incomeview
			--		join bill on incomeview.nbill = bill.nbill AND incomeview.ayear = bill.ybill
			--		WHERE  bill.active='S' AND bill.billkind = 'C' 
			--		AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
			--		AND year(bill.adate) = @ayear
			--		AND (incomeview.transmissiondate IS NOT NULL)
			--		and (incomeview.transmissiondate <= @stop OR @stop IS NULL)
			--		),0)
			--	+
		 
		 -- --- 2) IMPORTO COPERTO DA ASSOCIAZIONI MULTIPLE A INCASSI TRASMESSI
		 --  isnull((SELECT SUM(incomebill.amount)
			--		from incomebill 
			--		JOIN incomeview ON incomeview.idinc = incomebill.idinc
			--		join bill on incomeview.ayear= bill.ybill AND incomebill.ybill=bill.ybill AND incomebill.nbill=bill.nbill 
			--		WHERE bill.active='S' AND bill.billkind = 'C' 
			--		AND    (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
			--		AND    year(bill.adate) = @ayear
			--		AND	(incomeview.transmissiondate IS NOT NULL)
			--		and (incomeview.transmissiondate <= @stop OR @stop IS NULL)
			--		),0)
 

		END 
	ELSE
		BEGIN
		  ---    APERTURE E STORNI: CONSIDERO APERTURE NEL PERIODO DELLA STAMPA E TUTTI GLI EVENTUALI STORNI SUCCESSIVI
			SELECT  @partite_pendenti_attive = 
			SUM(isnull(total,0) - isnull(reduction,0))
			FROM billview 
			WHERE ybill = @ayear 
				AND billkind='C' 
				AND active = 'S'
				AND
				(	(year(billview.adate) = @ayear AND (billview.adate <= @stop))   --bollette aperte nel periodo della stampa
				    OR  (@stop is null)
				)
				AND (idtreasurer = @idtreasurer  or @idtreasurer is null)
	
		   SELECT  @esitato_partite_pendenti_attive = 
				SUM(isnull(regularized,0))
			FROM billview 
			WHERE ybill = @ayear 
				AND billkind='C' 
				AND active = 'S'
				AND
				(	(year(billview.adate) = @ayear AND (billview.adate <= @stop))   --bollette aperte nel periodo della stampa
				    OR  (@stop is null)
				)
				AND (idtreasurer = @idtreasurer  or @idtreasurer is null)

		 --  --- IMPORTO COPERTO RIFERITO AI SOLI INCASSI TRASMESSI 
		 --  --- 1) IMPORTO COPERTO DA INCASSI TRASMESSI
			--SELECT  @coperto_partite_pendenti_attive = isnull(
			--	   (SELECT SUM(incomeview.curramount) 
			--		FROM incomeview
			--		join bill on incomeview.nbill = bill.nbill AND incomeview.ayear = bill.ybill
			--		WHERE  bill.active='S' AND bill.billkind = 'C' 
			--		AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
			--		AND year(bill.adate) = @ayear
			--		AND (incomeview.transmissiondate IS NOT NULL)
			--			--and (incomeview.transmissiondate <= @stop OR @stop IS NULL)
			--		),0)
			--+		 
		 -- --- 3) IMPORTO COPERTO DA ASSOCIAZIONI MULTIPLE A PAGAMENTI NON TRASMESSI
		 --  isnull((SELECT SUM(incomebill.amount)
			--		from incomebill 
			--		JOIN incomeview ON incomeview.idinc = incomebill.idinc
			--		join bill on incomeview.ayear= bill.ybill AND incomebill.ybill=bill.ybill AND incomebill.nbill=bill.nbill 
			--		WHERE bill.active='S' AND bill.billkind = 'C' 
			--		AND    (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
			--		AND    year(bill.adate) = @ayear
			--		AND	(incomeview.transmissiondate IS NOT NULL)
			--		-- and (incomeview.transmissiondate <= @stop OR @stop IS NULL)
			--		),0)
 
  --SELECT * 		    FROM   bill 
		--	WHERE  bill.active='S' AND bill.billkind = 'C' 
		--	AND    (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
		--	AND    year(bill.adate) = @ayear 
		END

	SET @partite_pendenti_attive = isnull(@partite_pendenti_attive,0) - isnull(@esitato_partite_pendenti_attive,0)

	DECLARE @partite_pendenti_passive decimal(19,2)
 	DECLARE @coperto_partite_pendenti_passive decimal(19,2)
	DECLARE @esitato_partite_pendenti_passive decimal(19,2)
	-- parametro includi movimentazione bollette in anno successivo 
	-- se il parametro vale N devo vedere importo apertura e storni sospesi al 31 /12 (o alla data stop della stampa), 
	-- importo coperto su trasmesso al 31 /12 (o data stop della stampa)
	IF (ISNULL(@includenextyearop,'N') = 'N')
		BEGIN
		    --- APERTURE E STORNI: CONSIDERO APERTURE NEL PERIODO DELLA STAMPA E TUTTI GLI EVENTUALI STORNI, ANCHE QUELLI AVVENUTI IN SEGUITO
		    --- CONSIDERO APERTURE NELL'ANNO E NON SOLO IL RANGE DELLA STAMPA
			SELECT  @partite_pendenti_passive = SUM(isnull(bankimportbill.amount,0))
			FROM bankimportbill join bill on bill.ybill = bankimportbill.ybill and bill.nbill = bankimportbill.nbill  and bill.billkind = bankimportbill.billkind 
			WHERE bill.ybill = @ayear 
				AND bill.billkind='D' 
				AND bill.active = 'S'
				AND
				(	(year(bill.adate) = @ayear AND (bill.adate <= @stop)) 
				    OR  (@stop is null)
				)
				AND (bankimportbill.adate <= @stop  or @stop is null)
				AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)


				 -- IMPORTO ESITATO DELLE PARTITE PENDENTI ATTIVE

		 SELECT  @esitato_partite_pendenti_passive = 
			SUM(isnull(billtransaction.amount,0))
			FROM billtransaction join bill on bill.ybill = billtransaction.ybill and bill.nbill = billtransaction.nbill  and bill.billkind = billtransaction.billkind 
			WHERE bill.ybill = @ayear 
				AND bill.billkind='D' 
				AND bill.active = 'S'
				AND
				(	(year(bill.adate) = @ayear AND (bill.adate <= @stop)) 
				    OR  (@stop is null)
				)
				AND (billtransaction.adate <= @stop  or @stop is null)
				AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)

				/*
		    --- IMPORTO COPERTO RIFERITO AI SOLI PAGAMENTI TRASMESSI 
			--- 1) IMPORTO COPERTO DA PAGAMENTI TRASMESSI
			SELECT  @coperto_partite_pendenti_passive = isnull( (SELECT SUM(expenseview.curramount)  
			FROM expenseview 
			join bill on expenseview.nbill = bill.nbill
					AND expenseview.ayear = bill.ybill
			WHERE  bill.active='S' AND bill.billkind = 'D' 
			AND    (bill.idtreasurer = @idtreasurer or @idtreasurer is null)
			AND    year(bill.adate) = @ayear
					AND (expenseview.transmissiondate IS NOT NULL)
					and (expenseview.transmissiondate <= @stop OR @stop IS NULL)
			),0)			
			
			+
			--- 2) IMPORTO COPERTO DA OPERAZIONI FONDO ECONOMALE NON REINTEGRATE o REINTEGRATE E NON TRASMESSE
			isnull((SELECT SUM(operation.amount)
			FROM pettycashoperation operation 
			join bill on operation.yoperation = bill.ybill
				AND operation.nbill = bill.nbill
			WHERE 
				--- bollette non rientegrate
				((NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
					WHERE restoreop.yoperation = operation.yrestore
					AND restoreop.noperation = operation.nrestore
					AND restoreop.idpettycash = operation.idpettycash)
					)
				OR
				(
					-- REINTEGRATE MA REINTEGRI NON TRASMESSI
					NOT EXISTS (SELECT COUNT(*) FROM pettycashoperation pce
						JOIN expenseview e
						ON  e.idexp = pce.idexp
					WHERE pce.yoperation = operation.yrestore
					AND pce.noperation = operation.nrestore
					AND pce.idpettycash = operation.idpettycash
					AND e.nbill = bill.nbill
					AND e.ayear= bill.ybill
					AND (e.transmissiondate IS NOT NULL)
					AND (e.transmissiondate <= @stop OR @stop IS NULL)
					)))
					and bill.active='S' AND bill.billkind = 'D' 
					AND (bill.idtreasurer = @idtreasurer or @idtreasurer is null)
					AND year(bill.adate) = @ayear
				 )
				,0)
				+ 
		  --- 3) IMPORTO COPERTO DA ASSOCIAZIONI MULTIPLE A PAGAMENTI TRASMESSI
		  isnull((SELECT SUM(expensebill.amount) 
			from expensebill 
			JOIN expenseview ON expenseview.idexp = expensebill.idexp
			join bill on expenseview.ayear= bill.ybill AND expensebill.ybill=bill.ybill AND expensebill.nbill=bill.nbill 
			WHERE 
			(expenseview.transmissiondate IS NOT NULL)
			-- and (expenseview.transmissiondate <= @stop OR @stop IS NULL)
			and bill.active='S' AND bill.billkind = 'D' 
			AND    (bill.idtreasurer = @idtreasurer or @idtreasurer is null)
			AND    year(bill.adate) = @ayear
			),0)
		*/
		END
	ELSE
		BEGIN
		    ---    APERTURE E STORNI: CONSIDERO APERTURE NEL PERIODO DELLA STAMPA E TUTTI GLI EVENTUALI STORNI SUCCESSIVI
			SELECT  @partite_pendenti_passive = SUM(isnull(total,0) - isnull(reduction,0))
			FROM billview 
			WHERE ybill = @ayear 
				AND billkind='D' 
				AND active = 'S'
				AND
				(	(year(billview.adate) = @ayear AND (billview.adate <= @stop))   --bollette aperte nel periodo della stampa
				    OR  (@stop is null)
				)
				AND (idtreasurer = @idtreasurer  or @idtreasurer is null)
			-- SELECT @partite_pendenti_passive
		    -- IMPORTO ESITATO  A OGGI
			  SELECT  @esitato_partite_pendenti_passive = 
				SUM(isnull(regularized,0))
			FROM billview 
			WHERE ybill = @ayear 
				AND billkind='D' 
				AND active = 'S'
				AND
				(	(year(billview.adate) = @ayear AND (billview.adate <= @stop))   --bollette aperte nel periodo della stampa
				    OR  (@stop is null)
				)
				AND (idtreasurer = @idtreasurer  or @idtreasurer is null)

			/*
			SELECT  @coperto_partite_pendenti_passive = isnull( (SELECT SUM(expenseview.curramount)  
			FROM expenseview 
			join bill on expenseview.nbill = bill.nbill
					AND expenseview.ayear = bill.ybill
			WHERE  bill.active='S' AND bill.billkind = 'D' 
			AND    (bill.idtreasurer = @idtreasurer or @idtreasurer is null)
			AND    year(bill.adate) = @ayear
					AND (expenseview.transmissiondate IS NOT NULL)
					--and (expenseview.transmissiondate <= @stop OR @stop IS NULL)
			),0)
				+
			--- 2) IMPORTO COPERTO DA OPERAZIONI FONDO ECONOMALE NON REINTEGRATE o REINTEGRATE E NON TRASMESSE
			isnull((SELECT SUM(operation.amount)
			FROM pettycashoperation operation 
			join bill on operation.yoperation = bill.ybill
				AND operation.nbill = bill.nbill
			WHERE 
				--- bollette non rientegrate
				((NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
					WHERE restoreop.yoperation = operation.yrestore
					AND restoreop.noperation = operation.nrestore
					AND restoreop.idpettycash = operation.idpettycash)
					)
				OR
				(
					-- REINTEGRATE MA REINTEGRI NON TRASMESSI
					NOT EXISTS (SELECT COUNT(*) FROM pettycashoperation pce
						JOIN expenseview e
						ON  e.idexp = pce.idexp
					WHERE pce.yoperation = operation.yrestore
					AND pce.noperation = operation.nrestore
					AND pce.idpettycash = operation.idpettycash
					AND e.nbill = bill.nbill
					AND e.ayear= bill.ybill
					AND (e.transmissiondate IS NOT NULL)
					--AND (expenseview.transmissiondate <= @stop OR @stop IS NULL)
					)))
					and bill.active='S' AND bill.billkind = 'D' 
					AND (bill.idtreasurer = @idtreasurer or @idtreasurer is null)
					AND year(bill.adate) = @ayear
				 )
				,0)
				+ 
		  --- 3) IMPORTO COPERTO DA ASSOCIAZIONI MULTIPLE A PAGAMENTI NON TRASMESSI
			isnull((SELECT SUM(expensebill.amount) 
			from expensebill 
			JOIN expenseview ON expenseview.idexp = expensebill.idexp
			join bill on expenseview.ayear= bill.ybill AND expensebill.ybill=bill.ybill AND expensebill.nbill=bill.nbill 
			WHERE 
			(expenseview.transmissiondate IS NOT NULL)
			-- and (expenseview.transmissiondate <= @stop OR @stop IS NULL)
			and bill.active='S' AND bill.billkind = 'D' 
			AND    (bill.idtreasurer = @idtreasurer or @idtreasurer is null)
			AND    year(bill.adate) = @ayear
			),0)
		-- SELECT * FROM bill 
		-- WHERE bill.active='S' AND bill.billkind = 'D' 
		-- AND (bill.idtreasurer = @idtreasurer  or @idtreasurer is null)
		-- AND year(bill.adate) = @ayear
		*/
		END

		SET @partite_pendenti_passive = isnull(@partite_pendenti_passive,0) - isnull(@esitato_partite_pendenti_passive,0)

	SELECT  operationorder,
		(SELECT
	  	CASE
		   	 WHEN operationorder = 1 THEN  	'Tot.prec.'
			 WHEN operationorder = 2 THEN  	@descphase_proceeds
	 		 WHEN operationorder = 3 THEN  	'Var.' + @descphase_proceeds
			 WHEN operationorder = 4 THEN  	@descphase_payment
			 WHEN operationorder = 5 THEN	'Var.' + @descphase_payment
			 WHEN operationorder in (6,7) THEN	'Girofondo'
		    	 ELSE  (NULL)
	  	END)	as 'operationkind',
		npro,	
		docdate,
		registry,
		substring(description,1,len(description)-1) as description,     
		substring(doc,1,len(doc)-1) as doc,   
		fin.codefin,
		codeupb,
		ISNULL(competency_proceeds,0) as competency_proceeds,
		ISNULL(residual_proceeds,0) as residual_proceeds,
		ISNULL(competency_payment,0) as competency_payment,
		ISNULL(residual_payment,0) as residual_payment,
		ISNULL(floatfund,0) as floatfund,
		ISNULL(esitatoR,0) as esitatoR,
		ISNULL(esitatoM,0) as esitatoM,
		autokind ,	
		@treasurer_header as treasurer,
		@partite_pendenti_attive as 'pendenti_attive',
		@partite_pendenti_passive as 'pendenti_passive'
	FROM 	#journalcompact 		
	LEFT OUTER join fin 
		ON #journalcompact.idfin = fin.idfin
	ORDER BY 
		docdate ASC,
		operationorder ASC,
		npro ASC

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
