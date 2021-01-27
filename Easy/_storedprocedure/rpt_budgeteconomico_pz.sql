
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomico_pz]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomico_pz]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec AMMINISTRAZIONE.rpt_budgeteconomico_pz 2014, 21,'%','S'
CREATE  PROCEDURE [amministrazione].[rpt_budgeteconomico_pz](
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
Stampa del budget per Potenza
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

--UTILIZZO FONDI ANNO PRECEDENTE	
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
	AND S.sortcode LIKE 'BEUF%'),0) +

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
	AND S.sortcode LIKE 'EC%'),0)


	
--Didattica	ERP1
declare @ERP1_Didattica decimal(19,2)
set @ERP1_Didattica = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ERP1%'),0)

--Ricerca	ERP2
declare @ERP2_Ricerca decimal(19,2)
set @ERP2_Ricerca = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ERP2%'),0)

--TOT. RICAVI DA PROVENTI PROPRI
declare @TOT_RICAVI_Proventi_Propri decimal(19,2)

--CONTRIBUTI	ERC

--Miur (Università)	ERC1
declare @ERC1_Miur decimal(19,2)
set @ERC1_Miur = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ERC1%'),0)

--Altri Enti Pubblici	ERC2
declare @ERC2_Altri_Enti_Pubblici decimal(19,2)
set @ERC2_Altri_Enti_Pubblici = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ERC2%'),0)

--Altri	ERC3
declare @ERC3_Altri decimal(19,2)
set @ERC3_Altri = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ERC3%'),0)

--TOT.RICAVI DA CONTRIBUTI
declare @TOT_RICAVI_DA_CONTRIBUTI decimal(19,2)



--TOTALE RICAVI
declare @TOT_RICAVI decimal(19,2)

--TOTALE RICAVI UF_ANNO_PREC
declare @TOT_RICAVI_UF_ANNO_PREC decimal(19,2)


--COSTI 2015
	
--PERSONALE	ECP
declare @ECP_PERSONALE decimal(19,2)

--Personale dedicato alla Ricerca e alla Didattica:	ECP1

declare @ECP1_Personale_dedicato_alla_Ricerca_alla_Didattica decimal(19,2)
set @ECP1_Personale_dedicato_alla_Ricerca_alla_Didattica = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECP1%'),0)
	
--Strutturato	ECP11
declare @ECP11_Strutturato decimal(19,2)
set @ECP11_Strutturato = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECP11%'),0)

--Non Strutturato	ECP13
declare @ECP12_Non_Strutturato decimal(19,2)
set @ECP12_Non_Strutturato = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECP12%'),0)


--Dirigenti e Tec. Amm.vi	ECP2
declare @ECP2_Dirigenti_e_Tec_Ammvi decimal(19,2)
set @ECP2_Dirigenti_e_Tec_Ammvi = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECP2%'),0)

--Supplenze (affidamenti/contratti)	ECP3
declare @ECP3_Supplenze decimal(19,2)
set @ECP3_Supplenze = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECP3%'),0)

--Altro personale dedicato alla ricerca e alla didattica	ECP16
declare @ECP4_Altro_personale decimal(19,2)
set @ECP4_Altro_personale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECP4%'),0)

--TOT. COSTI DEL PERSONALE	
declare @TOT_COSTI_DEL_PERSONALE decimal(19,2)

--GESTIONE CORRENTE	ECG
declare @ECG_GESTIONE_CORRENTE decimal(19,2)

--Funzionamento generale	ECG1
declare @ECG1_Funzionamento_generale decimal(19,2)
set @ECG1_Funzionamento_generale = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECG1%'),0)
	
--Ricerche  (Costi)	ECG2
declare @ECG2_Ricerche decimal(19,2)
set @ECG2_Ricerche = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECG2%'),0)

--Materiali di consumo	ECG3
declare @ECG3_Materiali_consumo decimal(19,2)
set @ECG3_Materiali_consumo = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECG3%'),0)

--Consulenze e collaborazioni	ECG4
declare @ECG4_Consulenze_e_collaborazioni decimal(19,2)
set @ECG4_Consulenze_e_collaborazioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECG4%'),0)

--Libri	ECG5
declare @ECG5_Libri decimal(19,2)
set @ECG5_Libri = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECG5%'),0)

--Missioni di servizio	ECG6
declare @ECG6_Missioni decimal(19,2)
set @ECG6_Missioni = ISNULL(( SELECT SUM(budgetprevision.prevision)
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
	AND S.sortcode LIKE 'ECG6%'),0)
	
--TOT. COSTI GESTIONE CORRENTE	
declare @TOT_COSTI_GESTIONE_CORRENTE decimal(19,2)


--TOTALE  COSTI	
declare @TOT_COSTI decimal(19,2)

--TOTALE  COSTI	UF ANNO PRECEDENTE
declare @TOT_COSTI_UF_ANNO_PREC decimal(19,2)

set @TOT_RICAVI_Proventi_Propri =	@ERP1_Didattica + 
									@ERP2_Ricerca

set @TOT_RICAVI_DA_CONTRIBUTI =		@ERC1_Miur + 
									@ERC2_Altri_Enti_Pubblici + 
									@ERC3_Altri

set @TOT_RICAVI =	@TOT_RICAVI_DA_CONTRIBUTI + 
					@TOT_RICAVI_Proventi_Propri

set @TOT_RICAVI_UF_ANNO_PREC =	@TOT_RICAVI + @UTILIZZO_FONDI_ANNO_PREC
							

set @TOT_COSTI_DEL_PERSONALE =	@ECP11_Strutturato +
								@ECP12_Non_Strutturato +
								@ECP2_Dirigenti_e_Tec_Ammvi +
								@ECP3_Supplenze +
								@ECP4_Altro_personale


set @TOT_COSTI_GESTIONE_CORRENTE =	@ECG1_Funzionamento_generale + 
									@ECG2_Ricerche +
									@ECG3_Materiali_consumo +
									@ECG4_Consulenze_e_collaborazioni +
									@ECG5_Libri +
									@ECG6_Missioni

set @TOT_COSTI =	@TOT_COSTI_DEL_PERSONALE +
					@TOT_COSTI_GESTIONE_CORRENTE

select
  @treasurer as department,
--UTILIZZO FONDI ANNO PRECEDENTE
@UTILIZZO_FONDI_ANNO_PREC as 'UTILIZZO_FONDI_ANNO_PREC',

--PROVENTI PROPRI	ERP

--Didattica	ERP1
@ERP1_Didattica as 'ERP1_Didattica',

--Ricerca	ERP2
@ERP2_Ricerca as 'ERP2_Ricerca',

--TOT. RICAVI DA PROVENTI PROPRI
@TOT_RICAVI_Proventi_Propri  as 'TOT_RICAVI_Proventi_Propri',

--CONTRIBUTI	ERC
--Miur (Università)	ERC1
@ERC1_Miur as 'ERC1_Miur',

--Altri Enti Pubblici	ERC2
@ERC2_Altri_Enti_Pubblici as 'ERC2_Altri_Enti_Pubblici',

--Altri	ERC3
@ERC3_Altri as 'ERC3_Altri',

--TOT.RICAVI DA CONTRIBUTI
@TOT_RICAVI_DA_CONTRIBUTI  as 'TOT_RICAVI_DA_CONTRIBUTI',

--TOTALE RICAVI
@TOT_RICAVI  as 'TOT_RICAVI',

--TOTALE RICAVI UF_ANNO_PREC
@TOT_RICAVI_UF_ANNO_PREC as 'TOT_RICAVI_UF_ANNO_PREC',
	
--COSTI 2015	
--PERSONALE	ECP

--Personale dedicato alla Ricerca e alla Didattica:	ECP1
@ECP1_Personale_dedicato_alla_Ricerca_alla_Didattica as 'ECP1_Personale_dedicato_alla_Ricerca_alla_Didattica',

--Strutturato	ECP2
@ECP11_Strutturato as 'ECP11_Strutturato',

--Non Strutturato	ECP3
@ECP12_Non_Strutturato as 'ECP12_Non_Strutturato',

--Dirigenti e Tec. Amm.vi	ECP4
@ECP2_Dirigenti_e_Tec_Ammvi as 'ECP2_Dirigenti_e_Tec_Ammvi',

--Supplenze (affidamenti/contratti)	ECP5
@ECP3_Supplenze as 'ECP3_Supplenze',

--Altro personale dedicato alla ricerca e alla didattica	ECP6
@ECP4_Altro_personale as 'ECP4_Altro_personale',

--TOT. COSTI DEL PERSONALE
@TOT_COSTI_DEL_PERSONALE as 'TOT_COSTI_DEL_PERSONALE',	

--GESTIONE CORRENTE	ECG

--Funzionamento generale	ECG1
@ECG1_Funzionamento_generale as 'ECG1_Funzionamento_generale',

--Ricerche  (Costi)	ECG2
@ECG2_Ricerche as 'ECG2_Ricerche',

--Materiali di consumo	ECG3
@ECG3_Materiali_consumo as 'ECG3_Materiali_consumo',

--Consulenze e collaborazioni	ECG4
@ECG4_Consulenze_e_collaborazioni as 'ECG4_Consulenze_e_collaborazioni',

--Libri	ECG5
@ECG5_Libri as 'ECG5_Libri',

--Missioni di servizio	ECG6
@ECG6_Missioni as 'ECG6_Missioni',

--TOT. COSTI GESTIONE CORRENTE
@TOT_COSTI_GESTIONE_CORRENTE as 'TOT_COSTI_GESTIONE_CORRENTE',

	
--TOTALE  COSTI
@TOT_COSTI as 'TOT_COSTI'

		
END


