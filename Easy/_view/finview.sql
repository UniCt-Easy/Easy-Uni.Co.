-- CREAZIONE VISTA finview
IF EXISTS(select * from sysobjects where id = object_id(N'[finview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finview]
GO






CREATE  VIEW [finview]
(
	idfin,
	ayear,
	finpart,
	codefin,
	nlevel,
	leveldescr,
	paridfin,
	idman,
	manager,
	printingorder,
	title,
	prevision,
	currentprevision,
	availableprevision,
	previousprevision,
	secondaryprev,
	currentsecondaryprev,
	availablesecondaryprev,
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	expiration,
	limit,
	flag,
	flagusable,
	idupb,
	codeupb,
	upb,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	cupcode,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
SELECT fin.idfin, fin.ayear, 
   	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.codefin, 
    	fin.nlevel, finlevel.description, 
    	fin.paridfin,
    ISNULL(upb.idman,finlast.idman),
    ISNULL(manager.title,managerfin.title),
    fin.printingorder,
    fin.title,
-- Calcolo Previsione Esercizio Corrente = SOMMA delle prevesercizio corr sottostanti, sul primo livello operativo di bilancio
	ISNULL(upbtotal.currentprev,0),
-- Calcolo Previsione Attuale = SOMMA delle prevesercizio corr sottostanti, sul primo livello operativo di bilancio +  la SOMMA di totbilancio.totvarprevisione 
	ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0),
-- Calcolo Previsione Disponibile = Previsione attuale - somma totbilanciospesa.totalecompetenza (se bil.competenza) o  Previsione attuale - somma totalecompetenza-totaleresidui (se bil. Cassa)
	ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) -
    CASE
	WHEN ((fin.flag&1)=1)  THEN --Spesa
		(				
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear)IN (1,3) THEN
				ISNULL(upbexpensetotal.totalcompetency,0)
			ELSE
				ISNULL(upbexpensetotal.totalcompetency,0) + ISNULL(upbexpensetotal.totalarrears,0)
			END
		)
	WHEN  ((fin.flag&1)=0) THEN --Entrata
		(
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
				ISNULL(upbincometotal.totalcompetency,0)
			ELSE
				ISNULL(upbincometotal.totalcompetency,0) + ISNULL(upbincometotal.totalarrears,0)
			END
		)
   	END,
	-- Calcolo Previsione Esercizio Precedente = somma prevesercizioprec su livelli operativi sottostanti
	upbtotal.previousprev,
	-- Calcolo Previsione Secondaria Esercizio Corrente = somma prevseceserciziocorr su livelli operativi sottostanti
	upbtotal.currentsecondaryprev,
	-- Calcolo Previsione Secondaria Attuale
	ISNULL(upbtotal.currentsecondaryprev,0) + ISNULL(upbtotal.secondaryvariation,0),
	-- Calcolo Previsione Secondaria Disponibile  =  Previsione attuale - somma ( totalecompetenza+totaleresidui)
	ISNULL(upbtotal.currentsecondaryprev,0) + ISNULL(upbtotal.secondaryvariation,0) -
    	CASE
	WHEN ((fin.flag&1) = 1) THEN --Spesa
		ISNULL(upbexpensetotal.totalcompetency,0) + ISNULL(upbexpensetotal.totalarrears,0)
	WHEN ((fin.flag&1) = 0) THEN --Entrata
		ISNULL(upbincometotal.totalcompetency,0) + ISNULL(upbincometotal.totalarrears,0)
  	END,
	-- Calcolo Previsione Secondaria Esercizio Precedente
	upbtotal.previoussecondaryprev,
	-- Calcolo Ripartizione
	upbtotal.currentarrears,
	-- Calcolo Ripartizione Precedente
	upbtotal.previousarrears,
	finyear.prevision2,
	finyear.prevision3,
	finyear.prevision4,
	finyear.prevision5,
	finlast.expiration, 
	finyear.limit,
	fin.flag,
   	CASE
		when (( finlevel.flag & 2)<>0) then 'S'
		else 'N'
	End,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	finlast.cupcode,
	fin.cu, 
	fin.ct, fin.lu, 
	fin.lt
	FROM fin 
	CROSS JOIN upb
	CROSS JOIN uniconfig		(NOLOCK) 
	INNER JOIN finlevel		ON finlevel.ayear = fin.ayear			AND finlevel.nlevel = fin.nlevel 
	LEFT OUTER JOIN upbtotal (NOLOCK)		ON fin.idfin = upbtotal.idfin 		AND upb.idupb = upbtotal.idupb
	LEFT OUTER JOIN upbincometotal		(NOLOCK) ON fin.idfin = upbincometotal.idfin	AND upb.idupb = upbincometotal.idupb	AND upbincometotal.nphase = uniconfig.incomefinphase
	LEFT OUTER JOIN	upbexpensetotal (NOLOCK)	ON fin.idfin = upbexpensetotal.idfin	AND upb.idupb = upbexpensetotal.idupb	AND upbexpensetotal.nphase = uniconfig.expensefinphase
	LEFT OUTER JOIN finlast (NOLOCK)		ON fin.idfin = finlast.idfin
	LEFT OUTER JOIN manager (NOLOCK)		ON manager.idman = upb.idman
	LEFT OUTER JOIN manager managerfin		ON managerfin.idman = finlast.idman
	LEFT OUTER JOIN finyear		ON fin.idfin = finyear.idfin		AND upb.idupb = finyear.idupb



GO

