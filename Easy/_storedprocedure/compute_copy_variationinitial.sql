SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
if exists (select * from dbo.sysobjects where id = object_id(N'[compute_copy_variationinitial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_copy_variationinitial]
GO

CREATE PROCEDURE compute_copy_variationinitial
(
	@ayear int,
	@date datetime,
	@copia_prev_precente char(1)
)
AS BEGIN

-- exec compute_copy_variationinitial 2015, {ts '2015-12-31 00:00:00'},'S'

DECLARE @levelusable tinyint
SELECT  @levelusable = MAX(nlevel) FROM finlevel WHERE ayear = @ayear


-- Se @fin_kind = 1 ==>  "competenza",
-- se @fin_kind = 2 ==> "cassa", 
-- se  @fin_kind = 3 ==> "competenza e cassa"
DECLARE @fin_kind tinyint
SELECT @fin_kind = ISNULL(fin_kind,0) FROM config WHERE ayear = @ayear


DECLARE @minlivop tinyint
DECLARE @maxlivop tinyint

SELECT @minlivop = isnull(MIN(nlevel),1) FROM finlevel WHERE flag&2 <> 0 AND ayear = @ayear
SELECT @maxlivop = MAX(nlevel) FROM finlevel WHERE ayear = @ayear


CREATE TABLE #initialvariation
(
	idupb varchar(36),
	idfin int,
	prevision decimal (19,2),
	secondaryprev decimal (19,2),
	prevision2 decimal (19,2),
	prevision3 decimal (19,2),
	residual decimal(19,2),
	previousprevision decimal(19,2),
	previoussecondaryprev decimal(19,2)
)

INSERT INTO #initialvariation(
	idupb,	idfin,	prevision,secondaryprev,prevision2,prevision3, residual,previousprevision,previoussecondaryprev
)
select  D.idupb, FL.idparent, 
		sum(case when V.flagprevision = 'S' then isnull(D.amount,0) else 0 end) , 
		sum(case when V.flagsecondaryprev = 'S' AND @fin_kind = 3 then isnull(D.amount,0) else 0 end),
		sum(case when V.flagprevision = 'S' then isnull(D.prevision2,0) else 0 end) , 
		sum(case when V.flagprevision = 'S' then isnull(D.prevision3,0) else 0 end) ,
		sum(ISNULL(D.residual,0)),
		sum(case when V.flagprevision = 'S' then isnull(D.previousprevision,0) else 0 end),
		sum(case when V.flagsecondaryprev = 'S' then isnull(D.previousprevision,0) else 0 end)
	from finvar V
	JOIN finvardetail D 	ON V.yvar = D.yvar
							AND V.nvar = D.nvar	
	join finlink FL on FL.idchild= D.idfin
WHERE  V.yvar = @ayear
		AND V.adate <= @date
		AND (V.flagsecondaryprev = 'S' OR V.flagprevision = 'S')
		AND V.idfinvarstatus = 5 
		AND V.variationkind = 5
		AND FL.nlevel>= @minlivop
GROUP BY D.idupb, FL.idparent

 

DECLARE @curridupb varchar(36)
DECLARE @curridfin int
DECLARE @newprevision decimal(19,2)
DECLARE @newprevision2 decimal(19,2)
DECLARE @newprevision3 decimal(19,2)
DECLARE @newsecondaryprev decimal(19,2)
DECLARE @newresidual decimal(19,2)
DECLARE @newpreviousprevision decimal(19,2)
DECLARE @newprevioussecondaryprev decimal(19,2)
DECLARE @pa decimal(19,2)

DECLARE #crs INSENSITIVE CURSOR FOR
SELECT
	idupb,
	idfin,
	prevision,
	secondaryprev,
	prevision2,
	prevision3,
	residual,
	previousprevision,
	previoussecondaryprev
FROM #initialvariation 

ORDER BY LEN(idupb)

FOR READ ONLY

OPEN #crs
FETCH NEXT FROM #crs INTO @curridupb, @curridfin, @newprevision, @newsecondaryprev,@newprevision2,@newprevision3,@newresidual,
			@newpreviousprevision,@newprevioussecondaryprev

WHILE (@@FETCH_STATUS = 0)
BEGIN
	IF (SELECT COUNT(*) FROM finyear WHERE idupb = @curridupb AND idfin = @curridfin) > 0
	BEGIN

		IF (@fin_kind = 3)
		BEGIN
			UPDATE finyear SET
				prevision = @newprevision,
				secondaryprev = @newsecondaryprev,
				currentarrears = @newresidual,
				prevision2 = @newprevision2,
				prevision3 = @newprevision3,
				lt = GetDate(),
				lu = 'COPIAMANUALE'
			WHERE finyear.idupb = @curridupb
				AND finyear.idfin = @curridfin
		END
		ELSE
		BEGIN
			UPDATE finyear SET
				prevision = @newprevision,
				currentarrears = @newresidual,
				prevision2 = @newprevision2,
				prevision3 = @newprevision3,
				lt = GetDate(),
				lu = 'COPIAMANUALE'
			WHERE finyear.idupb = @curridupb
				AND finyear.idfin = @curridfin
		END
		if(@copia_prev_precente = 'S')
		Begin
			UPDATE finyear SET	
								previousprevision= @newpreviousprevision, 
								previoussecondaryprev= @newprevioussecondaryprev
			WHERE finyear.idupb = @curridupb
				AND finyear.idfin = @curridfin

		End

	END
	ELSE
	BEGIN
		IF (@fin_kind = 3)
		BEGIN
			INSERT INTO finyear
			(
				ayear, idupb, idfin,
				prevision, secondaryprev, prevision2,prevision3, 
							currentarrears ,previousprevision,previoussecondaryprev,
							ct, cu, lt, lu
			)
			VALUES
			(
				@ayear, @curridupb, @curridfin, 
				@newprevision, @newsecondaryprev, @newprevision2,@newprevision3,
							@newresidual,@newpreviousprevision,@newprevioussecondaryprev,
							GETDATE(), 'COPIAMANUALE', GETDATE(), 'COPIAMANUALE'
			)
		END
		ELSE
		BEGIN
			INSERT INTO finyear
			(
				ayear, idupb, idfin,
				prevision, prevision2,prevision3,currentarrears,previousprevision,previoussecondaryprev,
				ct, cu, lt, lu
			)
			VALUES
			(
				@ayear, @curridupb, @curridfin, 
				@newprevision, @newprevision2,@newprevision3,@newresidual,@newpreviousprevision,@newprevioussecondaryprev,
				GETDATE(), 'COPIAMANUALE', GETDATE(), 'COPIAMANUALE'
			)
		END
	END
	FETCH NEXT FROM #crs INTO @curridupb, @curridfin, @newprevision, @newsecondaryprev,@newprevision2,@newprevision3,
					@newresidual,@newpreviousprevision,@newprevioussecondaryprev
	END
CLOSE #crs
DEALLOCATE #crs


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
