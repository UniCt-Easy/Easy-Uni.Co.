-- CREAZIONE VISTA upbitinerationavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[upbitinerationavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbitinerationavailable]
GO
 -- sp_help upbitinerationavailable
-- clear_table_info 'upbitinerationavailable'
-- select * from upbitinerationavailable where ayear = 2018
--select * from columntypes where tablename='upbitinerationavailable'
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
    -- disponibilita_impegni :  (B) disponibile della fase 1
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
	ISNULL( (SELECT SUM(itineration.totalgross) 
		FROM itineration
		WHERE itineration.idupb = upb.idupb
			and (select count(expenseitineration.iditineration) 
					from expenseitineration	
					where expenseitineration.iditineration = itineration.iditineration) = 0
			and (select count(pettycashoperationitineration.iditineration) 
					from pettycashoperationitineration	
					where pettycashoperationitineration.iditineration = itineration.iditineration) = 0
		),0),

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
	ISNULL( (SELECT SUM(itineration.totalgross) 
		FROM itineration
		WHERE itineration.idupb = upb.idupb
			and (select count(expenseitineration.iditineration) 
					from expenseitineration	
					where expenseitineration.iditineration = itineration.iditineration) = 0
			and (select count(pettycashoperationitineration.iditineration) 
					from pettycashoperationitineration	
					where pettycashoperationitineration.iditineration = itineration.iditineration) = 0
		),0),

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
    -- (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
	ISNULL( (SELECT SUM(itineration.totalgross) 
		FROM itineration
		WHERE itineration.idupb = upb.idupb
			and (select count(expenseitineration.iditineration) 
					from expenseitineration	
					where expenseitineration.iditineration = itineration.iditineration) = 0
			and (select count(pettycashoperationitineration.iditineration) 
					from pettycashoperationitineration	
					where pettycashoperationitineration.iditineration = itineration.iditineration) = 0
		),0),
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
