
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


-- FINE GENERAZIONE SCRIPT --
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_upbitinerationavailable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_upbitinerationavailable]
GO
--setuser 'amm'
--setuser 'amministrazione'
--exec exp_upbitinerationavailable 2021, '0001', 'D'
CREATE  PROCEDURE [exp_upbitinerationavailable]
(
	@ayear		int,
	@idupb		varchar(36),
	@kind 		char(1) = 'D'--, -- T -->  Solo Totali ,  D --> Dettagliata e Totali,	 F --> Formule
	--@idsor01	int  = null,
	--@idsor02	int  = null,
	--@idsor03	int  = null,
	--@idsor04	int  = null,
	--@idsor05	int  = null 
)
AS BEGIN
	IF @idupb IS NULL RETURN

---- QUESTA STORED PROCEDURE NASCE PER FORNIRE UN RISCONTRO SUI VALORI RESTITUITI DALLA VISTA upbitinerationavailable 
---- NEL CAMPO differenzadisponibilita 
--------------------------------------------------------------------------------------------------------------------------------- 
---------- PREVISIONE CORRENTE  E VARIAZIONI  PREVISIONE UPB  SU VOCI DI BILANCIO SPESA ESCLUSI TITOLI 5 E 6 ----------------- 
------------------------------------------------------------------------------------------------------------------------------ 
---- I VALORI SONO LETTI DALLE TABELLE TOTALIZZATRICI

---- previsionedisponibile_impegni:  (A) disponibile ad impegnare (creare una nuova fase 1)
---- PREVISIONE CORRENTE  + VARIAZIONI - (MOVIMENTI DI COMPETENZA + RESIDUI FASE 1)
---- disponibilita_impegni :  (B) disponibile della fase 1  rispetto alla fase 2
---- missioniupbnoncontabilizzate:  (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
---- Disptotale: somma dei precedenti (A+B+C)
---- (A) disponibile ad impegnare  + (B) disponibile della fase 1  rispetto alla fase 2 + (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
---- differenzadisponibilita,		--> Differenza Disponibilità  (B-C)

------------------------------------------ cose da  ompletare
------ 1) aggiungere le formule di calcolo della differenza disponibilità, campo utilizzato dalla view TRASF028, di cui già mostriamo dettaglio e totali delle voci che concorrono al calcolo
------ 2) aggiungere il dettaglio, i totali e le formule di calcolo per tutti gli altri campi calcolati dalla view
------ 3) gestire attributi di sicurezza anche se l'UPB mostrato è sempre lo stesso
------ 4) eventualmente valutare di inserire come parametro di input, la possibilità di specificare il dettaglio per le sole previsioni, soli movimenti finanziari, sole missioni attribuite all'UPB ecc..
DECLARE @nfinphase  int
DECLARE @nsecondphase  int
DECLARE @nfasecontab int
DECLARE @finphase 	 varchar(50)
DECLARE @secondphase   varchar(50)
DECLARE @fasecontab varchar(50)

SELECT @nfinphase	 = expensefinphase FROM uniconfig
SELECT @nsecondphase = @nfinphase  + 1 
SELECT @nfasecontab	 = expensephase FROM config WHERE ayear = @ayear

select @finphase = description from expensephase where nphase = @nfinphase
select @secondphase = description from expensephase where nphase = @nsecondphase

select @fasecontab = description from expensephase where nphase = @nfasecontab
CREATE TABLE #upbitinerationavailable
(
	querykind			int,
	kind			char(1),
	ayear				int,
	idupb 				varchar(36),
	codeupb				varchar(50),
	upb					varchar(150),
 	idfin				int,
	codefin				varchar(50),
	fin					varchar(150),
 	upb_currentprev		decimal(19,2),
	upb_previsionvariation decimal(19,2),
	fin_phase_comp			decimal(19,2),
	desc_fin_phase 			varchar(50),					
	second_phase_comp		decimal(19,2),
	desc_second_phase 		varchar(50),					
	fin_phase_resid			decimal(19,2), 
	second_phase_resid		decimal(19,2),
	desc_fase_contab		varchar(50),
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	yitineration int,
	nitineration int,
	description		varchar(200), 
	supposedamount decimal(19,2), 
	supposedfood decimal(19,2), 
	supposedliving decimal(19,2), 
    supposedtravel decimal(19,2), 
	-----------------------------------
	------------- anticipi ------------
	-----------------------------------
	ymov			int,
	nmov			int ,
	descriptionmov		varchar(200), 
	EY_start_amount decimal(19,2),
	---------------------------------------------------
	------------- anticipi su f. economale ------------
	---------------------------------------------------
	idpettycash			int,
	pettycash			varchar(200),
	yoperation			int,
	noperation			int,
	pettycashoperation	varchar(200),
	pettycash_amount	decimal(19,2)
)

CREATE TABLE #totupbitinerationavailable
(
	querykind			int,
	kind			char(1),
	ayear				int,
	idupb 				varchar(36),
	codeupb				varchar(50),
	upb					varchar(150),
 	idfin				int,
	codefin				varchar(50),
	fin					varchar(150),
 	upb_currentprev		decimal(19,2),
	upb_previsionvariation decimal(19,2),
	fin_phase_comp			decimal(19,2),
	desc_fin_phase 			varchar(50),					
	second_phase_comp		decimal(19,2),
	desc_second_phase 		varchar(50),	
	desc_fasecontab			varchar(50),
	fin_phase_resid			decimal(19,2), 
	second_phase_resid		decimal(19,2),
	desc_fase_contab		varchar(50),
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	supposedamount decimal(19,2), 
	supposedfood decimal(19,2), 
	supposedliving decimal(19,2), 
    supposedtravel decimal(19,2), 
	-----------------------------------
	------------- anticipi ------------
	-----------------------------------
	EY_start_amount decimal(19,2),
	---------------------------------------------------
	------------- anticipi su f. economale ------------
	---------------------------------------------------
	pettycash_amount	decimal(19,2)
)


INSERT INTO #upbitinerationavailable
(
		querykind				,
		ayear					,
		idupb 					,
		codeupb					,
		upb						,
 		idfin					,
		codefin					,
		fin						,
 		upb_currentprev			,
		upb_previsionvariation  
	)

  SELECT 1,  @ayear AS ayear ,/*'PREVISIONE CORRENTE e VARIAZIONI 'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, fin.idfin, fin.codefin, fin.title, upbtotal.currentprev, upbtotal.previsionvariation 
		FROM    upbtotal (nolock)
			JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
				JOIN    upb (nolock)	ON upbtotal.idupb = upb.idupb
		WHERE   upbtotal.idupb = @idupb
		AND     ( (fin.flag & 1) <> 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = @ayear
		-- 11/05/2021
		AND		fin.codefin not like '5%'
		AND		fin.codefin not like '6%' 	
		AND     @kind in ('D','P')


INSERT INTO #totupbitinerationavailable
(
		querykind				,
		ayear					,
		idupb 					,
		codeupb					,
		upb						,
 		idfin					,
		codefin					,
		fin						,
 		upb_currentprev			,
		upb_previsionvariation  
	)


   SELECT 1,  @ayear AS ayear ,/*'TOTALE PREVISIONE CORRENTE e VARIAZIONI 'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, fin.idfin, fin.codefin, fin.title,   sum(upbtotal.currentprev), sum(upbtotal.previsionvariation)
 
		FROM    upbtotal (nolock)
			JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
				JOIN    upb (nolock)	ON upbtotal.idupb = upb.idupb
		WHERE   upbtotal.idupb = @idupb
		AND     ( (fin.flag & 1) <> 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = @ayear
		-- 11/05/2021
		AND		fin.codefin not like '5%'
		AND		fin.codefin not like '6%' 
		AND     @kind in ('T','D','P')
GROUP BY upb.idupb, upb.codeupb, upb.title,fin.idfin, fin.codefin, fin.title  


-- previsionedisponibile_impegni:  (A) disponibile ad impegnare (creare una nuova fase 1)
 
-- I VALORI SONO LETTI DALLE TABELLE TOTALIZZATRICI
------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
---------- MOVIMENTI DI COMPETENZA ed EVENTUALI MOVIMENTI RESIDUI (A SECONDA DELLA CONFIGURAZIONE) FASE   BILANCIO ESCLUSI TITOLI 5 E 6 -------------------------- 
------------------------------------------------------------------------------------------------------------------------------------------------------------------ 

INSERT INTO 	       #upbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
 	idfin					,
	codefin					,
	fin						,
	fin_phase_comp			,
	desc_fin_phase 			,						
	fin_phase_resid		 
	)
  SELECT  2,  @ayear AS ayear ,/*'MOV. COMPETENZA ED EVENTUALI RESIDUI (A SECONDA DELLA CONFIGURAZIONE) FASE BILANCIO  'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, fin.idfin, fin.codefin, fin.title, 
			  upbexpensetotal.totalcompetency, @finphase,
			  CASE
					WHEN	config.fin_kind = 2
					THEN	upbexpensetotal.totalarrears 
				ELSE 0
			  END AS totalarrears 
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
			JOIN    upb (nolock)	ON upbexpensetotal.idupb = upb.idupb
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase
		JOIN config ON config.ayear = fin.ayear
		WHERE upbexpensetotal.idupb = @idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = @ayear AND config.ayear = @ayear
		-- 11/05/2021
		AND		fin.codefin not like '5%'
		AND		fin.codefin not like '6%'
		AND     @kind in ('D','F')


INSERT INTO #totupbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
 	idfin					,
	codefin					,
	fin						,
	fin_phase_comp			,
	desc_fin_phase 			,						
	fin_phase_resid		 
	)

   SELECT  2,  @ayear AS ayear ,/*'MOV. COMPETENZA ED EVENTUALI RESIDUI (A SECONDA DELLA CONFIGURAZIONE) FASE BILANCIO  'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, fin.idfin, fin.codefin, fin.title, 
		 SUM(upbexpensetotal.totalcompetency), 
		 @finphase,
		 SUM(CASE
				WHEN config.fin_kind = 2
				THEN  upbexpensetotal.totalarrears 
				ELSE 0
			END ) AS totalarrears 
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
			JOIN    upb (nolock)	ON upbexpensetotal.idupb = upb.idupb
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase
		JOIN config ON config.ayear = fin.ayear
		WHERE upbexpensetotal.idupb = @idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = @ayear AND config.ayear = @ayear
		-- 11/05/2021
		AND		fin.codefin not like '5%'
		AND		fin.codefin not like '6%'
		AND     @kind in ('T','D','F')
  GROUP BY  uniconfig.expensefinphase, upbexpensetotal.nphase , upb.idupb, upb.codeupb, upb.title,fin.idfin, fin.codefin, fin.title  
------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
---------- MOVIMENTI DI COMPETENZA ed EVENTUALI MOVIMENTI RESIDUI (A SECONDA DELLA CONFIGURAZIONE) FASE SUCCESSIVA BILANCIO ESCLUSI TITOLI 5 E 6 ----------------- 
------------------------------------------------------------------------------------------------------------------------------------------------------------------ 

INSERT INTO 	       #upbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
 	idfin					,
	codefin					,
	fin						,				
	second_phase_comp		,
	desc_second_phase 		,					
	second_phase_resid		 
	)
  SELECT  3,  @ayear AS ayear ,/*'MOV. COMPETENZA ed EVENTUALI RESIDUI (A SECONDA DELLA CONFIGURAZIONE) FASE BILANCIO  'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, fin.idfin, fin.codefin, fin.title, 
			  upbexpensetotal.totalcompetency, @secondphase,
			  CASE
					WHEN	config.fin_kind = 2
					THEN	upbexpensetotal.totalarrears 
				ELSE 0
			  END AS totalarrears
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
			JOIN    upb (nolock)	ON upbexpensetotal.idupb = upb.idupb
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase +1
		JOIN config ON config.ayear = fin.ayear
		WHERE upbexpensetotal.idupb = @idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = @ayear AND config.ayear = @ayear
		-- 11/05/2021
		AND		fin.codefin not like '5%'
		AND		fin.codefin not like '6%'
		AND     @kind in ('D','F')

------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
---------- MOVIMENTI DI COMPETENZA ed EVENTUALI MOVIMENTI RESIDUI (A SECONDA DELLA CONFIGURAZIONE) FASE SUCCESSIVA BILANCIO ESCLUSI TITOLI 5 E 6 ----------------- 
------------------------------------------------------------------------------------------------------------------------------------------------------------------ 
 INSERT INTO #totupbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
 	idfin					,
	codefin					,
	fin						,
	fin_phase_comp			,
	desc_fin_phase 			,						
	fin_phase_resid		 
	)

   SELECT  3,  @ayear AS ayear ,/*'MOV. COMPETENZA ED EVENTUALI RESIDUI (A SECONDA DELLA CONFIGURAZIONE) FASE BILANCIO  'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, fin.idfin, fin.codefin, fin.title, 
		 SUM(upbexpensetotal.totalcompetency), 
		 @secondphase,
		 SUM(CASE
				WHEN config.fin_kind = 2
				THEN  upbexpensetotal.totalarrears 
				ELSE 0
			END ) AS totalarrears 
 
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
			JOIN    upb (nolock)	ON upbexpensetotal.idupb = upb.idupb
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase +1
		JOIN config ON config.ayear = fin.ayear
		WHERE upbexpensetotal.idupb = @idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = @ayear AND config.ayear = @ayear
		-- 11/05/2021
		AND		fin.codefin not like '5%'
		AND		fin.codefin not like '6%'
		AND     @kind in ('T','D','F')
  GROUP BY  uniconfig.expensefinphase, upbexpensetotal.nphase , upb.idupb, upb.codeupb, upb.title,fin.idfin, fin.codefin, fin.title
		
--------------------------------------------------------------------------------
---------------------------  missioni attribuite all'UPB ------------------------           
--------------------------------------------------------------------------------


INSERT INTO 	       #upbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	yitineration			,
	nitineration			,
	description				,
	supposedamount			, 
	supposedfood			, 
	supposedliving			, 
    supposedtravel		  
	)


 -- (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
	 SELECT 4,  @ayear AS ayear ,/*'MISSIONI ATTRIBUITE ALL''UPB  'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, 
			 itineration.yitineration, itineration.nitineration,itineration.description,ISNULL(itineration.supposedamount,0) as supposedamount, ISNULL(itineration.supposedfood,0) as supposedfood, 
			 ISNULL(itineration.supposedliving,0) as supposedliving, ISNULL(itineration.supposedtravel,0) as supposedtravel
		 FROM itineration
		 			JOIN    upb (nolock)	ON itineration.idupb = upb.idupb
		WHERE itineration.idupb = @idupb 
		and itineration.yitineration<= @ayear 
		and isnull(itineration.active,'S') <> 'N' 
		AND iditinerationstatus <> 7 --Non considero le missioni annullate
		--- MISSIONE NON SALDATA  
		AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(NOLOCK)
										JOIN expense s							(NOLOCK)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= @ayear	AND (mov.movkind = 4))
		AND NOT EXISTS
						(SELECT * FROM itinerationsorting (NOLOCK) 
						WHERE iditineration = itineration.iditineration 
						AND idsor = (SELECT idsor FROM sorting (NOLOCK) WHERE sortcode = 'Missione_Impegnata'))
		AND     @kind in ('D','M')
 -- (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)

INSERT INTO 	       #totupbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	supposedamount			, 
	supposedfood			, 
	supposedliving			, 
    supposedtravel		  
	)
	 SELECT  4,  @ayear AS ayear ,/*'MISSIONI ATTRIBUITE ALL''UPB  'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, 
			 SUM(ISNULL(itineration.supposedamount,0)) as supposedamount, SUM(ISNULL(itineration.supposedfood,0)) as supposedfood, 
			 SUM(ISNULL(itineration.supposedliving,0)) as supposedliving, SUM(ISNULL(itineration.supposedtravel,0)) as supposedtravel
		 FROM itineration
		 			JOIN    upb (nolock)	ON itineration.idupb = upb.idupb
		WHERE itineration.idupb = @idupb 
		and itineration.yitineration<= @ayear 
		and isnull(itineration.active,'S') <> 'N' 
		AND iditinerationstatus <> 7 --Non considero le missioni annullate
		--- MISSIONE NON SALDATA  
		AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(NOLOCK)
										JOIN expense s							(NOLOCK)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= @ayear	AND (mov.movkind = 4))
		AND NOT EXISTS
						(SELECT * FROM itinerationsorting (NOLOCK) 
						WHERE iditineration = itineration.iditineration 
						AND idsor = (SELECT idsor FROM sorting (NOLOCK) WHERE sortcode = 'Missione_Impegnata'))
		AND     @kind in ('T','D','M')
		GROUP BY  upb.idupb, upb.codeupb, upb.title
		
----------------------------------------------------------------------------------------------------------- 
--------------------------- CONTABILIZZAZIONI anticipo missioni attribuite all'UPB ------------------------           
-----------------------------------------------------------------------------------------------------------   


INSERT INTO 	       #upbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
 	
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	yitineration			,
	nitineration			,
	description				,
	supposedamount			, 
	supposedfood			, 
	supposedliving			, 
    supposedtravel			, 
	-----------------------------------
	------------- anticipi ------------
	-----------------------------------
	ymov					,
	nmov					,
	desc_fase_contab 		,
	descriptionmov			, 
	EY_start_amount			
	)
	SELECT 5,  @ayear AS ayear ,/*'CONTABILIZZAZIONI ANTICIPO MISSIONE'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, 
			 itineration.yitineration, itineration.nitineration,itineration.description,ISNULL(itineration.supposedamount,0) as supposedamount, ISNULL(itineration.supposedfood,0) as supposedfood, 
			 ISNULL(itineration.supposedliving,0) as supposedliving, ISNULL(itineration.supposedtravel,0) as supposedtravel,
			 s.ymov,s.nmov,@fasecontab,s.description, EY_start.amount
			FROM expenseitineration mov			(nolock)
			JOIN expense s						(nolock)		ON s.idexp = mov.idexp
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			JOIN    upb (nolock)	ON itineration.idupb = upb.idupb
			LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE (/*(mov.movkind = 4)OR*/(mov.movkind = 6)) 
			AND itineration.idupb = @idupb	
			and EY_start.ayear <= @ayear	 
			and itineration.yitineration<= @ayear
			and isnull(itineration.active,'S') <> 'N' 
			AND iditinerationstatus <> 7 --Non considero le missioni annullate
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= @ayear	AND (mov.movkind = 4)) 
			AND NOT EXISTS
						(SELECT * FROM itinerationsorting (NOLOCK) 
						WHERE iditineration = itineration.iditineration 
						AND idsor = (SELECT idsor FROM sorting (NOLOCK) WHERE sortcode = 'Missione_Impegnata'))
		 	AND     @kind in ('D','C')

INSERT INTO 	       #totupbitinerationavailable
(
	querykind				,
	ayear					,
	idupb 					,
	codeupb					,
	upb						,
 	
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	supposedamount			, 
	supposedfood			, 
	supposedliving			, 
    supposedtravel			, 
	desc_fase_contab		,
	-----------------------------------
	------------- anticipi ------------
	-----------------------------------
	EY_start_amount			
	)
		 SELECT   5,  @ayear AS ayear ,/*' TOTALE CONTABILIZZAZIONI ANTICIPO MISSIONE'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, 
		  SUM(ISNULL(itineration.supposedamount,0)) as supposedamount, SUM(ISNULL(itineration.supposedfood,0)) as supposedfood, 
			 SUM(ISNULL(itineration.supposedliving,0)) as supposedliving, SUM(ISNULL(itineration.supposedtravel,0)) as supposedtravel, @fasecontab, SUM(EY_start.amount)
			FROM expenseitineration mov			(nolock)
			JOIN expense s						(nolock)		ON s.idexp = mov.idexp
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
			JOIN    upb (nolock)	ON itineration.idupb = upb.idupb
			LEFT OUTER JOIN expenseyear EY_start (NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			WHERE (/*(mov.movkind = 4)OR*/(mov.movkind = 6)) 
			AND itineration.idupb = @idupb	
			and EY_start.ayear <= @ayear	 
			and itineration.yitineration<= @ayear
			and isnull(itineration.active,'S') <> 'N' 
			AND iditinerationstatus <> 7 --Non considero le missioni annullate
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <= @ayear	AND (mov.movkind = 4)) 
			AND NOT EXISTS
						(SELECT * FROM itinerationsorting (NOLOCK) 
						WHERE iditineration = itineration.iditineration 
						AND idsor = (SELECT idsor FROM sorting (NOLOCK) WHERE sortcode = 'Missione_Impegnata'))
			AND     @kind in ('T','D','C')
			GROUP BY upb.idupb, upb.codeupb, upb.title
------------------------------------------------------------------------------------------------------------------------------ 
--------------------------- CONTABILIZZAZIONI anticipo missioni attribuite all'UPB su FONDO ECONOMALE ------------------------           
------------------------------------------------------------------------------------------------------------------------------ 
		   
INSERT INTO #upbitinerationavailable
(
	querykind			,
	ayear				,
	idupb 				,
	codeupb				,
	upb					,
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	yitineration ,
	nitineration ,
	description	 ,
	supposedamount , 
	supposedfood , 
	supposedliving , 
    supposedtravel , 
	---------------------------------------------------
	------------- anticipi su f. economale ------------
	---------------------------------------------------
	idpettycash			,
	pettycash 			,
	yoperation			,
	noperation			,
	pettycashoperation  ,
	pettycash_amount	
)


SELECT 6,  @ayear AS ayear ,/*'CONTABILIZZAZIONI ANTICIPO MISSIONE su F. ECONOMALE'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, 
itineration.yitineration, itineration.nitineration,itineration.description,ISNULL(itineration.supposedamount,0) as supposedamount, ISNULL(itineration.supposedfood,0) as supposedfood, 
ISNULL(itineration.supposedliving,0) as supposedliving, ISNULL(itineration.supposedtravel,0) as supposedtravel,
p.idpettycash, pettycash.description, p.yoperation,p.noperation,p.description, p.amount
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p (NOLOCK) 	ON mov.idpettycash = p.idpettycash
													AND mov.yoperation = p.yoperation
													AND mov.noperation = p.noperation
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
				JOIN    upb (nolock)	ON itineration.idupb = upb.idupb
			JOIN pettycash (nolock)		ON pettycash.idpettycash = p.idpettycash
			WHERE   mov.movkind = 6  
			AND itineration.idupb = upb.idupb	 
			and p.yoperation <= @ayear
			and itineration.yitineration<= @ayear
			and isnull(itineration.active,'S') <> 'N' 
			AND iditinerationstatus <> 7 --Non considero le missioni annullate
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <=@ayear	AND (mov.movkind = 4))
			AND NOT EXISTS
						(SELECT * FROM itinerationsorting (NOLOCK) 
						WHERE iditineration = itineration.iditineration 
						AND idsor = (SELECT idsor FROM sorting (NOLOCK) WHERE sortcode = 'Missione_Impegnata'))
 			AND     @kind in ('D','C')


INSERT INTO #totupbitinerationavailable
(
	querykind			,
	ayear				,
	idupb 				,
	codeupb				,
	upb					,
	-----------------------------------
	------------- missioni ------------
	-----------------------------------
	supposedamount , 
	supposedfood , 
	supposedliving , 
    supposedtravel , 
	---------------------------------------------------
	------------- anticipi su f. economale ------------
	---------------------------------------------------
	pettycash_amount	
)
 	SELECT  6,  @ayear AS ayear ,/*'CONTABILIZZAZIONI ANTICIPO MISSIONE su F. ECONOMALE'AS tipo,*/ @idupb as idupb, upb.codeupb, upb.title, 
			 SUM(ISNULL(itineration.supposedamount,0)) as supposedamount,  SUM(ISNULL(itineration.supposedfood,0)) as supposedfood, 
			 SUM(ISNULL(itineration.supposedliving,0)) as supposedliving, SUM(ISNULL(itineration.supposedtravel,0)) as supposedtravel, SUM(p.amount) 
			FROM pettycashoperationitineration mov (NOLOCK) 
			JOIN pettycashoperation p (NOLOCK) 	ON mov.idpettycash = p.idpettycash
													AND mov.yoperation = p.yoperation
													AND mov.noperation = p.noperation
			JOIN itineration 					(nolock)		ON itineration.iditineration= mov.iditineration
				JOIN    upb (nolock)	ON itineration.idupb = upb.idupb
			WHERE   mov.movkind = 6  
			AND itineration.idupb = upb.idupb	 
			and p.yoperation <= @ayear
			and itineration.yitineration<= @ayear
			and isnull(itineration.active,'S') <> 'N' 
			AND iditinerationstatus <> 7 --Non considero le missioni annullate
			--- MISSIONE NON SALDATA  
			AND NOT EXISTS (SELECT * FROM   expenseitineration mov					(nolock)
										JOIN expense s							(nolock)		ON s.idexp = mov.idexp
										LEFT OUTER JOIN expenseyear EY_start	(NOLOCK) 		ON EY_start.idexp = mov.idexp AND EY_start.ayear = s.ymov
			 							WHERE itineration.iditineration= mov.iditineration and EY_start.ayear <=@ayear	AND (mov.movkind = 4))
			AND NOT EXISTS
						(SELECT * FROM itinerationsorting (NOLOCK) 
						WHERE iditineration = itineration.iditineration 
						AND idsor = (SELECT idsor FROM sorting (NOLOCK) WHERE sortcode = 'Missione_Impegnata'))
 			AND     @kind in ('T','D','C')
						GROUP BY upb.idupb, upb.codeupb, upb.title

--select * from #upbitinerationavailable
--select * from #totupbitinerationavailable
 
 UPDATE #upbitinerationavailable SET kind = 'R'
 UPDATE #totupbitinerationavailable SET kind = 'T'

-------------------------------------------------------
---------------- CALCOLO DELLE FORMULE ----------------
-------------------------------------------------------
---  (A) disponibile ad impegnare 
---  (B) disponibile della fase 1
---  (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
---  Differenza Disponibilità = come B-C 

DECLARE @A_disponibilita_ad_impegnare decimal(19,2)
DECLARE @B_disponibilitafase_1_rispetto_fase_2 decimal(19,2)
DECLARE @C_missioni_attribuite_UPB_non_contabilizzate  decimal(19,2)


IF (@kind = 'T') 
BEGIN
	---  (A) disponibile ad impegnare 
	---  (B) disponibile della fase 1
	---  (C) missioni attribuite all'UPB ma non contabilizzate (in anticipo o saldo)
	---  Differenza Disponibilità = come B-C 
		 
	SELECT 
			T.ayear			as 'Eserc.'			,
			T.codeupb		as 'Cod. UPB'		,
			T.upb			as 'UPB'			,  
			T.codefin		as 'Cod. Bilancio'	,
			T.fin			as 'Bilancio'		,
			case when 	 T.querykind in (2,3) then 'Tot. Movimenti finanziari' else null end	as 'Movimenti finanziari'	,
			T.desc_fin_phase		as 'Fase',
			T.fin_phase_comp		as 'Competenza',
			T.fin_phase_resid		as 'Residui',    
			case when 	 T.querykind in (4) then 'Tot. Elenco Missioni' else null end	 as 'Missioni',
			T.supposedamount	as 'Costo presunto missione'	,
			T.supposedfood		as 'Costo presunto pasti '	,
			T.supposedliving	as 'Costo presunto soggiorno '  ,
			T.supposedtravel	as 'Costo presunto viaggio '	,
			CASE when 	 T.querykind in (5,6) then 'Tot. Anticipi Missione' else null end	  as 'Anticipo'/* */				,
			CASE WHEN  T.querykind = 5  THEN @fasecontab ELSE NULL END as 'Fase finanziaria anticipo'/* */				,
			CASE WHEN  T.querykind = 5  THEN T.EY_start_amount ELSE NULL END as 'Importo contabilizzaizone su movim. finanziario'/* */	,	
			CASE WHEN  T.querykind = 6  THEN T.pettycash_amount  ELSE NULL END as 'Importo contabilizzato su F. Economale'/* */		,	
			 T.querykind
	FROM    #totupbitinerationavailable T	where  T.querykind <> 1 /*escludo previsioni e variazioni*/	
	order by T.querykind 

	RETURN
END
			
IF (@kind = 'D') 
BEGIN
	--- (A) disponibile ad impegnare 
	--- (B) disponibile della fase 1 rispetto alla fase 2
	--- (C) residuo missioni attribuite all'UPB ma non contabilizzate completamente
	--- Differenza Disponibilità = come B-C 
	SELECT  
			U.ayear			as 'Eserc.'			,
			U.codeupb		as 'Cod. UPB'		,
			U.upb			as 'UPB'			,  
			U.codefin		as 'Cod. Bilancio'	,
			U.fin			as 'Bilancio'		,
			case when 	 U.querykind in (2,3) then 'Movimento finanziario' else null end	as 'Movimenti finanziari'	,
			U.desc_fin_phase		as 'Fase',

			U.fin_phase_comp		as 'Competenza',
			U.fin_phase_resid		as 'Residui',    
			case when 	 U.querykind in (4) then 'Missione' else null end	 as 'Missioni',
			
			U.yitineration	as 'Eserc. Missione'		,
			U.nitineration	as 'Numero Missione'	,
			U.description	as 'Missione'		,
			U.supposedamount  as 'Costo presunto'	,
			U.supposedfood  as 'Costo presunto pasti '	,
			U.supposedliving  as 'Costo presunto soggiorno ' 				,
			U.supposedtravel  as 'Costo presunto viaggio '/* */				,
			case when 	 U.querykind in (5,6) then 'Anticipo Missione' else null end	  as 'Anticipo'/* */		,
			U.desc_fase_contab  as 'Fase finanziaria anticipo'/* */				,
			U.EY_start_amount as 'Importo anticipo contabilizzato',
			U.pettycash as 'Fondo Economale'			,
			U.yoperation	as 'Eserc. operazione'		,
			U.noperation	as 'Num. operazione'		,		
			U.pettycash_amount  as 'Importo contabilizzato su F. Economale'/* */		,
			 U.querykind, U.kind 	
	FROM    #upbitinerationavailable U		 where  U.querykind <> 1 /*escludo previsioni e variazioni*/

	UNION
		SELECT   
			T.ayear			as 'Eserc.'			,
			T.codeupb		as 'Cod. UPB'		,
			T.upb			as 'UPB'			,  
			T.codefin		as 'Cod. Bilancio'	,
			T.fin			as 'Bilancio'		,
		case when 	 T.querykind in (2,3) then 'Tot. Movimenti finanziari' else null end	as 'Movimenti finanziari'	,
			T.desc_fin_phase		as 'Fase',
			T.fin_phase_comp		as 'Competenza',
			T.fin_phase_resid		as 'Residui',    
			case when 	 T.querykind in (4) then 'Tot. Elenco Missioni' else null end	 as 'Missioni',
			null	as 'Eserc. Missione'		,
			null	as 'Numero Missione'	,
			null	as 'Missione'		,
			T.supposedamount  as 'Costo presunto'	,
			T.supposedfood  as 'Costo presunto pasti '	,
			T.supposedliving  as 'Costo presunto soggiorno ' 				,
			T.supposedfood  as 'Costo presunto viaggio '/* */				,
			case when 	 T.querykind in (5,6) then 'Tot. Anticipi Missione' else null end	  as 'Anticipo'/* */					,
			T.desc_fase_contab as 'Fase finanziaria anticipo'/* */		,
			T.EY_start_amount as 'Importo anticipo contabilizzato',
			null as 'Fondo Economale'			,
			null	as 'Eserc. operazione'		,
			null	as 'Num. operazione'		,		 
			T.pettycash_amount as 'Importo contabilizzato su F. Economale'/* */	,
			  T.querykind, T.kind
	FROM    #totupbitinerationavailable T  	 where  T.querykind <> 1 /*escludo previsioni e variazioni*/
	ORDER BY querykind , kind
	RETURN
END

/*
IF (@kind = 'P') 
BEGIN
	---  previsione attuale (previsione iniziale  +  variazioni)
		SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.upb_currentprev		,
			U.upb_previsionvariation  
			FROM #upbitinerationavailable U  
	WHERE U.querykind = 1 
	UNION 
	SELECT  T.ayear					,
			T.codeupb				,
			T.upb					,  
			T.codefin				,
			T.fin					,
			T.upb_currentprev		,
			T.upb_previsionvariation  
			FROM #upbitinerationavailable T  
	WHERE T.querykind = 1 
	RETURN
END

IF (@kind = 'F') 
BEGIN
	--- totale movimenti finanziari di fase 1
	--- totale movimenti finanziari di fase 2
		SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.desc_fin_phase		,
			U.ymov					,
			U.nmov					,
			U.description			,
			U.fin_phase_comp		,
			U.fin_phase_resid		 
	FROM    #upbitinerationavailable U  
			 
	WHERE U.querykind = 2 
	UNION
	SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.desc_fin_phase		,
			null/*U.ymov*/			,
			null/*U.nmov*/			,
			null/*U.description*/	,
			T.fin_phase_comp		,
			T.fin_phase_resid		 
	FROM    #upbitinerationavailable U JOIN #totupbitinerationavailable T
	ON U.ayear = T.ayear AND  U.idupb = T.idupb AND U.querykind = T.querykind
	WHERE U.querykind = 2 
	UNION
	SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.desc_second_phase		,
			U.ymov					,
			U.nmov					,
			U.description			,
			U.second_phase_comp		,
			U.second_phase_resid	 
	FROM    #upbitinerationavailable U  
	WHERE U.querykind = 3 
	UNION
	SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.desc_second_phase		,
			null/*U.ymov*/			,
			null/*U.nmov*/			,
			null/*U.description*/	,
			T.second_phase_comp		,
			T.second_phase_resid	 
	FROM   #upbitinerationavailable U JOIN #totupbitinerationavailable T
	ON U.ayear = T.ayear AND  U.idupb = T.idupb AND U.querykind = T.querykind
	WHERE U.querykind = 3 
	RETURN
END

IF (@kind = 'M') 
BEGIN
	--- elenco missioni attribuite all'UPB
		SELECT  U.ayear				,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.yitineration			,
			U.nitineration			,
			U.description			,
			U.supposedamount		,
			U.supposedfood			,
			U.supposedfood			,
			U.supposedtravel		
	FROM    #upbitinerationavailable U  
			 
	WHERE U.querykind = 4 
	UNION

	SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			null /*U.yitineration*/	,
			null /*U.nitineration*/	,
			null /*U.description*/	,
			U.supposedamount		,
			U.supposedfood			,
			U.supposedfood			,
			U.supposedtravel		
	FROM   #upbitinerationavailable U JOIN #totupbitinerationavailable T
	ON U.ayear = T.ayear AND  U.idupb = T.idupb  AND U.querykind = T.querykind
	WHERE U.querykind = 4 
	RETURN
END

IF (@kind = 'C') 
BEGIN
	--- elenco anticipi contabilizzati missioni attribuite all'UPB
		SELECT  U.ayear				,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.yitineration			,
			U.nitineration			,
			U.description			,
			U.supposedamount		,
			U.supposedfood			,
			U.supposedfood			,
			U.supposedtravel		,
			U.desc_fase_contab		,
			U.ymov					,
			U.nmov					,
			null /* */				,
			null /* */				,
			U.EY_start_amount		 
	FROM    #upbitinerationavailable U  
			 
	WHERE U.querykind = 5 
	UNION

	SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			null /*U.yitineration*/	,
			null /*U.nitineration*/	,
			null /*U.description*/	,
			T.supposedamount		,
			T.supposedfood			,
			T.supposedfood			,
			T.supposedtravel		,
			null /*U.desc_fase_contab*/		,
			null /*U.ymov*/					,
			null /*U.nmov*/					,
			null /* */						,
			null /* */						,
			T.EY_start_amount
	FROM   #upbitinerationavailable U JOIN #totupbitinerationavailable T
	ON U.ayear = T.ayear AND  U.idupb = T.idupb  AND U.querykind = T.querykind
	WHERE U.querykind = 5 

	--- elenco anticipi su partite di giro contabilizzati su Fondo Economale
		SELECT  U.ayear				,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			U.yitineration			,
			U.nitineration			,
			U.description			,
			U.supposedamount		,
			U.supposedfood			,
			U.supposedfood			,
			U.supposedtravel		,
			U.pettycash 			,
			U.yoperation			,
			U.noperation			,
			U.pettycashoperation	,
			U.pettycash_amount	
	FROM    #upbitinerationavailable U  
			 
	WHERE U.querykind = 5 
	UNION

	SELECT  U.ayear					,
			U.codeupb				,
			U.upb					,  
			U.codefin				,
			U.fin					,
			null /*U.yitineration*/	,
			null /*U.nitineration*/	,
			null /*U.description*/	,
			T.supposedamount		,
			T.supposedfood			,
			T.supposedfood			,
			T.supposedtravel		,
			null /*U.pettycash*/ 	,
			null /*U.yoperation*/	,
			null /*U.noperation*/	,
			null /*U.pettycashoperation*/	,
			null /*U.pettycash_amount*/	
	FROM   #upbitinerationavailable U JOIN #totupbitinerationavailable T
	ON U.ayear = T.ayear AND  U.idupb = T.idupb  AND U.querykind = T.querykind
	WHERE U.querykind = 5 

	RETURN
	
END			
*/
		 
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
