
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgetconsuntivo_upb_sun]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgetconsuntivo_upb_sun]
GO
/****** Object:  StoredProcedure [amministrazione].[rpt_budgetconsuntivo_upb_sun]    Script Date: 10/11/2014 11.16.02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- exec [amministrazione].[rpt_budgetconsuntivo_upb_sun]  2014, 15, '%', '2014-12-31',null,null,null,null,null
CREATE PROCEDURE [rpt_budgetconsuntivo_upb_sun] 
(
	@ayear smallint,
	@idsorkind int,
	@idupb varchar(36),
	@showchildupb char(1)='S',
	@adate datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

	-- AGGIUNGERE GESTIONE SICUREZZA E UPB
)
AS BEGIN


/*
Gianni 22 ottobre 2014
Stampa del preventivo di budget di Ateneo come richiesto da Giovanni Russo
*/


declare @treasurer varchar(150)
if(@idupb = '%') 
Begin
	select @treasurer = null
end
Else
Begin
	select @treasurer = isnull(T.header, T.description) from upb U
						join treasurer T
							ON T.idtreasurer = U.idtreasurer
						where U.idupb = @idupb
End

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END


declare @finphase_inc int

SELECT @finphase_inc = assessmentphasecode
FROM config
WHERE ayear = @ayear
IF @finphase_inc IS NULL
BEGIN
	SELECT @finphase_inc = incomefinphase FROM uniconfig
END

declare @finphase_exp int

SELECT @finphase_exp= appropriationphasecode
FROM config
WHERE ayear = @ayear
IF @finphase_exp IS NULL
BEGIN
	SELECT @finphase_exp = expensefinphase FROM uniconfig
END


create table #tmp
(codice varchar(50), Previsione_Iniziale decimal (19,2), Variazioni_Budget decimal (19,2), Fase1 decimal (19,2))

Insert into #tmp values ('E1', null, null, null) --PROVENTI OPERATIVI
Insert into #tmp values ('E11', null, null, null) --PROVENTI PROPRI
Insert into #tmp values ('E12', null, null, null) --CONTRIBUTI
Insert into #tmp values ('E13', null, null, null) --PROVENTI PER ATTIVITÀ ASSISTENZIALE
Insert into #tmp values ('E14', null, null, null) --PROVENTI PER GESTIONE DIRETTA INTERVENTI PER IL DIRITTO ALLO STUDIO
Insert into #tmp values ('E15', null, null, null) --ALTRI PROVENTI
Insert into #tmp values ('E16', null, null, null) --VARIAZIONE LAVORI IN CORSO
Insert into #tmp values ('E17', null, null, null) --INCREMENTO DELLE IMMOBILIZZAZIONI PER LAVORI INTERNI
Insert into #tmp values ('E2', null, null, null) --COSTI OPERATIVI
Insert into #tmp values ('E21', null, null, null) --COSTI SPECIFICI
Insert into #tmp values ('E211', null, null, null) --Sostegno agli Studenti
Insert into #tmp values ('E2111', null, null, null) --Interventi in favore degli studenti e mobilità
Insert into #tmp values ('E2112', null, null, null) --Borse di studio post-lauream
Insert into #tmp values ('E213', null, null, null) --Sostegno alla ricerca e attività editoriale
Insert into #tmp values ('E214', null, null, null) --Personale dedicato alla ricerca e alla didattica
Insert into #tmp values ('E2141', null, null, null) --Docenti
Insert into #tmp values ('E2142', null, null, null) --Ricercatori
Insert into #tmp values ('E2143', null, null, null) --Ricercatori a tempo determinato
Insert into #tmp values ('E2144', null, null, null) --Collaborazioni scientifiche (collaboratori, assegnisti, ecc)
Insert into #tmp values ('E2145', null, null, null) --Docenti a contratto
Insert into #tmp values ('E2146', null, null, null) --Esperti linguistici
Insert into #tmp values ('E2148', null, null, null) --Missioni personale dedicato alla didattica ed alla ricerca
Insert into #tmp values ('E2149', null, null, null) --Altri oneri per personale dedicato alla didattica ed alla ricerca
Insert into #tmp values ('E215', null, null, null) --Acquisto materiale consumo per laboratori
Insert into #tmp values ('E216', null, null, null) --Trasferimenti a partner di progetti coordinati
Insert into #tmp values ('E217', null, null, null) --Altri costi specifici
Insert into #tmp values ('E22', null, null, null) --COSTI GENERALI
Insert into #tmp values ('E221', null, null, null) --Personale tecnico-amministrativo
Insert into #tmp values ('E222', null, null, null) --Acquisto materiali
Insert into #tmp values ('E223', null, null, null) --Acquisto di libri, periodici e materiale bibliografico
Insert into #tmp values ('E224', null, null, null) --Acquisto di servizi e collaborazioni tecnico gestionali
Insert into #tmp values ('E225', null, null, null) --Costi per il godimento di beni di terzi
Insert into #tmp values ('E226', null, null, null) --Altri costi generali
Insert into #tmp values ('E2261', null, null, null) --Utenze e canoni
Insert into #tmp values ('E2262', null, null, null) --Manutenzione ordinaria e gestione strutture
Insert into #tmp values ('E2264', null, null, null) --Altri costi generali per attività istituzionali
Insert into #tmp values ('E3', null, null, null) --ONERI DIVERSI DI GESTIONE
Insert into #tmp values ('E3111', null, null, null) --Imposte varie
Insert into #tmp values ('E3112', null, null, null) --Altri oneri
Insert into #tmp values ('E3113', null, null, null) --Trasferimenti correnti
Insert into #tmp values ('E3114', null, null, null) --Trasferimenti per investimenti
Insert into #tmp values ('E4', null, null, null) --RETTIFICHE DI VALORE DI ATTIVITÀ FINANZIARIE
Insert into #tmp values ('E5', null, null, null) --PROVENTI ED ONERI FINANZIARI
Insert into #tmp values ('E6', null, null, null) --PROVENTI ED ONERI STRAORDINARI
Insert into #tmp values ('E611', null, null, null) --Proventi Straordinari
Insert into #tmp values ('E612', null, null, null) --Oneri Straordinari
Insert into #tmp values ('E7', null, null, null) --IMPOSTE E TASSE

-- Aggiunto per verifiche
Insert into #tmp values ('E111101', null, null, null) --Oneri Straordinari


/*Previsioni_Iniziali*/
Update #tmp
set Previsione_Iniziale = (Select SUM(bp.prevision)
from budgetprevision bp
join sorting s
on bp.idsor=s.idsor
JOIN sortinglevel
	ON sortinglevel.nlevel = s.nlevel
	AND sortinglevel.idsorkind = s.idsorkind
JOIN sortingkind
	ON sortingkind.idsorkind = s.idsorkind
join UPB u
on bp.idupb=u.idupb
WHERE ((sortinglevel.flag & 2) <> 0) -- tutti i livelli operativi
 AND sortingkind.idsorkind = @idsorkind
	AND s.idsor NOT IN -- non deve essere un padre
		(SELECT c1.paridsor FROM sorting c1
		WHERE c1.paridsor IS NOT NULL)
AND ayear = @ayear
AND sortcode like #tmp.codice+'%'
AND (bp.idupb LIKE @idupb)	
AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
)

/*Variazioni di budget*/
Update #tmp
set Variazioni_Budget = (Select SUM(bp.amount)
from budgetvardetailview bp
WHERE 
/*((sortinglevel.flag & 2) <> 0) -- tutti i livelli operativi
 AND sortingkind.idsorkind = @idsorkind
	AND s.idsor NOT IN -- non deve essere un padre
		(SELECT c1.paridsor FROM sorting c1
		WHERE c1.paridsor IS NOT NULL)
AND */
bp.ybudgetvar = @ayear
AND adate <= @adate
AND bp.sortcode like #tmp.codice+'%'
AND (bp.idupb LIKE @idupb)	
AND (@idsor01 IS NULL OR bp.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR bp.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR bp.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR bp.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR bp.idsor05 = @idsor05)
)

/*!!! DEVO METTERE UN IF PER NON SOVRASCRIVERE LE FASI 1 !!!*/

/* Fase1 sono preaccertamenti se stiamo parlando di E1% o E611 altrimenti sono prenotazioni */

Update #tmp
set 
Fase1 = CASE 
	WHEN ((#tmp.codice like 'E1%') OR (#tmp.codice like 'E611%'))
			THEN
				(SELECT SUM(incomeyear.amount)
				FROM incomeyear
				JOIN incometotal
					ON incometotal.idinc =	incomeyear.idinc
					AND incometotal.ayear = incomeyear.ayear
				JOIN income
					ON income.idinc = incomeyear.idinc
				JOIN fin
					ON fin.idfin = incomeyear.idfin
				JOIN finsorting FS
					ON FS.idfin = incomeyear.idfin
				JOIN sorting s
					ON FS.idsor=s.idsor
				JOIN sortinglevel
					ON sortinglevel.nlevel = s.nlevel
					AND sortinglevel.idsorkind = s.idsorkind
				JOIN sortingkind
					ON sortingkind.idsorkind = s.idsorkind
				WHERE  ((sortinglevel.flag & 2) <> 0) -- tutti i livelli operativi
					AND sortingkind.idsorkind = @idsorkind
					AND s.idsor NOT IN					--> non deve essere un padre
							(SELECT c1.paridsor FROM sorting c1
								WHERE c1.paridsor IS NOT NULL)
					AND incomeyear.ayear = @ayear
					AND ((incometotal.flag & 1)=0)		--> Competenza
					AND incomeyear.idupb LIKE @idupb
					AND income.nphase = @finphase_inc	--> @finphase
					AND income.adate <= @adate			--> @date
					AND (s.sortcode like #tmp.codice+'%')
					AND (@idsor01 IS NULL OR (select idsor01 from upb where idupb=incomeyear.idupb) = @idsor01)
					AND (@idsor02 IS NULL OR (select idsor02 from upb where idupb=incomeyear.idupb) = @idsor02)
					AND (@idsor03 IS NULL OR (select idsor03 from upb where idupb=incomeyear.idupb) = @idsor03)
					AND (@idsor04 IS NULL OR (select idsor04 from upb where idupb=incomeyear.idupb) = @idsor04)
					AND (@idsor05 IS NULL OR (select idsor05 from upb where idupb=incomeyear.idupb) = @idsor05)
					
					)
			 ELSE
				(SELECT SUM(expenseyear.amount)
					FROM expenseyear
					JOIN expensetotal
						ON expensetotal.idexp =	expenseyear.idexp
						AND expensetotal.ayear = expenseyear.ayear
					JOIN expense
						ON expense.idexp = expenseyear.idexp
					JOIN fin
						ON fin.idfin = expenseyear.idfin
					JOIN finsorting FS
						ON FS.idfin = expenseyear.idfin
					JOIN sorting s
						ON FS.idsor=s.idsor
					JOIN sortinglevel
						ON sortinglevel.nlevel = s.nlevel
						AND sortinglevel.idsorkind = s.idsorkind
					JOIN sortingkind
						ON sortingkind.idsorkind = s.idsorkind
					WHERE  ((sortinglevel.flag & 2) <> 0) -- tutti i livelli operativi
						AND sortingkind.idsorkind = @idsorkind
						AND s.idsor NOT IN -- non deve essere un padre
								(SELECT c1.paridsor FROM sorting c1
								WHERE c1.paridsor IS NOT NULL)
						AND expenseyear.ayear = @ayear
						AND ((expensetotal.flag & 1)=0) --Competenza
						AND expenseyear.idupb LIKE @idupb
						AND expense.nphase = @finphase_exp ----- >>>>@finphase
						AND expense.adate <= @adate ----- >>>>@date
						AND (s.sortcode like #tmp.codice+'%')
						AND (@idsor01 IS NULL OR (select idsor01 from upb where idupb=expenseyear.idupb) = @idsor01)
						AND (@idsor02 IS NULL OR (select idsor02 from upb where idupb=expenseyear.idupb) = @idsor02)
						AND (@idsor03 IS NULL OR (select idsor03 from upb where idupb=expenseyear.idupb) = @idsor03)
						AND (@idsor04 IS NULL OR (select idsor04 from upb where idupb=expenseyear.idupb) = @idsor04)
						AND (@idsor05 IS NULL OR (select idsor05 from upb where idupb=expenseyear.idupb) = @idsor05)  
				)
			END


--select * from #tmp

--CREARE TABELLA TEMPORANEA CHE OSPITA LA SINGOLA RIGA DI OUTPUT

CREATE TABLE #report
(
E1_Previsione_Iniziale decimal(19,2),	E1_Variazioni_Budget decimal(19,2),	E1_Previsione_Attuale decimal(19,2),	E1_Fase1 decimal(19,2),	E1_Budget_Disponibile decimal(19,2),
E11_Previsione_Iniziale decimal(19,2),	E11_Variazioni_Budget decimal(19,2),	E11_Previsione_Attuale decimal(19,2),	E11_Fase1 decimal(19,2),	E11_Budget_Disponibile decimal(19,2),
E12_Previsione_Iniziale decimal(19,2),	E12_Variazioni_Budget decimal(19,2),	E12_Previsione_Attuale decimal(19,2),	E12_Fase1 decimal(19,2),	E12_Budget_Disponibile decimal(19,2),
E13_Previsione_Iniziale decimal(19,2),	E13_Variazioni_Budget decimal(19,2),	E13_Previsione_Attuale decimal(19,2),	E13_Fase1 decimal(19,2),	E13_Budget_Disponibile decimal(19,2),
E14_Previsione_Iniziale decimal(19,2),	E14_Variazioni_Budget decimal(19,2),	E14_Previsione_Attuale decimal(19,2),	E14_Fase1 decimal(19,2),	E14_Budget_Disponibile decimal(19,2),
E15_Previsione_Iniziale decimal(19,2),	E15_Variazioni_Budget decimal(19,2),	E15_Previsione_Attuale decimal(19,2),	E15_Fase1 decimal(19,2),	E15_Budget_Disponibile decimal(19,2),
E16_Previsione_Iniziale decimal(19,2),	E16_Variazioni_Budget decimal(19,2),	E16_Previsione_Attuale decimal(19,2),	E16_Fase1 decimal(19,2),	E16_Budget_Disponibile decimal(19,2),
E17_Previsione_Iniziale decimal(19,2),	E17_Variazioni_Budget decimal(19,2),	E17_Previsione_Attuale decimal(19,2),	E17_Fase1 decimal(19,2),	E17_Budget_Disponibile decimal(19,2),
E2_Previsione_Iniziale decimal(19,2),	E2_Variazioni_Budget decimal(19,2),	E2_Previsione_Attuale decimal(19,2),	E2_Fase1 decimal(19,2),	E2_Budget_Disponibile decimal(19,2),
E21_Previsione_Iniziale decimal(19,2),	E21_Variazioni_Budget decimal(19,2),	E21_Previsione_Attuale decimal(19,2),	E21_Fase1 decimal(19,2),	E21_Budget_Disponibile decimal(19,2),
E211_Previsione_Iniziale decimal(19,2),	E211_Variazioni_Budget decimal(19,2),	E211_Previsione_Attuale decimal(19,2),	E211_Fase1 decimal(19,2),	E211_Budget_Disponibile decimal(19,2),
E2111_Previsione_Iniziale decimal(19,2),	E2111_Variazioni_Budget decimal(19,2),	E2111_Previsione_Attuale decimal(19,2),	E2111_Fase1 decimal(19,2),	E2111_Budget_Disponibile decimal(19,2),
E2112_Previsione_Iniziale decimal(19,2),	E2112_Variazioni_Budget decimal(19,2),	E2112_Previsione_Attuale decimal(19,2),	E2112_Fase1 decimal(19,2),	E2112_Budget_Disponibile decimal(19,2),
E213_Previsione_Iniziale decimal(19,2),	E213_Variazioni_Budget decimal(19,2),	E213_Previsione_Attuale decimal(19,2),	E213_Fase1 decimal(19,2),	E213_Budget_Disponibile decimal(19,2),
E214_Previsione_Iniziale decimal(19,2),	E214_Variazioni_Budget decimal(19,2),	E214_Previsione_Attuale decimal(19,2),	E214_Fase1 decimal(19,2),	E214_Budget_Disponibile decimal(19,2),
E2141_Previsione_Iniziale decimal(19,2),	E2141_Variazioni_Budget decimal(19,2),	E2141_Previsione_Attuale decimal(19,2),	E2141_Fase1 decimal(19,2),	E2141_Budget_Disponibile decimal(19,2),
E2142_Previsione_Iniziale decimal(19,2),	E2142_Variazioni_Budget decimal(19,2),	E2142_Previsione_Attuale decimal(19,2),	E2142_Fase1 decimal(19,2),	E2142_Budget_Disponibile decimal(19,2),
E2143_Previsione_Iniziale decimal(19,2),	E2143_Variazioni_Budget decimal(19,2),	E2143_Previsione_Attuale decimal(19,2),	E2143_Fase1 decimal(19,2),	E2143_Budget_Disponibile decimal(19,2),
E2144_Previsione_Iniziale decimal(19,2),	E2144_Variazioni_Budget decimal(19,2),	E2144_Previsione_Attuale decimal(19,2),	E2144_Fase1 decimal(19,2),	E2144_Budget_Disponibile decimal(19,2),
E2145_Previsione_Iniziale decimal(19,2),	E2145_Variazioni_Budget decimal(19,2),	E2145_Previsione_Attuale decimal(19,2),	E2145_Fase1 decimal(19,2),	E2145_Budget_Disponibile decimal(19,2),
E2146_Previsione_Iniziale decimal(19,2),	E2146_Variazioni_Budget decimal(19,2),	E2146_Previsione_Attuale decimal(19,2),	E2146_Fase1 decimal(19,2),	E2146_Budget_Disponibile decimal(19,2),
E2148_Previsione_Iniziale decimal(19,2),	E2148_Variazioni_Budget decimal(19,2),	E2148_Previsione_Attuale decimal(19,2),	E2148_Fase1 decimal(19,2),	E2148_Budget_Disponibile decimal(19,2),
E2149_Previsione_Iniziale decimal(19,2),	E2149_Variazioni_Budget decimal(19,2),	E2149_Previsione_Attuale decimal(19,2),	E2149_Fase1 decimal(19,2),	E2149_Budget_Disponibile decimal(19,2),
E215_Previsione_Iniziale decimal(19,2),	E215_Variazioni_Budget decimal(19,2),	E215_Previsione_Attuale decimal(19,2),	E215_Fase1 decimal(19,2),	E215_Budget_Disponibile decimal(19,2),
E216_Previsione_Iniziale decimal(19,2),	E216_Variazioni_Budget decimal(19,2),	E216_Previsione_Attuale decimal(19,2),	E216_Fase1 decimal(19,2),	E216_Budget_Disponibile decimal(19,2),
E217_Previsione_Iniziale decimal(19,2),	E217_Variazioni_Budget decimal(19,2),	E217_Previsione_Attuale decimal(19,2),	E217_Fase1 decimal(19,2),	E217_Budget_Disponibile decimal(19,2),
E22_Previsione_Iniziale decimal(19,2),	E22_Variazioni_Budget decimal(19,2),	E22_Previsione_Attuale decimal(19,2),	E22_Fase1 decimal(19,2),	E22_Budget_Disponibile decimal(19,2),
E221_Previsione_Iniziale decimal(19,2),	E221_Variazioni_Budget decimal(19,2),	E221_Previsione_Attuale decimal(19,2),	E221_Fase1 decimal(19,2),	E221_Budget_Disponibile decimal(19,2),
E222_Previsione_Iniziale decimal(19,2),	E222_Variazioni_Budget decimal(19,2),	E222_Previsione_Attuale decimal(19,2),	E222_Fase1 decimal(19,2),	E222_Budget_Disponibile decimal(19,2),
E223_Previsione_Iniziale decimal(19,2),	E223_Variazioni_Budget decimal(19,2),	E223_Previsione_Attuale decimal(19,2),	E223_Fase1 decimal(19,2),	E223_Budget_Disponibile decimal(19,2),
E224_Previsione_Iniziale decimal(19,2),	E224_Variazioni_Budget decimal(19,2),	E224_Previsione_Attuale decimal(19,2),	E224_Fase1 decimal(19,2),	E224_Budget_Disponibile decimal(19,2),
E225_Previsione_Iniziale decimal(19,2),	E225_Variazioni_Budget decimal(19,2),	E225_Previsione_Attuale decimal(19,2),	E225_Fase1 decimal(19,2),	E225_Budget_Disponibile decimal(19,2),
E2251_Previsione_Iniziale decimal(19,2),	E2251_Variazioni_Budget decimal(19,2),	E2251_Previsione_Attuale decimal(19,2),	E2251_Fase1 decimal(19,2),	E2251_Budget_Disponibile decimal(19,2),
E226_Previsione_Iniziale decimal(19,2),	E226_Variazioni_Budget decimal(19,2),	E226_Previsione_Attuale decimal(19,2),	E226_Fase1 decimal(19,2),	E226_Budget_Disponibile decimal(19,2),
E2261_Previsione_Iniziale decimal(19,2),	E2261_Variazioni_Budget decimal(19,2),	E2261_Previsione_Attuale decimal(19,2),	E2261_Fase1 decimal(19,2),	E2261_Budget_Disponibile decimal(19,2),
E2262_Previsione_Iniziale decimal(19,2),	E2262_Variazioni_Budget decimal(19,2),	E2262_Previsione_Attuale decimal(19,2),	E2262_Fase1 decimal(19,2),	E2262_Budget_Disponibile decimal(19,2),
E2264_Previsione_Iniziale decimal(19,2),	E2264_Variazioni_Budget decimal(19,2),	E2264_Previsione_Attuale decimal(19,2),	E2264_Fase1 decimal(19,2),	E2264_Budget_Disponibile decimal(19,2),
E3_Previsione_Iniziale decimal(19,2),	E3_Variazioni_Budget decimal(19,2),	E3_Previsione_Attuale decimal(19,2),	E3_Fase1 decimal(19,2),	E3_Budget_Disponibile decimal(19,2),
E3111_Previsione_Iniziale decimal(19,2),	E3111_Variazioni_Budget decimal(19,2),	E3111_Previsione_Attuale decimal(19,2),	E3111_Fase1 decimal(19,2),	E3111_Budget_Disponibile decimal(19,2),
E3112_Previsione_Iniziale decimal(19,2),	E3112_Variazioni_Budget decimal(19,2),	E3112_Previsione_Attuale decimal(19,2),	E3112_Fase1 decimal(19,2),	E3112_Budget_Disponibile decimal(19,2),
E3113_Previsione_Iniziale decimal(19,2),	E3113_Variazioni_Budget decimal(19,2),	E3113_Previsione_Attuale decimal(19,2),	E3113_Fase1 decimal(19,2),	E3113_Budget_Disponibile decimal(19,2),
E3114_Previsione_Iniziale decimal(19,2),	E3114_Variazioni_Budget decimal(19,2),	E3114_Previsione_Attuale decimal(19,2),	E3114_Fase1 decimal(19,2),	E3114_Budget_Disponibile decimal(19,2),
E4_Previsione_Iniziale decimal(19,2),	E4_Variazioni_Budget decimal(19,2),	E4_Previsione_Attuale decimal(19,2),	E4_Fase1 decimal(19,2),	E4_Budget_Disponibile decimal(19,2),
E5_Previsione_Iniziale decimal(19,2),	E5_Variazioni_Budget decimal(19,2),	E5_Previsione_Attuale decimal(19,2),	E5_Fase1 decimal(19,2),	E5_Budget_Disponibile decimal(19,2),
E6_Previsione_Iniziale decimal(19,2),	E6_Variazioni_Budget decimal(19,2),	E6_Previsione_Attuale decimal(19,2),	E6_Fase1 decimal(19,2),	E6_Budget_Disponibile decimal(19,2),
E611_Previsione_Iniziale decimal(19,2),	E611_Variazioni_Budget decimal(19,2),	E611_Previsione_Attuale decimal(19,2),	E611_Fase1 decimal(19,2),	E611_Budget_Disponibile decimal(19,2),
E612_Previsione_Iniziale decimal(19,2),	E612_Variazioni_Budget decimal(19,2),	E612_Previsione_Attuale decimal(19,2),	E612_Fase1 decimal(19,2),	E612_Budget_Disponibile decimal(19,2),
E7_Previsione_Iniziale decimal(19,2),	E7_Variazioni_Budget decimal(19,2),	E7_Previsione_Attuale decimal(19,2),	E7_Fase1 decimal(19,2),	E7_Budget_Disponibile decimal(19,2), 
department varchar(150)
)

insert into #report(department)values(@treasurer) 
update #report set E1_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E1') ,0)
update #report set E1_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E1') ,0)
update #report set E1_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E1') ,0)
update #report set E1_Fase1= isnull((Select Fase1 from #tmp where codice = 'E1') ,0)
update #report set E1_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E1') ,0)
update #report set E11_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E11') ,0)
update #report set E11_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E11') ,0)
update #report set E11_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E11') ,0)
update #report set E11_Fase1= isnull((Select Fase1 from #tmp where codice = 'E11') ,0)
update #report set E11_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E11') ,0)
update #report set E12_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E12') ,0)
update #report set E12_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E12') ,0)
update #report set E12_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E12') ,0)
update #report set E12_Fase1= isnull((Select Fase1 from #tmp where codice = 'E12') ,0)
update #report set E12_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E12') ,0)
update #report set E13_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E13') ,0)
update #report set E13_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E13') ,0)
update #report set E13_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E13') ,0)
update #report set E13_Fase1= isnull((Select Fase1 from #tmp where codice = 'E13') ,0)
update #report set E13_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E13') ,0)
update #report set E14_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E14') ,0)
update #report set E14_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E14') ,0)
update #report set E14_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E14') ,0)
update #report set E14_Fase1= isnull((Select Fase1 from #tmp where codice = 'E14') ,0)
update #report set E14_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E14') ,0)
update #report set E15_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E15') ,0)
update #report set E15_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E15') ,0)
update #report set E15_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E15') ,0)
update #report set E15_Fase1= isnull((Select Fase1 from #tmp where codice = 'E15') ,0)
update #report set E15_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E15') ,0)
update #report set E16_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E16') ,0)
update #report set E16_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E16') ,0)
update #report set E16_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E16') ,0)
update #report set E16_Fase1= isnull((Select Fase1 from #tmp where codice = 'E16') ,0)
update #report set E16_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E16') ,0)
update #report set E17_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E17') ,0)
update #report set E17_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E17') ,0)
update #report set E17_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E17') ,0)
update #report set E17_Fase1= isnull((Select Fase1 from #tmp where codice = 'E17') ,0)
update #report set E17_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E17') ,0)
update #report set E2_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2') ,0)
update #report set E2_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2') ,0)
update #report set E2_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2') ,0)
update #report set E2_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2') ,0)
update #report set E2_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2') ,0)
update #report set E21_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E21') ,0)
update #report set E21_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E21') ,0)
update #report set E21_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E21') ,0)
update #report set E21_Fase1= isnull((Select Fase1 from #tmp where codice = 'E21') ,0)
update #report set E21_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E21') ,0)
update #report set E211_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E211') ,0)
update #report set E211_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E211') ,0)
update #report set E211_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E211') ,0)
update #report set E211_Fase1= isnull((Select Fase1 from #tmp where codice = 'E211') ,0)
update #report set E211_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E211') ,0)
update #report set E2111_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2111') ,0)
update #report set E2111_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2111') ,0)
update #report set E2111_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2111') ,0)
update #report set E2111_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2111') ,0)
update #report set E2111_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2111') ,0)
update #report set E2112_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2112') ,0)
update #report set E2112_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2112') ,0)
update #report set E2112_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2112') ,0)
update #report set E2112_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2112') ,0)
update #report set E2112_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2112') ,0)
update #report set E213_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E213') ,0)
update #report set E213_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E213') ,0)
update #report set E213_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E213') ,0)
update #report set E213_Fase1= isnull((Select Fase1 from #tmp where codice = 'E213') ,0)
update #report set E213_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E213') ,0)
update #report set E214_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E214') ,0)
update #report set E214_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E214') ,0)
update #report set E214_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E214') ,0)
update #report set E214_Fase1= isnull((Select Fase1 from #tmp where codice = 'E214') ,0)
update #report set E214_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E214') ,0)
update #report set E2141_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2141') ,0)
update #report set E2141_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2141') ,0)
update #report set E2141_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2141') ,0)
update #report set E2141_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2141') ,0)
update #report set E2141_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2141') ,0)
update #report set E2142_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2142') ,0)
update #report set E2142_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2142') ,0)
update #report set E2142_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2142') ,0)
update #report set E2142_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2142') ,0)
update #report set E2142_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2142') ,0)
update #report set E2143_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2143') ,0)
update #report set E2143_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2143') ,0)
update #report set E2143_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2143') ,0)
update #report set E2143_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2143') ,0)
update #report set E2143_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2143') ,0)
update #report set E2144_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2144') ,0)
update #report set E2144_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2144') ,0)
update #report set E2144_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2144') ,0)
update #report set E2144_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2144') ,0)
update #report set E2144_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2144') ,0)
update #report set E2145_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2145') ,0)
update #report set E2145_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2145') ,0)
update #report set E2145_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2145') ,0)
update #report set E2145_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2145') ,0)
update #report set E2145_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2145') ,0)
update #report set E2146_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2146') ,0)
update #report set E2146_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2146') ,0)
update #report set E2146_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2146') ,0)
update #report set E2146_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2146') ,0)
update #report set E2146_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2146') ,0)
update #report set E2148_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2148') ,0)
update #report set E2148_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2148') ,0)
update #report set E2148_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2148') ,0)
update #report set E2148_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2148') ,0)
update #report set E2148_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2148') ,0)
update #report set E2149_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2149') ,0)
update #report set E2149_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2149') ,0)
update #report set E2149_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2149') ,0)
update #report set E2149_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2149') ,0)
update #report set E2149_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2149') ,0)
update #report set E215_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E215') ,0)
update #report set E215_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E215') ,0)
update #report set E215_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E215') ,0)
update #report set E215_Fase1= isnull((Select Fase1 from #tmp where codice = 'E215') ,0)
update #report set E215_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E215') ,0)
update #report set E216_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E216') ,0)
update #report set E216_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E216') ,0)
update #report set E216_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E216') ,0)
update #report set E216_Fase1= isnull((Select Fase1 from #tmp where codice = 'E216') ,0)
update #report set E216_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E216') ,0)
update #report set E217_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E217') ,0)
update #report set E217_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E217') ,0)
update #report set E217_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E217') ,0)
update #report set E217_Fase1= isnull((Select Fase1 from #tmp where codice = 'E217') ,0)
update #report set E217_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E217') ,0)
update #report set E22_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E22') ,0)
update #report set E22_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E22') ,0)
update #report set E22_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E22') ,0)
update #report set E22_Fase1= isnull((Select Fase1 from #tmp where codice = 'E22') ,0)
update #report set E22_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E22') ,0)
update #report set E221_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E221') ,0)
update #report set E221_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E221') ,0)
update #report set E221_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E221') ,0)
update #report set E221_Fase1= isnull((Select Fase1 from #tmp where codice = 'E221') ,0)
update #report set E221_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E221') ,0)
update #report set E222_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E222') ,0)
update #report set E222_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E222') ,0)
update #report set E222_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E222') ,0)
update #report set E222_Fase1= isnull((Select Fase1 from #tmp where codice = 'E222') ,0)
update #report set E222_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E222') ,0)
update #report set E223_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E223') ,0)
update #report set E223_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E223') ,0)
update #report set E223_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E223') ,0)
update #report set E223_Fase1= isnull((Select Fase1 from #tmp where codice = 'E223') ,0)
update #report set E223_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E223') ,0)
update #report set E224_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E224') ,0)
update #report set E224_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E224') ,0)
update #report set E224_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E224') ,0)
update #report set E224_Fase1= isnull((Select Fase1 from #tmp where codice = 'E224') ,0)
update #report set E224_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E224') ,0)
update #report set E225_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E225') ,0)
update #report set E225_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E225') ,0)
update #report set E225_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E225') ,0)
update #report set E225_Fase1= isnull((Select Fase1 from #tmp where codice = 'E225') ,0)
update #report set E225_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E225') ,0)
update #report set E2251_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2251') ,0)
update #report set E2251_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2251') ,0)
update #report set E2251_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2251') ,0)
update #report set E2251_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2251') ,0)
update #report set E2251_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2251') ,0)
update #report set E226_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E226') ,0)
update #report set E226_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E226') ,0)
update #report set E226_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E226') ,0)
update #report set E226_Fase1= isnull((Select Fase1 from #tmp where codice = 'E226') ,0)
update #report set E226_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E226') ,0)
update #report set E2261_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2261') ,0)
update #report set E2261_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2261') ,0)
update #report set E2261_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2261') ,0)
update #report set E2261_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2261') ,0)
update #report set E2261_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2261') ,0)
update #report set E2262_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2262') ,0)
update #report set E2262_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2262') ,0)
update #report set E2262_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2262') ,0)
update #report set E2262_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2262') ,0)
update #report set E2262_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2262') ,0)
update #report set E2264_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E2264') ,0)
update #report set E2264_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E2264') ,0)
update #report set E2264_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E2264') ,0)
update #report set E2264_Fase1= isnull((Select Fase1 from #tmp where codice = 'E2264') ,0)
update #report set E2264_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E2264') ,0)
update #report set E3_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E3') ,0)
update #report set E3_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E3') ,0)
update #report set E3_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E3') ,0)
update #report set E3_Fase1= isnull((Select Fase1 from #tmp where codice = 'E3') ,0)
update #report set E3_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E3') ,0)
update #report set E3111_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E3111') ,0)
update #report set E3111_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E3111') ,0)
update #report set E3111_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E3111') ,0)
update #report set E3111_Fase1= isnull((Select Fase1 from #tmp where codice = 'E3111') ,0)
update #report set E3111_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E3111') ,0)
update #report set E3112_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E3112') ,0)
update #report set E3112_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E3112') ,0)
update #report set E3112_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E3112') ,0)
update #report set E3112_Fase1= isnull((Select Fase1 from #tmp where codice = 'E3112') ,0)
update #report set E3112_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E3112') ,0)
update #report set E3113_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E3113') ,0)
update #report set E3113_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E3113') ,0)
update #report set E3113_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E3113') ,0)
update #report set E3113_Fase1= isnull((Select Fase1 from #tmp where codice = 'E3113') ,0)
update #report set E3113_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E3113') ,0)
update #report set E3114_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E3114') ,0)
update #report set E3114_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E3114') ,0)
update #report set E3114_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E3114') ,0)
update #report set E3114_Fase1= isnull((Select Fase1 from #tmp where codice = 'E3114') ,0)
update #report set E3114_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E3114') ,0)
update #report set E4_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E4') ,0)
update #report set E4_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E4') ,0)
update #report set E4_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E4') ,0)
update #report set E4_Fase1= isnull((Select Fase1 from #tmp where codice = 'E4') ,0)
update #report set E4_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E4') ,0)
update #report set E5_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E5') ,0)
update #report set E5_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E5') ,0)
update #report set E5_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E5') ,0)
update #report set E5_Fase1= isnull((Select Fase1 from #tmp where codice = 'E5') ,0)
update #report set E5_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E5') ,0)
update #report set E6_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E6') ,0)
update #report set E6_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E6') ,0)
update #report set E6_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E6') ,0)
update #report set E6_Fase1= isnull((Select Fase1 from #tmp where codice = 'E6') ,0)
update #report set E6_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E6') ,0)
update #report set E611_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E611') ,0)
update #report set E611_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E611') ,0)
update #report set E611_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E611') ,0)
update #report set E611_Fase1= isnull((Select Fase1 from #tmp where codice = 'E611') ,0)
update #report set E611_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E611') ,0)
update #report set E612_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E612') ,0)
update #report set E612_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E612') ,0)
update #report set E612_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E612') ,0)
update #report set E612_Fase1= isnull((Select Fase1 from #tmp where codice = 'E612') ,0)
update #report set E612_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E612') ,0)
update #report set E7_Previsione_Iniziale= isnull((Select Previsione_Iniziale from #tmp where codice = 'E7') ,0)
update #report set E7_Variazioni_Budget= isnull((Select Variazioni_Budget from #tmp where codice = 'E7') ,0)
update #report set E7_Previsione_Attuale= isnull((Select Previsione_Iniziale +  Variazioni_Budget from #tmp where codice = 'E7') ,0)
update #report set E7_Fase1= isnull((Select Fase1 from #tmp where codice = 'E7') ,0)
update #report set E7_Budget_Disponibile= isnull((Select Previsione_Iniziale +  Variazioni_Budget - Fase1 from #tmp where codice = 'E7') ,0)

select * from #report


END


