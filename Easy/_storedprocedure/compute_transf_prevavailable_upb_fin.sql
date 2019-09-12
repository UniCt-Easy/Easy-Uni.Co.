
if exists (select * from dbo.sysobjects where id = object_id(N'[compute_transf_prevavailable_upb_fin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_transf_prevavailable_upb_fin]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE compute_transf_prevavailable_upb_fin
(
	@ayear int,
	@date datetime
)
AS BEGIN
-- exec compute_transf_prevavailable_upb_fin 2011,  {ts '2011-12-18 00:00:00'}
DECLARE @fin_kind tinyint
SELECT  @fin_kind = ISNULL(fin_kind,0) FROM config WHERE ayear = @ayear

DECLARE @finincomephase tinyint
DECLARE @finexpensephase tinyint

DECLARE @maxincomephase tinyint
DECLARE @maxexpensephase tinyint

DECLARE @upblibero varchar(150)
SELECT  @upblibero = ISNULL(title,'') FROM upb WHERE idupb = '0001'


CREATE TABLE #previsionupbfin
(
	idupb varchar(36),
	idfin int,
	incomeprevavailable_comp decimal(19,2),	
	incomeprevavailable_cash decimal(19,2),
	expenseprevavailable_comp decimal(19,2),
	expenseprevavailable_cash decimal(19,2)
)

SELECT @finexpensephase = expensefinphase FROM uniconfig
SELECT @finincomephase  = incomefinphase FROM uniconfig

SELECT @maxexpensephase = MAX (nphase) FROM expensephase
SELECT @maxincomephase  = MAX (nphase) FROM incomephase

IF @fin_kind = 1 
BEGIN
	INSERT INTO #previsionupbfin
	(
		
		idupb,
		idfin,
		incomeprevavailable_comp
	)
	SELECT 
		
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentprev,0) + 
			ISNULL(UT.previsionvariation,0) - 
			ISNULL(UET.totalcompetency,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbincometotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @finincomephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) = 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb, FL.newidfin
	HAVING SUM( ISNULL(UT.currentprev,0) + 
		    ISNULL(UT.previsionvariation,0) - 
		    ISNULL(UET.totalcompetency,0)) <>0
	
	INSERT INTO #previsionupbfin
	(
		
		idupb,
		idfin,
		expenseprevavailable_comp
	)
	SELECT 
		
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentprev,0) + 
			ISNULL(UT.previsionvariation,0) - 
			ISNULL(UET.totalcompetency,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbexpensetotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @finexpensephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) <> 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb, FL.newidfin
	HAVING SUM( ISNULL(UT.currentprev,0) + 
		    ISNULL(UT.previsionvariation,0) - 
		    ISNULL(UET.totalcompetency,0)) <>0
END

IF @fin_kind = 2 
BEGIN
	INSERT INTO #previsionupbfin
	(
		idupb,
		idfin,
		incomeprevavailable_cash
	)
	SELECT 
		
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentprev,0) + 
			ISNULL(UT.previsionvariation,0) - 
			ISNULL(UET.totalcompetency,0) -
			ISNULL(UET.totalarrears,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbincometotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxincomephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN  finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) = 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb, FL.newidfin
	HAVING SUM( ISNULL(UT.currentprev,0) + 
		    ISNULL(UT.previsionvariation,0) - 
		    ISNULL(UET.totalcompetency,0) -
		    ISNULL(UET.totalarrears,0)) <>0
	
	INSERT INTO #previsionupbfin
	(
		idupb,
		idfin,
		expenseprevavailable_cash
	)
	SELECT 
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentprev,0) + 
			ISNULL(UT.previsionvariation,0) - 
			ISNULL(UET.totalcompetency,0) -
			ISNULL(UET.totalarrears,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbexpensetotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxexpensephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) <> 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb, FL.newidfin
	HAVING SUM( ISNULL(UT.currentprev,0) + 
		    ISNULL(UT.previsionvariation,0) - 
		    ISNULL(UET.totalcompetency,0) -
		    ISNULL(UET.totalarrears,0)) <>0
END


IF @fin_kind = 3 
BEGIN
	
	INSERT INTO #previsionupbfin
	(
		
		idupb,
		idfin,
		incomeprevavailable_comp
	)
	SELECT 
		
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentprev,0) + 
			ISNULL(UT.previsionvariation,0) - 
			ISNULL(UET.totalcompetency,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbincometotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @finincomephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) = 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb,FL.newidfin
	HAVING SUM( ISNULL(UT.currentprev,0) + 
		    ISNULL(UT.previsionvariation,0) - 
		    ISNULL(UET.totalcompetency,0)) <>0
	
	INSERT INTO #previsionupbfin
	(
		
		idupb,
		idfin,
		expenseprevavailable_comp
	)
	SELECT 
		
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentprev,0) + 
			ISNULL(UT.previsionvariation,0) - 
			ISNULL(UET.totalcompetency,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbexpensetotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @finexpensephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) <> 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb, FL.newidfin
	HAVING SUM( ISNULL(UT.currentprev,0) + 
		    ISNULL(UT.previsionvariation,0) - 
		    ISNULL(UET.totalcompetency,0)) <>0
	
	INSERT INTO #previsionupbfin
	(
		
		idupb,
		idfin,
		incomeprevavailable_cash
	)
	SELECT 
		
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentsecondaryprev,0) + 
			ISNULL(UT.secondaryvariation,0) - 
			ISNULL(UET.totalcompetency,0) -
			ISNULL(UET.totalarrears,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbincometotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxincomephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) = 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb,FL.newidfin
	HAVING SUM(
			ISNULL(UT.currentsecondaryprev,0) + 
			ISNULL(UT.secondaryvariation,0) - 
			ISNULL(UET.totalcompetency,0) -
			ISNULL(UET.totalarrears,0)) <>0
	
	INSERT INTO #previsionupbfin
	(
		
		idupb,
		idfin,
		expenseprevavailable_cash
	)
	SELECT 
		
		UT.idupb,
		FL.newidfin,
		SUM(
			ISNULL(UT.currentsecondaryprev,0) + 
			ISNULL(UT.secondaryvariation,0) - 
			ISNULL(UET.totalcompetency,0) -
			ISNULL(UET.totalarrears,0))
	
		FROM  upbtotal UT 
		LEFT  OUTER JOIN upbexpensetotal UET 
			ON UET.idfin = UT.idfin
			AND UET.idupb = UT.idupb
			AND UET.nphase = @maxexpensephase
		JOIN  fin F ON UT.idfin = F.idfin
		JOIN finlookup FL ON FL.oldidfin = F.idfin
		JOIN finlast FS ON FS.idfin = F.idfin 
		WHERE  ((F.flag & 1) <> 0) AND F.ayear = @ayear
		AND UT.idupb <> '0001'
	GROUP BY UT.idupb, FL.newidfin
	HAVING SUM(
			ISNULL(UT.currentsecondaryprev,0) + 
			ISNULL(UT.secondaryvariation,0) - 
			ISNULL(UET.totalcompetency,0) -
			ISNULL(UET.totalarrears,0)) <>0
	
END


IF ((SELECT COUNT(*) FROM #previsionupbfin) > 0) 
BEGIN
PRINT 'OK'
--SELECT * FROM #previsionupbfin

-- CREO LE VARIAZIONI DI PREVISIONE NON UFFICIALI NEL NUOVO ESERCIZIO
DECLARE @nextayear int
SET 	@nextayear = @ayear + 1

DECLARE @gen_01 datetime
SELECT  @gen_01 = CONVERT(datetime, '01-01-' + CONVERT(char(4), @nextayear), 105)


DECLARE @nvar   int 
SET 	@nvar = ISNULL((SELECT MAX(nvar) FROM finvar WHERE yvar = @nextayear),0) +1
PRINT 	@nvar


IF ((SELECT COUNT(*) FROM #previsionupbfin WHERE ISNULL(idfin,0) = 0) > 0)  
BEGIN
	PRINT 'VOCI DI BILANCIO NON ATTUALIZZATE'
	RETURN
END

CREATE TABLE #FinvardetailTemp(
	nvar	int,
	yvar	smallint,
	rownum int identity(1,1),
	idfin	int,
	idupb	varchar(36),
	amount	decimal(19,2),
	description	varchar(150),
	ct	datetime,
	cu	varchar(64),
	lt	datetime,
	lu	varchar(64)
)

IF (@fin_kind = 1 )  -- CREO UNA VARIAZIONE DI COMPETENZA
BEGIN
	
	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(incomeprevavailable_comp,0),
	GetDate(),'assistenza', 'Disponibilità ad accertare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(incomeprevavailable_comp,0)<>0
	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(expenseprevavailable_comp,0),
	GetDate(),'assistenza', 'Disponibilità a impegnare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(expenseprevavailable_comp,0)<>0
	
	
	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(incomeprevavailable_comp),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero, GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(incomeprevavailable_comp),0)<>0

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(expenseprevavailable_comp),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero, GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(expenseprevavailable_comp),0)<>0
	
	IF (select count(*) from #FinvardetailTemp)>0 
	BEGIN
		INSERT INTO finvar
		(nvar,yvar,adate,ct,cu,description, 
		enactment,enactmentdate,flagcredit,flagprevision, 
		flagproceeds,flagsecondaryprev,lt,lu,nenactment, 
		rtf,txt,official,nofficial,variationkind,idfinvarstatus)
		SELECT @nvar, @nextayear,@gen_01,GetDate(),'assistenza','Trasferimento previsioni competenza disponibili',
		null,null,'N','S','N','N',GetDate(),'assistenza',null,
		null,null,'N',null,4,5
		
		INSERT INTO finvardetail (idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin) 
		SELECT idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin 
		FROM #FinvardetailTemp
	END
	
END

IF (@fin_kind = 2 )  -- CREO UNA VARIAZIONE DI CASSA
BEGIN
	
	
	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(incomeprevavailable_cash,0),
	GetDate(),'assistenza', 'Disponibilità ad incassare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(incomeprevavailable_cash,0)<>0
	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(expenseprevavailable_cash,0),
	GetDate(),'assistenza', 'Disponibilità a pagare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(expenseprevavailable_cash,0)<>0
	
	
	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(incomeprevavailable_cash),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero, GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(incomeprevavailable_cash),0)<>0
	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(expenseprevavailable_cash),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero, GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(expenseprevavailable_cash),0)<>0
	
	IF (select count(*) from #FinvardetailTemp)>0 
	BEGIN
		INSERT INTO finvar
		(nvar,yvar,adate,ct,cu,description, 
		enactment,enactmentdate,flagcredit,flagprevision, 
		flagproceeds,flagsecondaryprev,lt,lu,nenactment, 
		rtf,txt,official,nofficial,variationkind, idfinvarstatus)
		SELECT @nvar, @nextayear,@gen_01,GetDate(),'assistenza','Trasferimento previsioni cassa disponibili',
		null,null,'N','S','N','N',GetDate(),'assistenza',null,
		null,null,'N',null,4,5
		
		INSERT INTO finvardetail (idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin) 
		SELECT idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin 
		FROM #FinvardetailTemp
	END
	
END

IF (@fin_kind = 3 )  -- CREO UNA VARIAZIONE DI COMPETENZA E UNA DI CASSA
BEGIN
	
-- Crea 1° variazione, quella COMPETENZA	
	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(incomeprevavailable_comp,0),
	GetDate(),'assistenza', 'Disponibilità ad accertare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(incomeprevavailable_comp,0)<>0	
	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(expenseprevavailable_comp,0),
	GetDate(),'assistenza', 'Disponibilità a impegnare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(expenseprevavailable_comp,0)<>0	
	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(incomeprevavailable_comp),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero , GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(incomeprevavailable_comp),0)<>0	

	
	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(expenseprevavailable_comp),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero , GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(expenseprevavailable_comp),0)<>0	
	
	IF (select count(*) from #FinvardetailTemp)>0 
	BEGIN
		INSERT INTO finvar
		(nvar,yvar,adate,ct,cu,description, 
		enactment,enactmentdate,flagcredit,flagprevision, 
		flagproceeds,flagsecondaryprev,lt,lu,nenactment, 
		rtf,txt,official,nofficial,variationkind,idfinvarstatus)
		SELECT @nvar, @nextayear,@gen_01 ,GetDate(),'assistenza','Trasferimento previsioni competenza disponibili',
		null,null,'N','S','N','N',GetDate(),'assistenza',null,
		null,null,'N',null,4,5
		
		INSERT INTO finvardetail (idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin) 
		SELECT idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin 
		FROM #FinvardetailTemp
	END

-- Crea 2° variazione, quella CASSA

	SET @nvar = (SELECT MAX(nvar) FROM finvar WHERE yvar = @nextayear) +1
	
	DELETE FROM #FinvardetailTemp
	
	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(incomeprevavailable_cash,0),
	GetDate(),'assistenza', 'Disponibilità a incassare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(incomeprevavailable_cash,0)<>0	
	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb fondi ricerca
	SELECT idupb, @nvar, @nextayear, ISNULL(expenseprevavailable_cash,0),
	GetDate(),'assistenza', 'Disponibilità a pagare', GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	WHERE  ISNULL(expenseprevavailable_cash,0)<>0	
	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(incomeprevavailable_cash),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero, GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(incomeprevavailable_cash),0)<>0	

	INSERT INTO #FinvardetailTemp
	(idupb, nvar, yvar, amount, ct, cu, 
	 description, lt, lu, idfin) -- upb dipartimento
	SELECT '0001', @nvar, @nextayear, - ISNULL(SUM(expenseprevavailable_cash),0),
	GetDate(),'assistenza', 'Storno da UPB ' + @upblibero, GetDate(),'assistenza',
	idfin
	FROM   #previsionupbfin 
	GROUP  BY idfin
	HAVING ISNULL(SUM(expenseprevavailable_cash),0)<>0	
	
	IF (select count(*) from #FinvardetailTemp) >0 
	BEGIN
		INSERT INTO finvar
		(nvar,yvar,adate,ct,cu,description, 
		enactment,enactmentdate,flagcredit,flagprevision, 
		flagproceeds,flagsecondaryprev,lt,lu,nenactment, 
		rtf,txt,official,nofficial,variationkind,idfinvarstatus)
		SELECT @nvar, @nextayear,@gen_01 ,GetDate(),'assistenza','Trasferimento previsioni cassa disponibili',
		null,null,'N','N','N','S',GetDate(),'assistenza',null,
		null,null,'N',null,4,5

		INSERT INTO finvardetail (idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin) 
		SELECT idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin 
		FROM #FinvardetailTemp

	END
END

END
ELSE
	PRINT 'NON CI SONO PREVISIONI DA TRASFERIRE'


END

GO



