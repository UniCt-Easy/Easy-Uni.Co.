
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


-- CREAZIONE VISTA [upbunderwritingyearview]
IF EXISTS(select * from sysobjects where id = object_id(N'[upbunderwritingyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbunderwritingyearview]
GO



CREATE    VIEW [upbunderwritingyearview] (
	idunderwriting,
	codeunderwriting,
	underwriting,
	idupb,
	codeupb,	
	upb,
	idfin,
	codefin,
	fin,
	flag, 
	finpart,
	ayear,
	initialprevision,			-- previsione principale iniziale 
	varprevision,				-- variazioni di previsione principale
	actualprevision,			-- previsione principale CORRENTE 
	initialsecondaryprev,		-- previsione iniziale di cassa
	varsecondaryprev,			-- variazioni di previsione di cassa
	actualsecondaryprev,		-- previsione di cassa CORRENTE 
	totcreditpart,				-- tot. assegnazioni crediti
	totpreceedspart,			-- tot. assegnazioni incassi 
	assessment,		--accertamenti	(include anche i residui per chi gestisce solo la cassa)
	appropriation,	--impegni (include anche i residui per chi gestisce solo la cassa)
	proceeds,			--incassi	(include anche i residui per chi gestisce solo la cassa)
	payment,			--pagamenti (include anche i residui per chi gestisce solo la cassa)
	incomeprevavailable,	-- disp ad accertare =  previsione principale meno accertamenti (+ residui per chi ha sola cassa)
	expenseprevavailable,	-- disp. a impegnare = previsione principale meno impegni (+ residui per chi ha sola cassa)
	proceedsprevavailable,	-- disp. ad incassare = previsione principale di cassa meno incassi (+ residui per chi ha sola cassa),
	paymentprevavailable,	-- disp a pagare = previsione principale di cassa meno pagamenti (+ residui per chi ha sola cassa),
	creditavailable,	-- crediti disponibili  = totale crediti assegnati - impegni 
	proceedsavailable,	-- incassi disponibili = totale incassi assegnati - pagamenti
	active
)

AS SELECT
	upbunderwritingtotal.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	upbunderwritingtotal.idupb,
	upb.codeupb,
	upb.title,
	upbunderwritingtotal.idfin,
	fin.codefin,
	fin.title,
	fin.flag, 
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.ayear,
	-- initialprevision
	ISNULL(upbunderwritingtotal.currentprev,0),
	-- varprevision
	ISNULL(upbunderwritingtotal.previsionvariation,0),
	-- actualprevision,
	ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0),
	-- initialsecondaryprev
	ISNULL(upbunderwritingtotal.currentsecondaryprev,0),
	-- varsecondaryprev
	ISNULL(upbunderwritingtotal.secondaryvariation,0),
	-- actualsecondaryprev
	ISNULL(upbunderwritingtotal.currentsecondaryprev,0) + ISNULL(upbunderwritingtotal.secondaryvariation,0),
	-- totcreditpart
	ISNULL(upbunderwritingtotal.totcreditpart,0),
	-- tonpreceedspart
	ISNULL(upbunderwritingtotal.totproceedspart,0),
	--assessment = accertamenti
	Case when (( fin.flag & 1) = 0)
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomefinphase.totalcompetency,0)
			ELSE
					ISNULL(Incomefinphase.totalcompetency,0) + ISNULL(Incomefinphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- appropriation = impegni
	Case when (( fin.flag & 1) <> 0) 
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) 
				THEN
					ISNULL(Expensefinphase.totalcompetency,0)
				ELSE
					ISNULL(Expensefinphase.totalcompetency,0) + ISNULL(Expensefinphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- proceeds
	Case when (( fin.flag & 1) = 0)
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomemaxphase.totalcompetency,0)
			ELSE
					ISNULL(Incomemaxphase.totalcompetency,0) + ISNULL(Incomemaxphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- payment 
	Case when (( fin.flag & 1) <> 0) 
		Then
			(CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) 
				THEN
					ISNULL(Expensemaxphase.totalcompetency,0)
				ELSE
					ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0)
			END)
		Else 0
	End	,
	-- incomeprevavailable = disp ad accertare
	Case when (( fin.flag & 1) = 0)
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Incomefinphase.totalcompetency,0)
				ELSE
						ISNULL(Incomefinphase.totalcompetency,0) + ISNULL(Incomefinphase.totalarrears,0)
				END)
		Else 0
	End	,
	-- expenseprevavailable = disp. a impegnare
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (	CASE 
				WHEN (SELECT fin_kind from config where config.ayear=fin.ayear) IN (1,3) THEN
					ISNULL(Expensefinphase.totalcompetency,0)
				ELSE
					ISNULL(Expensefinphase.totalcompetency,0) + ISNULL(Expensefinphase.totalarrears,0)
				END)
		Else 0		
	End,
	-- proceedspreavailable = disp. ad incassare
		Case when (( fin.flag & 1) = 0) 
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (ISNULL(Incomemaxphase.totalcompetency,0) + ISNULL(Incomemaxphase.totalarrears,0))
		Else 0
	End	,
	-- paymentpreavailable = disp a pagare
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.currentprev,0) + ISNULL(upbunderwritingtotal.previsionvariation,0) 
			- (ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
		Else 0		
	End,
	-- creditavailable
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.totcreditpart,0) + ISNULL(upbunderwritingtotal.creditvariation,0) - ISNULL(Expensefinphase.totalcompetency,0)
		Else 0	
	End,
	-- proceedsavailable 
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbunderwritingtotal.totproceedspart,0) + ISNULL(upbunderwritingtotal.proceedsvariation,0) - (	ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
			
		Else 0	
	End,
	underwriting.active
FROM upbunderwritingtotal 
CROSS JOIN uniconfig
JOIN upb
	ON upbunderwritingtotal.idupb = upb.idupb
JOIN fin
	ON upbunderwritingtotal.idfin = fin.idfin
JOIN finlast 
	ON finlast.idfin=fin.idfin
JOIN underwriting
	ON upbunderwritingtotal.idunderwriting = underwriting.idunderwriting 
LEFT OUTER JOIN underwritingincometotal Incomefinphase
	ON Incomefinphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Incomefinphase.idupb = upbunderwritingtotal.idupb
	AND Incomefinphase.idfin = upbunderwritingtotal.idfin
	AND Incomefinphase.nphase = uniconfig.incomefinphase
LEFT OUTER JOIN underwritingexpensetotal Expensefinphase
	ON Expensefinphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Expensefinphase.idupb = upbunderwritingtotal.idupb
	AND Expensefinphase.idfin = upbunderwritingtotal.idfin
	AND Expensefinphase.nphase = uniconfig.expensefinphase
LEFT OUTER JOIN underwritingincometotal Incomemaxphase
	ON Incomemaxphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Incomemaxphase.idupb = upbunderwritingtotal.idupb
	AND Incomemaxphase.idfin = upbunderwritingtotal.idfin
	AND Incomemaxphase.nphase = (select max(nphase) from incomephase)
LEFT OUTER JOIN underwritingexpensetotal Expensemaxphase
	ON Expensemaxphase.idunderwriting = upbunderwritingtotal.idunderwriting
	AND Expensemaxphase.idupb = upbunderwritingtotal.idupb
	AND Expensemaxphase.idfin = upbunderwritingtotal.idfin
	AND Expensemaxphase.nphase = (select max(nphase) from expensephase)
	
GO 

