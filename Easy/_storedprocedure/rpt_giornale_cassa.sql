
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_giornale_cassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_giornale_cassa]
GO


 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
CREATE    PROCEDURE [rpt_giornale_cassa]
	@ayear 		int,
	@start 		datetime,
	@stop 		datetime,
	@showupb 	char(1),
	@includigirofondi char(1),
	@idtreasurer INT,
	@documentiesitati char(1) --Considera tutti i mandati e reversali dell'esercizio esitati nell'esercizio

AS BEGIN

	DECLARE @cashvaliditykind tinyint
	SELECT	@cashvaliditykind = cashvaliditykind
	FROM 	config
	WHERE 	ayear = @ayear

	DECLARE	@newxayear 		int
	SET @newxayear = @ayear +1

--exec rpt_giornale_cassa 2014, {ts '2014-02-11 00:00:00'}, {ts '2014-02-11 00:00:00'}, 'N','S', 4
-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	
	DECLARE @floatfund decimal(19,2)

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
		WHERE 	ayear = @ayear and idtreasurer = @idtreasurer
	end

	DECLARE @31dicCurr datetime
	SET @31dicCurr = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)

	DECLARE @tot_payment_comp	decimal(19,2)
	SELECT 	@tot_payment_comp = SUM(amount)
	FROM 	historypaymentview 
	WHERE 	competencydate < @start
		AND ymov = @ayear
		AND ( (totflag & 1) =0) -- Competenza
		AND (idtreasurer = @idtreasurer	 or @idtreasurer is null)		

	DECLARE @tot_proceeds_comp	decimal(19,2)
	SELECT 	@tot_proceeds_comp = SUM(amount)
	FROM 	historyproceedsview 
	WHERE 	competencydate < @start
		AND ymov = @ayear
		AND ( (totflag & 1) =0)-- Competenza
		AND (idtreasurer = @idtreasurer		 or @idtreasurer is null)		
			
	DECLARE @codphase_payment tinyint
	SELECT 	@codphase_payment = MAX(nphase)
	FROM    expensephase

	DECLARE @var_payment_comp	decimal(19,2)
	SELECT  @var_payment_comp = SUM(EV.amount)
    	FROM   expensevar EV
	JOIN historypaymentview HPV
		ON  HPV.idexp = EV.idexp
    	WHERE EV.yvar = @ayear
		and HPV.ymov = @ayear
		AND (idtreasurer = @idtreasurer		 or @idtreasurer is null)		
		AND ( (HPV.totflag & 1) =0)-- Competenza
	AND (
	(HPV.competencydate < @start
  		AND ( 
			((EV.autokind <> 11) AND(EV.autokind <> 10)) 
			OR EV.autokind is null
          		         )
	)
	OR
	(EV.adate < @start
		AND ((EV.autokind = 11)OR(EV.autokind = 10 )) 
	) 
	)

	DECLARE @codphase_proceeds tinyint
	SELECT 	@codphase_proceeds = MAX(nphase) FROM incomephase
	DECLARE @var_proceeds_comp decimal(19,2)
	SELECT 	@var_proceeds_comp = SUM(IV.amount)
		FROM 	incomevar IV
		JOIN historyproceedsview HPV
			ON HPV.idinc = IV.idinc
	WHERE   IV.yvar = @ayear
		AND (HPV.idtreasurer = @idtreasurer		 or @idtreasurer is null)		
		AND ( (HPV.totflag & 1) =0)-- Competenza
		AND HPV.ymov = @ayear
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
		AND ymov = @ayear
		AND ( (totflag & 1) =1) --Residuo
		AND (idtreasurer = @idtreasurer		 or @idtreasurer is null)		

	DECLARE @tot_proceeds_resid	decimal(19,2)
	SELECT 	@tot_proceeds_resid = SUM(amount)
	FROM 	historyproceedsview 
	WHERE 	competencydate < @start
		AND ymov = @ayear
		AND ( (totflag & 1) =1) -- Residuo
		AND (idtreasurer = @idtreasurer		 or @idtreasurer is null)		
	
	DECLARE @var_payment_resid	decimal(19,2)
	SELECT  @var_payment_resid = SUM(EV.amount)
	FROM expensevar EV
	JOIN historypaymentview HPV
		ON HPV.idexp = EV.idexp
	WHERE EV.yvar = @ayear
	AND ( (HPV.totflag & 1) =1) -- Residuo
	AND HPV.ymov = @ayear
	AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)			
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
		AND ( (HPV.totflag & 1) =1) -- Residuo
		AND HPV.ymov = @ayear
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)			
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
IF(@idtreasurer is not null)  and (@includigirofondi = 'S')
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
		ISNULL(@var_payment_comp, 0)+
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
		operationorder 		int,		adate 			datetime, 	
		nmov 			int,		npro 			int,		
		docdate 		datetime,	registry 		varchar(100),	
		description 		varchar(200),	doc 			varchar(150),	
		codefin 		varchar(50),	codeupb 		varchar(50),	
		competency_proceeds 	decimal(19,2),	residual_proceeds 	decimal(19,2),	
		competency_payment 	decimal(19,2),	residual_payment 	decimal(19,2),	
		floatfund 		decimal(19,2),	idmov 			varchar(40),	
		autokind 		int,
	)

	INSERT INTO #journal
	(
		docdate,
		competency_proceeds,
		residual_proceeds,
		competency_payment,
		residual_payment,
		operationorder
	)
	VALUES
	(
		DATEADD(day, -1, @start),
		@tot_proceeds_comp,
		@tot_proceeds_resid,
		@tot_payment_comp,
		@tot_payment_resid,
		1
	)

	INSERT INTO #journal
	(
		adate,
		nmov,
		npro,
		docdate,
		registry,
		description,
		doc,
		codefin,  
		codeupb,
		competency_proceeds,
		residual_proceeds,
		idmov,
		operationorder
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
		fin.codefin,
		upb.codeupb,
		CASE WHEN ( (HPV.totflag & 1) =0)  then HPV.amount  ELSE NULL END,
		CASE WHEN ( (HPV.totflag & 1) =1) then HPV.amount  ELSE NULL END,
		HPV.idinc, 
		2
	FROM historyproceedsview HPV  
	JOIN fin
		ON fin.idfin = HPV.idfin
	JOIN registry
		ON registry.idreg = HPV.idreg
	JOIN upb
		ON upb.idupb = HPV.idupb
	WHERE HPV.competencydate BETWEEN @start AND @stop
		AND HPV.ymov 	= @ayear
		AND (HPV.idtreasurer = @idtreasurer		 or @idtreasurer is null)		

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
			codefin,  
			codeupb,
			competency_proceeds,
			residual_proceeds,
			idmov,
			operationorder
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
			fin.codefin,
			upb.codeupb,
			CASE WHEN ( (HPV.totflag & 1) =0)  then HPV.amount  ELSE NULL END,
			CASE WHEN ( (HPV.totflag & 1) =1) then HPV.amount  ELSE NULL END,
			HPV.idinc, 
			2
		FROM historyproceedsview HPV  
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE year(HPV.competencydate ) = @newxayear -- Considera gli incassi esitati l'anno successivo, come incassi esitati l'anno corrente affinchè influiscano sulla cassa dell'anno corrente
			AND HPV.ymov 	= @ayear
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
			codefin,
			codeupb,
			competency_proceeds,
			residual_proceeds,
			idmov,
			autokind,
			operationorder
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
				NULL
			END,
			fin.codefin, 
			upb.codeupb,
			CASE 
				WHEN ( (HPV.totflag & 1) =0) then IV.amount  ELSE NULL END,
			CASE 
				WHEN ( (HPV.totflag & 1) = 1) then IV.amount  ELSE NULL END,
			HPV.idinc, 
			IV.autokind,
			3
		FROM incomevar  IV
			JOIN historyproceedsview HPV 
				ON HPV.idinc = IV.idinc
				AND HPV.ymov = @ayear
			JOIN fin
				ON fin.idfin = HPV.idfin
			JOIN upb
				ON upb.idupb = HPV.idupb
			JOIN registry
				ON registry.idreg = HPV.idreg
		WHERE IV.yvar = @ayear
			AND isnull(IV.autokind,'') <>'22' 
			AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)			
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
		codefin,
		codeupb,
		competency_payment,
		residual_payment,
		idmov,
		operationorder
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
		NULL
		END,
		fin.codefin,
		upb.codeupb,
		CASE WHEN ( (HPV.totflag & 1) = 0) then HPV.amount  ELSE NULL END,
		CASE WHEN ( (HPV.totflag & 1) = 1) then HPV.amount  ELSE NULL END,
		HPV.idexp,
		4
		FROM historypaymentview HPV
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE 	HPV.ymov  = @ayear
			AND HPV.competencydate BETWEEN @start AND @stop
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
		codefin,
		codeupb,
		competency_payment,
		residual_payment,
		idmov,
		operationorder
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
		NULL
		END,
		fin.codefin,
		upb.codeupb,
		CASE WHEN ( (HPV.totflag & 1) = 0) then HPV.amount  ELSE NULL END,
		CASE WHEN ( (HPV.totflag & 1) = 1) then HPV.amount  ELSE NULL END,
		HPV.idexp,
		4
		FROM historypaymentview HPV
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE 	HPV.ymov  = @ayear
			and year(HPV.competencydate ) = @newxayear -- Considera i pagamenti esitati l'anno successivo, come pagamenti esitati l'anno corrente affinchè influiscano sulla cassa dell'anno corrente
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
			codefin,
			codeupb,
			competency_payment,
			residual_payment,
			idmov,
			autokind,
			operationorder
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
			fin.codefin,
			upb.codeupb,
			CASE WHEN ( (HPV.totflag & 1) = 0) then EV.amount  ELSE NULL END,
			CASE WHEN ( (HPV.totflag & 1) = 1) then EV.amount  ELSE NULL END,
			HPV.idexp, 
			EV.autokind,
			5
		FROM expensevar EV
		JOIN historypaymentview HPV
			ON HPV.idexp 	= EV.idexp
			AND  HPV.ymov 	= @ayear
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE EV.yvar = @ayear
		AND isnull(EV.autokind,'') <>'22' 
		AND (HPV.idtreasurer = @idtreasurer	 or @idtreasurer is null)			
		AND (
			(HPV.competencydate BETWEEN @start AND @stop
	  		AND ( 
				((EV.autokind <> 10) AND(EV.autokind <> 11)  ) 
				OR EV.autokind is null
	          		 )
			)
			OR
			(EV.adate  BETWEEN @start AND @stop
				AND ((EV.autokind = 10)OR(EV.autokind = 11)) 
			) 
		)
	END

-- Inseriamo i Girofondi 
IF((@idtreasurer is not null) and (@includigirofondi = 'S'))
Begin
	--> Girofondi - 
	INSERT INTO #journal
	(
		adate,docdate, -- devo per forza valorizzare docdate perchè il report raggruppa e quindi ordina per docdate, se non la valorizziamo,i girofondi sarnno sempre le prime op. del report
		nmov,
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
	WHERE ytransfer = @ayear AND idtreasurersource = @idtreasurer
		and adate  BETWEEN @start AND @stop
	--> Girofondi + 
	INSERT INTO #journal
	(
		adate,docdate,
		nmov,
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
	WHERE ytransfer = @ayear AND idtreasurerdest = @idtreasurer
		and adate  BETWEEN @start AND @stop
End
	
	UPDATE #journal
		SET floatfund = @floatfund

-- l'UPDATE viene fatto sulle righe delle variazioni	
	UPDATE #journal 
		SET docdate = adate
		WHERE 
		operationorder = 3
		AND
		((autokind = 10)OR(autokind=11))
	
	UPDATE #journal 
		SET docdate = adate
		WHERE 
		operationorder = 5
		AND 
		((autokind = 10)OR(autokind=11))
	
	DECLARE @descphase_proceeds	varchar(50)
	SELECT 	@descphase_proceeds 	= description FROM incomephase
		WHERE 	nphase = @codphase_proceeds

	DECLARE @descphase_payment	varchar(50)
	SELECT 	@descphase_payment 	= description FROM expensephase
		WHERE 	nphase = @codphase_payment

	DECLARE @treasurer_header varchar(150)
	SELECT @treasurer_header = header
	FROM treasurer
	where idtreasurer = @idtreasurer
	
	
	SELECT 
		adate,
		operationorder,
		(SELECT
	  	CASE
		   	 WHEN operationorder = 1 THEN  	'Tot.prec.'
			 WHEN operationorder = 2 THEN  	@descphase_proceeds
	 		 WHEN operationorder = 3 THEN  	'Var.' + @descphase_proceeds
			 WHEN operationorder = 4 THEN  	@descphase_payment
			 WHEN operationorder = 5 THEN	'Var.' + @descphase_payment
			 WHEN operationorder in (6,7) THEN	'Girofondo'
		    	 ELSE  NULL
	  	END)	as 'operationkind',
		nmov,
	    	npro,
		docdate,
		registry,
		description,
		doc,
		codefin,
		codeupb,
		competency_proceeds,
		residual_proceeds,
		competency_payment,
		residual_payment,
		floatfund,
		autokind,
		@treasurer_header as treasurer
	FROM 	#journal
	ORDER BY docdate ASC,
		 operationorder ASC,
		 npro ASC
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

