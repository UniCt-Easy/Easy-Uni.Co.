
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






SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_currentfloatfund]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_currentfloatfund]
GO

CREATE   PROCEDURE [rebuild_currentfloatfund]
(
	@ayear int = NULL
)
AS BEGIN

DECLARE @startfloatfund decimal(19,2)
DECLARE @previsionkind char(1)
DECLARE @secprevisionkind char(1)
DECLARE @fin_kind tinyint

DECLARE @locked char(1)

DECLARE @maxexpensephase tinyint
SELECT  @maxexpensephase = MAX(nphase) FROM expensephase

DECLARE @maxincomephase tinyint
SELECT  @maxincomephase = MAX(nphase) FROM incomephase
print 'begin'


IF (@ayear IS NOT NULL)
BEGIN
	declare @value decimal(19,2)

	DELETE FROM currentcashtotal WHERE ayear = @ayear
	set @locked='N'
	SELECT @locked = locked from surplus where ayear = @ayear
	SET @locked= ISNULL(@locked,'N')

	SELECT @fin_kind = ISNULL(fin_kind,0)  FROM config WHERE ayear = @ayear

	--calcola lo START FLOAT FUND
	IF ( (@fin_kind<>1) and  (select count(*) from fin where ayear=@ayear and (flag&16 <>0) )>0			
		)
	BEGIN
		IF (@fin_kind = 3)
		BEGIN
			SET @startfloatfund =
			ISNULL(
				(SELECT 
				SUM(finyear.secondaryprev) 
				FROM finyear
				join fin F on F.idfin=finyear.idfin
				WHERE finyear.ayear=@ayear and (F.flag&16 <>0) )
			,0)

			SELECT @startfloatfund = 
			@startfloatfund +
			ISNULL(
				(SELECT SUM(d.amount) 
				FROM finvardetail d
				join fin f on d.idfin=f.idfin
				JOIN finvar v
					ON v.yvar = d.yvar
					AND v.nvar = d.nvar
				WHERE (v.flagsecondaryprev = 'S') AND  (F.flag & 16 <>0) and (v.yvar=@ayear)
				       AND (v.idfinvarstatus = 5))
			,0)
		END

		IF (@fin_kind = 2)
		BEGIN
			SET @startfloatfund =
			ISNULL(
				(SELECT SUM(finyear.prevision)
				FROM finyear
					join fin F on F.idfin=finyear.idfin
					WHERE  finyear.ayear=@ayear and (F.flag&16 <>0) )
			,0)
	
			SELECT @startfloatfund = 
			@startfloatfund +
				ISNULL(
					(SELECT SUM(d.amount) 
					FROM finvardetail d
					join fin f on d.idfin=f.idfin
					JOIN finvar v
						ON v.yvar = d.yvar
						AND v.nvar = d.nvar
					WHERE (v.flagprevision = 'S') AND   (F.flag & 16 <>0) and (v.yvar=@ayear)
					      AND (v.idfinvarstatus = 5))
				,0)
		END
	END
	ELSE
	BEGIN
		-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
		SELECT @startfloatfund = ISNULL(startfloatfund,0) 
		FROM surplus WHERE ayear = @ayear
	END
	print 'ayear:'
	print @ayear

	INSERT INTO currentcashtotal VALUES(@ayear,ISNULL(@startfloatfund,0))
	print 'start found:'
	print @startfloatfund

	IF ((@locked='S') OR (SELECT COUNT(*) FROM fin WHERE ayear = @ayear) = 0 )
	BEGIN
		UPDATE  currentcashtotal
			SET currentfloatfund =  (SELECT
			 (ISNULL(startfloatfund,0) + 
			  ISNULL(competencyproceeds,0) + 
			  ISNULL(residualproceeds,0) - 
			  ISNULL(competencypayments,0) - 
			  ISNULL(residualpayments,0))
			FROM surplus WHERE ayear = @ayear)
		WHERE ayear = @ayear
	END
	ELSE
	BEGIN
		set @value= 0
		select  @value = SUM(i.curramount)
				FROM incometotal i 
				JOIN incomelast IL		ON IL.idinc = i.idinc
				JOIN proceeds p			ON p.kpro=IL.kpro
				JOIN proceedstransmission pt			ON p.kproceedstransmission=pt.kproceedstransmission
				WHERE i.ayear = @ayear

		UPDATE currentcashtotal
			SET currentfloatfund = currentfloatfund +	ISNULL(@value,0)		WHERE ayear = @ayear
		print 'income found:'
		print @value

		set @value= 0
		select  @value = SUM(i.curramount)
				FROM expenselast EL
				JOIN expensetotal i		ON EL.idexp = i.idexp
				WHERE i.ayear = @ayear

		print 'expense found:'
		print @value

		UPDATE currentcashtotal SET currentfloatfund = currentfloatfund -ISNULL(@value,0)	WHERE ayear = @ayear
	END
	
END	
ELSE -- @ayear non specificato
BEGIN
	DELETE FROM currentcashtotal
	DECLARE @ycursor int
	DECLARE fc INSENSITIVE CURSOR FOR
	SELECT ayear FROM accountingyear
	FOR READ ONLY
	OPEN fc

	FETCH NEXT FROM fc INTO @ycursor
	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		print 'ayear:'
		print @ycursor
		
		set @locked='N'
		SELECT @locked = locked from surplus where ayear = @ycursor
		SET @locked= ISNULL(@locked,'N')

		SELECT	@fin_kind = ISNULL(fin_kind, 0) FROM config WHERE ayear = @ycursor

		IF ((@fin_kind<>1) AND (select count(*) from fin where ayear=@ayear and (flag&16 <>0))>0)
		BEGIN
			IF (@fin_kind = 3)
			BEGIN
				SET  @startfloatfund = ISNULL(
					(SELECT SUM(finyear.secondaryprev)
					FROM finyear 
					join fin F on F.idfin=finyear.idfin
					WHERE finyear.ayear = @ayear and (F.flag&16 <>0)
							)
					,0)
				SELECT @startfloatfund = 
				@startfloatfund +
				ISNULL(
					(SELECT SUM(d.amount) 
					FROM finvardetail d
					join fin F on F.idfin=d.idfin
					JOIN finvar v
						ON v.yvar = d.yvar
						AND v.nvar = d.nvar
					WHERE (F.flag&16 <>0) and v.yvar=@ayear
						AND (v.flagsecondaryprev = 'S')
						AND (v.idfinvarstatus = 5))
				,0)
			END
			IF (@fin_kind = 2)
			BEGIN
				SET @startfloatfund = ISNULL(
					(SELECT SUM(finyear.prevision)
					FROM finyear
					join fin F on F.idfin=finyear.idfin
					WHERE  finyear.ayear = @ayear and (F.flag&16 <>0) )
					,0)

				SELECT @startfloatfund = 
				@startfloatfund +
				ISNULL(
					(SELECT SUM(d.amount) 
					FROM finvardetail d
					join fin F on F.idfin=d.idfin
					JOIN finvar v
						ON v.yvar = d.yvar
						AND v.nvar = d.nvar
					WHERE (F.flag&16 <>0) and ( v.yvar=@ayear)
						AND (v.flagprevision= 'S')
						AND (v.idfinvarstatus = 5))
				,0)
			END
		END
		ELSE
		BEGIN
			SELECT @startfloatfund = ISNULL(startfloatfund,0) 
			FROM surplus WHERE ayear = @ycursor 
		END		

		INSERT INTO currentcashtotal VALUES(@ycursor,ISNULL(@startfloatfund,0))
		print 'start found:'
		print @startfloatfund


		
		IF ((@locked='S') OR (SELECT COUNT(*) FROM fin WHERE ayear = @ycursor) = 0 )
		BEGIN
			UPDATE  currentcashtotal
				SET currentfloatfund =  (SELECT
				 (ISNULL(startfloatfund,0) + 
				  ISNULL(competencyproceeds,0) + 
				  ISNULL(residualproceeds,0) - 
				  ISNULL(competencypayments,0) - 
				  ISNULL(residualpayments,0))
				FROM surplus WHERE ayear = @ycursor)
			WHERE ayear = @ycursor
		END
		ELSE
		BEGIN
		set @value= 0
		select  @value = SUM(i.curramount)
					FROM incometotal i 
					JOIN incomelast IL
						ON IL.idinc = i.idinc
					JOIN proceeds p
						ON p.kpro=IL.kpro
					JOIN proceedstransmission pt
						ON p.kproceedstransmission=pt.kproceedstransmission
					WHERE i.ayear = @ycursor

		UPDATE currentcashtotal	SET currentfloatfund =	currentfloatfund +	ISNULL(@value,0)
										WHERE ayear = @ycursor
		print 'income found:'
		print @value
	
		set @value= 0
		select  @value = SUM(i.curramount)
				FROM expenselast EL
				JOIN expensetotal i		ON EL.idexp = i.idexp
				WHERE i.ayear = @ycursor
			
		UPDATE currentcashtotal SET currentfloatfund = currentfloatfund - ISNULL(@value,0)	
							WHERE ayear = @ycursor

		print 'expense found:'
		print @value

		END

		
	FETCH NEXT FROM fc INTO @ycursor
	END
	DEALLOCATE fc

	
END

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

