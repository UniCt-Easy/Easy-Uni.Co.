
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_budgetinvestimenti_lecce]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_budgetinvestimenti_lecce]
GO

CREATE PROCEDURE exp_budgetinvestimenti_lecce
(
	@ayear int,
	@showupb char(1)='S',
	@idupb varchar(36)
)
AS BEGIN
/* 
	Questa sp si basa su una specifica classificazione creata ad hoc per Lecce
	Tipo classificazione "Fonti Finanziamento per Budget Investimenti = Fonti_BI"
	A	VBE - Contributi da terzi finalizzati.
	B	VBE – Risorse Proprie
	C	Contributi da terzi finalizzati.
	D	Risorse da indebitamento
	E	Risorse Proprie
*/

-- exp_budgetinvestimenti_lecce 2015, 'S','%' 

declare @FontiBI int
select  @FontiBI = idsorkind from sortingkind where codesorkind='Fonti_BI'

declare @BUDGET_UFF int 
select @BUDGET_UFF = idsorkind from sortingkind where codesorkind='BUDGET_UFF' 

CREATE TABLE #budgetprevision
(
	idupb varchar(36),
	idfin int,
	nlevel tinyint,
	prevision decimal (19,2),
	coldaterzi decimal(19,2),
	idsor int,
	sortcode varchar(50)
)

-- Prende le coppie UPB/Spese, aventi previsione, ove il Bilancio spesa sia classificato con la classificazione 'Budget Schema Ufficiale', ramo Investimenti.
-- Il codice della classificazione, indica la riga della stampa.

INSERT INTO #budgetprevision
(
	idfin,
	idupb,
	nlevel,
	prevision,
	idsor,
	sortcode
)

SELECT 
	f.idfin,
	u.idupb,
	f.nlevel,
	ISNULL(finyear.prevision,0),
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
	and finyear.idupb like @idupb

-- Prende le UPB, aventi delle voci di entrata con previsione imputate ad esso, e classificate con la class. 'Fonti Finanziamento per Budget Investimenti' 
-- Per ogni UPB, le voci di entrata aventi previsione su quell'ubp, saranno classificate tutte allo stesso modo, cioè con lo stesso codice di classificazione "Fonti_BI".
-- Quindi o tutte con A, o tutte con B, etc...
-- Il codice di classificazione sulle entrate, ci indica la colonna della stampa
CREATE TABLE #budgetColonne
(
	idupb varchar(36),
	fontitype varchar(100)
)		
insert into #budgetColonne(idupb, fontitype)
	select distinct fy.idupb, 
	case	when s.sortcode in ('A', 'C') then 'daterzi'
			when s.sortcode in ('B', 'E') then 'darisorseproprie'
			when s.sortcode in ('D') then 'daindebitamento'
	end
	from finyear fy
	join fin f	
		on f.idfin = fy.idfin	
	JOIN finsorting fs
		ON f.idfin = fs.idfin
	JOIN sorting s
		ON  s.idsor = fs.idsor
	where f.ayear = @ayear
		and s.idsorkind = @FontiBI
		and ((f.flag&1)=0) --> solo entrata
		and fy.prevision >0
		and fy.idupb like @idupb

-- Aggiungiamo le upb "non classificate", che hanno previsione in spesa MA NON ESISTE una una coppia Upb/Entrata, con E classificata, avente previsione>0
-- Queste UPB vanno intese con classificazione:  E	Risorse Proprie

insert into #budgetColonne(idupb, fontitype)
	select distinct idupb, 
	'darisorseproprie'
from #budgetprevision
where ( select count(*) from #budgetColonne where idupb = #budgetprevision.idupb) = 0


if (@showupb = 'S')
	Begin
		SELECT 
			U.codeupb as 'Codice UPB',
			P.sortcode	as 'Cod.Budget Investimenti',
			S.description as 'Budget Investimenti',
			F.codefin as 'Cod.Bilancio Spesa',
			P.prevision as'Previsione', 
			case when E.fontitype ='daterzi' then P.prevision else 0 end as 'Risorse da Terzi',
			case when E.fontitype ='daindebitamento' then P.prevision else 0 end as 'Risorse  da Indebitamento',
			case when E.fontitype ='darisorseproprie' then P.prevision else 0 end as 'Risorse Proprie'
		 FROM #budgetprevision P
		JOIN #budgetColonne E
			on P.idupb = E.idupb
		join upb U
			on P.idupb = U.idupb
		join fin F
			on F.idfin = P.idfin
		join sorting S
			on S.idsor = P.idsor
		Order by U.codeupb, S.printingorder
End
Else
Begin
	SELECT 
		P.sortcode	as 'Cod.Budget Investimenti',
		S.description as 'Budget Investimenti',
		F.codefin as 'Cod.Bilancio Spesa',
		sum(P.prevision) as'Previsione', 
		case when E.fontitype ='daterzi' then sum(P.prevision) else 0 end as 'Risorse da Terzi',
		case when E.fontitype ='daindebitamento' then sum(P.prevision) else 0 end as 'Risorse  da Indebitamento',
		case when E.fontitype ='darisorseproprie' then sum(P.prevision) else 0 end as 'Risorse Proprie'
	 FROM #budgetprevision P
	JOIN #budgetColonne E
		on P.idupb =E.idupb
	join fin F
		on F.idfin = P.idfin
	join sorting S
		on S.idsor = P.idsor
	group by P.sortcode, S.description,	S.printingorder, F.codefin, E.fontitype 
	Order by S.printingorder
End




END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


