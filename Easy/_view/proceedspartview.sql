-- CREAZIONE VISTA proceedspartview
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedspartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedspartview]
GO

--clear_table_info'proceedspartview'
--select * from proceedspartview
CREATE                                 VIEW proceedspartview 
	(
	idinc,
	nproceedspart,
	yproceedspart,
	nphase,
	phase,
	ymov,
	nmov,
	idunderwriting,
	underwriting,
	idfin,
	codefin,
	finance,
	
	idupb,
	codeupb,
	upb,
	idtreasurer,
	treasurer,
	
	idupbincome,
	codeupbincome,
	upbincome,	
	idtreasurerincome,
	treasurerincome,
	
	description,
	amount,
	financeincome,
	adate,
	--	> Importo destinato, valorizzato se Te<>Ts
	allocatedamount,
	--	> Importo da Girofondare: importo che non è stato ancora girofondato;
	moneytotransfer,
	--	> Importo Girofondato: importo per cui è stato fatto il girofondo ala cassiere di destinazione;
	moneytransfered,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	cu,
	ct,
	lu,
	lt,
	idtreasurerproceeds,
	treasurerproceeds
	)
	AS SELECT
	proceedspart.idinc,
	proceedspart.nproceedspart,
	proceedspart.yproceedspart,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	income.idunderwriting,
	underwriting.title,
	proceedspart.idfin,
	fin.codefin,
	fin.title,
	
	proceedspart.idupb,
	UU.codeupb,
	UU.title,
	UU.idtreasurer,
	TU.description,

	incomeyear.idupb,
	UE.codeupb,
	UE.title,
	UE.idtreasurer,
	TE.description,
	
	proceedspart.description,
	proceedspart.amount,
	b2.codefin,
	proceedspart.adate,
	--	> allocatedamount = Importo destinato, valorizzato se Te<>Ts
	case 
		when isnull(TP.idtreasurer,0) <>isnull(UU.idtreasurer,0) then proceedspart.amount
		else null
	end,	
	-- > moneytotransfer = Importo da Girofondare: importo che non è stato ancora girofondato;
		case 
		when  ( isnull(TP.idtreasurer,0) <>isnull(UU.idtreasurer,0)) 
				then (proceedspart.amount - 	ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
												and moneytransfer.yproceedspart = proceedspart.yproceedspart)
												,0))
		else null
	end,
	--	> moneytransfered = Importo Girofondato: importo per cui è stato fatto il girofondo la cassiere di destinazione;
		case 
		when  ( isnull(TP.idtreasurer,0) <>isnull(UU.idtreasurer,0)) 
				then ( SELECT SUM(moneytransfer.amount) FROM moneytransfer
						WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
						and moneytransfer.yproceedspart = proceedspart.yproceedspart)
		else null
	end,
	UU.idsor01,
	UU.idsor02,
	UU.idsor03,
	UU.idsor04,
	UU.idsor05,
	proceedspart.cu,
	proceedspart.ct,
	proceedspart.lu,
	proceedspart.lt,
	TP.idtreasurer,
	TP.description
	FROM proceedspart (NOLOCK)
	JOIN income (NOLOCK)
		ON income.idinc = proceedspart.idinc
	JOIN incomelast (NOLOCK)
		ON incomelast.idinc = proceedspart.idinc	
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN fin (NOLOCK)
		ON fin.idfin = proceedspart.idfin
	JOIN upb UU (NOLOCK)
		ON UU.idupb = proceedspart.idupb
	LEFT OUTER JOIN incomeyear
		ON income.idinc = incomeyear.idinc
		AND incomeyear.ayear = proceedspart.yproceedspart
	LEFT OUTER JOIN fin b2
		ON b2.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb UE	
		ON UE.idupb = incomeyear.idupb
	LEFT OUTER JOIN treasurer TE 
		ON TE.idtreasurer = UE.idtreasurer
	LEFT OUTER JOIN treasurer TU
		ON TU.idtreasurer = UU.idtreasurer	
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN treasurer TP
		ON TP.idtreasurer = proceeds.idtreasurer	
	LEFT OUTER JOIN underwriting
		ON underwriting.idunderwriting = income.idunderwriting 	





GO

