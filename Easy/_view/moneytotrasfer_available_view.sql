
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


-- CREAZIONE VISTA proceedspartview
IF EXISTS(select * from sysobjects where id = object_id(N'[moneytotrasfer_available_view]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [moneytotrasfer_available_view]
GO

--clear_table_info'moneytotrasfer_available_view'
--select * from moneytotrasfer_available_view order by idtreasurer
CREATE                                 VIEW moneytotrasfer_available_view 
	(
	y,   --anno
	n,    -- n.assegnazione o variazione
	kind, -- tipo (assegnazione o storno)
	adate,

	ndet,  --idinc o rownum in caso di storno
	nphase,
	phase,
	ymov,
	nmov,
	

	--parte comune
	idunderwriting,  --finanziamento di destinazione (ossia IN CUI bisogna girofondare)
	underwriting,
	idfin,			--bilancio di destinazione 
	codefin,
	finance,
	
	idupb,		--upb di destinazione 
	codeupb,
	upb,

	idtreasurer,	--cassiere di destinazione 
	treasurer,
	
	idupbincome,	-- upb di provenienza (ossia DA CUI bisogna girofondare)
	codeupbincome,
	upbincome,	

	idtreasurerincome, --cassiere di provenienza
	treasurerincome,

	idfinincome,			--bilancio di provenienza 
	codefinincome,	
	financeincome,

	description,
	amount,

	--	> Importo da Girofondare: importo che non è stato ancora girofondato;
	moneytotransfer,
	--	> Importo Girofondato: importo per cui è stato fatto il girofondo ala cassiere di destinazione;
	moneytransfered,

	idsor01,idsor02,idsor03,idsor04,idsor05
	)
	AS SELECT
	proceedspart.yproceedspart, 
	proceedspart.nproceedspart,
	'assegnazione',
	proceedspart.adate,


	proceedspart.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,

	income.idunderwriting, --finanziamento di destinazione (ossia IN CUI bisogna girofondare)
	underwriting.title,
	fin_dest.idfin,		--bilancio di destinazione
	fin_dest.codefin,
	fin_dest.title,
	
	U_dest.idupb, --upb di destinazione
	U_dest.codeupb,
	U_dest.title,
	T_dest.idtreasurer,		--cassiere di destinazione
	T_dest.description,

	U_origin.idupb,		--upb di origine
	U_origin.codeupb,
	U_origin.title,

	fin_origin.idfin,		--bilancio di origine
	fin_origin.codefin,
	fin_origin.title,

	T_origin.idtreasurer,	--cassiere di origine (ossia quello della reversale con cui è effettuato l'incasso)
	T_origin.description,
	
	proceedspart.description+'-'+income.description,
	proceedspart.amount,
	
	
	-- > moneytotransfer = Importo da Girofondare: importo che non è stato ancora girofondato;
		proceedspart.amount - 	ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
												and moneytransfer.yproceedspart = proceedspart.yproceedspart)
												,0)
		
	,
	--	> moneytransfered = Importo Girofondato: importo per cui è stato fatto il girofondo la cassiere di destinazione;
		( SELECT SUM(moneytransfer.amount) FROM moneytransfer
						WHERE moneytransfer.nproceedspart = proceedspart.nproceedspart
						and moneytransfer.yproceedspart = proceedspart.yproceedspart)
		
	,
	U_dest.idsor01, --upb di destinazione dell'assegnazione
	U_dest.idsor02,
	U_dest.idsor03,
	U_dest.idsor04,
	U_dest.idsor05
	

	FROM proceedspart (NOLOCK)
	JOIN fin fin_dest (NOLOCK)
		ON fin_dest.idfin = proceedspart.idfin
	JOIN upb U_dest (NOLOCK)
		ON U_dest.idupb = proceedspart.idupb
	LEFT OUTER JOIN treasurer T_dest (NOLOCK)
		ON T_dest.idtreasurer = U_dest.idtreasurer	

	JOIN income (NOLOCK)
		ON income.idinc = proceedspart.idinc
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = proceedspart.idinc
	JOIN upb U_origin (NOLOCK)
		ON U_origin.idupb = incomeyear.idupb
	JOIN fin fin_origin (NOLOCK)
		ON fin_origin.idfin = incomeyear.idfin

	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	LEFT OUTER JOIN underwriting (NOLOCK)
		ON underwriting.idunderwriting = income.idunderwriting 	

	JOIN incomelast (NOLOCK)
		ON incomelast.idinc = proceedspart.idinc	
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN treasurer T_origin (NOLOCK)
		ON T_origin.idtreasurer = proceeds.idtreasurer	
	WHERE T_origin.idtreasurer <> U_dest.idtreasurer
UNION ALL
	select	FV.yvar,
			FV.nvar,
			'storno',
			FV.adate,

			FVD_dest.rownum,

			null,null,null,null,

			--parte comune
			
	uw_dest.idunderwriting,  --finanziamento di destinazione (ossia IN CUI bisogna girofondare)
	uw_dest.title,

	f_dest.idfin,			--bilancio di destinazione 
	f_dest.codefin,
	f_dest.title,
	
	u_dest.idupb,		--upb di destinazione 
	u_dest.codeupb,
	u_dest.title,

	t_dest.idtreasurer,	--cassiere di destinazione 
	t_dest.description,
	
	u_origin.idupb,	-- upb di provenienza (ossia DA CUI bisogna girofondare)
	u_origin.codeupb,
	u_origin.title,	

	f_origin.idfin,			--bilancio di provenienza 
	f_origin.codefin,
	f_origin.title,

	t_origin.idtreasurer, --cassiere di provenienza
	t_origin.description,


	FVD_dest.description+'-'+FV.description,
	FVD_dest.amount,

	--	> Importo da Girofondare: importo che non è stato ancora girofondato;
		FVD_dest.amount - 	ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.yvar = FVD_dest.yvar
												and moneytransfer.nvar = FVD_dest.nvar
												and moneytransfer.rownum = FVD_dest.rownum
								) ,0),

	--	> Importo Girofondato: importo per cui è stato fatto il girofondo al cassiere di destinazione;
		ISNULL(	(SELECT SUM(moneytransfer.amount) FROM moneytransfer
												WHERE moneytransfer.yvar = FVD_dest.yvar
												and moneytransfer.nvar = FVD_dest.nvar
												and moneytransfer.rownum = FVD_dest.rownum)
												,0),

	u_dest.idsor01,u_dest.idsor02,u_dest.idsor03,u_dest.idsor04,u_dest.idsor05
	

	from finvar FV (NOLOCK)
		join finvardetail FVD_dest (NOLOCK)
			ON FVD_dest.yvar=FV.yvar and FVD_dest.nvar=FV.nvar AND FVD_dest.amount > 0
		join fin f_dest (NOLOCK)
			on FVD_dest.idfin=f_dest.idfin and f_dest.flag&1<>0
		join upb u_dest (NOLOCK)
			on FVD_dest.idupb=u_dest.idupb 
		join treasurer t_dest (NOLOCK)
			on u_dest.idtreasurer=t_dest.idtreasurer 
		join underwriting uw_dest (NOLOCK)
			on FVD_dest.idunderwriting=uw_dest.idunderwriting 
		join finvardetail FVD_origin (NOLOCK)
			ON FVD_origin.yvar=FV.yvar and FVD_origin.nvar=FV.nvar AND FVD_origin.amount < 0
		join fin f_origin  (NOLOCK)
			on FVD_origin.idfin=f_origin.idfin and f_origin.flag&1<>0
		join upb u_origin (NOLOCK)
			on FVD_origin.idupb=u_origin.idupb 
		join treasurer t_origin (NOLOCK)
			on u_origin.idtreasurer=t_origin.idtreasurer 
	where FV.moneytransfer='S'


GO

