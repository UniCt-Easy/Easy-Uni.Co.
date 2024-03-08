
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisionepluriennale_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisionepluriennale_riep]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--- setuser 'amministrazione'
-- setuser 'amm'
-- EXEC rpt_bilprevisionepluriennale_riep 2006, 'E', 3, '0001', 'S', 'N'

CREATE    PROCEDURE [rpt_bilprevisionepluriennale_riep]
	@ayear 		int,
	@finpart 	char(1),
	@levelusable 	tinyint,	
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1)
AS
BEGIN

DECLARE @idupboriginal 		varchar(36)
SET @idupboriginal= @idupb

IF (@showchildupb = 'S') SET @idupb = @idupb + '%' 

DECLARE @ayearprec smallint
SET @ayearprec = @ayear - 1

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1


CREATE TABLE #budget
(
	idfin 			int		, 
	codeupb			varchar(50)	,
	idupb 			varchar(36)	,
	upb   			varchar(150)	,
	upbprintingorder	varchar(50)	,
	previsioneannuale1 decimal(19,2),
	previsioneannuale2 decimal(19,2),
	previsioneannuale3 decimal(19,2),
	prevprec_annuale2 decimal(19,2),
	prevprec_annuale3 decimal(19,2),
	varaumento_annuale2 decimal(19,2),
	vardiminuizione_annuale2 decimal(19,2),
	varaumento_annuale3 decimal(19,2),
	vardimunuzione_annuale3	decimal(19,2)
)


CREATE TABLE #finyear
(
	idfin int, 
	idupb varchar(36),
	previsioneannuale1 decimal(19,2),
	previsioneannuale2 decimal(19,2),
	previsioneannuale3 decimal(19,2),
	prevprec_annuale2 decimal(19,2),
	prevprec_annuale3 decimal(19,2),
	varaumento_annuale2 decimal(19,2),
	vardiminuizione_annuale2 decimal(19,2),
	varaumento_annuale3 decimal(19,2),
	vardimunuzione_annuale3	decimal(19,2)
)


DECLARE @infoadvance		char(1)
SELECT  @infoadvance = paramvalue FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'

DECLARE @minlevelusable		tinyint
SELECT  @minlevelusable = min(nlevel) FROM finlevel WHERE ayear = @ayear and (flag&2)<>0
	
IF(@levelusable < @minlevelusable)
begin
	SET @levelusable = @minlevelusable
end	

------------------------------------------------- SE SI è DECISO DI NON VEDERE  UPB ---------------------------------------------------------------------------------

IF (@showupb <>'S') and (@idupboriginal = '%') 
BEGIN 

	INSERT INTO #budget(idfin)
	SELECT idfin
	FROM fin 
	WHERE 	nlevel = 1
		AND ayear = @ayear AND ((flag & 1)= @finpart_bit)

		
	IF @levelusable > @minlevelusable
	BEGIN	 --print 'then'  --stampa per articolo (ovvero nodi foglia)
	INSERT INTO #finyear(
		idfin,
		previsioneannuale1,
		previsioneannuale2,
		previsioneannuale3,
		prevprec_annuale2,
		prevprec_annuale3
		)
	SELECT  
		f6.idfin,
		SUM(fy.prevision),
		SUM(fy.prevision2),
		SUM(fy.prevision3),
		SUM(fy_prec.prevision2),
		SUM(fy_prec.prevision3)
	FROM fin f6
	JOIN finlevel fl
		ON f6.nlevel = fl.nlevel AND  f6.ayear = fl.ayear
	JOIN finyear fy
		ON fy.idfin = f6.idfin
	LEFT OUTER JOIN finlookup
		ON finlookup.newidfin = FY.idfin		
	LEFT OUTER JOIN finyear fy_prec
		ON finlookup.oldidfin = fy_prec.idfin and fy_prec.idupb = fy.idupb				
	WHERE f6.ayear = @ayear
		AND ((f6.flag & 1)= @finpart_bit) 
		AND (f6.nlevel = @levelusable
			OR (f6.nlevel < @levelusable
			AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = f6.idfin)
			AND (fl.flag&2)<>0
			)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F6.flag & 16 =0) )
	GROUP BY f6.idfin		

	UPDATE #budget set		
	previsioneannuale1 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale1,0.0))
		FROM #finyear as fy2
		JOIN finlink 
			ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		JOIN finlast
			ON finlast.idfin = finlink.idchild
		JOIN fin
			ON finlast.idfin = fin.idfin
		WHERE	fy2.idfin =  finlink.idchild  
			AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			),0),	
		
	previsioneannuale2 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale2,0.0))
			FROM #finyear as fy2
			JOIN finlink 
				ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
			JOIN finlast
				ON finlast.idfin = finlink.idchild
			JOIN fin
				ON finlast.idfin = fin.idfin
			WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				),0),		
	previsioneannuale3 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale3,0.0))
			FROM #finyear as fy2
			JOIN finlink 
				ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
			JOIN finlast
				ON finlast.idfin = finlink.idchild
			JOIN fin
				ON finlast.idfin = fin.idfin
			WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				),0),

	prevprec_annuale2 = 	ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale2,0.0))
			FROM #finyear as fy2
			JOIN finlink 
				ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
			JOIN finlast
				ON finlast.idfin = finlink.idchild
			JOIN fin
				ON finlast.idfin = fin.idfin
			WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				),0),

	prevprec_annuale3 = 	ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale3,0.0))
			FROM #finyear as fy2
			JOIN finlink 
				ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
			JOIN finlast
				ON finlast.idfin = finlink.idchild
			JOIN fin
				ON finlast.idfin = fin.idfin
			WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				),0),

	varaumento_annuale2 = 	
				ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN finlast
					ON finlast.idfin = finlink.idchild
				JOIN fin
					ON finlast.idfin = fin.idfin
				WHERE	fy2.idfin =  finlink.idchild  
				AND (ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0)) > 0
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				),0),
	vardiminuizione_annuale2 = 
				ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN finlast
					ON finlast.idfin = finlink.idchild
				JOIN fin
					ON finlast.idfin = fin.idfin
				WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0)) > 0
				),0),
	varaumento_annuale3 = 	
				ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN finlast
					ON finlast.idfin = finlink.idchild
				JOIN fin
					ON finlast.idfin = fin.idfin
				WHERE	fy2.idfin =  finlink.idchild  
				AND (ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0)) > 0
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				),0),
	vardimunuzione_annuale3 = 
				ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN finlast
					ON finlast.idfin = finlink.idchild
				JOIN fin
					ON finlast.idfin = fin.idfin
				WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0)) > 0
				),0)				
END
Else
Begin -- Stampa per Capitolo
		
	INSERT INTO #finyear(
		idfin,
		previsioneannuale1,
		previsioneannuale2,
		previsioneannuale3,
		prevprec_annuale2,
		prevprec_annuale3
		)
	SELECT  
		f6.idfin,
		SUM(fy.prevision),
		SUM(fy.prevision2),
		SUM(fy.prevision3),
		SUM(fy_prec.prevision2),
		SUM(fy_prec.prevision3)
	FROM fin f6
	JOIN finlevel fl
		ON f6.nlevel = fl.nlevel AND  f6.ayear = fl.ayear
	JOIN finyear fy
		ON fy.idfin = f6.idfin
	LEFT OUTER JOIN finlookup
		ON finlookup.newidfin = FY.idfin		
	LEFT OUTER JOIN finyear fy_prec
		ON finlookup.oldidfin = fy_prec.idfin and fy_prec.idupb = fy.idupb
	WHERE f6.ayear = @ayear
		AND ((f6.flag & 1)= @finpart_bit) 
		AND (f6.nlevel = @levelusable
			OR (f6.nlevel < @levelusable
			AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = f6.idfin)
			AND (fl.flag&2)<>0
			)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f6.flag & 16 =0) )
	GROUP BY f6.idfin	
	/*
select #finyear.*, fin.codefin from #finyear
join fin
	on #finyear.idfin = fin.idfin
	
return
*/


	UPDATE #budget set		
	previsioneannuale1 = 	ISNULL((SELECT SUM(fy2.previsioneannuale1)
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					),0),
		
	previsioneannuale2 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale2,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					),0),		
	previsioneannuale3 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale3,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					),0),

	prevprec_annuale2 = 	ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale2,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					),0),

	prevprec_annuale3 = 	ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale3,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					),0),

	varaumento_annuale2 = 	
				ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				),0),
	vardiminuizione_annuale2 = 
				ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				),0),
	varaumento_annuale3 = 	
				ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				),0),
	vardimunuzione_annuale3 = 
				ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				),0)				
End
				
END--(@showupb <>'S') and (@idupboriginal = '%') 
ELSE
BEGIN 

	INSERT INTO #budget
		(
		idfin,
		idupb
		)
	SELECT 
		b1.idfin,
		upb.idupb
	FROM fin b1 cross join upb
	WHERE 	b1.nlevel = 1
		AND (upb.idupb like @idupb)
		AND b1.ayear = @ayear AND ((b1.flag & 1)= @finpart_bit)

	IF @levelusable > @minlevelusable
	BEGIN print 'then'  --stampa per articolo (ovvero nodi foglia)
	
		INSERT INTO #finyear(
		idfin, idupb,
		previsioneannuale1,
		previsioneannuale2,
		previsioneannuale3,
		prevprec_annuale2,
		prevprec_annuale3
		)
	SELECT  
		f6.idfin, fy.idupb,
		SUM(fy.prevision),
		SUM(fy.prevision2),
		SUM(fy.prevision3),
		SUM(fy_prec.prevision2),
		SUM(fy_prec.prevision3)
	FROM fin f6
	JOIN finlevel fl
		ON f6.nlevel = fl.nlevel AND  f6.ayear = fl.ayear
	JOIN finyear fy
		ON fy.idfin = f6.idfin
	LEFT OUTER JOIN finlookup
		ON finlookup.newidfin = FY.idfin		
	LEFT OUTER JOIN finyear fy_prec
		ON finlookup.oldidfin = fy_prec.idfin and	fy_prec.idupb = fy.idupb			
	WHERE f6.ayear = @ayear
		AND ((f6.flag & 1)= @finpart_bit) 
		AND (f6.nlevel = @levelusable
			OR (f6.nlevel < @levelusable
			AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = f6.idfin)
			AND (fl.flag&2)<>0
			)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f6.flag & 16 =0) )
	GROUP BY fy.idupb, f6.idfin	
	
	----select distinct idfin from #budget
	--SELECT ISNULL(fy2.previsioneannuale1,0.0), fy2.idfin ,fy2.idupb
	--				FROM #finyear as fy2
	--				JOIN finlink 
	--					ON finlink.idparent =7001 AND finlink.nlevel = 1
	--				JOIN finlast
	--					ON finlast.idfin = finlink.idchild
	--				JOIN fin
	--					ON finlast.idfin = fin.idfin
	--				WHERE	fy2.idfin =  finlink.idchild  
	--					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
	--		 AND finlink.idchild = 8083
	UPDATE #budget  
	SET
			previsioneannuale1 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale1,0.0))
					FROM #finyear as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),
				
			previsioneannuale2 = 	ISNULL((SELECT SUM(fy2.previsioneannuale2)
					FROM #finyear as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),
						
			previsioneannuale3 = 	ISNULL((SELECT SUM(fy2.previsioneannuale3)
					FROM #finyear as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),
			/*prevprec_annuale2 =		ISNULL((SELECT SUM(ISNULL(FY_prec.prevision2,0.0))
					FROM finyear as FY_prec
					JOIN finlookup
						ON finlookup.oldidfin = FY_prec.idfin
					JOIN finlink 
						ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE finlookup.newidfin = finlink.idchild
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND FY_prec.ayear = @ayearprec
						AND FY_prec.idupb = #budget.idupb),0),
						),0),*/	
			prevprec_annuale2 =		ISNULL((SELECT SUM(fy2.prevprec_annuale2)
					FROM #finyear as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),	
			prevprec_annuale3 =		ISNULL((SELECT SUM(fy2.prevprec_annuale3)
					FROM #finyear as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),																		

			varaumento_annuale2 = 	
						ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0))
						FROM #finyear as fy2
						JOIN finlink 
							ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
						JOIN finlast
							ON finlast.idfin = finlink.idchild
						JOIN fin
							ON finlast.idfin = fin.idfin
						WHERE	fy2.idfin =  finlink.idchild  
						AND fy2.idupb = #budget.idupb
						AND (ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0)) > 0
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						),0),
			vardiminuizione_annuale2 = 
						ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0))
						FROM #finyear as fy2
						JOIN finlink 
							ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
						JOIN finlast
							ON finlast.idfin = finlink.idchild
						JOIN fin
							ON finlast.idfin = fin.idfin
						WHERE	fy2.idfin =  finlink.idchild  
						AND fy2.idupb = #budget.idupb
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND (ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0)) > 0
						),0),
			varaumento_annuale3 = 	
						ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0))
						FROM #finyear as fy2
						JOIN finlink 
							ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
						JOIN finlast
							ON finlast.idfin = finlink.idchild
						JOIN fin
							ON finlast.idfin = fin.idfin
						WHERE	fy2.idfin =  finlink.idchild  
						AND fy2.idupb = #budget.idupb
						AND (ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0)) > 0
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						),0),
			vardimunuzione_annuale3 = 
						ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0))
						FROM #finyear as fy2
						JOIN finlink 
							ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
						JOIN finlast
							ON finlast.idfin = finlink.idchild
						JOIN fin
							ON finlast.idfin = fin.idfin
						WHERE	fy2.idfin =  finlink.idchild  
						AND fy2.idupb = #budget.idupb
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND (ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0)) > 0
						),0)			
End
Else
-- Stampa  per capitolo			
Begin
	INSERT INTO #finyear(
		idfin, idupb,
		previsioneannuale1,
		previsioneannuale2,
		previsioneannuale3,
		prevprec_annuale2,
		prevprec_annuale3
		)
	SELECT  
		f6.idfin, fy.idupb,
		SUM(fy.prevision),
		SUM(fy.prevision2),
		SUM(fy.prevision3),
		SUM(fy_prec.prevision2),
		SUM(fy_prec.prevision3)
	FROM fin f6
	JOIN finlevel fl
		ON f6.nlevel = fl.nlevel AND  f6.ayear = fl.ayear
	JOIN finyear fy
		ON fy.idfin = f6.idfin
	LEFT OUTER JOIN finlookup
		ON finlookup.newidfin = FY.idfin		
	LEFT OUTER JOIN finyear fy_prec
		ON finlookup.oldidfin = fy_prec.idfin	and fy_prec.idupb = fy.idupb			
	WHERE f6.ayear = @ayear
		AND ((f6.flag & 1)= @finpart_bit) 
		AND (f6.nlevel = @levelusable
			OR (f6.nlevel < @levelusable
			AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = f6.idfin)
			AND (fl.flag&2)<>0
			)
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f6.flag & 16 =0) )
	GROUP BY f6.idfin, fy.idupb	

	UPDATE #budget set		
	previsioneannuale1 = 	ISNULL((SELECT SUM(fy2.previsioneannuale1)
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					AND fy2.idupb = #budget.idupb
					),0),
		
	previsioneannuale2 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale2,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					AND fy2.idupb = #budget.idupb
					),0),		
	previsioneannuale3 = 	ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale3,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					AND fy2.idupb = #budget.idupb
					),0),

	prevprec_annuale2 = 	ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale2,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					AND fy2.idupb = #budget.idupb
					),0),

	prevprec_annuale3 = 	ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale3,0.0))
				FROM #finyear as fy2
				JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
				JOIN fin
					ON fin.idfin = finlink.idchild
				WHERE	fy2.idfin =  finlink.idchild  
					AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					AND  fin.nlevel = @levelusable 
					AND fy2.idupb = #budget.idupb
					),0),

	varaumento_annuale2 = 	
				ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.previsioneannuale1, 0.0) - ISNULL(fy2.prevprec_annuale2, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				AND fy2.idupb = #budget.idupb
				),0),
	vardiminuizione_annuale2 = 
				ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.prevprec_annuale2, 0.0) - ISNULL(fy2.previsioneannuale1, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				AND fy2.idupb = #budget.idupb
				),0),
	varaumento_annuale3 = 	
				ISNULL((SELECT SUM(ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.previsioneannuale2, 0.0) - ISNULL(fy2.prevprec_annuale3, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				AND fy2.idupb = #budget.idupb
				),0),
	vardimunuzione_annuale3 = 
				ISNULL((SELECT SUM(ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0))
				 FROM #finyear as fy2
				 JOIN finlink 
					ON finlink.idparent = #budget.idfin AND finlink.nlevel = 1
		   		 JOIN fin
					ON fin.idfin = finlink.idchild
		  		WHERE	fy2.idfin =  finlink.idchild  
				AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND (ISNULL(fy2.prevprec_annuale3, 0.0) - ISNULL(fy2.previsioneannuale2, 0.0)) > 0
				AND  fin.nlevel = @levelusable 
				AND fy2.idupb = #budget.idupb
				),0)				
End										
END--(@showupb <>'S') and (@idupboriginal = '%') 

	UPDATE #budget SET 
		codeupb = (SELECT codeupb FROM upb 
			WHERE idupb=#budget.idupb),
		upb = (SELECT title FROM upb 
			WHERE idupb=#budget.idupb),
		upbprintingorder = (SELECT  printingorder FROM upb
			WHERE idupb=#budget.idupb)

	IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
		UPDATE #budget SET  
			upbprintingorder = (SELECT TOP 1 upbprintingorder
				FROM #budget
				WHERE idupb = @idupboriginal),
			upb = (SELECT TOP 1 upb
				FROM #budget
				WHERE idupb = @idupboriginal),
			idupb = @idupboriginal,
			codeupb =(SELECT TOP 1 codeupb
				FROM #budget	
				WHERE idupb = @idupboriginal)
			
	IF (@showupb <>'S') and (@idupboriginal = '%') 
		UPDATE #budget SET  
		upbprintingorder = null	,
		upb =  null,
		idupb = null,
		codeupb = null
	DECLARE @supposed_ff_prec	decimal(19,2)
	DECLARE @supposed_aa_prec	decimal(19,2)
	
	DECLARE @supposed_ff		decimal(19,2)
	DECLARE @supposed_aa		decimal(19,2)
	 

	 -- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077
	IF 	@finpart = 'E'
	BEGIN
		 	-- Bilancio di Previsione 2014 --
			-- Fondo cassa al 01/01/2013
			SELECT	@supposed_ff_prec = ISNULL(startfloatfund, 0) 
			FROM surplus
			WHERE ayear = @ayear - 1
			
			-- Avanzo di amministrazione al 01/01/2013 = AA al 31/12/2012 = fondo cassa 31/12/2012 + Residui Attivi 2012 - Residui Passivi 2012 = fondo cassa 01/01/2013 + RA 2012 - RP 2012
			SELECT @supposed_aa_prec = 	(SELECT ISNULL(startfloatfund, 0) FROM surplus	WHERE ayear = @ayear - 1)
			+	
			ISNULL(previousrevenue, 0) +
			ISNULL(currentrevenue , 0) -
			ISNULL(previousexpenditure, 0) -
			ISNULL(currentexpenditure, 0)
			FROM surplus
			WHERE ayear = @ayear - 2
		
		
			SELECT
			@supposed_ff =
				ISNULL(startfloatfund, 0.0) 	+ ISNULL(proceedstilldate, 0.0) -
				ISNULL(paymentstilldate, 0.0) 	+ ISNULL(proceedstoendofyear, 0.0) -
				ISNULL(paymentstoendofyear, 0.0),
			@supposed_aa =
				ISNULL(startfloatfund, 0.0) 	+ ISNULL(proceedstilldate, 0.0) -
				ISNULL(paymentstilldate, 0.0) 	+	ISNULL(proceedstoendofyear, 0.0) -
				ISNULL(paymentstoendofyear, 0.0) + ISNULL(supposedpreviousrevenue, 0.0) +				
				ISNULL(supposedcurrentrevenue , 0.0) - ISNULL(supposedpreviousexpenditure, 0.0) -
				ISNULL(supposedcurrentexpenditure, 0.0)
			FROM 	surplus
			WHERE 	ayear = @ayear - 1
	END
--select * from #finyear where idfin = 8083
SELECT 
	#budget.idfin,
	fin.codefin AS code1,
	fin.title AS desc1,
	fin.printingorder AS printorder1,
	codeupb			,
	idupb 			,
	upb   			,
	upbprintingorder	,
	previsioneannuale1,
	previsioneannuale2,
	previsioneannuale3,
	prevprec_annuale2 as 'prevbilprec',
	prevprec_annuale3 as 'prevbilprec2',
	varaumento_annuale2 as 'varaumento',
	vardiminuizione_annuale2 as 'vardiminuizione',
	varaumento_annuale3 as 'varaumento1',
	vardimunuzione_annuale3 as 'vardiminuizione1'	,
	(SELECT case fin_kind when 2 then 'S' else 'C' end FROM config WHERE ayear = @ayear) as 'previsionkind',
	null 			as 'display_aa',
	@supposed_ff 		as 'supposed_ff',
	@supposed_aa 		as 'supposed_aa',
	@supposed_ff_prec 	as 'supposed_ff_prec',
	@supposed_aa_prec 	as 'supposed_aa_prec'	
FROM 	#budget
JOIN fin
	ON #budget.idfin = fin.idfin	

ORDER BY printorder1


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

