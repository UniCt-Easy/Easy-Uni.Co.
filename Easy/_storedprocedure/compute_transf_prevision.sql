
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
if exists (select * from dbo.sysobjects where id = object_id(N'[compute_transf_prevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_transf_prevision]
GO
--setuser 'amministrazione'
--compute_transf_prevision 2016,'16-12-2016'
CREATE PROCEDURE compute_transf_prevision
(
	@ayear int,
	@date datetime
)
AS BEGIN
 SET NOCOUNT ON;  
DECLARE @levelusable tinyint
SELECT  @levelusable = MAX(nlevel) FROM finlevel WHERE ayear = @ayear

DECLARE @infoavanzo char(1)
SELECT  @infoavanzo = paramvalue FROM generalreportparameter WHERE idparam = 'MostraAvanzo'

-- Se @fin_kind = 1 ==> è stata personalizzata una previsione principale di tipo "competenza", se @fin_kind = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se  @fin_kind = 3 ==> è stata personalizzata una
-- previsione principale di tipo "altra previsione". 
DECLARE @fin_kind tinyint

SELECT @fin_kind = ISNULL(fin_kind,0) FROM config WHERE ayear = @ayear

/*
Se un capitolo nell'anno successivo, 2009: 
- perde tutti gli articoli perchè cancellati,esisterà in convert bilancio l'associazione tra gli articoli e il capitolo.
- o perde tutti gli articoli perchè associati ad altri capitoli, esisterà in convert bilancio l'associazione tra gli articoli e i nuovi capitoli
ALLORA cancelliamo la riga del capitolo in #finlookup.
Perchè nel primo caso la prev. del capitolo sarà data dalla SUM delle prev. degli articoli, nel secondo caso sarà zero.

In altre parole,cancelliamo #finlookup le corrispondenze capitolo 2008 -->capitolo 2009 ove: 
1)capitolo 2008 è articolato 
2)capitolo 2009 non è articolato
3)esistono altre voci (al di fuori di se stesso) che puntano a capitolo 2009 (ad esempio suoi articoli o altri)
Nel caso in cui, invece:
1)capitolo 2008 è articolato 
2)capitolo 2009 non è articolato
3)NON esistono altre voci (al di fuori di se stesso) che puntano a capitolo 2009 
anche qui si potrebbe spezzare tanto deve andare a zero comunque

Quindi, quando
1)capitolo 2008 è articolato 
2)capitolo 2009 non è articolato
si può spezzare il legame capitolo 2008-2009 in #finlookup
*/

CREATE TABLE #finlookup(
        oldidfin	int,-- ayear
        newidfin	int -- ayear +1
)
INSERT INTO #finlookup(oldidfin,newidfin)
SELECT oldidfin,newidfin
FROM finlookup
JOIN fin
        ON finlookup.oldidfin = fin.idfin
WHERE fin.ayear = @ayear


--select * from #finlookup

-- Cancella il capitolo articolato nel 2008, e dearticolato nel 2009.
DELETE FROM #finlookup WHERE EXISTS ( select * from fin where fin.paridfin = #finlookup.oldidfin )--è parent nel  2008
                                AND NOT EXISTS ( select * from fin where fin.paridfin = #finlookup.newidfin )-- non è parent nel 2009

CREATE TABLE #bilprevision
(
	--finpart char (1),
	idupb varchar(36),
	idfin int,
	paridfin int,
	nlevel tinyint,
	previousprevision decimal (19,2),
	previoussecondaryprev decimal (19,2),
	previousarrears decimal(19,2),
	temp char(1)
)

INSERT INTO #bilprevision
(
	idfin,	idupb,	paridfin,	nlevel,	previousprevision,	previoussecondaryprev,	previousarrears
)
SELECT 
	--CASE 		WHEN ((F_NEW.flag&1)=0) THEN 'E'		WHEN ((F_NEW.flag&1)=1) THEN 'S'	END,
	F_NEW.idfin, -- new idfin
	u.idupb,
	F_NEW.paridfin, -- new paridfin
	F_NEW.nlevel,
	ISNULL(SUM(finyear.prevision),0), 
	ISNULL(SUM(finyear.secondaryprev),0),
	ISNULL(SUM(finyear.currentarrears),0)
FROM finyear (nolock)
JOIN fin f	(nolock)		        ON f.idfin = finyear.idfin
JOIN upb u	(nolock)		        ON u.idupb = finyear.idupb
JOIN #finlookup FK (nolock)	        ON FK.oldidfin = f.idfin 
JOIN fin F_NEW (nolock)	         ON F_NEW.idfin = FK.newidfin
WHERE  f.ayear = @ayear
	AND (    (((f.flag&1)=0) AND (@infoavanzo <> 'S' OR (F.flag & 16 =0))) --Entrata
		  OR ((f.flag&1)=1		) --Spesa
		)
GROUP BY F_NEW.idfin, u.idupb, F_NEW.paridfin, F_NEW.flag,F_NEW.nlevel
--print 'prima insert'
INSERT INTO #bilprevision
(
	idfin, 	idupb,	paridfin,	nlevel,	previousprevision,	previoussecondaryprev,	previousarrears
)
SELECT  DISTINCT
	--CASE 		WHEN ((F_NEW.flag&1)=0) THEN 'E'		WHEN ((F_NEW.flag&1)=1) THEN 'S'	END,	
	F_NEW.idfin, --> new idfin
	u.idupb,
	F_NEW.paridfin, --> new paridfin
	F_NEW.nlevel,
	0, 
	0,
	0
FROM    incomeyear IY (nolock)
JOIN fin f  (nolock)         ON f.idfin=IY.idfin
JOIN upb u  (nolock)         ON u.idupb=IY.idupb
JOIN #finlookup FK (nolock)  ON FK.oldidfin = f.idfin 
JOIN fin F_NEW (nolock)       ON F_NEW.idfin = FK.newidfin
WHERE  f.ayear = @ayear and iy.ayear=@ayear 	
	AND (@infoavanzo <> 'S' OR (F.flag & 16 =0))	
	--AND NOT EXISTS (select * from #bilprevision where  #bilprevision.idfin=F_NEW.idfin and #bilprevision.idupb=IY.idupb)
--print 'seconda insert'
INSERT INTO #bilprevision
(
	idfin,	idupb,	paridfin,	nlevel,	previousprevision,	previoussecondaryprev,	previousarrears
)
SELECT DISTINCT
	--CASE 		WHEN ((F_NEW.flag&1)=0) THEN 'E'		WHEN ((F_NEW.flag&1)=1) THEN 'S'	END,	
	F_NEW.idfin, --> new idfin
	u.idupb,
	F_NEW.paridfin, --> new paridfin
	F_NEW.nlevel,
	0, 
	0,
	0
FROM    expenseyear IY (nolock)
JOIN fin f   (nolock)     ON f.idfin=IY.idfin
JOIN upb u   (nolock)     ON u.idupb=IY.idupb
JOIN #finlookup FK  (nolock)       ON FK.oldidfin = f.idfin 
JOIN fin F_NEW  (nolock)        ON F_NEW.idfin = FK.newidfin
WHERE  f.ayear = @ayear and iy.ayear=@ayear 	
	--AND NOT EXISTS (select * from #bilprevision where  #bilprevision.idfin = F_NEW.idfin and #bilprevision.idupb=IY.idupb)

--print 'terza insert'
-- VARIAZIONI DI BILANCIO della previsione principale
--CREATE TABLE #tot_varprev (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO #bilprevision
(	
	idfin,	idupb,	paridfin,	nlevel, previousprevision
)

SELECT
	FK.newidfin,--ISNULL(finlink.idparent, FK.newidfin),
	FVD.idupb,
	fin.paridfin, fin.nlevel,
	SUM(FVD.amount)
FROM finvardetail FVD (nolock)
JOIN finvar FV  (nolock)	ON  FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
JOIN finlink FL (nolock)	ON FL.idchild = FVD.idfin
JOIN #finlookup FK (nolock)        ON FK.oldidfin = FL.idparent 
join fin  (nolock) on FK.newidfin= fin.idfin
--LEFT OUTER JOIN finlink
	--ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagprevision = 'S'
	AND FV.idfinvarstatus = 5 
	AND FV.variationkind <> 5
GROUP BY FVD.idupb,FK.newidfin,fin.paridfin,fin.nlevel --ISNULL(finlink.idparent, FK.newidfin)

--print 'quarta insert'
-- VARIAZIONI DI BILANCIO della previsione secondaria
--CREATE TABLE #tot_varsecondaryprev (idfin int, idupb varchar(36), total decimal(19,2))
INSERT INTO #bilprevision
(
	idfin,
	idupb,
	paridfin, nlevel,
	previoussecondaryprev
)
SELECT
	FK.newidfin,--ISNULL(finlink.idparent, FK.newidfin),
	FVD.idupb,
	fin.paridfin,fin.nlevel,
	SUM(FVD.amount)
FROM finvardetail FVD (nolock)
JOIN finvar FV (nolock)			ON FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
JOIN finlink FL (nolock)		ON FL.idchild = FVD.idfin
JOIN #finlookup FK (nolock)     ON FK.oldidfin = FL.idparent
join fin  (nolock)				on fk.newidfin= fin.idfin
--LEFT OUTER JOIN finlink
--	ON  finlink.idchild = FK.newidfin AND finlink.nlevel = @levelusable
WHERE FV.yvar = @ayear
	AND FV.adate <= @date
	AND FV.flagsecondaryprev = 'S'
	AND FV.idfinvarstatus = 5 
	AND FV.variationkind <> 5
GROUP BY FVD.idupb, FK.newidfin,fin.paridfin,fin.nlevel --ISNULL(finlink.idparent, FK.newidfin)
--print 'quinta insert'

---- Per questi due campi in un bilancio di sola cassa la previoussecondaryprev non sarà valorizzata 
---- controllare nel form se è giusto così
--UPDATE #bilprevision
--SET 
--	previousprevision = 
--	ISNULL(previousprevision,0) +
--	ISNULL(
--		(SELECT SUM(#tot_varprev.total) 
--		FROM #tot_varprev
--		LEFT OUTER JOIN finlink
--			ON finlink.idchild = #tot_varprev.idfin 
--		WHERE #tot_varprev.idupb = #bilprevision.idupb
--			AND ISNULL(finlink.idparent, #tot_varprev.idfin) = #bilprevision.idfin)
--	,0),
--	previoussecondaryprev =
--	ISNULL(previoussecondaryprev,0) +
--	ISNULL(
--		(SELECT SUM(#tot_varsecondaryprev.total)
--		FROM #tot_varsecondaryprev
--		LEFT OUTER JOIN  finlink
--			ON finlink.idchild = #tot_varsecondaryprev.idfin
--		WHERE #tot_varsecondaryprev.idupb = #bilprevision.idupb
--			AND ISNULL(finlink.idparent,#tot_varsecondaryprev.idfin) = #bilprevision.idfin)
--	,0)

DECLARE @nextayear int
SET 	@nextayear = @ayear + 1

-- Procedura che imposta il valore dei capitoli articolati pari alla somma degli articoli
-- in particolare sta prendendo i capitoli degli articoli, se non esistono nella tabella.
-- Per esempio se ho fatto solo un mov. di spesa sull'articolo, lo troverò SOLO in expenseyear
-- quindi in #bilprevision troverò SOLO l'articolo. Questo ciclo serve ad inserisce anche il relativo capitolo
-- per poterlo totalizzare.
DECLARE @minlivop tinyint
DECLARE @maxlivop tinyint

SELECT @minlivop = isnull(MIN(nlevel),1) FROM finlevel WHERE flag&2 <> 0 AND ayear = @nextayear
SELECT @maxlivop = MAX(nlevel) FROM finlevel WHERE ayear = @nextayear

DECLARE @liv tinyint
SET @liv = @maxlivop - 1
WHILE (@liv >= @minlivop)
BEGIN
-- @liv = 3
-- @childlevel = 4
	DECLARE @childlevel tinyint
	SET @childlevel = @liv + 1


	INSERT INTO #bilprevision
	(
		idupb, 	idfin, 	paridfin,	nlevel,	previousprevision,	previoussecondaryprev,	previousarrears,	temp
	)

	SELECT DISTINCT
		CHILD.idupb, CHILD.paridfin, finlink.idparent, 	@liv,	0,	0,	0,		'S'
	FROM #bilprevision CHILD (nolock)
	LEFT OUTER JOIN finlink (nolock)		ON finlink.idchild = CHILD.paridfin	AND finlink.nlevel = @liv - 1
	LEFT  OUTER JOIN #bilprevision PARENT  on PARENT.idfin = CHILD.paridfin	AND PARENT.idupb = CHILD.idupb
	WHERE CHILD.nlevel = @childlevel and PARENT.idfin is null
	--print 'INSERT NEL CICLO'
		

	UPDATE #bilprevision
	SET previousprevision = 
        	ISNULL(
        		(SELECT SUM(previousprevision) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin 
        		AND child.idupb = #bilprevision.idupb)
        	,0),
        	previoussecondaryprev = 
        	ISNULL(
        		(SELECT SUM(previoussecondaryprev) FROM #bilprevision child
        		WHERE child.paridfin = #bilprevision.idfin
        		AND child.idupb = #bilprevision.idupb)
        	,0)
	WHERE #bilprevision.nlevel = @liv AND ISNULL(#bilprevision.temp,'N') = 'S'
	AND EXISTS(SELECT * FROM #bilprevision b2 WHERE b2.paridfin = #bilprevision.idfin and b2.idupb=#bilprevision.idupb)
	--print 'UPDATE NEL CICLO'

	SET @liv = @liv - 1
	--print @liv
END


--SELECT	TOP 9223372036854775807 idupb,	idfin,	
--					SUM(previousprevision) as previousprevision,	
--					SUM(previoussecondaryprev) as previoussecondaryprev,	
--					SUM(previousarrears) as previousarrears
--				FROM #bilprevision 
--				group by idupb,idfin
--				order by len(idupb)

DECLARE @newfinyear TABLE (
    	idupb varchar(36),
	idfin int,
	paridfin int,
	nlevel tinyint,
	previousprevision decimal (19,2),
	previoussecondaryprev decimal (19,2),
	previousarrears decimal(19,2)
    );

insert into @newfinyear (idupb, idfin,previousprevision, previoussecondaryprev, previousarrears)
			select 
			 idupb,	idfin,	
					SUM(previousprevision) as previousprevision,	
					SUM(previoussecondaryprev) as previoussecondaryprev,	
					SUM(previousarrears) as previousarrears
				FROM #bilprevision 
				group by idupb,idfin
				order by len(idupb)
				


--print 'avvio merge'
IF (@fin_kind = 3) BEGIN
	
		update DEST  
		set  DEST.previousprevision= newfinyear.previousprevision,		
							DEST.previoussecondaryprev = newfinyear.previoussecondaryprev,
							DEST.previousarrears = newfinyear.previousarrears,
							LT = getdate(), LU='CHIUSURAMANALE'
		from  finyear DEST 
		join  @newfinyear newfinyear on DEST.idfin= newfinyear.idfin and DEST.idupb = newfinyear.idupb

		insert into finyear (ayear, idupb, idfin,previousprevision, previoussecondaryprev, previousarrears,
								ct, cu, lt, lu	)
		select @nextayear, newfinyear.idupb, newfinyear.idfin, 
				newfinyear.previousprevision, newfinyear.previoussecondaryprev, newfinyear.previousarrears,
				GETDATE(), 'CHIUSURAMANUALE', GETDATE(), 'CHIUSURAMANUALE'
		from @newfinyear newfinyear 
		left outer join finyear DEST on DEST.idfin=newfinyear.idfin and DEST.idupb = newfinyear.idupb
		where DEST.idfin is null

END
ELSE 
BEGIN
	update DEST  
		set  DEST.previousprevision= newfinyear.previousprevision,		
							DEST.previousarrears = newfinyear.previousarrears,
							LT = getdate(), LU='CHIUSURAMANALE'
		from finyear DEST 
		join @newfinyear newfinyear on DEST.idfin= newfinyear.idfin and DEST.idupb = newfinyear.idupb

		insert into finyear (ayear, idupb, idfin,previousprevision,  previousarrears,
								ct, cu, lt, lu	)
		select @nextayear, newfinyear.idupb, newfinyear.idfin, 
				newfinyear.previousprevision, newfinyear.previousarrears,
				GETDATE(), 'CHIUSURAMANUALE', GETDATE(), 'CHIUSURAMANUALE'
		from @newfinyear newfinyear 
		left outer join finyear DEST on DEST.idfin=newfinyear.idfin and DEST.idupb = newfinyear.idupb
		where DEST.idfin is null
END

--print 'merge terminata'

DECLARE @curridupb varchar(36)
DECLARE @curridfin int
DECLARE @pp decimal(19,2)
DECLARE @ps decimal(19,2)
DECLARE @pa decimal(19,2)


/*
se ho un cap. nel 2008: CAP08 
nel 2008 ho cap. e articolo : CAP09, ART09
in finlookup c'era CAP08 che puntava a CAP09
ora invece CAP08 deve puntare a ART09
Quindi CAP09 non ha nessuno che lo punta, succede che in finyear la sp NON crea la riga del capitolo MA solo quella dell'articolo!
Questo cursore se esiste una riga in finyear il cui padre non è puntato da nessuno in finlookup
fa o l'UPDATE o la INSERT in finyear
*/

DECLARE #cursor INSENSITIVE CURSOR FOR
SELECT
	fy.idupb,
	f.paridfin,
	SUM(fy.previousprevision),
	SUM(fy.previoussecondaryprev),
	SUM(fy.previousarrears)
FROM finyear fy
JOIN fin f
	ON fy.idfin = f.idfin
WHERE fy.ayear = @nextayear AND NOT EXISTS (select * from #finlookup where f.paridfin = #finlookup.newidfin )
	and f.paridfin is not null
GROUP BY fy.idupb,f.paridfin

FOR READ ONLY
OPEN #cursor
FETCH NEXT FROM #cursor INTO @curridupb, @curridfin, @pp, @ps, @pa

WHILE (@@FETCH_STATUS = 0)
BEGIN

	IF (SELECT COUNT(*) FROM finyear WHERE idupb = @curridupb AND idfin = @curridfin) > 0
	BEGIN
		IF (@fin_kind = 3)
		BEGIN
			UPDATE finyear SET
				previousprevision = @pp,
				previoussecondaryprev = @ps,
				previousarrears = @pa,
				lu = 'CHIUSURAMANUALE'
			WHERE finyear.idupb = @curridupb
				AND finyear.idfin = @curridfin
		END
		ELSE
		BEGIN
			UPDATE finyear SET
				previousprevision = @pp,
				previousarrears = @pa,
				lu = 'CHIUSURAMANUALE'
			WHERE finyear.idupb = @curridupb
				AND finyear.idfin = @curridfin
		END
	END
	ELSE
	BEGIN
		IF (@fin_kind = 3)
		BEGIN
			INSERT INTO finyear
			(
				ayear, idupb, idfin,
				previousprevision, previoussecondaryprev, previousarrears,
				ct, cu, lt, lu
			)
			VALUES
			(
				@nextayear, @curridupb, @curridfin, 
				@pp, @ps, @pa,
				GETDATE(), 'CHIUSURAMANUALE', GETDATE(), 'CHIUSURAMANUALE'
			)
		END
		ELSE
		BEGIN
			INSERT INTO finyear
			(
				ayear, idupb, idfin,
				previousprevision, previousarrears,
				ct, cu, lt, lu
			)
			VALUES
			(
				@nextayear, @curridupb, @curridfin, 
				@pp, @pa,
				GETDATE(), 'CHIUSURAMANUALE', GETDATE(), 'CHIUSURAMANUALE'
			)
		END
	END
	FETCH NEXT FROM #cursor INTO @curridupb, @curridfin, @pp, @ps, @pa
END
CLOSE #cursor
DEALLOCATE #cursor

--- Annullo la creazione di eventuali righe su voci di bilancio non operative in finyear per non avere problemi di totalizzazione
DELETE   FROM finyear WHERE idfin IN (
SELECT f.idfin from finyear fy
	JOIN fin f
		ON fy.idfin = f.idfin
	JOIN finlevel
		ON finlevel.ayear = f.ayear	AND finlevel.nlevel = f.nlevel
		where  f.ayear=@nextayear
		AND  finlevel.flag&2=0)
and finyear.ayear = @nextayear


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--compute_transf_prevision 2015, '31-12-2015'

