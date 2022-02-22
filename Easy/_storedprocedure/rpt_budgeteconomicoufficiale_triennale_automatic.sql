
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_triennale_automatic]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_triennale_automatic]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 -- setuser'amministrazione' 
-- exec rpt_budgeteconomicoufficiale_triennale_automatic 2018, '%','S'
-- A.	Budget Economico triennale che mostra la previsione iniziale 
-- Previsione iniziale = variazioni "integrazione previsione iniziale"

CREATE      PROCEDURE [rpt_budgeteconomicoufficiale_triennale_automatic](
	@ayear int,--> anno del bilancio di previsione
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@prevcorrente char(1)='N',
	@adate datetime, -- Data da usare perchè deve calcolare la previsione corrente se @prevcorrente = S
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

if (@prevcorrente ='S') 
	Begin
		exec rpt_budgeteconomicoufficiale_triennale_automatic_curr @ayear, @idupb,@showchildupb, @adate,@idsor01,@idsor02,@idsor03,	@idsor04,@idsor05
		RETURN
	End
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
declare @A_I1_ProventiPerLaDidattica_prev2 decimal(19,2)
declare @A_I1_ProventiPerLaDidattica_prev3 decimal(19,2)
SELECT	@A_I1_ProventiPerLaDidattica = SUM(D.amount*A.economicbudget_sign_value),
		@A_I1_ProventiPerLaDidattica_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_I1_ProventiPerLaDidattica_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U			ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1101%'

declare @A_I2_ProventiDaRicercheCommissionate decimal(19,2)
declare @A_I2_ProventiDaRicercheCommissionate_prev2 decimal(19,2)
declare @A_I2_ProventiDaRicercheCommissionate_prev3 decimal(19,2)
SELECT	@A_I2_ProventiDaRicercheCommissionate = SUM(D.amount*A.economicbudget_sign_value),
		@A_I2_ProventiDaRicercheCommissionate_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_I2_ProventiDaRicercheCommissionate_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U				ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1102%'

declare @A_I3_ProventiDaRicercheConFinanziamento decimal(19,2)
declare @A_I3_ProventiDaRicercheConFinanziamento_prev2 decimal(19,2)
declare @A_I3_ProventiDaRicercheConFinanziamento_prev3 decimal(19,2)
SELECT  @A_I3_ProventiDaRicercheConFinanziamento =  SUM(D.amount*A.economicbudget_sign_value),
		@A_I3_ProventiDaRicercheConFinanziamento_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@A_I3_ProventiDaRicercheConFinanziamento_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 		
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1103%'

declare @A_I_ProventiPropri decimal(19,2)
set @A_I_ProventiPropri = isnull(@A_I1_ProventiPerLaDidattica,0) + isnull(@A_I2_ProventiDaRicercheCommissionate,0) + isnull(@A_I3_ProventiDaRicercheConFinanziamento,0)

declare @A_I_ProventiPropri_prev2 decimal(19,2)
set @A_I_ProventiPropri_prev2 = isnull(@A_I1_ProventiPerLaDidattica_prev2,0) + isnull(@A_I2_ProventiDaRicercheCommissionate_prev2,0) + isnull(@A_I3_ProventiDaRicercheConFinanziamento_prev2,0)

declare @A_I_ProventiPropri_prev3 decimal(19,2)
set @A_I_ProventiPropri_prev3 = isnull(@A_I1_ProventiPerLaDidattica_prev3,0) + isnull(@A_I2_ProventiDaRicercheCommissionate_prev3,0) + isnull(@A_I3_ProventiDaRicercheConFinanziamento_prev3,0)


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
declare @A_II1_ContributiMIUR_prev2 decimal(19,2)
declare @A_II1_ContributiMIUR_prev3 decimal(19,2)
SELECT  @A_II1_ContributiMIUR = SUM(D.amount*A.economicbudget_sign_value),
		@A_II1_ContributiMIUR_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_II1_ContributiMIUR_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1201%'

declare @A_II2_ContributiRegioni decimal(19,2)
declare @A_II2_ContributiRegioni_prev2 decimal(19,2)
declare @A_II2_ContributiRegioni_prev3 decimal(19,2)
SELECT @A_II2_ContributiRegioni = SUM(D.amount*A.economicbudget_sign_value),
		@A_II2_ContributiRegioni_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_II2_ContributiRegioni_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1202%'

declare @A_II3_ContributiAltreAmministrazioni decimal(19,2)
declare @A_II3_ContributiAltreAmministrazioni_prev2 decimal(19,2)
declare @A_II3_ContributiAltreAmministrazioni_prev3 decimal(19,2)
SELECT	@A_II3_ContributiAltreAmministrazioni = SUM(D.amount*A.economicbudget_sign_value),
		@A_II3_ContributiAltreAmministrazioni_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_II3_ContributiAltreAmministrazioni_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1203%'

declare @A_II4_ContributiUE decimal(19,2)
declare @A_II4_ContributiUE_prev2 decimal(19,2)
declare @A_II4_ContributiUE_prev3 decimal(19,2)
SELECT  @A_II4_ContributiUE =  SUM(D.amount*A.economicbudget_sign_value),
		@A_II4_ContributiUE_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@A_II4_ContributiUE_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U				ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1204%'

declare @A_II5_ContributiUniversita decimal(19,2)
declare @A_II5_ContributiUniversita_prev2 decimal(19,2)
declare @A_II5_ContributiUniversita_prev3 decimal(19,2)
SELECT @A_II5_ContributiUniversita =  SUM(D.amount*A.economicbudget_sign_value),
		@A_II5_ContributiUniversita_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@A_II5_ContributiUniversita_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1205%'

declare @A_II6_ContributiAltriPubblici decimal(19,2)
declare @A_II6_ContributiAltriPubblici_prev2 decimal(19,2)
declare @A_II6_ContributiAltriPubblici_prev3 decimal(19,2)
SELECT  @A_II6_ContributiAltriPubblici =  SUM(D.amount*A.economicbudget_sign_value),
		@A_II6_ContributiAltriPubblici_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@A_II6_ContributiAltriPubblici_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1206%'

declare @A_II7_ContributiAltriPrivati decimal(19,2)
declare @A_II7_ContributiAltriPrivati_prev2 decimal(19,2)
declare @A_II7_ContributiAltriPrivati_prev3 decimal(19,2)
SELECT	@A_II7_ContributiAltriPrivati = SUM(D.amount*A.economicbudget_sign_value),
		@A_II7_ContributiAltriPrivati_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_II7_ContributiAltriPrivati_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1207%'

declare @A_II_Contributi decimal(19,2)
set @A_II_Contributi = isnull(@A_II1_ContributiMIUR,0) + isnull(@A_II2_ContributiRegioni,0) + isnull(@A_II3_ContributiAltreAmministrazioni,0) 
					+ isnull(@A_II4_ContributiUE,0) + isnull(@A_II5_ContributiUniversita,0) + isnull(@A_II6_ContributiAltriPubblici,0) + isnull(@A_II7_ContributiAltriPrivati,0)

declare @A_II_Contributi_prev2 decimal(19,2)
set @A_II_Contributi_prev2 = isnull(@A_II1_ContributiMIUR_prev2,0) + isnull(@A_II2_ContributiRegioni_prev2,0) + isnull(@A_II3_ContributiAltreAmministrazioni_prev2,0) 
					+ isnull(@A_II4_ContributiUE_prev2,0) + isnull(@A_II5_ContributiUniversita_prev2,0) + isnull(@A_II6_ContributiAltriPubblici_prev2,0) + isnull(@A_II7_ContributiAltriPrivati_prev2,0)

declare @A_II_Contributi_prev3 decimal(19,2)
set @A_II_Contributi_prev3 = isnull(@A_II1_ContributiMIUR_prev3,0) + isnull(@A_II2_ContributiRegioni_prev3,0) + isnull(@A_II3_ContributiAltreAmministrazioni_prev3,0) 
					+ isnull(@A_II4_ContributiUE_prev3,0) + isnull(@A_II5_ContributiUniversita_prev3,0) + isnull(@A_II6_ContributiAltriPubblici_prev3,0) + isnull(@A_II7_ContributiAltriPrivati_prev3,0)


declare @A_III_ProventiPerAttivitaAssistenziale decimal(19,2)
declare @A_III_ProventiPerAttivitaAssistenziale_prev2 decimal(19,2)
declare @A_III_ProventiPerAttivitaAssistenziale_prev3 decimal(19,2)
SELECT @A_III_ProventiPerAttivitaAssistenziale = SUM(D.amount*A.economicbudget_sign_value),
		@A_III_ProventiPerAttivitaAssistenziale_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_III_ProventiPerAttivitaAssistenziale_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U				ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1301%'

-- IV. PROVENTI PER GESTIONE DIRETTA INTERVENTI PER IL DIRITTO ALLO STUDIO
declare @A_IV_ProventiPerGestioneDiretta decimal(19,2)
declare @A_IV_ProventiPerGestioneDiretta_prev2 decimal(19,2)
declare @A_IV_ProventiPerGestioneDiretta_prev3 decimal(19,2)
SELECT @A_IV_ProventiPerGestioneDiretta = SUM(D.amount*A.economicbudget_sign_value),
		@A_IV_ProventiPerGestioneDiretta_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_IV_ProventiPerGestioneDiretta_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1401%'

-- V.ALTRI PROVENTI E RICAVI DIVERSI
-- 1) Utilizzo di riserve di Patrimonio netto derivanti dalla contabilità finanziaria
-- 2) Altri Proventi e Ricavi Diversi
declare @A_V1_UtilizzoRiservePatrimonioNetto decimal(19,2)
declare @A_V1_UtilizzoRiservePatrimonioNetto_prev2 decimal(19,2)
declare @A_V1_UtilizzoRiservePatrimonioNetto_prev3 decimal(19,2)
SELECT @A_V1_UtilizzoRiservePatrimonioNetto = SUM(D.amount*A.economicbudget_sign_value),
		@A_V1_UtilizzoRiservePatrimonioNetto_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_V1_UtilizzoRiservePatrimonioNetto_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U						ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1501%'
		
declare @A_V2_AltriProventi decimal(19,2)
declare @A_V2_AltriProventi_prev2 decimal(19,2)
declare @A_V2_AltriProventi_prev3 decimal(19,2)
SELECT @A_V2_AltriProventi = SUM(D.amount*A.economicbudget_sign_value),
		@A_V2_AltriProventi_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_V2_AltriProventi_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U						ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1502%'
		
declare @A_V_UtilizzoRiservePatrimonioNetto decimal(19,2)
declare @A_V_UtilizzoRiservePatrimonioNetto_prev2 decimal(19,2)
declare @A_V_UtilizzoRiservePatrimonioNetto_prev3 decimal(19,2)
set @A_V_UtilizzoRiservePatrimonioNetto = isnull(@A_V1_UtilizzoRiservePatrimonioNetto,0) + isnull(@A_V2_AltriProventi,0)
set @A_V_UtilizzoRiservePatrimonioNetto_prev2 = isnull(@A_V1_UtilizzoRiservePatrimonioNetto_prev2,0) + isnull(@A_V2_AltriProventi_prev2,0)
set @A_V_UtilizzoRiservePatrimonioNetto_prev3 = isnull(@A_V1_UtilizzoRiservePatrimonioNetto_prev3,0) + isnull(@A_V2_AltriProventi_prev3,0)

-- Variazione Rimanenze
declare @A_VI_VariazioniRimanenze decimal(19,2)
declare @A_VI_VariazioniRimanenze_prev2 decimal(19,2)
declare @A_VI_VariazioniRimanenze_prev3 decimal(19,2)
SELECT @A_VI_VariazioniRimanenze = SUM(D.amount*A.economicbudget_sign_value),
		@A_VI_VariazioniRimanenze_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_VI_VariazioniRimanenze_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U						ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1601%'
		
-- Incremento delle Immobilizzazioni per Lavori Interni
declare @A_VII_IncrementoImmobilizzazioni decimal(19,2)
declare @A_VII_IncrementoImmobilizzazioni_prev2 decimal(19,2)
declare @A_VII_IncrementoImmobilizzazioni_prev3 decimal(19,2)
SELECT @A_VII_IncrementoImmobilizzazioni = SUM(D.amount*A.economicbudget_sign_value),
		@A_VII_IncrementoImmobilizzazioni_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@A_VII_IncrementoImmobilizzazioni_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U					ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EA1701%'
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
declare @B_VIII1a_CostiDocentiRicercatori_prev2 decimal(19,2)
declare @B_VIII1a_CostiDocentiRicercatori_prev3 decimal(19,2)
SELECT @B_VIII1a_CostiDocentiRicercatori = SUM(D.amount*A.economicbudget_sign_value),
		@B_VIII1a_CostiDocentiRicercatori_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_VIII1a_CostiDocentiRicercatori_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB1101%'

declare @B_VIII1b_CollaborazioniScientifiche decimal(19,2)
declare @B_VIII1b_CollaborazioniScientifiche_prev2 decimal(19,2)
declare @B_VIII1b_CollaborazioniScientifiche_prev3 decimal(19,2)
SELECT	@B_VIII1b_CollaborazioniScientifiche = SUM(D.amount*A.economicbudget_sign_value),
		@B_VIII1b_CollaborazioniScientifiche_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_VIII1b_CollaborazioniScientifiche_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB1102%'

declare @B_VIII1c_DocentiAContratto  decimal(19,2)
declare @B_VIII1c_DocentiAContratto_prev2  decimal(19,2)
declare @B_VIII1c_DocentiAContratto_prev3  decimal(19,2)
SELECT	@B_VIII1c_DocentiAContratto = SUM(D.amount*A.economicbudget_sign_value),
		@B_VIII1c_DocentiAContratto_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_VIII1c_DocentiAContratto_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB1103%'

declare @B_VIII1d_EspertiLinguistici decimal(19,2)
declare @B_VIII1d_EspertiLinguistici_prev2 decimal(19,2)
declare @B_VIII1d_EspertiLinguistici_prev3 decimal(19,2)
SELECT @B_VIII1d_EspertiLinguistici = SUM(D.amount*A.economicbudget_sign_value),
		@B_VIII1d_EspertiLinguistici_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_VIII1d_EspertiLinguistici_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB1104%'

declare @B_VIII1e_AltroPersonale decimal(19,2)
declare @B_VIII1e_AltroPersonale_prev2 decimal(19,2)
declare @B_VIII1e_AltroPersonale_prev3 decimal(19,2)
SELECT	@B_VIII1e_AltroPersonale =  SUM(D.amount*A.economicbudget_sign_value),
		@B_VIII1e_AltroPersonale_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@B_VIII1e_AltroPersonale_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB1105%'

declare @B_VIII2_CostiPersonaleDirigente decimal(19,2)
declare @B_VIII2_CostiPersonaleDirigente_prev2 decimal(19,2)
declare @B_VIII2_CostiPersonaleDirigente_prev3 decimal(19,2)
SELECT  @B_VIII2_CostiPersonaleDirigente = SUM(D.amount*A.economicbudget_sign_value),
		@B_VIII2_CostiPersonaleDirigente_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_VIII2_CostiPersonaleDirigente_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	join accountsortingbudgetview A
		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB1201%'

declare @B_VIII_CostiPersonale decimal(19,2)
set @B_VIII_CostiPersonale = isnull(@B_VIII1a_CostiDocentiRicercatori,0) + isnull(@B_VIII1b_CollaborazioniScientifiche,0) + isnull(@B_VIII1c_DocentiAContratto,0) 
						+ isnull(@B_VIII1d_EspertiLinguistici,0) + isnull(@B_VIII1e_AltroPersonale,0) + isnull(@B_VIII2_CostiPersonaleDirigente,0)

declare @B_VIII_CostiPersonale_prev2 decimal(19,2)
set @B_VIII_CostiPersonale_prev2 = isnull(@B_VIII1a_CostiDocentiRicercatori_prev2,0) + isnull(@B_VIII1b_CollaborazioniScientifiche_prev2,0) + isnull(@B_VIII1c_DocentiAContratto_prev2,0) 
						+ isnull(@B_VIII1d_EspertiLinguistici_prev2,0) + isnull(@B_VIII1e_AltroPersonale_prev2,0) + isnull(@B_VIII2_CostiPersonaleDirigente_prev2,0)

declare @B_VIII_CostiPersonale_prev3 decimal(19,2)
set @B_VIII_CostiPersonale_prev3 = isnull(@B_VIII1a_CostiDocentiRicercatori_prev3,0) + isnull(@B_VIII1b_CollaborazioniScientifiche_prev3,0) + isnull(@B_VIII1c_DocentiAContratto_prev3,0) 
						+ isnull(@B_VIII1d_EspertiLinguistici_prev3,0) + isnull(@B_VIII1e_AltroPersonale_prev3,0) + isnull(@B_VIII2_CostiPersonaleDirigente_prev3,0)

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
declare @B_IX1_CostiSostegnoStudenti_prev2 decimal(19,2)
declare @B_IX1_CostiSostegnoStudenti_prev3 decimal(19,2)
SELECT	@B_IX1_CostiSostegnoStudenti = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX1_CostiSostegnoStudenti_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX1_CostiSostegnoStudenti_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2101%'

declare @B_IX2_CostiDirittoStudio decimal(19,2)
declare @B_IX2_CostiDirittoStudio_prev2 decimal(19,2)
declare @B_IX2_CostiDirittoStudio_prev3 decimal(19,2)
SELECT  @B_IX2_CostiDirittoStudio = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX2_CostiDirittoStudio_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX2_CostiDirittoStudio_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2102%'

declare @B_IX3_CostiRicercaAttivitaEditoriale decimal(19,2)
declare @B_IX3_CostiRicercaAttivitaEditoriale_prev2 decimal(19,2)
declare @B_IX3_CostiRicercaAttivitaEditoriale_prev3 decimal(19,2)
SELECT @B_IX3_CostiRicercaAttivitaEditoriale =  SUM(D.amount*A.economicbudget_sign_value),
		@B_IX3_CostiRicercaAttivitaEditoriale_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX3_CostiRicercaAttivitaEditoriale_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2103%'
		
declare @B_IX4_TrasferimentiPartner decimal(19,2)
declare @B_IX4_TrasferimentiPartner_prev2 decimal(19,2)
declare @B_IX4_TrasferimentiPartner_prev3 decimal(19,2)
SELECT	@B_IX4_TrasferimentiPartner = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX4_TrasferimentiPartner_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX4_TrasferimentiPartner_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2104%'

declare @B_IX5_AcquistoMaterialeConsumo  decimal(19,2)
declare @B_IX5_AcquistoMaterialeConsumo_prev2  decimal(19,2)
declare @B_IX5_AcquistoMaterialeConsumo_prev3  decimal(19,2)
SELECT  @B_IX5_AcquistoMaterialeConsumo = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX5_AcquistoMaterialeConsumo_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX5_AcquistoMaterialeConsumo_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb	
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2105%'

declare @B_IX6_VariazioneRimanenze decimal(19,2)
declare @B_IX6_VariazioneRimanenze_prev2 decimal(19,2)
declare @B_IX6_VariazioneRimanenze_prev3 decimal(19,2)
SELECT  @B_IX6_VariazioneRimanenze = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX6_VariazioneRimanenze_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX6_VariazioneRimanenze_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2106%'

declare @B_IX7_AcquistoLibri decimal(19,2)
declare @B_IX7_AcquistoLibri_prev2 decimal(19,2)
declare @B_IX7_AcquistoLibri_prev3 decimal(19,2)
SELECT  @B_IX7_AcquistoLibri =  SUM(D.amount*A.economicbudget_sign_value),
		@B_IX7_AcquistoLibri_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX7_AcquistoLibri_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2107%'

declare @B_IX8_AcquistoServizi decimal(19,2)
declare @B_IX8_AcquistoServizi_prev2 decimal(19,2)
declare @B_IX8_AcquistoServizi_prev3 decimal(19,2)
SELECT  @B_IX8_AcquistoServizi = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX8_AcquistoServizi_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX8_AcquistoServizi_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2108%'

declare @B_IX9_AcquistoAltriMateriali decimal(19,2)
declare @B_IX9_AcquistoAltriMateriali_prev2 decimal(19,2)
declare @B_IX9_AcquistoAltriMateriali_prev3 decimal(19,2)
SELECT  @B_IX9_AcquistoAltriMateriali = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX9_AcquistoAltriMateriali_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX9_AcquistoAltriMateriali_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2109%'

declare @B_IX10_VariazioneRimanenze decimal(19,2)
declare @B_IX10_VariazioneRimanenze_prev2 decimal(19,2)
declare @B_IX10_VariazioneRimanenze_prev3 decimal(19,2)
SELECT  @B_IX10_VariazioneRimanenze = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX10_VariazioneRimanenze_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX10_VariazioneRimanenze_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2110%'

declare @B_IX11_CostiGodimento decimal(19,2)
declare @B_IX11_CostiGodimento_prev2 decimal(19,2)
declare @B_IX11_CostiGodimento_prev3 decimal(19,2)
SELECT  @B_IX11_CostiGodimento = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX11_CostiGodimento_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX11_CostiGodimento_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2111%'

declare @B_IX12_AltriCosti  decimal(19,2)
declare @B_IX12_AltriCosti_prev2  decimal(19,2)
declare @B_IX12_AltriCosti_prev3  decimal(19,2)
SELECT  @B_IX12_AltriCosti = SUM(D.amount*A.economicbudget_sign_value),
		@B_IX12_AltriCosti_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_IX12_AltriCosti_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB2112%'

declare @IX_CostiGestione decimal(19,2)
set @IX_CostiGestione = isnull(@B_IX1_CostiSostegnoStudenti,0) + isnull(@B_IX2_CostiDirittoStudio,0) + isnull(@B_IX3_CostiRicercaAttivitaEditoriale,0) 
						+ isnull(@B_IX4_TrasferimentiPartner,0) + isnull(@B_IX5_AcquistoMaterialeConsumo,0) + isnull(@B_IX6_VariazioneRimanenze,0) 
						+ isnull(@B_IX7_AcquistoLibri,0) + isnull(@B_IX8_AcquistoServizi,0) + isnull(@B_IX9_AcquistoAltriMateriali,0) + isnull(@B_IX10_VariazioneRimanenze,0) 
						+ isnull(@B_IX11_CostiGodimento,0) + isnull(@B_IX12_AltriCosti,0)

declare @IX_CostiGestione_prev2 decimal(19,2)
set @IX_CostiGestione_prev2 = isnull(@B_IX1_CostiSostegnoStudenti_prev2,0) + isnull(@B_IX2_CostiDirittoStudio_prev2,0) + isnull(@B_IX3_CostiRicercaAttivitaEditoriale_prev2,0) 
						+ isnull(@B_IX4_TrasferimentiPartner_prev2,0) + isnull(@B_IX5_AcquistoMaterialeConsumo_prev2,0) + isnull(@B_IX6_VariazioneRimanenze_prev2,0) 
						+ isnull(@B_IX7_AcquistoLibri_prev2,0) + isnull(@B_IX8_AcquistoServizi_prev2,0) + isnull(@B_IX9_AcquistoAltriMateriali_prev2,0) + isnull(@B_IX10_VariazioneRimanenze_prev2,0) 
						+ isnull(@B_IX11_CostiGodimento_prev2,0) + isnull(@B_IX12_AltriCosti_prev2,0)

declare @IX_CostiGestione_prev3 decimal(19,2)
set @IX_CostiGestione_prev3 = isnull(@B_IX1_CostiSostegnoStudenti_prev3,0) + isnull(@B_IX2_CostiDirittoStudio_prev3,0) + isnull(@B_IX3_CostiRicercaAttivitaEditoriale_prev3,0) 
						+ isnull(@B_IX4_TrasferimentiPartner_prev3,0) + isnull(@B_IX5_AcquistoMaterialeConsumo_prev3,0) + isnull(@B_IX6_VariazioneRimanenze_prev3,0) 
						+ isnull(@B_IX7_AcquistoLibri_prev3,0) + isnull(@B_IX8_AcquistoServizi_prev3,0) + isnull(@B_IX9_AcquistoAltriMateriali_prev3,0) + isnull(@B_IX10_VariazioneRimanenze_prev3,0) 
						+ isnull(@B_IX11_CostiGodimento_prev3,0) + isnull(@B_IX12_AltriCosti_prev3,0)

/*	
	X.AMMORTAMENTI E SVALUTAZIONI
		1) Ammortamenti immobilizzazioni immateriali
		2) Ammortamenti immobilizzazioni materiali
		3) Svalutazioni immobilizzazioni
		4) Svalutazioni dei crediti compresi nell'attivo circolante e nelle disponibilità liquide
*/
declare @B_X1_AmmortamentiImmobImmateriali decimal(19,2)
declare @B_X1_AmmortamentiImmobImmateriali_prev2 decimal(19,2)
declare @B_X1_AmmortamentiImmobImmateriali_prev3 decimal(19,2)
SELECT @B_X1_AmmortamentiImmobImmateriali =  SUM(D.amount*A.economicbudget_sign_value),
		@B_X1_AmmortamentiImmobImmateriali_prev2 =  SUM(D.amount2*A.economicbudget_sign_value),
		@B_X1_AmmortamentiImmobImmateriali_prev3 =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB3101%'

declare @B_X2_AmmortamentiImmobMateriali decimal(19,2)
declare @B_X2_AmmortamentiImmobMateriali_prev2 decimal(19,2)
declare @B_X2_AmmortamentiImmobMateriali_prev3 decimal(19,2)
SELECT @B_X2_AmmortamentiImmobMateriali = SUM(D.amount*A.economicbudget_sign_value),
		@B_X2_AmmortamentiImmobMateriali_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_X2_AmmortamentiImmobMateriali_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB3102%'

declare @B_X3_SvalutazioniImmobilizzazioni decimal(19,2)
declare @B_X3_SvalutazioniImmobilizzazioni_prev2 decimal(19,2)
declare @B_X3_SvalutazioniImmobilizzazioni_prev3 decimal(19,2)
SELECT  @B_X3_SvalutazioniImmobilizzazioni = SUM(D.amount*A.economicbudget_sign_value),
		@B_X3_SvalutazioniImmobilizzazioni_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_X3_SvalutazioniImmobilizzazioni_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB3103%'

declare @B_X4_SvalutazioniCrediti decimal(19,2)
declare @B_X4_SvalutazioniCrediti_prev2 decimal(19,2)
declare @B_X4_SvalutazioniCrediti_prev3 decimal(19,2)
SELECT  @B_X4_SvalutazioniCrediti = SUM(D.amount*A.economicbudget_sign_value),
		@B_X4_SvalutazioniCrediti_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_X4_SvalutazioniCrediti_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB3104%'

declare @X_AmmortamentiSvalutazioni decimal(19,2)
set @X_AmmortamentiSvalutazioni = isnull(@B_X1_AmmortamentiImmobImmateriali,0) + isnull(@B_X2_AmmortamentiImmobMateriali,0) + isnull(@B_X3_SvalutazioniImmobilizzazioni,0) + isnull(@B_X4_SvalutazioniCrediti,0) 

declare @X_AmmortamentiSvalutazioni_prev2 decimal(19,2)
set @X_AmmortamentiSvalutazioni_prev2=isnull(@B_X1_AmmortamentiImmobImmateriali_prev2,0) + isnull(@B_X2_AmmortamentiImmobMateriali_prev2,0) + isnull(@B_X3_SvalutazioniImmobilizzazioni_prev2,0) + isnull(@B_X4_SvalutazioniCrediti_prev2,0) 

declare @X_AmmortamentiSvalutazioni_prev3 decimal(19,2)
set @X_AmmortamentiSvalutazioni_prev3=isnull(@B_X1_AmmortamentiImmobImmateriali_prev3,0) + isnull(@B_X2_AmmortamentiImmobMateriali_prev3,0) + isnull(@B_X3_SvalutazioniImmobilizzazioni_prev3,0) + isnull(@B_X4_SvalutazioniCrediti_prev3,0) 

declare @B_XI_AccantonamentiRischiOneri decimal(19,2)
declare @B_XI_AccantonamentiRischiOneri_prev2 decimal(19,2)
declare @B_XI_AccantonamentiRischiOneri_prev3 decimal(19,2)
SELECT @B_XI_AccantonamentiRischiOneri = SUM(D.amount*A.economicbudget_sign_value),
		@B_XI_AccantonamentiRischiOneri_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_XI_AccantonamentiRischiOneri_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB4101%'

declare @B_XII_OneriDversiGestione decimal(19,2)
declare @B_XII_OneriDversiGestione_prev2 decimal(19,2)
declare @B_XII_OneriDversiGestione_prev3 decimal(19,2)
SELECT  @B_XII_OneriDversiGestione = SUM(D.amount*A.economicbudget_sign_value),
		@B_XII_OneriDversiGestione_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@B_XII_OneriDversiGestione_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EB5101%'
/*
	C) PROVENTI ED ONERI FINANZIARI
	1) Proventi finanziari
	2) Interessi ed altri oneri finanziari 
	3) Utili su cambi 
	4) Perdite su cambi 
*/
declare @C_1ProventiFinanziari decimal(19,2)
declare @C_1ProventiFinanziari_prev2 decimal(19,2)
declare @C_1ProventiFinanziari_prev3 decimal(19,2)
SELECT  @C_1ProventiFinanziari = SUM(D.amount*A.economicbudget_sign_value),
		@C_1ProventiFinanziari_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@C_1ProventiFinanziari_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EC1101%'

declare @C_2Interessi_orig decimal(19,2)
declare @C_2Interessi_prev2_orig decimal(19,2)
declare @C_2Interessi_prev3_orig decimal(19,2)

declare @C_2Interessi decimal(19,2)
declare @C_2Interessi_prev2 decimal(19,2)
declare @C_2Interessi_prev3 decimal(19,2)
SELECT  @C_2Interessi_orig =   SUM(D.amount*A.economicbudget_sign_value),
		@C_2Interessi_prev2_orig =   SUM(D.amount2*A.economicbudget_sign_value),
		@C_2Interessi_prev3_orig =   SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EC1102%'

if (@C_2Interessi_orig < 0) set @C_2Interessi = -@C_2Interessi_orig else set @C_2Interessi = @C_2Interessi_orig
if (@C_2Interessi_prev2_orig < 0) set @C_2Interessi_prev2 = -@C_2Interessi_prev2_orig else set @C_2Interessi_prev2 = @C_2Interessi_prev2_orig
if (@C_2Interessi_prev3_orig < 0) set @C_2Interessi_prev3 = -@C_2Interessi_prev3_orig else set @C_2Interessi_prev3 = @C_2Interessi_prev3_orig

declare @C_3Utili decimal(19,2)
declare @C_3Utili_prev2 decimal(19,2)
declare @C_3Utili_prev3 decimal(19,2)
SELECT  @C_3Utili = SUM(D.amount*A.economicbudget_sign_value),
		@C_3Utili_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@C_3Utili_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EC1103%'

declare @C_3Perdite decimal(19,2)
declare @C_3Perdite_prev2 decimal(19,2)
declare @C_3Perdite_prev3 decimal(19,2)
SELECT  @C_3Perdite = - SUM(D.amount*A.economicbudget_sign_value),
		@C_3Perdite_prev2 = - SUM(D.amount2*A.economicbudget_sign_value),
		@C_3Perdite_prev3 = - SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EC1104%'


declare @C_ProventiOneri_orig decimal(19,2)
declare @C_ProventiOneri decimal(19,2)
SET @C_ProventiOneri_orig = 	isnull(@C_1ProventiFinanziari,0) - isnull(@C_2Interessi,0) + isnull(@C_3Utili,0) + isnull(@C_3Perdite,0)

declare @C_ProventiOneri_prev2_orig decimal(19,2)
declare @C_ProventiOneri_prev2 decimal(19,2)
SET @C_ProventiOneri_prev2_orig = isnull(@C_1ProventiFinanziari_prev2,0) - isnull(@C_2Interessi_prev2,0) + isnull(@C_3Utili_prev2,0) + isnull(@C_3Perdite_prev2,0)

declare @C_ProventiOneri_prev3_orig decimal(19,2)
declare @C_ProventiOneri_prev3 decimal(19,2)
SET @C_ProventiOneri_prev3_orig = isnull(@C_1ProventiFinanziari_prev3,0) - isnull(@C_2Interessi_prev3,0) + isnull(@C_3Utili_prev3,0) + isnull(@C_3Perdite_prev3,0)

if (@C_ProventiOneri_orig < 0) set @C_ProventiOneri = -@C_ProventiOneri_orig else set @C_ProventiOneri = @C_ProventiOneri_orig
if (@C_ProventiOneri_prev2_orig < 0) set @C_ProventiOneri_prev2 = -@C_ProventiOneri_prev2_orig else set @C_ProventiOneri_prev2 = @C_ProventiOneri_prev2_orig
if (@C_ProventiOneri_prev3_orig < 0) set @C_ProventiOneri_prev3 = -@C_ProventiOneri_prev3_orig else set @C_ProventiOneri_prev3 = @C_ProventiOneri_prev3_orig

/*
	D) RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
		1) Rivalutazioni di attività finanziarie
		2) Svalutazioni di attività finanziarie
*/
declare @D_1Rivalutazioni decimal(19,2)
declare @D_1Rivalutazioni_prev2 decimal(19,2)
declare @D_1Rivalutazioni_prev3 decimal(19,2)
SELECT @D_1Rivalutazioni = SUM(D.amount*A.economicbudget_sign_value),
	@D_1Rivalutazioni_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
	@D_1Rivalutazioni_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'ED1101%'

declare @D_2Svalutazioni_orig decimal(19,2)
declare @D_2Svalutazioni_prev2_orig decimal(19,2)
declare @D_2Svalutazioni_prev3_orig decimal(19,2)


declare @D_2Svalutazioni decimal(19,2)
declare @D_2Svalutazioni_prev2 decimal(19,2)
declare @D_2Svalutazioni_prev3 decimal(19,2)
SELECT  @D_2Svalutazioni_orig =  - SUM(D.amount*A.economicbudget_sign_value),
		@D_2Svalutazioni_prev2_orig =  - SUM(D.amount2*A.economicbudget_sign_value),
		@D_2Svalutazioni_prev3_orig =  - SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'ED1102%'


if (@D_2Svalutazioni_orig < 0) set @D_2Svalutazioni = -@D_2Svalutazioni_orig else set @D_2Svalutazioni = @D_2Svalutazioni_orig
if (@D_2Svalutazioni_prev2_orig < 0) set @D_2Svalutazioni_prev2 = -@D_2Svalutazioni_prev2_orig else set @D_2Svalutazioni_prev2 = @D_2Svalutazioni_prev2_orig
if (@D_2Svalutazioni_prev3_orig < 0) set @D_2Svalutazioni_prev3 = -@D_2Svalutazioni_prev3_orig else set @D_2Svalutazioni_prev3 = @D_2Svalutazioni_prev3_orig

declare @D_Rettifiche_orig decimal(19,2)
declare @D_Rettifiche decimal(19,2)
set @D_Rettifiche_orig = isnull(@D_1Rivalutazioni,0) - isnull(@D_2Svalutazioni,0)

declare @D_Rettifiche_prev2_orig decimal(19,2)
declare @D_Rettifiche_prev2 decimal(19,2)
set @D_Rettifiche_prev2_orig = isnull(@D_1Rivalutazioni_prev2,0) - isnull(@D_2Svalutazioni_prev2,0)

declare @D_Rettifiche_prev3_orig decimal(19,2)
declare @D_Rettifiche_prev3 decimal(19,2)
set @D_Rettifiche_prev3_orig = isnull(@D_1Rivalutazioni_prev3,0) - isnull(@D_2Svalutazioni_prev3,0)

if (@D_Rettifiche_orig < 0) set @D_Rettifiche = -@D_Rettifiche_orig else set @D_Rettifiche = @D_Rettifiche_orig
if (@D_Rettifiche_prev2_orig < 0) set @D_Rettifiche_prev2 = -@D_Rettifiche_prev2_orig else set @D_Rettifiche_prev2 = @D_Rettifiche_prev2_orig
if (@D_Rettifiche_prev3_orig < 0) set @D_Rettifiche_prev3 = -@D_Rettifiche_prev3_orig else set @D_Rettifiche_prev3 = @D_Rettifiche_prev3_orig


/*
	E)	PROVENTI ED ONERI STRAORDINARI
		1) Proventi straordinari
		2) Oneri straordinari
*/
			
declare @E_1ProventiStraordinari  decimal(19,2)
declare @E_1ProventiStraordinari_prev2  decimal(19,2)
declare @E_1ProventiStraordinari_prev3  decimal(19,2)
SELECT @E_1ProventiStraordinari = SUM(D.amount*A.economicbudget_sign_value),
		@E_1ProventiStraordinari_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@E_1ProventiStraordinari_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EE1101%'

declare @E_2OneriStraordinari_orig  decimal(19,2)
declare @E_2OneriStraordinari_prev2_orig  decimal(19,2)
declare @E_2OneriStraordinari_prev3_orig  decimal(19,2)

declare @E_2OneriStraordinari  decimal(19,2)
declare @E_2OneriStraordinari_prev2  decimal(19,2)
declare @E_2OneriStraordinari_prev3  decimal(19,2)
SELECT @E_2OneriStraordinari_orig =  SUM(D.amount*A.economicbudget_sign_value),
		@E_2OneriStraordinari_prev2_orig =  SUM(D.amount2*A.economicbudget_sign_value),
		@E_2OneriStraordinari_prev3_orig =  SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EE1102%'

if (@E_2OneriStraordinari_orig < 0) set @E_2OneriStraordinari = -@E_2OneriStraordinari_orig else set @E_2OneriStraordinari = @E_2OneriStraordinari_orig
if (@E_2OneriStraordinari_prev2_orig < 0) set @E_2OneriStraordinari_prev2 = -@E_2OneriStraordinari_prev2_orig else set @E_2OneriStraordinari_prev2 = @E_2OneriStraordinari_prev2_orig
if (@E_2OneriStraordinari_prev3_orig < 0) set @E_2OneriStraordinari_prev3 = -@E_2OneriStraordinari_prev3_orig else set @E_2OneriStraordinari_prev3 = @E_2OneriStraordinari_prev3_orig

declare @E_ProventiOneriStraordinari decimal(19,2)
declare @E_ProventiOneriStraordinari_orig decimal(19,2)
set @E_ProventiOneriStraordinari_orig = isnull(@E_1ProventiStraordinari,0) - isnull(@E_2OneriStraordinari,0)
if (@E_ProventiOneriStraordinari_orig < 0) set @E_ProventiOneriStraordinari = -@E_ProventiOneriStraordinari_orig else set @E_ProventiOneriStraordinari = @E_ProventiOneriStraordinari_orig

declare @E_ProventiOneriStraordinari_prev2 decimal(19,2)
declare @E_ProventiOneriStraordinari_prev2_orig decimal(19,2)
set @E_ProventiOneriStraordinari_prev2_orig = isnull(@E_1ProventiStraordinari_prev2,0) - isnull(@E_2OneriStraordinari_prev2,0)
if (@E_ProventiOneriStraordinari_prev2_orig < 0) set @E_ProventiOneriStraordinari_prev2 = -@E_ProventiOneriStraordinari_prev2_orig else set @E_ProventiOneriStraordinari_prev2 = @E_ProventiOneriStraordinari_prev2_orig

declare @E_ProventiOneriStraordinari_prev3 decimal(19,2)
declare @E_ProventiOneriStraordinari_prev3_orig decimal(19,2)
set @E_ProventiOneriStraordinari_prev3_orig = isnull(@E_1ProventiStraordinari_prev3,0) - isnull(@E_2OneriStraordinari_prev3,0)
if (@E_ProventiOneriStraordinari_prev3_orig < 0) set @E_ProventiOneriStraordinari_prev3 = -@E_ProventiOneriStraordinari_prev3_orig else set @E_ProventiOneriStraordinari_prev3 = @E_ProventiOneriStraordinari_prev3_orig

	/*
	F) Imposte sul reddito dell'esercizio correnti, differite, anticipate
	*/
declare @F_Imposte_orig  decimal(19,2)
declare @F_Imposte_prev2_orig  decimal(19,2)
declare @F_Imposte_prev3_orig  decimal(19,2)

declare @F_Imposte  decimal(19,2)
declare @F_Imposte_prev2  decimal(19,2)
declare @F_Imposte_prev3  decimal(19,2)
SELECT @F_Imposte_orig =  - SUM(D.amount*A.economicbudget_sign_value),
		@F_Imposte_prev2_orig =  - SUM(D.amount2*A.economicbudget_sign_value),
		@F_Imposte_prev3_orig =  - SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EF1101%'

if (@F_Imposte_orig < 0) set @F_Imposte = -@F_Imposte_orig else set @F_Imposte = @F_Imposte_orig
if (@F_Imposte_prev2_orig < 0) set @F_Imposte_prev2 = -@F_Imposte_prev2_orig else set @F_Imposte_prev2 = @F_Imposte_prev2_orig
if (@F_Imposte_prev3_orig < 0) set @F_Imposte_prev3 = -@F_Imposte_prev3_orig else set @F_Imposte_prev3 = @F_Imposte_prev3_orig
/*
	G) Utilizzo di riservedi Patrimonio Netto derivanti dalla contabilità economico-patrimoniale
*/
declare @G_UtilizzoDiRiserve  decimal(19,2)
declare @G_UtilizzoDiRiserve_prev2  decimal(19,2)
declare @G_UtilizzoDiRiserve_prev3  decimal(19,2)
SELECT  @G_UtilizzoDiRiserve = SUM(D.amount*A.economicbudget_sign_value),
		@G_UtilizzoDiRiserve_prev2 = SUM(D.amount2*A.economicbudget_sign_value),
		@G_UtilizzoDiRiserve_prev3 = SUM(D.amount3*A.economicbudget_sign_value)
	FROM accountvardetail D  join accountvar V	ON V.yvar = D.yvar	AND V.nvar = D.nvar 
	JOIN accountsortingbudgetview A		on D.idacc = A.idacc
	JOIN upb U
		ON D.idupb = U.idupb
	WHERE V.yvar = @ayear and  ( V.variationkind =6  and idaccountvarstatus = 4 )
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND A.sortcode_economicbudget LIKE 'EG1101%'

DECLARE @TOTRICAVI decimal(19,2)
DECLARE @TOTRICAVI_prev2 decimal(19,2)
DECLARE @TOTRICAVI_prev3 decimal(19,2)
/*SET @TOTRICAVI = @A_I_ProventiPropri + @A_II_Contributi + @A_III_ProventiPerAttivitaAssistenziale + @A_IV_ProventiPerGestioneDiretta +
				@A_V_UtilizzoRiservePatrimonioNetto + @A_VI_VariazioniRimanenze + @A_VII_IncrementoImmobilizzazioni
				+ @C_1ProventiFinanziari  +  @C_3Utili 
				+ @D_1Rivalutazioni
				+ @E_1ProventiStraordinari 
*/
DECLARE @TOTCOSTI decimal(19,2)
DECLARE @TOTCOSTI_prev2 decimal(19,2)
DECLARE @TOTCOSTI_prev3 decimal(19,2)
/*SET @TOTCOSTI = @B_VIII_CostiPersonale + @IX_CostiGestione + @X_AmmortamentiSvalutazioni + @B_XI_AccantonamentiRischiOneri + @B_XII_OneriDversiGestione
				   - @C_2Interessi + @C_3Perdite
				   + @D_2Svalutazioni
				   - @E_2OneriStraordinari
				   + @F_Imposte 
				   -->  Interessi, Oneri straordinari sono col segno meno, perchè vengono letti col segno -, ma in questo contesto vanno sommati.
*/
declare @RisultatoEconomicoPresunto decimal(19,2)
declare @RisultatoEconomicoPresunto_prev2 decimal(19,2)
declare @RisultatoEconomicoPresunto_prev3 decimal(19,2)
---set @RisultatoEconomicoPresunto = @TOTRICAVI - @TOTCOSTI
set @RisultatoEconomicoPresunto = 
				isnull(@A_I_ProventiPropri,0) + isnull(@A_II_Contributi,0) + isnull(@A_III_ProventiPerAttivitaAssistenziale,0) + isnull(@A_IV_ProventiPerGestioneDiretta,0) 
				+ isnull(@A_V_UtilizzoRiservePatrimonioNetto,0) + isnull(@A_VI_VariazioniRimanenze,0) + isnull(@A_VII_IncrementoImmobilizzazioni,0)
				- (		isnull(@B_VIII_CostiPersonale,0) + isnull(@IX_CostiGestione,0) + isnull(@X_AmmortamentiSvalutazioni,0) + isnull(@B_XI_AccantonamentiRischiOneri,0) + isnull(@B_XII_OneriDversiGestione,0)	)
				+ isnull(@C_ProventiOneri_orig,0) + isnull(@D_Rettifiche_orig,0) + isnull(@E_ProventiOneriStraordinari_orig,0) - isnull(@F_Imposte,0)

set @RisultatoEconomicoPresunto_prev2 = 
				isnull(@A_I_ProventiPropri_prev2,0) + isnull(@A_II_Contributi_prev2,0) + isnull(@A_III_ProventiPerAttivitaAssistenziale_prev2,0) + isnull(@A_IV_ProventiPerGestioneDiretta_prev2,0) 
				+ isnull(@A_V_UtilizzoRiservePatrimonioNetto_prev2,0) + isnull(@A_VI_VariazioniRimanenze_prev2,0) + isnull(@A_VII_IncrementoImmobilizzazioni_prev2,0)
				- (		isnull(@B_VIII_CostiPersonale_prev2,0) + isnull(@IX_CostiGestione_prev2,0) + isnull(@X_AmmortamentiSvalutazioni_prev2,0) + isnull(@B_XI_AccantonamentiRischiOneri_prev2,0) + isnull(@B_XII_OneriDversiGestione_prev2,0)	)
				+ isnull(@C_ProventiOneri_prev2_orig,0) + isnull(@D_Rettifiche_prev2_orig,0) + isnull(@E_ProventiOneriStraordinari_prev2_orig,0) - isnull(@F_Imposte_prev2,0)

set @RisultatoEconomicoPresunto_prev3 = 
				isnull(@A_I_ProventiPropri_prev3,0) + isnull(@A_II_Contributi_prev3,0) + isnull(@A_III_ProventiPerAttivitaAssistenziale_prev3,0) + isnull(@A_IV_ProventiPerGestioneDiretta_prev3,0) 
				+ isnull(@A_V_UtilizzoRiservePatrimonioNetto_prev3,0) + isnull(@A_VI_VariazioniRimanenze_prev3,0) + isnull(@A_VII_IncrementoImmobilizzazioni_prev3,0)
				- (		isnull(@B_VIII_CostiPersonale_prev3,0) + isnull(@IX_CostiGestione_prev3,0) + isnull(@X_AmmortamentiSvalutazioni_prev3,0) + isnull(@B_XI_AccantonamentiRischiOneri_prev3,0) + isnull(@B_XII_OneriDversiGestione_prev3,0)	)
				+ isnull(@C_ProventiOneri_prev3_orig,0) + isnull(@D_Rettifiche_prev3_orig,0) + isnull(@E_ProventiOneriStraordinari_prev3_orig,0) - isnull(@F_Imposte_prev3,0)

declare @RisultatoAPareggio decimal(19,2)
declare @RisultatoAPareggio_prev2 decimal(19,2)
declare @RisultatoAPareggio_prev3 decimal(19,2)
set @RisultatoAPareggio = isnull(@RisultatoEconomicoPresunto,0) + isnull(@G_UtilizzoDiRiserve,0)
set @RisultatoAPareggio_prev2 = isnull(@RisultatoEconomicoPresunto_prev2,0) + isnull(@G_UtilizzoDiRiserve_prev2,0)
set @RisultatoAPareggio_prev3 = isnull(@RisultatoEconomicoPresunto_prev3,0) + isnull(@G_UtilizzoDiRiserve_prev3,0)

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

SELECT
  @ayear				  AS ayear         ,
  @idupboriginal		  as idupb         ,
  @codeupb				  as codeupb	   ,
  @title				  as upb		   ,
 @treasurer as department,
 
isnull(@A_I1_ProventiPerLaDidattica,0)  	as	  'A_I1_ProventiPerLaDidattica',  
isnull(@A_I1_ProventiPerLaDidattica_prev2,0)  	as	  'A_I1_ProventiPerLaDidattica_prev2',  
isnull(@A_I1_ProventiPerLaDidattica_prev3,0)  	as	  'A_I1_ProventiPerLaDidattica_prev3',  

isnull(@A_I2_ProventiDaRicercheCommissionate,0)  	as	  'A_I2_ProventiDaRicercheCommissionate',  
isnull(@A_I2_ProventiDaRicercheCommissionate_prev2,0)  	as	  'A_I2_ProventiDaRicercheCommissionate_prev2',  
isnull(@A_I2_ProventiDaRicercheCommissionate_prev3,0) 	as	  'A_I2_ProventiDaRicercheCommissionate_prev3',  

isnull(@A_I3_ProventiDaRicercheConFinanziamento,0)  	as	  'A_I3_ProventiDaRicercheConFinanziamento',  
isnull(@A_I3_ProventiDaRicercheConFinanziamento_prev2,0)  	as	  'A_I3_ProventiDaRicercheConFinanziamento_prev2',  
isnull(@A_I3_ProventiDaRicercheConFinanziamento_prev3,0)  	as	  'A_I3_ProventiDaRicercheConFinanziamento_prev3',  

isnull(@A_I_ProventiPropri,0)  	as	  'A_I_ProventiPropri',  
isnull(@A_I_ProventiPropri_prev2,0)  	as	  'A_I_ProventiPropri_prev2',  
isnull(@A_I_ProventiPropri_prev3,0)  	as	  'A_I_ProventiPropri_prev3',  

isnull(@A_II1_ContributiMIUR,0)  	as	  'A_II1_ContributiMIUR',  
isnull(@A_II1_ContributiMIUR_prev2,0)  	as	  'A_II1_ContributiMIUR_prev2',  
isnull(@A_II1_ContributiMIUR_prev3,0) 	as	  'A_II1_ContributiMIUR_prev3',  

isnull(@A_II2_ContributiRegioni,0)  	as	  'A_II2_ContributiRegioni',  
isnull(@A_II2_ContributiRegioni_prev2,0)	as	  'A_II2_ContributiRegioni_prev2',  
isnull(@A_II2_ContributiRegioni_prev3,0)  	as	  'A_II2_ContributiRegioni_prev3',  

isnull(@A_II3_ContributiAltreAmministrazioni,0)  	as	  'A_II3_ContributiAltreAmministrazioni',  
isnull(@A_II3_ContributiAltreAmministrazioni_prev2,0)  	as	  'A_II3_ContributiAltreAmministrazioni_prev2',  
isnull(@A_II3_ContributiAltreAmministrazioni_prev3,0)  	as	  'A_II3_ContributiAltreAmministrazioni_prev3',  

isnull(@A_II4_ContributiUE,0)  	as	  'A_II4_ContributiUE',  
isnull(@A_II4_ContributiUE_prev2,0)  	as	  'A_II4_ContributiUE_prev2',  
isnull(@A_II4_ContributiUE_prev3,0)  	as	  'A_II4_ContributiUE_prev3',  

isnull(@A_II5_ContributiUniversita,0)  	as	  'A_II5_ContributiUniversita',  
isnull(@A_II5_ContributiUniversita_prev2,0)  	as	  'A_II5_ContributiUniversita_prev2',  
isnull(@A_II5_ContributiUniversita_prev3,0)  	as	  'A_II5_ContributiUniversita_prev3',  

isnull(@A_II6_ContributiAltriPubblici,0)  	as	  'A_II6_ContributiAltriPubblici',  
isnull(@A_II6_ContributiAltriPubblici_prev2,0)  	as	  'A_II6_ContributiAltriPubblici_prev2',  
isnull(@A_II6_ContributiAltriPubblici_prev3,0)  	as	  'A_II6_ContributiAltriPubblici_prev3',  

isnull(@A_II7_ContributiAltriPrivati,0)  	as	  'A_II7_ContributiAltriPrivati',  
isnull(@A_II7_ContributiAltriPrivati_prev2,0)  	as	  'A_II7_ContributiAltriPrivati_prev2',  
isnull(@A_II7_ContributiAltriPrivati_prev3,0)  	as	  'A_II7_ContributiAltriPrivati_prev3',  

isnull(@A_II_Contributi,0)  	as	  'A_II_Contributi',  
isnull(@A_II_Contributi_prev2,0)  	as	  'A_II_Contributi_prev2',  
isnull(@A_II_Contributi_prev3,0)  	as	  'A_II_Contributi_prev3',  

isnull(@A_III_ProventiPerAttivitaAssistenziale,0)  	as	  'A_III_ProventiPerAttivitaAssistenziale',  
isnull(@A_III_ProventiPerAttivitaAssistenziale_prev2,0)  	as	  'A_III_ProventiPerAttivitaAssistenziale_prev2',  
isnull(@A_III_ProventiPerAttivitaAssistenziale_prev3,0)  	as	  'A_III_ProventiPerAttivitaAssistenziale_prev3',  

isnull(@A_IV_ProventiPerGestioneDiretta,0)  	as	  'A_IV_ProventiPerGestioneDiretta',  
isnull(@A_IV_ProventiPerGestioneDiretta_prev2,0)  	as	  'A_IV_ProventiPerGestioneDiretta_prev2',  
isnull(@A_IV_ProventiPerGestioneDiretta_prev3,0)  	as	  'A_IV_ProventiPerGestioneDiretta_prev3',  

isnull(@A_V1_UtilizzoRiservePatrimonioNetto,0)  as 'A_V1_UtilizzoRiservePatrimonioNetto',
isnull(@A_V1_UtilizzoRiservePatrimonioNetto_prev2,0)  as 'A_V1_UtilizzoRiservePatrimonioNetto_prev2',
isnull(@A_V1_UtilizzoRiservePatrimonioNetto_prev3,0)  as 'A_V1_UtilizzoRiservePatrimonioNetto_prev3',

isnull(@A_V2_AltriProventi,0) as 'A_V2_AltriProventi',
isnull(@A_V2_AltriProventi_prev2,0) as 'A_V2_AltriProventi_prev2',
isnull(@A_V2_AltriProventi_prev3,0) as 'A_V2_AltriProventi_prev3',

isnull(@A_V_UtilizzoRiservePatrimonioNetto,0)  	as	  'A_V_UtilizzoRiservePatrimonioNetto',  
isnull(@A_V_UtilizzoRiservePatrimonioNetto_prev2,0)  	as	  'A_V_UtilizzoRiservePatrimonioNetto_prev2',  
isnull(@A_V_UtilizzoRiservePatrimonioNetto_prev3,0)  	as	  'A_V_UtilizzoRiservePatrimonioNetto_prev3',  

isnull(@A_VI_VariazioniRimanenze,0)  	as	  'A_VI_VariazioniRimanenze',  
isnull(@A_VI_VariazioniRimanenze_prev2,0)  	as	  'A_VI_VariazioniRimanenze_prev2',  
isnull(@A_VI_VariazioniRimanenze_prev3,0)  	as	  'A_VI_VariazioniRimanenze_prev3',  

isnull(@A_VII_IncrementoImmobilizzazioni,0)  	as	  'A_VII_IncrementoImmobilizzazioni',  
isnull(@A_VII_IncrementoImmobilizzazioni_prev2,0)  	as	  'A_VII_IncrementoImmobilizzazioni_prev2',  
isnull(@A_VII_IncrementoImmobilizzazioni_prev3,0)  	as	  'A_VII_IncrementoImmobilizzazioni_prev3',  

isnull(@B_VIII1a_CostiDocentiRicercatori,0)  	as	  'B_VIII1a_CostiDocentiRicercatori',  
isnull(@B_VIII1a_CostiDocentiRicercatori_prev2,0)  	as	  'B_VIII1a_CostiDocentiRicercatori_prev2',  
isnull(@B_VIII1a_CostiDocentiRicercatori_prev3,0)  	as	  'B_VIII1a_CostiDocentiRicercatori_prev3',  

isnull(@B_VIII1b_CollaborazioniScientifiche,0)  	as	  'B_VIII1b_CollaborazioniScientifiche',  
isnull(@B_VIII1b_CollaborazioniScientifiche_prev2,0)  	as	  'B_VIII1b_CollaborazioniScientifiche_prev2',  
isnull(@B_VIII1b_CollaborazioniScientifiche_prev3,0)  	as	  'B_VIII1b_CollaborazioniScientifiche_prev3',  

isnull(@B_VIII1c_DocentiAContratto,0)   	as	  'B_VIII1c_DocentiAContratto',   
isnull(@B_VIII1c_DocentiAContratto_prev2,0)   	as	  'B_VIII1c_DocentiAContratto_prev2',   
isnull(@B_VIII1c_DocentiAContratto_prev3,0)   	as	  'B_VIII1c_DocentiAContratto_prev3',   

isnull(@B_VIII1d_EspertiLinguistici,0)  	as	  'B_VIII1d_EspertiLinguistici',  
isnull(@B_VIII1d_EspertiLinguistici_prev2,0)  	as	  'B_VIII1d_EspertiLinguistici_prev2',  
isnull(@B_VIII1d_EspertiLinguistici_prev3,0)  	as	  'B_VIII1d_EspertiLinguistici_prev3',  

isnull(@B_VIII1e_AltroPersonale,0)  	as	  'B_VIII1e_AltroPersonale',  
isnull(@B_VIII1e_AltroPersonale_prev2,0)  	as	  'B_VIII1e_AltroPersonale_prev2',  
isnull(@B_VIII1e_AltroPersonale_prev3,0)  	as	  'B_VIII1e_AltroPersonale_prev3',  

isnull(@B_VIII2_CostiPersonaleDirigente,0)  	as	  'B_VIII2_CostiPersonaleDirigente',  
isnull(@B_VIII2_CostiPersonaleDirigente_prev2,0)  	as	  'B_VIII2_CostiPersonaleDirigente_prev2',  
isnull(@B_VIII2_CostiPersonaleDirigente_prev3,0)  	as	  'B_VIII2_CostiPersonaleDirigente_prev3',  

isnull(@B_VIII_CostiPersonale,0)  	as	  'B_VIII_CostiPersonale',  
isnull(@B_VIII_CostiPersonale_prev2,0)  	as	  'B_VIII_CostiPersonal_prev2',  
isnull(@B_VIII_CostiPersonale_prev3,0)  	as	  'B_VIII_CostiPersonale_prev3',  

isnull(@B_IX1_CostiSostegnoStudenti,0)  	as	  'B_IX1_CostiSostegnoStudenti',  
isnull(@B_IX1_CostiSostegnoStudenti_prev2,0)  	as	  'B_IX1_CostiSostegnoStudenti_prev2',  
isnull(@B_IX1_CostiSostegnoStudenti_prev3,0)  	as	  'B_IX1_CostiSostegnoStudenti_prev3',  

isnull(@B_IX2_CostiDirittoStudio,0)  	as	  'B_IX2_CostiDirittoStudio',  
isnull(@B_IX2_CostiDirittoStudio_prev2,0)  	as	  'B_IX2_CostiDirittoStudio_prev2',  
isnull(@B_IX2_CostiDirittoStudio_prev3,0)  	as	  'B_IX2_CostiDirittoStudio_prev3',  

isnull(@B_IX3_CostiRicercaAttivitaEditoriale,0)  	as	  'B_IX3_CostiRicercaAttivitaEditoriale',  
isnull(@B_IX3_CostiRicercaAttivitaEditoriale_prev2,0)  	as	  'B_IX3_CostiRicercaAttivitaEditoriale_prev2',  
isnull(@B_IX3_CostiRicercaAttivitaEditoriale_prev3,0)  	as	  'B_IX3_CostiRicercaAttivitaEditoriale_prev3',  

isnull(@B_IX4_TrasferimentiPartner,0)  	as	  'B_IX4_TrasferimentiPartner',  
isnull(@B_IX4_TrasferimentiPartner_prev2,0)  	as	  'B_IX4_TrasferimentiPartner_prev2',  
isnull(@B_IX4_TrasferimentiPartner_prev3,0)  	as	  'B_IX4_TrasferimentiPartner_prev3',  

isnull(@B_IX5_AcquistoMaterialeConsumo,0)   	as	  'B_IX5_AcquistoMaterialeConsumo',   
isnull(@B_IX5_AcquistoMaterialeConsumo_prev2,0)   	as	  'B_IX5_AcquistoMaterialeConsumo_prev2',   
isnull(@B_IX5_AcquistoMaterialeConsumo_prev3,0)   	as	  'B_IX5_AcquistoMaterialeConsumo_prev3',   

isnull(@B_IX6_VariazioneRimanenze,0)  	as	  'B_IX6_VariazioneRimanenze',  
isnull(@B_IX6_VariazioneRimanenze_prev2,0)  	as	  'B_IX6_VariazioneRimanenze_prev2',  
isnull(@B_IX6_VariazioneRimanenze_prev3,0)  	as	  'B_IX6_VariazioneRimanenze_prev3',  

isnull(@B_IX7_AcquistoLibri,0)  	as	  'B_IX7_AcquistoLibri',  
isnull(@B_IX7_AcquistoLibri_prev2,0)  	as	  'B_IX7_AcquistoLibri_prev2',  
isnull(@B_IX7_AcquistoLibri_prev3,0)  	as	  'B_IX7_AcquistoLibri_prev3',  

isnull(@B_IX8_AcquistoServizi,0)  	as	  'B_IX8_AcquistoServizi',  
isnull(@B_IX8_AcquistoServizi_prev2,0)  	as	  'B_IX8_AcquistoServizi_prev2',  
isnull(@B_IX8_AcquistoServizi_prev3,0)  	as	  'B_IX8_AcquistoServizi_prev3',  

isnull(@B_IX9_AcquistoAltriMateriali,0)  	as	  'B_IX9_AcquistoAltriMateriali',  
isnull(@B_IX9_AcquistoAltriMateriali_prev2,0)  	as	  'B_IX9_AcquistoAltriMateriali_prev2',  
isnull(@B_IX9_AcquistoAltriMateriali_prev3,0)  	as	  'B_IX9_AcquistoAltriMateriali_prev3',  

isnull(@B_IX10_VariazioneRimanenze,0)  	as	  'B_IX10_VariazioneRimanenze',  
isnull(@B_IX10_VariazioneRimanenze_prev2,0) 	as	  'B_IX10_VariazioneRimanenze_prev2',  
isnull(@B_IX10_VariazioneRimanenze_prev3,0)  	as	  'B_IX10_VariazioneRimanenze_prev3',  

isnull(@B_IX11_CostiGodimento,0)  	as	  'B_IX11_CostiGodimento',  
isnull(@B_IX11_CostiGodimento_prev2,0)  	as	  'B_IX11_CostiGodimento_prev2',  
isnull(@B_IX11_CostiGodimento_prev3,0) 	as	  'B_IX11_CostiGodimento_prev3',  

isnull(@B_IX12_AltriCosti,0)   	as	  'B_IX12_AltriCosti',   
isnull(@B_IX12_AltriCosti_prev2,0)  	as	  'B_IX12_AltriCosti_prev2',   
isnull(@B_IX12_AltriCosti_prev3,0)  	as	  'B_IX12_AltriCosti_prev3',   

isnull(@IX_CostiGestione,0)  	as	  'IX_CostiGestione',  
isnull(@IX_CostiGestione_prev2,0)  	as	  'IX_CostiGestione_prev2',  
isnull(@IX_CostiGestione_prev3,0)  	as	  'IX_CostiGestione_prev3',  

isnull(@B_X1_AmmortamentiImmobImmateriali,0)  	as	  'B_X1_AmmortamentiImmobImmateriali',  
isnull(@B_X1_AmmortamentiImmobImmateriali_prev2,0)  	as	  'B_X1_AmmortamentiImmobImmateriali_prev2',  
isnull(@B_X1_AmmortamentiImmobImmateriali_prev3,0)  	as	  'B_X1_AmmortamentiImmobImmateriali_prev3',  

isnull(@B_X2_AmmortamentiImmobMateriali,0)  	as	  'B_X2_AmmortamentiImmobMateriali',  
isnull(@B_X2_AmmortamentiImmobMateriali_prev2,0)  	as	  'B_X2_AmmortamentiImmobMateriali_prev2',  
isnull(@B_X2_AmmortamentiImmobMateriali_prev3,0)  	as	  'B_X2_AmmortamentiImmobMateriali_prev3',  

isnull(@B_X3_SvalutazioniImmobilizzazioni,0)  	as	  'B_X3_SvalutazioniImmobilizzazioni',
isnull(@B_X3_SvalutazioniImmobilizzazioni_prev2,0)  	as	  'B_X3_SvalutazioniImmobilizzazioni_prev2',
isnull(@B_X3_SvalutazioniImmobilizzazioni_prev3,0)  	as	  'B_X3_SvalutazioniImmobilizzazioni_prev3',

isnull(@B_X4_SvalutazioniCrediti,0)  	as	  'B_X4_SvalutazioniCrediti',  
isnull(@B_X4_SvalutazioniCrediti_prev2,0)  	as	  'B_X4_SvalutazioniCrediti_prev2',  
isnull(@B_X4_SvalutazioniCrediti_prev3,0)  	as	  'B_X4_SvalutazioniCrediti_prev3',  

isnull(@X_AmmortamentiSvalutazioni,0) 	as	  'X_AmmortamentiSvalutazioni',  
isnull(@X_AmmortamentiSvalutazioni_prev2,0) 	as	  'X_AmmortamentiSvalutazioni_prev2',  
isnull(@X_AmmortamentiSvalutazioni_prev3,0)  	as	  'X_AmmortamentiSvalutazioni_prev3',  

isnull(@B_XI_AccantonamentiRischiOneri,0)  	as	  'B_XI_AccantonamentiRischiOneri',  
isnull(@B_XI_AccantonamentiRischiOneri_prev2,0)  	as	  'B_XI_AccantonamentiRischiOneri_prev2',  
isnull(@B_XI_AccantonamentiRischiOneri_prev3,0)  	as	  'B_XI_AccantonamentiRischiOneri_prev3',  

isnull(@B_XII_OneriDversiGestione,0)  	as	  'B_XII_OneriDversiGestione',  
isnull(@B_XII_OneriDversiGestione_prev2,0)  	as	  'B_XII_OneriDversiGestione_prev2',  
isnull(@B_XII_OneriDversiGestione_prev3,0)  	as	  'B_XII_OneriDversiGestione_prev3',  

isnull(@C_1ProventiFinanziari,0)  	as	  'C_1ProventiFinanziari',  
isnull(@C_1ProventiFinanziari_prev2,0)  	as	  'C_1ProventiFinanziari_prev2',  
isnull(@C_1ProventiFinanziari_prev3,0)  	as	  'C_1ProventiFinanziari_prev3',  
  
isnull(@C_2Interessi,0) 	as	  'C_2Interessi',  
isnull(@C_2Interessi_prev2,0) 	as	  'C_2Interessi_prev2',  
isnull(@C_2Interessi_prev3,0)  	as	  'C_2Interessi_prev3',  

isnull(@C_3Utili,0)  	as	  'C_3Utili',  
isnull(@C_3Utili_prev2,0)  	as	  'C_3Utili_prev2',  
isnull(@C_3Utili_prev3,0)  	as	  'C_3Utili_prev3',  

isnull(@C_3Perdite,0)  	as	  'C_3Perdite',  
isnull(@C_3Perdite_prev2,0)  	as	  'C_3Perdite_prev2',  
isnull(@C_3Perdite_prev3,0)  	as	  'C_3Perdite_prev3',  

isnull(@C_ProventiOneri,0)  	as	  'C_ProventiOneri',  
isnull(@C_ProventiOneri_prev2,0)  	as	  'C_ProventiOneri_prev2',  
isnull(@C_ProventiOneri_prev3,0)  	as	  'C_ProventiOneri_prev3',  

isnull(@D_1Rivalutazioni,0)  	as	  'D_1Rivalutazioni',  
isnull(@D_1Rivalutazioni_prev2,0)  	as	  'D_1Rivalutazioni_prev2',  
isnull(@D_1Rivalutazioni_prev3,0)  	as	  'D_1Rivalutazioni_prev3',  

isnull(@D_2Svalutazioni,0)  	as	  'D_2Svalutazioni',  
isnull(@D_2Svalutazioni_prev2,0)  	as	  'D_2Svalutazioni_prev2',  
isnull(@D_2Svalutazioni_prev3,0)  	as	  'D_2Svalutazioni_prev3',  

isnull(@D_Rettifiche,0)  	as	  'D_Rettifiche',  
isnull(@D_Rettifiche_prev2,0)  	as	  'D_Rettifiche_prev2',  
isnull(@D_Rettifiche_prev3,0)  	as	  'D_Rettifiche_prev3',  

isnull(@E_1ProventiStraordinari,0)   	as	  'E_1ProventiStraordinari',   
isnull(@E_1ProventiStraordinari_prev2,0)   	as	  'E_1ProventiStraordinari_prev2',   
isnull(@E_1ProventiStraordinari_prev3,0)   	as	  'E_1ProventiStraordinari_prev3',   

isnull(@E_2OneriStraordinari,0)   	as	  'E_2OneriStraordinari',   
isnull(@E_2OneriStraordinari_prev2,0)   	as	  'E_2OneriStraordinari_prev2',   
isnull(@E_2OneriStraordinari_prev3,0)   	as	  'E_2OneriStraordinari_prev3',   

isnull(@E_ProventiOneriStraordinari,0)  	as	  'E_ProventiOneriStraordinari',  
isnull(@E_ProventiOneriStraordinari_prev2,0)  	as	  'E_ProventiOneriStraordinari_prev2',  
isnull(@E_ProventiOneriStraordinari_prev3,0)  	as	  'E_ProventiOneriStraordinari_prev3',  

isnull(@F_Imposte,0)   	as	  'F_Imposte',   
isnull(@F_Imposte_prev2,0)   	as	  'F_Imposte_prev2',   
isnull(@F_Imposte_prev3,0)   	as	  'F_Imposte_prev3',   

isnull(@G_UtilizzoDiRiserve,0)   	as	  'G_UtilizzoDiRiserve',   
isnull(@G_UtilizzoDiRiserve_prev2,0)   	as	  'G_UtilizzoDiRiserve_prev2',   
isnull(@G_UtilizzoDiRiserve_prev3,0)   	as	  'G_UtilizzoDiRiserve_prev3',   

isnull(@TOTRICAVI,0)  	as	  'TotRicavi',  
isnull(@TOTRICAVI_prev2,0)  	as	  'TotRicavi_prev2',  
isnull(@TOTRICAVI_prev3,0)  	as	  'TotRicavi_prev3',  

isnull(@TOTCOSTI,0)  	as	  'TotCosto',  
isnull(@TOTCOSTI_prev2,0)  	as	  'TotCosto_prev2',  
isnull(@TOTCOSTI_prev3,0)  	as	  'TotCosto_prev3',  

isnull(@RisultatoEconomicoPresunto,0)  	as	  'RisultatoEconomicoPresunto', 
isnull(@RisultatoEconomicoPresunto_prev2,0)  	as	  'RisultatoEconomicoPresunto_prev2', 
isnull(@RisultatoEconomicoPresunto_prev3,0)  	as	  'RisultatoEconomicoPresunto_prev3', 

isnull(@RisultatoAPareggio,0) 	as	  'RisultatoAPareggio' ,
isnull(@RisultatoAPareggio_prev2,0) 	as	  'RisultatoAPareggio_prev2' ,
isnull(@RisultatoAPareggio_prev3,0) 	as	  'RisultatoAPareggio_prev3' 
		
				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



