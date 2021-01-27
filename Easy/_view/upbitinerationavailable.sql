
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


-- CREAZIONE VISTA upbitinerationavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[upbitinerationavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbitinerationavailable]
GO
-- setuser'amm'
-- setuser'amministrazione'
-- sp_help upbitinerationavailable
-- clear_table_info 'upbitinerationavailable'
-- select * from upbitinerationavailable where ayear = 2018
-- select * from columntypes where tablename='upbitinerationavailable'
CREATE VIEW [upbitinerationavailable]
(
	idupb,
	codeupb,
	title,
	paridupb,
	idunderwriter,
	idman,
	manager,
	underwriter,
	printingorder,
	requested,
	granted,
	previousappropriation,
	previousassessment,
	expiration,
	assured,
	active,
	cupcode,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flagactivity,
	flagkind,
	newcodeupb,
	start,
	stop,
	cigcode,
	idtreasurer,
	codetreasurer,
	idepupbkind,
	flag,
	ayear,
	--totresidual,
	previsionedisponibile_impegni,  --> (A) disponibile ad impegnare (creare una nuova fase 1)
    disponibilita_impegni,			--> (B) disponibilità degli impegni
    missioniupbnoncontabilizzate,	--> (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
    disptotale,						--> la somma dei precedenti (A+B+C)
	differenzadisponibilita,		--> Differenza Disponibilità  (B-C)
	cu, 
	ct, 
	lu, 
	lt
)
AS 
SELECT 
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.paridupb,
	upb.idunderwriter,
	upb.idman,
	manager.title,
	underwriter.description,
	upb.printingorder,
	upb.requested,
	upb.granted,
	upb.previousappropriation,
	upb.previousassessment,
	upb.expiration,
	upb.assured,
	upb.active,
	upb.cupcode,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upb.flagactivity,
	upb.flagkind,
	upb.newcodeupb,
	upb.start,
	upb.stop,
	upb.cigcode,
	upb.idtreasurer,
	treasurer.codetreasurer,
	upb.idepupbkind,
	upb.flag,
	accountingyear.ayear, 
	-- previsionedisponibile_impegni:  (A) disponibile ad impegnare (creare una nuova fase 1)
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
			JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <> 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0 )
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0),
    -- disponibilita_impegni :  (B) disponibile della fase 1  rispetto alla fase 2
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase /*Fase Impegno*/
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0)
	-
		ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase + 1 /*Fase successiva all'impegno*/
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0),
    -- missioniupbnoncontabilizzate:  (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)

	
		ISNULL( (SELECT SUM (ISNULL(itineration.supposedamount,0) +  ISNULL(itineration.supposedfood,0) + ISNULL(itineration.supposedliving,0) + ISNULL(itineration.supposedtravel,0) )
		 FROM itineration
		WHERE itineration.idupb = upb.idupb and itineration.yitineration<= accountingyear.ayear	and isnull(itineration.active,'S') <> 'N' 
		--- MISSIONE NON SALDATA  
		AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4))
			)
		 ,0)
 
 		-
		ISNULL(	
			(SELECT SUM(EY_start.amount)
			FROM expenseitineration mov			(nolock)
			JOIN expense s						(nolock)		ON s.idexp = mov.idexp
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE (/*(mov.movkind = 4)OR*/(mov.movkind = 6)) AND itineration.idupb = upb.idupb	and EY_start.ayear <= accountingyear.ayear	 and itineration.yitineration<= accountingyear.ayear	 and isnull(itineration.active,'S') <> 'N'  
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4))
			)
		,0) 
		-
 
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p (NOLOCK) 	ON mov.idpettycash = p.idpettycash
													AND mov.yoperation = p.yoperation
													AND mov.noperation = p.noperation
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			WHERE   mov.movkind = 6  AND itineration.idupb = upb.idupb	 and p.yoperation <= accountingyear.ayear and itineration.yitineration<= accountingyear.ayear	and isnull(itineration.active,'S') <> 'N' 
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4))
			) 			
		,0)
	,
 
    -- Disptotale: somma dei precedenti (A+B+C)

	-- (A) disponibile ad impegnare 
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
			JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <> 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0 )
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0)
	+
    --  (B) disponibile della fase 1
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase /*Fase Impegno*/
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0)
	-
		ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase + 1 /*Fase successiva all'impegno*/
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0)
	+
    -- (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
	ISNULL( (SELECT SUM (ISNULL(itineration.supposedamount,0) +  ISNULL(itineration.supposedfood,0) + ISNULL(itineration.supposedliving,0) + ISNULL(itineration.supposedtravel,0) )
		 FROM itineration
		WHERE itineration.idupb = upb.idupb and itineration.yitineration<= accountingyear.ayear	  and isnull(itineration.active,'S') <> 'N' 
		--- MISSIONE NON SALDATA  
		AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4))
		)
		 ,0)
 
 		-
		ISNULL(	
			(SELECT SUM(EY_start.amount)
			FROM expenseitineration mov			(nolock)
			JOIN expense s						(nolock)		ON s.idexp = mov.idexp
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE (/*(mov.movkind = 4)OR*/(mov.movkind = 6)) AND itineration.idupb = upb.idupb	and EY_start.ayear <= accountingyear.ayear	 and itineration.yitineration<= accountingyear.ayear	and isnull(itineration.active,'S') <> 'N' 
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4)) 
			)
		,0) 
		-
 
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p (NOLOCK) 	ON mov.idpettycash = p.idpettycash
													AND mov.yoperation = p.yoperation
													AND mov.noperation = p.noperation
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			WHERE   mov.movkind = 6  AND itineration.idupb = upb.idupb	 and p.yoperation <= accountingyear.ayear and itineration.yitineration<= accountingyear.ayear	and isnull(itineration.active,'S') <> 'N' 
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4))
		) 			
		,0)
		,

	 -- Differenza Disponibilità = come B-C 
    --  (B) disponibile della fase 1
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase /*Fase Impegno*/
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0)
	-
		ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase + 1 /*Fase successiva all'impegno*/
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0)
	-
	(
    -- (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
	ISNULL( (SELECT SUM (ISNULL(itineration.supposedamount,0) +  ISNULL(itineration.supposedfood,0) + ISNULL(itineration.supposedliving,0) + ISNULL(itineration.supposedtravel,0) )
		 FROM itineration
		WHERE itineration.idupb = upb.idupb and itineration.yitineration<= accountingyear.ayear	and isnull(itineration.active,'S') <> 'N'  
		--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4))
		)
		 ,0)
 
 		-
		ISNULL(	
			(SELECT SUM(EY_start.amount)
			FROM expenseitineration mov			(nolock)
			JOIN expense s						(nolock)		ON s.idexp = mov.idexp
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE (/*(mov.movkind = 4)OR*/(mov.movkind = 6)) AND itineration.idupb = upb.idupb	and EY_start.ayear <= accountingyear.ayear	 and itineration.yitineration<= accountingyear.ayear	and isnull(itineration.active,'S') <> 'N' 
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4)) 
			)
		,0) 
		- 
 
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p (NOLOCK) 	ON mov.idpettycash = p.idpettycash
													AND mov.yoperation = p.yoperation
													AND mov.noperation = p.noperation
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			WHERE   mov.movkind = 6  AND itineration.idupb = upb.idupb	 and p.yoperation <= accountingyear.ayear and itineration.yitineration<= accountingyear.ayear	and isnull(itineration.active,'S') <> 'N' 
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= accountingyear.ayear	AND (mov.movkind = 4))
			) 			
		,0)
		),
	upb.cu, 
	upb.ct, 
	upb.lu, 
	upb.lt
FROM upb (nolock)
CROSS JOIN accountingyear (nolock)
JOIN config (nolock)				ON config.ayear = accountingyear.ayear
JOIN manager with (nolock)	ON manager.idman = upb.idman
LEFT OUTER JOIN underwriter with (nolock)	ON underwriter.idunderwriter = upb.idunderwriter
LEFT OUTER JOIN treasurer 	ON upb.idtreasurer=treasurer.idtreasurer
GO
