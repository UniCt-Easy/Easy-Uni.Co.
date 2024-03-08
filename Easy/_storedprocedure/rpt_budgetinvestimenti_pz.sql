
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgetinvestimenti_pz]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgetinvestimenti_pz]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec AMMINISTRAZIONE.rpt_budgeteconomico_pz 2014, 21,'%','S'
CREATE  PROCEDURE [amministrazione].[rpt_budgetinvestimenti_pz](
	@ayear int,--> anno del bilancio di previsione
	@idsorkind int,
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
/*
Stampa del budget investimenti per Potenza
Gianni 24/11/2014
*/

AS BEGIN
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

--UTILIZZO FONDI 2014	
declare @UTILIZZO_FONDI_ANNO_PREC decimal(19,2)
set @UTILIZZO_FONDI_ANNO_PREC = 
ISNULL(( SELECT SUM(finyear.prevision)
FROM finyear 
join finsorting FS
on finyear.idfin= FS.idfin
join sorting S
	on FS.idsor = S.idsor
JOIN upb U
	ON finyear.idupb = U.idupb
WHERE finyear.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'BIUF%'),0) +

ISNULL(( SELECT SUM(finyear.currentarrears)
FROM finyear 
join finsorting FS
on finyear.idfin= FS.idfin
join sorting S
	on FS.idsor = S.idsor
JOIN upb U
	ON finyear.idupb = U.idupb
WHERE finyear.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'IC%'),0)


--Didattica	IRP1
declare @IRP1_Didattica decimal(19,2)
set @IRP1_Didattica = ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'IRP1%'),0)

--Ricerca	IRP2
declare @IRP2_Ricerca decimal(19,2)
set @IRP2_Ricerca = ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'IRP2%'),0)

--TOT. RICAVI DA PROVENTI PROPRI
declare @TOT_RICAVI_Proventi_Propri decimal(19,2)

--TOTALE RICAVI UF_ANNO_PREC
declare @TOT_RICAVI_UF_ANNO_PREC decimal(19,2)


--CONTRIBUTI	IRC

--Miur (Università)	IRC1
declare @IRC1_Miur decimal(19,2)
set @IRC1_Miur = ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'IRC1%'),0)

--Altri Enti Pubblici	IRC2
declare @IRC2_Altri_Enti_Pubblici decimal(19,2)
set @IRC2_Altri_Enti_Pubblici = ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'IRC2%'),0)

--Altri	IRC3
declare @IRC3_Altri decimal(19,2)
set @IRC3_Altri = ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'IRC3%'),0)

--TOT.RICAVI DA CONTRIBUTI
declare @TOT_RICAVI_DA_CONTRIBUTI decimal(19,2)


--TOTALE RICAVI
declare @TOT_RICAVI decimal(19,2)


--INVESTIMENTI 2015
		
--Ricerche (investimento)	ICR1
declare @ICR1_Ricerche decimal(19,2)
set @ICR1_Ricerche = ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'ICR1%'),0)

--Altre spese di investimento	ICA1
declare @ICA1_Altre_Spese_Investimento decimal(19,2)
set @ICA1_Altre_Spese_Investimento = ISNULL(( SELECT SUM(budgetprevision.prevision)
FROM budgetprevision 
join sorting S
	on budgetprevision.idsor = S.idsor
JOIN upb U
	ON budgetprevision.idupb = U.idupb
WHERE budgetprevision.ayear = @ayear
	and S.idsorkind = @idsorkind
	AND U.idupb like @idupb
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
	AND S.sortcode LIKE 'ICA1%'),0)

	
--TOT. INVESTIMENTI
declare @TOT_INVESTIMENTI decimal(19,2)



set @TOT_RICAVI_Proventi_Propri =	@IRP1_Didattica + 
									@IRP2_Ricerca

set @TOT_RICAVI_DA_CONTRIBUTI =		@IRC1_Miur + 
									@IRC2_Altri_Enti_Pubblici + 
									@IRC3_Altri

set @TOT_RICAVI =	@TOT_RICAVI_DA_CONTRIBUTI + 
					@TOT_RICAVI_Proventi_Propri

set @TOT_RICAVI_UF_ANNO_PREC =	@TOT_RICAVI + @UTILIZZO_FONDI_ANNO_PREC
							



set @TOT_INVESTIMENTI =	@ICR1_Ricerche + 
						@ICA1_Altre_Spese_Investimento



select
  @treasurer as department,
--UTILIZZO FONDI 2014
@UTILIZZO_FONDI_ANNO_PREC as 'UTILIZZO_FONDI_ANNO_PREC',

--PROVENTI PROPRI	ERP

--Didattica	IRP1
@IRP1_Didattica as 'IRP1_Didattica',

--Ricerca	IRP2
@IRP2_Ricerca as 'IRP2_Ricerca',

--TOT. RICAVI DA PROVENTI PROPRI
@TOT_RICAVI_Proventi_Propri  as 'TOT_RICAVI_Proventi_Propri',

	
--CONTRIBUTI	IRC
--Miur (Università)	IRC1
@IRC1_Miur as 'IRC1_Miur',

--Altri Enti Pubblici	IRC2
@IRC2_Altri_Enti_Pubblici as 'IRC2_Altri_Enti_Pubblici',

--Altri	IRC3
@IRC3_Altri as 'IRC3_Altri',

--TOT.RICAVI DA CONTRIBUTI
@TOT_RICAVI_DA_CONTRIBUTI  as 'TOT_RICAVI_DA_CONTRIBUTI',


--TOTALE RICAVI
@TOT_RICAVI  as 'TOT_RICAVI',

--TOTALE RICAVI UF_ANNO_PREC
@TOT_RICAVI_UF_ANNO_PREC as 'TOT_RICAVI_UF_ANNO_PREC',
	
--Ricerche (investimento)	ICR1
@ICR1_Ricerche as 'ICR1_Ricerche',

--Altre spese di investimento	ICA1
@ICA1_Altre_Spese_Investimento as 'ICA1_Altre_Spese_Investimento',


--TOT. COSTI GESTIONE CORRENTE
@TOT_INVESTIMENTI as 'TOT_INVESTIMENTI'
	

				
END
