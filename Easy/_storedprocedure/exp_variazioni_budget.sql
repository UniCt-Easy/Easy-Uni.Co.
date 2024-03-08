
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_variazioni_budget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_variazioni_budget]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
--exec exp_variazioni_budget 2017, {d'2017-12-31'},'%','S',null,null,null,null,null
--go
--exec exp_variazioni_budget  2019, {d'2019-12-31'},'%','S',null,null,null,null,null
--go
-- exec exp_variazioni_budget 2018, {d'2018-12-31'},1 ,null,null,null,null,null
CREATE      PROCEDURE  [exp_variazioni_budget](
	@ayear int,--> anno del bilancio di previsione
	@adate datetime, 
	@numatto int, 
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

IF @idsor05 = 0 set @idsor05 = null

declare 	@idupb varchar(36)='%'
declare 	@showchildupb char(1)='S'

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

declare @nlevel int
set @nlevel = (select MIN(nlevel) from accountlevel where ayear = @ayear and flagusable = 'S')

declare @maxnlevel int
set @maxnlevel = (select MAX(nlevel) from accountlevel where ayear = @ayear and flagusable = 'S')
declare @lenminlevel int
set @lenminlevel = 2 + 4*@nlevel
CREATE TABLE #dati
(nlevel int ,label varchar(300), sortcode varchar(10),
 _initprev decimal(19,2), _var decimal(19,2), 
 _prevcorr decimal(19,2), _preacc decimal(19,2),_preimp decimal(19,2),
 _saldo decimal(19,2), _entry decimal(19,2), _nonrealizzato decimal(19,2),
  kind char(10) /*Costi o Ricavi, Voce aggregata, SuTotali e Totali */, 
  parent_label varchar(50), segno int, 
  ordinestampa int identity(1,1))  
 -------------------------------------------------------------------------------------------------
 --------------------------------------- RICAVI --------------------------------------------------
 -------------------------------------------------------------------------------------------------
 /*	I. PROVENTI PROPRI
	1)Proventi per la didattica
	2)Proventi da Ricerche commissionate e trasferimento tecnologico
	3)Proventi da Ricerche con finanziamento competitivi
*/
INSERT INTO #dati  SELECT 0,'A) PROVENTI OPERATIVI', null, 0,0,0,0,0,0,0,0, 'R' ,null,null 
INSERT INTO #dati  SELECT 2,'I.PROVENTI PROPRI', null, 0,0,0,0,0,0,0,0, 'R' ,null, 1
INSERT INTO #dati  SELECT 1,'1) Proventi per la didattica', 'EA1101%', 0,0,0,0,0,0,0,0, 'R' ,'I.PROVENTI PROPRI',1   
INSERT INTO #dati  SELECT 1,'2) Proventi da Ricerche commissionate e trasferimento tecnologico', 'EA1102%', 0,0,0,0,0,0,0,0, 'R', 'I.PROVENTI PROPRI',1
INSERT INTO #dati  SELECT 1,'3) Proventi da Ricerche con finanziamenti competitivi', 'EA1103%', 0,0,0,0,0,0,0,0, 'R' ,'I.PROVENTI PROPRI',1

INSERT INTO #dati  SELECT 2,'II. CONTRIBUTI', null,  0,0,0,0,0,0,0,0, 'R',  null,1
INSERT INTO #dati  SELECT 1,'1) Contributi MIUR  e altre Amministrazioni Centrali', 'EA1201%', 0,0,0,0,0,0,0,0, 'R','II. CONTRIBUTI',1
INSERT INTO #dati  SELECT 1,'2) Contibuti Regioni e Province autonome', 'EA1202%',  0,0,0,0,0,0,0,0, 'R','II. CONTRIBUTI',1 
INSERT INTO #dati  SELECT 1,'3) Contributi altre Amministrazioni locali', 'EA1203%',  0,0,0,0,0,0,0,0, 'R' ,'II. CONTRIBUTI',1
DECLARE @label_1 varchar(200)
IF (@ayear<=2017)  
	SET @label_1 = '4) Contributi Unione Europea e altri Organismi Internazionali'
else 
	SET @label_1 = '4) Contributi Unione Europea e Resto del Mondo'

INSERT INTO #dati  SELECT 1,@label_1, 'EA1204%',  0,0,0,0,0,0,0,0, 'R','II. CONTRIBUTI',1 
INSERT INTO #dati  SELECT 1,'5) Contributi da Università', 'EA1205%', 0,0,0,0,0,0,0,0, 'R' ,'II. CONTRIBUTI',1
INSERT INTO #dati  SELECT 1,'6) Contributi da altri enti (pubblici)', 'EA1206%',  0,0,0,0,0,0,0,0, 'R' ,'II. CONTRIBUTI',1
INSERT INTO #dati  SELECT 1,'7) Contributi da altri enti (privati)', 'EA1207%', 0,0,0,0,0,0,0,0, 'R' ,'II. CONTRIBUTI',1 

-------------- PROVENTI PER ATTIVITA' ASSISTENZIALE ---------------------------------- 
INSERT INTO #dati  SELECT 2,'III. PROVENTI PER ATTIVITA’ ASSISTENZIALE', 'EA1301%',  0,0,0,0,0,0,0,0, 'R',  null,1 
-------------- PROVENTI PER GESTIONE DIRETTA ---------------------------------- 
INSERT INTO #dati  SELECT 2,'IV. PROVENTI PER LA GESTIONE DIRETTA INTERVENTI PER IL DIRITTO ALLO STUDIO', 'EA1401%',  0,0,0,0,0,0,0,0, 'R', null,1
-- V.ALTRI PROVENTI E RICAVI DIVERSI
-- 1) Utilizzo di riserve di Patrimonio netto derivanti dalla contabilità finanziaria
-- 2) Altri Proventi e Ricavi Diversi
INSERT INTO #dati  SELECT 2,'V. ALTRI PROVENTI  E RICAVI DIVERSI',null,  0,0,0,0,0,0,0,0, 'R' ,  null,1
INSERT INTO #dati  SELECT 1,'1) Utilizzo di riserve di Patrimonio netto derivanti dalla contabilità finanziaria', 'EA1501%', 0,0,0,0,0,0,0,0, 'R' ,  'V. ALTRI PROVENTI  E RICAVI DIVERSI',1
INSERT INTO #dati  SELECT 1,'2) Altri Proventi e Ricavi Diversi', 'EA1502%', 0,0,0,0,0,0,0,0, 'R' ,'V. ALTRI PROVENTI  E RICAVI DIVERSI',1 
-------------- Variazioni Rimanenze  ---------------------------------- 
INSERT INTO #dati  SELECT 2,'VI. VARIAZIONE RIMANENZE', 'EA1601%', 0,0,0,0,0,0,0,0, 'R',  null,1 
---------- Incremento Immobilizzazioni per lavoro interni ---------------------------------- 
INSERT INTO #dati  SELECT 2,'VII. INCREMENTO IMMOBILIZZAZIONI PER LAVORI INTERNI', 'EA1701%',0,0,0,0,0,0,0,0, 'R' , null,1
----------- TOTALE PROVENTI (A)-----------------------------------------------------------------
INSERT INTO #dati  SELECT 0,'TOTALE PROVENTI  (A)', null, 0,0,0,0,0,0,0,0, 'R' ,null,null 
------------------------------------------------------------------------------------------------
-------------------------------------- COSTI ---------------------------------------------------
------------------------------------------------------------------------------------------------
INSERT INTO #dati  SELECT 0,'B) COSTI OPERATIVI', null, 0,0,0,0,0,0,0,0, 'C' ,null,null 

INSERT INTO #dati  SELECT 2,'VIII.  COSTI DEL PERSONALE', null, 0,0,0,0,0,0,0,0, 'C' ,null,1
INSERT INTO #dati  SELECT 1,'1) Costi del personale dedicato alla ricerca e alla didattica', null, 0,0,0,0,0,0,0,0, 'C' ,null,1
INSERT INTO #dati  SELECT 1,'a) Docenti/Ricercatori',  'EB1101%', 0,0,0,0,0,0,0,0, 'C' ,'VIII.  COSTI DEL PERSONALE',1
INSERT INTO #dati  SELECT 1,'b) Collaborazioni scientifiche (collaboratori, assegnisti, ecc)', 'EB1102%', 0,0,0,0,0,0,0,0, 'C','VIII.  COSTI DEL PERSONALE',1 
INSERT INTO #dati  SELECT 1,'c) Docenti a contratto', 'EB1103%', 0,0,0,0,0,0,0,0, 'C' ,'VIII.  COSTI DEL PERSONALE',1
INSERT INTO #dati  SELECT 1,'d) Esperti linguistici', 'EB1104%', 0,0,0,0,0,0,0,0, 'C' ,'VIII.  COSTI DEL PERSONALE',1
INSERT INTO #dati  SELECT 1,'e) Altro personale dedicato alla didattica e alla ricerca', 'EB1105%', 0,0,0,0,0,0,0,0, 'C' ,'VIII.  COSTI DEL PERSONALE',1
INSERT INTO #dati  SELECT 1,'2) Costi del personale dirigente e tecnico-amministrativo', 'EB1201%', 0,0,0,0,0,0,0,0, 'C','VIII.  COSTI DEL PERSONALE',1

INSERT INTO #dati  SELECT 2,'IX. COSTI DELLA GESTIONE CORRENTE', null, 0,0,0,0,0,0,0,0, 'C'  ,null,1   
INSERT INTO #dati  SELECT 1,'1) Costi per sostegno agli studenti', 'EB2101%', 0,0,0,0,0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1   
INSERT INTO #dati  SELECT 1,'2) Costi per il diritto allo studio', 'EB2102%', 0,0,0,0,0,0,0,0, 'C'  , 'IX. COSTI DELLA GESTIONE CORRENTE',1  
IF (@ayear<=2017)  
	SET @label_1 = '3) Costi per la ricerca e l''attività editoriale'
else 
	SET @label_1 = '3) Costi per l''attività editoriale'

INSERT INTO #dati  SELECT 1,@label_1, 'EB2103%', 0,0,0,0,0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1  
INSERT INTO #dati  SELECT 1,'4) Trasferimenti a partner di progetti coordinati', 'EB2104%',0,0,0,0,0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  
INSERT INTO #dati  SELECT 1, '5) Acquisto materiale consumo per laboratori', 'EB2105%',0,0,0,0,0,0,0,0, 'C'  , 'IX. COSTI DELLA GESTIONE CORRENTE',1  
INSERT INTO #dati  SELECT 1,'6) Variazione rimanenze di materiale di consumo per laboratori', 'EB2106%',0,0,0,0,0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  
INSERT INTO #dati  SELECT 1,'7)Acquisto di libri, periodici e matariale bibliografico', 'EB2107%', 0,0,0,0,0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1   
INSERT INTO #dati  SELECT 1,'8) Acquisto di servizi e collaborazioni tecnico gestionali', 'EB2108%',0,0,0,0,0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  
INSERT INTO #dati  SELECT 1,'9) Acquisto altri materiali', 'EB2109%',0,0,0,0,0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1   
INSERT INTO #dati  SELECT 1,'10) Variazione delle rimanenze di materiale', 'EB2110%',  0,0,0,0,0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  
INSERT INTO #dati  SELECT 1,'11) Costi per godimento beni di terzi', 'EB2111%',0,0,0,0,0,0,0,0, 'C'  , 'IX. COSTI DELLA GESTIONE CORRENTE',1  
INSERT INTO #dati  SELECT 1,'12) Altri costi', 'EB2112%', 0,0,0,0,0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1    

INSERT INTO #dati  SELECT 2,'X. AMMORTAMENTI E SVALUTAZIONI', null,0,0,0,0,0,0,0,0, 'C' ,null,1
INSERT INTO #dati  SELECT 1,'1) Ammortamenti immobilizzazioni immateriali', 'EB3101%',0,0,0,0,0,0,0,0, 'C','X. AMMORTAMENTI E SVALUTAZIONI',1
INSERT INTO #dati  SELECT 1,'2) Ammortamenti immobilizzazioni materiali', 'EB3102%', 0,0,0,0,0,0,0,0, 'C','X. AMMORTAMENTI E SVALUTAZIONI',1 
INSERT INTO #dati  SELECT 1,'3) Svalutazioni immobilizzazioni', 'EB3103%',0,0,0,0,0,0,0,0, 'C','X. AMMORTAMENTI E SVALUTAZIONI',1 
INSERT INTO #dati  SELECT 1,'4) Svalutazioni dei crediti compresi nell’attivo circolante e nelle disponibilità liquide', 'EB3104%', 0,0,0,0,0,0,0,0, 'C' ,'X. AMMORTAMENTI E SVALUTAZIONI',1
INSERT INTO #dati  SELECT 2,'XI. ACCANTONAMENTI PER RISCHI E ONERI', 'EB4101%', 0,0,0,0,0,0,0,0, 'C', null, 1 
INSERT INTO #dati  SELECT 2,'XII. ONERI DIVERSI DI GESTIONE','EB5101%',0,0,0,0,0,0,0,0, 'C' , null, 1
INSERT INTO #dati  SELECT 0,'TOTALE COSTI  (B)', null, 0,0,0,0,0,0,0,0, 'C' ,null,null 
INSERT INTO #dati  SELECT 0,'DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)', null, 0,0,0,0,0,0,0,0, 'A' ,null,null 

INSERT INTO #dati  SELECT 3,'C) PROVENTI E ONERI FINANZIARI', null, 0,0,0,0,0,0,0,0, 'A', null,1  --,'S' 
INSERT INTO #dati  SELECT 1,'1) Proventi finanziari', 'EC1101%', 0,0,0,0,0,0,0,0, 'R', 'C) PROVENTI E ONERI FINANZIARI',1
INSERT INTO #dati  SELECT 1,'2) Interessi ed altri oneri finanziari', 'EC1102%',0,0,0,0,0,0,0,0, 'C', 'C) PROVENTI E ONERI FINANZIARI',-1 --,'S' 
INSERT INTO #dati  SELECT 2,'3) Utili e Perdite su cambi', null,0,0,0,0,0,0,0,0, 'A', 'C) PROVENTI E ONERI FINANZIARI',1 --,'S' 
INSERT INTO #dati  SELECT 1,' Utili', 'EC1103%',0,0,0,0,0,0,0,0, 'R' , '3) Utili e Perdite su cambi',1
INSERT INTO #dati  SELECT 1,' Perdite', 'EC1104%',0,0,0,0,0,0,0,0, 'C' ,'3) Utili e Perdite su cambi',-1

INSERT INTO #dati  SELECT 2,'D) RETTIFICHE DI VALORE DI ATTIVITA'' FINANZIARIE', null, 0,0,0,0,0,0,0,0, 'A', null,1   --,'S' 
INSERT INTO #dati  SELECT 1,'1) Rivalutazioni', 'ED1101%',0,0,0,0,0,0,0,0, 'R', 'D) RETTIFICHE DI VALORE DI ATTIVITA'' FINANZIARIE',1 
INSERT INTO #dati  SELECT 1,'2) Svalutazioni', 'ED1102%',0,0,0,0,0,0,0,0, 'C', 'D) RETTIFICHE DI VALORE DI ATTIVITA'' FINANZIARIE',-1  -- ,'S' 

INSERT INTO #dati  SELECT 2,'E) PROVENTI E ONERI STRAORDINARI', null, 0,0,0,0,0,0,0,0, 'A',null,1  ---,'S' 
INSERT INTO #dati  SELECT 1,'1) Proventi', 'EE1101%', 0,0,0,0,0,0,0,0, 'R','E) PROVENTI E ONERI STRAORDINARI',1 
INSERT INTO #dati  SELECT 1,'2) Oneri',  'EE1102%', 0,0,0,0,0,0,0,0, 'C','E) PROVENTI E ONERI STRAORDINARI',-1  ---,'S'   

INSERT INTO #dati  SELECT 1,'F) IMPOSTE SUL REDDITO DELL''ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE', 'EF1101%',0,0,0,0,0,0,0,0, 'C', null, -1

-------------Tot Ricavi  ------------------------------------------------------------   
INSERT INTO #dati  SELECT 3,'TotRicavi', null,0,0,0,0,0,0,0,0, 'TOTR', 'RISULTATO ECONOMICO', 1 
-------------Tot Costi ----------------------------------------------------  
INSERT INTO #dati  SELECT 3,'TotCosti', null, 0,0,0,0,0,0,0,0, 'TOTC' , 'RISULTATO ECONOMICO', -1 
-------------Risultato Economico Presunto ----------------------------------  
INSERT INTO #dati  SELECT 4,'RISULTATO ECONOMICO', null, 0,0,0,0,0,0,0,0, 'SUBT' , 'RISULTATO A PAREGGIO', 1 
----------------------------Utilizzo Di Riserve   -------------------------------------  
INSERT INTO #dati  SELECT 4,'G) UTILIZZO DI RISERVE DI PATRIMONIO NETTO DERIVANTI DALLA CONTABILITA'' ECONOMICO-PATRIMONIALE', 'EG1101%', 0,0,0,0,0,0,0,0, 'C' ,'RISULTATO A PAREGGIO',1  
-------------Risultato A Pareggio----------------------------------   
INSERT INTO #dati  SELECT 5,'RISULTATO A PAREGGIO', null, 0,0,0,0,0,0,0,0, 'TOT'  , null,1
 --drop table #dati

 DECLARE @label varchar(300)
 DECLARE @sortcode varchar(10)
 DECLARE @kind char(1)
 DECLARE @ass char(1)
 declare @cursore cursor


	set @cursore = cursor for 
		select label, sortcode, kind
		from #dati WHERE kind in ('R', 'C') and sortcode is not null
	
	open @cursore
	fetch next from @cursore into  @label, @sortcode, @kind
	while @@fetch_status = 0
	begin
		   declare @_initprev decimal(19,2)
		   declare @_var    decimal(19,2)
		   declare @_prevcorr    decimal(19,2)
		   declare @_preacc    decimal(19,2)
		   declare @_preimp   decimal(19,2)
		   declare @_saldo   decimal(19,2)
		   declare @_entry   decimal(19,2)
		   declare @_nonrealizzato   decimal(19,2)

		   SET  @_initprev = ISNULL(( SELECT SUM(accountyear.prevision)
			FROM accountyear 
			join account A		on accountyear.idacc = A.idacc
			JOIN upb U			ON accountyear.idupb = U.idupb
			join sorting S		on S.idsor = A.idsor_economicbudget
			WHERE accountyear.ayear = @ayear
			AND U.idupb like @idupb
			AND A.nlevel = @nlevel
			AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
			AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
			AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
			AND S.sortcode LIKE @sortcode),0)

			
		    SET  @_var = ISNULL(( SELECT SUM(D.amount)
			FROM accountvardetail D 
				join accountvar V			ON V.yvar = D.yvar	AND V.nvar = D.nvar 
			join account A					on D.idacc = A.idacc
			JOIN upb U						ON D.idupb = U.idupb
			join sorting S					on S.idsor = A.idsor_economicbudget
			join accountenactment AC	 	ON AC.idenactment = V.idenactment
			WHERE V.yvar = @ayear
				AND V.adate<= @adate
				AND AC.nenactment = @numatto
				AND A.nlevel = @nlevel
				AND V.idaccountvarstatus = 5 and V.variationkind <> 5 
				AND (U.idupb like @idupb)
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
				AND S.sortcode LIKE @sortcode),0)


		-- SET @_preimp =  
		-- (ISNULL(( SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EY.amount ELSE - EY.amount END) 
		--		FROM epexpyear EY
		--		JOIN epexp E				ON E.idepexp = EY.idepexp
		--		JOIN account A				ON EY.idacc = A.idacc
		--		JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
		--		JOIN upb U					ON EY.idupb = U.idupb
		--		JOIN sorting S				ON S.idsor = PARENT.idsor_economicbudget
		--		WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate 
		--		AND U.idupb like @idupb
		--		AND A.flagaccountusage & 64 <> 0
		--		--AND A.nlevel = @maxnlevel
		--		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		--		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		--		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		--		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		--		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		--		AND S.sortcode LIKE @sortcode),0))
		--		+
		--		(ISNULL((SELECT SUM(CASE E.flagvariation WHEN 'N' THEN EV.amount ELSE - EV.amount END) 
		--		FROM epexpvar EV 
		--		JOIN epexpyear EY			ON EV.idepexp = EY.idepexp 
		--		JOIN epexp E				ON E.idepexp = EY.idepexp
		--		JOIN account A				ON EY.idacc = A.idacc
		--		JOIN account PARENT 		ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
		--		JOIN upb U					ON EY.idupb = U.idupb
		--		JOIN sorting S				ON S.idsor = PARENT.idsor_economicbudget
		--		WHERE E.nphase = 1 AND EY.ayear = @ayear AND E.adate<= @adate and EV.adate <= @adate and EV.yvar = @ayear
		--		AND U.idupb like @idupb
		--		AND A.flagaccountusage & 64 <> 0
		--		--AND A.nlevel = @maxnlevel
		--		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		--		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		--		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		--		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		--		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		--		AND S.sortcode LIKE @sortcode),0))

  
		--		SET @_preacc = ISNULL(( SELECT SUM(AY.amount) 
		--		from epaccyear AY
		--		JOIN epacc AC			ON AC.idepacc = AY.idepacc
		--		JOIN account A			ON AY.idacc = A.idacc
		--		JOIN account PARENT 	ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
		--		JOIN upb U				ON AY.idupb = U.idupb
		--		JOIN sorting S			ON S.idsor = PARENT.idsor_economicbudget
		--		WHERE AC.nphase = 1 AND AY.ayear = @ayear AND AC.adate<= @adate and AC.yepacc = @ayear
		--		AND U.idupb like @idupb
		--		AND A.flagaccountusage & 128 <> 0
		--		--AND A.nlevel = @maxnlevel
		--		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		--		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		--		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		--		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		--		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		--		AND S.sortcode LIKE @sortcode),0)
		--		+
		--		ISNULL(( SELECT SUM(AV.amount) 
		--		FROM epaccvar AV
		--		JOIN epaccyear AY		ON AY.idepacc = AV.idepacc
		--		JOIN epacc AC			ON AC.idepacc = AY.idepacc
		--		JOIN account A			ON AY.idacc = A.idacc
		--		JOIN account PARENT 	ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
		--		JOIN upb U				ON AY.idupb = U.idupb
		--		JOIN sorting S			ON S.idsor = PARENT.idsor_economicbudget
		--		WHERE AC.nphase = 1  AND AC.adate<= @adate and AV.adate <= @adate AND AY.ayear = @ayear and AV.yvar = @ayear
		--		AND U.idupb like @idupb
		--		AND A.flagaccountusage & 128 <> 0
		--		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	
		--		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		--		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		--		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	
		--		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		--		--AND A.nlevel = @maxnlevel
		--		AND S.sortcode LIKE @sortcode),0)

	 
		--SET @_entry = ISNULL(( SELECT SUM(entrydetail.amount)
		--			  FROM entrydetail
		--			JOIN entry
		--				ON entry.yentry = entrydetail.yentry
		--				AND entry.nentry = entrydetail.nentry
		--			JOIN account A
		--				ON A.idacc = entrydetail.idacc
		--			JOIN account PARENT 
		--				ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
		--			JOIN sorting S
		--				on S.idsor = PARENT.idsor_economicbudget
		--			JOIN upb U	ON entrydetail.idupb = U.idupb
		--			WHERE entry.yentry = @ayear AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		--				AND adate <= @adate
		--				AND entrydetail.idupb like @idupb
		--				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	
		--				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		--				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		--				AND(
		--				(( A.flagaccountusage & 64) <> 0)    -- Costi
		--				OR
		--				(( A.flagaccountusage & 128) <> 0)   -- Ricavi
		--				)
		--				AND S.sortcode LIKE @sortcode),0)
								  
		   if (@kind = 'C') 	SET @_entry  = - @_entry  --- cambio di segno per i costi
		   	
		   update #dati set _initprev = @_initprev where label = @label
		   update #dati set _var = @_var	   where label = @label
		   update #dati set _prevcorr = isnull(@_initprev,0)  + isnull(@_var,0) where label = @label
		--   update #dati set _preacc = @_preacc where label = @label
		--   update #dati set _preimp = @_preimp where label = @label
		--   update #dati set _saldo =  isnull(@_initprev,0)  + isnull(@_var,0)  - isnull(@_preacc,0)  - isnull(@_preimp,0) where label = @label
		--   update #dati set _entry  = @_entry  where label = @label
		--   update #dati set _nonrealizzato  = isnull(@_preacc,0)  + isnull(@_preimp,0) - isnull(@_entry,0) where label = @label

		   set @_initprev		= 0
		   set @_var			= 0 
		   set @_prevcorr		= 0
		--   set @_preacc			= 0 
		--   set @_preimp			= 0 
		--   set @_saldo			= 0  
		--   set @_entry			= 0 
		--   set @_nonrealizzato  = 0 

	fetch next from  @cursore into   @label, @sortcode, @kind
	end
	close @cursore
	deallocate @cursore
	END


-- gestisco i valori aggregati di livello 2, costi ricavi o voci aggregate (costi/ricavi)


UPDATE #dati SET _initprev = _initprev + isnull((select sum(_initprev * segno) FROM #dati child
where child.parent_label = #dati.label and nlevel = 1),0)		where  #dati.kind IN('R','C','A') and nlevel = 2
  	
UPDATE #dati SET _var = _var +  isnull((select sum(_var * segno) FROM #dati child
where child.parent_label = #dati.label and nlevel = 1)	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 2

UPDATE #dati SET _prevcorr = _prevcorr +  isnull((select sum(_prevcorr * segno) FROM #dati child
where child.parent_label = #dati.label and nlevel = 1)	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 2

--UPDATE #dati SET _preacc= _preacc +  isnull((select sum(_preacc * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel = 1)	,0)	where  #dati.kind IN('R','C')  and nlevel = 2

--UPDATE #dati SET _preimp= _preimp +  isnull((select sum(_preimp * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel = 1)	,0)	where  #dati.kind IN('R','C')  and nlevel = 2

--UPDATE #dati SET _preimp= _preimp +  isnull((select sum(_preacc* segno + _preimp * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel = 1)	,0)	where  #dati.kind IN('A')  and nlevel = 2

--UPDATE #dati SET _saldo= _saldo +  isnull((select sum(_saldo * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel = 1)	,0)	where  #dati.kind IN('R','C', 'A')  and nlevel = 2

--UPDATE #dati SET _entry = _entry +  isnull((select sum(_entry * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel = 1)	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 2

--UPDATE #dati SET _nonrealizzato= _nonrealizzato +  isnull((select sum(_nonrealizzato * segno) FROM #dati child
--where child.parent_label = #dati.label  and nlevel = 1)	,0) 	where  #dati.kind IN('R','C', 'A')  and nlevel = 2

-- gestisco i valori aggregati di livello 3, costi ricavi o voci aggregate (costi/ricavi)
 
UPDATE #dati SET _initprev = _initprev + isnull((select sum(_initprev * segno) FROM #dati child
where child.parent_label = #dati.label and nlevel IN(1, 2)),0)		where  #dati.kind IN('R','C','A') and nlevel =3
  	
UPDATE #dati SET _var = _var +  isnull((select sum(_var * segno) FROM #dati child
where child.parent_label = #dati.label and nlevel IN(1, 2))	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 3

UPDATE #dati SET _prevcorr = _prevcorr +  isnull((select sum(_prevcorr * segno) FROM #dati child
where child.parent_label = #dati.label and nlevel IN(1, 2))	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel =3

--UPDATE #dati SET _preacc= _preacc +  isnull((select sum(_preacc * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel   IN(1, 2))	,0)	where  #dati.kind IN('R','C')  and nlevel =3

--UPDATE #dati SET _preimp= _preimp +  isnull((select sum(_preimp * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel IN(1, 2))	,0)	where  #dati.kind IN('R','C')  and nlevel = 3

--UPDATE #dati SET _preimp= _preimp +  isnull((select sum(_preacc* segno + _preimp * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel IN(1, 2))	,0)	where  #dati.kind IN('A')  and nlevel = 3

--UPDATE #dati SET _saldo= _saldo +  isnull((select sum(_saldo * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel IN(1, 2))	,0)	where  #dati.kind IN('R','C', 'A')  and nlevel = 3

--UPDATE #dati SET _entry = _entry +  isnull((select sum(_entry * segno) FROM #dati child
--where child.parent_label = #dati.label and nlevel IN(1, 2))	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 3

--UPDATE #dati SET _nonrealizzato= _nonrealizzato +  isnull((select sum(_nonrealizzato * segno) FROM #dati child
--where child.parent_label = #dati.label  and nlevel IN(1, 2))	,0) 	where  #dati.kind IN('R','C', 'A')  and nlevel = 3

--Valorizzo la voce Totale_Proventi_A
UPDATE #dati SET _initprev = _initprev + isnull((select sum(_initprev ) FROM #dati child
where child.KIND = 'R' and nlevel = 2 ),0)			where  #dati.label = ('TOTALE PROVENTI  (A)')

UPDATE #dati SET _var = _var + isnull((select sum(_var ) FROM #dati child
where child.KIND = 'R' and nlevel = 2 ),0)			where  #dati.label = ('TOTALE PROVENTI  (A)')

--UPDATE #dati SET _prevcorr = _prevcorr +  isnull((select sum(_prevcorr ) FROM #dati child
--where child.KIND = 'R' and nlevel = 2)	,0)	where  #dati.label = ('TOTALE PROVENTI  (A)')

--UPDATE #dati SET _preacc= _preacc +  isnull((select sum(_preacc ) FROM #dati child
--where child.KIND = 'R' and nlevel = 2)	,0)	where #dati.label = ('TOTALE PROVENTI  (A)')

--UPDATE #dati SET _preimp= _preimp +  isnull((select sum(_preimp ) FROM #dati child
--where child.KIND = 'R' and nlevel = 2)	,0)	where #dati.label = ('TOTALE PROVENTI  (A)')

--UPDATE #dati SET _saldo= _saldo + isnull((select sum(_saldo ) FROM #dati child
--where child.KIND = 'R' and nlevel = 2 ),0)		where  #dati.label = ('TOTALE PROVENTI  (A)')

--UPDATE #dati SET _entry = _entry + isnull((select sum(_entry ) FROM #dati child
--where child.KIND = 'R' and nlevel = 2 )	,0)	where #dati.label = ('TOTALE PROVENTI  (A)')

--UPDATE #dati SET _nonrealizzato= _nonrealizzato + isnull((select sum(_nonrealizzato ) FROM #dati child
--where  child.KIND = 'R' and nlevel = 2 )	,0)		where #dati.label = ('TOTALE PROVENTI  (A)')

--Valorizzo la voce Totale_Costi_B
UPDATE #dati SET _initprev = _initprev + isnull((select sum(_initprev ) FROM #dati child
where child.KIND = 'C' and nlevel = 2 ),0)			where  #dati.label = ('TOTALE COSTI  (B)')

UPDATE #dati SET _var = _var + isnull((select sum(_var ) FROM #dati child
where child.KIND = 'C' and nlevel = 2 ),0)			where  #dati.label = ('TOTALE COSTI  (B)')

UPDATE #dati SET _prevcorr = _prevcorr +  isnull((select sum(_prevcorr ) FROM #dati child
where child.KIND = 'C' and nlevel = 2)	,0)	where  #dati.label = ('TOTALE COSTI  (B)')

--UPDATE #dati SET _preacc= _preacc +  isnull((select sum(_preacc ) FROM #dati child
--where child.KIND = 'C' and nlevel = 2)	,0)	where #dati.label = ('TOTALE COSTI  (B)')

--UPDATE #dati SET _preimp= _preimp +  isnull((select sum(_preimp ) FROM #dati child
--where child.KIND = 'C' and nlevel = 2)	,0)	where #dati.label = ('TOTALE COSTI  (B)')

--UPDATE #dati SET _saldo= _saldo + isnull((select sum(_saldo ) FROM #dati child
--where child.KIND = 'C' and nlevel = 2 ),0)		where  #dati.label = ('TOTALE COSTI  (B)')

--UPDATE #dati SET _entry = _entry + isnull((select sum(_entry ) FROM #dati child
--where child.KIND = 'C' and nlevel = 2 )	,0)	where #dati.label = ('TOTALE COSTI  (B)')

--UPDATE #dati SET _nonrealizzato= _nonrealizzato + isnull((select sum(_nonrealizzato ) FROM #dati child
--where  child.KIND = 'C' and nlevel = 2 )	,0)		where #dati.label = ('TOTALE COSTI  (B)')

---- DIFFERENZA TRA PROVENTI E COSTI OPERATIVI
UPDATE #dati SET _initprev = 
isnull((select sum(_initprev ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)') ,0)	-
isnull((select sum(_initprev ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)') ,0)			
where  #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)')

UPDATE #dati SET _var  	 = 
isnull((select sum(_var ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)') ,0)	-
isnull((select sum(_var ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)') ,0)	
where  #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)')

UPDATE #dati SET _prevcorr = 
isnull((select sum(_prevcorr ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)') ,0)	-
isnull((select sum(_prevcorr ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)') ,0)	
where  #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)')

--UPDATE #dati SET _preimp= 
--isnull((select sum(_preacc ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)') ,0)	-
--isnull((select sum(_preimp ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)') ,0)	
--where #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)')


--UPDATE #dati SET _saldo= 
--isnull((select sum(_saldo ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)') ,0)	-
--isnull((select sum(_saldo ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)') ,0)	
--where  #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)')

--UPDATE #dati SET _entry = 
--isnull((select sum(_entry ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)') ,0)	-
--isnull((select sum(_entry ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)') ,0)	
--where #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)')

--UPDATE #dati SET _nonrealizzato= 
--isnull((select sum(_nonrealizzato ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)') ,0)	-
--isnull((select sum(_nonrealizzato ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)') ,0)	
--where #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)')

--- Valorizzo la voce TotRicavi
UPDATE #dati SET _initprev = isnull((select sum(_initprev ) FROM #dati child
where child.KIND = 'R' and nlevel = 1 ),0)		where  #dati.label = 'TotRicavi'

UPDATE #dati SET _var =  isnull((select sum(_var ) FROM #dati child
where child.KIND = 'R' and nlevel = 1 ),0)		where  #dati.label = 'TotRicavi'

UPDATE #dati SET _prevcorr = isnull((select sum(_prevcorr ) FROM #dati child
where child.KIND = 'R' and nlevel = 1)	,0)	 where  #dati.label = 'TotRicavi'

--UPDATE #dati SET _preacc=  isnull((select sum(_preacc ) FROM #dati child
--where child.KIND = 'R' and nlevel = 1)	,0)	where  #dati.label = 'TotRicavi'


--UPDATE #dati SET _saldo= isnull((select sum(_saldo ) FROM #dati child
--where child.KIND = 'R' and nlevel = 1 ),0)		where  #dati.label = 'TotRicavi'

--UPDATE #dati SET _entry = isnull((select sum(_entry ) FROM #dati child
--where child.KIND = 'R' and nlevel = 1 )	,0)		where  #dati.label = 'TotRicavi'

--UPDATE #dati SET _nonrealizzato=  isnull((select sum(_nonrealizzato ) FROM #dati child
--where  child.KIND = 'R' and nlevel = 1 )	,0)		where  #dati.label = 'TotRicavi'

--- Valorizzo la voce TotCosti
UPDATE #dati SET _initprev = isnull((select sum(_initprev ) FROM #dati child
where  child.KIND = 'C' and sortcode is not null),0)	where  #dati.label = 'TotCosti'

UPDATE #dati SET _var =  isnull((select sum(_var ) FROM #dati child
where  child.KIND = 'C' and sortcode is not null),0)	where  #dati.label = 'TotCosti'

UPDATE #dati SET _preacc=  isnull((select sum(_preacc ) FROM #dati child
where  child.KIND = 'C' and sortcode is not null ) 	,0) where  #dati.label = 'TotCosti'

--UPDATE #dati SET _preimp=  isnull((select sum(_preimp ) FROM #dati child
--where  child.KIND = 'C' and sortcode is not null) 	,0) where  #dati.label = 'TotCosti'

--UPDATE #dati SET _saldo= isnull((select sum(_saldo ) FROM #dati child
--where  child.KIND = 'C' and sortcode is not null ) 	,0)	where  #dati.label = 'TotCosti'

--UPDATE #dati SET _entry = isnull((select sum(_entry ) FROM #dati child
--where  child.KIND = 'C' and sortcode is not null) 	,0)	where  #dati.label = 'TotCosti'

--UPDATE #dati SET _nonrealizzato=  isnull((select sum(_nonrealizzato ) FROM #dati child
--where  child.KIND = 'C' and sortcode is not null) 	,0)	where  #dati.label = 'TotCosti'

--- Risultato economico  
UPDATE #dati SET _initprev =  (select sum(_initprev * segno) FROM #dati child
where child.parent_label = #dati.label)		where  #dati.label = 'RISULTATO ECONOMICO'

--UPDATE #dati SET _entry = (select sum(_entry * segno) FROM #dati child
--where child.parent_label = #dati.label)		where  #dati.label = 'RISULTATO ECONOMICO'

--- Risultato a pareggio
UPDATE #dati SET _initprev= (select sum(_initprev * segno) FROM #dati child
where child.parent_label = #dati.label)		where  #dati.label = 'RISULTATO A PAREGGIO'
 
ALTER TABLE #dati add _movbudget decimal(19,2)
--UPDATE #dati SET _movbudget = CASE kind 
--							  WHEN 'R' THEN _preacc 
--							  WHEN 'C' THEN _preimp 
--							  ELSE --- voci aggregate costi/ricavi o subotali
--									CASE
--										WHEN _preacc > 0 THEN _preacc ELSE _preimp 
--									END  
--							  END 

UPDATE #dati SET nlevel = 2 WHERE  label = 'F) IMPOSTE SUL REDDITO DELL''ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE'

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

--select * from #dati where kind = 'R' and sortcode is not null
--select *  from #dati where kind = 'C' and sortcode is not null

--select sum(_initprev) from #dati where kind = 'R' and sortcode is not null
--select sum(_initprev)  from #dati where kind = 'C' and sortcode is not null
SELECT
  @ayear				  AS ayear         ,
  --@idupboriginal		  as idupb         ,
  --@codeupb				  as codeupb	   ,
  --@title				  as upb		   ,
  --@treasurer			  as department    ,
  --nlevel,
  CASE WHEN nlevel = 1 THEN SPACE(2) + label
	 WHEN nlevel = 2 THEN SPACE(1) + label
	 ELSE label
END  as label,
--sortcode,
_initprev as 'Previsioni economiche iniziali',
_var as 'Variazione attuale ',
--_prevcorr ,
--_movbudget,
--_saldo,
--_entry,
--_nonrealizzato,
--kind,
--parent_label,
segno,
ordinestampa
FROM #dati
where ordinestampa not in (21,51,57,58,66,67  )
 order by ordinestampa
GO


