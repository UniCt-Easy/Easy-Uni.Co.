
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_coordanal_dm2012_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_coordanal_dm2012_new]
GO
	
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE rpt_statopatrimoniale_coordanal_dm2012_new

--setuser'amministrazione'
--setuser'amm'
--exec rpt_statopatrimoniale_coordanal_dm2012_new 2922, {ts '2022-01-01 00:00:00'}, {ts '2022-01-15 00:00:00'}, '%','N','N', 2033 ,'S',null, null, 'N'
--exec  rpt_statopatrimoniale_coordanal_dm2012_new 2022, {ts '2022-01-01 00:00:00'}, {ts '2022-01-15 00:00:00'}, '%', 'S', 'N', NULL, 'N', NULL, NULL, 'N', NULL, NULL, NULL, NULL, NULL
--exec  rpt_statopatrimoniale_coordanal_dm2012_new 2022, {ts '2022-01-01 00:00:00'}, {ts '2022-01-15 00:00:00'}, '%', 'S', 'S', NULL, 'N', NULL, NULL, 'N', NULL, NULL, NULL, NULL, NULL
--exec  rpt_statopatrimoniale_coordanal_dm2012_new 2022, {ts '2022-01-01 00:00:00'}, {ts '2022-12-22 00:00:00'}, '%', 'S', 'N', 5468, 'N', NULL, NULL, 'N', NULL, NULL, NULL, NULL, NULL
	(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@showcoordanal char(1) , -- Mostra figli
	@idsor1 int, -- Se valorizzato viene mostrato
	@showidsor1child char(1), -- Includi figli

	@idsor2 int=null,	@idsor3 int=null,	
	@apertura   varchar(1),
	@idsor01 int=null,	@idsor02 int=null,	@idsor03 int=null,	@idsor04 int=null,	@idsor05 int=null
	)
	AS BEGIN

	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
		SET @idupb=@idupb+'%'
	END
	-- Conto Economico Anno Precedente
	DECLARE @firstdayPY datetime
	DECLARE @lastdayPY datetime
	SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
	SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)
	
	declare @ayearPrec int
	set @ayearPrec = @ayear - 1

	DECLARE @Mostracoordianataanalitica1 char(1)
	SELECT @Mostracoordianataanalitica1= isnull(paramvalue,'N') 
	FROM reportadditionalparam WHERE paramname = 'Mostracoordianataanalitica1'
	and reportname = 'statopatrimonialedm2014_new'


	--	(*) Se @idsor1 valorizzata  e se
	---  @showidsor1child =  S totalizzo i figli, scrive idsor01 nell'intestazione
	---  @showidsor1child =  N filtra solo per la coordinata indicata e , scrive idsor01 nell'intestazione
	--	se showcoordanal = S restituisce in out tutti i figli, che saranno visualizzati nell'intestazione 

DECLARE @ANALITICA1 TABLE(_idsor1 int)


-- VALORIZZO @idsor1 E NON VOGLIO VEDERE I FIGLI, VOGLIO SOLO I DATI DI @idsor1
if ((@idsor1 is not null) and  @showidsor1child = 'N')
Begin
	insert into @ANALITICA1 select @idsor1		--> [***]
	
End	

-- VALORIZZO @idsor1 E VOGLIO TOTALIZZARE I FIGLI		
if ((@idsor1 is not null ) and  @showidsor1child = 'S')
Begin
	insert into @ANALITICA1 (_idsor1)			--> [***]
	select distinct entrydetail.idsor1 
	from entrydetail 
	join entry 
		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	join sortinglink SLK1
		on SLK1.idchild = entrydetail.idsor1 
	where entry.yentry = @ayear and entry.adate BETWEEN @start AND @stop
		AND (entrydetail.idupb like @idupb  OR @idupb = '%')
		AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		and  (SLK1.idparent = @idsor1)
		AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
End	
 -- [***] Questo riempimento di @ANALITICA1 verrà usato solo per i conti d'ordine

--	Il par. MOSTRA COORDINATA ANALITICA entra in gioco quando idsor1 è null, 
--	se MOSTRA COORDINATA ANALITICA = S allora vogliamo vedere tutte le idsor1
--	se MOSTRA COORDINATA ANALITICA = N vogliamo la stampa senza considerare le idsor1, ossia quella 'vecchia'

-- NON VALORIZZO @idsor1 MA VOGLIO VEDERE TUTTE LE @idsor1
if(@idsor1 is null AND @Mostracoordianataanalitica1 = 'S')
Begin
	insert into @ANALITICA1 (_idsor1)
	select distinct entrydetail.idsor1 
	from entrydetail 
	join entry 
		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	join sortinglink SLK1
		on SLK1.idchild = entrydetail.idsor1 
	where entry.yentry = @ayear and entry.adate BETWEEN @start AND @stop
		AND (entrydetail.idupb like @idupb  OR @idupb = '%')
		AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
end

	CREATE TABLE #STRUTTURA
	(nlevel int ,				label varchar(200),			codepatrimony varchar(200),		 
	_curramountAttivo decimal(19,2),	_prevamountAttivo decimal(19,2), 	
	_curramountPassivo decimal(19,2),	_prevamountPassivo decimal(19,2), 	

	 kind char(10) /*Costi o Ricavi, Voce aggregata, SuTotali e Totali */, 
	 parent_label varchar(300), segno int, 
	 _idsor1 int,
	 mostra char(1),-- Assume valore S o N o P.		Se S verrà mostrata nella stampa, se N non verrà passata al report, 
												--	Se P verrà passata al report e mostrata traparentesi solo l'importo, la denominazione verrà nascosta
	 ordinestampa int --identity(1,1)
	 )  
	
	CREATE TABLE #IMPORTI_CLASS
	(nlevel int ,				label varchar(200),			codepatrimony varchar(200),		 
	_curramountAttivo decimal(19,2),	_prevamountAttivo decimal(19,2), 	
	_curramountPassivo decimal(19,2),	_prevamountPassivo decimal(19,2), 	

	 kind char(10) /*Costi o Ricavi, Voce aggregata, SuTotali e Totali */, 
	 parent_label varchar(300), segno int, 
	 _idsor1 int,
	 mostra char(1),-- Assume valore S o N o P.		Se S verrà mostrata nella stampa, se N non verrà passata al report, 
												--	Se P verrà passata al report e mostrata traparentesi solo l'importo, la denominazione verrà nascosta
	 ordinestampa int --identity(1,1)
	 --ordinestampa_in int identity(1,1)
	 )  



-- SE VOGLIO VEDERLE TUTTE O VOGLIO VEDERE ANCHE I FIGLI, USO @ANALITICA1
if ((@idsor1 is null) or (@idsor1 is not null and @showcoordanal = 'S'))
Begin
		 -------------------------------------------------------------------------------------------------
		 --------------------------------------- RICAVI --------------------------------------------------
		 -------------------------------------------------------------------------------------------------

		 ---------------------------------------------	A) IMMOBILIZZAZIONI	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'A) IMMOBILIZZAZIONI', null, 0,0,0,0, 'A' ,null,null , _idsor1, 'S',10 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 2,'I.IMMATERIALI', null, 0,0,0,0, 'A' ,null, 1, _idsor1,'S' ,20 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'1) Costi di impianto, di ampliamento e di sviluppo', 'A) I 1)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S' ,30 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'2) Diritti di brevetto e diritti di utilizzazione delle opere dell''ingegno', 'A) I 2)', 0,0,0,0, 'A', 'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',40 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'3) Concessioni, licenze, marchi e diritti simili', 'A) I 3)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',50 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'4) Immobilizzazioni in corso ed acconti', 'A) I 4)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',60 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'5) Altre immobilizzazioni immateriali', 'A) I 5)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',70 from  @ANALITICA1
		---------------------------------------------	TOTALE IMMOBILIZZAZIONI IMMATERIALI	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE IMMOBILIZZAZIONI IMMATERIALI', null, 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, _idsor1,'S',80 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 2,'II.MATERIALI', null, 0,0,0,0, 'A' ,null, 1, _idsor1,'S',90 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'1) Terreni e fabbricati', 'A) II 1)', 0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',100 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'2) Impianti e attrezzature', 'A) II 2)',  0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1 , _idsor1,'S',110 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'3) Attrezzature scientifiche', 'A) II 3)',  0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',120 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'4) Patrimonio librario, opere d''arte, d''antiquariato e museali', 'A) II 4)',  0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1 , _idsor1,'S' ,130 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'5) Mobili ed arredi', 'A) II 5)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',140 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'6) Immobilizzazioni in corso e acconti', 'A) II 6)',  0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',150 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'7) Altre immobilizzazioni materiali', 'A) II 7)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1 , _idsor1,'S' ,160 from  @ANALITICA1
		---------------------------------------------	TOTALE IMMOBILIZZAZIONI MATERIALI	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE IMMOBILIZZAZIONI MATERIALI', null, 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, _idsor1,'S',170 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 2,'III FINANZIARIE', 'A) III', 0,0,0,0, 'A' ,null, 1, _idsor1,'S' ,180 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE IMMOBILIZZAZIONI FINANZIARIE', 'A) III', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, _idsor1,'S' ,190 from  @ANALITICA1 
		---------------------------------------------	TOTALE IMMOBILIZZAZIONI A	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE IMMOBILIZZAZIONI (A)', null, 0,0,0,0, 'A' ,'TOTALE ATTIVO', 1, _idsor1,'S' ,200 from  @ANALITICA1

		-----------------------------------------------	B) ATTIVO CIRCOLANTE	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'B) ATTIVO CIRCOLANTE', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S' ,210 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'I RIMANENZE', 'B) I', 0,0,0,0, 'A' ,'TOTALE RIMANENZE', 1, _idsor1,'S',220 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE RIMANENZE', null, 0,0,0,0, 'A' , 'TOTALE ATTIVO CIRCOLANTE (B)', 1, _idsor1,'S',230  from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 231 from  @ANALITICA1 -- Fittizia
		-----------------------------------------------II CREDITI	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 240 from  @ANALITICA1 -- Fittizia

		INSERT INTO #STRUTTURA  SELECT 1,'II CREDITI  (con separata indicazione, per ciascuna voce, degli importi esigibili entro l''esercizio successivo)', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S',250 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 251 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 260 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 1,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)', 0,0,0,0, 'A'	,'TOTALE CREDITI',1, _idsor1,'S',270  from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)e', 0,0,0,0, 'A'	,'B) II 1)',1, _idsor1,'P' ,271 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)o', 0,0,0,0, 'A'	,'B) II 1)',1, _idsor1,'N' ,280 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)', 0,0,0,0, 'A', 'TOTALE CREDITI',1, _idsor1,'S',290 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)e', 0,0,0,0, 'A', 'B) II 2)',1, _idsor1,'P' ,291from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)o', 0,0,0,0, 'A', 'B) II 2)',1, _idsor1,'N',300 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)', 0,0,0,0, 'A' ,'TOTALE CREDITI',	1, _idsor1,'S',310 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)e', 0,0,0,0, 'A' ,'B) II 3)',		1, _idsor1,'P',311 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)o', 0,0,0,0, 'A' ,'B) II 3)',		1, _idsor1,'N',320  from  @ANALITICA1

		IF (@ayear <= 2017) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)', 0,0,0,0, 'A' ,'TOTALE CREDITI'	,1, _idsor1,'S',325  from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)e', 0,0,0,0, 'A' ,'B) II 4)'		,1, _idsor1,'P',326  from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)o', 0,0,0,0, 'A' ,'B) II 4)'		,1, _idsor1,'N',330 from  @ANALITICA1
	
		end
		else
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)', 0,0,0,0, 'A' , 'TOTALE CREDITI'				,1, _idsor1,'S',325 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)e', 0,0,0,0, 'A' ,'B) II 4)'					,1, _idsor1,'P',326 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)o', 0,0,0,0, 'A' ,'B) II 4)'					,1, _idsor1,'N',330 from  @ANALITICA1
		end

		INSERT INTO #STRUTTURA  SELECT 1,'5) Crediti verso Università', 'B) II 5)', 0,0,0,0, 'A' ,'TOTALE CREDITI'	,1, _idsor1,'S' ,340 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'5) Crediti verso Università', 'B) II 5)e', 0,0,0,0, 'A' ,'B) II 5)',		1, _idsor1,'P'	,341 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'5) Crediti verso Università', 'B) II 5)o', 0,0,0,0, 'A' ,'B) II 5)',		1, _idsor1,'N'	,350 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)', 0,0,0,0, 'A' ,'TOTALE CREDITI',1, _idsor1,'S',360 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)e', 0,0,0,0, 'A' ,'B) II 6)',1, _idsor1,'P',361 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)o', 0,0,0,0, 'A' ,'B) II 6)',1, _idsor1,'N',370 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'7) Crediti verso Società ed enti controllati', 'B) II 7)', 0,0,0,0, 'A' ,'TOTALE CREDITI',1, _idsor1,'S',380  from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'7) Crediti verso Società ed enti controllati', 'B) II 7)e', 0,0,0,0, 'A' ,'B) II 7)',1, _idsor1,'P',381 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'7) Crediti verso Società ed enti controllati', 'B) II 7)o', 0,0,0,0, 'A' ,'B) II 7)',1, _idsor1,'N' ,390 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'8) Crediti verso altri (pubblici)', 'B) II 8)', 0,0,0,0,	'A' ,'TOTALE CREDITI',1, _idsor1,'S',400 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'8) Crediti verso altri (pubblici)', 'B) II 8)e', 0,0,0,0,	'A' ,'B) II 8)',1, _idsor1,'P' ,401 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'8) Crediti verso altri (pubblici)', 'B) II 8)o', 0,0,0,0,	'A' ,'B) II 8)',1, _idsor1,'N',410 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'9) Crediti verso altri (privati)', 'B) II 9)', 0,0,0,0,	'A' ,'TOTALE CREDITI',1, _idsor1,'S',420 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'9) Crediti verso altri (privati)', 'B) II 9)e', 0,0,0,0,	'A' ,'B) II 9)',1, _idsor1,'P' ,421 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'9) Crediti verso altri (privati)', 'B) II 9)o', 0,0,0,0,	'A' ,'B) II 9)',1, _idsor1,'N',430 from  @ANALITICA1
		-----------------------------------------------TOTALE CREDITI	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE CREDITI', null, 0,0,0,0,	'A' ,'TOTALE ATTIVO CIRCOLANTE (B)', 1, _idsor1,'S' ,440 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0,				'A' ,null, 1, null,'N' , 441 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE CREDITI(e)', null, 0,0,0,0, 'A' ,null, 1, _idsor1,'P',450 from  @ANALITICA1
		-------------------------------------------------	III ATTIVITA'' FINANZIARIE ----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 1,'III ATTIVITA'' FINANZIARIE',		'B) III',  0,0,0,0, 'A',  'TOTALE ATTIVITA'' FINANZIARIE',1 , _idsor1,'S',460 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0,									'A' ,null, 1, null,'N' , 461 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE ATTIVITA'' FINANZIARIE',	null,  0,0,0,0,		'A', null,1, _idsor1,'S' ,470 from  @ANALITICA1

		-------------------------------------------------	IV DISPONIBILITA'' LIQUIDE		----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 2,'IV DISPONIBILITA'' LIQUIDE',		null,  0,0,0,0,	'A' ,  null,1, _idsor1,'S' ,480 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'1) Depositi bancari e postali',	'B) IV 1)', 0,0,0,0, 'A' ,'TOTALE DISPONIBILITA'' LIQUIDE',1, _idsor1,'S',490   from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'2) Denaro e valori in cassa',		'B) IV 2)', 0,0,0,0, 'A', 'TOTALE DISPONIBILITA'' LIQUIDE',1, _idsor1,'S',500  from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE DISPONIBILITA'' LIQUIDE',	null, 0,0,0,0, 'A',  'TOTALE ATTIVO CIRCOLANTE (B)',1 , _idsor1,'S',510 from  @ANALITICA1
		----------------------------------------------- TOTALE		B) ATTIVO CIRCOLANTE	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE ATTIVO CIRCOLANTE (B)', null, 0,0,0,0, 'A' ,'TOTALE ATTIVO', 1, _idsor1,'S' ,520 from  @ANALITICA1

		-----------------------------C) RATEI E RISCONTI ATTIVI ---------------------------------- 
		INSERT INTO #STRUTTURA  SELECT 0,'C) RATEI E RISCONTI ATTIVI', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S' ,530 from  @ANALITICA1

		IF (@ayear <= 2017) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'c1)	Ratei per progetti e ricerche in corso',	'C) c1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S', 540 from  @ANALITICA1
		end
		else
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'c1)	Altri ratei e risconti attivi',				'C) c1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S',540 from  @ANALITICA1
		end
		INSERT INTO #STRUTTURA  SELECT 1,'c2)	Altri ratei e risconti attivi', 'C) c2)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S' ,550from  @ANALITICA1
		---------------------------------------	D)	RATEI ATTIVI PER PROGETTI E RICERCHE IN CORSO	--------------------------------------------------------------------
		IF (@ayear >= 2018) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 0,'D)	RATEI ATTIVI PER PROGETTI E RICERCHE IN CORSO', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S',560 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 1,'d 1)	Ratei attivi per progetti e ricerche finanziate e co-finanziate in corso', 'd 1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S',560 from  @ANALITICA1
		End

		--------------------------------------TOTALE ATTIVO-----------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'TOTALE ATTIVO', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S',570 from  @ANALITICA1
		------------------------------------------------------------------------------------------------

		----------------------------------------------- POI CI SONO I CONTI D'ORDINE ATTIVI ----------------------------

		INSERT INTO #STRUTTURA  SELECT 0,'A)	PATRIMONIO NETTO', null, 0,0,0,0, 'P' ,null,null , _idsor1,'S',10 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 3,'I FONDO DI DOTAZIONE DELL''ATENEO', 'A) I', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, _idsor1,'S',20 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 2,'II PATRIMONIO VINCOLATO', null, 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO', 1, _idsor1,'S',30 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'1) Fondi vincolati destinati da terzi', 'A) II 1)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, _idsor1,'S' ,40 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'2) Fondi vincolati per decisione degli organi istituzionali', 'A) II 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, _idsor1,'S' ,50 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'3) Riserve vincolate(per progetti specifici, obblighi di legge,o altro)', 'A) II 3)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, _idsor1,'S' ,60 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 70 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE PATRIMONIO VINCOLATO', null, 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, _idsor1,'S',80 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 2,'III PATRIMONIO NON VINCOLATO', null, 0,0,0,0, 'P' ,null, 1, _idsor1,'S',90 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 1,'1) Risultato gestionale esercizio', 'A) III 1)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S' ,100 from  @ANALITICA1
		if (@ayear <=2017) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'2) Risultati gestionali relativi ad esercizi precedenti', 'A) III 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S' ,110 from  @ANALITICA1
		End
		ELSE
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'2) Risultati relativi ad esercizi precedenti', 'A) III 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S' ,110 from  @ANALITICA1
		End
		INSERT INTO #STRUTTURA  SELECT 1,'3) Riserve statutarie', 'A) III 3)', 0,0,0,0,			'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S',120  from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE PATRIMONIO NON VINCOLATO', null, 0,0,0,0,		'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, _idsor1,'S' ,130 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE PATRIMONIO NETTO(A)', null, 0,0,0,0,			'P' ,'TOTALE PASSIVO', 1, _idsor1,'S' ,140 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' ,150 from  @ANALITICA1 -- Fittizia

		INSERT INTO #STRUTTURA  SELECT 0,'B)	FONDI PER RISCHI ED ONERI', null, 0,0,0,0,			'P' ,null,null , _idsor1,'S' ,160 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE FONDI PER RISCHI ED ONERI (B)', 'B)', 0,0,0,0,	'P' ,'TOTALE PASSIVO',null , _idsor1,'S' ,170 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0,									'P' ,null, 1, null,'N' ,180 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,'C)	TRATTAMENTO DI FINE RAPPORTO DI LAVORO SUBORDINATO', 'C)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',null , _idsor1,'S',190 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 200 from  @ANALITICA1 -- Fittizia
		-------------------------------------------------------	DEBITI -------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'D)	DEBITI (con separata indicazione, per ciascuna voce, degli importi esigibili oltre l''esercizio successivo)', null, 0,0,0,0, 'P' ,null,null , _idsor1,'S',210 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 220 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 1,'1) Mutui e Debiti verso banche', 'D) 1)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1   ,	_idsor1,'S' ,230 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'1) Mutui e Debiti verso banche', 'D) 1)e', 0,0,0,0, 'P', 'D) 1)',1   ,				_idsor1,'N' ,231 from  @ANALITICA1 -- hanno lo stesso ordine stampa perchè solo P verrà visualizzato
		INSERT INTO #STRUTTURA  SELECT 0,'1) Mutui e Debiti verso banche', 'D) 1)o', 0,0,0,0, 'P', 'D) 1)',1   ,				_idsor1,'P' ,240 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)',	0,0,0,0, 'P'  , 'TOTALE DEBITI (D)',1  , _idsor1,'S',250 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)e',				0,0,0,0, 'P'  , 'D) 2)',1  , _idsor1,'P',251 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)o',				0,0,0,0, 'P'  , 'D) 2)',1  , _idsor1,'N',260 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'3) Debiti verso Regione e Province Autonome',  'D) 3)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1  , _idsor1,'S',270 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'3) Debiti verso Regione e Province Autonome',  'D) 3)e', 0,0,0,0, 'P',  'D) 3)',1  , _idsor1,'P',271 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'3) Debiti verso Regione e Province Autonome',  'D) 3)o', 0,0,0,0, 'P',  'D) 3)',1  , _idsor1,'N',280 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'4) Debiti verso altre Amministrazioni locali', 'D) 4)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',290 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'4) Debiti verso altre Amministrazioni locali', 'D) 4)e', 0,0,0,0, 'P' , 'D) 4)',1  , _idsor1,'P' ,291 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'4) Debiti verso altre Amministrazioni locali', 'D) 4)o', 0,0,0,0, 'P' , 'D) 4)',1  , _idsor1,'N',300 from  @ANALITICA1

		IF (@ayear <= 2017) 
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)',0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S' ,310 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)e',0,0,0,0, 'P' , 'D) 5)',1  , _idsor1,'P',311 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)o',0,0,0,0, 'P' , 'D) 5)',1  , _idsor1,'N',320 from  @ANALITICA1
		end
		ELSE
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',310 from  @ANALITICA1
			 INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)e', 0,0,0,0, 'P' , 'D) 5)',1  , _idsor1,'P',311 from  @ANALITICA1
			 INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)o', 0,0,0,0, 'P' ,'D) 5)',1  , _idsor1,'N' ,320 from  @ANALITICA1
			 end
		INSERT INTO #STRUTTURA  SELECT 1,'6) Debiti verso Università',	'D) 6)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',325 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'6) Debiti verso Università',	'D) 6)e', 0,0,0,0, 'P' , 'D) 6)',1  , _idsor1,'P',326 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'6) Debiti verso Università',	'D) 6)o', 0,0,0,0, 'P' , 'D) 6)',1  , _idsor1,'N' ,330 from  @ANALITICA1


		INSERT INTO #STRUTTURA  SELECT 1,'7) Debiti verso studenti',		'D) 7)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1   , _idsor1,'S',340 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'7) Debiti verso studenti',		'D) 7)e', 0,0,0,0, 'P', 'D) 7)',1   , _idsor1,'P' ,341 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'7) Debiti verso studenti',		'D) 7)o', 0,0,0,0, 'P', 'D) 7)',1   , _idsor1,'N',350 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'8) Acconti',					'D) 8)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',360 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'8) Acconti',					'D) 8)e', 0,0,0,0, 'P' , 'D) 8)',1  , _idsor1,'P' ,361 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'8) Acconti',					'D) 8)o', 0,0,0,0, 'P' , 'D) 8)',1  , _idsor1,'N', 370 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'9) Debiti verso fornitori',	'D) 9)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1   , _idsor1,'S' ,380 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'9) Debiti verso fornitori',	'D) 9)e', 0,0,0,0, 'P' , 'D) 9)',1   , _idsor1,'P' ,381 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'9) Debiti verso fornitori',	'D) 9)o', 0,0,0,0, 'P' , 'D) 9)',1   , _idsor1,'N',390  from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'10) Debiti verso dipendenti',	'D) 10)',  0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',400  from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'10) Debiti verso dipendenti',	'D) 10)e',  0,0,0,0, 'P' , 'D) 10)',1  , _idsor1,'P' ,401 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'10) Debiti verso dipendenti',	'D) 10)o',  0,0,0,0, 'P' , 'D) 10)',1  , _idsor1,'N' ,410 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'11) Debiti verso società o enti controllati', 'D) 11)', 0,0,0,0, 'P'  , 'TOTALE DEBITI (D)',1  , _idsor1,'S' ,420 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'11) Debiti verso società o enti controllati', 'D) 11)e', 0,0,0,0, 'P'  , 'D) 11)',1  , _idsor1,'P' ,421 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'11) Debiti verso società o enti controllati', 'D) 11)o', 0,0,0,0, 'P'  , 'D) 11)',1  , _idsor1,'N',430 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 1,'12) Altri debiti',				'D) 12)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1    , _idsor1,'S',440 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'12) Altri debiti',				'D) 12)e', 0,0,0,0, 'P', 'D) 12)',1    , _idsor1,'P' ,441 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,'12) Altri debiti',				'D) 12)o', 0,0,0,0, 'P', 'D) 12)',1    , _idsor1,'N',450 from  @ANALITICA1

		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE DEBITI (D)', null, 0,0,0,0, 'P' ,'TOTALE PASSIVO',null , _idsor1,'S',460 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 4,null, null, 0,0,0,0, 'P' ,null, 1, _idsor1,'P' ,461 from  @ANALITICA1
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 470 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,'E) RATEI E RISCONTI PASSIVI E CONTRIBUTI AGLI INVESTIMENTI', null, 0,0,0,0, 'P' ,null,1 , _idsor1,'S' ,480 from  @ANALITICA1
		IF (@ayear <= 2017) 
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'e1) Risconti per progetti e ricerche in corso', 'E) e1)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',1 , _idsor1,'S' ,490 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 1,'e2) Contributi agli investimenti', 'E) e2)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S',500 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 1,'e3) Altri ratei e risconti passivi', 'E) e3)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S' ,510 from  @ANALITICA1
		end
		Else
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'e1) Contributi agli investimenti', 'E) e1)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',1 , _idsor1,'S',490 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 1,'e2) Altri ratei e risconti passivi', 'E) e2)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S',500 from  @ANALITICA1
		end
  
		if(@ayear >=2018)
		Begin
			INSERT INTO #STRUTTURA  SELECT 0,'F)	RISCONTI PASSIVI PER PROGETTI E RICERCHE IN CORSO', null, 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S' ,530 from  @ANALITICA1
			INSERT INTO #STRUTTURA  SELECT 1,'f1) Risconti passivi per progetti e ricerche finanziate e co-finanziate in corso', 'f 1)', 0,0,0,0, 'P' ,null, 1, _idsor1,'S',540 from  @ANALITICA1
		End
		else
		Begin
			INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 530 from  @ANALITICA1 -- Fittizia
			INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 540 from  @ANALITICA1 -- Fittizia
		end
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 550 from  @ANALITICA1 -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 560 from  @ANALITICA1 -- Fittizia
		--------------------------------------TOTALE PASSIVO ------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'TOTALE PASSIVO', null, 0,0,0,0, 'P' ,null,null , _idsor1,'S' ,570 from  @ANALITICA1
		------------------------------------------------------------------------------------------------
		
End
Else
Begin
-- Se voglio vedere solo una specifica @idsor1 o i figli totalizzati, metto nella #STRUTTURA DIRETTAMENTE QUELLA SPECIFICA @idsor1
		 -------------------------------------------------------------------------------------------------
		 --------------------------------------- RICAVI --------------------------------------------------
		 -------------------------------------------------------------------------------------------------

		 ---------------------------------------------	A) IMMOBILIZZAZIONI	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'A) IMMOBILIZZAZIONI', null, 0,0,0,0, 'A' ,null,null , @idsor1, 'S',10  
		INSERT INTO #STRUTTURA  SELECT 2,'I.IMMATERIALI', null, 0,0,0,0, 'A' ,null, 1, @idsor1,'S' ,20  
		INSERT INTO #STRUTTURA  SELECT 1,'1) Costi di impianto, di ampliamento e di sviluppo', 'A) I 1)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, @idsor1,'S' ,30  
		INSERT INTO #STRUTTURA  SELECT 1,'2) Diritti di brevetto e diritti di utilizzazione delle opere dell''ingegno', 'A) I 2)', 0,0,0,0, 'A', 'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, @idsor1,'S',40  
		INSERT INTO #STRUTTURA  SELECT 1,'3) Concessioni, licenze, marchi e diritti simili', 'A) I 3)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, @idsor1,'S',50  
		INSERT INTO #STRUTTURA  SELECT 1,'4) Immobilizzazioni in corso ed acconti', 'A) I 4)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, @idsor1,'S',60  
		INSERT INTO #STRUTTURA  SELECT 1,'5) Altre immobilizzazioni immateriali', 'A) I 5)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, @idsor1,'S',70  
		---------------------------------------------	TOTALE IMMOBILIZZAZIONI IMMATERIALI	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE IMMOBILIZZAZIONI IMMATERIALI', null, 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, @idsor1,'S',80  

		INSERT INTO #STRUTTURA  SELECT 2,'II.MATERIALI', null, 0,0,0,0, 'A' ,null, 1, @idsor1,'S',90  
		INSERT INTO #STRUTTURA  SELECT 1,'1) Terreni e fabbricati', 'A) II 1)', 0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1, @idsor1,'S',100  
		INSERT INTO #STRUTTURA  SELECT 1,'2) Impianti e attrezzature', 'A) II 2)',  0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1 , @idsor1,'S',110  
		INSERT INTO #STRUTTURA  SELECT 1,'3) Attrezzature scientifiche', 'A) II 3)',  0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, @idsor1,'S',120  
		INSERT INTO #STRUTTURA  SELECT 1,'4) Patrimonio librario, opere d''arte, d''antiquariato e museali', 'A) II 4)',  0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1 , @idsor1,'S' ,130  
		INSERT INTO #STRUTTURA  SELECT 1,'5) Mobili ed arredi', 'A) II 5)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, @idsor1,'S',140  
		INSERT INTO #STRUTTURA  SELECT 1,'6) Immobilizzazioni in corso e acconti', 'A) II 6)',  0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, @idsor1,'S',150  
		INSERT INTO #STRUTTURA  SELECT 1,'7) Altre immobilizzazioni materiali', 'A) II 7)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1 , @idsor1,'S' ,160  
		---------------------------------------------	TOTALE IMMOBILIZZAZIONI MATERIALI	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE IMMOBILIZZAZIONI MATERIALI', null, 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, @idsor1,'S',170  

		INSERT INTO #STRUTTURA  SELECT 2,'III FINANZIARIE', 'A) III', 0,0,0,0, 'A' ,null, 1, @idsor1,'S' ,180  
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE IMMOBILIZZAZIONI FINANZIARIE', 'A) III', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, @idsor1,'S' ,190   
		---------------------------------------------	TOTALE IMMOBILIZZAZIONI A	----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE IMMOBILIZZAZIONI (A)', null, 0,0,0,0, 'A' ,'TOTALE ATTIVO', 1, @idsor1,'S' ,200  

		-----------------------------------------------	B) ATTIVO CIRCOLANTE	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'B) ATTIVO CIRCOLANTE', null, 0,0,0,0, 'A' ,null,null , @idsor1,'S' ,210  
		INSERT INTO #STRUTTURA  SELECT 1,'I RIMANENZE', 'B) I', 0,0,0,0, 'A' ,'TOTALE RIMANENZE', 1, @idsor1,'S',220  
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE RIMANENZE', null, 0,0,0,0, 'A' , 'TOTALE ATTIVO CIRCOLANTE (B)', 1, @idsor1,'S',230   
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 231   -- Fittizia
		-----------------------------------------------II CREDITI	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 240   -- Fittizia

		INSERT INTO #STRUTTURA  SELECT 1,'II CREDITI  (con separata indicazione, per ciascuna voce, degli importi esigibili entro l''esercizio successivo)', null, 0,0,0,0, 'A' ,null,null , @idsor1,'S',250  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 251   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 260   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 1,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)', 0,0,0,0, 'A'	,'TOTALE CREDITI',1, @idsor1,'S',270   
		INSERT INTO #STRUTTURA  SELECT 0,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)e', 0,0,0,0, 'A'	,'B) II 1)',1, @idsor1,'P' ,271  
		INSERT INTO #STRUTTURA  SELECT 0,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)o', 0,0,0,0, 'A'	,'B) II 1)',1, @idsor1,'N' ,280  

		INSERT INTO #STRUTTURA  SELECT 1,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)', 0,0,0,0, 'A', 'TOTALE CREDITI',1, @idsor1,'S',290  
		INSERT INTO #STRUTTURA  SELECT 0,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)e', 0,0,0,0, 'A', 'B) II 2)',1, @idsor1,'P' ,291 
		INSERT INTO #STRUTTURA  SELECT 0,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)o', 0,0,0,0, 'A', 'B) II 2)',1, @idsor1,'N',300  

		INSERT INTO #STRUTTURA  SELECT 1,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)', 0,0,0,0, 'A' ,'TOTALE CREDITI',	1, @idsor1,'S',310  
		INSERT INTO #STRUTTURA  SELECT 0,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)e', 0,0,0,0, 'A' ,'B) II 3)',		1, @idsor1,'P',311  
		INSERT INTO #STRUTTURA  SELECT 0,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)o', 0,0,0,0, 'A' ,'B) II 3)',		1, @idsor1,'N',320   

		IF (@ayear <= 2017) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)', 0,0,0,0, 'A' ,'TOTALE CREDITI'	,1, @idsor1,'S',325   
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)e', 0,0,0,0, 'A' ,'B) II 4)'		,1, @idsor1,'P',326   
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)o', 0,0,0,0, 'A' ,'B) II 4)'		,1, @idsor1,'N',330  
	
		end
		else
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)', 0,0,0,0, 'A' , 'TOTALE CREDITI'				,1, @idsor1,'S',325  
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)e', 0,0,0,0, 'A' ,'B) II 4)'					,1, @idsor1,'P',326  
			INSERT INTO #STRUTTURA  SELECT 0,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)o', 0,0,0,0, 'A' ,'B) II 4)'					,1, @idsor1,'N',330  
		end

		INSERT INTO #STRUTTURA  SELECT 1,'5) Crediti verso Università', 'B) II 5)', 0,0,0,0, 'A' ,'TOTALE CREDITI'	,1, @idsor1,'S' ,340  
		INSERT INTO #STRUTTURA  SELECT 0,'5) Crediti verso Università', 'B) II 5)e', 0,0,0,0, 'A' ,'B) II 5)',		1, @idsor1,'P'	,341  
		INSERT INTO #STRUTTURA  SELECT 0,'5) Crediti verso Università', 'B) II 5)o', 0,0,0,0, 'A' ,'B) II 5)',		1, @idsor1,'N'	,350  

		INSERT INTO #STRUTTURA  SELECT 1,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)', 0,0,0,0, 'A' ,'TOTALE CREDITI',1, @idsor1,'S',360  
		INSERT INTO #STRUTTURA  SELECT 0,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)e', 0,0,0,0, 'A' ,'B) II 6)',1, @idsor1,'P',361  
		INSERT INTO #STRUTTURA  SELECT 0,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)o', 0,0,0,0, 'A' ,'B) II 6)',1, @idsor1,'N',370  

		INSERT INTO #STRUTTURA  SELECT 1,'7) Crediti verso Società ed enti controllati', 'B) II 7)', 0,0,0,0, 'A' ,'TOTALE CREDITI',1, @idsor1,'S',380   
		INSERT INTO #STRUTTURA  SELECT 0,'7) Crediti verso Società ed enti controllati', 'B) II 7)e', 0,0,0,0, 'A' ,'B) II 7)',1, @idsor1,'P',381  
		INSERT INTO #STRUTTURA  SELECT 0,'7) Crediti verso Società ed enti controllati', 'B) II 7)o', 0,0,0,0, 'A' ,'B) II 7)',1, @idsor1,'N' ,390  

		INSERT INTO #STRUTTURA  SELECT 1,'8) Crediti verso altri (pubblici)', 'B) II 8)', 0,0,0,0,	'A' ,'TOTALE CREDITI',1, @idsor1,'S',400  
		INSERT INTO #STRUTTURA  SELECT 0,'8) Crediti verso altri (pubblici)', 'B) II 8)e', 0,0,0,0,	'A' ,'B) II 8)',1, @idsor1,'P' ,401  
		INSERT INTO #STRUTTURA  SELECT 0,'8) Crediti verso altri (pubblici)', 'B) II 8)o', 0,0,0,0,	'A' ,'B) II 8)',1, @idsor1,'N',410  

		INSERT INTO #STRUTTURA  SELECT 1,'9) Crediti verso altri (privati)', 'B) II 9)', 0,0,0,0,	'A' ,'TOTALE CREDITI',1, @idsor1,'S',420  
		INSERT INTO #STRUTTURA  SELECT 0,'9) Crediti verso altri (privati)', 'B) II 9)e', 0,0,0,0,	'A' ,'B) II 9)',1, @idsor1,'P' ,421  
		INSERT INTO #STRUTTURA  SELECT 0,'9) Crediti verso altri (privati)', 'B) II 9)o', 0,0,0,0,	'A' ,'B) II 9)',1, @idsor1,'N',430  
		-----------------------------------------------TOTALE CREDITI	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE CREDITI', null, 0,0,0,0,	'A' ,'TOTALE ATTIVO CIRCOLANTE (B)', 1, @idsor1,'S' ,440  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0,				'A' ,null, 1, null,'N' , 441   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE CREDITI(e)', null, 0,0,0,0, 'A' ,null, 1, @idsor1,'P',450  
		-------------------------------------------------	III ATTIVITA'' FINANZIARIE ----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 1,'III ATTIVITA'' FINANZIARIE',		'B) III',  0,0,0,0, 'A',  'TOTALE ATTIVITA'' FINANZIARIE',1 , @idsor1,'S',460  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0,									'A' ,null, 1, null,'N' , 461   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 2,'TOTALE ATTIVITA'' FINANZIARIE',	null,  0,0,0,0,		'A', null,1, @idsor1,'S' ,470  

		-------------------------------------------------	IV DISPONIBILITA'' LIQUIDE		----------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 2,'IV DISPONIBILITA'' LIQUIDE',		null,  0,0,0,0,	'A' ,  null,1, @idsor1,'S' ,480  
		INSERT INTO #STRUTTURA  SELECT 1,'1) Depositi bancari e postali',	'B) IV 1)', 0,0,0,0, 'A' ,'TOTALE DISPONIBILITA'' LIQUIDE',1, @idsor1,'S',490    
		INSERT INTO #STRUTTURA  SELECT 1,'2) Denaro e valori in cassa',		'B) IV 2)', 0,0,0,0, 'A', 'TOTALE DISPONIBILITA'' LIQUIDE',1, @idsor1,'S',500   
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE DISPONIBILITA'' LIQUIDE',	null, 0,0,0,0, 'A',  'TOTALE ATTIVO CIRCOLANTE (B)',1 , @idsor1,'S',510  
		----------------------------------------------- TOTALE		B) ATTIVO CIRCOLANTE	------------------------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE ATTIVO CIRCOLANTE (B)', null, 0,0,0,0, 'A' ,'TOTALE ATTIVO', 1, @idsor1,'S' ,520  

		-----------------------------C) RATEI E RISCONTI ATTIVI ---------------------------------- 
		INSERT INTO #STRUTTURA  SELECT 0,'C) RATEI E RISCONTI ATTIVI', null, 0,0,0,0, 'A' ,null,null , @idsor1,'S' ,530  

		IF (@ayear <= 2017) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'c1)	Ratei per progetti e ricerche in corso',	'C) c1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, @idsor1,'S', 540  
		end
		else
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'c1)	Altri ratei e risconti attivi',				'C) c1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, @idsor1,'S',540  
		end
		INSERT INTO #STRUTTURA  SELECT 1,'c2)	Altri ratei e risconti attivi', 'C) c2)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, @idsor1,'S' ,550 
		---------------------------------------	D)	RATEI ATTIVI PER PROGETTI E RICERCHE IN CORSO	--------------------------------------------------------------------
		IF (@ayear >= 2018) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 0,'D)	RATEI ATTIVI PER PROGETTI E RICERCHE IN CORSO', null, 0,0,0,0, 'A' ,null,null , @idsor1,'S',560  
			INSERT INTO #STRUTTURA  SELECT 1,'d 1)	Ratei attivi per progetti e ricerche finanziate e co-finanziate in corso', 'd 1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, @idsor1,'S',560  
		End

		--------------------------------------TOTALE ATTIVO-----------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'TOTALE ATTIVO', null, 0,0,0,0, 'A' ,null,null , @idsor1,'S',570  
		------------------------------------------------------------------------------------------------

		----------------------------------------------- POI CI SONO I CONTI D'ORDINE ATTIVI ----------------------------

		INSERT INTO #STRUTTURA  SELECT 0,'A)	PATRIMONIO NETTO', null, 0,0,0,0, 'P' ,null,null , @idsor1,'S',10  
		INSERT INTO #STRUTTURA  SELECT 3,'I FONDO DI DOTAZIONE DELL''ATENEO', 'A) I', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, @idsor1,'S',20  

		INSERT INTO #STRUTTURA  SELECT 2,'II PATRIMONIO VINCOLATO', null, 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO', 1, @idsor1,'S',30  
		INSERT INTO #STRUTTURA  SELECT 1,'1) Fondi vincolati destinati da terzi', 'A) II 1)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, @idsor1,'S' ,40  
		INSERT INTO #STRUTTURA  SELECT 1,'2) Fondi vincolati per decisione degli organi istituzionali', 'A) II 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, @idsor1,'S' ,50  
		INSERT INTO #STRUTTURA  SELECT 1,'3) Riserve vincolate(per progetti specifici, obblighi di legge,o altro)', 'A) II 3)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, @idsor1,'S' ,60  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 70   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE PATRIMONIO VINCOLATO', null, 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, @idsor1,'S',80  

		INSERT INTO #STRUTTURA  SELECT 2,'III PATRIMONIO NON VINCOLATO', null, 0,0,0,0, 'P' ,null, 1, @idsor1,'S',90  
		INSERT INTO #STRUTTURA  SELECT 1,'1) Risultato gestionale esercizio', 'A) III 1)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, @idsor1,'S' ,100  
		if (@ayear <=2017) 
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'2) Risultati gestionali relativi ad esercizi precedenti', 'A) III 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, @idsor1,'S' ,110  
		End
		ELSE
		Begin
			INSERT INTO #STRUTTURA  SELECT 1,'2) Risultati relativi ad esercizi precedenti', 'A) III 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, @idsor1,'S' ,110  
		End
		INSERT INTO #STRUTTURA  SELECT 1,'3) Riserve statutarie', 'A) III 3)', 0,0,0,0,			'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, @idsor1,'S',120   
		INSERT INTO #STRUTTURA  SELECT 3,'TOTALE PATRIMONIO NON VINCOLATO', null, 0,0,0,0,		'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, @idsor1,'S' ,130  
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE PATRIMONIO NETTO(A)', null, 0,0,0,0,			'P' ,'TOTALE PASSIVO', 1, @idsor1,'S' ,140  

		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' ,150   -- Fittizia

		INSERT INTO #STRUTTURA  SELECT 0,'B)	FONDI PER RISCHI ED ONERI', null, 0,0,0,0,			'P' ,null,null , @idsor1,'S' ,160  
		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE FONDI PER RISCHI ED ONERI (B)', 'B)', 0,0,0,0,	'P' ,'TOTALE PASSIVO',null , @idsor1,'S' ,170  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0,									'P' ,null, 1, null,'N' ,180   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,'C)	TRATTAMENTO DI FINE RAPPORTO DI LAVORO SUBORDINATO', 'C)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',null , @idsor1,'S',190  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 200   -- Fittizia
		-------------------------------------------------------	DEBITI -------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'D)	DEBITI (con separata indicazione, per ciascuna voce, degli importi esigibili oltre l''esercizio successivo)', null, 0,0,0,0, 'P' ,null,null , @idsor1,'S',210  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 220   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 1,'1) Mutui e Debiti verso banche', 'D) 1)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1   ,	@idsor1,'S' ,230  
		INSERT INTO #STRUTTURA  SELECT 0,'1) Mutui e Debiti verso banche', 'D) 1)e', 0,0,0,0, 'P', 'D) 1)',1   ,				@idsor1,'P' ,231   -- hanno lo stesso ordine stampa perchè solo P verrà visualizzato
		INSERT INTO #STRUTTURA  SELECT 0,'1) Mutui e Debiti verso banche', 'D) 1)o', 0,0,0,0, 'P', 'D) 1)',1   ,				@idsor1,'N' ,240  

		INSERT INTO #STRUTTURA  SELECT 1,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)',	0,0,0,0, 'P'  , 'TOTALE DEBITI (D)',1  , @idsor1,'S',250  
		INSERT INTO #STRUTTURA  SELECT 0,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)e',				0,0,0,0, 'P'  , 'D) 2)',1  , @idsor1,'N',251  
		INSERT INTO #STRUTTURA  SELECT 0,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)o',				0,0,0,0, 'N'  , 'D) 2)',1  , @idsor1,'P',260  

		INSERT INTO #STRUTTURA  SELECT 1,'3) Debiti verso Regione e Province Autonome',  'D) 3)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1  , @idsor1,'S',270  
		INSERT INTO #STRUTTURA  SELECT 0,'3) Debiti verso Regione e Province Autonome',  'D) 3)e', 0,0,0,0, 'P',  'D) 3)',1  , @idsor1,'P',271  
		INSERT INTO #STRUTTURA  SELECT 0,'3) Debiti verso Regione e Province Autonome',  'D) 3)o', 0,0,0,0, 'P',  'D) 3)',1  , @idsor1,'N',280  

		INSERT INTO #STRUTTURA  SELECT 1,'4) Debiti verso altre Amministrazioni locali', 'D) 4)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , @idsor1,'S',290  
		INSERT INTO #STRUTTURA  SELECT 0,'4) Debiti verso altre Amministrazioni locali', 'D) 4)e', 0,0,0,0, 'P' , 'D) 4)',1  , @idsor1,'P' ,291  
		INSERT INTO #STRUTTURA  SELECT 0,'4) Debiti verso altre Amministrazioni locali', 'D) 4)o', 0,0,0,0, 'P' , 'D) 4)',1  , @idsor1,'N',300  

		IF (@ayear <= 2017) 
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)',0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , @idsor1,'S' ,310  
			INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)e',0,0,0,0, 'P' , 'D) 5)',1  , @idsor1,'P',311  
			INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)o',0,0,0,0, 'P' , 'D) 5)',1  , @idsor1,'N',320  
		end
		ELSE
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , @idsor1,'S',310  
			 INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)e', 0,0,0,0, 'P' , 'D) 5)',1  , @idsor1,'P',311  
			 INSERT INTO #STRUTTURA  SELECT 0,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)o', 0,0,0,0, 'P' ,'D) 5)',1  , @idsor1,'N' ,320  
			 end
		INSERT INTO #STRUTTURA  SELECT 1,'6) Debiti verso Università',	'D) 6)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , @idsor1,'S',325  
		INSERT INTO #STRUTTURA  SELECT 0,'6) Debiti verso Università',	'D) 6)e', 0,0,0,0, 'P' , 'D) 6)',1  , @idsor1,'P',326  
		INSERT INTO #STRUTTURA  SELECT 0,'6) Debiti verso Università',	'D) 6)o', 0,0,0,0, 'P' , 'D) 6)',1  , @idsor1,'N' ,330  


		INSERT INTO #STRUTTURA  SELECT 1,'7) Debiti verso studenti',		'D) 7)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1   , @idsor1,'S',340  
		INSERT INTO #STRUTTURA  SELECT 0,'7) Debiti verso studenti',		'D) 7)e', 0,0,0,0, 'P', 'D) 7)',1   , @idsor1,'P' ,341  
		INSERT INTO #STRUTTURA  SELECT 0,'7) Debiti verso studenti',		'D) 7)o', 0,0,0,0, 'P', 'D) 7)',1   , @idsor1,'N',350  

		INSERT INTO #STRUTTURA  SELECT 1,'8) Acconti',					'D) 8)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , @idsor1,'S',360  
		INSERT INTO #STRUTTURA  SELECT 0,'8) Acconti',					'D) 8)e', 0,0,0,0, 'P' , 'D) 8)',1  , @idsor1,'P' ,361  
		INSERT INTO #STRUTTURA  SELECT 0,'8) Acconti',					'D) 8)o', 0,0,0,0, 'P' , 'D) 8)',1  , @idsor1,'N', 370  

		INSERT INTO #STRUTTURA  SELECT 1,'9) Debiti verso fornitori',	'D) 9)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1   , @idsor1,'S' ,380  
		INSERT INTO #STRUTTURA  SELECT 0,'9) Debiti verso fornitori',	'D) 9)e', 0,0,0,0, 'P' , 'D) 9)',1   , @idsor1,'P' ,381  
		INSERT INTO #STRUTTURA  SELECT 0,'9) Debiti verso fornitori',	'D) 9)o', 0,0,0,0, 'P' , 'D) 9)',1   , @idsor1,'N',390   

		INSERT INTO #STRUTTURA  SELECT 1,'10) Debiti verso dipendenti',	'D) 10)',  0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , @idsor1,'S',400   
		INSERT INTO #STRUTTURA  SELECT 0,'10) Debiti verso dipendenti',	'D) 10)e',  0,0,0,0, 'P' , 'D) 10)',1  , @idsor1,'P' ,401  
		INSERT INTO #STRUTTURA  SELECT 0,'10) Debiti verso dipendenti',	'D) 10)o',  0,0,0,0, 'P' , 'D) 10)',1  , @idsor1,'N' ,410  

		INSERT INTO #STRUTTURA  SELECT 1,'11) Debiti verso società o enti controllati', 'D) 11)', 0,0,0,0, 'P'  , 'TOTALE DEBITI (D)',1  , @idsor1,'S' ,420  
		INSERT INTO #STRUTTURA  SELECT 0,'11) Debiti verso società o enti controllati', 'D) 11)e', 0,0,0,0, 'P'  , 'D) 11)',1  , @idsor1,'P' ,421  
		INSERT INTO #STRUTTURA  SELECT 0,'11) Debiti verso società o enti controllati', 'D) 11)o', 0,0,0,0, 'P'  , 'D) 11)',1  , @idsor1,'N',430  

		INSERT INTO #STRUTTURA  SELECT 1,'12) Altri debiti',				'D) 12)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1    , @idsor1,'S',440  
		INSERT INTO #STRUTTURA  SELECT 0,'12) Altri debiti',				'D) 12)e', 0,0,0,0, 'P', 'D) 12)',1    , @idsor1,'N' ,441  
		INSERT INTO #STRUTTURA  SELECT 0,'12) Altri debiti',				'D) 12)o', 0,0,0,0, 'P', 'D) 12)',1    , @idsor1,'P',450  

		INSERT INTO #STRUTTURA  SELECT 4,'TOTALE DEBITI (D)', null, 0,0,0,0, 'P' ,'TOTALE PASSIVO',null , @idsor1,'S',460  
		INSERT INTO #STRUTTURA  SELECT 4,null, null, 0,0,0,0, 'P' ,null, 1, @idsor1,'P' ,461  
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 470   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,'E) RATEI E RISCONTI PASSIVI E CONTRIBUTI AGLI INVESTIMENTI', null, 0,0,0,0, 'P' ,null,1 , @idsor1,'S' ,480  
		IF (@ayear <= 2017) 
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'e1) Risconti per progetti e ricerche in corso', 'E) e1)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',1 , @idsor1,'S' ,490  
			INSERT INTO #STRUTTURA  SELECT 1,'e2) Contributi agli investimenti', 'E) e2)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, @idsor1,'S',500  
			INSERT INTO #STRUTTURA  SELECT 1,'e3) Altri ratei e risconti passivi', 'E) e3)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, @idsor1,'S' ,510  
		end
		Else
		begin
			INSERT INTO #STRUTTURA  SELECT 1,'e1) Contributi agli investimenti', 'E) e1)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',1 , @idsor1,'S',490  
			INSERT INTO #STRUTTURA  SELECT 1,'e2) Altri ratei e risconti passivi', 'E) e2)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, @idsor1,'S',500  
		end
 
		if(@ayear >=2018)
		Begin
			INSERT INTO #STRUTTURA  SELECT 0,'F)	RISCONTI PASSIVI PER PROGETTI E RICERCHE IN CORSO', null, 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, @idsor1,'S' ,530  
			INSERT INTO #STRUTTURA  SELECT 1,'f1) Risconti passivi per progetti e ricerche finanziate e co-finanziate in corso', 'f 1)', 0,0,0,0, 'P' ,null, 1, @idsor1,'S',540  
		End
		else
		Begin
			INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 530   -- Fittizia
			INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 540   -- Fittizia
		end
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 550   -- Fittizia
		INSERT INTO #STRUTTURA  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 560   -- Fittizia
		--------------------------------------TOTALE PASSIVO ------------------------------------------
		INSERT INTO #STRUTTURA  SELECT 0,'TOTALE PASSIVO', null, 0,0,0,0, 'P' ,null,null , @idsor1,'S' ,570  
		------------------------------------------------------------------------------------------------
End

-- SE VOGLIO VEDERLE TUTTE o VOGLIO VEDERE una specifica IDSOR1 PIù I FIGLI:
if ((@idsor1 is null) or (@idsor1 is not null and @showcoordanal = 'S'))
Begin
		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,_curramountAttivo, ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
						  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							JOIN #STRUTTURA ON #STRUTTURA._idsor1 = entrydetail.idsor1 and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE  entry.yentry = @ayear
							and entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'A'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1  ,ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
				
		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,_prevamountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							JOIN #STRUTTURA ON #STRUTTURA._idsor1 = entrydetail.idsor1	 and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.patpart = 'A'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and #STRUTTURA.codepatrimony is not null
							group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1,ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra

		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1, _curramountPassivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							JOIN #STRUTTURA ON #STRUTTURA._idsor1 = entrydetail.idsor1  and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE  entry.yentry = @ayear
							and  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'P'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
						group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1	,ordinestampa	,#STRUTTURA.nlevel, parent_label, segno ,mostra								  
				
				INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1, _prevamountPassivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
								JOIN #STRUTTURA ON #STRUTTURA._idsor1 = entrydetail.idsor1  and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.patpart = 'P'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
				group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra

End

-- SE VOGLIO SOLO TOTALIZZARE I FIGLI:
if ((@idsor1 is not null and @showidsor1child = 'S'))
Begin
-- legge i dati usando i figli, ma nella select prende direttamente il padre, per non aumentare le righe della #STRUTTURA
		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,_curramountAttivo, ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
						  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							join sortinglink SLK1
								on SLK1.idchild = entrydetail.idsor1 
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = SLK1.idparent and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE  entry.yentry = @ayear
							and entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'A'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1  ,ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
				
		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,_prevamountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							join sortinglink SLK1
								on SLK1.idchild = entrydetail.idsor1 
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = SLK1.idparent and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.patpart = 'A'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and #STRUTTURA.codepatrimony is not null
							group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1,ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra

		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1, _curramountPassivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							join sortinglink SLK1
								on SLK1.idchild = entrydetail.idsor1 
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = SLK1.idparent and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE  entry.yentry = @ayear
							and  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'P'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
						group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1	,ordinestampa	,#STRUTTURA.nlevel, parent_label, segno ,mostra								  
				
				INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1, _prevamountPassivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							join sortinglink SLK1
								on SLK1.idchild = entrydetail.idsor1 
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = SLK1.idparent and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.patpart = 'P'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
				group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
End

-- SE VOGLIO VEDERE SOLO UNA SPECIFICA idsor1:
if ((@idsor1 is not null and @showidsor1child = 'N'))
Begin
		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,_curramountAttivo, ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
						  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = entrydetail.idsor1 and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE  entry.yentry = @ayear
							and entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'A'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1  ,ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
				
		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,_prevamountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = entrydetail.idsor1 and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.patpart = 'A'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and #STRUTTURA.codepatrimony is not null
							group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1,ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra

		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1, _curramountPassivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							join sortinglink SLK1
								on SLK1.idchild = entrydetail.idsor1 
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = entrydetail.idsor1 and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE  entry.yentry = @ayear
							and  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'P'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
						group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1	,ordinestampa	,#STRUTTURA.nlevel, parent_label, segno ,mostra								  
				
				INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1, _prevamountPassivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		select #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, SUM(entrydetail.amount),ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							join sortinglink SLK1
								on SLK1.idchild = entrydetail.idsor1 
							JOIN #STRUTTURA 
								ON #STRUTTURA._idsor1 = entrydetail.idsor1 and patrimony.codepatrimony = #STRUTTURA.codepatrimony
							WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.patpart = 'P'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
				group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, ordinestampa,#STRUTTURA.nlevel, parent_label, segno ,mostra
End

		update #IMPORTI_CLASS SET _curramountAttivo  = - _curramountAttivo ,_prevamountAttivo  = - _prevamountAttivo where kind = 'A'--- cambio di segno per i costi

/*			
	if (@idsor1 is null AND @Mostracoordianataanalitica1 = 'N')
		update #IMPORTI_CLASS set _idsor1 = 0 -- metto a 0 per evitare di appesantire il codice con gli isnull, e per evitare di interrogare ogni volta il parametro (cose che rallente la query)
*/
-- gestisco i valori aggregati di livello 1, ove visualizziamo la parte (e)														
	 
 
		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, isnull(SUM(child._prevamountPassivo),0), isnull(SUM(child._curramountPassivo),0), isnull(sum(child._prevamountAttivo),0), isnull(sum(child._curramountAttivo),0),
			#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
		FROM #IMPORTI_CLASS child
		JOIN  #STRUTTURA	--è il padre
			ON child.parent_label = #STRUTTURA.codepatrimony and child.nlevel = 0 and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
		WHERE #STRUTTURA.nlevel = 1  
		group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra


		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, isnull(SUM(child._prevamountPassivo),0), isnull(SUM(child._curramountPassivo),0), isnull(sum(child._prevamountAttivo),0), isnull(sum(child._curramountAttivo),0),
			#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
		FROM #IMPORTI_CLASS child
		JOIN  #STRUTTURA	--è il padre
			ON child.parent_label = isnull(#STRUTTURA.codepatrimony,#STRUTTURA.label) and child.nlevel = 1 and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
		WHERE  #STRUTTURA.nlevel = 2 --and #STRUTTURA.codepatrimony is not null
		group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra


		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, isnull(SUM(child._prevamountPassivo),0), isnull(SUM(child._curramountPassivo),0), isnull(sum(child._prevamountAttivo),0), isnull(sum(child._curramountAttivo),0),
			#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
		FROM #IMPORTI_CLASS child
		JOIN  #STRUTTURA	--è il padre
			ON child.parent_label = isnull(#STRUTTURA.codepatrimony,#STRUTTURA.label) and child.nlevel in(1,2) and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
		WHERE  #STRUTTURA.nlevel = 3 
		group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra

		INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
		SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, isnull(SUM(child._prevamountPassivo),0), isnull(SUM(child._curramountPassivo),0), isnull(sum(child._prevamountAttivo),0), isnull(sum(child._curramountAttivo),0),
			#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
		FROM #IMPORTI_CLASS child
		JOIN  #STRUTTURA	--è il padre
			ON child.parent_label = isnull(#STRUTTURA.codepatrimony,#STRUTTURA.label) and child.nlevel = 3 and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
		WHERE  #STRUTTURA.nlevel = 4 
		group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra

			INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
	SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, 0, 0, isnull(sum(child._prevamountAttivo),0), isnull(sum(child._curramountAttivo),0),
		#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
	FROM #IMPORTI_CLASS child
	JOIN  #STRUTTURA	--è il padre
		ON child.parent_label = #STRUTTURA.label and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
	WHERE #STRUTTURA.label = ('TOTALE ATTIVO') and #STRUTTURA.kind ='A' and #STRUTTURA.mostra='S'
	group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra


	INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
	SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, isnull(SUM(child._prevamountPassivo),0), isnull(SUM(child._curramountPassivo),0), 0, 0,
		#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
	FROM #IMPORTI_CLASS child
	JOIN  #STRUTTURA	--è il padre
		ON child.parent_label = #STRUTTURA.label and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
	WHERE #STRUTTURA.label = ('TOTALE PASSIVO')  and #STRUTTURA.kind ='P' and #STRUTTURA.mostra='S'
	group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra

	INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
	SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, 0, 0, isnull(sum(child._prevamountAttivo),0), isnull(sum(child._curramountAttivo),0),
		#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
	FROM #IMPORTI_CLASS child
	JOIN  #STRUTTURA	--è il padre
		ON child.parent_label = #STRUTTURA.label and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
	WHERE #STRUTTURA.label = ('TOTALE CREDITI(e)') and #STRUTTURA.kind ='A' and #STRUTTURA.mostra='P'
	group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra


	INSERT INTO #IMPORTI_CLASS(label, codepatrimony,kind, _idsor1,  _prevamountPassivo,  _curramountPassivo, _prevamountAttivo, _curramountAttivo,ordinestampa,nlevel, parent_label, segno ,mostra)
	SELECT #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, isnull(SUM(child._prevamountPassivo),0), isnull(SUM(child._curramountPassivo),0), 0, 0,
		#STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra
	FROM #IMPORTI_CLASS child
	JOIN  #STRUTTURA	--è il padre
		ON child.parent_label = #STRUTTURA.label and #STRUTTURA._idsor1 = child._idsor1 and  #STRUTTURA.kind =child.kind
	WHERE #STRUTTURA.label = ('TOTALE DEBITI(e)')  and #STRUTTURA.kind ='P' and #STRUTTURA.mostra='P'
	group by #STRUTTURA.label, #STRUTTURA.codepatrimony, #STRUTTURA.kind, #STRUTTURA._idsor1, #STRUTTURA.ordinestampa, #STRUTTURA.nlevel, #STRUTTURA.parent_label, #STRUTTURA.segno ,#STRUTTURA.mostra

	--INSERT INTO #IMPORTI_CLASS 
	--SELECT * FROM #STRUTTURA
	--where not exists(select * from #IMPORTI_CLASS D2 where D2.ordinestampa = #STRUTTURA.ordinestampa and  D2.kind = #STRUTTURA.kind  and  D2._idsor1 = #STRUTTURA._idsor1)


---------------------------------------------------------------------------valorizza conti d'ordine attivi
DECLARE @sk_prec char(2)
SET @sk_prec = SUBSTRING(CONVERT(varchar(4),@ayear-1),3,2)

CREATE TABLE #conti_d_ordine	(
		idacc 		varchar(38), 
		code	varchar(50), 
		title		varchar(150), 
		printingordacc varchar(50), 
		py_totaledare decimal(19,2),
		py_totaleavere decimal(19,2),
		p_totaledare decimal(19,2),
		p_totaleavere decimal(19,2),
		_idsor1 int
	)

if exists (	select * FROM entrydetail  
				join account 		on entrydetail.idacc = account.idacc
				join @ANALITICA1 A	on A._idsor1 = entrydetail.idsor1
				where ((account.flag&4)<> 0) AND (entrydetail.yentry = @ayear or entrydetail.yentry = @ayear-1 ))
Begin
	insert into #conti_d_ordine(idacc, code, title, printingordacc, _idsor1, p_totaledare)
	SELECT 	account.idacc, account.codeacc, account.title, account.printingorder,	entrydetail.idsor1,  -SUM(amount) 
	FROM entrydetail  
	JOIN entry			on entry.nentry = entrydetail.nentry and entry.yentry = entrydetail.yentry 
	join account 		on entrydetail.idacc = account.idacc
	join @ANALITICA1 A	on A._idsor1 = entrydetail.idsor1
	WHERE  	(entrydetail.idupb like @idupb  OR @idupb is null)
		and entrydetail.idsor1 = A._idsor1 
		AND entrydetail.idacc = account.idacc and
		entry.adate between @start and @stop
		AND (@apertura ='N' or entry.identrykind=7)
		and  ((account.flag&4)<> 0)AND account.ayear = @ayear 
		and amount <0
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1

	insert into #conti_d_ordine(idacc, code, title, printingordacc, _idsor1, p_totaleavere)
	SELECT 	account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1,  SUM(amount)
	FROM entrydetail  
	JOIN entry			on		entry.nentry = entrydetail.nentry and entry.yentry = entrydetail.yentry 
	join account 		on entrydetail.idacc = account.idacc
	join @ANALITICA1 A	on A._idsor1 = entrydetail.idsor1
	WHERE  (entrydetail.idupb like @idupb  OR @idupb is null)
		and entrydetail.idsor1 = A._idsor1 
		AND entrydetail.idacc = account.idacc and
		entry.adate between @start and @stop
		AND (@apertura ='N' or entry.identrykind=7)
		and  ((account.flag&4)<> 0)AND account.ayear = @ayear 
		and amount >0
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1
					     
	insert into #conti_d_ordine(idacc, code, title, printingordacc, _idsor1, py_totaledare)
	SELECT 	account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1,  -SUM(amount)
	FROM entrydetail  
	JOIN entry			on	entry.nentry = entrydetail.nentry and entry.yentry = entrydetail.yentry 
	join account 		on entrydetail.idacc = account.idacc
	join @ANALITICA1 A	on A._idsor1 = entrydetail.idsor1
	WHERE  (entrydetail.idupb like @idupb  OR @idupb is null)
		and entrydetail.idsor1 = A._idsor1 
		AND entrydetail.idacc = account.idacc 
		AND entrydetail.idacc =  @sk_prec + SUBSTRING(account.idacc, 3,LEN(account.idacc) -2) 
		AND (@apertura ='N' or entry.identrykind=7)
		and  ((account.flag&4)<> 0)
		and amount<0
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1

	insert into #conti_d_ordine(idacc, code, title, printingordacc, _idsor1, py_totaleavere)
	SELECT 	account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1,  SUM(amount) 
	FROM entrydetail  
	JOIN entry			on	entry.nentry = entrydetail.nentry and entry.yentry = entrydetail.yentry 
	join account 		on entrydetail.idacc = account.idacc
	join @ANALITICA1 A	on A._idsor1 = entrydetail.idsor1
	WHERE  	(entrydetail.idupb like @idupb  OR @idupb is null)
		and entrydetail.idsor1 = A._idsor1 
		AND entrydetail.idacc = account.idacc 
		AND entrydetail.idacc =  @sk_prec + SUBSTRING(account.idacc, 3,LEN(account.idacc) -2) 
		AND (@apertura ='N' or entry.identrykind=7)
		and  ((account.flag&4)<> 0)
		and amount>0
	group by account.idacc, account.codeacc, account.title, account.printingorder, entrydetail.idsor1

		if(@idsor1 is not null and @showidsor1child =  'S' and @showcoordanal = 'N')
			update #conti_d_ordine set _idsor1 = @idsor1

		insert into #IMPORTI_CLASS(nlevel,label,codepatrimony,_curramountAttivo ,	_prevamountAttivo , _curramountPassivo,_prevamountPassivo, kind ,parent_label , segno , _idsor1 , mostra, ordinestampa  )  
		SELECT 0,'CONTI ORDINE ATTIVO-'+code, null, SUM(p_totaleavere),SUM(py_totaleavere), null,null, 'A' ,null,null , _idsor1,'S' ,600   
		FROM #conti_d_ordine			
		group by idacc, code, title, printingordacc , _idsor1

		insert into #IMPORTI_CLASS(nlevel,label,codepatrimony,_curramountAttivo ,	_prevamountAttivo , _curramountPassivo,_prevamountPassivo, kind ,parent_label , segno , _idsor1 , mostra, ordinestampa  )  
		SELECT 0,'CONTI ORDINE ATTIVO-'+code, null,  null,null, SUM(p_totaledare),SUM(py_totaledare), 'P' ,null,null , _idsor1,'S' ,600   
		FROM #conti_d_ordine			
		group by idacc, code, title, printingordacc , _idsor1
END
--select * from #conti_d_ordine
-----------------------------------------------------------------------



/*
	(*) Se @idsor1 valorizzata  e se
	-  @showidsor1child =  S totalizzo i figli, scrive idsor01 nell'intestazione
	-  @showidsor1child =  N filtra solo per la coordinata indicata e , scrive idsor01 nell'intestazione
	se showcoordanal = S restituisce in out tutti i figli, che saranno visualizzati nell'intestazione 
*/

if(@idsor1 is not null and @showidsor1child =  'S' and @showcoordanal = 'N')
Begin
--Se si vuole considerare i figli E si vuole anche mostarli, mostra i vari idsor, se invece si vuole SOLO totalizzarli SENZA mostarli si fa l'update
	update #IMPORTI_CLASS set _idsor1 = @idsor1
End



DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal
;WITH ATTIVO AS (select 
				isnull(SA.nlevel, S.nlevel) as 'nlevelAttivo',
		CASE 
			WHEN isnull(SA.nlevel,S.nlevel) = 1 THEN SPACE(2) + isnull(SA.label, S.label)
			WHEN isnull(SA.nlevel, S.nlevel) = 2 THEN SPACE(1) + isnull(SA.label, S.label)
			WHEN isnull(SA.nlevel, S.nlevel) = 3 THEN SPACE(1) + isnull(SA.label, S.label)
			ELSE isnull(SA.label,S.label) --- 0 e 4 senza rientro
		END  as labelAttivo,
		isnull(SA.codepatrimony,S.codepatrimony) as codepatrimonyA,
		isnull(SA.mostra, S.mostra) as mostraA,
		sum(SA._curramountAttivo) as _curramountAttivo,
		sum(SA._prevamountAttivo) as _prevamountAttivo,
		isnull(SA.parent_label, S.parent_label) as'parent_labelAttivo',
		isnull(SA.segno, S.segno) as segnoA,
		isnull(SA.ordinestampa, S.ordinestampa) as ordinestampaA,
		isnull( SA._idsor1,  S._idsor1) as _idsor1,
		isnull( SA.kind,  S.kind) as kind
		 	FROM #STRUTTURA S
		left outer JOIN  #IMPORTI_CLASS SA on S.ordinestampa = SA.ordinestampa and  S.kind = SA.kind and  S._idsor1 = SA._idsor1
		where  S.kind = 'A' and S.label is not null 
		group by S.nlevel, S.label,  S.codepatrimony,	 S.parent_label,  S.segno,  S.ordinestampa,		 S.mostra ,
			SA.nlevel, SA.label,  SA.codepatrimony,	 SA.parent_label,  SA.segno,  SA.ordinestampa,		 SA.mostra ,SA._idsor1, S._idsor1,
		isnull( SA.kind,  S.kind)
		 ),

		PASSIVO AS
			(select 
			isnull(SP.nlevel, P.nlevel) as 'nlevelPassivo',
			CASE 
				WHEN isnull(SP.nlevel,P.nlevel) = 1 THEN SPACE(2) + isnull(SP.label, P.label)
				WHEN isnull(SP.nlevel, P.nlevel) = 2 THEN SPACE(1) + isnull(SP.label, P.label)
				WHEN isnull(SP.nlevel, P.nlevel) = 3 THEN SPACE(1) + isnull(SP.label, P.label)
				ELSE isnull(SP.label, P.label) --0 e 4 senza rientro
			END  as labelPassivo,
			isnull(SP.codepatrimony,P.codepatrimony) as codepatrimonyP,
			isnull(SP.mostra, P.mostra) as mostraP,
			sum(SP._curramountPassivo) as _curramountPassivo,
			sum(SP._prevamountPassivo) as _prevamountPassivo,
			--kind,
			isnull(SP.parent_label,P.parent_label) as 'parent_labelPassivo',
			isnull(SP.segno, P.segno) as segnoP,
			isnull(SP.ordinestampa, P.ordinestampa) as ordinestampaP,
			isnull( SP._idsor1,  P._idsor1) as _idsor1,
			isnull( SP.kind,  P.kind) as kind
			FROM #STRUTTURA P
			left outer JOIN  #IMPORTI_CLASS SP on P.ordinestampa = SP.ordinestampa and  P.kind = SP.kind and  P._idsor1 = SP._idsor1
			where  P.kind = 'P'  and P.label is not null 
			group by P.nlevel, P.label,  P.codepatrimony,	 P.parent_label,  P.segno,  P.ordinestampa,		 P.mostra ,
			SP.nlevel, SP.label,  SP.codepatrimony,	 SP.parent_label, SP.segno,  	 SP.ordinestampa,		 SP.mostra, SP._idsor1, P._idsor1,isnull( SP.kind,  P.kind))
SELECT 	@ayear				  AS ayear         ,
		@idupboriginal		  as idupb         ,
		@codeupb				  as codeupb	   ,
		@title				  as upb		   ,

		ATTIVO.nlevelAttivo,
		ATTIVO.labelAttivo,
		ATTIVO.codepatrimonyA,
		ATTIVO.segnoA,
		ATTIVO.parent_labelAttivo,
		ATTIVO._curramountAttivo,
		ATTIVO._prevamountAttivo,
		ATTIVO.mostraA,

		PASSIVO.nlevelPassivo,
		PASSIVO.labelPassivo,
		PASSIVO.codepatrimonyP,
		PASSIVO.mostraP,
		PASSIVO._curramountPassivo,
		PASSIVO._prevamountPassivo,
		PASSIVO.parent_labelPassivo,
		PASSIVO.segnoP,
		ATTIVO.ordinestampaA,
		PASSIVO.ordinestampaP,
		sorting.idsor as idsor,
		sorting.sortcode as sortcode1,
		sorting.description as titlecode1,
		-- La riga deve essere nascosta nella sezione dettagli a queste condizioni
		--1) mostraA e mostraP pari a N o P
		--2) Tutti gli importi sono pari a zero o nulli
		isnull( ATTIVO.kind,  PASSIVO.kind) AS kind,
		CASE 
				WHEN (ATTIVO.mostraA <> 'S' AND PASSIVO.mostraP<> 'S'  AND 
					 ISNULL(ATTIVO._curramountAttivo,0) = 0 AND 
					 ISNULL(ATTIVO._prevamountAttivo,0) = 0 AND 
					 ISNULL(PASSIVO._curramountPassivo,0) = 0 AND 
					 ISNULL(PASSIVO._prevamountPassivo,0) = 0 
				 )
				 THEN 'S'
				 ELSE 'N'
		END as toSuppress
FROM ATTIVO
left outer JOIN PASSIVO on ATTIVO.ordinestampaA = PASSIVO.ordinestampaP and PASSIVO._idsor1 = ATTIVO._idsor1
join sorting
			on ATTIVO._idsor1 = sorting.idsor
--where  Attivo.kind = 'A' and Passivo.kind = 'P' 
order by sortcode1, ATTIVO.ordinestampaA


drop table #IMPORTI_CLASS
drop table #STRUTTURA

end

	GO
	
	SET QUOTED_IDENTIFIER OFF
	GO
	SET ANSI_NULLS ON
	GO
	
	
