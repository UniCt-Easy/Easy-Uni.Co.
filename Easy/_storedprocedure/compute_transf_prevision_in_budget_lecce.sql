
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
 
--setuser 'amministrazione'
-- [compute_transf_prevision_in_budget_lecce]  2024 ,null, 'S'
if exists (select * from dbo.sysobjects where id = object_id(N'[compute_transf_prevision_in_budget_lecce]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_transf_prevision_in_budget_lecce]
GO

CREATE PROCEDURE compute_transf_prevision_in_budget_lecce
(
	@ayear int,
	@idsorkind int = null,
	@trasferisci char(1) = 'S'
)
AS BEGIN

CREATE TABLE #lookup(
	impegni varchar(50),
	fontidaterzi varchar(50),
	fontidaindebitamento varchar(50),
	fontidarisorseproprie varchar(50)
)
-- Questo lookup serve per valorizzare inserire la previsione sulle voci FONTI DI FINANZIAMENTO
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21101','I11101','I12101','I13101')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21102','I11102','I12102','I13102')	
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21103','I11103','I12103','I13103')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21104','I11104','I12104','I13104')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21105','I11105','I12105','I13105')

insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21201','I11201','I12201','I13201')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21202','I11202','I12202','I13202')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21203','I11203','I12203','I13203')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21204','I11204','I12204','I13204')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21205','I11205','I12205','I13205')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21206','I11206','I12206','I13206')
insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21207','I11207','I12207','I13207')

insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21301','I11301','I12301','I13301')

insert into #lookup(impegni, fontidaterzi, fontidaindebitamento, fontidarisorseproprie)values('I21401','I11401','I12401','I13401')

/* 	Questa sp si basa su una specifica classificazione creata ad hoc per Lecce.
	Tipo classificazione "fontitype Finanziamento per Budget Investimenti = fonti_BI"
	A	VBE - Contributi da terzi finalizzati.
	B	VBE – Risorse Proprie
	C	Contributi da terzi finalizzati.
	D	Risorse da indebitamento
	E	Risorse Proprie
*/

declare @fontiBI int
select  @fontiBI = idsorkind from sortingkind where codesorkind='fonti_BI'

declare @BUDGET_UFF int 
select  @BUDGET_UFF = idsorkind from sortingkind where codesorkind='BUDGET_UFF'
 
-- Parte ECONOMICO e INVESTIMENTI\IMPEGNI, stessa quesry usata in compute_transf_prevision_in_budget.sql
CREATE TABLE #budgetprevision(
	finpart char (1),
	idupb varchar(36),
	idfin int,
	nlevel tinyint,
	prevision decimal (19,2),
	previousprevision decimal (19,2),
	prevision2 decimal (19,2),
	prevision3 decimal (19,2),
	prevision4 decimal (19,2),
	prevision5 decimal (19,2),
	idsor int
)

INSERT INTO #budgetprevision
(
	finpart,
	idfin,
	idupb,
	nlevel,
	prevision,
	previousprevision,prevision2,prevision3,prevision4,prevision5,
	idsor
)
SELECT 
	CASE WHEN ((f.flag&1)=0) THEN 'E'
		WHEN ((f.flag&1)=1) THEN 'S'
	END,
	f.idfin,
	u.idupb,
	f.nlevel,
	ISNULL(SUM(finyear.prevision),0) * fs.quota,
	ISNULL(SUM(finyear.previousprevision),0) * fs.quota ,
	ISNULL(SUM(finyear.prevision2),0) * fs.quota,
	ISNULL(SUM(finyear.prevision3),0) * fs.quota,
	ISNULL(SUM(finyear.prevision4),0) * fs.quota,
	ISNULL(SUM(finyear.prevision5),0) * fs.quota,
	fs.idsor
FROM finyear 
JOIN fin f 
        ON f.idfin = finyear.idfin
JOIN finlast fl 
        ON f.idfin = fl.idfin
JOIN upb u 
        ON u.idupb = finyear.idupb
JOIN finsorting fs
		ON f.idfin = fs.idfin
JOIN sorting s
		ON  s.idsor = fs.idsor
WHERE f.ayear = @ayear
	  AND s.idsorkind = @BUDGET_UFF
GROUP BY f.idfin, u.idupb,s.idsor,fs.idsor, fs.quota, f.paridfin, f.flag,f.nlevel

-- Parte INVESTIMENTI \ FONTI DI FINANZIAMENTO lavora come exp_budgetinvestimenti_lecce.sql		
CREATE TABLE #budgetFontiFinanziamento(
	idupb varchar(36),
	idfin int,
	nlevel tinyint,
	prevision decimal (19,2),
	previousprevision decimal (19,2),
	prevision2 decimal (19,2),
	prevision3 decimal (19,2),
	prevision4 decimal (19,2),
	prevision5 decimal (19,2),
	coldaterzi decimal(19,2),
	idsor int,
	sortcode varchar(50)
)

-- Prende le coppie UPB/Spese, aventi previsione, ove il Bilancio spesa sia classificato con la classificazione 'Budget Schema Ufficiale', ramo Investimenti\Impegni.
-- Il codice della classificazione, indica la riga della stampa.
INSERT INTO #budgetFontiFinanziamento(
	idupb,
	prevision,
	previousprevision,
	prevision2, prevision3,	prevision4, prevision5,
	idsor,
	sortcode
)
SELECT 
	u.idupb,
	ISNULL(SUM(finyear.prevision),0),
	ISNULL(SUM(finyear.previousprevision),0),
	ISNULL(SUM(finyear.prevision2),0),
	ISNULL(SUM(finyear.prevision3),0),
	ISNULL(SUM(finyear.prevision4),0),
	ISNULL(SUM(finyear.prevision5),0),
	fs.idsor,
	s.sortcode
FROM finyear 
JOIN fin f 
        ON f.idfin = finyear.idfin
JOIN finlast fl 
        ON f.idfin = fl.idfin
JOIN upb u 
        ON u.idupb = finyear.idupb
JOIN finsorting fs
		ON f.idfin = fs.idfin
JOIN sorting s
		ON  s.idsor = fs.idsor
WHERE f.ayear = @ayear
	and s.idsorkind = @BUDGET_UFF
	and ((f.flag&1)=1)  --> Solo spesa
	and S.sortcode like 'I2%' --> solo ramo investimenti Impegni
	and ISNULL(finyear.prevision,0)> 0
GROUP BY u.idupb,fs.idsor,	s.sortcode

-- Prende le UPB, aventi delle voci di entrata con previsione imputate ad esso, e classificate con la class. 'fontitype Finanziamento per Budget Investimenti' 
-- Per ogni UPB, le voci di entrata aventi previsione su quell'ubp, saranno classificate tutte allo stesso modo, cioè con lo stesso codice di classificazione "fonti_BI".
-- Quindi o tutte con A, o tutte con B, etc...
-- Il codice di classificazione sulle entrate, ci indica la colonna relativa alla fonte di finanziamento della stampa. Della classificazione "fonti_BI" escludiamo
-- le fonti che si riferiscono esclusivamente al ramo Variazioni di Budget Economico (Voci A e B), e includiamo le Fonti del Ramo Investimenti (Voci C, D, E)
CREATE TABLE #budgetColonne(
	idupb varchar(36),
	fontitype varchar(100)
)	

insert into #budgetColonne(idupb, fontitype)
	select distinct fy.idupb, 
	case	when s.sortcode in ('C') then 'daterzi'
			when s.sortcode in ('D') then 'daindebitamento'
			when s.sortcode in ('E') then 'darisorseproprie'
			when s.sortcode in ('A','B') then 'ramoeconomico'
	end
	from finyear fy
	join fin f	
		on f.idfin = fy.idfin	
	JOIN finsorting fs
		ON f.idfin = fs.idfin
	JOIN sorting s
		ON  s.idsor = fs.idsor
	where f.ayear = @ayear
		and s.idsorkind = @fontiBI
		and ((f.flag&1)=0) --> solo entrata
		and fy.prevision >0
		and s.sortcode  IN ('A','B','C', 'D', 'E')

		--SELECT * FROM #budgetFontiFinanziamento
		--SELECT * FROM #budgetColonne
--- Non è corretto che le fonti di entrata non classificate siano considerate come 'Risorse proprie'
--- quindi se hanno utilizzato i codici A o B (riservati al ramo economico) 
--- non sarà attribuita alcuna fonte a quell'UPB
 
-- Aggiungiamo le upb "non classificate", che hanno previsione in spesa MA NON ESISTE una una coppia Upb/Entrata, con E classificata, avente previsione>0
-- Queste UPB vanno intese con classificazione:  E	Risorse Proprie

 

insert into #budgetColonne(idupb, fontitype)
	select distinct idupb, 
	'darisorseproprie'
from #budgetFontiFinanziamento
where ( select count(*) from #budgetColonne where idupb = #budgetFontiFinanziamento.idupb) = 0


if (@trasferisci = 'S')
Begin
	 
	delete from budgetprevision where ayear = @ayear and idsor in (select idsor from sorting where idsorkind = @BUDGET_UFF)

	-- Valorizza la parte ECONOMICO e INVESTIMENTI\IMPEGNI
	INSERT INTO budgetprevision(
		idupb,
		idsor,
		ayear,
		prevision,
		previousprevision,
		prevision2,
		prevision3,
		prevision4,
		prevision5,
		ct,cu,lt,lu
	)
	SELECT 
		#budgetprevision.idupb,
		#budgetprevision.idsor,
		@ayear,
		SUM(#budgetprevision.prevision),
		SUM(#budgetprevision.previousprevision),
		SUM(#budgetprevision.prevision2),
		SUM(#budgetprevision.prevision3),
		SUM(#budgetprevision.prevision4),
		SUM(#budgetprevision.prevision5),
		GetDate(),'trasf_previsioni_e',GetDate(),	'trasf_previsioni_e'
	FROM  #budgetprevision
	GROUP BY #budgetprevision.idupb, #budgetprevision.idsor
	--SELECT * FROM #budgetFontiFinanziamento
	--SELECT * FROM #budgetColonne
	--SELECT * FROM #lookup
	-- Valorizza la parte INVESTIMENTI \ FONTI DI FINANZIAMENTO
	INSERT INTO budgetprevision
	(
		idupb,
		idsor,
		ayear,
		prevision,
		previousprevision,
		prevision2,
		prevision3,
		prevision4,
		prevision5,
		ct,	cu,	lt,	lu
	)
	SELECT 
		P.idupb,
		case 
			when E.fontitype ='daterzi' then S1.idsor
			when E.fontitype ='daindebitamento' then S2.idsor
			when E.fontitype ='darisorseproprie' then S3.idsor
		End,
		@ayear,
		SUM(P.prevision),
		SUM(P.previousprevision),
		SUM(P.prevision2),
		SUM(P.prevision3),
		SUM(P.prevision4),
		SUM(P.prevision5),
		GetDate(), 'trasf_previsioni_e', GetDate(), 'trasf_previsioni_e'
	FROM #budgetFontiFinanziamento P
	JOIN #budgetColonne E
		on P.idupb = E.idupb
	join #lookup A
		on P.sortcode like A.impegni +'%'
	JOIN sorting S1
		on A.fontidaterzi = S1.sortcode and S1.idsorkind = @BUDGET_UFF 
	JOIN sorting S2
		on A.fontidaindebitamento = S2.sortcode and S2.idsorkind = @BUDGET_UFF 
	JOIN sorting S3
 		on A.fontidarisorseproprie = S3.sortcode and S3.idsorkind = @BUDGET_UFF 
	WHERE E.fontitype<> 'ramoeconomico'
	GROUP BY P.idupb, E.fontitype, S1.idsor, S2.idsor, S3.idsor
End
Else
Begin
	SELECT 
		U.idupb AS '#IdUPB',
		U.codeupb as 'Cod.UPB',
		S.sortcode as 'Budget Voce Classificazione',
		SUM(P.prevision) as 'Budget',
		SUM(P.previousprevision) as'Budget Eserc.Prec.',
		SUM(P.prevision2) as 'Budget Eserc.+1',
		SUM(P.prevision3) as 'Budget Eserc.+2',
		SUM(P.prevision4) as 'Budget Eserc.+3',
		SUM(P.prevision5) as 'Budget Eserc.+4'
	FROM #budgetprevision P
	join upb U
		on P.idupb = U.idupb
	JOIN sorting S
		on P.idsor = S.idsor and S.idsorkind = @BUDGET_UFF 
	GROUP BY U.codeupb,S.sortcode, U.IDUPB

	UNION
		
	SELECT 	U.idupb AS '#IdUPB',
		U.codeupb as 'Cod.UPB',
		case 
			when E.fontitype ='daterzi' then S1.sortcode
			when E.fontitype ='daindebitamento' then S2.sortcode
			when E.fontitype ='darisorseproprie' then S3.sortcode
		End as 'Budget Voce Classificazione',
		SUM(P.prevision) as 'Budget',
		SUM(P.previousprevision) as'Budget Eserc.Prec.',
		SUM(P.prevision2) as 'Budget Eserc.+1',
		SUM(P.prevision3) as 'Budget Eserc.+2',
		SUM(P.prevision4) as 'Budget Eserc.+3',
		SUM(P.prevision5) as 'Budget Eserc.+4'
	FROM #budgetFontiFinanziamento P
	JOIN #budgetColonne E
		on P.idupb = E.idupb
	join upb U
		on P.idupb = U.idupb
	join #lookup A
		on P.sortcode like A.impegni +'%'
	JOIN sorting S1
		on A.fontidaterzi = S1.sortcode and S1.idsorkind = @BUDGET_UFF 
	JOIN sorting S2
		on A.fontidaindebitamento = S2.sortcode and S2.idsorkind = @BUDGET_UFF 
	JOIN sorting S3
 		on A.fontidarisorseproprie = S3.sortcode and S3.idsorkind = @BUDGET_UFF 
	WHERE E.fontitype<> 'ramoeconomico'
	GROUP BY U.codeupb, E.fontitype, S1.sortcode, S2.sortcode, S3.sortcode,	U.idupb 
End



END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 
