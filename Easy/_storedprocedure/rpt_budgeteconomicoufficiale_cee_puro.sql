/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoufficiale_cee_puro]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoufficiale_cee_puro]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione' 
-- exec rpt_budgeteconomicoufficiale_cee_puro 2025, '%','S'
CREATE      PROCEDURE [rpt_budgeteconomicoufficiale_cee_puro](
	@ayear int,--> anno del bilancio di previsione
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


 -- A) Valore della produzione: 
 -- 1) ricavi delle vendite e delle prestazioni
		--  1) a) ricavi delle vendite e delle prestazioni
		--  1) b) altri ricavi connessi alle vendite e alle prestazioni
  --  2) variazioni  delle  rimanenze  di   prodotti   in   corso   di lavorazione, semilavorati e finiti; 
  --  3) variazioni dei lavori in corso su ordinazione; 
  --  4) incrementi di immobilizzazioni per lavori interni; 
  --  5)  altri  ricavi  e  proventi,  con  separata  indicazione   dei contributi in conto esercizio. 
  -- Totale(A)

  declare @A1a_RicaviVenditePrestazioni decimal(19,2)
	set @A1a_RicaviVenditePrestazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-A) 1) a)%'),0)

  declare @A1b_RicaviVenditePrestazioni decimal(19,2)
	set @A1b_RicaviVenditePrestazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-A) 1) b)'),0)


	 declare @A2_VariazioniRimanenze decimal(19,2)
	set @A2_VariazioniRimanenze = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-A) 2)%'),0)

	declare @A3_VariazioniLavori decimal(19,2)
	set @A3_VariazioniLavori = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-A) 3)%'),0)

	declare @A4_IncrementiImmobilizzazioni  decimal(19,2)
	set @A4_IncrementiImmobilizzazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-A) 4)%'),0)

	declare @A5a_AltriRicavi  decimal(19,2)
	set @A5a_AltriRicavi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-A) 5) a)%'),0)

	declare @A5b_AltriRicavi  decimal(19,2)
	set @A5b_AltriRicavi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-A) 5) b)%'),0)


declare @A_Totale decimal (19,2) 
set @A_Totale = @A1a_RicaviVenditePrestazioni + @A1b_RicaviVenditePrestazioni + @A2_VariazioniRimanenze +  @A3_VariazioniLavori 
		+  @A4_IncrementiImmobilizzazioni + @A5a_AltriRicavi+ @A5b_AltriRicavi
  --  B) Costi della produzione: 
    --  6) per materie prime, sussidiarie, di consumo e di merci; 
  --  7) per servizi; 
  --  8) per godimento di beni di terzi; 
  --  9) per il personale: 
  --    a) salari e stipendi; 
  --    b) oneri sociali; 
  --    c) trattamento di fine rapporto; 
  --    d) trattamento di quiescenza e simili; 
  --    e) altri costi; 
  --  10) ammortamenti e svalutazioni: 
  --    a) ammortamento delle immobilizzazioni immateriali; 
  --    b) ammortamento delle immobilizzazioni materiali; 
  --    c) altre svalutazioni delle immobilizzazioni; 
  --    d) svalutazioni dei crediti compresi nell'attivo  circolante  e delle disponibilita' liquide; 
  --  11) variazioni delle rimanenze di materie prime, sussidiarie,  di consumo e merci; 
  --  12) accantonamenti per rischi; 
  --  13) altri accantonamenti; 
  --  14) oneri diversi di gestione. 
  --Totale (B) 

  declare @B6_PerMateriePrime decimal(19,2)
	set @B6_PerMateriePrime = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 6)%'),0)
		
  declare @B7_PerServizi decimal(19,2)
	set @B7_PerServizi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 7)%'),0)
		
  declare @B8_PerGodimento decimal(19,2)
	set @B8_PerGodimento = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 8)%'),0)
		
  declare @B9a_SalariStipendi decimal(19,2)
	set @B9a_SalariStipendi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 9) a)%'),0)
		
	declare @B9b_OneriSociali decimal(19,2)
	set @B9b_OneriSociali = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 9) b)%'),0)

	declare @B9c_TrattamentoFineRapporto decimal(19,2)
	set @B9c_TrattamentoFineRapporto = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 9) c)%'),0)

	declare @B9d_TrattamentoFineRapporto decimal(19,2)
	set @B9d_TrattamentoFineRapporto = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 9) d)%'),0)

	declare @B9e_AltriCosti decimal(19,2)
	set @B9e_AltriCosti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 9) e)%'),0)
	
	declare @B9_Totale decimal(19,2)
	set @B9_Totale = @B9a_SalariStipendi + @B9b_OneriSociali + @B9c_TrattamentoFineRapporto + @B9d_TrattamentoFineRapporto + @B9e_AltriCosti

  declare @B10a_AmmortamentoImmateriali decimal(19,2)
	set @B10a_AmmortamentoImmateriali = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 10) a)%'),0)

  declare @B10b_AmmortamentoImmobilizzazioniMateriali decimal(19,2)
	set @B10b_AmmortamentoImmobilizzazioniMateriali = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 10) b)%'),0)

  declare @B10c_SvalutazioniImmobilizzazioni decimal(19,2)
	set @B10c_SvalutazioniImmobilizzazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 10) c)%'),0)

  declare @B10d_SvalutazioniCrediti decimal(19,2)
	set @B10d_SvalutazioniCrediti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 10) d)%'),0)

declare @B10_Totale decimal (19,2)
set @B10_Totale = @B10a_AmmortamentoImmateriali + @B10b_AmmortamentoImmobilizzazioniMateriali +	@B10c_SvalutazioniImmobilizzazioni + @B10d_SvalutazioniCrediti

  declare @B11_VariazioniRimanenze decimal(19,2)
	set @B11_VariazioniRimanenze = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 11)%'),0)

  declare @B12_AccantonamentiRischi decimal(19,2)
	set @B12_AccantonamentiRischi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 12)%'),0)

  declare @B13_AltriAccantonamenti decimal(19,2)
	set @B13_AltriAccantonamenti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 13)%'),0)

  declare @B14_OneriDiversiGestione decimal(19,2)
	set @B14_OneriDiversiGestione = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-B) 14)%'),0)

	declare @B_Totale decimal (19,2)
	set @B_Totale = @B6_PerMateriePrime + @B7_PerServizi + @B8_PerGodimento+@B9_Totale + @B10_Totale 
	+ @B11_VariazioniRimanenze + @B12_AccantonamentiRischi + @B13_AltriAccantonamenti + @B14_OneriDiversiGestione

--    Differenza tra valore e costi della produzione (A - B)
	declare @DifferenzaValoreCostiProduzione decimal (19,2)
	set @DifferenzaValoreCostiProduzione = @A_Totale - @B_Totale

 -- C) Proventi e oneri finanziari: 
 --   15) proventi  da  partecipazioni,  con  separata  indicazione  di quelli relativi ad imprese controllate  e  collegate 
 --   16) altri proventi finanziari: 
 --     a) da crediti iscritti  nelle  immobilizzazioni,  con  separata
--			indicazione di quelli da imprese controllate e collegate e di  quelli
--			da controllanti; 
 --     b)  da  titoli  iscritti   nelle   immobilizzazioni   che   non
--			costituiscono partecipazioni; 
 --     c)  da  titoli  iscritti   nell'attivo   circolante   che   non
--		costituiscono partecipazioni; 
 --     d) proventi diversi dai precedenti, con separata indicazione di
--		quelli da imprese controllate e collegate e di quelli da controllanti
--	17) interessi e altri oneri finanziari, con separata  indicazione di quelli verso imprese controllate e collegate e verso controllanti; 
 --   17-bis) utili e perdite su cambi. 
--	Totale (15 + 16 - 17+ - 17 bis). 

  declare @C15a_ProventiPartecipazioni decimal(19,2)
	set @C15a_ProventiPartecipazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 15) a)%'),0)

  declare @C15b_ProventiPartecipazioni decimal(19,2)
	set @C15b_ProventiPartecipazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 15) b)%'),0)

		  declare @C15c_ProventiPartecipazioni decimal(19,2)
	set @C15c_ProventiPartecipazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 15) c)%'),0)

  declare @C15d_ProventiPartecipazioni decimal(19,2)
	set @C15d_ProventiPartecipazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 15) d)%'),0)

  declare @C15e_ProventiPartecipazioni decimal(19,2)
	set @C15e_ProventiPartecipazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 15) e)%'),0)
	
	declare @C15_totale decimal(19,2)
	set @C15_totale = @C15a_ProventiPartecipazioni + @C15b_ProventiPartecipazioni + @C15c_ProventiPartecipazioni 
				+ @C15d_ProventiPartecipazioni +	@C15e_ProventiPartecipazioni
  declare @C16a1_Crediti decimal(19,2)
	set @C16a1_Crediti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) a) 1%'),0)

  declare @C16a2_Crediti decimal(19,2)
	set @C16a2_Crediti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) a) 2%'),0)

  declare @C16a3_Crediti decimal(19,2)
	set @C16a3_Crediti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) a) 3%'),0)

  declare @C16a4_Crediti decimal(19,2)
	set @C16a4_Crediti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) a) 4%'),0)

  declare @C16a5_Crediti decimal(19,2)
	set @C16a5_Crediti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) a) 5%'),0)

	declare @C16a_Crediti decimal(19,2)
	set @C16a_Crediti = @C16a1_Crediti + @C16a2_Crediti + @C16a3_Crediti + @C16a4_Crediti + @C16a5_Crediti

  declare @C16b_TitoliIscrittiImmobilizzazion decimal(19,2)
	set @C16b_TitoliIscrittiImmobilizzazion = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) b)%'),0)

  declare @C16c_TitoliIscrittiAttivoCircolante decimal(19,2)
	set @C16c_TitoliIscrittiAttivoCircolante = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) c)%'),0)
		
  declare @C16d1_ProventiDiversiPrecedenti decimal(19,2)
	set @C16d1_ProventiDiversiPrecedenti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) d) 1%'),0)

  declare @C16d2_ProventiDiversiPrecedenti decimal(19,2)
	set @C16d2_ProventiDiversiPrecedenti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) d) 2%'),0)

	 declare @C16d3_ProventiDiversiPrecedenti decimal(19,2)
	set @C16d3_ProventiDiversiPrecedenti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) d) 3%'),0)

   declare @C16d4_ProventiDiversiPrecedenti decimal(19,2)
	set @C16d4_ProventiDiversiPrecedenti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) d) 4%'),0)

	declare @C16d5_ProventiDiversiPrecedenti decimal(19,2)
	set @C16d5_ProventiDiversiPrecedenti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 16) d) 5%'),0)

	declare @C16d_ProventiDiversiPrecedenti decimal(19,2)
	set @C16d_ProventiDiversiPrecedenti = @C16d1_ProventiDiversiPrecedenti + @C16d2_ProventiDiversiPrecedenti + @C16d3_ProventiDiversiPrecedenti
								+ @C16d4_ProventiDiversiPrecedenti + @C16d5_ProventiDiversiPrecedenti


	declare @C16_totale decimal(19,2)
	set @C16_totale = @C16a_Crediti + @C16b_TitoliIscrittiImmobilizzazion + @C16c_TitoliIscrittiAttivoCircolante 
			+ @C16d1_ProventiDiversiPrecedenti	+ @C16d2_ProventiDiversiPrecedenti	+ @C16d3_ProventiDiversiPrecedenti	+ @C16d4_ProventiDiversiPrecedenti	+ @C16d5_ProventiDiversiPrecedenti

  declare @C17a_Interessi decimal(19,2)
	set @C17a_Interessi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 17) a)%'),0)

  declare @C17b_Interessi decimal(19,2)
	set @C17b_Interessi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 17) b)%'),0)

  declare @C17c_Interessi decimal(19,2)
	set @C17c_Interessi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 17) c)%'),0)

  declare @C17d_Interessi decimal(19,2)
	set @C17d_Interessi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 17) d)%'),0)

  declare @C17e_Interessi decimal(19,2)
	set @C17e_Interessi = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 17) e)%'),0)


  declare @C17bis_UtiliPerdite decimal(19,2)
	set @C17bis_UtiliPerdite = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-C) 17bis)%'),0)

	declare @C17_Interessi decimal(19,2)
	set @C17_Interessi =  @C17a_Interessi + @C17b_Interessi + @C17c_Interessi + @C17d_Interessi + @C17e_Interessi

	declare @C_Totale decimal(19,2)
	set @C_Totale = @C15a_ProventiPartecipazioni + @C15b_ProventiPartecipazioni + @C15c_ProventiPartecipazioni + @C15d_ProventiPartecipazioni + @C15e_ProventiPartecipazioni 
			+ @C16_totale 
			- @C17a_Interessi - @C17b_Interessi - @C17c_Interessi - @C17d_Interessi - @C17e_Interessi
			- @C17bis_UtiliPerdite

  --D) Rettifiche di valore di attivita' e passivita' finanziarie 
  --  18) rivalutazioni: 
  --    a) di partecipazioni; 
  --    b)  di  immobilizzazioni  finanziarie  che  non   costituiscono partecipazioni; 
  --    c)  di  titoli   iscritti   all'attivo   circolante   che   non costituiscono partecipazioni; 
  --  19) svalutazioni: 
  --    a) di partecipazioni; 
  --    b)  di  immobilizzazioni  finanziarie  che  non   costituiscono partecipazioni; 
  --    c)  di  titoli  iscritti   nell'attivo   circolante   che   non costituiscono partecipazioni. 
  --Totale delle rettifiche (18 - 19).

  --Risultato prima delle imposte (A-B+-C+-D); 
  --  20) imposte sul reddito  dell'esercizio,  correnti,  differite  e anticipate; 
  --  21) utile (perdite) dell'esercizio. 

  declare @D18a_Rivalutazioni_diPartecipazioni decimal(19,2)
  set @D18a_Rivalutazioni_diPartecipazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 18) a)%'),0)

  declare @D18b_Rivalutazioni_diImmobilizzazioniFinanziarie decimal(19,2)
  set @D18b_Rivalutazioni_diImmobilizzazioniFinanziarie = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 18) b)%'),0)

  declare @D18c_Rivalutazioni_diTitoliIscritti  decimal(19,2)
  set @D18c_Rivalutazioni_diTitoliIscritti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 18) c)%'),0)

  declare @D18d_Rivalutazioni_diStrumentiFinanziari decimal(19,2)
  set @D18d_Rivalutazioni_diStrumentiFinanziari = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 18) d)%'),0)

	declare @D18_Totale decimal (19,2)
	set @D18_Totale = @D18a_Rivalutazioni_diPartecipazioni + @D18b_Rivalutazioni_diImmobilizzazioniFinanziarie + @D18c_Rivalutazioni_diTitoliIscritti + @D18d_Rivalutazioni_diStrumentiFinanziari


  declare @D19a_Svalutazioni_diPartecipazioni decimal(19,2)
  set @D19a_Svalutazioni_diPartecipazioni = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 19) a)%'),0)

  declare @D19b_Svalutazioni_diImmobilizzazioniFinanziarie decimal(19,2)
  set @D19b_Svalutazioni_diImmobilizzazioniFinanziarie = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 19) b)%'),0)

  declare @D19c_Svalutazioni_diTitoliIscritti  decimal(19,2)
  set @D19c_Svalutazioni_diTitoliIscritti = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 19) c)%'),0)

  declare @D19d_Svalutazioni_diStrumentiFinanziari decimal(19,2)
  set @D19d_Svalutazioni_diStrumentiFinanziari = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-D) 19) d)%'),0)

	declare @D19_Totale decimal (19,2)
	set @D19_Totale = @D19a_Svalutazioni_diPartecipazioni + @D19b_Svalutazioni_diImmobilizzazioniFinanziarie + @D19c_Svalutazioni_diTitoliIscritti + @D19d_Svalutazioni_diStrumentiFinanziari

	declare @D_Totale decimal(19,2)
	set @D_Totale = @D18_Totale+ @D19_Totale

	declare @TotaledelleRettifiche decimal(12,2)
	set @TotaledelleRettifiche = @D18_Totale - @D19_Totale

	declare @Totale_RisultatoPrimaDelleImposte decimal(19,2)
	set @Totale_RisultatoPrimaDelleImposte = @A_Totale - @B_Totale +@C_Totale + @TotaledelleRettifiche
	
	
	declare @D20a_ImposteRedditoEesercizio decimal(19,2)
	set @D20a_ImposteRedditoEesercizio = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-20) a)%'),0)


	declare @D20b_ImposteRedditoEesercizio decimal(19,2)
	set @D20b_ImposteRedditoEesercizio = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-20) b)%'),0)

	declare @D20c_ImposteRedditoEesercizio decimal(19,2)
	set @D20c_ImposteRedditoEesercizio = ISNULL(( SELECT SUM(accountyear.prevision*A.economicbudget_sign_value)
	FROM accountyear 
	join accountview A
		on accountyear.idacc = A.idacc
	JOIN upb U
		ON accountyear.idupb = U.idupb
	join sorting S
		on S.idsor = A.idsor_economicbudget
	WHERE accountyear.ayear = @ayear
		AND U.idupb like @idupb
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND S.sortcode LIKE 'E-20) c)%'),0)

DECLARE @D20_ImposteRedditoEesercizio decimal(19,2)
SET @D20_ImposteRedditoEesercizio = @D20a_ImposteRedditoEesercizio+@D20b_ImposteRedditoEesercizio+@D20c_ImposteRedditoEesercizio

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

@A_Totale 		as		 A_Totale 	,
@A1a_RicaviVenditePrestazioni  		as		 A1a_RicaviVenditePrestazioni  	,
@A1b_RicaviVenditePrestazioni  		as		 A1b_RicaviVenditePrestazioni  	,
@A2_VariazioniRimanenze  		as		 A2_VariazioniRimanenze  	,
@A3_VariazioniLavori  		as		 A3_VariazioniLavori  	,
@A4_IncrementiImmobilizzazioni   		as		 A4_IncrementiImmobilizzazioni   	,
@A5a_AltriRicavi   		as		 A5a_AltriRicavi   	,
@A5b_AltriRicavi   		as		 A5b_AltriRicavi   	,
@B_Totale  		as		 B_Totale  	,
@B10_Totale  		as		 B10_Totale  	,
@B10a_AmmortamentoImmateriali  		as		 B10a_AmmortamentoImmateriali  	,
@B10b_AmmortamentoImmobilizzazioniMateriali  		as		 B10b_AmmortamentoImmobilizzazioniMateriali  	,
@B10c_SvalutazioniImmobilizzazioni  		as		 B10c_SvalutazioniImmobilizzazioni  	,
@B10d_SvalutazioniCrediti  		as		 B10d_SvalutazioniCrediti  	,
@B11_VariazioniRimanenze  		as		 B11_VariazioniRimanenze  	,
@B12_AccantonamentiRischi  		as		 B12_AccantonamentiRischi  	,
@B13_AltriAccantonamenti  		as		 B13_AltriAccantonamenti  	,
@B14_OneriDiversiGestione  		as		 B14_OneriDiversiGestione  	,
@B6_PerMateriePrime  		as		 B6_PerMateriePrime  	,
@B7_PerServizi  		as		 B7_PerServizi  	,
@B8_PerGodimento  		as		 B8_PerGodimento  	,
@B9_Totale  		as		 B9_Totale  	,
@B9a_SalariStipendi  		as		 B9a_SalariStipendi  	,
@B9b_OneriSociali  		as		 B9b_OneriSociali  	,
@B9c_TrattamentoFineRapporto  		as		 B9c_TrattamentoFineRapporto  	,
@B9d_TrattamentoFineRapporto  		as		 B9d_TrattamentoFineRapporto  	,
@B9e_AltriCosti  		as		 B9e_AltriCosti  	,
@C_Totale  		as		 C_Totale  	,
@C15a_ProventiPartecipazioni  		as		 C15a_ProventiPartecipazioni  	,
@C15b_ProventiPartecipazioni  		as		 C15b_ProventiPartecipazioni  	,
@C15c_ProventiPartecipazioni  		as		 C15c_ProventiPartecipazioni  	,
@C15d_ProventiPartecipazioni  		as		 C15d_ProventiPartecipazioni  	,
@C15e_ProventiPartecipazioni  		as		 C15e_ProventiPartecipazioni  	,
@C15_totale as C15_totale,
@C16_totale  		as		 C16_totale  	,
@C16a_Crediti  		as		 C16a_Crediti  	,
@C16a1_Crediti as  C16a1_Crediti,
@C16a2_Crediti as  C16a2_Crediti,
@C16a3_Crediti as  C16a3_Crediti,
@C16a4_Crediti as  C16a4_Crediti,
@C16a5_Crediti as  C16a5_Crediti,

@C16b_TitoliIscrittiImmobilizzazion  		as		 C16b_TitoliIscrittiImmobilizzazion  	,
@C16c_TitoliIscrittiAttivoCircolante  		as		 C16c_TitoliIscrittiAttivoCircolante  	,
@C16d_ProventiDiversiPrecedenti			as C16d_ProventiDiversiPrecedenti,
@C16d1_ProventiDiversiPrecedenti  		as		 C16d1_ProventiDiversiPrecedenti  	,
@C16d2_ProventiDiversiPrecedenti  		as		 C16d2_ProventiDiversiPrecedenti  	,
@C16d3_ProventiDiversiPrecedenti  		as		 C16d3_ProventiDiversiPrecedenti  	,
@C16d4_ProventiDiversiPrecedenti  		as		 C16d4_ProventiDiversiPrecedenti  	,
@C16d5_ProventiDiversiPrecedenti  		as		 C16d5_ProventiDiversiPrecedenti  	,
@C17_Interessi	as C17_Interessi,
@C17a_Interessi  		as		 C17a_Interessi  	,
@C17b_Interessi  		as		 C17b_Interessi  	,
@C17c_Interessi  		as		 C17c_Interessi  	,
@C17d_Interessi  		as		 C17d_Interessi  	,
@C17e_Interessi  		as		 C17e_Interessi  	,
@C17bis_UtiliPerdite  		as		 C17bis_UtiliPerdite  	,
@D_Totale  		as		 D_Totale  	,
@D18_Totale  		as		 D18_Totale  	,
@D18a_Rivalutazioni_diPartecipazioni  		as		 D18a_Rivalutazioni_diPartecipazioni  	,
@D18b_Rivalutazioni_diImmobilizzazioniFinanziarie  		as		 D18b_Rivalutazioni_diImmobilizzazioniFinanziarie  	,
@D18c_Rivalutazioni_diTitoliIscritti   		as		 D18c_Rivalutazioni_diTitoliIscritti   	,
@D18d_Rivalutazioni_diStrumentiFinanziari  		as		 D18d_Rivalutazioni_diStrumentiFinanziari  	,
@D19_Totale  		as		 D19_Totale  	,
@D19a_Svalutazioni_diPartecipazioni  		as		 D19a_Svalutazioni_diPartecipazioni  	,
@D19b_Svalutazioni_diImmobilizzazioniFinanziarie  		as		 D19b_Svalutazioni_diImmobilizzazioniFinanziarie  	,
@D19c_Svalutazioni_diTitoliIscritti   		as		 D19c_Svalutazioni_diTitoliIscritti   	,
@D19d_Svalutazioni_diStrumentiFinanziari  		as		 D19d_Svalutazioni_diStrumentiFinanziari  	,

@D20_ImposteRedditoEesercizio  		as		 D20_ImposteRedditoEesercizio  	,
@D20a_ImposteRedditoEesercizio  		as		 D20a_ImposteRedditoEesercizio  	,
@D20b_ImposteRedditoEesercizio  		as		 D20b_ImposteRedditoEesercizio  	,
@D20c_ImposteRedditoEesercizio  		as		 D20c_ImposteRedditoEesercizio  	,

@DifferenzaValoreCostiProduzione  		as		 DifferenzaValoreCostiProduzione  	,
@Totale_RisultatoPrimaDelleImposte  		as		 Totale_RisultatoPrimaDelleImposte  	,
@TotaledelleRettifiche 		as		 TotaledelleRettifiche 	

		




				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



