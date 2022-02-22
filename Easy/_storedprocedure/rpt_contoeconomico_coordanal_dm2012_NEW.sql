
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contoeconomico_coordanal_dm2012_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contoeconomico_coordanal_dm2012_new]
GO
	
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
--setuser'amministrazione'
CREATE PROCEDURE rpt_contoeconomico_coordanal_dm2012_new
	(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),

	@showcoordanal char(1) , -- Msotra figli
	@idsor1 int, -- Se valorizzato viene mostrato
	@showidsor1child char(1), -- Includi figli

	@idsor2 int=null,	@idsor3 int=null,	
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
DECLARE @Mostracoordianataanalitica1 char(1)
SELECT @Mostracoordianataanalitica1= isnull(paramvalue,'N') 
FROM reportadditionalparam WHERE paramname = 'Mostracoordianataanalitica1'
and reportname = 'contoeconomicodm2012_new'

create table #ANALITICA1(_idsor1 int)
if ((@idsor1 is not null) and  @showidsor1child = 'N')
Begin
	insert into #ANALITICA1 select @idsor1
End	

if ((@idsor1 is not null ) and ( @showidsor1child = 'S')) 
Begin
	insert into #ANALITICA1 (_idsor1)
	select distinct entrydetail.idsor1 
	from entrydetail 
	join entry 
		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	join sortinglink SLK1
		on SLK1.idchild = entrydetail.idsor1 
	where entry.adate BETWEEN @start AND @stop
		AND (entrydetail.idupb like @idupb  OR @idupb = '%')
		AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		and  (SLK1.idparent = @idsor1)
		AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
		
		
End	

if(@idsor1 is null AND @Mostracoordianataanalitica1 = 'S')
Begin
	insert into #ANALITICA1 (_idsor1)
	select distinct entrydetail.idsor1 
	from entrydetail 
	join entry 
		ON entry.yentry = entrydetail.yentry AND entry.nentry = entrydetail.nentry
	join sortinglink SLK1
		on SLK1.idchild = entrydetail.idsor1 
	where entry.adate BETWEEN @start AND @stop
		AND (entrydetail.idupb like @idupb  OR @idupb = '%')
		AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
end



--select * from #ANALITICA1
	CREATE TABLE #dati
	(nlevel int ,				label varchar(200),			codeplaccount varchar(200),		 
	_curramount decimal(19,2),	_prevamount decimal(19,2), 	_saldo decimal(19,2),	_nonrealizzato decimal(19,2),
	 kind char(10) /*Costi o Ricavi, Voce aggregata, SuTotali e Totali */, 
	 parent_label varchar(300), segno int, 
	 _idsor1 int,
	 ordinestampa int identity(1,1)
	 )  
	
 -------------------------------------------------------------------------------------------------
 --------------------------------------- RICAVI --------------------------------------------------
 -------------------------------------------------------------------------------------------------
 /*	I. PROVENTI PROPRI
	1)Proventi per la didattica
	2)Proventi da Ricerche commissionate e trasferimento tecnologico
	3)Proventi da Ricerche con finanziamento competitivi
*/
INSERT INTO #dati  SELECT 0,'A) PROVENTI OPERATIVI', null, 0,0,0,0, 'R' ,null,null , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 2,'I.PROVENTI PROPRI', null, 0,0,0,0, 'R' ,null, 1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Proventi per la didattica', 'A) I 1)', 0,0,0,0, 'R' ,'I.PROVENTI PROPRI',1, _idsor1  from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Proventi da Ricerche commissionate e trasferimento tecnologico', 'A) I 2)', 0,0,0,0, 'R', 'I.PROVENTI PROPRI',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'3) Proventi da Ricerche con finanziamenti competitivi', 'A) I 3)', 0,0,0,0, 'R' ,'I.PROVENTI PROPRI',1, _idsor1 from  #ANALITICA1

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
INSERT INTO #dati  SELECT 2,'II. CONTRIBUTI', null,  0,0,0,0, 'R',  null,1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Contributi MIUR  e altre Amministrazioni Centrali', 'A) II 1)', 0,0,0,0, 'R','II. CONTRIBUTI',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Contibuti Regioni e Province autonome', 'A) II 2)',  0,0,0,0, 'R','II. CONTRIBUTI',1 , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'3) Contributi altre Amministrazioni locali', 'A) II 3)',  0,0,0,0, 'R' ,'II. CONTRIBUTI',1, _idsor1 from  #ANALITICA1

INSERT INTO #dati  SELECT 1, '4) Contributi Unione Europea e altri Organismi Internazionali', 'A) II 4)',  0,0,0,0, 'R','II. CONTRIBUTI',1 , _idsor1 from  #ANALITICA1

INSERT INTO #dati  SELECT 1,'5) Contributi da Università', 'A) II 5)', 0,0,0,0, 'R' ,'II. CONTRIBUTI',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'6) Contributi da altri enti (pubblici)', 'A) II 6)',  0,0,0,0, 'R' ,'II. CONTRIBUTI',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'7) Contributi da altri enti (privati)', 'A) II 7)', 0,0,0,0, 'R' ,'II. CONTRIBUTI',1 , _idsor1 from  #ANALITICA1

-------------- PROVENTI PER ATTIVITA' ASSISTENZIALE ---------------------------------- 
INSERT INTO #dati  SELECT 2,'III. PROVENTI PER ATTIVITA’ ASSISTENZIALE', 'A) III',  0,0,0,0, 'R',  null,1 , _idsor1 from  #ANALITICA1
-------------- PROVENTI PER GESTIONE DIRETTA ---------------------------------- 
INSERT INTO #dati  SELECT 2,'IV. PROVENTI PER LA GESTIONE DIRETTA INTERVENTI PER IL DIRITTO ALLO STUDIO', 'A) IV',  0,0,0,0, 'R', null,1, _idsor1 from  #ANALITICA1
-- V.ALTRI PROVENTI E RICAVI DIVERSI
-- 1) Utilizzo di riserve di Patrimonio netto derivanti dalla contabilità finanziaria
-- 2) Altri Proventi e Ricavi Diversi
INSERT INTO #dati  SELECT 2,'V. ALTRI PROVENTI  E RICAVI DIVERSI','A) V',  0,0,0,0, 'R' ,  null,1, _idsor1 from  #ANALITICA1
-------------- Variazioni Rimanenze  ---------------------------------- 
INSERT INTO #dati  SELECT 2,'VI. VARIAZIONE RIMANENZE', 'A) VI', 0,0,0,0, 'R',  null,1 , _idsor1 from  #ANALITICA1
---------- Incremento Immobilizzazioni per lavoro interni ---------------------------------- 
INSERT INTO #dati  SELECT 2,'VII. INCREMENTO IMMOBILIZZAZIONI PER LAVORI INTERNI', 'A) VII', 0,0,0,0, 'R' , null,1, _idsor1 from  #ANALITICA1
----------- TOTALE PROVENTI (A)-----------------------------------------------------------------
INSERT INTO #dati  SELECT 0,'TOTALE PROVENTI  (A)', null, 0,0,0,0, 'R' ,'RISULTATO DI ESERCIZIO',1 , _idsor1 from  #ANALITICA1
------------------------------------------------------------------------------------------------
-------------------------------------- COSTI ---------------------------------------------------
------------------------------------------------------------------------------------------------
INSERT INTO #dati  SELECT 0,'B) COSTI OPERATIVI', null, 0,0,0,0, 'C' ,null,null , _idsor1 from  #ANALITICA1
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
INSERT INTO #dati  SELECT 3,'VIII.  COSTI DEL PERSONALE',										null, 0,0,0,0, 'C' ,null,1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 2,'1) Costi del personale dedicato alla ricerca e alla didattica',	 null, 0,0,0,0, 'C' ,'VIII.  COSTI DEL PERSONALE',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'a) Docenti/Ricercatori',											'B) VIII 1) a)', 0,0,0,0, 'C' ,'1) Costi del personale dedicato alla ricerca e alla didattica',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'b) Collaborazioni scientifiche (collaboratori, assegnisti, ecc)',	'B) VIII 1) b)', 0,0,0,0, 'C' ,'1) Costi del personale dedicato alla ricerca e alla didattica',1 ,_idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'c) Docenti a contratto',											'B) VIII 1) c)', 0,0,0,0, 'C' ,'1) Costi del personale dedicato alla ricerca e alla didattica',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'d) Esperti linguistici',											'B) VIII 1) d)', 0,0,0,0, 'C' ,'1) Costi del personale dedicato alla ricerca e alla didattica',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'e) Altro personale dedicato alla didattica e alla ricerca',		'B) VIII 1) e)', 0,0,0,0, 'C' ,'1) Costi del personale dedicato alla ricerca e alla didattica',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Costi del personale dirigente e tecnico-amministrativo',		'B) VIII 2)'   , 0,0,0,0, 'C' ,'1) Costi del personale dedicato alla ricerca e alla didattica',1, _idsor1 from  #ANALITICA1

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
INSERT INTO #dati  SELECT 2,'IX. COSTI DELLA GESTIONE CORRENTE', null, 0,0,0,0, 'C'  ,null,1   , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Costi per sostegno agli studenti', 'B) IX 1)', 0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1   , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Costi per il diritto allo studio', 'B) IX 2)', 0,0,0,0, 'C'  , 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'3) Costi per l''attività editoriale', 'B) IX 3)', 0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'4) Trasferimenti a partner di progetti coordinati', 'B) IX 4)', 0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'5) Acquisto materiale consumo per laboratori', 'B) IX 5)', 0,0,0,0, 'C'  , 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'6) Variazione rimanenze di materiale di consumo per laboratori', 'B) IX 6)', 0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'7)Acquisto di libri, periodici e matariale bibliografico', 'B) IX 7)', 0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1   , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'8) Acquisto di servizi e collaborazioni tecnico gestionali', 'B) IX 8)', 0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'9) Acquisto altri materiali', 'B) IX 9)', 0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1   , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'10) Variazione delle rimanenze di materiale', 'B) IX 10)',  0,0,0,0, 'C' , 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'11) Costi per godimento beni di terzi', 'B) IX 11)', 0,0,0,0, 'C'  , 'IX. COSTI DELLA GESTIONE CORRENTE',1  , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'12) Altri costi', 'B) IX 12)', 0,0,0,0, 'C', 'IX. COSTI DELLA GESTIONE CORRENTE',1    , _idsor1 from  #ANALITICA1
/*	
	X.AMMORTAMENTI E SVALUTAZIONI
		1) Ammortamenti immobilizzazioni immateriali
		2) Ammortamenti immobilizzazioni materiali
		3) Svalutazioni immobilizzazioni
		4) Svalutazioni dei crediti compresi nell'attivo circolante e nelle disponibilità liquide
*/
INSERT INTO #dati  SELECT 2,'X. AMMORTAMENTI E SVALUTAZIONI', null, 0,0,0,0, 'C' ,null,1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'1) Ammortamenti immobilizzazioni immateriali', 'B) X 1)', 0,0,0,0, 'C','X. AMMORTAMENTI E SVALUTAZIONI',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Ammortamenti immobilizzazioni materiali', 'B) X 2)', 0,0,0,0, 'C','X. AMMORTAMENTI E SVALUTAZIONI',1 , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'3) Svalutazioni immobilizzazioni', 'B) X 3)', 0,0,0,0, 'C','X. AMMORTAMENTI E SVALUTAZIONI',1 , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'4) Svalutazioni dei crediti compresi nell’attivo circolante e nelle disponibilità liquide', 'B) X 4)', 0,0,0,0, 'C' ,'X. AMMORTAMENTI E SVALUTAZIONI',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 2,'XI. ACCANTONAMENTI PER RISCHI E ONERI', 'B) XI', 0,0,0,0, 'C', null, 1 , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 2,'XII. ONERI DIVERSI DI GESTIONE','B) XII', 0,0,0,0, 'C' , null, 1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 0,'TOTALE COSTI  (B)', null, 0,0,0,0, 'C' ,'RISULTATO DI ESERCIZIO',-1 , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 0,'DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)', null, 0,0,0,0, 'A' ,null,null , _idsor1 from  #ANALITICA1
/*
	C) PROVENTI ED ONERI FINANZIARI
	1) Proventi finanziari
	2) Interessi ed altri oneri finanziari 
	3) Utili su cambi 
	4) Perdite su cambi 
*/
INSERT INTO #dati  SELECT 3,'C) PROVENTI E ONERI FINANZIARI', null, 0,0,0,0, 'A', 'RISULTATO DI ESERCIZIO',1 , _idsor1 from  #ANALITICA1 --,'S' 
INSERT INTO #dati  SELECT 1,'1) Proventi finanziari', 'C) 1)', 0,0,0,0, 'R', 'C) PROVENTI E ONERI FINANZIARI',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Interessi ed altri oneri finanziari', 'C) 2)', 0,0,0,0, 'C', 'C) PROVENTI E ONERI FINANZIARI',-1 , _idsor1 from  #ANALITICA1 --,'S' 
INSERT INTO #dati  SELECT 2,'3) Utili e Perdite su cambi', null, 0,0,0,0, 'A', 'C) PROVENTI E ONERI FINANZIARI',1 , _idsor1 from  #ANALITICA1 --,'S' 
INSERT INTO #dati  SELECT 1,' Utili', 'C) 3)', 0,0,0,0, 'R' , '3) Utili e Perdite su cambi',1, _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,' Perdite', 'C) 3)', 0,0,0,0, 'C' ,'3) Utili e Perdite su cambi',-1, _idsor1 from  #ANALITICA1
/*
	D) RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
		1) Rivalutazioni di attività finanziarie
		2) Svalutazioni di attività finanziarie
*/
INSERT INTO #dati  SELECT 2,'D) RETTIFICHE DI VALORE DI ATTIVITA'' FINANZIARIE', null, 0,0,0,0, 'A', null,1 , _idsor1 from  #ANALITICA1  --,'S' 
INSERT INTO #dati  SELECT 1,'1) Rivalutazioni', 'D) 1)', 0,0,0,0, 'R', 'D) RETTIFICHE DI VALORE DI ATTIVITA'' FINANZIARIE',1 , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Svalutazioni', 'D) 2)', 0,0,0,0, 'C', 'D) RETTIFICHE DI VALORE DI ATTIVITA'' FINANZIARIE',-1  , _idsor1 from  #ANALITICA1-- ,'S' 
/*
	E)	PROVENTI ED ONERI STRAORDINARI
		1) Proventi straordinari
		2) Oneri straordinari
*/
INSERT INTO #dati  SELECT 2,'E) PROVENTI E ONERI STRAORDINARI', null, 0,0,0,0, 'A','RISULTATO DI ESERCIZIO',1, _idsor1 from  #ANALITICA1  ---,'S' 
INSERT INTO #dati  SELECT 1,'1) Proventi', 'E) 1)', 0,0,0,0, 'R','E) PROVENTI E ONERI STRAORDINARI',1 , _idsor1 from  #ANALITICA1
INSERT INTO #dati  SELECT 1,'2) Oneri',  'E) 2)', 0,0,0,0, 'C','E) PROVENTI E ONERI STRAORDINARI',-1  , _idsor1 from  #ANALITICA1---,'S'   
/*
	F) Imposte sul reddito dell'esercizio correnti, differite, anticipate
*/
INSERT INTO #dati  SELECT 1,'F) IMPOSTE SUL REDDITO DELL''ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE', 'F)', 0,0,0,0, 'C', 'RISULTATO DI ESERCIZIO', -1, _idsor1 from  #ANALITICA1
/*
	G) Utilizzo di riservedi Patrimonio Netto derivanti dalla contabilità economico-patrimoniale
*/
-------------RISULTATO DI ESERCIZIO Presunto ----------------------------------  
INSERT INTO #dati  SELECT 4,'RISULTATO DI ESERCIZIO', null,  0,0,0,0, 'SUBT' , null, 1 , _idsor1 from  #ANALITICA1

 DECLARE @label varchar(200)
 DECLARE @codeplaccount varchar(200)
 DECLARE @kind char(1)
 DECLARE @ass char(1)
 declare @cursore cursor
 declare @crs_idsor1 int
 
	set @cursore = cursor for 
		select label, codeplaccount, kind, _idsor1
		from #dati WHERE kind in ('R', 'C') and codeplaccount is not null
		--AND codeplaccount='B) VIII 1) a)'
	open @cursore
	fetch next from @cursore into  @label, @codeplaccount, @kind, @crs_idsor1
	while @@fetch_status = 0
	begin
		   declare @_curramount   decimal(19,2)
		   declare @_prevamount   decimal(19,2)

		   
		   if(@idsor1 is null AND @Mostracoordianataanalitica1 = 'N')
		   Begin 
				SET @_curramount = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account A
								ON A.idacc = entrydetail.idacc
							JOIN placcount
								ON placcount.idplaccount = A.idplaccount
							WHERE  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((A.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND placcount.codeplaccount = @codeplaccount
								AND placcount.placcpart =@kind
								AND placcount.ayear = @ayear
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								),0)


				SET @_prevamount = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account A
								ON A.idacc = entrydetail.idacc
							JOIN placcount
								ON placcount.idplaccount = A.idplaccount
							WHERE  entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((A.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND placcount.codeplaccount = @codeplaccount
								AND placcount.placcpart =@kind
								AND placcount.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								),0)

				   if (@kind = 'C') 	SET @_curramount  = - @_curramount  --- cambio di segno per i costi
				   if (@kind = 'C') 	SET @_prevamount  = - @_prevamount  --- cambio di segno per i costi

				   update #dati set _curramount = @_curramount		where label = @label
				   update #dati set _prevamount = @_prevamount	   where label = @label
				   --update #dati set _saldo =  isnull(@_curramount,0)  -  isnull(@_prevamount,0) where label = @label
		   End
		   Else
		   Begin
				SET @_curramount = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account A
								ON A.idacc = entrydetail.idacc
							JOIN placcount
								ON placcount.idplaccount = A.idplaccount
							WHERE  entry.adate BETWEEN @start AND @stop
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((A.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND placcount.codeplaccount = @codeplaccount
								AND placcount.ayear = @ayear
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and entrydetail.idsor1 = @crs_idsor1
								),0)
								  
				SET @_prevamount = ISNULL(( SELECT SUM(entrydetail.amount)
							  FROM entrydetail
							JOIN entry
								ON entry.yentry = entrydetail.yentry
								AND entry.nentry = entrydetail.nentry
							JOIN account A
								ON A.idacc = entrydetail.idacc
							JOIN placcount
								ON placcount.idplaccount = A.idplaccount
							JOIN upb U	ON entrydetail.idupb = U.idupb
							WHERE  entry.adate BETWEEN @firstdayPY AND @lastdayPY
							AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
							   AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
								AND ((A.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
								AND placcount.codeplaccount = @codeplaccount
								AND placcount.ayear = @ayearPrec
								AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02) AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)	
								AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
								and entrydetail.idsor1 = @crs_idsor1
								),0)

				   if (@kind = 'C') 	SET @_curramount  = - @_curramount  --- cambio di segno per i costi
				   if (@kind = 'C') 	SET @_prevamount  = - @_prevamount  --- cambio di segno per i costi

				   update #dati set _curramount = @_curramount		where label = @label and _idsor1 = @crs_idsor1
				   update #dati set _prevamount = @_prevamount	   where label = @label and _idsor1 = @crs_idsor1
				   --update #dati set _saldo =  isnull(@_curramount,0)  -  isnull(@_prevamount,0) where label = @label and _idsor1 = @crs_idsor1
		   End
		   set @_curramount		= 0
		   set @_prevamount		= 0 
		  

	fetch next from  @cursore into   @label, @codeplaccount, @kind, @crs_idsor1
	end
	close @cursore
	deallocate @cursore
	END
					
-- gestisco i valori aggregati di livello 2, costi ricavi o voci aggregate (costi/ricavi)															
	UPDATE #dati SET _curramount = _curramount +  isnull((select sum(_curramount * segno) FROM #dati child
	where child.parent_label = #dati.label and nlevel = 1 and  _idsor1 = #dati._idsor1  )	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 2 

	UPDATE #dati SET _prevamount = _prevamount +  isnull((select sum(_prevamount * segno) FROM #dati child
	where child.parent_label = #dati.label and nlevel = 1 and    _idsor1 = #dati._idsor1 )	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 2 

-- gestisco i valori aggregati di livello 3, costi ricavi o voci aggregate (costi/ricavi)
	UPDATE #dati SET _curramount = _curramount +  isnull((select sum(_curramount * segno) FROM #dati child
	where child.parent_label = #dati.label and nlevel IN(1, 2) and    _idsor1 = #dati._idsor1 )	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 3 

	UPDATE #dati SET _prevamount = _prevamount +  isnull((select sum(_prevamount * segno) FROM #dati child
	where child.parent_label = #dati.label and nlevel IN(1, 2) and    _idsor1 = #dati._idsor1)	,0)	where  #dati.kind IN('R','C' ,'A')  and nlevel = 3 

--Valorizzo la voce Totale_Proventi_A
	
	UPDATE #dati SET _curramount = _curramount + isnull((select sum(_curramount) FROM #dati child
	where child.KIND = 'R' and nlevel = 2 and   _idsor1 = #dati._idsor1  )	,0)	where #dati.label = ('TOTALE PROVENTI  (A)') 

	UPDATE #dati SET _prevamount = _prevamount + isnull((select sum(_prevamount) FROM #dati child
	where child.KIND = 'R' and nlevel = 2  and    _idsor1 = #dati._idsor1 )	,0)	where #dati.label = ('TOTALE PROVENTI  (A)') 

	UPDATE #dati SET _curramount = _curramount + isnull((select sum(_curramount ) FROM #dati child
	where child.KIND = 'C' and nlevel = 2  and   _idsor1 = #dati._idsor1 )	,0)	where #dati.label = ('TOTALE COSTI  (B)')

	UPDATE #dati SET _prevamount = _prevamount + isnull((select sum(_prevamount ) FROM #dati child
	where child.KIND = 'C' and nlevel = 2  and    _idsor1 = #dati._idsor1 )	,0)	where #dati.label = ('TOTALE COSTI  (B)') 

	---- DIFFERENZA TRA PROVENTI E COSTI OPERATIVI
	
	UPDATE #dati SET _curramount = 
	isnull((select sum(_curramount ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)' and   _idsor1 = #dati._idsor1) ,0)	-
	isnull((select sum(_curramount ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)' and    _idsor1 = #dati._idsor1) ,0)	
	where #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)') 

	UPDATE #dati SET _prevamount = 
	isnull((select sum(_prevamount ) FROM #dati  where #dati.label = 'TOTALE PROVENTI  (A)' and   _idsor1 = #dati._idsor1) ,0)	-
	isnull((select sum(_prevamount ) FROM #dati  where #dati.label = 'TOTALE COSTI  (B)' and    _idsor1 = #dati._idsor1) ,0)	
	where #dati.label = ('DIFFERENZA TRA PROVENTI E COSTI OPERATIVI (A-B)') 

	--- Valorizzo la voce TotRicavi
	UPDATE #dati SET _curramount = isnull((select sum(_curramount ) FROM #dati child
	where child.KIND = 'R' and nlevel = 1  and  _idsor1 = #dati._idsor1)	,0)		where  #dati.label = 'TotRicavi' 

	UPDATE #dati SET _prevamount = isnull((select sum(_prevamount ) FROM #dati child
	where child.KIND = 'R' and nlevel = 1  and    _idsor1 = #dati._idsor1)	,0)		where  #dati.label = 'TotRicavi'

	--- Valorizzo la voce TotCosti
	UPDATE #dati SET _curramount = isnull((select sum(_curramount ) FROM #dati child
	where  child.KIND = 'C' and _curramount is not null and   _idsor1 = #dati._idsor1) 	,0)	where  #dati.label = 'TotCosti'

	UPDATE #dati SET _prevamount = isnull((select sum(_prevamount ) FROM #dati child
	where  child.KIND = 'C' and codeplaccount is not null and   _idsor1 = #dati._idsor1 ) 	,0)	where  #dati.label = 'TotCosti' 
	
	--- RISULTATO DI ESERCIZIO  
	UPDATE #dati SET _curramount =  (select sum(_curramount * segno) FROM #dati child
	where child.parent_label = #dati.label and    _idsor1 = #dati._idsor1 )		where  #dati.label = 'RISULTATO DI ESERCIZIO' 

	UPDATE #dati SET _prevamount = (select sum(_prevamount * segno) FROM #dati child
	where child.parent_label = #dati.label and    _idsor1 = #dati._idsor1 )		where  #dati.label = 'RISULTATO DI ESERCIZIO' 
	
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
if (@idsor1 is null AND @Mostracoordianataanalitica1 = 'N')
Begin
	SELECT
		@ayear				  AS ayear         ,
		@idupboriginal		  as idupb         ,
		@codeupb				  as codeupb	   ,
		@title				  as upb		   ,
		nlevel,
		CASE WHEN nlevel = 1 THEN SPACE(2) + label
			WHEN nlevel = 2 THEN SPACE(1) + label
			ELSE label
		END  as label,
		codeplaccount,
		_curramount,
		_prevamount,
		kind,
		parent_label,
		segno,
		ordinestampa,
		null as idsor,
		null as sortcode1,
		null as titlecode1
		FROM #dati order by ordinestampa
end
else
Begin
	SELECT
		@ayear				  AS ayear         ,
		@idupboriginal		  as idupb         ,
		@codeupb				  as codeupb	   ,
		@title				  as upb		   ,
		#dati.nlevel,
		CASE WHEN #dati.nlevel = 1 THEN SPACE(2) + #dati.label
			WHEN #dati.nlevel = 2 THEN SPACE(1) + #dati.label
			ELSE label
		END  as label,
		codeplaccount,
		sum(_curramount) as _curramount,
		sum(_prevamount) as _prevamount,
		kind,
		parent_label,
		segno,
		ordinestampa,
		sorting.idsor,
		sorting.sortcode as sortcode1,
		sorting.description 	as titlecode1
		FROM #dati 
		join sorting
			on #dati._idsor1 = sorting.idsor
		group by #dati.nlevel, #dati.label, codeplaccount, kind, parent_label,segno, ordinestampa,  sortcode, printingorder,sorting.idsor,		sorting.sortcode,sorting.description
		order by sortcode1, ordinestampa
		

End

	GO
	
	SET QUOTED_IDENTIFIER OFF
	GO
	SET ANSI_NULLS ON
	GO
	
	
	
	
--	exec rpt_contoeconomico_coordanal_dm2012_new 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','S','N',null,'N'
--	exec rpt_contoeconomico_coordanal_dm2012_new 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-12-31 00:00:00'}, '0001','S', 'S',2033 ,'S'
--	exec rpt_contoeconomico_coordanal_dm2012_new 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '%','S',	'S',2033 ,'S'
