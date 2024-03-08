
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisione_bozza_riep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisione_bozza_riep]
GO


CREATE 	PROCEDURE [rpt_bilprevisione_bozza_riep]
	@ayear 		int,
	@finpart 	char(1),
	@levelusable 	tinyint,	
	@idupb		varchar(36),
	@showupb 	char(1),
	@showchildupb 	char(1),
	@nprevfin int,
	@suppressifblank char(1)
AS  BEGIN
	
DECLARE @idupboriginal 		varchar(36)
SET 	@idupboriginal= @idupb
IF 	(@showchildupb = 'S') SET @idupb = @idupb + '%' 

DECLARE @nextayear int 
SET @nextayear = @ayear + 1

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
if @finpart='E' set @finpart_bit = 0
if @finpart='S' set @finpart_bit = 1

DECLARE @fin_kind varchar(1)
SELECT  @fin_kind = fin_kind
FROM 	config 
WHERE 	ayear = @ayear

-- EXEC rpt_bilprevisione_bozza_riep 2007,'S','3','%','N','N',2

CREATE TABLE #budget
(
	idfin int, 
	codeupb varchar(50),
	idupb varchar(36),
	upb varchar(150),
	upbprintingorder varchar(50),
	prevision decimal(19,2),
	previousprevision decimal(19,2),
	secondaryprevision decimal(19,2),
	previoussecprevision decimal(19,2),
	currentarrears decimal(19,2),
	accretion_var decimal(19,2),
	diminution_var decimal(19,2),
	sec_accretion_var decimal(19,2),
	sec_diminution_var decimal(19,2)	
)
	
DECLARE @infoadvance char(1)
SELECT  @infoadvance = paramvalue FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo'
DECLARE @minlevelusable tinyint
SELECT  @minlevelusable = min(nlevel) FROM finlevel WHERE ayear = @ayear and (flag&2)<>0

IF(@levelusable < @minlevelusable)
Begin
	SET @levelusable = @minlevelusable
End

CREATE TABLE #prevfindetail_new
(
	idfin int, 
	competency decimal(19,2),
	previousprevision decimal(19,2),
	cash decimal(19,2),	
	previoussecprevision decimal(19,2),
	currentarrears decimal(19,2)
)

------------------------------------------------------- SE HAI DECISO DI NON VEDERE L 'UPB ---------------------------------------------------

IF (@showupb <>'S') and (@idupboriginal = '%') 
BEGIN 

	INSERT INTO #budget
		(
		idfin,
		idupb
		)
	SELECT 
		idfin,
		null
	FROM fin 
	WHERE 	nlevel = 1
		AND ayear = @nextayear AND ((flag & 1)= @finpart_bit)

  IF @levelusable > @minlevelusable
  BEGIN	 --print 'then'  --stampa per articolo (ovvero nodi foglia)
	INSERT INTO #prevfindetail_new	
	(
		idfin , 
		competency ,
		previousprevision ,
		cash ,
		previoussecprevision ,
		currentarrears 
	)
	SELECT  
		B.idfin,
		case @fin_kind 
			when 2
				then ISNULL(SUM(P.cash), 0)
			else ISNULL(SUM(P.competency), 0)
		end,
		ISNULL(SUM(P.previousprevision),0),
		ISNULL(SUM(P.cash),0),
		ISNULL(SUM(P.previoussecondaryprev),0),
		ISNULL(SUM(P.supposedrevenue),0)
	FROM  fin B 
	JOIN finlevel fl
		ON B.nlevel = fl.nlevel AND  B.ayear = fl.ayear
	join prevfindetail P	
		on P.idfin = B.idfin
		AND P.nprevfin = @nprevfin 
		AND P.ayear = @ayear
	WHERE  ((B.flag & 1)= @finpart_bit) 
		AND (B.nlevel = @levelusable
		OR 
		  (B.nlevel < @levelusable
		AND EXISTS
			(SELECT * FROM finlast WHERE finlast.idfin = B.idfin)
			AND (fl.flag&2)<>0
			))
		AND (@infoadvance = 'N' or @infoadvance = 'B' OR (B.flag & 16 =0))
	GROUP BY B.idfin

	UPDATE #budget set 
		prevision 		= ISNULL((SELECT 
						  CASE @fin_kind
						  	WHEN 2
						  	THEN SUM(ISNULL(fy2.cash, 0.0))
						  	ELSE SUM(ISNULL(fy2.competency, 0.0))
						  END
					FROM #prevfindetail_new as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					),0),
		
		previousprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.previousprevision, 0.0))
					FROM #prevfindetail_new as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					),0),
		secondaryprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.cash, 0.0))
					FROM #prevfindetail_new as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					),0),
		previoussecprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.previousprevision, 0.0))
					FROM #prevfindetail_new as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
					),0),
		currentarrears		= ISNULL((SELECT 

					ISNULL(SUM(fy2.currentarrears),0)
					  FROM #prevfindetail_new as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					  JOIN finlast
						ON finlast.idfin = finlink.idchild
					  JOIN fin
						 ON finlast.idfin = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')),0),
		--previsione principale variazioni in aumento 
		accretion_var		=  ISNULL((SELECT 
					    CASE @fin_kind
						WHEN 2
						THEN SUM(ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0))
						ELSE SUM(ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))
					    END 
					    FROM #prevfindetail_new as fy2
					    JOIN finlink 
							ON finlink.idparent = #budget.idfin
						  JOIN finlast
							ON finlast.idfin = finlink.idchild
						  JOIN fin
							 ON finlast.idfin = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))>0)
						)
						),0),
		--previsione principale variazioni in diminuzione 
		diminution_var	 	=	ISNULL((SELECT 
					    	 CASE @fin_kind
						   WHEN 2
						   THEN SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0))
						 ELSE SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))
					        END 
					        FROM #prevfindetail_new as fy2
					        JOIN finlink 
							ON finlink.idparent = #budget.idfin
						  JOIN finlast
							ON finlast.idfin = finlink.idchild
						  JOIN fin
							 ON finlast.idfin = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))>0)
						)
						),0),
		--previsione secondaria variazioni in aumento
		sec_accretion_var	= 0,	
		--previsione secondaria variazioni in diminuzione
		sec_diminution_var	= 0
  END
  ELSE
  BEGIN  
-- Stampa per capitolo
-- deva sia totalizzare i capitoli, che fare la sum indipendentemente dall'upb
	INSERT INTO #prevfindetail_new
	(
		idfin , 
		competency ,
		previousprevision ,
		cash ,
		previoussecprevision ,
		currentarrears 
	)
	SELECT
		B.idfin, 
		(SELECT 
			case @fin_kind 
				when 2
					then ISNULL(SUM(FiY.cash), 0.0)
				else ISNULL(SUM(FiY.competency), 0.0)
			end
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin
				AND FiY.ayear = @ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FLK.idparent = B.idfin 
				),
		-- ISNULL(sum(P.previousprevision),0), sarà zero
		(SELECT 
			ISNULL(SUM(FiY.previousprevision), 0.0)
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin
				AND FiY.ayear = @ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FLK.idparent = B.idfin 
				),
		(SELECT 
			ISNULL(SUM(FiY.cash), 0.0)
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin
				AND FiY.ayear = @ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FLK.idparent = B.idfin 
				),
		--ISNULL(sum(P.previoussecondaryprev),0), sarà zero
		(SELECT 
			ISNULL(SUM(FiY.previoussecondaryprev), 0.0)
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin
				AND FiY.ayear = @ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FLK.idparent = B.idfin 
				),
		(SELECT 
				CASE
					WHEN (@finpart= 'E') THEN ISNULL(SUM(FiY.supposedrevenue), 0.0)
					ELSE ISNULL(SUM(FiY.supposedexpenditure), 0.0)
				END
			FROM fin Fi
			JOIN finlink FLK
				ON Fi.idfin = FLK.idchild 
			JOIN finlast 
				ON finlast.idfin = FLK.idchild 
			JOIN prevfindetail FiY
				ON FiY.idfin = FLK.idchild 
				AND FiY.nprevfin = @nprevfin
				AND FiY.ayear = @ayear
			WHERE (Fi.flag & 1)= @finpart_bit
				AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
				AND FLK.idparent = B.idfin 
				)
		FROM  fin B 
		JOIN finlevel fl
			ON B.nlevel = fl.nlevel AND  B.ayear = fl.ayear
		/*LEFT OUTER join prevfindetail P	
			on P.idfin = B.idfin
			AND P.nprevfin = @nprevfin 
			AND P.ayear = @ayear*/
		WHERE ((B.flag & 1)= @finpart_bit) 
			AND B.ayear = @nextayear
			AND (B.nlevel = @levelusable
			OR 
			  (B.nlevel < @levelusable
			AND EXISTS
				(SELECT * FROM finlast WHERE finlast.idfin = B.idfin)
				AND (fl.flag&2)<>0
				))
			AND (@infoadvance = 'N' or @infoadvance = 'B' OR (b.flag & 16 =0))
	GROUP BY B.idfin 

	UPDATE #budget set 
		prevision 		= ISNULL((SELECT 
						  CASE @fin_kind
						  	WHEN 2
						  	THEN SUM(ISNULL(fy2.cash, 0.0))
						  	ELSE SUM(ISNULL(fy2.competency, 0.0))
						  END
					FROM #prevfindetail_new as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						),0),
		previousprevision	= 
					  ISNULL((SELECT SUM(ISNULL(fy2.previousprevision,0.0))
					  FROM #prevfindetail_new as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN fin
						ON finlink.idchild = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						),0),
		secondaryprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.cash, 0.0))
					FROM #prevfindetail_new as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin
					JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						),0),
		previoussecprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.previoussecprevision, 0.0))
					  FROM #prevfindetail_new as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						),0),
		currentarrears		= ISNULL((SELECT 
						ISNULL(SUM(fy2.currentarrears),0) 
					  FROM #prevfindetail_new as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					  JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						),0),
		--previsione principale variazioni in aumento 
		accretion_var		=  ISNULL((SELECT 
					    CASE @fin_kind
						WHEN 2
						THEN SUM(ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0))
						ELSE SUM(ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))
					    END 
					FROM #prevfindetail_new as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin
					JOIN fin
						ON finlink.idchild = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))>0)
						)
					  ),0),
		--previsione principale variazioni in diminuzione 
		diminution_var	 	=	ISNULL((SELECT 
					    	 CASE @fin_kind
						   WHEN 2
						   THEN SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0))
						 ELSE SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))
					        END 
					        FROM #prevfindetail_new as fy2
					        JOIN finlink 
							ON finlink.idparent = #budget.idfin
						JOIN fin
						ON finlink.idchild = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))>0)
						)
					),0),
		--previsione secondaria variazioni in aumento
		sec_accretion_var	=  0,
		--previsione secondaria variazioni in diminuzione
		sec_diminution_var	= 0

   END

END -- (@showupb <>'S') and (@idupboriginal = '%') 
------------------------------------------------------- SE, INVECE, HAI DECISO DI VEDERE L 'UPB ---------------------------------------------------
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
		AND b1.ayear =  @nextayear  AND ((b1.flag & 1)= @finpart_bit)

CREATE TABLE #prevfindetail
(
	idfin int, 
	idupb varchar(36),
	competency decimal(19,2),
	previousprevision decimal(19,2),
	cash decimal(19,2),	
	previoussecprevision decimal(19,2),
	currentarrears decimal(19,2),
	accretion_var decimal(19,2),
	diminution_var decimal(19,2)
)
	

IF (@levelusable <= @minlevelusable )
BEGIN
-- solo se la stampa è x capitolo
INSERT INTO #prevfindetail
(
	idfin , 
	idupb ,
	competency ,
	previousprevision ,
	cash ,
	previoussecprevision ,
	currentarrears 
)
SELECT
	B.idfin, 
	U.idupb,
	(SELECT 
		case @fin_kind 
			when 2
				then ISNULL(SUM(FiY.cash), 0.0)
			else ISNULL(SUM(FiY.competency), 0.0)
		end
		FROM fin Fi
		JOIN finlink FLK
			ON Fi.idfin = FLK.idchild 
		JOIN finlast 
			ON finlast.idfin = FLK.idchild 
		JOIN prevfindetail FiY
			ON FiY.idfin = FLK.idchild 
			AND FiY.nprevfin = @nprevfin
			AND FiY.ayear = @ayear
		WHERE (Fi.flag & 1)= @finpart_bit
			AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FiY.idupb = U.idupb
			AND FLK.idparent = B.idfin 
			),
	-- ISNULL(P.previousprevision,0), è zero perchè i prevfindetail no ci sono i capitoli articolati, abbiamo solo le foglie
	(SELECT 
		ISNULL(SUM(FiY.previousprevision), 0.0)
		FROM fin Fi
		JOIN finlink FLK
			ON Fi.idfin = FLK.idchild 
		JOIN finlast 
			ON finlast.idfin = FLK.idchild 
		JOIN prevfindetail FiY
			ON FiY.idfin = FLK.idchild 
			AND FiY.nprevfin = @nprevfin 
			AND FiY.ayear = @ayear
		WHERE (Fi.flag & 1)= @finpart_bit
			AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FiY.idupb = U.idupb
			AND FLK.idparent = B.idfin 
			),
	(SELECT 
		ISNULL(SUM(FiY.cash), 0.0)
		FROM fin Fi
		JOIN finlink FLK
			ON Fi.idfin = FLK.idchild 
		JOIN finlast 
			ON finlast.idfin = FLK.idchild 
		JOIN prevfindetail FiY
			ON FiY.idfin = FLK.idchild 
			AND FiY.nprevfin = @nprevfin
			AND FiY.ayear = @ayear
		WHERE (Fi.flag & 1)= @finpart_bit
			AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FiY.idupb = U.idupb
			AND FLK.idparent = B.idfin 
			),
	--ISNULL(P.previoussecondaryprev,0),
	(SELECT 
		ISNULL(SUM(FiY.previoussecondaryprev), 0.0)
		FROM fin Fi
		JOIN finlink FLK
			ON Fi.idfin = FLK.idchild 
		JOIN finlast 
			ON finlast.idfin = FLK.idchild 
		JOIN prevfindetail FiY
			ON FiY.idfin = FLK.idchild 
			AND FiY.nprevfin = @nprevfin
			AND FiY.ayear = @ayear
		WHERE (Fi.flag & 1)= @finpart_bit
			AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
			AND FiY.idupb = U.idupb
			AND FLK.idparent = B.idfin 
			),
	(SELECT 
		CASE
			WHEN (@finpart= 'E') THEN ISNULL(SUM(FiY.supposedrevenue), 0.0)
			ELSE ISNULL(SUM(FiY.supposedexpenditure), 0.0)
		END
	FROM fin Fi
	JOIN finlink FLK
		ON Fi.idfin = FLK.idchild 
	JOIN finlast 
		ON finlast.idfin = FLK.idchild 
	JOIN prevfindetail FiY
		ON FiY.idfin = FLK.idchild 
		AND FiY.nprevfin = @nprevfin
		AND FiY.ayear = @ayear
	WHERE (Fi.flag & 1)= @finpart_bit
		AND ((fi.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
		AND FiY.idupb = U.idupb
		AND FLK.idparent = B.idfin 
		)
FROM  fin B cross join upb U
JOIN finlevel fl
	ON B.nlevel = fl.nlevel AND  B.ayear = fl.ayear
/*left outer join prevfindetail P	
	on P.idfin = B.idfin	and  P.idupb = U.idupb	AND P.nprevfin = @nprevfin 	AND P.ayear = @ayear*/
WHERE (U.idupb like @idupb)
	AND B.ayear = @nextayear
	AND ((B.flag & 1)= @finpart_bit) 
	AND (B.nlevel = @levelusable
	OR 
	  (B.nlevel < @levelusable
	AND EXISTS
		(SELECT * FROM finlast WHERE finlast.idfin = B.idfin)
		AND (fl.flag&2)<>0
		))
	AND (@infoadvance = 'N' or @infoadvance = 'B' OR (B.flag & 16 =0))


END

IF @levelusable > @minlevelusable
	BEGIN print 'then'  --stampa per articolo (ovvero nodi foglia)
	UPDATE #budget  
	SET
		prevision 		= ISNULL((SELECT 
						  CASE @fin_kind
						  	WHEN 2
						  	THEN SUM(ISNULL(fy2.cash, 0.0))
						  	ELSE SUM(ISNULL(fy2.competency, 0.0))
						  END
					FROM prevfindetail as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.ayear = @ayear
						AND fy2.nprevfin = @nprevfin
						AND fy2.idupb = #budget.idupb),0),
		
		previousprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.previousprevision, 0.0))
					FROM prevfindetail as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.ayear = @ayear
						AND fy2.nprevfin = @nprevfin
						AND fy2.idupb = #budget.idupb),0),
		secondaryprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.cash, 0.0))
					FROM prevfindetail as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.ayear = @ayear
						AND fy2.nprevfin = @nprevfin
						AND fy2.idupb = #budget.idupb),0),
		previoussecprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.previoussecondaryprev, 0.0))
					FROM prevfindetail as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN finlast
						ON finlast.idfin = finlink.idchild
					JOIN fin
						ON finlast.idfin = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.ayear = @ayear
						AND fy2.nprevfin = @nprevfin
						AND fy2.idupb = #budget.idupb),0),
		currentarrears		= ISNULL((SELECT 
					  CASE 
						WHEN (@finpart= 'E') THEN ISNULL(SUM(fy2.supposedrevenue),0)    
						WHEN (@finpart= 'S') THEN ISNULL(SUM(fy2.supposedexpenditure),0)
					  END
					  FROM prevfindetail as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					  JOIN finlast
						ON finlast.idfin = finlink.idchild
					  JOIN fin
						 ON finlast.idfin = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.ayear = @ayear
						AND fy2.nprevfin = @nprevfin
						AND fy2.idupb = #budget.idupb),0),
		--previsione principale variazioni in aumento 
		accretion_var		=  ISNULL((SELECT 
					    CASE @fin_kind
						WHEN 2
						THEN SUM(ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0))
						ELSE SUM(ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))
					    END 
					    FROM prevfindetail as fy2
					    JOIN finlink 
							ON finlink.idparent = #budget.idfin
						  JOIN finlast
							ON finlast.idfin = finlink.idchild
						  JOIN fin
							 ON finlast.idfin = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((fin.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))>0)
						)
						AND fy2.ayear = @ayear
						AND fy2.nprevfin = @nprevfin
						AND fy2.idupb = #budget.idupb),0),
		--previsione principale variazioni in diminuzione 
		diminution_var	 	=	ISNULL((SELECT 
					    	 CASE @fin_kind
						   WHEN 2
						   THEN SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0))
						 ELSE SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))
					        END 
					        FROM prevfindetail as fy2
					        JOIN finlink 
							ON finlink.idparent = #budget.idfin
						  JOIN finlast
							ON finlast.idfin = finlink.idchild
						  JOIN fin
							 ON finlast.idfin = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))>0)
						)
						AND fy2.ayear = @ayear
						AND fy2.nprevfin = @nprevfin
						AND fy2.idupb = #budget.idupb),0),
		--previsione secondaria variazioni in aumento
		sec_accretion_var	= 0,	
		--previsione secondaria variazioni in diminuzione
		sec_diminution_var	= 0
	END
	

ELSE    BEGIN
	print 'else'  --stampa per capitolo:legge da #prevfindetail
	UPDATE #budget  
	SET
		prevision 		= ISNULL((SELECT 
						  CASE @fin_kind
						  	WHEN 2
						  	THEN SUM(ISNULL(fy2.cash, 0.0))
						  	ELSE SUM(ISNULL(fy2.competency, 0.0))
						  END
					FROM #prevfindetail as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),
		previousprevision	= 
					  ISNULL((SELECT SUM(ISNULL(fy2.previousprevision,0.0))
					  FROM #prevfindetail as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN fin
						ON finlink.idchild = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb
						),0),
		secondaryprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.cash, 0.0))
					FROM #prevfindetail as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin
					JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),
		previoussecprevision	= ISNULL((SELECT 
					  SUM(ISNULL(fy2.previoussecprevision, 0.0))
					  FROM #prevfindetail as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),
		currentarrears		= ISNULL((SELECT 
						ISNULL(SUM(fy2.currentarrears),0) 
					  FROM #prevfindetail as fy2
					  JOIN finlink 
						ON finlink.idparent = #budget.idfin 
					  JOIN fin
						ON finlink.idchild = fin.idfin
					WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						AND fy2.idupb = #budget.idupb),0),
		--previsione principale variazioni in aumento 
		accretion_var		=  ISNULL((SELECT 
					    CASE @fin_kind
						WHEN 2
						THEN SUM(ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0))
						ELSE SUM(ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))
					    END 
					FROM #prevfindetail as fy2
					JOIN finlink 
						ON finlink.idparent = #budget.idfin
					JOIN fin
						ON finlink.idchild = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.cash, 0.0) - ISNULL(fy2.previousprevision, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.competency, 0.0) - ISNULL(fy2.previousprevision, 0.0))>0)
						)
						AND fy2.idupb = #budget.idupb),0),
		--previsione principale variazioni in diminuzione 
		diminution_var	 	=	ISNULL((SELECT 
					    	 CASE @fin_kind
						   WHEN 2
						   THEN SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0))
						 ELSE SUM(ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))
					        END 
					        FROM #prevfindetail as fy2
					        JOIN finlink 
							ON finlink.idparent = #budget.idfin
						JOIN fin
						ON finlink.idchild = fin.idfin
					  WHERE	fy2.idfin =  finlink.idchild  
						AND ((FIN.flag & 16 =0) OR @infoadvance = 'N' OR @infoadvance = 'B')
						and (  
						( @fin_kind = 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.cash, 0.0)) >0 )
							OR 
						( @fin_kind <> 2 AND (ISNULL(fy2.previousprevision, 0.0) -ISNULL(fy2.competency, 0.0))>0)
						)
						AND fy2.idupb = #budget.idupb),0),
		--previsione secondaria variazioni in aumento
		sec_accretion_var	=  0,
		--previsione secondaria variazioni in diminuzione
		sec_diminution_var	= 0
	END
	
END --- (@showupb ='S')...

UPDATE #budget SET 
	codeupb = (SELECT codeupb FROM upb 
		WHERE idupb=#budget.idupb),
	upb = (SELECT title FROM upb 
		WHERE idupb=#budget.idupb),
	upbprintingorder = (SELECT  printingorder FROM upb
		WHERE idupb=#budget.idupb)

IF (@showupb <>'S') AND (@idupboriginal <> '%' ) AND (@showchildupb = 'S')
BEGIN
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
END
			
IF (@showupb <>'S') and (@idupboriginal = '%') 
BEGIN
	UPDATE #budget SET  
		upbprintingorder = null	,
		upb =  null,
		idupb = null,
		codeupb = null
END
DECLARE @supposed_ff_prec	decimal(19,2)
DECLARE @supposed_aa_prec	decimal(19,2)
DECLARE @supposed_ff		decimal(19,2)
DECLARE @supposed_aa		decimal(19,2)
IF (@finpart = 'E')
BEGIN
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
		WHERE 	ayear = @ayear 

		SELECT	
		@supposed_ff_prec =
			ISNULL(startfloatfund, 0.0) 	+ ISNULL(competencyproceeds, 0.0) -
			ISNULL(competencypayments, 0.0) + ISNULL(residualproceeds, 0.0) -
			ISNULL(residualpayments, 0.0),
		@supposed_aa_prec =
			ISNULL(startfloatfund, 0.0) 	+ ISNULL(competencyproceeds, 0.0) -
			ISNULL(competencypayments, 0.0) + ISNULL(residualproceeds, 0.0) -
			ISNULL(residualpayments, 0.0) 	+ ISNULL(previousrevenue, 0.0) +				
			ISNULL(currentrevenue , 0.0) 	- ISNULL(previousexpenditure, 0.0) -
			ISNULL(currentexpenditure, 0.0)
		FROM 	surplus
		WHERE 	ayear = @ayear -1 
	
	

END
	
DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'
-- se vuoi nascondere le voci inutilizzate e vuoi nasccondere anche i totoli e la e categorie(mostra tutte le voci), allora
-- cancella le righe a zero, se invece vuoi nascondere solo le voci inutilizzate fino alla categoria,
-- (quindi nel report principale saranno nascosti solo capitoli e articoli) non fa  nulla

IF(Upper(@MostraTutteVoci)='N' AND @suppressifblank = 'S' )
BEGIN
	DELETE FROM #budget
	WHERE ISNULL(prevision,0)= 0
		AND ISNULL(previousprevision,0)= 0
		AND ISNULL(secondaryprevision,0)= 0
		AND ISNULL(currentarrears,0)= 0
		AND ISNULL(accretion_var,0)= 0
		AND ISNULL(diminution_var,0)= 0
	AND idupb <> '0001' AND @fin_kind IN ('1','3') 
	DELETE FROM #budget
	WHERE ISNULL(prevision,0)= 0
		AND ISNULL(previousprevision,0)= 0
		AND ISNULL(accretion_var,0)= 0
		AND ISNULL(diminution_var,0)= 0
	AND idupb <> '0001'AND @fin_kind IN ('2')
END
SELECT 
	#budget.idfin, 
	fin.codefin as 'code1',			
	fin.title as 'desc1',			
	fin.printingorder as 'printorder1',
	codeupb			,
	idupb 			,
	upb   			,
	upbprintingorder	,
	prevision		,
	previousprevision	,
	secondaryprevision	,
	previoussecprevision	,
	currentarrears		,
	accretion_var		,
	diminution_var		,
	sec_accretion_var	,
	sec_diminution_var	,
	case @fin_kind when 2 then 'S' else 'C' end as 'previsionkind',
	null 			as 'display_aa',
	@supposed_ff 		as 'supposed_ff',
	@supposed_aa 		as 'supposed_aa',
	@supposed_ff_prec 	as 'supposed_ff_prec',
	@supposed_aa_prec 	as 'supposed_aa_prec'	
FROM #budget
JOIN fin
	ON #budget.idfin = fin.idfin	
ORDER BY printorder1
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


