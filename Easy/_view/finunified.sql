-- CREAZIONE VISTA finunified
IF EXISTS(select * from sysobjects where id = object_id(N'[finunified]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finunified]
GO


CREATE   VIEW [finunified]
(
	idfin,
	ayear,
	flag,
	finpart,
	codefin,
	paridfin,
	nlevel,
--	sortcode,
	idman,
	manager,
	printingorder,
	title,
	prevision,
	currentprevision,		--	+ corrente prev. princ.
	availableprevision,		--	+ disponibile prev. princ.
	previousprevision,
	secondaryprev,
	currentsecondaryprev,		--	+ corrente prev. sec.
	availablesecondaryprev,		--	+ disponibile prev. sec.
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	expiration,
	cupcode,
	idacc,
	codeacc,
	account,
	cu,
	ct,
	lu,
	lt
)
AS
SELECT
fin.idfin,
fin.ayear,
fin.flag,
CASE
	WHEN ((fin.flag&1)=0) THEN 'E'
	WHEN ((fin.flag&1)=1) THEN 'S'
END,
fin.codefin,
fin.paridfin,
fin.nlevel,
--fin.sortcode,
manager.idman,
manager.title,
fin.printingorder,
fin.title,
-- Previsione Principale Esercizio Corrente
(select sum(ISNULL(currentprev,0)) from upbtotal where idfin=fin.idfin),
--	Previsione Attuale: previsione corrente - variazioni di previsione. SA 
(select isnull(sum(ISNULL(currentprev,0) + ISNULL(previsionvariation,0)),0) 
	from upbtotal where idfin=fin.idfin),
--	Disponibile: previsione corrente + var.di previsione - movimenti di spesa. SA
 	(select isnull(sum( ISNULL(currentprev,0) + ISNULL(previsionvariation,0)),0)
		from upbtotal where idfin=fin.idfin)
	-
 	CASE
	WHEN ((fin.flag&1)=1) THEN
		(				
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
				(select isnull(sum(ISNULL(totalcompetency,0)),0) 
				from upbexpensetotal JOIN uniconfig 
				ON upbexpensetotal.nphase = uniconfig.expensefinphase
				where idfin = fin.idfin
				)
			ELSE
				(select isnull(sum(ISNULL(totalcompetency,0)+ ISNULL(totalarrears,0)),0) 
				from upbexpensetotal JOIN uniconfig 
				ON upbexpensetotal.nphase = uniconfig.expensefinphase
				where idfin = fin.idfin
				)
			END
		)
	WHEN ((fin.flag&1)=0)THEN
		(
			CASE 
			WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3)  THEN
				(select isnull(sum(ISNULL(totalcompetency,0)),0) 
				from upbincometotal JOIN uniconfig 
				ON upbincometotal.nphase = uniconfig.incomefinphase
				where idfin = fin.idfin
				)
			ELSE
				(select isnull(sum(ISNULL(totalcompetency,0) 
				+ ISNULL(totalarrears,0)),0)
				from upbincometotal JOIN uniconfig 
				ON upbincometotal.nphase = uniconfig.incomefinphase
				where idfin = fin.idfin
				)
			END
		) 
   	END,
-- Previsione Principale Esercizio Precedente
	(select sum(ISNULL(previousprev,0)) from upbtotal where idfin=fin.idfin),
-- Previsione Secondaria Esercizio Corrente
	(select sum(ISNULL(currentsecondaryprev,0)) from upbtotal where idfin=fin.idfin),
-- Calcolo Previsione Secondaria Attuale,	SA
	(select (sum(ISNULL(currentsecondaryprev,0) + ISNULL(secondaryvariation,0))) 
		from upbtotal where idfin=fin.idfin),
-- Calcolo Previsione Secondaria Disponibile  =  Previsione attuale - somma ( totalecompetenza+totaleresidui), SA
	(select isnull(sum(ISNULL(currentsecondaryprev,0) + ISNULL(secondaryvariation,0)),0)
		from upbtotal where idfin=fin.idfin)
   -
    CASE
	WHEN ((fin.flag&1)=1) THEN
		(select isnull(sum(ISNULL(totalcompetency,0)+ ISNULL(totalarrears,0)),0) 
			from upbexpensetotal JOIN uniconfig 
				ON upbexpensetotal.nphase = uniconfig.expensefinphase	
			where idfin = fin.idfin
			)
	WHEN ((fin.flag&1)=0) THEN
		(select isnull(sum(ISNULL(totalcompetency,0) + ISNULL(totalarrears,0)),0)
			from upbincometotal JOIN uniconfig 
				ON upbincometotal.nphase = uniconfig.incomefinphase	
			where idfin = fin.idfin
			)
   END,
-- Previsione Secondaria Esercizio Precedente
(select sum (previoussecondaryprev) from upbtotal where idfin=fin.idfin),
-- Residui Presunti (Correnti)
(select sum(currentarrears) from upbtotal where idfin=fin.idfin),
-- Residui Effettivi (Precendenti)
(select sum(previousarrears) from upbtotal where idfin=fin.idfin),
-- Previsione Anno 2
(select sum(prevision2) from finyear where idfin=fin.idfin),
-- Previsione Anno 3
(select sum(prevision3) from finyear where idfin=fin.idfin),
-- Previsione Anno 4
(select sum(prevision4) from finyear where idfin=fin.idfin),
-- Previsione Anno 5
(select sum(prevision5) from finyear where idfin=fin.idfin),
finlast.expiration,
finlast.cupcode,
finlast.idacc,
account.codeacc, 
account.title,
fin.cu,
fin.ct,
fin.lu,
fin.lt
	FROM fin 
	(NOLOCK) INNER JOIN finlevel
	ON finlevel.ayear = fin.ayear
	AND finlevel.nlevel = fin.nlevel 
	LEFT OUTER JOIN finlast (NOLOCK)
	ON finlast.idfin = fin.idfin
	LEFT OUTER JOIN account (NOLOCK)		
	ON account.idacc = finlast.idacc
	LEFT OUTER JOIN manager (NOLOCK)
	ON manager.idman = finlast.idman
	--LEFT OUTER JOIN manager managerfin
	--ON managerfin.idman = fin.idman
	





GO

