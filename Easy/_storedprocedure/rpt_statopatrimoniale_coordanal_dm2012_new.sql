if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_coordanal_dm2012_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_coordanal_dm2012_new]
GO
	
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

-- exec rpt_statopatrimoniale_coordanal_dm2012_new 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','S','N', null ,'N',null, null, 'N'
 --exec rpt_statopatrimoniale_dm2012_2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','S', null ,null, null, 'N'
 --exec rpt_statopatrimoniale_coordanal_dm2012_new 2017, {ts '2017-01-01 00:00:00'}, {ts '2017-01-01 00:00:00'}, '%','N', 'N',null ,'N', null, null, 'N'
 --exec rpt_statopatrimoniale_dm2012 2017, {ts '2017-01-01 00:00:00'}, {ts '2017-1-1 00:00:00'}, '%','N',null,'N',null,null,'S'--2.13
 
CREATE PROCEDURE rpt_statopatrimoniale_coordanal_dm2012_new

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

	/*
	(*) Se @idsor1 valorizzata  e se
	-  @showidsor1child =  S totalizzo i figli, scrive idsor01 nell'intestazione
	-  @showidsor1child =  N filtra solo per la coordinata indicata e , scrive idsor01 nell'intestazione
	se showcoordanal = S restituisce in out tutti i figli, che saranno visualizzati nell'intestazione 
*/

--create table #ANALITICA1(_idsor1 int)
DECLARE @ANALITICA1 TABLE(_idsor1 int)
if ((@idsor1 is not null) and  @showidsor1child = 'N')
Begin
	insert into @ANALITICA1 select @idsor1
	
End	

if ((@idsor1 is not null ) and  @showidsor1child = 'S')
Begin
	insert into @ANALITICA1 (_idsor1)
	select distinct entrydetail.idsor1 
	from entrydetail 
	join entry 
		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	join sortinglink SLK1
		on SLK1.idchild = entrydetail.idsor1 
	where entry.adate BETWEEN @start AND @stop
		AND (entrydetail.idupb like @idupb  OR @idupb = '%')
		AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		and  SLK1.idparent = @idsor1
		AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
		
		
End	


if(@idsor1 is null)
Begin
		insert into @ANALITICA1 
		select null
end


	CREATE TABLE #DATI
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
	
 -------------------------------------------------------------------------------------------------
 --------------------------------------- RICAVI --------------------------------------------------
 -------------------------------------------------------------------------------------------------

 ---------------------------------------------	A) IMMOBILIZZAZIONI	----------------------------------------------------
INSERT INTO #dati  SELECT 0,'A) IMMOBILIZZAZIONI', null, 0,0,0,0, 'A' ,null,null , _idsor1, 'S',10 from  @ANALITICA1
INSERT INTO #dati  SELECT 2,'I.IMMATERIALI', null, 0,0,0,0, 'A' ,null, 1, _idsor1,'S' ,20 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Costi di impianto, di ampliamento e di sviluppo', 'A) I 1)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S' ,30 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Diritti di brevetto e diritti di utilizzazione delle opere dell''ingegno', 'A) I 2)', 0,0,0,0, 'A', 'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',40 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'3) Concessioni, licenze, marchi e diritti simili', 'A) I 3)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',50 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'4) Immobilizzazioni in corso ed acconti', 'A) I 4)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',60 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'5) Altre immobilizzazioni immateriali', 'A) I 5)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI IMMATERIALI',1, _idsor1,'S',70 from  @ANALITICA1
---------------------------------------------	TOTALE IMMOBILIZZAZIONI IMMATERIALI	----------------------------------------------------
INSERT INTO #dati  SELECT 3,'TOTALE IMMOBILIZZAZIONI IMMATERIALI', null, 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, _idsor1,'S',80 from  @ANALITICA1

INSERT INTO #dati  SELECT 2,'II.MATERIALI', null, 0,0,0,0, 'A' ,null, 1, _idsor1,'S',90 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Terreni e fabbricati', 'A) II 1)', 0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',100 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Impianti e attrezzature', 'A) II 2)',  0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1 , _idsor1,'S',110 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'3) Attrezzature scientifiche', 'A) II 3)',  0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',120 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'4) Patrimonio librario, opere d''arte, d''antiquariato e museali', 'A) II 4)',  0,0,0,0, 'A','TOTALE IMMOBILIZZAZIONI MATERIALI',1 , _idsor1,'S' ,130 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'5) Mobili ed arredi', 'A) II 5)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',140 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'6) Immobilizzazioni in corso e acconti', 'A) II 6)',  0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1, _idsor1,'S',150 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'7) Altre immobilizzazioni materiali', 'A) II 7)', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI MATERIALI',1 , _idsor1,'S' ,160 from  @ANALITICA1
---------------------------------------------	TOTALE IMMOBILIZZAZIONI MATERIALI	----------------------------------------------------
INSERT INTO #dati  SELECT 3,'TOTALE IMMOBILIZZAZIONI MATERIALI', null, 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, _idsor1,'S',170 from  @ANALITICA1

INSERT INTO #dati  SELECT 2,'III FINANZIARIE', 'A) III', 0,0,0,0, 'A' ,null, 1, _idsor1,'S' ,180 from  @ANALITICA1
INSERT INTO #dati  SELECT 3,'TOTALE IMMOBILIZZAZIONI FINANZIARIE', 'A) III', 0,0,0,0, 'A' ,'TOTALE IMMOBILIZZAZIONI (A)', 1, _idsor1,'S' ,190 from  @ANALITICA1 
---------------------------------------------	TOTALE IMMOBILIZZAZIONI A	----------------------------------------------------
INSERT INTO #dati  SELECT 4,'TOTALE IMMOBILIZZAZIONI (A)', null, 0,0,0,0, 'A' ,'TOTALE ATTIVO', 1, _idsor1,'S' ,200 from  @ANALITICA1

-----------------------------------------------	B) ATTIVO CIRCOLANTE	------------------------------------------------------------
INSERT INTO #dati  SELECT 0,'B) ATTIVO CIRCOLANTE', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S' ,210 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'I RIMANENZE', 'B) I', 0,0,0,0, 'A' ,'TOTALE RIMANENZE', 1, _idsor1,'S',220 from  @ANALITICA1
INSERT INTO #dati  SELECT 2,'TOTALE RIMANENZE', null, 0,0,0,0, 'A' , 'TOTALE ATTIVO CIRCOLANTE (B)', 1, _idsor1,'S',230  from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 231 from  @ANALITICA1 -- Fittizia
-----------------------------------------------II CREDITI	------------------------------------------------------------
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 240 from  @ANALITICA1 -- Fittizia

INSERT INTO #dati  SELECT 1,'II CREDITI  (con separata indicazione, per ciascuna voce, degli importi esigibili entro l''esercizio successivo)', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S',250 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 251 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'A' ,null, 1, null,'N' , 260 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 1,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)', 0,0,0,0, 'A'	,'TOTALE CREDITI',1, _idsor1,'S',270  from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)e', 0,0,0,0, 'A'	,'B) II 1)',1, _idsor1,'P' ,271 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'1) Crediti verso MIUR e altre Amministrazioni Centrali',	'B) II 1)o', 0,0,0,0, 'A'	,'B) II 1)',1, _idsor1,'N' ,280 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)', 0,0,0,0, 'A', 'TOTALE CREDITI',1, _idsor1,'S',290 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)e', 0,0,0,0, 'A', 'B) II 2)',1, _idsor1,'P' ,291from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'2) Crediti verso Regioni e Province Autonome',				'B) II 2)o', 0,0,0,0, 'A', 'B) II 2)',1, _idsor1,'N',300 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)', 0,0,0,0, 'A' ,'TOTALE CREDITI',	1, _idsor1,'S',310 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)e', 0,0,0,0, 'A' ,'B) II 3)',		1, _idsor1,'P',311 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'3) Crediti verso altre Amministrazioni locali',			'B) II 3)o', 0,0,0,0, 'A' ,'B) II 3)',		1, _idsor1,'N',320  from  @ANALITICA1

IF (@ayear <= 2017) 
Begin
	INSERT INTO #dati  SELECT 1,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)', 0,0,0,0, 'A' ,'TOTALE CREDITI'	,1, _idsor1,'S',325  from  @ANALITICA1
	INSERT INTO #dati  SELECT 0,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)e', 0,0,0,0, 'A' ,'B) II 4)'		,1, _idsor1,'P',326  from  @ANALITICA1
	INSERT INTO #dati  SELECT 0,'4) Crediti verso l''Unione Europea e altri Organismi Internazionali', 'B) II 4)o', 0,0,0,0, 'A' ,'B) II 4)'		,1, _idsor1,'N',330 from  @ANALITICA1
	
end
else
Begin
	INSERT INTO #dati  SELECT 1,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)', 0,0,0,0, 'A' , 'TOTALE CREDITI'				,1, _idsor1,'S',325 from  @ANALITICA1
	INSERT INTO #dati  SELECT 0,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)e', 0,0,0,0, 'A' ,'B) II 4)'					,1, _idsor1,'P',326 from  @ANALITICA1
	INSERT INTO #dati  SELECT 0,'4) Crediti verso l''Unione Europea e Resto del Mondo', 'B) II 4)o', 0,0,0,0, 'A' ,'B) II 4)'					,1, _idsor1,'N',330 from  @ANALITICA1
end

INSERT INTO #dati  SELECT 1,'5) Crediti verso Università', 'B) II 5)', 0,0,0,0, 'A' ,'TOTALE CREDITI'	,1, _idsor1,'S' ,340 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'5) Crediti verso Università', 'B) II 5)e', 0,0,0,0, 'A' ,'B) II 5)',		1, _idsor1,'P'	,341 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'5) Crediti verso Università', 'B) II 5)o', 0,0,0,0, 'A' ,'B) II 5)',		1, _idsor1,'N'	,350 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)', 0,0,0,0, 'A' ,'TOTALE CREDITI',1, _idsor1,'S',360 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)e', 0,0,0,0, 'A' ,'B) II 6)',1, _idsor1,'P',361 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'6) Crediti verso studenti per tasse e contributi', 'B) II 6)o', 0,0,0,0, 'A' ,'B) II 6)',1, _idsor1,'N',370 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'7) Crediti verso Società ed enti controllati', 'B) II 7)', 0,0,0,0, 'A' ,'TOTALE CREDITI',1, _idsor1,'S',380  from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'7) Crediti verso Società ed enti controllati', 'B) II 7)e', 0,0,0,0, 'A' ,'B) II 7)',1, _idsor1,'P',381 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'7) Crediti verso Società ed enti controllati', 'B) II 7)o', 0,0,0,0, 'A' ,'B) II 7)',1, _idsor1,'N' ,390 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'8) Crediti verso altri (pubblici)', 'B) II 8)', 0,0,0,0,	'A' ,'TOTALE CREDITI',1, _idsor1,'S',400 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'8) Crediti verso altri (pubblici)', 'B) II 8)e', 0,0,0,0,	'A' ,'B) II 8)',1, _idsor1,'P' ,401 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'8) Crediti verso altri (pubblici)', 'B) II 8)o', 0,0,0,0,	'A' ,'B) II 8)',1, _idsor1,'N',410 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'9) Crediti verso altri (privati)', 'B) II 9)', 0,0,0,0,	'A' ,'TOTALE CREDITI',1, _idsor1,'S',420 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'9) Crediti verso altri (privati)', 'B) II 9)e', 0,0,0,0,	'A' ,'B) II 9)',1, _idsor1,'P' ,421 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'9) Crediti verso altri (privati)', 'B) II 9)o', 0,0,0,0,	'A' ,'B) II 9)',1, _idsor1,'N',430 from  @ANALITICA1
-----------------------------------------------TOTALE CREDITI	------------------------------------------------------------
INSERT INTO #dati  SELECT 2,'TOTALE CREDITI', null, 0,0,0,0,	'A' ,'TOTALE ATTIVO CIRCOLANTE (B)', 1, _idsor1,'S' ,440 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0,				'A' ,null, 1, null,'N' , 441 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 2,'TOTALE CREDITI(e)', null, 0,0,0,0, 'A' ,null, 1, _idsor1,'P',450 from  @ANALITICA1
-------------------------------------------------	III ATTIVITA'' FINANZIARIE ----------------------------------------------------
INSERT INTO #dati  SELECT 1,'III ATTIVITA'' FINANZIARIE',		'B) III',  0,0,0,0, 'A',  'TOTALE ATTIVITA'' FINANZIARIE',1 , _idsor1,'S',460 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0,									'A' ,null, 1, null,'N' , 461 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 2,'TOTALE ATTIVITA'' FINANZIARIE',	null,  0,0,0,0,		'A', null,1, _idsor1,'S' ,470 from  @ANALITICA1

-------------------------------------------------	IV DISPONIBILITA'' LIQUIDE		----------------------------------------------------
INSERT INTO #dati  SELECT 2,'IV DISPONIBILITA'' LIQUIDE',		null,  0,0,0,0,	'A' ,  null,1, _idsor1,'S' ,480 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Depositi bancari e postali',	'B) IV 1)', 0,0,0,0, 'A' ,'TOTALE DISPONIBILITA'' LIQUIDE',1, _idsor1,'S',490   from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Denaro e valori in cassa',		'B) IV 2)', 0,0,0,0, 'A', 'TOTALE DISPONIBILITA'' LIQUIDE',1, _idsor1,'S',500  from  @ANALITICA1
INSERT INTO #dati  SELECT 2,'TOTALE DISPONIBILITA'' LIQUIDE',	null, 0,0,0,0, 'A',  'TOTALE ATTIVO CIRCOLANTE (B)',1 , _idsor1,'S',510 from  @ANALITICA1
----------------------------------------------- TOTALE		B) ATTIVO CIRCOLANTE	------------------------------------------------------------
INSERT INTO #dati  SELECT 3,'TOTALE ATTIVO CIRCOLANTE (B)', null, 0,0,0,0, 'A' ,'TOTALE ATTIVO', 1, _idsor1,'S' ,520 from  @ANALITICA1

-----------------------------C) RATEI E RISCONTI ATTIVI ---------------------------------- 
INSERT INTO #dati  SELECT 0,'C) RATEI E RISCONTI ATTIVI', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S' ,530 from  @ANALITICA1

IF (@ayear <= 2017) 
Begin
	INSERT INTO #dati  SELECT 2,'c1)	Ratei per progetti e ricerche in corso',	'C) c1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S', 540 from  @ANALITICA1
end
else
Begin
	INSERT INTO #dati  SELECT 2,'c1)	Altri ratei e risconti attivi',				'C) c1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S',540 from  @ANALITICA1
end
INSERT INTO #dati  SELECT 2,'c2)	Altri ratei e risconti attivi', 'C) c2)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S' ,550from  @ANALITICA1
---------------------------------------	D)	RATEI ATTIVI PER PROGETTI E RICERCHE IN CORSO	--------------------------------------------------------------------
IF (@ayear >= 2018) 
Begin
	INSERT INTO #dati  SELECT 0,'D)	RATEI ATTIVI PER PROGETTI E RICERCHE IN CORSO', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S',560 from  @ANALITICA1
	INSERT INTO #dati  SELECT 2,'d 1)	Ratei attivi per progetti e ricerche finanziate e co-finanziate in corso', 'd 1)', 0,0,0,0, 'A' ,'TOTALE ATTIVO',1, _idsor1,'S',560 from  @ANALITICA1
End

--------------------------------------TOTALE ATTIVO-----------------------------------
INSERT INTO #dati  SELECT 0,'TOTALE ATTIVO', null, 0,0,0,0, 'A' ,null,null , _idsor1,'S',570 from  @ANALITICA1
------------------------------------------------------------------------------------------------

----------------------------------------------- POI CI SONO I CONTI D'ORDINE ATTIVI ----------------------------

INSERT INTO #dati  SELECT 0,'A)	PATRIMONIO NETTO', null, 0,0,0,0, 'P' ,null,null , _idsor1,'S',10 from  @ANALITICA1
INSERT INTO #dati  SELECT 3,'I FONDO DI DOTAZIONE DELL''ATENEO', 'A) I', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, _idsor1,'S',20 from  @ANALITICA1

INSERT INTO #dati  SELECT 2,'II PATRIMONIO VINCOLATO', null, 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO', 1, _idsor1,'S',30 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Fondi vincolati destinati da terzi', 'A) II 1)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, _idsor1,'S' ,40 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Fondi vincolati per decisione degli organi istituzionali', 'A) II 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, _idsor1,'S' ,50 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'3) Riserve vincolate(per progetti specifici, obblighi di legge,o altro)', 'A) II 3)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO VINCOLATO',1, _idsor1,'S' ,60 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 70 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 3,'TOTALE PATRIMONIO VINCOLATO', null, 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, _idsor1,'S',80 from  @ANALITICA1

INSERT INTO #dati  SELECT 2,'III PATRIMONIO NON VINCOLATO', null, 0,0,0,0, 'P' ,null, 1, _idsor1,'S',90 from  @ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Risultato gestionale esercizio', 'A) III 1)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S' ,100 from  @ANALITICA1
if (@ayear <=2017) 
Begin
    INSERT INTO #dati  SELECT 1,'2) Risultati gestionali relativi ad esercizi precedenti', 'A) III 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S' ,110 from  @ANALITICA1
End
ELSE
Begin
    INSERT INTO #dati  SELECT 1,'2) Risultati relativi ad esercizi precedenti', 'A) III 2)', 0,0,0,0, 'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S' ,110 from  @ANALITICA1
End
INSERT INTO #dati  SELECT 1,'3) Riserve statutarie', 'A) III 3)', 0,0,0,0,			'P' ,'TOTALE PATRIMONIO NON VINCOLATO',1, _idsor1,'S',120  from  @ANALITICA1
INSERT INTO #dati  SELECT 3,'TOTALE PATRIMONIO NON VINCOLATO', null, 0,0,0,0,		'P' ,'TOTALE PATRIMONIO NETTO(A)', 1, _idsor1,'S' ,130 from  @ANALITICA1
INSERT INTO #dati  SELECT 4,'TOTALE PATRIMONIO NETTO(A)', null, 0,0,0,0,			'P' ,'TOTALE PASSIVO', 1, _idsor1,'S' ,140 from  @ANALITICA1

INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' ,150 from  @ANALITICA1 -- Fittizia

INSERT INTO #dati  SELECT 0,'B)	FONDI PER RISCHI ED ONERI', null, 0,0,0,0,			'P' ,null,null , _idsor1,'S' ,160 from  @ANALITICA1
INSERT INTO #dati  SELECT 2,'TOTALE FONDI PER RISCHI ED ONERI (B)', 'B)', 0,0,0,0,	'P' ,'TOTALE PASSIVO',null , _idsor1,'S' ,170 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0,									'P' ,null, 1, null,'N' ,180 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 2,'C)	TRATTAMENTO DI FINE RAPPORTO DI LAVORO SUBORDINATO', 'C)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',null , _idsor1,'S',190 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 200 from  @ANALITICA1 -- Fittizia
-------------------------------------------------------	DEBITI -------------------------------
INSERT INTO #dati  SELECT 2,'D)	DEBITI (con separata indicazione, per ciascuna voce, degli importi esigibili oltre l''esercizio successivo)', null, 0,0,0,0, 'P' ,null,null , _idsor1,'S',210 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 220 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 1,'1) Mutui e Debiti verso banche', 'D) 1)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1   ,	_idsor1,'S' ,230 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'1) Mutui e Debiti verso banche', 'D) 1)e', 0,0,0,0, 'P', 'D) 1)',1   ,				_idsor1,'N' ,231 from  @ANALITICA1 -- hanno lo stesso ordine stampa perchè solo P verrà visualizzato
INSERT INTO #dati  SELECT 0,'1) Mutui e Debiti verso banche', 'D) 1)o', 0,0,0,0, 'P', 'D) 1)',1   ,				_idsor1,'P' ,240 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)',	0,0,0,0, 'P'  , 'TOTALE DEBITI (D)',1  , _idsor1,'S',250 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)e',				0,0,0,0, 'P'  , 'D) 2)',1  , _idsor1,'N',251 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'2) Debiti verso MIUR e altre Amministrazioni centrali',  'D) 2)o',				0,0,0,0, 'P'  , 'D) 2)',1  , _idsor1,'P',260 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'3) Debiti verso Regione e Province Autonome',  'D) 3)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1  , _idsor1,'S',270 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'3) Debiti verso Regione e Province Autonome',  'D) 3)e', 0,0,0,0, 'P',  'D) 3)',1  , _idsor1,'N',271 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'3) Debiti verso Regione e Province Autonome',  'D) 3)o', 0,0,0,0, 'P',  'D) 3)',1  , _idsor1,'P',280 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'4) Debiti verso altre Amministrazioni locali', 'D) 4)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',290 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'4) Debiti verso altre Amministrazioni locali', 'D) 4)e', 0,0,0,0, 'P' , 'D) 4)',1  , _idsor1,'N' ,291 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'4) Debiti verso altre Amministrazioni locali', 'D) 4)o', 0,0,0,0, 'P' , 'D) 4)',1  , _idsor1,'P',300 from  @ANALITICA1

IF (@ayear <= 2017) 
begin
	INSERT INTO #dati  SELECT 1,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)',0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S' ,310 from  @ANALITICA1
	INSERT INTO #dati  SELECT 0,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)e',0,0,0,0, 'P' , 'D) 5)',1  , _idsor1,'N',311 from  @ANALITICA1
	INSERT INTO #dati  SELECT 0,'5) Debiti verso l''Unione Europea e altri Organismi Internazionali', 'D) 5)o',0,0,0,0, 'P' , 'D) 5)',1  , _idsor1,'P',320 from  @ANALITICA1
end
ELSE
begin
	INSERT INTO #dati  SELECT 1,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',310 from  @ANALITICA1
	 INSERT INTO #dati  SELECT 0,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)e', 0,0,0,0, 'P' , 'D) 5)',1  , _idsor1,'N',311 from  @ANALITICA1
	 INSERT INTO #dati  SELECT 0,'5) Debiti verso l''Unione Europea  e Resto del Mondo', 'D) 5)o', 0,0,0,0, 'P' ,'D) 5)',1  , _idsor1,'P' ,320 from  @ANALITICA1
	 end
INSERT INTO #dati  SELECT 1,'6) Debiti verso Università',	'D) 6)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',325 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'6) Debiti verso Università',	'D) 6)e', 0,0,0,0, 'P' , 'D) 6)',1  , _idsor1,'N',326 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'6) Debiti verso Università',	'D) 6)o', 0,0,0,0, 'P' , 'D) 6)',1  , _idsor1,'P' ,330 from  @ANALITICA1


INSERT INTO #dati  SELECT 1,'7) Debiti verso studenti',		'D) 7)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1   , _idsor1,'S',340 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'7) Debiti verso studenti',		'D) 7)e', 0,0,0,0, 'P', 'D) 7)',1   , _idsor1,'N' ,341 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'7) Debiti verso studenti',		'D) 7)o', 0,0,0,0, 'P', 'D) 7)',1   , _idsor1,'P',350 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'8) Acconti',					'D) 8)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',360 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'8) Acconti',					'D) 8)e', 0,0,0,0, 'P' , 'D) 8)',1  , _idsor1,'N' ,361 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'8) Acconti',					'D) 8)o', 0,0,0,0, 'P' , 'D) 8)',1  , _idsor1,'P', 370 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'9) Debiti verso fornitori',	'D) 9)', 0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1   , _idsor1,'S' ,380 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'9) Debiti verso fornitori',	'D) 9)e', 0,0,0,0, 'P' , 'D) 9)',1   , _idsor1,'N' ,381 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'9) Debiti verso fornitori',	'D) 9)o', 0,0,0,0, 'P' , 'D) 9)',1   , _idsor1,'P',390  from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'10) Debiti verso dipendenti',	'D) 10)',  0,0,0,0, 'P' , 'TOTALE DEBITI (D)',1  , _idsor1,'S',400  from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'10) Debiti verso dipendenti',	'D) 10)e',  0,0,0,0, 'P' , 'D) 10)',1  , _idsor1,'N' ,401 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'10) Debiti verso dipendenti',	'D) 10)o',  0,0,0,0, 'P' , 'D) 10)',1  , _idsor1,'P' ,410 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'11) Debiti verso società o enti controllati', 'D) 11)', 0,0,0,0, 'P'  , 'TOTALE DEBITI (D)',1  , _idsor1,'S' ,420 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'11) Debiti verso società o enti controllati', 'D) 11)e', 0,0,0,0, 'P'  , 'D) 11)',1  , _idsor1,'N' ,421 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'11) Debiti verso società o enti controllati', 'D) 11)o', 0,0,0,0, 'P'  , 'D) 11)',1  , _idsor1,'P',430 from  @ANALITICA1

INSERT INTO #dati  SELECT 1,'12) Altri debiti',				'D) 12)', 0,0,0,0, 'P', 'TOTALE DEBITI (D)',1    , _idsor1,'S',440 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'12) Altri debiti',				'D) 12)e', 0,0,0,0, 'P', 'D) 12)',1    , _idsor1,'N' ,441 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,'12) Altri debiti',				'D) 12)o', 0,0,0,0, 'P', 'D) 12)',1    , _idsor1,'P',450 from  @ANALITICA1

INSERT INTO #dati  SELECT 2,'TOTALE DEBITI (D)', null, 0,0,0,0, 'P' ,'TOTALE PASSIVO',null , _idsor1,'S',460 from  @ANALITICA1
INSERT INTO #dati  SELECT 2,'TOTALE DEBITI(e)', null, 0,0,0,0, 'P' ,null, 1, _idsor1,'P' ,461 from  @ANALITICA1
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 470 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 2,'E) RATEI E RISCONTI PASSIVI E CONTRIBUTI AGLI INVESTIMENTI', null, 0,0,0,0, 'A' ,null,1 , _idsor1,'S' ,480 from  @ANALITICA1
IF (@ayear <= 2017) 
begin
	INSERT INTO #dati  SELECT 2,'e1) Risconti per progetti e ricerche in corso', 'E) e1)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',1 , _idsor1,'S' ,490 from  @ANALITICA1
end
Else
begin
	INSERT INTO #dati  SELECT 1,'e1) Contributi agli investimenti', 'E) e1)', 0,0,0,0, 'P' ,'TOTALE PASSIVO',1 , _idsor1,'S',490 from  @ANALITICA1
end
 
IF (@ayear <= 2017) 
begin
		INSERT INTO #dati  SELECT 1,'e2) Contributi agli investimenti', 'E) e2)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S',510 from  @ANALITICA1
end
Else
begin	
	INSERT INTO #dati  SELECT 1,'e2) Altri ratei e risconti passivi', 'E) e2)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S',510 from  @ANALITICA1
end
INSERT INTO #dati  SELECT 1,'e3) Altri ratei e risconti passivi', 'E) e3)', 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S' ,520 from  @ANALITICA1
if(@ayear >=2018)
Begin
	INSERT INTO #dati  SELECT 2,'F)	RISCONTI PASSIVI PER PROGETTI E RICERCHE IN CORSO', null, 0,0,0,0, 'P' ,'TOTALE PASSIVO', 1, _idsor1,'S' ,530 from  @ANALITICA1
	INSERT INTO #dati  SELECT 1,'f1) Risconti passivi per progetti e ricerche finanziate e co-finanziate in corso', 'f 1)', 0,0,0,0, 'P' ,null, 1, _idsor1,'S',540 from  @ANALITICA1
End
else
Begin
	INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 530 from  @ANALITICA1 -- Fittizia
	INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 540 from  @ANALITICA1 -- Fittizia
end
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 550 from  @ANALITICA1 -- Fittizia
INSERT INTO #dati  SELECT 0,null, null, 0,0,0,0, 'P' ,null, 1, null,'N' , 560 from  @ANALITICA1 -- Fittizia
--------------------------------------TOTALE PASSIVO ------------------------------------------
INSERT INTO #dati  SELECT 0,'TOTALE PASSIVO', null, 0,0,0,0, 'P' ,null,null , _idsor1,'S' ,570 from  @ANALITICA1
------------------------------------------------------------------------------------------------

	
 DECLARE @label varchar(200)
 DECLARE @codepatrimony varchar(200)
 DECLARE @kind char(1)
 DECLARE @ass char(1)
 declare @cursore cursor
 declare @crs_idsor1 int
 
	set @cursore = cursor for 
		select label, codepatrimony, kind, _idsor1
		from #dati WHERE kind in ('P', 'A') and codepatrimony is not null

	open @cursore
	fetch next from @cursore into  @label, @codepatrimony, @kind, @crs_idsor1
	while @@fetch_status = 0
	begin
		   declare @_curramountAttivo   decimal(19,2)
		   declare @_prevamountAttivo   decimal(19,2)
		   declare @_curramountPassivo   decimal(19,2)
		   declare @_prevamountPassivo  decimal(19,2)
		   
		   if(@idsor1 is null)
		   Begin 
				SET @_curramountAttivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND patrimony.patpart = 'A'
								AND patrimony.ayear = @ayear
								AND (@apertura ='N' or entry.identrykind=7)
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								),0)

				SET @_prevamountAttivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND patrimony.patpart = 'A'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								),0)
				SET @_curramountPassivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND patrimony.patpart = 'P'
								AND patrimony.ayear = @ayear
								AND (@apertura ='N' or entry.identrykind=7)
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								),0)


				SET @_prevamountPassivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND patrimony.patpart = 'P'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								),0)
			if (@kind = 'A') 	SET @_curramountAttivo  = - @_curramountAttivo  --- cambio di segno per i costi
			if (@kind = 'A') 	SET @_prevamountAttivo  = - @_prevamountAttivo  --- cambio di segno per i costi

			update #dati set _curramountAttivo = @_curramountAttivo			where codepatrimony = @codepatrimony AND kind = @kind
			update #dati set _prevamountAttivo = @_prevamountAttivo			where codepatrimony = @codepatrimony AND kind = @kind
			update #dati set _curramountPassivo = @_curramountPassivo		where codepatrimony = @codepatrimony AND kind = @kind
			update #dati set _prevamountPassivo = @_prevamountPassivo	    where codepatrimony = @codepatrimony AND kind = @kind
		   End
		   Else
		   Begin
				SET @_curramountAttivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'A'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and entrydetail.idsor1 = @crs_idsor1
								),0)
								  
				SET @_prevamountAttivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND patrimony.patpart = 'A'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and entrydetail.idsor1 = @crs_idsor1
								),0)
				SET @_curramountPassivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND (@apertura ='N' or entry.identrykind=7)
								AND patrimony.ayear = @ayear
								AND patrimony.patpart = 'P'
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and entrydetail.idsor1 = @crs_idsor1
								),0)
								  
				SET @_prevamountPassivo = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account 
								ON account.idacc = entrydetail.idacc
							JOIN patrimony
								ON patrimony.idpatrimony = account.idpatrimony
							WHERE  entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND patrimony.codepatrimony = @codepatrimony
								AND patrimony.patpart = 'P'
								AND patrimony.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and entrydetail.idsor1 = @crs_idsor1
								),0)
			if (@kind = 'A') 	SET @_curramountAttivo  = - @_curramountAttivo  --- cambio di segno per i costi
			if (@kind = 'A') 	SET @_prevamountAttivo  = - @_prevamountAttivo  --- cambio di segno per i costi

			update #dati set _curramountAttivo = @_curramountAttivo		where codepatrimony = @codepatrimony  AND kind = @kind and _idsor1 = @crs_idsor1
			update #dati set _prevamountAttivo = @_prevamountAttivo	    where codepatrimony = @codepatrimony  AND kind = @kind and _idsor1 = @crs_idsor1
			update #dati set _curramountPassivo = @_curramountPassivo	where codepatrimony = @codepatrimony  AND kind = @kind and _idsor1 = @crs_idsor1
			update #dati set _prevamountPassivo = @_prevamountPassivo	where codepatrimony = @codepatrimony  AND kind = @kind and _idsor1 = @crs_idsor1

		   End
		   set @_curramountAttivo		= 0
		   set @_prevamountAttivo		= 0 
		   set @_curramountPassivo		= 0
		   set @_prevamountPassivo		= 0 

	fetch next from  @cursore into   @label, @codepatrimony, @kind, @crs_idsor1
	end
	close @cursore
	deallocate @cursore
	END
				
	if (@idsor1 is null )
		update #dati set _idsor1 = 0 -- metto a 0 per evitare di appesantire il codice con gli isnull, e per non evitare di interrogare ogni volta il parametro (cose che rallente la query)

-- gestisco i valori aggregati di livello 1, ove visualizziamo la parte (e)														
	UPDATE #dati SET _curramountAttivo = _curramountAttivo +  isnull((select sum(_curramountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.codepatrimony and nlevel = 0 and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A'  and nlevel = 1 

	
	UPDATE #dati SET _prevamountAttivo = _prevamountAttivo +  isnull((select sum(_prevamountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.codepatrimony and nlevel = 0 and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A'  and nlevel = 1 

	UPDATE #dati SET _curramountPassivo = _curramountPassivo +  isnull((select sum(_curramountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.codepatrimony and nlevel = 0 and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 1 

	
	UPDATE #dati SET _prevamountPassivo = _prevamountPassivo +  isnull((select sum(_prevamountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.codepatrimony and nlevel = 0 and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 1 
	
-- gestisco i valori aggregati di livello 2, costi ricavi o voci aggregate (costi/ricavi)															
	UPDATE #dati SET _curramountAttivo = _curramountAttivo +  isnull((select sum(_curramountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel = 1 and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A'  and nlevel = 2 

	UPDATE #dati SET _prevamountAttivo = _prevamountAttivo +  isnull((select sum(_prevamountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel = 1 and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A'  and nlevel = 2 

	UPDATE #dati SET _curramountPassivo = _curramountPassivo +  isnull((select sum(_curramountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel = 1 and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 2 

	
	UPDATE #dati SET _prevamountPassivo = _prevamountPassivo +  isnull((select sum(_prevamountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel = 1 and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 2 

-- gestisco i valori aggregati di livello 3, costi ricavi o voci aggregate (costi/ricavi)
	UPDATE #dati SET _curramountAttivo = _curramountAttivo +  isnull((select sum(_curramountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel IN(1, 2) and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A' and nlevel = 3 

	UPDATE #dati SET _prevamountAttivo = _prevamountAttivo +  isnull((select sum(_prevamountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel IN(1, 2) and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A'  and nlevel = 3 

	UPDATE #dati SET _curramountPassivo = _curramountPassivo +  isnull((select sum(_curramountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel IN(1, 2) and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 3 

	UPDATE #dati SET _prevamountPassivo = _prevamountPassivo +  isnull((select sum(_prevamountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel IN(1, 2) and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 3 
--Valorizzo la voce Totale_Proventi_A
-- gestisco i valori aggregati di livello 4, costi ricavi o voci aggregate (costi/ricavi)
	UPDATE #dati SET _curramountAttivo = _curramountAttivo +  isnull((select sum(_curramountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel =3 and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A' and nlevel = 4 

	UPDATE #dati SET _prevamountAttivo = _prevamountAttivo +  isnull((select sum(_prevamountAttivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel =3 and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='A'  and nlevel = 4 

	UPDATE #dati SET _curramountPassivo = _curramountPassivo +  isnull((select sum(_curramountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel =3 and  #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 4 

	UPDATE #dati SET _prevamountPassivo = _prevamountPassivo +  isnull((select sum(_prevamountPassivo * segno) FROM #dati child
									where child.parent_label = #dati.label and nlevel =3 and #dati._idsor1 = child._idsor1 )	,0)	
	where  #dati.kind ='P'  and nlevel = 4 	

	UPDATE #dati SET _curramountAttivo = _curramountAttivo + isnull((select sum(_curramountAttivo) FROM #dati child
			where child.KIND = 'A' and child.parent_label = #dati.label and mostra='S' and #dati._idsor1 = child._idsor1 )	,0)	
	where #dati.label = ('TOTALE ATTIVO') 

	UPDATE #dati SET _prevamountAttivo = _prevamountAttivo + isnull((select sum(_prevamountAttivo) FROM #dati child
			where child.KIND = 'A' and child.parent_label = #dati.label  and  mostra='S' and #dati._idsor1 = child._idsor1 )	,0)	
	where #dati.label = ('TOTALE ATTIVO') 

	UPDATE #dati SET _curramountPassivo = _curramountPassivo + isnull((select sum(_curramountPassivo ) FROM #dati child
			where child.KIND = 'P'and  child.parent_label = #dati.label  and mostra='S' and #dati._idsor1 = child._idsor1 )	,0)	
	where #dati.label = ('TOTALE PASSIVO')

	UPDATE #dati SET _prevamountPassivo = _prevamountPassivo + isnull((select sum(_prevamountPassivo ) FROM #dati child
			where child.KIND = 'P'and child.parent_label = #dati.label and mostra='S' and  #dati._idsor1 = child._idsor1)	,0)	
	where #dati.label = ('TOTALE PASSIVO') 
	
	
	-- Solo la sezione Crediti della parte Attiva ha la doppia scrittura
	UPDATE #dati set _curramountAttivo = isnull((select sum(_curramountAttivo * segno) FROM #dati child
											where child.KIND = 'A' and child.mostra = 'P' and  #dati._idsor1 = child._idsor1),0)
	where #dati.label = 'TOTALE CREDITI(e)'

	UPDATE #dati set _prevamountAttivo = isnull((select sum(_prevamountAttivo * segno) FROM #dati child
											where child.KIND = 'A' and child.mostra = 'P' and  #dati._idsor1 = child._idsor1),0)
	where #dati.label = 'TOTALE CREDITI(e)'

	UPDATE #dati set _curramountPassivo = isnull((select sum(_curramountPassivo * segno) FROM #dati child
											where child.KIND = 'P' and child.mostra = 'P' and  #dati._idsor1 = child._idsor1),0)
	where #dati.label = 'TOTALE DEBITI(e)'

	UPDATE #dati set _prevamountPassivo = isnull((select sum(_prevamountPassivo * segno) FROM #dati child
											where child.KIND = 'P' and child.mostra = 'P' and  #dati._idsor1 = child._idsor1),0)
	where #dati.label = 'TOTALE DEBITI(e)'


	

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal


/*
	(*) Se @idsor1 valorizzata  e se
	-  @showidsor1child =  S totalizzo i figli, scrive idsor01 nell'intestazione
	-  @showidsor1child =  N filtra solo per la coordinata indicata e , scrive idsor01 nell'intestazione
	se showcoordanal = S restituisce in out tutti i figli, che saranno visualizzati nell'intestazione 
*/

if(@idsor1 is not null and @showidsor1child =  'S' and @showcoordanal = 'N')
Begin
--Se si vuole considerare i figli E si vuole anche mostarli, mostra i vari idsor, se invece si vuole SOLO totalizzarli SENZA mostarli si fa l'update
	update #dati set _idsor1 = @idsor1
End
if (@idsor1 is null)
Begin
	SELECT distinct 
		@ayear				  AS ayear         ,
		@idupboriginal		  as idupb         ,
		@codeupb				  as codeupb	   ,
		@title				  as upb		   ,
		A.nlevel as'nlevelAttivo',
		CASE 
			WHEN A.nlevel = 1 THEN SPACE(2) + A.label
			WHEN A.nlevel = 2 THEN SPACE(1) + A.label
			ELSE A.label
		END  as labelAttivo,
		A.codepatrimony as codepatrimonyA,
		A.segno as segnoA,
		A.parent_label as'parent_labelAttivo',
		A._curramountAttivo,
		A._prevamountAttivo,
		A.mostra as mostraA,

		P.nlevel as 'nlevelPassivo',
		CASE 
			WHEN P.nlevel = 1 THEN SPACE(2) + P.label
			WHEN P.nlevel = 2 THEN SPACE(1) + P.label
			ELSE P.label
		END  as labelPassivo,
		P.codepatrimony as codepatrimonyP,
		p.mostra as mostraP,
		P._curramountPassivo,
		P._prevamountPassivo,
		--kind,
		P.parent_label as 'parent_labelPassivo',
		P.segno asegnoP,
		A.ordinestampa as ordinestampaA,
		P.ordinestampa as ordinestampaP,
		null as idsor,
		null as sortcode1,
		null as titlecode1
		FROM #dati A
		left outer join #dati P
			on A.ordinestampa = P.ordinestampa 
		WHERE  A.kind = 'A' and P.kind = 'P'
		order by A.ordinestampa,P.ordinestampa
end
else
Begin
	SELECT --distinct 
		@ayear				  AS ayear         ,
		@idupboriginal		  as idupb         ,
		@codeupb				  as codeupb	   ,
		@title				  as upb		   ,
		A.nlevel as'nlevelAttivo',
		CASE 
			WHEN A.nlevel = 1 THEN SPACE(2) + A.label
			WHEN A.nlevel = 2 THEN SPACE(1) + A.label
			ELSE A.label
		END  as labelAttivo,
		A.codepatrimony as codepatrimonyA,
		A.segno as segnoA,
		A.parent_label as'parent_labelAttivo',
		sum(A._curramountAttivo) as _curramountAttivo,
		sum(A._prevamountAttivo) as _prevamountAttivo,
		A.mostra as mostraA,

		P.nlevel as 'nlevelPassivo',
		CASE 
			WHEN P.nlevel = 1 THEN SPACE(2) + P.label
			WHEN P.nlevel = 2 THEN SPACE(1) + P.label
			ELSE P.label
		END  as labelPassivo,
		P.codepatrimony as codepatrimonyP,
		p.mostra as mostraP,
		sum(P._curramountPassivo) as _curramountPassivo,
		sum(P._prevamountPassivo) as _prevamountPassivo,
		--kind,
		P.parent_label as 'parent_labelPassivo',
		P.segno asegnoP,
		A.ordinestampa as ordinestampaA,
		P.ordinestampa as ordinestampaP,
		sorting.idsor as idsor,
		sorting.sortcode as sortcode1,
		sorting.description as titlecode1
	
		FROM #dati A
		left outer join #dati P
			on A.ordinestampa = P.ordinestampa 
		join sorting
			on A._idsor1 = sorting.idsor
		WHERE  A.kind = 'A' and P.kind = 'P'
			and P._idsor1 = A._idsor1
		group by A.nlevel, P.nlevel, A.label, P.label, A.codepatrimony,P.codepatrimony,
		 --kind, 
		 A.parent_label, P.parent_label, A.segno, P.segno, A.ordinestampa,P.ordinestampa,  
		 A.mostra, P.mostra,
		 sortcode, printingorder,sorting.idsor,		sorting.sortcode,sorting.description
		order by sortcode1, A.ordinestampa
		

End



	GO
	
	SET QUOTED_IDENTIFIER OFF
	GO
	SET ANSI_NULLS ON
	GO
	
	
	
	
--	exec rpt_statopatrimoniale_coordanal_dm2012_new 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','S','N',null,'N'
--	exec rpt_statopatrimoniale_coordanal_dm2012_new 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-12-31 00:00:00'}, '0001','S', 'S',2033 ,'S'
--	exec rpt_statopatrimoniale_coordanal_dm2012_new 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','S',	'S',2033 ,'S'
--exec rpt_statopatrimoniale_coordanal_dm2012_new 2017, {ts '2017-01-01 00:00:00'}, {ts '2017-12-31 00:00:00'}, '%','S','S', 2033 ,'S',null, null, 'N'
--exec rpt_statopatrimoniale_coordanal_dm2012_new 2017, {ts '2017-01-01 00:00:00'}, {ts '2017-12-31 00:00:00'}, '%','S','N', null ,'N',null, null, 'N'
--exec rpt_statopatrimoniale_coordanal_dm2012_new 2017, {ts '2017-01-01 00:00:00'}, {ts '2017-01-01 00:00:00'}, '%','N', 'N',null ,'N', null, null, 'N'
