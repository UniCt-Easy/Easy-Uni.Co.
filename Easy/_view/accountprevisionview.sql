-- CREAZIONE VISTA accountprevisionview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountprevisionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountprevisionview]
GO


CREATE        VIEW accountprevisionview
(
	idacc,
	ayear,
	codeacc,
	account,
	nlevel,
	leveldescr,
	paridacc,
	idman,
	manager,
	printingorder,
	title,
	prevision,
	currentprevision,
	availableprevision,
	prevision2,
	currentprevision2,
	availableprevision2,
	prevision3,
	currentprevision3,
	availableprevision3,
	prevision4,
	currentprevision4,
	availableprevision4,
	prevision5,
	currentprevision5,
	availableprevision5,
	flagusable,

	idupb,
	codeupb,
	upb,
	idtreasurer,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	cupcode,
	cigcode,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
SELECT account.idacc, account.ayear,    
	account.codeacc,  account.title,
    	account.nlevel, accountlevel.description, 
    	account.paridacc,
    upb.idman,
    manager.title,
    account.printingorder,account.title,

-- Calcolo Previsione Esercizio Corrente = SOMMA delle prevesercizio corr sottostanti, sul primo livello operativo di bilancio
	ISNULL(upbaccounttotal.currentprev,0),
-- Calcolo Previsione Attuale = SOMMA delle prevesercizio corr sottostanti, sul primo livello operativo di bilancio +  la SOMMA di totbilancio.totvarprevisione 
	ISNULL(upbaccounttotal.currentprev,0) + ISNULL(upbaccounttotal.previsionvariation,0),
-- Calcolo Previsione Disponibile = Previsione attuale - somma totbilanciospesa.totalecompetenza (se bil.competenza) o  Previsione attuale - somma totalecompetenza-totaleresidui (se bil. Cassa)
	ISNULL(upbaccounttotal.currentprev,0) + ISNULL(upbaccounttotal.previsionvariation,0) - ISNULL(upbepexptotal.total,0),

	ISNULL(upbaccounttotal.currentprev2,0),
	ISNULL(upbaccounttotal.currentprev2,0) + ISNULL(upbaccounttotal.previsionvariation2,0),
	ISNULL(upbaccounttotal.currentprev2,0) + ISNULL(upbaccounttotal.previsionvariation2,0) - ISNULL(upbepexptotal.total2,0),

    ISNULL(upbaccounttotal.currentprev3,0),
	ISNULL(upbaccounttotal.currentprev3,0) + ISNULL(upbaccounttotal.previsionvariation3,0),
	ISNULL(upbaccounttotal.currentprev3,0) + ISNULL(upbaccounttotal.previsionvariation3,0) - ISNULL(upbepexptotal.total3,0),
	
    ISNULL(upbaccounttotal.currentprev4,0),
	ISNULL(upbaccounttotal.currentprev4,0) + ISNULL(upbaccounttotal.previsionvariation4,0),
	ISNULL(upbaccounttotal.currentprev4,0) + ISNULL(upbaccounttotal.previsionvariation4,0) - ISNULL(upbepexptotal.total4,0),


    ISNULL(upbaccounttotal.currentprev5,0),
	ISNULL(upbaccounttotal.currentprev5,0) + ISNULL(upbaccounttotal.previsionvariation5,0),
	ISNULL(upbaccounttotal.currentprev5,0) + ISNULL(upbaccounttotal.previsionvariation5,0) - ISNULL(upbepexptotal.total5,0),

   	accountlevel.flagusable,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idtreasurer,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upb.cupcode,
	upb.cigcode,
	account.cu, 	account.ct, account.lu, 	account.lt
	FROM account 
	CROSS JOIN upb (NOLOCK)
	 INNER JOIN accountlevel 
		ON accountlevel.ayear = account.ayear	
		AND accountlevel.nlevel = account.nlevel 
	LEFT OUTER JOIN upbaccounttotal (NOLOCK)
		ON account.idacc = upbaccounttotal.idacc 
		AND upb.idupb = upbaccounttotal.idupb
	LEFT OUTER JOIN	upbepexptotal (NOLOCK)
		ON account.idacc = upbepexptotal.idacc
		AND upb.idupb = upbepexptotal.idupb
		AND upbepexptotal.nphase = 1
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = upb.idman
	




GO
