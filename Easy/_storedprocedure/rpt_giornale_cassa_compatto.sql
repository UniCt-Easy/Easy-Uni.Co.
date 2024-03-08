
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_giornale_cassa_compatto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_giornale_cassa_compatto]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

CREATE  PROCEDURE [rpt_giornale_cassa_compatto]
	@ayear				int,
	@start	 			datetime,
	@stop				datetime,
	@showupb			char(1),
	@includigirofondi	char(1),
	@idtreasurer		int,
	@documentiesitati char(1)--Considera tutti i mandati e reversali dell'esercizio esitati nell'esercizio
AS
BEGIN
---setuser 'amministrazione'
-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
-- exec rpt_giornale_cassa_compatto 2021, {ts '2021-02-22 00:00:00'}, {ts '2021-03-10 00:00:00'}, 'N','N', 16, 'N'
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
		operationorder		int,		adate			datetime,
		nmov			int,		description		varchar(200),
		codefin			varchar(50),	codeupb			varchar(50),
		registry		varchar(100),	npro			int,
		docdate			datetime,	doc                     varchar(150),
		competency_proceeds	decimal(19,2),	residual_proceeds	decimal(19,2),
		competency_payment	decimal(19,2),	residual_payment	decimal(19,2),
		floatfund		decimal(19,2),	idmov			varchar(40),
		autokind 		tinyint,	operationkind 		varchar(40),
		idfin int 
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
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) = 0) then HPV.amount  ELSE (NULL) END,
		CASE WHEN ( (totflag & 1) = 1) then HPV.amount  ELSE (NULL) END,
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
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) = 0) then HPV.amount  ELSE (NULL) END,
		CASE WHEN ( (totflag & 1) = 1) then HPV.amount  ELSE (NULL) END,
		HPV.idinc,
		2
	FROM historyproceedsview HPV
	JOIN fin
		ON fin.idfin = HPV.idfin
	JOIN registry
		ON registry.idreg = HPV.idreg
	JOIN upb
		ON upb.idupb = HPV.idupb
	WHERE  year(HPV.competencydate ) = @newxayear -- Considera gli incassi esitati l'anno successivo, come incassi esitati l'anno corrente affinchè influiscano sulla cassa dell'anno corrente
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
			3
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
		(NULL)
		END,
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) =0) then HPV.amount  ELSE NULL END,
		CASE WHEN ( (totflag & 1) =1) then HPV.amount  ELSE NULL END,
		HPV.idexp,
		4
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
		(NULL)
		END,
		fin.codefin,HPV.idfin,
		upb.codeupb,
		CASE WHEN ( (totflag & 1) =0) then HPV.amount  ELSE NULL END,
		CASE WHEN ( (totflag & 1) =1) then HPV.amount  ELSE NULL END,
		HPV.idexp,
		4
		FROM historypaymentview HPV
		JOIN fin
			ON fin.idfin = HPV.idfin
		JOIN registry
			ON registry.idreg = HPV.idreg
		JOIN upb
			ON upb.idupb = HPV.idupb
		WHERE  year(HPV.competencydate ) = @newxayear -- Considera i pagamenti esitati l'anno successivo, come pagamenti esitati l'anno corrente affinchè influiscano sulla cassa dell'anno corrente
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
			fin.codefin,HPV.idfin,
			upb.codeupb,
			CASE WHEN ( (totflag & 1) =0) then EV.amount  ELSE (NULL) END,
			CASE WHEN ( (totflag & 1) =1) then EV.amount  ELSE (NULL) END,
			HPV.idexp,
			EV.autokind,
			5
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

	-- Inseriamo i Girofondi 
IF ((@idtreasurer is not null) and (@includigirofondi = 'S'))
Begin
	--> Girofondi - 
	INSERT INTO #journal
	(
		adate,docdate,-- devo per forza valorizzare docdate perchè il report raggruppa e quindi ordina per docdate, se non la valorizziamo,i girofondi sarnno sempre le prime op. del report
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
		npro			int,
		docdate			datetime,
		registry		varchar(100),
		description		varchar(6000),
		doc                     varchar(1000), 
		idfin int, 
		codeupb			varchar(50),
		competency_proceeds	decimal(19,2),
		residual_proceeds	decimal(19,2),
		competency_payment	decimal(19,2),
		residual_payment	decimal(19,2),
		floatfund		decimal(19,2),
		autokind 		tinyint
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
		registry,
		autokind	
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
		registry,
		autokind	
	FROM  	#journal
	JOIN finlink FLK
		ON #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel
	GROUP BY docdate,npro,codeupb, FLK.idparent, 
		 floatfund,operationorder,registry,
		autokind	
	
	--SELECT * FROM #journal order by npro
	--SELECT * FROM #journalcompact order by npro

	--------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------
	--------------------------------------------------------------------------------------------------------------
	DECLARE @npro 			int
	DECLARE @description 		varchar(200)
	DECLARE @doc 			varchar(200) 
	DECLARE @operationorder 	int
	DECLARE @registry 		varchar(100)		
	DECLARE @autokind 		tinyint
	DECLARE @codefin		varchar(50)	
	DECLARE @idfinparent 		int	
	DECLARE @codeupb		varchar(50)		
	DECLARE @descriptioncompact 	varchar(8000) 
	DECLARE rowcursor INSENSITIVE CURSOR FOR
	SELECT 	npro,description,operationorder,registry,doc,
			autokind,FLK.idparent, 
			codeupb 
		FROM #journal 
		JOIN finlink FLK
			ON #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel
			 WHERE ((SELECT COUNT(description) FROM #journal J1 
	 WHERE #journal.npro = J1.npro AND #journal.operationorder = J1.operationorder
	 AND #journal.idfin = J1.idfin AND #journal.codeupb = J1.codeupb 
	 group by  J1.npro,J1.operationorder, J1.idfin, 
	J1.codeupb ) >1
	 or
	(SELECT COUNT(doc) FROM #journal J1 
	 WHERE #journal.npro = J1.npro AND #journal.operationorder = J1.operationorder
	 AND #journal.idfin = J1.idfin AND #journal.codeupb = J1.codeupb 
	 group by  J1.npro,J1.operationorder, J1.idfin, 
	J1.codeupb ) >1 
	)
	FOR READ ONLY
	
	OPEN rowcursor FETCH  NEXT FROM rowcursor 
	INTO @npro,@description,@operationorder,@registry,
	@doc,@autokind,@idfinparent, 
	@codeupb 
	WHILE @@FETCH_STATUS = 0
		BEGIN 
			
			UPDATE #journalcompact 
			SET	@descriptioncompact = ISNULL(#journalcompact.description,'')+@description,
			doc = SUBSTRING(ISNULL(doc,'') +@doc+';',1,1000)
			
			WHERE 	(npro = @npro and operationorder = @operationorder 
				and idfin = @idfinparent
				and codeupb = @codeupb 	
				and registry = @registry			
				)
			 	 
			IF PATINDEX('%'+@description+';%',@descriptioncompact)=0
			UPDATE #journalcompact 
			SET description = SUBSTRING(ISNULL(description,'') + @description + ';',1,6000)
			WHERE (npro=@npro and operationorder=@operationorder 
				and idfin = @idfinparent
				and codeupb=@codeupb
				and registry = @registry 				
				)
 
			FETCH NEXT FROM rowcursor INTO  @npro,@description,@operationorder,@registry,@doc,@autokind,@idfinparent, 
					@codeupb
		END 
	DEALLOCATE rowcursor

	---SELECT * FROM #journalcompact WHERE description is not null
	UPDATE #journalcompact  SET description = (SELECT description FROM #journal WHERE #journal.npro = #journalcompact.npro AND #journal.operationorder = #journalcompact.operationorder
	AND	   #journalcompact.idfin = (SELECT FLK.idparent FROM  finlink FLK WHERE  #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel) AND #journal.codeupb = #journalcompact.codeupb
	AND #journal.registry = #journalcompact.registry
	AND description IS NOT NULL)
	WHERE #journalcompact.description IS NULL
	AND (SELECT COUNT(*) FROM #journal WHERE #journal.npro = #journalcompact.npro AND #journal.operationorder = #journalcompact.operationorder
	AND	   #journalcompact.idfin = (SELECT FLK.idparent FROM  finlink FLK WHERE  #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel) AND #journal.codeupb = #journalcompact.codeupb
	AND #journal.registry = #journalcompact.registry
	AND description IS NOT NULL
	--group by  J1.npro,J1.operationorder, #journalcompact.idfin, J1.codeupb 
	) = 1

	UPDATE #journalcompact  SET doc = (SELECT doc FROM #journal WHERE #journal.npro = #journalcompact.npro AND #journal.operationorder = #journalcompact.operationorder
	AND	   #journalcompact.idfin = (SELECT FLK.idparent FROM  finlink FLK WHERE  #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel) AND #journal.codeupb = #journalcompact.codeupb
	AND #journal.registry = #journalcompact.registry
	AND doc IS NOT NULL)
	WHERE #journalcompact.doc IS NULL
	AND (SELECT COUNT(*) FROM #journal WHERE #journal.npro = #journalcompact.npro AND #journal.operationorder = #journalcompact.operationorder
	AND	   #journalcompact.idfin = (SELECT FLK.idparent FROM  finlink FLK WHERE  #journal.idfin = FLK.idchild and FLK.nlevel =@minlevel) AND #journal.codeupb = #journalcompact.codeupb
	AND #journal.registry = #journalcompact.registry
	AND doc IS NOT NULL
	--group by  J1.npro,J1.operationorder, #journalcompact.idfin, J1.codeupb 
	) = 1

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
		floatfund		,
		autokind )
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
		@floatfund,null
	)

		--Aggiungo i girofondi, perchè non hanno bilancio/upb
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
		doc,
		fin.codefin,
		codeupb,
		competency_proceeds,
		residual_proceeds,
		competency_payment,
		residual_payment,
		floatfund,
		autokind ,	
		@treasurer_header as treasurer
	FROM 	#journalcompact 		
	LEFT OUTER join fin 
		ON #journalcompact.idfin = fin.idfin
	ORDER BY 
		docdate ASC,
		operationorder ASC,
		npro ASC,
		registry ASC

END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




