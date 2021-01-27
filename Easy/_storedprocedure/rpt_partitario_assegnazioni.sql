
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_partitario_assegnazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_partitario_assegnazioni]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE   PROCEDURE rpt_partitario_assegnazioni
	@ayear 		int,
	@idupb		varchar(36),
	@level  	tinyint,
	@filter 	int,
	@start 		datetime,
	@stop 		datetime,
	@showupb 	char(1),
	@showchildupb 	char(1) 
AS
	BEGIN
		DECLARE @idupboriginal 	varchar(36)
		SET  	@idupboriginal= @idupb
		IF 	(@showchildupb = 'S' and @idupb<>'%' ) set @idupb=@idupb+'%' 
		
	DECLARE @level_input tinyint
	SET  @level_input = ISNULL((SELECT nlevel from fin where idfin = @filter) ,@level)
	-- ho scelto come livello 2 e poi ho specificato il capitolo, lui corregge @nlevel dandogli 3

IF (@level < @level_input ) AND (@filter is not null)
	BEGIN
	SET  @level = @level_input
	END

		DECLARE @codliv_op	tinyint
		SELECT  @codliv_op = MIN(nlevel)
			FROM finlevel
			WHERE flag&2 <> 0
			AND ayear = @ayear
		
		DECLARE @nomeliv_bil	varchar(50)
		SELECT  @nomeliv_bil = description 
			FROM finlevel
			WHERE nlevel = @level
			AND ayear = @ayear
			
		IF @codliv_op < @level
			SELECT @codliv_op = @level
			
		
		CREATE TABLE #part
		(
			idfin			int		,
			idupb 			varchar(36)	,
			rowkind			int		,
			operationdate		datetime	,
			operationkind		varchar(55)	,
			yoperation		int		,
			noperation		int		,
			description		varchar(150)	,
			prevision		decimal(19,2)	,
 			finvar			decimal(19,2)	,
			creditpart		decimal(19,2)	,
			proceedspart		decimal(19,2)	
		)
		
		CREATE TABLE #prevpart
		(
			idfin			int		,
			idupb			varchar(36)	,
			prevision		decimal(19,2)	,
			finvar			decimal(19,2)	,
			creditpart		decimal(19,2)	,
			proceedspart		decimal(19,2)	
		)
		
		



		DECLARE @firstday datetime
		SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4), @ayear), 105)
		
		IF (DATEDIFF(DAY,@start,@firstday) = 0)
	 	BEGIN
		INSERT INTO #part
			(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			prevision
			)
			SELECT 
			fin.idfin,
			upb.idupb,
			1,
			CONVERT(datetime, '01/01/' + CONVERT(varchar(4), @ayear), 101),
			'Prev.iniziale',
				(SELECT SUM(fy2.prevision) 
				FROM finyear fy2 
				JOIN finlink FLK
					ON fy2.idfin = FLK.idchild and FLK.nlevel = @level
				join fin f2
					on f2.idfin = FLK.idchild 
				WHERE FLK.idparent = fin.idfin
				AND f2.nlevel = @codliv_op 
				AND fy2.idupb= upb.idupb)
			FROM finyear
			JOIN fin
				ON finyear.idfin = fin.idfin
			JOIN upb
				ON finyear.idupb = upb.idupb
			JOIN finlink
				ON finlink.idchild = fin.idfin and finlink.nlevel = @level
			WHERE (upb.idupb like @idupb )
				AND fin.ayear = @ayear
				AND (( fin.flag & 1) = 1)
				AND fin.nlevel = @level
				AND (@filter IS NULL OR finlink.idparent = @filter )
		END
		IF (DATEDIFF(DAY,@start,@firstday) <> 0)
		BEGIN

		INSERT INTO #prevpart
		(
			idfin,
			idupb
		)
		SELECT finyear.idfin,
		       finyear.idupb
		FROM upbtotal
		JOIN upb
			ON upbtotal.idupb = upb.idupb
		JOIN fin
			ON upbtotal.idfin = fin.idfin
		JOIN finlink
			ON finlink.idchild = fin.idfin	and finlink.nlevel = @level
		LEFT OUTER JOIN finyear
			ON finyear.idfin = fin.idfin and finyear.idupb = upb.idupb
		WHERE (upb.idupb like @idupb)
			AND fin.ayear = @ayear
			AND (( fin.flag & 1)=1)
			AND fin.nlevel = @level
			AND (@filter IS NULL OR finlink.idparent = @filter )


		UPDATE #prevpart
		SET prevision =
			(SELECT ISNULL(SUM(u2.prevision),0.0) 
			FROM finyear u2
			join fin f2
				on u2.idfin = f2.idfin	
			JOIN finlink FLK
				ON FLK.idchild = F2.idfin AND FLK.nlevel = @level
			WHERE u2.idupb= #prevpart.idupb
				AND FLK.idparent = #prevpart.idfin
				AND f2.nlevel = @codliv_op
				),
			finvar =
			(SELECT ISNULL(SUM(finvardetail.amount), 0.0)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN finlink FLK
				ON FLK.idchild = finvardetail.idfin AND FLK.nlevel = @level
			WHERE finvardetail.idupb = #prevpart.idupb 
				AND FLK.idparent = #prevpart.idfin
				AND finvar.adate < @start 
				AND finvar.yvar = @ayear
				AND finvar.flagprevision = 'S'
				AND finvar.variationkind <> 5
				AND finvar.idfinvarstatus = 5 )


		UPDATE #prevpart
		SET creditpart =
			(SELECT ISNULL(SUM(creditpart.amount), 0.0)
			FROM creditpart
			JOIN incomeyear
				ON creditpart.idinc = incomeyear.idinc
				and creditpart.ycreditpart = incomeyear.ayear
			JOIN finlink
				ON finlink.idchild = creditpart.idfin 
			WHERE adate  < @start 
				AND incomeyear.idupb = #prevpart.idupb 
				AND creditpart.ycreditpart = @ayear
				and finlink.idparent = #prevpart.idfin
				)
				+ 
			(SELECT ISNULL(SUM(finvardetail.amount), 0)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN finlink
				ON finlink.idchild = finvardetail.idfin
			WHERE finvar.adate < @start 
				AND finvar.yvar = @ayear
				AND finvar.flagcredit = 'S'
				AND finvar.idfinvarstatus = 5
				AND finvardetail.idupb = #prevpart.idupb 
				and finlink.idparent = #prevpart.idfin
				)

		UPDATE #prevpart
		SET proceedspart =
			(SELECT ISNULL(SUM(proceedspart.amount), 0.0)
			FROM proceedspart
			JOIN incomeyear
				ON proceedspart.idinc = incomeyear.idinc
				and proceedspart.yproceedspart = incomeyear.ayear
			JOIN finlink
				ON finlink.idchild = proceedspart.idfin
			WHERE adate < @start 
				AND finlink.idparent = #prevpart.idfin
				AND incomeyear.idupb = #prevpart.idupb 
				AND yproceedspart = @ayear)
				+ 
			(SELECT ISNULL(SUM(finvardetail.amount), 0.0)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN finlink
				ON finlink.idchild = finvardetail.idfin
			WHERE finvardetail.idupb = #prevpart.idupb 
				AND finvar.adate  < @start 
				AND finvar.yvar = @ayear
				AND finvar.flagproceeds = 'S'
				AND finvar.idfinvarstatus = 5
				AND finlink.idparent = #prevpart.idfin
				)

		INSERT INTO #part
		(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			prevision,
			finvar,
			creditpart,
			proceedspart
		)
		SELECT
			#prevpart.idfin,
			upb.idupb,
			1,
			DATEADD(dd, -1, @start),
			'Tot.prec.',
			ISNULL(#prevpart.prevision,0.0),
			ISNULL(#prevpart.finvar,0.0),
			ISNULL(#prevpart.creditpart,0.0),
			ISNULL(#prevpart.proceedspart,0.0)
			FROM #prevpart
			JOIN fin
				ON fin.idfin = #prevpart.idfin
			JOIN upb 
				ON upb.idupb = #prevpart.idupb
		END
	
		INSERT INTO #part
			(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			yoperation,
			noperation,
			description,
			finvar
			)
			SELECT 
			fin.idfin,
			upb.idupb,
			2,
			finvar.adate,
			'Var.prev.',
			finvar.yvar,
			finvar.nvar,
			finvar.description,
			ISNULL(finvardetail.amount,0.0)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN finlink 
				ON finlink.idchild = finvardetail.idfin and finlink.nlevel =  @level_input
			JOIN finlink FL1
				ON FL1.idchild = finvardetail.idfin AND FL1.nlevel = @level
			JOIN fin
				ON fin.idfin = FL1.idparent
			JOIN upb 
				ON upb.idupb=finvardetail.idupb 
			WHERE (upb.idupb like @idupb)
				AND fin.ayear = @ayear
				AND (( fin.flag & 1)=1)
				AND fin.nlevel = @level
				AND finvar.adate BETWEEN @start AND @stop
      				AND finvar.flagprevision = 'S'
				AND finvar.idfinvarstatus = 5
				AND finvar.variationkind <> 5
				AND (@filter IS NULL OR finlink.idparent = @filter )


		INSERT INTO #part
			(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			yoperation,
			noperation,
			description,
			creditpart
			)
			SELECT 
			fin.idfin,
			upb.idupb,
			3,
			creditpart.adate,
			'Ass.cred.',
			creditpart.ycreditpart,
			creditpart.ncreditpart,
			creditpart.description,
			ISNULL(creditpart.amount,0.0)
			FROM creditpart
			JOIN incomeyear
				ON creditpart.idinc = incomeyear.idinc
				and creditpart.ycreditpart = incomeyear.ayear
			JOIN finlink 
				ON finlink.idchild = creditpart.idfin and finlink.nlevel =  @level_input
			JOIN finlink FL1
				ON FL1.idchild = creditpart.idfin AND FL1.nlevel = @level
			JOIN fin
				ON fin.idfin = FL1.idparent
			JOIN upb  
				ON upb.idupb=incomeyear.idupb
			WHERE (upb.idupb like @idupb )
				AND fin.ayear = @ayear
				AND (( fin.flag & 1)=1)
				AND fin.nlevel = @level
				AND (@filter IS NULL OR finlink.idparent = @filter )
				AND creditpart.adate BETWEEN @start AND @stop 


		INSERT INTO #part
			(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			yoperation,
			noperation,
			description,
			creditpart
			)
			SELECT 
			fin.idfin,
			upb.idupb,
			4,
			finvar.adate,
			'Var.cred.',
			finvar.yvar,
			finvar.nvar,
			finvar.description,
			ISNULL(finvardetail.amount,0.0)
			FROM finvardetail
			JOIN finvar
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN finlink 
				ON finlink.idchild = finvardetail.idfin and finlink.nlevel =  @level_input
			JOIN finlink FL1
				ON FL1.idchild = finvardetail.idfin AND FL1.nlevel = @level
			JOIN fin
				ON fin.idfin = FL1.idparent
			JOIN upb 
				ON upb.idupb=finvardetail.idupb
			WHERE (upb.idupb like @idupb)
				AND finvar.adate BETWEEN @start AND @stop
      				AND finvar.flagcredit = 'S'
				AND finvar.idfinvarstatus = 5
				AND fin.ayear = @ayear
				AND (( fin.flag & 1) = 1)
				AND fin.nlevel = @level
				AND (@filter IS NULL OR finlink.idparent = @filter )
	  
		INSERT INTO #part
			(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			yoperation,
			noperation,
			description,
			proceedspart
			)
			SELECT 
			fin.idfin,
			upb.idupb,
			5,
			proceedspart.adate,
			'Ass.cassa',
			proceedspart.yproceedspart,
			proceedspart.nproceedspart,
			proceedspart.description,
			isnull(proceedspart.amount,0.0)
			FROM proceedspart
			JOIN incomeyear
				ON proceedspart.idinc = incomeyear.idinc
				and proceedspart.yproceedspart = incomeyear.ayear
			JOIN finlink 
				ON finlink.idchild = proceedspart.idfin and finlink.nlevel =  @level_input
			JOIN finlink FL1
				ON FL1.idchild = proceedspart.idfin AND FL1.nlevel = @level
			JOIN fin
				ON fin.idfin = FL1.idparent
			JOIN upb  
				ON upb.idupb=incomeyear.idupb
			WHERE (upb.idupb like @idupb)
				AND fin.ayear = @ayear
				AND (( fin.flag & 1) = 1)
				AND fin.nlevel = @level
				AND (@filter IS NULL OR finlink.idparent = @filter )
				AND proceedspart.adate BETWEEN @start AND @stop

		INSERT INTO #part
			(
			idfin,
			idupb,
			rowkind,
			operationdate,
			operationkind,
			yoperation,
			noperation,
			description,
			proceedspart
			)
			SELECT 
			fin.idfin,
			upb.idupb,
			6,
			finvar.adate,
			'Var. cassa',
			finvar.yvar,
			finvar.nvar,
			finvar.description,
			isnull(finvardetail.amount,0.0)
			FROM finvardetail 
			JOIN finvar 
				ON finvar.yvar = finvardetail.yvar
				AND finvar.nvar = finvardetail.nvar
			JOIN finlink 
				ON finlink.idchild = finvardetail.idfin and finlink.nlevel =  @level_input
			JOIN finlink FL1
				ON FL1.idchild = finvardetail.idfin AND FL1.nlevel = @level
			JOIN fin
				ON fin.idfin = FL1.idparent
			join upb
				on finvardetail.idupb = upb.idupb
			WHERE (finvardetail.idupb like @idupb )
				AND finvar.adate BETWEEN @start AND @stop
				AND finvar.flagproceeds='S'
				AND finvar.idfinvarstatus = 5
				AND (( fin.flag & 1) = 1)
				AND fin.ayear = @ayear
				AND fin.nlevel = @level
				AND (@filter IS NULL OR finlink.idparent = @filter )

IF (@showupb <>'S') AND (@idupboriginal <> '%') AND (@showchildupb = 'S')
UPDATE #part 
SET  
	idupb = @idupboriginal 
	
IF (@showupb <>'S') and (@idupboriginal = '%') 
UPDATE #part 
SET  idupb = null


DELETE FROM #part
WHERE 
	ISNULL(prevision,0.0)= 0
	AND   ISNULL(finvar,0.0)= 0
	AND   ISNULL(creditpart,0.0)=0
	AND   ISNULL(proceedspart,0.0)=0

	IF ((@showupb <>'S') AND (@idupboriginal <> '%' ) AND 
	(@showchildupb = 'S'))OR ((@showupb <>'S') and (@idupboriginal = '%'))
	BEGIN
    	SELECT 
		#part.idfin,
		fin.nlevel as 'finlevel',
		fin.codefin,
		fin.printingorder as 'finprintingorder',
		fin.title,
		upb.codeupb,
		#part.idupb,
		upb.title as 'upb',
		upb.printingorder as 'upbprintingorder',
		rowkind,
		operationdate,
		operationkind,
		yoperation,
		noperation,
		description,
		sum(isnull(prevision,0.0))    as 'prevision',
		sum(isnull(finvar,0.0))       as 'finvar', 
		sum(isnull(creditpart,0.0))   as 'creditpart',
		sum(isnull(proceedspart,0.0)) as 'proceedspart'
     	FROM #part
	JOIN fin 
		ON fin.idfin = #part.idfin
	 LEFT OUTER JOIN upb 
		ON upb.idupb = #part.idupb
     GROUP BY #part.idfin,fin.nlevel,codefin,fin.printingorder,fin.title,codeupb,
	      #part.idupb,upb.title,upb.printingorder,rowkind,operationdate,
	      operationkind,yoperation,noperation,description
     	ORDER BY upbprintingorder ASC,
	     #part.idfin ASC,
	     operationdate ASC,
	     rowkind ASC,
	     noperation ASC
	END
	ELSE
	BEGIN
	SELECT 
		#part.idfin,
		@nomeliv_bil as 'finlevel',
		fin.codefin,
		fin.printingorder as 'finprintingorder',
		fin.title,
		upb.codeupb,
		upb.idupb,
		upb.title as 'upb',
		upb.printingorder as 'upbprintingorder',
		rowkind,
		operationdate,
		operationkind,
		yoperation,
		noperation,
		description,
		isnull(prevision,0.0) as   'prevision',
		isnull(finvar,0.0)  as 'finvar', 
		isnull(creditpart,0.0) as 'creditpart',
		isnull(proceedspart,0.0) as 'proceedspart'
     	FROM #part
	JOIN fin 
		ON fin.idfin = #part.idfin
	JOIN upb 
		ON upb.idupb = #part.idupb
	ORDER BY upbprintingorder ASC,
	     #part.idfin ASC,
	     operationdate ASC,
	     rowkind ASC,
	     noperation ASC
	END
  END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

