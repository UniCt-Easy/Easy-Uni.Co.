
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
IF EXISTS(select * from sysobjects where id = object_id(N'[upbfinyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbfinyearview]
GO



CREATE    VIEW [upbfinyearview] (
	idupb,
	codeupb,	
	upb,
	idfin,
	codefin,
	fin,
	flag, 
	finpart,
	ayear,
	initialprevision,
	varprevision,
	actualprevision,
	initialsecondaryprev,
	varsecondaryprev,
	actualsecondaryprev,
	totcreditpart,
	totpreceedspart,
	assessment,		--accertamenti	
	appropriation,	--impegni
	proceeds,
	payment,
	incomeprevavailable,	-- disp ad accertare
	expenseprevavailable,	-- disp. a impegnare
	proceedsprevavailable,	-- disp. ad incassare,
	paymentprevavailable,	-- disp a pagare
	creditavailable,	--crediti disponibili
	proceedsavailable,	-- incassi disponibili,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)

AS SELECT
	upbtotal.idupb,
	upb.codeupb,
	upb.title,
	upbtotal.idfin,
	fin.codefin,
	fin.title,
	fin.flag, 
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.ayear,
	-- initialprevision
	ISNULL(upbtotal.currentprev,0),
	-- varprevision
	ISNULL(upbtotal.previsionvariation,0),
	-- actualprevision,
	ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0),
	-- initialsecondaryprev
	ISNULL(upbtotal.currentsecondaryprev,0),
	-- varsecondaryprev
	ISNULL(upbtotal.secondaryvariation,0),
	-- actualsecondaryprev
	ISNULL(upbtotal.currentsecondaryprev,0) + ISNULL(upbtotal.secondaryvariation,0),
	-- totcreditpart
	ISNULL(upbtotal.totcreditpart,0),
	-- tonpreceedspart
	ISNULL(upbtotal.totproceedspart,0),

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
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
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
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
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
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
			- (ISNULL(Incomemaxphase.totalcompetency,0) + ISNULL(Incomemaxphase.totalarrears,0))
		Else 0
	End	,
	-- paymentpreavailable = disp a pagare
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbtotal.currentprev,0) + ISNULL(upbtotal.previsionvariation,0) 
			- (ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
		Else 0		
	End,
	-- creditavailable
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbtotal.totcreditpart,0)+ ISNULL(upbtotal.creditvariation,0) - ISNULL(Expensefinphase.totalcompetency,0)
		Else 0	
	End,
	-- proceedsavailable 
	Case when (( fin.flag & 1) <> 0) 
		Then
			ISNULL(upbtotal.totproceedspart,0) + ISNULL(upbtotal.proceedsvariation,0) - (	ISNULL(Expensemaxphase.totalcompetency,0) + ISNULL(Expensemaxphase.totalarrears,0))
			
		Else 0	
	End,
	UPB.idsor01,
	UPB.idsor02,
	UPB.idsor03,
	UPB.idsor04,
	UPB.idsor05
FROM upbtotal 
CROSS JOIN uniconfig
JOIN upb
	ON upbtotal.idupb = upb.idupb
JOIN fin
	ON upbtotal.idfin = fin.idfin
JOIN finlast 
	ON finlast.idfin = fin.idfin
LEFT OUTER JOIN upbincometotal Incomefinphase
	ON Incomefinphase.idupb = upbtotal.idupb
	AND Incomefinphase.idfin = upbtotal.idfin
	AND Incomefinphase.nphase = uniconfig.incomefinphase
LEFT OUTER JOIN upbexpensetotal Expensefinphase
	ON Expensefinphase.idupb = upbtotal.idupb
	AND Expensefinphase.idfin = upbtotal.idfin
	AND Expensefinphase.nphase = uniconfig.expensefinphase
LEFT OUTER JOIN upbincometotal Incomemaxphase
	ON  Incomemaxphase.idupb = upbtotal.idupb
	AND Incomemaxphase.idfin = upbtotal.idfin
	AND Incomemaxphase.nphase = (select max(nphase) from incomephase)
LEFT OUTER JOIN upbexpensetotal Expensemaxphase
	ON  Expensemaxphase.idupb = upbtotal.idupb
	AND Expensemaxphase.idfin = upbtotal.idfin
	AND Expensemaxphase.nphase = (select max(nphase) from expensephase)
	


