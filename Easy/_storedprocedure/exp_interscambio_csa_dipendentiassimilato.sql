if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_dipendentiassimilato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_dipendentiassimilato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE exp_interscambio_csa_dipendentiassimilato
 (
	@datagenerazione datetime,
	@ayear int,
	@ateneo varchar(5),
	@tiporecord varchar(2) ,
	@tipoCompenso char(1), -- Assume valori T = Conto Terzi, C = CO.CO.CO. , B = Borse di studio, M = Missioni
	@start datetime,
	@stop datetime
)
AS 
/*
exec exp_interscambio_csa_dipendentiassimilato {ts '2012-12-31 01:02:03'} ,2012, '70136','16', 'M',{ts '2012-01-01 01:02:03'},{ts '2012-12-31 01:02:03'}

 */
BEGIN

DECLARE @annoredditi int
SET @annoredditi = @ayear
--------------------------------------------------------------------------------------- Interroghiamo i singoli dipartimenti ----------------------------------------------------------------

CREATE TABLE #Compensi(
		departmentname varchar(500),
		iddb_idexp varchar(60),-- iddb(50) + idexp(10)
		idregistrylegalstatus int,
		voce8000 varchar(4),
		importo decimal(19,2),
		idreg int,
		ymov smallint,
		nmov int,
		paymentdate smalldatetime
		)

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
			where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		if(@tipoCompenso in ('T','C','B')) 	set @dip_nomesp = @iddbdepartment + '.exp_interscambio_csa_dipendentiassimilato_single'
		if(@tipoCompenso in ('M'))			set @dip_nomesp = @iddbdepartment + '.exp_interscambio_csa_missioni_single'


		INSERT INTO #Compensi(
				idreg,
				departmentname,
				iddb_idexp,
				idregistrylegalstatus,
				voce8000,
				importo,
				ymov,
				nmov,
				paymentdate
		)
		exec @dip_nomesp @datagenerazione, @ayear, @ateneo, @tipoCompenso, @start, @stop
		fetch next from @crsdepartment into @iddbdepartment
	
	END



----------------------------------------------------------------------------  Consolidiamo i dati  -----------------------------------------------------------------------------------------------------------------------------------------------------------

DECLARE @COD_FISC_SOSTITUTO varchar(16) --p_iva o CF
DECLARE @DESCR_SOSTITUTO varchar(60)
	SELECT
		@COD_FISC_SOSTITUTO = ISNULL(cf, p_iva),
		@DESCR_SOSTITUTO = SUBSTRING(agencyname, 1, 60)
	FROM license

SET @DESCR_SOSTITUTO = 
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(
@DESCR_SOSTITUTO,
'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'Ù','u'),
'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
']',' '),'`',' '),'{',' '),'}',' '),'~',' '),'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),
'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),
'õ','o'),'ý','y'),'é','e'),'à','a'''),'è','e'''),'ì','i'),'ò','o'),'ù','u'''),'á','a'''),'í','i'''),'ó','''o'),'É','e'),
'Á','a'''),'À','a'''),'È','e'''),'Í','i'''),'Ì','i'''),'Ó','o'''),'Ò','o'''),'Ú','u'''),
CHAR(9),' '),CHAR(10),' '),CHAR(13),' ')

-- IMP: I dati all’interno dello stesso tipo record devono essere ordinati per matricola.	00
-- Record 15
CREATE TABLE #RecordSostitutiComunicazione(
-- parte comune a tutti i record
--	ProgrGen	varchar(6),		-- Progressivo generale del record all’interno del file. Viene incrementato ad ogni riga del file dati. Il record di testata ha progrGen='000000'
	TipoOperazione	char(1),	-- Tipo operazione da fare sul record	‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
	SeparatoreChr	char(1),	-- Variabile (0, 1)	Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
	TotCampi	int ,			-- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
	TipoRecord	varchar(2),		-- Tipo record (00-08; 90, 91, 92)
	ProgrTipoRec  int identity(0,1),/*varchar(6),*/	-- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record. 
								-- Si azzera comunque al cambio di ogni matricola.	Inizia da 000000 fino a 999999
	Comparto char(1),			-- Il comparto del dipendente. Nel record di testa vale 0
	Ruolo	varchar (4),		-- Variabile (2..4)	Il ruolo del dipendente. Nel record di testa assume valore  '0000'
	Matricola	varchar(6),		--	La matricola del dipendente. Nel record di testa assume valore me il valore '000000'

-- parte del record 15
	ANNO	int,							-- *Anno fiscale
--	COD_FISC_SOSTITUTO	varchar(16),		-- *Partita iva o codice fiscale del sostituto che dichiara la comunicazione
	PROGR	varchar(2),						-- *Progressivo, vedi pag.2
	COD_FISC	varchar(16),				-- Codice fiscale del sostituito, ossia della persona
	SOSTITUTO_TIPO_COMUNICAZIONE char(1),	-- *FK verso SOSTITUTI_TIPI_COMUNICAZIONI
--	DESCR_SOSTITUTO	varchar(60),			-- denominazione del sostituto
	DATA_RICEZIONE	datetime,				--  D(10)Data ricezione della comunicazione (obbligatorio)
	QUADRO	char(1),						-- non più utilizzato
	PROGR_CONGUAGLIO char(2),				-- 
	CODICE_INPDAP_AMMINISTRAZIONE varchar(12),-- non più utilizzato
	DATA_CESSAZIONE	datetime,				-- D(10) non più utilizzato
	PROVINCIA_LAVORO varchar(2),			-- non più utilizzato
	DATA_IN	datetime,						-- D(10) non più utilizzato
	DATA_FIN datetime,						-- D(10)non più utilizzato
	TIPO_IMPIEGO	varchar(2),				-- non più utilizzato
	TIPO_SERVIZIO	varchar(2),				-- non più utilizzato
	F_CONTRIBUTI_INPDAP	char(1),			-- non più utilizzato
	DATA_INS datetime,						-- D(10)
	DATA_MOD datetime,						-- D(10)
	OPERATORE	varchar(10),
	CAPITOLO	varchar(6),					-- Utilizzato per imputare gli importi caricati in SOSTITUTI_IMPORTI alle corrette colonne del conto annuale e della BDM
	iddb_idexp varchar(60) -- Serve perchè dobbiamo fornire i dettagli per singolo pagamento
)

-- Record 16
CREATE TABLE #RecordSostitutiImporti(
-- parte comune a tutti i record
--	ProgrGen	varchar(6),		-- Progressivo generale del record all’interno del file. Viene incrementato ad ogni riga del file dati. Il record di testata ha progrGen='000000'
	TipoOperazione	char(1),	-- Tipo operazione da fare sul record	‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
	SeparatoreChr	char(1),	-- Variabile (0, 1)	Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
	TotCampi	int ,			-- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
	TipoRecord	varchar(2),		-- Tipo record (00-08; 90, 91, 92)
	ProgrTipoRec  int identity(0,1),/*varchar(6),*/	-- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record. 
								-- Si azzera comunque al cambio di ogni matricola.	Inizia da 000000 fino a 999999
	Comparto char(1),			-- Il comparto del dipendente. Nerl record di testa vale 0
	Ruolo	varchar (4),		-- Variabile (2..4)	Il ruolo del dipendente. Nel rcord di testa assume valore  '0000'
	Matricola	varchar(6),		-- La matricola del dipendente. Nel record di testa assume valore me il valore '000000'

-- parte del Record 16
	ANNO	int,					-- *
	COD_FISC_SOSTITUTO	varchar(16),--*
	PROGR	varchar(2),				-- *
	--Questi 4 campi sono foreign key verso la tabella SOSTITUTI_COMUNICAZIONI

	VOCE	varchar(5),				-- * Voce di comunicazione (vedi documento Voci_di_comunicazione(8000)_1.0.doc)	
	ANNO_COMPETENZA	varchar(4),		-- *Anno di competenza della voce
	F_CASSA_COMPETENZA	char(1),	-- * Per le voci previdenziali, ci dice se sono state liquidate con le aliquote di cassa (ANNO) o di competenza (ANNO_COMPENTENZA); se ANNO = ANNO_COMPETENZA vale ‘1’
									-- ‘1’ Competenza
									-- ‘2’ Cassa
	IMPORTO	decimal(18,6),
	DIVISA	char(1),				-- 'E' Euro, 'L' Lire
	DATA_INS datetime,				-- D(10)
	DATA_MOD datetime,				-- D(10)
	OPERATORE	varchar(10),
	iddb_idexp varchar(60) -- Serve perchè dobbiamo fornire i dettagli per singolo pagamento

)


-- RECORD 15

INSERT INTO #RecordSostitutiComunicazione(
-- parte comune a tutti i record
	TipoOperazione,		-- Tipo operazione da fare sul record	'I'
	TipoRecord	,		-- Tipo record (00-08; 90, 91, 92)
----	ProgrTipoRec,
	Comparto ,			-- Il comparto del dipendente. 
	Ruolo,				-- Variabile (2..4)	Il ruolo del dipendente.
	Matricola,			-- La matricola del dipendente.
-- parte del record 15
	ANNO,							-- *Anno fiscale
	COD_FISC,
	SOSTITUTO_TIPO_COMUNICAZIONE,
	iddb_idexp,
	DATA_RICEZIONE
)
SELECT
	'I',			-- tipo operazione
	'15',			-- tipo record
----	REPLICATE('0',6),
	RLS.csa_compartment,	-- comparto
	RLS.csa_role,		-- ruolo
	R.extmatricula,	-- matricola
	@ayear,			-- I.yitineration,	-- anno
	ISNULL(R.cf, REPLICATE('0',16)), 
	-- In base al tipo compenso assume i seguenti valori 
	-- per T = Conto Terzi, CONTO TERZI:  Comunicazione di Tipo: D - Dati provenienti dal DATORE 
	-- per C = CO.CO.CO. , Comunicazione di Tipo: G - DATORE - Collab. Extra CSA
	-- per B = Borse di studio, Comunicazione di Tipo: D - Dati provenienti dal DATORE
	CASE @tipocompenso
		WHEN 'T' THEN 'D' -- T = Conto Terzi
		WHEN 'C' THEN 'G' --C = CO.CO.CO.
		WHEN 'B' THEN 'D' --B = Borse di studio
		WHEN 'M' THEN 'M' -- CHIEDERE A QUALCUNO E' MOLTO IMPORTANTE!!!
	END,
	D.iddb_idexp,
	D.paymentdate
FROM #Compensi D
JOIN registrylegalstatus RLS
	ON D.idreg = RLS.idreg
	AND D.idregistrylegalstatus = RLS.idregistrylegalstatus
JOIN registry R				
	ON D.idreg = R.idreg
WHERE R.extmatricula IS NOT NULL
		AND RLS.csa_role IS NOT NULL
		AND RLS.csa_compartment IS NOT NULL
GROUP BY R.cf, R.extmatricula,RLS.csa_compartment,RLS.csa_role, D.iddb_idexp, D.paymentdate


-- RECORD 16 - Inserisce le solo le VOCI del contratto dipendente
INSERT INTO #RecordSostitutiImporti(
-- parte comune a tutti i record
	TipoOperazione,	
	TipoRecord,		
	--ProgrTipoRec varchar(6),	-- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record. 
								-- Si azzera comunque al cambio di ogni matricola.	Inizia da 000000 fino a 999999
	Comparto,			
	Ruolo,		
	Matricola,

-- parte del Record 16
	ANNO	,					-- *
	--Questi 4 campi sono foreign key verso la tabella SOSTITUTI_COMUNICAZIONI

	VOCE,				-- * Voce di comunicazione (vedi documento Voci_di_comunicazione(8000)_1.0.doc)	
	ANNO_COMPETENZA,	-- * Anno di competenza della voce
	F_CASSA_COMPETENZA,	-- * 1 - Competenza,	2 - Cassa
	IMPORTO	,
	DIVISA,
	iddb_idexp
)

SELECT 
	'I',
	'16',
	RLS.csa_compartment,
	RLS.csa_role,
	R.extmatricula,
	@ayear,--I.yitineration,

	D.voce8000,
	@ayear,--I.yitineration,
	'1',
	SUM(D.importo),
	'E',
	D.iddb_idexp	
FROM #Compensi D
JOIN registrylegalstatus RLS
	ON D.idreg = RLS.idreg
	AND D.idregistrylegalstatus = RLS.idregistrylegalstatus
JOIN registry R
	ON RLS.idreg = R.idreg
WHERE 	R.extmatricula IS NOT NULL
		AND RLS.csa_role IS NOT NULL
		AND RLS.csa_compartment IS NOT NULL
GROUP BY RLS.csa_compartment,RLS.csa_role,R.extmatricula, D.iddb_idexp, D.voce8000


-- Valorizzo il campo PROG di #RecordSostitutiComunicazione
-- Parte da 01 e si azzera al cambio di matricola
UPDATE #RecordSostitutiComunicazione
SET PROGR = 1 + ISNULL(
		(SELECT COUNT(matricola)
		FROM #RecordSostitutiComunicazione C2
		WHERE  C2.matricola = #RecordSostitutiComunicazione.matricola
		AND C2.iddb_idexp < #RecordSostitutiComunicazione.iddb_idexp ),0
	)


-- Questo UPDATE andrà fatto dopo aver valorizzato il campo PROGR di #RecordSostitutiComunicazione
UPDATE #RecordSostitutiImporti SET PROGR =  (SELECT PROGR FROM #RecordSostitutiComunicazione
											WHERE #RecordSostitutiImporti.MATRICOLA = #RecordSostitutiComunicazione.MATRICOLA
												AND #RecordSostitutiImporti.iddb_idexp = #RecordSostitutiComunicazione.iddb_idexp)


-- Record 00
CREATE TABLE #RecordTesta(
-- parte comune a tutti i record
	ProgrGen	varchar(6),		-- Progressivo generale del record all’interno del file. Viene incrementato ad ogni riga del file dati. Il record di testata ha progrGen='000000'
	TipoOperazione	char(1),	-- Tipo operazione da fare sul record	‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
	SeparatoreChr	char(1),	-- Variabile (0, 1)	Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
	TotCampi	int ,			-- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
	TipoRecord	varchar(2),		-- Tipo record (00-08; 90, 91, 92)
	ProgrTipoRec varchar(6),	-- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record. 
								-- Si azzera comunque al cambio di ogni matricola.	Inizia da 000000 fino a 999999
	Comparto char(1),			-- Il comparto del dipendente. Nerl record di testa vale 0
	Ruolo	varchar (4),		-- Variabile (2..4)	Il ruolo del dipendente. Nel rcord di testa assume valore  '0000'
	Matricola	varchar(6),		--	La matricola del dipendente. Nel record di testa assume valore me il valore '000000'

-- parte del Record di Testa
	Ateneo	varchar(5),			-- Codice ateneo di origine	70003
	Data	datetime ,			-- Data generazione record	GG/MM/AAAA
	Ora		datetime,--(8),				-- Ora generazione record	HH.MM.SS
	CodFile	char(1),			--	Solo se trattasi di un file prodotto con la funzione di CSA “Estrazione dati dipendente Trasferito” si riporta ‘T’.
									-- CodFile= '0' va usato in tutti i casi in cui il file viene utilizzato per caricamenti “batch.	0
	InvioMatricola	char(1),	-- Indica se la matricola viene avvalorata nei vari record  oppure la si lascia al valore ‘000000’. Nel nostro caso deve valere 1
	InvioDatiAnagrafici	char(1)-- invioDatiAnagrafici. Nel nostro caso deve valere 0
)

INSERT INTO #RecordTesta(
-- parte comune a tutti i record
	TipoOperazione,
	TipoRecord,			-- Tipo record (00-08; 90, 91, 92)
	ProgrTipoRec,		-- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record. 
								-- Si azzera comunque al cambio di ogni matricola.	Inizia da 000000 fino a 999999
	Comparto,			-- Nel record di testa vale 0
	Ruolo,				-- Nel rcord di testa assume valore  '0000'
	Matricola,			-- Nel record di testa assume valore me il valore '000000'

-- parte del Record di Testa
	Ateneo,					-- Codice ateneo di origine	70003
	Data ,					-- Data generazione record	GG/MM/AAAA
	--Ora	,				-- Ora generazione record	HH.MM.SS
	CodFile,			
	InvioMatricola,			-- Indica se la matricola viene avvalorata nei vari record  oppure la si lascia al valore ‘000000’. Nel nostro caso deve valere 1
	InvioDatiAnagrafici		-- invioDatiAnagrafici. Nel nostro caso deve valere 0
)
SELECT
	'I',		-- Tipo Operazione
	'00',		-- TipoRec
	REPLICATE('0',6),	-- ProgrTipoRec
	'0',				-- Comparto
	REPLICATE('0',4),	-- Ruolo
	REPLICATE('0',6),	-- Matricola
	SUBSTRING(REPLICATE('0',5),1,5 - DATALENGTH(SUBSTRING(convert(varchar(5),@ateneo),1,5))) + SUBSTRING(convert(varchar(5),@ateneo),1,5),		
	@datagenerazione,	-- data
	'0',		-- CodFile
	'1',		-- InvioMatricola
	'0'			-- InvioDatiAnagrafici


-- Tabella di output
CREATE TABLE #tracciato(
	ProgGen int identity(0,1),
	TipoRecord	varchar(2),		-- Tipo record (00-08; 90, 91, 92)
	ProgrTipoRec varchar(6),	
	Matricola varchar(6),
	stringa varchar(600) COLLATE SQL_Latin1_General_CP1_CI_AS
)

INSERT INTO #tracciato
(	
	TipoRecord,
	ProgrTipoRec,	
	Matricola,
	stringa 
)
SELECT 
	TipoRecord,
	ProgrTipoRec,	
	Matricola,

	'@'+ TipoOperazione  
	+'@'+ --> SeparatoreChr	char(1) Non mettiamo nulla, è come se avesse lunghezza 0
	+'@'+ convert (varchar(2),15)-- Tot. Campi
	+'@'+ TipoRecord
	+'@'+ ProgrTipoRec 
	+'@'+ Comparto 
	+'@'+ Ruolo	
	+'@'+ Matricola	
-- parte del Record di Testa
	+'@'+ Ateneo --> Al momento è posto come parametro di input DA FARE!!!
	-- Data generazione record	GG/MM/AAAA
	+'@'+ SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(data)))) +
		CONVERT(varchar(2),DAY(data)) + '/'+
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(data)))) +
		CONVERT(varchar(2),MONTH(data))+'/'+
		+CONVERT(varchar(4),YEAR(data))

	+'@'+ SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DATEPART(hh,@datagenerazione)))) +
		CONVERT(varchar(2),DATEPART(hh,@datagenerazione)) + '.'+
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DATEPART(mi,@datagenerazione)))) +
		CONVERT(varchar(2),DATEPART(mi,@datagenerazione))+'.'+
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DATEPART(ss,@datagenerazione)))) +
		CONVERT(varchar(2),DATEPART(ss,@datagenerazione))+	--'.'+
	+'@'+ CodFile
	+'@'+ InvioMatricola
	+'@'+ InvioDatiAnagrafici
	+'@'
FROM #RecordTesta

INSERT INTO #tracciato
(	
	TipoRecord,
	ProgrTipoRec,	
	Matricola,
	stringa 
)
SELECT 
	TipoRecord,
	ProgrTipoRec,	
	Matricola,

-- parte comune a tutti i record
	 '@'+ TipoOperazione
	+'@'+ --> SeparatoreChr	char(1) Non mettiamo nulla, è come se avesse lunghezza 0
	+'@'+ '30' +  -- TotCampi	
	+'@'+ TipoRecord
	+'@'+ SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6))) + SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6)
	+'@'+ Comparto 
	-- Ruolo	varchar (4),		-- Variabile (2..4)	Il ruolo del dipendente. Nel record di testa assume valore  '0000'
	+'@'+ isnull(Ruolo,'0000')
	-- Matricola	vachar(6)		--	La matricola del dipendente. Nel record di testa assume valore me il valore '000000'
	+'@'+ SUBSTRING(REPLICATE('0',6),1,6 - ISNULL(DATALENGTH(SUBSTRING(isnull(Matricola,''),1,6)),0)) + SUBSTRING(isnull(Matricola,''),1,6)

-- parte del record 15
	+'@'+ convert(varchar(4), ANNO)
	+'@'+ convert(varchar(16),@COD_FISC_SOSTITUTO)		-- *Partita iva o codice fiscale del sostituto che dichiara la comunicazione
	+'@'+  SUBSTRING(REPLICATE('0',2),1,2 - ISNULL(DATALENGTH(SUBSTRING(isnull(PROGR,'0'),1,2)),0)) + SUBSTRING(isnull(PROGR,'0'),1,2)		-- *Progressivo, vedi pag.2
	+'@'+ convert(varchar(16),COD_FISC)-- codice fiscale della persona
	+'@'+ SOSTITUTO_TIPO_COMUNICAZIONE -- D - Dati provenienti dal DATORE
	+'@'+isnull(@DESCR_SOSTITUTO,'')
	-- DATA_RICEZIONE	GG/MM/AAAA
	+'@'+ SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(DATA_RICEZIONE)))) +
		CONVERT(varchar(2),DAY(DATA_RICEZIONE)) + '/'+
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(DATA_RICEZIONE)))) +
		CONVERT(varchar(2),MONTH(DATA_RICEZIONE))+'/'+
		+CONVERT(varchar(4),YEAR(DATA_RICEZIONE))

	+'@'+ -- REPLICATE('0',1) -- QUADRO	
	+'@'+ --REPLICATE('0',2) -- PROGR_CONGUAGLIO
	+'@'+ --REPLICATE('0',12)-- CODICE_INPDAP_AMMINISTRAZIONE 
	+'@'+ --SPACE(10)-- DATA_CESSAZIONE	
	+'@'+ --REPLICATE('0',2) -- PROVINCIA_LAVORO
	+'@'+ --SPACE(10)-- DATA_IN	
	+'@'+ --SPACE(10)-- DATA_FIN 
	+'@'+ --REPLICATE('0',2) -- TIPO_IMPIEGO	
	+'@'+ --REPLICATE('0',2) -- TIPO_SERVIZIO	
	+'@'+ --REPLICATE('0',1) -- F_CONTRIBUTI_INPDAP	
	+'@'+ --SPACE(10)--DATA_INS datetime,
	+'@'+ --SPACE(10)--DATA_MOD
	+'@'+ + 'ImportSp'+ --REPLICATE('0',10)--OPERATORE	
	+'@'+ --REPLICATE('0',6)--CAPITOLO	
	+'@'
FROM #RecordSostitutiComunicazione
WHERE @TipoRecord = '15'

INSERT INTO #tracciato
(	
	TipoRecord,
	ProgrTipoRec,	
	Matricola,
	stringa 
)
SELECT 
	TipoRecord,
	ProgrTipoRec,	
	Matricola,

-- parte comune a tutti i record
	 '@'+ TipoOperazione
	+'@'+ --> SeparatoreChr	char(1) Non mettiamo nulla, è come se avesse lunghezza 0
	+'@'+ '20' +  -- TotCampi	
	+'@'+ TipoRecord
	+'@'+ SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6))) + SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6)
	+'@'+ Comparto 
	-- Ruolo	varchar (4),		-- Variabile (2..4)	Il ruolo del dipendente. Nel record di testa assume valore  '0000'
	--+'@'+ SUBSTRING(REPLICATE('0',4),1,4 - ISNULL(DATALENGTH(SUBSTRING(isnull(Ruolo,''),1,4)),0)) + SUBSTRING(isnull(Ruolo,''),1,4)
	+'@'+ isnull(Ruolo,'0000')
	-- Matricola	vachar(6)		--	La matricola del dipendente. Nel record di testa assume valore me il valore '000000'
	+'@'+ SUBSTRING(REPLICATE('0',6),1,6 - ISNULL(DATALENGTH(SUBSTRING(isnull(Matricola,''),1,6)),0)) + SUBSTRING(isnull(Matricola,''),1,6)

-- parte del Record 16
	+'@'+ convert(varchar(4), ANNO)
	+'@'+ convert(varchar(16),@COD_FISC_SOSTITUTO)		-- *Partita iva o codice fiscale del sostituto che dichiara la comunicazione
	+'@'+ SUBSTRING(REPLICATE('0',2),1,2 - ISNULL(DATALENGTH(SUBSTRING(isnull(PROGR,'0'),1,2)),0)) + SUBSTRING(isnull(PROGR,'0'),1,2)		-- *Progressivo, vedi pag.2
--Questi 4 campi sono foreign key verso la tabella SOSTITUTI_COMUNICAZIONI
	+'@'+  SUBSTRING(REPLICATE('0',5),1,5 - ISNULL(DATALENGTH(SUBSTRING(isnull(VOCE,'0'),1,5)),0)) + SUBSTRING(isnull(VOCE,'0'),1,5)		
	+'@'+ convert(varchar(4), ANNO_COMPETENZA)
	+'@'+ F_CASSA_COMPETENZA	
	+'@'+  REPLACE(CONVERT(varchar(25),IMPORTO),'.',',') --IMPORTO	decimal(18,6),
	+'@'+ DIVISA	
	+'@'+ --SPACE(10)--DATA_INS 
	+'@'+ --SPACE(10)--DATA_MOD
	+'@'+ 'ImportSp'+ --REPLICATE('0',10)--OPERATORE	
	+'@'
FROM #RecordSostitutiImporti
WHERE @TipoRecord = '16'

SELECT 
	SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),ProgGen),1,6))) + SUBSTRING(convert(varchar(6),ProgGen),1,6)
	+ stringa as out_str 
FROM #tracciato
ORDER BY ProgGen, Matricola, TipoRecord



END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



