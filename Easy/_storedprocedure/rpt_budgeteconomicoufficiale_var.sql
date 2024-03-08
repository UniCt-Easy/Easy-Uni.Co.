
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


--setuser 'amministrazione'

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_var]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_var]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec rpt_budgeteconomicoufficiale_var 2021, {d '2021-11-11'}, 22,'%','S',null,null,null,null,null
CREATE PROCEDURE [rpt_budgeteconomicoufficiale_var] (
	@ayear int,--> anno del bilancio di previsione
	@data datetime,
	@idsorkind int,
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
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

DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
BEGIN
	SET @idupb=@idupb+'%' 
END

/*	I. PROVENTI PROPRI
	1)Proventi per la didattica
	2)Proventi da Ricerche commissionate e trasferimento tecnologico
	3)Proventi da Ricerche con finanziamento competitivi
*/
declare @A_I1_ProventiPerLaDidattica decimal(19,2)
declare @A_I1_ProventiPerLaDidattica_var decimal(19,2)
SELECT	@A_I1_ProventiPerLaDidattica_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE (bv.ybudgetvar = @ayear or @ayear is null)
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1101%'

SELECT	@A_I1_ProventiPerLaDidattica = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1101%'

declare @A_I2_ProventiDaRicercheCommissionate decimal(19,2)
declare @A_I2_ProventiDaRicercheCommissionate_var decimal(19,2)
SELECT	@A_I2_ProventiDaRicercheCommissionate_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1102%'

SELECT	@A_I2_ProventiDaRicercheCommissionate = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1102%'

declare @A_I3_ProventiDaRicercheConFinanziamento decimal(19,2)
declare @A_I3_ProventiDaRicercheConFinanziamento_var decimal(19,2)
SELECT	@A_I3_ProventiDaRicercheConFinanziamento_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1103%'

SELECT	@A_I3_ProventiDaRicercheConFinanziamento = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1103%'

declare @A_I_ProventiPropri decimal(19,2)
set @A_I_ProventiPropri = isnull(@A_I1_ProventiPerLaDidattica, 0) + isnull(@A_I2_ProventiDaRicercheCommissionate, 0) + isnull(@A_I3_ProventiDaRicercheConFinanziamento, 0)
declare @A_I_ProventiPropri_var decimal(19,2)
set @A_I_ProventiPropri_var = isnull(@A_I1_ProventiPerLaDidattica_var, 0) + isnull(@A_I2_ProventiDaRicercheCommissionate_var, 0) + isnull(@A_I3_ProventiDaRicercheConFinanziamento_var, 0)

/*
	II.CONTRIBUTI
	1)Contributi MIUR e altre Amministrazioni centrali
	2)Contributi Regioni e Province autonome
	3)Contributi altre Amministrazioni locali
	4)Contributi Unione Europea e altri Organismi Internazionali
	5)Contributi da Università
	6)Contributi da altri (pubblici)
	7)Contributi da altri (privati)
*/
declare @A_II1_ContributiMIUR decimal(19,2)
declare @A_II1_ContributiMIUR_var decimal(19,2)
SELECT	@A_II1_ContributiMIUR_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1201%'

SELECT	@A_II1_ContributiMIUR = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1201%'

declare @A_II2_ContributiRegioni decimal(19,2)
declare @A_II2_ContributiRegioni_var decimal(19,2)
SELECT	@A_II2_ContributiRegioni_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1202%'

SELECT	@A_II2_ContributiRegioni = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1202%'

declare @A_II3_ContributiAltreAmministrazioni decimal(19,2)
declare @A_II3_ContributiAltreAmministrazioni_var decimal(19,2)
SELECT	@A_II3_ContributiAltreAmministrazioni_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1203%'

SELECT	@A_II3_ContributiAltreAmministrazioni = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1203%'

declare @A_II4_ContributiUE decimal(19,2)
declare @A_II4_ContributiUE_var decimal(19,2)
SELECT	@A_II4_ContributiUE_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1204%'

SELECT	@A_II4_ContributiUE = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1204%'

declare @A_II5_ContributiUniversita decimal(19,2)
declare @A_II5_ContributiUniversita_var decimal(19,2)
SELECT	@A_II5_ContributiUniversita_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1205%'

SELECT	@A_II5_ContributiUniversita = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1205%'

declare @A_II6_ContributiAltriPubblici decimal(19,2)
declare @A_II6_ContributiAltriPubblici_var decimal(19,2)
SELECT	@A_II6_ContributiAltriPubblici_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1206%'

SELECT	@A_II6_ContributiAltriPubblici = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1206%'

declare @A_II7_ContributiAltriPrivati decimal(19,2)
declare @A_II7_ContributiAltriPrivati_var decimal(19,2)
SELECT	@A_II7_ContributiAltriPrivati_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1207%'

SELECT	@A_II7_ContributiAltriPrivati = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1207%'

declare @A_II_Contributi decimal(19,2)
set @A_II_Contributi = isnull(@A_II1_ContributiMIUR, 0) + isnull(@A_II2_ContributiRegioni, 0) + isnull(@A_II3_ContributiAltreAmministrazioni, 0) + isnull(@A_II4_ContributiUE, 0) +
								isnull(@A_II5_ContributiUniversita, 0) + isnull(@A_II6_ContributiAltriPubblici, 0) + isnull(@A_II7_ContributiAltriPrivati, 0)
declare @A_II_Contributi_var decimal(19,2)
set @A_II_Contributi_var = isnull(@A_II1_ContributiMIUR_var, 0) + isnull(@A_II2_ContributiRegioni_var, 0) + isnull(@A_II3_ContributiAltreAmministrazioni_var, 0) + isnull(@A_II4_ContributiUE_var, 0) +
								  isnull(@A_II5_ContributiUniversita_var, 0) + isnull(@A_II6_ContributiAltriPubblici_var, 0) + isnull(@A_II7_ContributiAltriPrivati_var, 0)

declare @A_III_ProventiPerAttivitaAssistenziale decimal(19,2)
declare @A_III_ProventiPerAttivitaAssistenziale_var decimal(19,2)
SELECT	@A_III_ProventiPerAttivitaAssistenziale_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1301%'

SELECT	@A_III_ProventiPerAttivitaAssistenziale = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1301%'

-- IV. PROVENTI PER GESTIONE DIRETTA INTERVENTI PER IL DIRITTO ALLO STUDIO
declare @A_IV_ProventiPerGestioneDiretta decimal(19,2)
declare @A_IV_ProventiPerGestioneDiretta_var decimal(19,2)
SELECT	@A_IV_ProventiPerGestioneDiretta_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1401%'

SELECT	@A_IV_ProventiPerGestioneDiretta = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1401%'

-- V.ALTRI PROVENTI E RICAVI DIVERSI
-- 1) Utilizzo di riserve di Patrimonio netto derivanti dalla contabilità finanziaria
-- 2) Altri Proventi e Ricavi Diversi
declare @A_V1_UtilizzoRiservePatrimonioNetto decimal(19,2)
declare @A_V1_UtilizzoRiservePatrimonioNetto_var decimal(19,2)
SELECT	@A_V1_UtilizzoRiservePatrimonioNetto_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1501%'
		
SELECT	@A_V1_UtilizzoRiservePatrimonioNetto = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1501%'

declare @A_V2_AltriProventi decimal(19,2)
declare @A_V2_AltriProventi_var decimal(19,2)
SELECT	@A_V2_AltriProventi_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1502%'

SELECT	@A_V2_AltriProventi = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1502%'

declare @A_V_UtilizzoRiservePatrimonioNetto decimal(19,2)
set @A_V_UtilizzoRiservePatrimonioNetto = isnull(@A_V1_UtilizzoRiservePatrimonioNetto, 0) + isnull(@A_V2_AltriProventi, 0)
declare @A_V_UtilizzoRiservePatrimonioNetto_var decimal(19,2)
set @A_V_UtilizzoRiservePatrimonioNetto_var = isnull(@A_V1_UtilizzoRiservePatrimonioNetto_var, 0) + isnull(@A_V2_AltriProventi_var, 0)

-- Variazione Rimanenze
declare @A_VI_VariazioniRimanenze decimal(19,2)
declare @A_VI_VariazioniRimanenze_var decimal(19,2)
SELECT	@A_VI_VariazioniRimanenze_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1601%'

SELECT	@A_VI_VariazioniRimanenze = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1601%'

-- Incremento delle Immobilizzazioni per Lavori Interni
declare @A_VII_IncrementoImmobilizzazioni decimal(19,2)
declare @A_VII_IncrementoImmobilizzazioni_var decimal(19,2)
SELECT	@A_VII_IncrementoImmobilizzazioni_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EA1701%'

SELECT	@A_VII_IncrementoImmobilizzazioni = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EA1701%'

/*
 B)	COSTI OPERATIVI
VIII.COSTI DEL PERSONALE
	1) Costi del personale dedicato alla ricerca e alla didattica
		a)Docenti/ricercatori
		b)Collaborazioni scientifiche (collaboratori, assegnisti, ecc)
		c)Docenti a contratto 
		d)Esperti linguistici
		e)Altro personale dedicato alla didattica e alla ricerca
	2) Costi del personale dirigente e tecnico-amministrativo
*/

declare @B_VIII1a_CostiDocentiRicercatori decimal(19,2)
declare @B_VIII1a_CostiDocentiRicercatori_var decimal(19,2)
SELECT	@B_VIII1a_CostiDocentiRicercatori_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB1101%'

SELECT	@B_VIII1a_CostiDocentiRicercatori = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1101%'

declare @B_VIII1b_CollaborazioniScientifiche decimal(19,2)
declare @B_VIII1b_CollaborazioniScientifiche_var decimal(19,2)
SELECT	@B_VIII1b_CollaborazioniScientifiche_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB1102%'

SELECT	@B_VIII1b_CollaborazioniScientifiche = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1102%'

declare @B_VIII1c_DocentiAContratto decimal(19,2)
declare @B_VIII1c_DocentiAContratto_var decimal(19,2)
SELECT	@B_VIII1c_DocentiAContratto_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB1103%'

SELECT	@B_VIII1c_DocentiAContratto = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1103%'

declare @B_VIII1d_EspertiLinguistici decimal(19,2)
declare @B_VIII1d_EspertiLinguistici_var decimal(19,2)
SELECT	@B_VIII1d_EspertiLinguistici_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB1104%'

SELECT	@B_VIII1d_EspertiLinguistici = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1104%'

declare @B_VIII1e_AltroPersonale decimal(19,2)
declare @B_VIII1e_AltroPersonale_var decimal(19,2)
SELECT	@B_VIII1e_AltroPersonale_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB1105%'

SELECT	@B_VIII1e_AltroPersonale = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1105%'

declare @B_VIII2_CostiPersonaleDirigente decimal(19,2)
declare @B_VIII2_CostiPersonaleDirigente_var decimal(19,2)
SELECT	@B_VIII2_CostiPersonaleDirigente_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB1201%'

SELECT	@B_VIII2_CostiPersonaleDirigente = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB1201%'

declare @B_VIII_CostiPersonale decimal(19,2)
set @B_VIII_CostiPersonale = isnull(@B_VIII1a_CostiDocentiRicercatori, 0) + isnull(@B_VIII1b_CollaborazioniScientifiche, 0) + isnull(@B_VIII1c_DocentiAContratto, 0) + isnull(@B_VIII1d_EspertiLinguistici, 0) +
								isnull(@B_VIII1e_AltroPersonale, 0) + isnull(@B_VIII2_CostiPersonaleDirigente, 0)
declare @B_VIII_CostiPersonale_var decimal(19,2)
set @B_VIII_CostiPersonale_var = isnull(@B_VIII1a_CostiDocentiRicercatori_var, 0) + isnull(@B_VIII1b_CollaborazioniScientifiche_var, 0) + isnull(@B_VIII1c_DocentiAContratto_var, 0) + isnull(@B_VIII1d_EspertiLinguistici_var, 0) +
								  isnull(@B_VIII1e_AltroPersonale_var, 0) + isnull(@B_VIII2_CostiPersonaleDirigente_var, 0)

	/*
	IX.COSTI DELLA GESTIONE CORRENTE
	1)Costi per sostegno agli studenti
	2)Costi per il diritto allo studio
	3)Costi per la ricerca e l'attività editoriale
	4)Trasferimenti a partner di progetti coordinati
	5)Acquisto materiale consumo per laboratori
	6)Variazione rimanenze di materiale di consumo per laboratori
	7)Acquisto di libri, periodici e materiale bibliografico
	8)Acquisto di servizi e collaborazioni tecnico gestionali
	9)Acquisto altri materiali
	10)Variazione delle rimanenze di materiali
	11)Costi per godimento bene di terzi
	12)Altri  costi 
	*/
declare @B_IX1_CostiSostegnoStudenti decimal(19,2)
declare @B_IX1_CostiSostegnoStudenti_var decimal(19,2)
SELECT	@B_IX1_CostiSostegnoStudenti_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2101%'

SELECT	@B_IX1_CostiSostegnoStudenti = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2101%'

declare @B_IX2_CostiDirittoStudio decimal(19,2)
declare @B_IX2_CostiDirittoStudio_var decimal(19,2)
SELECT	@B_IX2_CostiDirittoStudio_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2102%'

SELECT	@B_IX2_CostiDirittoStudio = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2102%'

declare @B_IX3_CostiRicercaAttivitaEditoriale decimal(19,2)
declare @B_IX3_CostiRicercaAttivitaEditoriale_var decimal(19,2)
SELECT	@B_IX3_CostiRicercaAttivitaEditoriale_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2103%'
	
SELECT	@B_IX3_CostiRicercaAttivitaEditoriale = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2103%'

declare @B_IX4_TrasferimentiPartner decimal(19,2)
declare @B_IX4_TrasferimentiPartner_var decimal(19,2)
SELECT	@B_IX4_TrasferimentiPartner_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2104%'

SELECT	@B_IX4_TrasferimentiPartner = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2104%'

declare @B_IX5_AcquistoMaterialeConsumo decimal(19,2)
declare @B_IX5_AcquistoMaterialeConsumo_var decimal(19,2)
SELECT	@B_IX5_AcquistoMaterialeConsumo_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2105%'

SELECT	@B_IX5_AcquistoMaterialeConsumo = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2105%'

declare @B_IX6_VariazioneRimanenze decimal(19,2)
declare @B_IX6_VariazioneRimanenze_var decimal(19,2)
SELECT	@B_IX6_VariazioneRimanenze_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2106%'

SELECT	@B_IX6_VariazioneRimanenze = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2106%'

declare @B_IX7_AcquistoLibri decimal(19,2)
declare @B_IX7_AcquistoLibri_var decimal(19,2)
SELECT	@B_IX7_AcquistoLibri_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2107%'

SELECT	@B_IX7_AcquistoLibri = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2107%'

declare @B_IX8_AcquistoServizi decimal(19,2)
declare @B_IX8_AcquistoServizi_var decimal(19,2)
SELECT	@B_IX8_AcquistoServizi_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2108%'

SELECT	@B_IX8_AcquistoServizi = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2108%'

declare @B_IX9_AcquistoAltriMateriali decimal(19,2)
declare @B_IX9_AcquistoAltriMateriali_var decimal(19,2)
SELECT	@B_IX9_AcquistoAltriMateriali_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2109%'

SELECT	@B_IX9_AcquistoAltriMateriali = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2109%'

declare @B_IX10_VariazioneRimanenze decimal(19,2)
declare @B_IX10_VariazioneRimanenze_var decimal(19,2)
SELECT	@B_IX10_VariazioneRimanenze_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2110%'

SELECT	@B_IX10_VariazioneRimanenze = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2110%'

declare @B_IX11_CostiGodimento decimal(19,2)
declare @B_IX11_CostiGodimento_var decimal(19,2)
SELECT	@B_IX11_CostiGodimento_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2111%'

SELECT	@B_IX11_CostiGodimento = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2111%'

declare @B_IX12_AltriCosti decimal(19,2)
declare @B_IX12_AltriCosti_var decimal(19,2)
SELECT	@B_IX12_AltriCosti_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB2112%'

SELECT	@B_IX12_AltriCosti = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB2112%'

declare @IX_CostiGestione decimal(19,2)
set @IX_CostiGestione = isnull(@B_IX1_CostiSostegnoStudenti, 0) + isnull(@B_IX2_CostiDirittoStudio, 0) + isnull(@B_IX3_CostiRicercaAttivitaEditoriale, 0) + isnull(@B_IX4_TrasferimentiPartner, 0) +
						isnull(@B_IX5_AcquistoMaterialeConsumo, 0) + isnull(@B_IX6_VariazioneRimanenze, 0) + isnull(@B_IX7_AcquistoLibri, 0) + isnull(@B_IX8_AcquistoServizi, 0) +
						isnull(@B_IX9_AcquistoAltriMateriali, 0) + isnull(@B_IX10_VariazioneRimanenze, 0) + isnull(@B_IX11_CostiGodimento, 0) + isnull(@B_IX12_AltriCosti, 0)
declare @IX_CostiGestione_var decimal(19,2)
set @IX_CostiGestione_var = isnull(@B_IX1_CostiSostegnoStudenti_var, 0) + isnull(@B_IX2_CostiDirittoStudio_var, 0) + isnull(@B_IX3_CostiRicercaAttivitaEditoriale_var, 0) + isnull(@B_IX4_TrasferimentiPartner_var, 0) +
							isnull(@B_IX5_AcquistoMaterialeConsumo_var, 0) + isnull(@B_IX6_VariazioneRimanenze_var, 0) + isnull(@B_IX7_AcquistoLibri_var, 0) + isnull(@B_IX8_AcquistoServizi_var, 0) +
							isnull(@B_IX9_AcquistoAltriMateriali_var, 0) + isnull(@B_IX10_VariazioneRimanenze_var, 0) + isnull(@B_IX11_CostiGodimento_var, 0) + isnull(@B_IX12_AltriCosti_var, 0)
/*	
	X.AMMORTAMENTI E SVALUTAZIONI
		1) Ammortamenti immobilizzazioni immateriali
		2) Ammortamenti immobilizzazioni materiali
		3) Svalutazioni immobilizzazioni
		4) Svalutazioni dei crediti compresi nell'attivo circolante e nelle disponibilità liquide
*/

declare @B_X1_AmmortamentiImmobImmateriali decimal(19,2)
declare @B_X1_AmmortamentiImmobImmateriali_var decimal(19,2)
SELECT	@B_X1_AmmortamentiImmobImmateriali_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB3101%'

SELECT	@B_X1_AmmortamentiImmobImmateriali = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB3101%'

declare @B_X2_AmmortamentiImmobMateriali decimal(19,2)
declare @B_X2_AmmortamentiImmobMateriali_var decimal(19,2)
SELECT	@B_X2_AmmortamentiImmobMateriali_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB3102%'

SELECT	@B_X2_AmmortamentiImmobMateriali = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB3102%'

declare @B_X3_SvalutazioniImmobilizzazioni decimal(19,2)
declare @B_X3_SvalutazioniImmobilizzazioni_var decimal(19,2)
SELECT	@B_X3_SvalutazioniImmobilizzazioni_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB3103%'

SELECT	@B_X3_SvalutazioniImmobilizzazioni = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB3103%'

declare @B_X4_SvalutazioniCrediti decimal(19,2)
declare @B_X4_SvalutazioniCrediti_var decimal(19,2)
SELECT	@B_X4_SvalutazioniCrediti_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB3104%'

SELECT	@B_X4_SvalutazioniCrediti = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB3104%'

declare @X_AmmortamentiSvalutazioni decimal(19,2)
set @X_AmmortamentiSvalutazioni = isnull(@B_X1_AmmortamentiImmobImmateriali, 0) + isnull(@B_X2_AmmortamentiImmobMateriali, 0) + isnull(@B_X3_SvalutazioniImmobilizzazioni, 0) + isnull(@B_X4_SvalutazioniCrediti, 0)
declare @X_AmmortamentiSvalutazioni_var decimal(19,2)
set @X_AmmortamentiSvalutazioni_var = isnull(@B_X1_AmmortamentiImmobImmateriali_var, 0) + isnull(@B_X2_AmmortamentiImmobMateriali_var, 0) + isnull(@B_X3_SvalutazioniImmobilizzazioni_var, 0) + isnull(@B_X4_SvalutazioniCrediti_var, 0)

declare @B_XI_AccantonamentiRischiOneri decimal(19,2)
declare @B_XI_AccantonamentiRischiOneri_var decimal(19,2)
SELECT	@B_XI_AccantonamentiRischiOneri_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB4101%'

SELECT	@B_XI_AccantonamentiRischiOneri = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB4101%'

declare @B_XII_OneriDversiGestione decimal(19,2)
declare @B_XII_OneriDversiGestione_var decimal(19,2)
SELECT	@B_XII_OneriDversiGestione_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EB5101%'

SELECT	@B_XII_OneriDversiGestione = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EB5101%'

/*
	C) PROVENTI ED ONERI FINANZIARI
	1) Proventi finanziari
	2) Interessi ed altri oneri finanziari 
	3) Utili su cambi 
	4) Perdite su cambi 
*/
declare @C_1ProventiFinanziari decimal(19,2)
declare @C_1ProventiFinanziari_var decimal(19,2)
SELECT	@C_1ProventiFinanziari_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EC1101%'

SELECT	@C_1ProventiFinanziari = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC1101%'

declare @C_2Interessi_orig decimal(19,2)
declare @C_2Interessi decimal(19,2)
declare @C_2Interessi_var decimal(19,2)
SELECT	@C_2Interessi_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EC1102%'

SELECT	@C_2Interessi_orig = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC1102%'

if (isnull(@C_2Interessi_orig, 0) < 0) set @C_2Interessi = -isnull(@C_2Interessi_orig, 0) else set @C_2Interessi = isnull(@C_2Interessi_orig, 0)

declare @C_3Utili decimal(19,2)
declare @C_3Utili_var decimal(19,2)
SELECT	@C_3Utili_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EC1103%'

SELECT	@C_3Utili = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC1103%'

declare @C_3Perdite decimal(19,2)
declare @C_3Perdite_var decimal(19,2)
SELECT	@C_3Perdite_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EC1104%'

SELECT	@C_3Perdite = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EC1104%'

declare @C_ProventiOneri_orig decimal(19,2)
declare @C_ProventiOneri decimal(19,2)
set @C_ProventiOneri_orig = isnull(@C_1ProventiFinanziari, 0) - isnull(@C_2Interessi, 0) + isnull(@C_3Utili, 0) + isnull(@C_3Perdite, 0)
if (@C_ProventiOneri_orig < 0) set @C_ProventiOneri = -@C_ProventiOneri_orig else set @C_ProventiOneri = @C_ProventiOneri_orig

declare @C_ProventiOneri_var_orig decimal(19,2)
declare @C_ProventiOneri_var decimal(19,2)
set @C_ProventiOneri_var_orig = isnull(@C_1ProventiFinanziari_var, 0) - isnull(@C_2Interessi_var, 0) + isnull(@C_3Utili_var, 0) + isnull(@C_3Perdite_var, 0)
if (@C_ProventiOneri_var_orig < 0) set @C_ProventiOneri_var = -@C_ProventiOneri_var_orig else set @C_ProventiOneri_var = @C_ProventiOneri_var_orig

/*
	D) RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
		1) Rivalutazioni di attività finanziarie
		2) Svalutazioni di attività finanziarie
*/
declare @D_1Rivalutazioni decimal(19,2)
declare @D_1Rivalutazioni_var decimal(19,2)
SELECT	@D_1Rivalutazioni_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'ED1101%'

SELECT	@D_1Rivalutazioni = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'ED1101%'

declare @D_2Svalutazioni_orig decimal(19,2)
declare @D_2Svalutazioni decimal(19,2)
declare @D_2Svalutazioni_var_orig decimal(19,2)
declare @D_2Svalutazioni_var decimal(19,2)
SELECT	@D_2Svalutazioni_var_orig = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'ED1102%'

SELECT	@D_2Svalutazioni_orig = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'ED1102%'

if (isnull(@D_2Svalutazioni_orig, 0) < 0) set @D_2Svalutazioni = -isnull(@D_2Svalutazioni_orig, 0) else set @D_2Svalutazioni = isnull(@D_2Svalutazioni_orig, 0)

declare @D_Rettifiche_orig decimal(19,2)
declare @D_Rettifiche decimal(19,2)
set @D_Rettifiche_orig = isnull(@D_1Rivalutazioni, 0) - isnull(@D_2Svalutazioni, 0)
if (@D_Rettifiche_orig < 0) set @D_Rettifiche = -@D_Rettifiche_orig else set @D_Rettifiche = @D_Rettifiche_orig

if (isnull(@D_2Svalutazioni_var_orig, 0) < 0) set @D_2Svalutazioni_var = -isnull(@D_2Svalutazioni_var_orig, 0) else set @D_2Svalutazioni_var = isnull(@D_2Svalutazioni_var_orig, 0)

declare @D_Rettifiche_var_orig decimal(19,2)
declare @D_Rettifiche_var decimal(19,2)
set @D_Rettifiche_var_orig = isnull(@D_1Rivalutazioni_var, 0) + isnull(@D_2Svalutazioni_var, 0)
if (@D_Rettifiche_var_orig < 0) set @D_Rettifiche_var = -@D_Rettifiche_var_orig else set @D_Rettifiche_var = @D_Rettifiche_var_orig

/*
	E)	PROVENTI ED ONERI STRAORDINARI
		1) Proventi straordinari
		2) Oneri straordinari
*/
			
declare @E_1ProventiStraordinari decimal(19,2)
declare @E_1ProventiStraordinari_var decimal(19,2)
SELECT	@E_1ProventiStraordinari_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EE1101%'

SELECT	@E_1ProventiStraordinari = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EE1101%'

declare @E_2OneriStraordinari_orig decimal(19,2)
declare @E_2OneriStraordinari decimal(19,2)
declare @E_2OneriStraordinari_var_orig decimal(19,2)
declare @E_2OneriStraordinari_var decimal(19,2)
SELECT	@E_2OneriStraordinari_var_orig = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EE1102%'

SELECT	@E_2OneriStraordinari_orig = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EE1102%'

if (isnull(@E_2OneriStraordinari_orig, 0) < 0) set @E_2OneriStraordinari = -isnull(@E_2OneriStraordinari_orig, 0) else set @E_2OneriStraordinari = isnull(@E_2OneriStraordinari_orig, 0)
declare @E_ProventiOneriStraordinari_orig decimal(19,2)
declare @E_ProventiOneriStraordinari decimal(19,2)
set @E_ProventiOneriStraordinari_orig = isnull(@E_1ProventiStraordinari, 0) - isnull(@E_2OneriStraordinari, 0)
if (@E_ProventiOneriStraordinari_orig < 0) set @E_ProventiOneriStraordinari = -@E_ProventiOneriStraordinari_orig else set @E_ProventiOneriStraordinari = @E_ProventiOneriStraordinari_orig

if (isnull(@E_2OneriStraordinari_var_orig, 0) < 0) set @E_2OneriStraordinari_var = -isnull(@E_2OneriStraordinari_var_orig, 0) else set @E_2OneriStraordinari_var = isnull(@E_2OneriStraordinari_var_orig, 0)
declare @E_ProventiOneriStraordinari_var_orig decimal(19,2)
declare @E_ProventiOneriStraordinari_var decimal(19,2)
set @E_ProventiOneriStraordinari_var_orig = isnull(@E_1ProventiStraordinari_var, 0) - isnull(@E_2OneriStraordinari_var, 0)
if(@E_ProventiOneriStraordinari_var_orig < 0) set @E_ProventiOneriStraordinari_var = -@E_ProventiOneriStraordinari_var_orig else set @E_ProventiOneriStraordinari_var = @E_ProventiOneriStraordinari_var_orig

/*
	F) Imposte sul reddito dell'esercizio correnti, differite, anticipate
*/
declare @F_Imposte_orig decimal(19,2)
declare @F_Imposte decimal(19,2)
declare @F_Imposte_var_orig decimal(19,2)
declare @F_Imposte_var decimal(19,2)
SELECT	@F_Imposte_var_orig = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EF1101%'

SELECT	@F_Imposte_orig = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EF1101%'

if (isnull(@F_Imposte_orig, 0) < 0) set @F_Imposte = -isnull(@F_Imposte_orig, 0) else set @F_Imposte = isnull(@F_Imposte_orig, 0)
if (isnull(@F_Imposte_var_orig, 0) < 0) set @F_Imposte_var = -isnull(@F_Imposte_var_orig, 0) else set @F_Imposte_var = isnull(@F_Imposte_var_orig, 0)
/*
	G) Utilizzo di riservedi Patrimonio Netto derivanti dalla contabilità economico-patrimoniale
*/
declare @G_UtilizzoDiRiserve decimal(19,2)
declare @G_UtilizzoDiRiserve_var decimal(19,2)
SELECT	@G_UtilizzoDiRiserve_var = isnull(sum(bvd.amount), 0)
	FROM budgetvar bv
	join budgetvardetail bvd	on bvd.ybudgetvar = bv.ybudgetvar and  bvd.nbudgetvar = bv.nbudgetvar
	join sorting s				on s.idsor = bvd.idsor
	JOIN upb u					on u.idupb = bvd.idupb
	WHERE bv.ybudgetvar = @ayear
		and s.idsorkind = @idsorkind
		AND u.idupb like @idupb
		AND bv.idbudgetvarstatus = 5
		AND (bv.adate <= @data or @data is null)
		AND (@idsor01 IS NULL OR u.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR u.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR u.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR u.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR u.idsor05 = @idsor05)
		AND s.sortcode LIKE 'EG1101%'

SELECT	@G_UtilizzoDiRiserve = isnull(sum(budgetprevision.prevision), 0)
	FROM budgetprevision 
	join sorting S		on budgetprevision.idsor = S.idsor
	JOIN upb U			ON budgetprevision.idupb = U.idupb 
	WHERE (budgetprevision.ayear = @ayear or @ayear is null)
		and S.idsorkind = @idsorkind
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'EG1101%'

declare @risultatoEconomicoPresunto decimal(19,2)
set @risultatoEconomicoPresunto = @A_I_ProventiPropri + @A_II_Contributi + @A_III_ProventiPerAttivitaAssistenziale + @A_IV_ProventiPerGestioneDiretta +
								@A_V_UtilizzoRiservePatrimonioNetto + @A_VI_VariazioniRimanenze + @A_VII_IncrementoImmobilizzazioni 
								-(@B_VIII_CostiPersonale + @IX_CostiGestione + @X_AmmortamentiSvalutazioni + @B_XI_AccantonamentiRischiOneri +
								@B_XII_OneriDversiGestione) + @C_ProventiOneri_orig + @D_Rettifiche_orig + @E_ProventiOneriStraordinari_orig
								- @F_Imposte_orig

declare @risultatoEconomicoPresunto_var decimal(19,2)
set @risultatoEconomicoPresunto_var = @A_I_ProventiPropri_var + @A_II_Contributi_var + @A_III_ProventiPerAttivitaAssistenziale_var + @A_IV_ProventiPerGestioneDiretta_var +
									@A_V_UtilizzoRiservePatrimonioNetto_var + @A_VI_VariazioniRimanenze_var + @A_VII_IncrementoImmobilizzazioni_var 
									- (@B_VIII_CostiPersonale_var + @IX_CostiGestione_var + @X_AmmortamentiSvalutazioni_var + @B_XI_AccantonamentiRischiOneri_var + 
									@B_XII_OneriDversiGestione_var) + @C_ProventiOneri_var_orig + @D_Rettifiche_var_orig + @E_ProventiOneriStraordinari_var_orig
									- @F_Imposte_var_orig

declare @risultatoPareggio decimal(19,2)
set @risultatoPareggio = @risultatoEconomicoPresunto + @G_UtilizzoDiRiserve
declare @risultatoPareggio_var decimal(19,2)
set @risultatoPareggio_var = @risultatoEconomicoPresunto_var + @G_UtilizzoDiRiserve_var

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

SELECT
@ayear			as ayear,
@idupboriginal	as idupb,
@codeupb		as codeupb,
@title			as upb,
@treasurer		as department, 
isnull(@A_I1_ProventiPerLaDidattica,0)  				as 'A_I1_ProventiPerLaDidattica',  
isnull(@A_I1_ProventiPerLaDidattica_var,0)  			as 'A_I1_ProventiPerLaDidattica_var',  
isnull(@A_I2_ProventiDaRicercheCommissionate,0)  		as 'A_I2_ProventiDaRicercheCommissionate',  
isnull(@A_I2_ProventiDaRicercheCommissionate_var,0)  	as 'A_I2_ProventiDaRicercheCommissionate_var',  
isnull(@A_I3_ProventiDaRicercheConFinanziamento,0)  	as 'A_I3_ProventiDaRicercheConFinanziamento',  
isnull(@A_I3_ProventiDaRicercheConFinanziamento_var,0)	as 'A_I3_ProventiDaRicercheConFinanziamento_var',  
isnull(@A_I_ProventiPropri,0)							as 'A_I_ProventiPropri',
isnull(@A_I_ProventiPropri_var,0)						as 'A_I_ProventiPropri_var',
isnull(@A_II1_ContributiMIUR,0)  						as 'A_II1_ContributiMIUR',  
isnull(@A_II1_ContributiMIUR_var,0)  					as 'A_II1_ContributiMIUR_var',
isnull(@A_II2_ContributiRegioni,0)  					as 'A_II2_ContributiRegioni',  
isnull(@A_II2_ContributiRegioni_var,0)  				as 'A_II2_ContributiRegioni_var',  
isnull(@A_II3_ContributiAltreAmministrazioni,0)  		as 'A_II3_ContributiAltreAmministrazioni',  
isnull(@A_II3_ContributiAltreAmministrazioni_var,0)		as 'A_II3_ContributiAltreAmministrazioni_var', 
isnull(@A_II4_ContributiUE,0)  							as 'A_II4_ContributiUE',  
isnull(@A_II4_ContributiUE_var,0)  						as 'A_II4_ContributiUE_var',
isnull(@A_II5_ContributiUniversita,0)  					as 'A_II5_ContributiUniversita',  
isnull(@A_II5_ContributiUniversita_var,0)  				as 'A_II5_ContributiUniversita_var', 
isnull(@A_II6_ContributiAltriPubblici,0)  				as 'A_II6_ContributiAltriPubblici',  
isnull(@A_II6_ContributiAltriPubblici_var,0)  			as 'A_II6_ContributiAltriPubblici_var',  
isnull(@A_II7_ContributiAltriPrivati,0)  				as 'A_II7_ContributiAltriPrivati',  
isnull(@A_II7_ContributiAltriPrivati_var,0)  			as 'A_II7_ContributiAltriPrivati_var',    
isnull(@A_II_Contributi,0)								as 'A_II_Contributi',
isnull(@A_II_Contributi_var,0)							as 'A_II_Contributi_var',
isnull(@A_III_ProventiPerAttivitaAssistenziale,0)  		as 'A_III_ProventiPerAttivitaAssistenziale',  
isnull(@A_III_ProventiPerAttivitaAssistenziale_var,0)  	as 'A_III_ProventiPerAttivitaAssistenziale_var', 
isnull(@A_IV_ProventiPerGestioneDiretta,0)  			as 'A_IV_ProventiPerGestioneDiretta',  
isnull(@A_IV_ProventiPerGestioneDiretta_var,0)  		as 'A_IV_ProventiPerGestioneDiretta_var', 
isnull(@A_V1_UtilizzoRiservePatrimonioNetto,0)  		as 'A_V1_UtilizzoRiservePatrimonioNetto',  
isnull(@A_V1_UtilizzoRiservePatrimonioNetto_var,0)  	as 'A_V1_UtilizzoRiservePatrimonioNetto_var', 
isnull(@A_V2_AltriProventi,0)  							as 'A_V2_AltriProventi',  
isnull(@A_V2_AltriProventi_var,0)  						as 'A_V2_AltriProventi_var',  
isnull(@A_V_UtilizzoRiservePatrimonioNetto,0)			as 'A_V_UtilizzoRiservePatrimonioNetto',
isnull(@A_V_UtilizzoRiservePatrimonioNetto_var,0)		as 'A_V_UtilizzoRiservePatrimonioNetto_var',
isnull(@A_VI_VariazioniRimanenze,0)						as 'A_VI_VariazioniRimanenze',
isnull(@A_VI_VariazioniRimanenze_var,0)					as 'A_VI_VariazioniRimanenze_var',
isnull(@A_VII_IncrementoImmobilizzazioni,0)				as 'A_VII_IncrementoImmobilizzazioni',
isnull(@A_VII_IncrementoImmobilizzazioni_var,0)			as 'A_VII_IncrementoImmobilizzazioni_var',
isnull(@B_VIII1a_CostiDocentiRicercatori,0)  			as 'B_VIII1a_CostiDocentiRicercatori',  
isnull(@B_VIII1a_CostiDocentiRicercatori_var,0)  		as 'B_VIII1a_CostiDocentiRicercatori_var',  
isnull(@B_VIII1b_CollaborazioniScientifiche,0)  		as 'B_VIII1b_CollaborazioniScientifiche',  
isnull(@B_VIII1b_CollaborazioniScientifiche_var,0)		as 'B_VIII1b_CollaborazioniScientifiche_var',  
isnull(@B_VIII1c_DocentiAContratto,0)					as 'B_VIII1c_DocentiAContratto',  
isnull(@B_VIII1c_DocentiAContratto_var,0)  				as 'B_VIII1c_DocentiAContratto_var',  
isnull(@B_VIII1d_EspertiLinguistici,0)  				as 'B_VIII1d_EspertiLinguistici',  
isnull(@B_VIII1d_EspertiLinguistici_var,0)  			as 'B_VIII1d_EspertiLinguistici_var',  
isnull(@B_VIII1e_AltroPersonale,0)  					as 'B_VIII1e_AltroPersonale',  
isnull(@B_VIII1e_AltroPersonale_var,0)  				as 'B_VIII1e_AltroPersonale_var',
isnull(@B_VIII2_CostiPersonaleDirigente,0)   			as 'B_VIII2_CostiPersonaleDirigente',   
isnull(@B_VIII2_CostiPersonaleDirigente_var,0)   		as 'B_VIII2_CostiPersonaleDirigente_var',
isnull(@B_VIII_CostiPersonale,0)						as 'B_VIII_CostiPersonale',
isnull(@B_VIII_CostiPersonale_var,0)					as 'B_VIII_CostiPersonale_var',
isnull(@B_IX1_CostiSostegnoStudenti,0)  				as 'B_IX1_CostiSostegnoStudenti',  
isnull(@B_IX1_CostiSostegnoStudenti_var,0)  			as 'B_IX1_CostiSostegnoStudenti_var',  
isnull(@B_IX2_CostiDirittoStudio,0)  					as 'B_IX2_CostiDirittoStudio',  
isnull(@B_IX2_CostiDirittoStudio_var,0)  				as 'B_IX2_CostiDirittoStudio_var',  
isnull(@B_IX3_CostiRicercaAttivitaEditoriale,0)			as 'B_IX3_CostiRicercaAttivitaEditoriale',  
isnull(@B_IX3_CostiRicercaAttivitaEditoriale_var,0)		as 'B_IX3_CostiRicercaAttivitaEditoriale_var',   
isnull(@B_IX4_TrasferimentiPartner,0)					as 'B_IX4_TrasferimentiPartner',  
isnull(@B_IX4_TrasferimentiPartner_var,0)  				as 'B_IX4_TrasferimentiPartner_var',   
isnull(@B_IX5_AcquistoMaterialeConsumo,0)				as 'B_IX5_AcquistoMaterialeConsumo',  
isnull(@B_IX5_AcquistoMaterialeConsumo_var,0)  			as 'B_IX5_AcquistoMaterialeConsumo_var',  
isnull(@B_IX6_VariazioneRimanenze,0)					as 'B_IX6_VariazioneRimanenze',  
isnull(@B_IX6_VariazioneRimanenze_var,0)  				as 'B_IX6_VariazioneRimanenze_var',  
isnull(@B_IX7_AcquistoLibri,0)  						as 'B_IX7_AcquistoLibri',  
isnull(@B_IX7_AcquistoLibri_var,0)  					as 'B_IX7_AcquistoLibri_var',  
isnull(@B_IX8_AcquistoServizi,0)  						as 'B_IX8_AcquistoServizi',  
isnull(@B_IX8_AcquistoServizi_var,0)  					as 'B_IX8_AcquistoServizi_var',  
isnull(@B_IX9_AcquistoAltriMateriali,0)   				as 'B_IX9_AcquistoAltriMateriali',   
isnull(@B_IX9_AcquistoAltriMateriali_var,0)   			as 'B_IX9_AcquistoAltriMateriali_var',    
isnull(@B_IX10_VariazioneRimanenze,0)  					as 'B_IX10_VariazioneRimanenze',  
isnull(@B_IX10_VariazioneRimanenze_var,0)  				as 'B_IX10_VariazioneRimanenze_var',  
isnull(@B_IX11_CostiGodimento,0)						as 'B_IX11_CostiGodimento',  
isnull(@B_IX11_CostiGodimento_var,0)  					as 'B_IX11_CostiGodimento_var',  
isnull(@B_IX12_AltriCosti,0)							as 'B_IX12_AltriCosti',  
isnull(@B_IX12_AltriCosti_var,0)  						as 'B_IX12_AltriCosti_var',  
isnull(@IX_CostiGestione,0)								as 'IX_CostiGestione',
isnull(@IX_CostiGestione_var,0)							as 'IX_CostiGestione_var',
isnull(@B_X1_AmmortamentiImmobImmateriali,0)  			as 'B_X1_AmmortamentiImmobImmateriali',  
isnull(@B_X1_AmmortamentiImmobImmateriali_var,0)  		as 'B_X1_AmmortamentiImmobImmateriali_var',  
isnull(@B_X2_AmmortamentiImmobMateriali,0)  			as 'B_X2_AmmortamentiImmobMateriali',  
isnull(@B_X2_AmmortamentiImmobMateriali_var,0) 			as 'B_X2_AmmortamentiImmobMateriali_var',   
isnull(@B_X3_SvalutazioniImmobilizzazioni,0)  			as 'B_X3_SvalutazioniImmobilizzazioni',  
isnull(@B_X3_SvalutazioniImmobilizzazioni_var,0)  		as 'B_X3_SvalutazioniImmobilizzazioni_var',  
isnull(@B_X4_SvalutazioniCrediti,0)   					as 'B_X4_SvalutazioniCrediti',   
isnull(@B_X4_SvalutazioniCrediti_var,0)  				as 'B_X4_SvalutazioniCrediti_var',   
isnull(@X_AmmortamentiSvalutazioni,0)					as 'X_AmmortamentiSvalutazioni',
isnull(@X_AmmortamentiSvalutazioni_var,0)				as 'X_AmmortamentiSvalutazioni_var',
isnull(@B_XI_AccantonamentiRischiOneri,0)  				as 'B_XI_AccantonamentiRischiOneri',  
isnull(@B_XI_AccantonamentiRischiOneri_var,0)  			as 'B_XI_AccantonamentiRischiOneri_var',  
isnull(@B_XII_OneriDversiGestione,0)  					as 'B_XII_OneriDversiGestione',  
isnull(@B_XII_OneriDversiGestione_var,0)  				as 'B_XII_OneriDversiGestione_var',  
isnull(@C_1ProventiFinanziari,0)  						as 'C_1ProventiFinanziari',  
isnull(@C_1ProventiFinanziari_var,0)  					as 'C_1ProventiFinanziari_var',  
isnull(@C_2Interessi,0)  								as 'C_2Interessi',
isnull(@C_2Interessi_var,0)  							as 'C_2Interessi_var',
isnull(@C_3Utili,0)										as 'C_3Utili',  
isnull(@C_3Utili_var,0)  								as 'C_3Utili_var',  
isnull(@C_3Perdite,0) 									as 'C_3Perdite',  
isnull(@C_3Perdite_var,0) 								as 'C_3Perdite_var',  
isnull(@C_ProventiOneri,0)								as 'C_ProventiOneri',
isnull(@C_ProventiOneri_var,0)							as 'C_ProventiOneri_var',
isnull(@D_1Rivalutazioni,0)								as 'D_1Rivalutazioni',  
isnull(@D_1Rivalutazioni_var,0)  						as 'D_1Rivalutazioni_var',  
isnull(@D_2Svalutazioni,0)  							as 'D_2Svalutazioni',  
isnull(@D_2Svalutazioni_var,0)  						as 'D_2Svalutazioni_var',  
isnull(@D_Rettifiche,0)									as 'D_Rettifiche',
isnull(@D_Rettifiche_var,0)								as 'D_Rettifiche_var',
isnull(@E_1ProventiStraordinari,0)						as 'E_1ProventiStraordinari',  
isnull(@E_1ProventiStraordinari_var,0)					as 'E_1ProventiStraordinari_var',    
isnull(@E_2OneriStraordinari,0) 						as 'E_2OneriStraordinari',  
isnull(@E_2OneriStraordinari_var,0) 					as 'E_2OneriStraordinari_var',  
isnull(@E_ProventiOneriStraordinari,0)					as 'E_ProventiOneriStraordinari',
isnull(@E_ProventiOneriStraordinari_var,0)				as 'E_ProventiOneriStraordinari_var',
isnull(@F_Imposte,0)  									as 'F_Imposte',  
isnull(@F_Imposte_var,0)  								as 'F_Imposte_var',  
isnull(@G_UtilizzoDiRiserve,0)  						as 'G_UtilizzoDiRiserve',  
isnull(@G_UtilizzoDiRiserve_var,0)  					as 'G_UtilizzoDiRiserve_var', 				
isnull(@risultatoEconomicoPresunto,0)					as 'risultatoEconomicoPresunto',
isnull(@risultatoEconomicoPresunto_var, 0)				as 'risultatoEconomicoPresunto_var',
isnull(@risultatoPareggio,0)							as 'risultatoPareggio',
isnull(@risultatoPareggio_var, 0)						as 'risultatoPareggio_var'
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_budgeteconomicoufficiale_var 2021, {d '2021-11-11'}, 22,'%','S',null,null,null,null,null

