
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_intrastat_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_intrastat_unified]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/*
setuser'amministrazione'
EXEC exp_mod_intrastat 2017, null,2,'A','T','B'
exp_mod_intrastat_unified {ts '2017-06-07 00:00:00.000'} ,'2017' ,'6' ,'2', 'A', 'M' ,'XXXX' ,'123456' ,'0' ,'V', '1', 'E', 'N', '(null)'
*/
CREATE  PROCEDURE [exp_mod_intrastat_unified] (
	@datainterchange datetime,
-- A seconda della periodicità ossia T o M, si dovrà indicare il periodo di riferimento
	@anno int,
	@mese int, 
	@trimestre int,
	@tipoRiepilogo char(1),	-- A = acquisti, C = cessioni,
	@tipoRecord char(1),	-- B -->Beni, S -->Servizi, T -- >Beni e Servizi
	@periodicita char(1),	-- M = dichiarazione Mensile, T = dichiarazione Trimestrale, A = dichiarazione Annuale >> NON PIU' DISPONIBILE
	@CodiceUA varchar(4),
	@cod_sezionedoganale varchar(6),
	@casella2 char(1),			-- Prima trasmisisone? S/N ===> 0 = non barrata, 1 = barrata
	@validazione char(1),	-- Intr@Web : Indica se si sta generando il file solo per validarlo o per trasmetterlo [*]
	@ninterchange varchar(2),
	@IntrawebEntratel char(1),-- Assume valori I oppure E[**],
	@unified char(1), -- Consente di consolidare o meno i dati
	@numeroprogressivoelenco varchar(6)
)
AS
BEGIN

IF (@IntrawebEntratel = 'E')
Begin
	SET @CodiceUA = 'ZENT'
End

-- Serve per incrementare il progressivo del flusso.
if exists (select * from intrastattrasmission)
Begin
	UPDATE intrastattrasmission SET idintrastattrasmission = isnull(idintrastattrasmission,0) + 1 
 End
 Else
 Begin
	insert into intrastattrasmission(idintrastattrasmission)values(1)
 End

 -- Se l'utente non ha indicato alcun progressivo, lo determina col meccanismo attuale.
if (@NumeroProgressivoelenco is null)
Begin
	SET @NumeroProgressivoelenco =
	(SELECT  SUBSTRING(REPLICATE('0',6),1, 6 - DATALENGTH(CONVERT(varchar(6),max(idintrastattrasmission))))  + CONVERT(varchar(6),max(idintrastattrasmission))
		FROM intrastattrasmission)
End
Else
Begin
	SET @NumeroProgressivoelenco = SUBSTRING(REPLICATE('0',6),1, 6 - DATALENGTH(@NumeroProgressivoelenco))  +  @NumeroProgressivoelenco
End

-- [*]Il record di testa lo genera il programma intr@web, quindi per  validare i file prodotto non server generalo, sono necessari solo:
-- record  frontespizio e record dettagli
-- Scadenza di presentazione in dogana
-- Elenchi mensili: entro il 20 del mese successivo a quello di riferimento (es. mensile di gennaio 2007 entro il 20 febbraio 2007 - eccezione del mese di luglio 
--																			per il quale la scadenza è entro il 6 settembre)
-- Elenchi Trimestrali: entro la fine del mese successivo al trimestre di riferimento (es. I trimestre 2007 entro il 30 aprile 2007)
-- Elenchi annuali: entro la fine di gennaio dell’anno successivo a quello di riferimento (es. annuale 2007 entro il 31 gennaio 2008)

-- [**]	Se vale I vuol dire che il file sarà elaborato con Intr@Web, quindi il record di Testa sarà generato solo per la Trasmissione, non per la Validazione;
--		Se vale E vuol dire che il ifle sarà elaborato con EntraTel, quindi dovremo generare anche il record di Testa.
-- Quindi il file di test alo generiamo se è una trasmissione Intr@Web o vogliamo fare un elaborazione con Entratel

-- Valori ammessi per la Casella 2 = Frontespizio pos 46.
-- • 0 = le operazioni sono riferite al periodo indicato dai campi 7, 8 e 9
-- • 8 = cambio di periodicità - le operazioni riepilogate nell’elenco trimestrale sono riferite solo al primo mese
-- • 9 = cambio di periodicità - le operazioni riepilogate nell’elenco trimestrale sono riferite al primo e al secondo mese
DECLARE @casella1 char(1)
SET @casella1 = '0' 

-- Valori ammessi per la Caselle 2 = Frontespizio pos 47
--Casi particolari riferiti al soggetto obbligato
-- • 7 = Primo elenco presentato
-- • 8 = Cessazione di attività o variazione della partita IVA
-- • 9 = Primo elenco presentato da un soggetto che, nel periodo di riferimento ha, contestualmente, cessato l’attività oppure ha variato la propria partita IVA riferite solo al primo mese
-- • 0 = nessuno dei casi sopra riportati

IF (@casella2 <> 0)
Begin
	SET @casella2 = 7
End

-- Tutti i campi presenti nella tabella #RecordDiTesta (tranne i campi "Riservato a SDA") sono obbligatori.
CREATE TABLE #RecordDiTesta
(
	CodiceUA		varchar(4),			-- Codice utente abilitato Lungh. 4
	riservatoSDA	varchar(12),		-- Lungh. 12 -- Riservato a SDA 
	nomedelfusso	varchar(12),		-- Lungh. 12 --	Nome del Flusso 
	cod_sezionedoganale	varchar(6),		-- Numerico  Lungh. 6-- Codice sezione doganale presso la quale si effettua l'operazione
	cf_piva			varchar(16),		-- Lungh. 16 -- CF o Piva o codice spedizioniere del richiedente (utente autorizzato)
	progressivosede	varchar(3),			-- Numerico -- Progressivo Sede utente autorizzato: il progressivo sede nel caso in cui non venga indicato, viene impostato con il valore "001" dal 
										-- Sistema di Accesso doganale (SDA); va modificato se la trasmissione avviene da una sede secondaria
	numerorecord_nelflusso varchar(5)	-- Numerico -- Numero di record presenti nel flusso (compreso il record di testa)
)

CREATE TABLE #Frontespizio
(
	campofisso varchar(5),						-- Assume valore costante 'EUROX'
	Piva_presentatore varchar(11),				-- Partita IVA del presentatore
	NumeroProgressivoelenco varchar(6),			-- Numero progressivo dell'elenco
	TipoRecord char(1),							-- Tipo Record 0 = frontespizio, 1 = righe dettaglio sezione 1, 2 = righe dettaglio sezione 2
	NumeroProgressivoRigaDettaglio varchar(5),	-- Numero progressivo di riga dettaglio all'interno delle sez. 1 e 2, impostato a zero nel frontespizio

	tipoRiepilogo char(1),				-- Tipo Riepilogo A=acquisti, C = cessioni
	anno varchar(2),					-- numerico -- Anno
	periodicita char(1),				-- Periodicità
	periodo varchar(2),					-- numerico -- Periodo
	piva_contribuente varchar(11),		-- numerico -- Partita IVA del contribuente
	casella1 char(1),					-- numerico: 0 = non barrata, 1 = barrata
	casella2 char(1),					-- numerico: 0 = non barrata, 1 = barrata
	piva_delegato  varchar(11),			-- numerico			-- Partita IVA del soggetto delegato
	num_dett_sezione1 int,				-- numerico			-- Numero dettagli della sezione 1
	complessivosezione1 int,			-- numerico Len. 13 -- Ammontare complessivo delle operazioni riportate nella sezione 1 (in migliaia di lire/euro)	 
	num_dett_sezione2 int,				-- numerico			-- Numero dettagli della sezione 2
	complessivosezione2 int,			-- numerico Len. 13 -- Ammontare complessivo delle operazioni riportate nella sezione 2 (in migliaia di lire/euro)	
	num_dett_sezione3 int,				-- numerico			-- Numero dettagli della sezione 3
	complessivosezione3 int,			-- numerico Len. 13 -- Ammontare complessivo delle operazioni riportate nella sezione 3 (in migliaia di lire/euro)	 
	num_dett_sezione4 int,				-- numerico			-- Numero dettagli della sezione 4
	complessivosezione4 int				-- numerico Len. 13 -- Ammontare complessivo delle operazioni riportate nella sezione 4 (in migliaia di lire/euro)	 
)

CREATE TABLE #RecordDettaglio1_BENI
(
	annorif int,
	meserif int,
	trimrif int,
	segno_variazione char(1),

	campofisso varchar(5),						-- Assume valore costante 'EUROX'
	Piva_presentatore varchar(11),				-- Partita IVA del presentatore
	NumeroProgressivoelenco varchar(6),			-- Numero progressivo dell'elenco
	TipoRecord char(1),							-- Tipo Record 0 = frontespizio, 1 = righe dettaglio sezione 1, 2 = righe dettaglio sezione 2
	NumeroProgressivoRigaDettaglio varchar(5),	-- Numero progressivo di riga dettaglio all'interno delle sez. 1 e 2, impostato a zero nel frontespizio

	NumeroProgressivoelenco_provvisorio int IDENTITY(1,1),
	NUM int,
	
	codiceIVA varchar(14),				-- - Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore =il numero di partita iva del soggetto passivo d’imposta con il quale è stata effettuata 
										--	l’operazione intracomunitaria
	ammontareinEuro int,				-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta int,				-- numerico Len.13 -- Ammontare delle operazioni in valuta
	codTransazione char(1),				-- Codice della natura dela transazione
	codNomenclatura varchar(8),			-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
	massainkg int,						-- numerico Len. 10 -- Massa netta in kilogrammi
	unitasupp int,						-- numerico Len. 10 -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
	valorestatisticoinEuro varchar(13), -- numerico -- Valore statistico in euro
	codConsegna char(1),				-- Codice delle condizioni di consegna
	codTrasporto char(1),				-- numerico -- Codice del modo di trasporto
	codDest_codProv char(2),			-- Codice del paese di destinazione/provenienza
	codOrigineMerce char(2),			-- Codice del paese di origine della merce
	provOrigine_Dest char (2)				-- Codice della provincia di origine/destinazione della merce	
)

CREATE TABLE #RecordDettaglio3_SERVIZI
(
	annorif int,
	meserif int,
	trimrif int,
	segno_variazione char(1),

	campofisso varchar(5),						-- Assume valore costante 'EUROX'
	Piva_presentatore varchar(11),				-- Partita IVA del presentatore
	NumeroProgressivoelenco varchar(6),			-- Numero progressivo dell'elenco
	TipoRecord char(1),							-- Tipo Record 0 = frontespizio, 1 = righe dettaglio sezione 1, 3 = righe dettaglio sezione 3
	NumeroProgressivoRigaDettaglio varchar(5),	-- Numero progressivo di riga dettaglio all'interno delle sez. 1 e 3, impostato a zero nel frontespizio

	NumeroProgressivoelenco_provvisorio int IDENTITY(1,1),
	NUM int,
	
	codiceIVA varchar(14),				--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore =il numero di partita iva del soggetto passivo d’imposta con il quale è stata effettuata 
										--	l’operazione intracomunitaria
	ammontareinEuro int,				-- numerico Len.13 -- Ammontare delle operazioni in euro
	ammontareinValuta int,				-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
	numerofattura varchar(15),			-- Numero Fattura
	datafattura varchar(6),				-- Data fattura formato (ggmmaa)
	codServizio varchar(6),				-- numerico -- Codice del Servizio
	modErogazione char(1),				-- Modalità di erogazione
	modpagamento char(1),				-- Modalità pagamento/incasso 
	codPaesePagamento char(2)			-- Codice del paese di Pagamento
)


DECLARE @lenRiservatoSDA int
SET @lenRiservatoSDA = 12 

DECLARE @tipofile char(1)
SET @tipofile = 'I' --Dichiarazioni Intrastat

DECLARE @lenanno INT
SET @lenanno = 2

DECLARE @lenmese INT
SET @lenmese = 2

DECLARE @lenday INT
SET @lenday = 2

DECLARE @lencod_sezionedoganale int
SET @Lencod_sezionedoganale = 6

DECLARE @lenCF_Piva int 
SET @lenCF_Piva = 16

DECLARE @lenPiva int
SET @lenPiva = 11

DECLARE @lenCodiceIVA int
SET @lenCodiceIVA = 14 -- codice stato membro 2 + p iva 12 = 14

-- Tutti i campi presenti nella tabella #RecordDiTesta (tranne i campi "Riservato a SDA") sono obbligatori.
INSERT INTO #RecordDiTesta
(
	CodiceUA,
	riservatoSDA,
	nomedelfusso,	-- <codiceUA><data>.<tipofile><nn><p7m>
	cod_sezionedoganale,
	cf_piva,
	progressivosede
)
SELECT 
	@CodiceUA,
	REPLICATE(' ',@lenRiservatoSDA),
-- Nome del flusso
	@CodiceUA 
		+ SUBSTRING(REPLICATE('0',@lenmese),1, @lenmese - DATALENGTH(CONVERT(varchar(2),MONTH(@datainterchange)))) + CONVERT(varchar(2),MONTH(@datainterchange))
		+ SUBSTRING(REPLICATE('0',@lenday),1, @lenday - DATALENGTH(CONVERT(varchar(2),DAY(@datainterchange)))) + CONVERT(varchar(2),DAY(@datainterchange))
		+ '.'
		+ @tipofile
		+ SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),@ninterchange)))  + CONVERT(varchar(2),@ninterchange),
	SUBSTRING(REPLICATE('0',@lencod_sezionedoganale),1, @lencod_sezionedoganale - DATALENGTH(CONVERT(varchar(6),@cod_sezionedoganale))) + CONVERT(varchar(6),@cod_sezionedoganale),
	CASE
		WHEN cf IS NOT NULL THEN cf + SUBSTRING(SPACE(@lenCF_Piva),1,@lenCF_Piva - DATALENGTH(cf))
		ELSE SPACE(16)
	END,
	'001'
FROM license 

-- Lettura della p iva del responsabile della trasmissione
DECLARE @piva_contribuente varchar(11)
SELECT @piva_contribuente=
		SUBSTRING(REPLICATE('0',@lenPiva),1,@lenPiva - ISNULL(DATALENGTH(SUBSTRING(isnull(p_iva,''),1,@lenPiva)),0)) + SUBSTRING(isnull(p_iva,''),1,@lenPiva)
FROM license

DECLARE @lenperiodo int
SET @lenperiodo = 2





INSERT INTO #Frontespizio
(
	campofisso,						-- Assume valore costante 'EUROX'
	Piva_presentatore,				-- Partita IVA del presentatore
	NumeroProgressivoelenco,		-- Numero progressivo dell'elenco
	TipoRecord,						-- Tipo Record 0 = frontespizio, 1-2-3-4 sezioni 
	NumeroProgressivoRigaDettaglio,	-- Numero progressivo di riga dettaglio all'interno della sezione, zero nel frontespizio

	tipoRiepilogo,			-- Tipo Riepilogo A=acquisti, C = cessioni
	anno,					-- numerico -- Anno
	periodicita,			-- Periodicità
	periodo,				-- numerico -- Periodo: se M indica il mese, se T indica il numero di trimestre
	piva_contribuente,		-- numerico -- Partita IVA del contribuente
	casella1,				-- numerico
	casella2,				-- numerico
	piva_delegato			-- numerico -- Partita IVA del soggetto delegato
)
SELECT 
	'EUROX',
	@piva_contribuente,
	@NumeroProgressivoelenco,
	'0',
	'00000',

	@tipoRiepilogo,			
	substring (convert(varchar(4),@anno),3,2),		
	@periodicita,		
	-- periodo
	case 
		when @periodicita = 'M' 
			then SUBSTRING(REPLICATE('0',@lenperiodo),1, @lenperiodo - DATALENGTH(CONVERT(varchar(2),@mese)))  + CONVERT(varchar(2),@mese)
		when @periodicita = 'T' 
			then SUBSTRING(REPLICATE('0',@lenperiodo),1, @lenperiodo - DATALENGTH(CONVERT(varchar(2),@trimestre)))  + CONVERT(varchar(2),@trimestre)
	end,
	@piva_contribuente,		
	@casella1,				
	@casella2,								
	REPLICATE('0',11)

-- AmmontareinEuro = va riportato l’importo in euro della merce oggetto dell’operazione intracomunitaria + eventuali spese accessorie direttamente imputabili e 
-- 		opportunamente ripartite (trasporto, imballaggio, assicurazioni, etc.). L’importo va arrotondato all’unità secondo le regole dell’euro (per difetto se frazione 
-- 		inferiore a 0,5€; per eccesso se frazione superiore o uguale a 0,5€).
-- AmmontareinValuta = va indicato l’importo in valuta del paese con il quale è stata effettuata l’operazione intracomunitaria applicando il tasso di cambio alla 
-- 		data di fattura; è obbligatorio per operazioni con paesi che non hanno aderito all’euro. L’importo va arrotondato all’unità secondo le regole matematiche 
-- 		(per difetto se frazione inferiore o uguale a 0,5€; per eccesso se frazione superiore a 0,5€).
-- Valore Statistico in Euro = il valore statistico è costituito dal valore della merce più le spese di consegna (trasporto, assicurazione, etc.) fino al confine 
--		italiano (valore franco confine italiano). Per calcolare il valore statistico è necessario tenere conto delle condizioni di consegna concordate in base alle 
--		clausole “incoterms”.

-- Codice della natura dela transazione = Natura della transazione (colonna 5 cessioni; colonna 6 acquisti): va indicato un codice tra quelli riportati nella tabella 
-- relativa del decreto 27 ottobre 2000. In presenza di operazione triangolare comunitaria in cui l’operatore italiano assume la veste di acquirente/cedente, come natura 
-- della transazione va utilizzato il codice alfabetico. In tutti gli altri casi va utilizzato il codice numerico=> USIAMO SOLO QUELLO NUMERICO 




DECLARE @lencodNomenclatura int
SET @lencodNomenclatura = 8

DECLARE @lenCodServizi int
SET @lenCodServizi = 5

DECLARE @lenNumFattura int
SET @lenNumFattura = 15

DECLARE @lenweight int
SET @lenweight = 10

DECLARE @lenunitasupp int 
SET @lenunitasupp = 10

DECLARE @meseinizio int
DECLARE @mesefine int
DECLARE @idcurrency int
SELECT @idcurrency = idcurrency FROM currency WHERE codecurrency='EUR'

IF (@periodicita = 'T')
begin
	SELECT 
		@meseinizio= (@trimestre-1)*3+1,
		@mesefine = @trimestre*3
end
ELSE 
begin
	SELECT 
		@meseinizio= @mese ,
		@mesefine = @mese
end
DECLARE @s varchar(300)

IF(@unified<>'S')
Begin

	set @s = 'exp_mod_intrastat'
	IF ((@tipoRecord = 'B') OR (@tipoRecord = 'T')) 
	BEGIN
		INSERT INTO #RecordDettaglio1_BENI(
			annorif ,
			meserif ,
			trimrif ,
			segno_variazione ,
			codiceIVA, 				-- codicestatomembro= Codice dello Stato membro dell'acquirente/fornitore + Codice IVA dell'acquitente /fornitore = DE123456788
			ammontareinEuro,		-- numerico -- Ammontare delle operazioni in euro
			ammontareinValuta,		-- numerico -- Ammontare delle operazioni in valuta
			codTransazione,			-- Codice della natura dela transazione
			codNomenclatura,		-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
			massainkg,				-- numerico -- Massa netta in kilogrammi
			unitasupp,				-- numerico -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
			valorestatisticoinEuro, -- numerico -- Valore statistico in euro
			codConsegna,			-- Codice delle condizioni di consegna
			codTrasporto,			-- numerico -- Codice del modo di trasporto
			codDest_codProv,		-- Codice del paese di destinazione/provenienza
			codOrigineMerce,		-- Codice del paese di origine della merce
			provOrigine_Dest		-- Codice della provincia di origine/destinazione della merce	
		)
		exec @s @anno,@mese,@trimestre,@tipoRiepilogo,@periodicita, 'B'
	END

	IF ((@tipoRecord = 'S') OR (@tipoRecord = 'T'))
	BEGIN 
		INSERT INTO #RecordDettaglio3_SERVIZI
			(
				annorif ,
				meserif ,
				trimrif ,
				segno_variazione ,
				codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
				ammontareinEuro ,			-- numerico Len.13 -- Ammontare delle operazioni in euro
				ammontareinValuta ,			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
				numerofattura ,				-- Numero Fattura
				datafattura ,				-- Data fattura formato (ggmmaa)
				codServizio ,				-- numerico -- Codice del Servizio
				modErogazione ,				-- Modalità di erogazione
				modpagamento ,				-- Modalità pagamento/incasso 
				codPaesePagamento 			-- Codice del paese di Pagamento
			)
		
		exec @s @anno,@mese,@trimestre,@tipoRiepilogo,@periodicita, 'S'
	END
	print @s
	--select * from #RecordDettaglio1_BENI
	--select * from #RecordDettaglio3_SERVIZI
End

Else
Begin
DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor
--DECLARE @s varchar(300)

SET 	@crsdepartment = cursor for 
						 select iddbdepartment from dbdepartment
						 where  (start is null or start <= @anno ) AND ( stop is null or stop >= @anno)
OPEN 	@crsdepartment
fetch next from @crsdepartment into @iddbdepartment
while @@fetch_status=0 begin
		set @s = @iddbdepartment + '.exp_mod_intrastat'
		IF ((@tipoRecord = 'B') OR (@tipoRecord = 'T')) 
		BEGIN
		INSERT INTO #RecordDettaglio1_BENI(
			annorif ,
			meserif ,
			trimrif ,
			segno_variazione ,
			codiceIVA, 				-- codicestatomembro= Codice dello Stato membro dell'acquirente/fornitore + Codice IVA dell'acquitente /fornitore = DE123456788
			ammontareinEuro,		-- numerico -- Ammontare delle operazioni in euro
			ammontareinValuta,		-- numerico -- Ammontare delle operazioni in valuta
			codTransazione,			-- Codice della natura dela transazione
			codNomenclatura,		-- numerico -- codice della nomenclatuta combinata della merce (solo nel caso di elenchi trimestrali)
			massainkg,				-- numerico -- Massa netta in kilogrammi
			unitasupp,				-- numerico -- Unità supplementari per l'acquisto / Quantità espressa nell'unità di misura supplementare
			valorestatisticoinEuro, -- numerico -- Valore statistico in euro
			codConsegna,			-- Codice delle condizioni di consegna
			codTrasporto,			-- numerico -- Codice del modo di trasporto
			codDest_codProv,		-- Codice del paese di destinazione/provenienza
			codOrigineMerce,		-- Codice del paese di origine della merce
			provOrigine_Dest		-- Codice della provincia di origine/destinazione della merce	
		)

		exec @s @anno,@mese,@trimestre,@tipoRiepilogo,@periodicita, 'B'
		END
		print @iddbdepartment
		IF ((@tipoRecord = 'S') OR (@tipoRecord = 'T')) 
		BEGIN
		INSERT INTO #RecordDettaglio3_SERVIZI
		(
			annorif ,
			meserif ,
			trimrif ,
			segno_variazione ,
			codiceIVA ,					--  Codice dello Stato membro dell'acquirente/fornitore+  Codice IVA dell'acquitente /fornitore 
			ammontareinEuro ,			-- numerico Len.13 -- Ammontare delle operazioni in euro
			ammontareinValuta ,			-- numerico Len.13 -- Ammontare delle operazioni in valuta > > >  SOLO per i Servizi ricevuti
			numerofattura ,				-- Numero Fattura
			datafattura ,				-- Data fattura formato (ggmmaa)
			codServizio ,				-- numerico -- Codice del Servizio
			modErogazione ,				-- Modalità di erogazione
			modpagamento ,				-- Modalità pagamento/incasso 
			codPaesePagamento 			-- Codice del paese di Pagamento
		)
		Exec @s @anno,@mese,@trimestre,@tipoRiepilogo,@periodicita, 'S'
		END

		fetch next from @crsdepartment into @iddbdepartment
end
End

UPDATE #RecordDettaglio1_BENI SET 
	campofisso = 'EUROX',
	Piva_presentatore = @piva_contribuente,
	NumeroProgressivoelenco =@NumeroProgressivoelenco,	
	TipoRecord = '1'
	WHERE 	segno_variazione is null

UPDATE #RecordDettaglio1_BENI SET 
	campofisso = 'EUROX',
	Piva_presentatore = @piva_contribuente,
	NumeroProgressivoelenco =@NumeroProgressivoelenco,	
	TipoRecord = '2'
	WHERE 	segno_variazione ='-'

declare @minprovv int
set @minprovv=0
select @minprovv= MIN(NumeroProgressivoelenco_provvisorio) from #RecordDettaglio1_BENI where TipoRecord = '1'
set @minprovv= isnull(@minprovv,0)
update #RecordDettaglio1_BENI set NUM= NumeroProgressivoelenco_provvisorio-@minprovv+1 where  TipoRecord = '1'

set @minprovv=0
select @minprovv= MIN(NumeroProgressivoelenco_provvisorio) from #RecordDettaglio1_BENI where TipoRecord = '2'
set @minprovv= isnull(@minprovv,0)
update #RecordDettaglio1_BENI set NUM= NumeroProgressivoelenco_provvisorio-@minprovv+1 where  TipoRecord = '2'









UPDATE #RecordDettaglio3_SERVIZI SET 
	campofisso = 'EUROX',
	Piva_presentatore = @piva_contribuente,
	NumeroProgressivoelenco =@NumeroProgressivoelenco,	
	TipoRecord = '3'

UPDATE #RecordDettaglio3_SERVIZI SET 
	campofisso = 'EUROX',
	Piva_presentatore = @piva_contribuente,
	NumeroProgressivoelenco =@NumeroProgressivoelenco,	
	TipoRecord = '4'
	WHERE 	segno_variazione ='-'

--non gestiamo  il TipoRecord 4
delete from #RecordDettaglio3_SERVIZI where TipoRecord = '4'

set @minprovv=0
select @minprovv= MIN(NumeroProgressivoelenco_provvisorio) from #RecordDettaglio3_SERVIZI where TipoRecord = '3'
set @minprovv= isnull(@minprovv,0)
update #RecordDettaglio3_SERVIZI set NUM= NumeroProgressivoelenco_provvisorio-@minprovv+1 where  TipoRecord = '3'

set @minprovv=0
select @minprovv= MIN(NumeroProgressivoelenco_provvisorio) from #RecordDettaglio3_SERVIZI where TipoRecord = '4'
set @minprovv= isnull(@minprovv,0)
update #RecordDettaglio1_BENI set NUM= NumeroProgressivoelenco_provvisorio-@minprovv+1 where  TipoRecord = '5'



-- Numero di record presenti nel flusso (compreso il record di testa)
DECLARE  @numerorecord_nelflusso int
SET  @numerorecord_nelflusso =  1 + 1 + (SELECT COUNT(*) FROM #RecordDettaglio1_BENI)+(SELECT COUNT(*) FROM #RecordDettaglio3_SERVIZI)

UPDATE #RecordDiTesta
SET numerorecord_nelflusso = SUBSTRING(REPLICATE('0',5),1, 5 - DATALENGTH(CONVERT(varchar(5),@numerorecord_nelflusso)))  + CONVERT(varchar(5),@numerorecord_nelflusso)

-- Numero progressivo di riga dettaglio all'interno delle sez. 1 e 2, impostato a zero nel frontespizio
UPDATE #RecordDettaglio1_BENI SET NumeroProgressivoRigaDettaglio = 
				 SUBSTRING(REPLICATE('0',5),1, 5 - DATALENGTH(CONVERT(varchar(5),NUM)))  
				+ CONVERT(varchar(5),NUM)

-- Numero progressivo di riga dettaglio all'interno delle sez. 3 e 4, impostato a zero nel frontespizio
UPDATE #RecordDettaglio3_SERVIZI SET NumeroProgressivoRigaDettaglio = 
				 SUBSTRING(REPLICATE('0',5),1, 5 - DATALENGTH(CONVERT(varchar(5),NUM)))  
				+ CONVERT(varchar(5),NUM)

UPDATE #Frontespizio set 
	num_dett_sezione1	= ISNULL((SELECT COUNT(*) FROM #RecordDettaglio1_BENI WHERE TipoRecord = '1'),0),
	complessivosezione1 = ISNULL((SELECT SUM(ammontareinEuro) FROM #RecordDettaglio1_BENI WHERE TipoRecord = '1'),0),
	num_dett_sezione2	= ISNULL((SELECT COUNT(*) FROM #RecordDettaglio1_BENI WHERE TipoRecord = '2'),0),
	complessivosezione2  = ISNULL(ISNULL((SELECT SUM(ammontareinEuro) FROM #RecordDettaglio1_BENI WHERE TipoRecord = '2' and segno_variazione <> '-'),0) - ISNULL((SELECT SUM(ammontareinEuro) FROM #RecordDettaglio1_BENI WHERE TipoRecord = '2' and segno_variazione = '-'),0),0),
	num_dett_sezione3	= ISNULL((SELECT COUNT(*) FROM #RecordDettaglio3_SERVIZI WHERE TipoRecord = '3'),0),
	complessivosezione3 = ISNULL((SELECT SUM(ammontareinEuro) FROM #RecordDettaglio3_SERVIZI WHERE TipoRecord = '3'),0),
	num_dett_sezione4	= ISNULL((SELECT COUNT(*) FROM #RecordDettaglio3_SERVIZI WHERE TipoRecord = '4'),0),
	complessivosezione4 = ISNULL((SELECT SUM(ammontareinEuro) FROM #RecordDettaglio3_SERVIZI WHERE TipoRecord = '4'),0)


-- Tabella di output
CREATE TABLE #trace(out_str varchar(131)) 


IF ((@validazione='T' and @IntrawebEntratel='I') OR (@IntrawebEntratel='E'))
begin
	INSERT INTO #trace (out_str)
	SELECT 
		CodiceUA		+	
		riservatoSDA	+	
		nomedelfusso	+	
		riservatoSDA	+	
		cod_sezionedoganale	+
		REPLICATE(' ',4)+
		cf_piva			+ 	
		progressivosede	+
		REPLICATE(' ',1)+
		numerorecord_nelflusso 
	FROM #RecordDiTesta
end


 
declare @strsez7 varchar(13)
declare @possez7 int
declare @lastcharsez7 int
declare @c1 char(1)
select @possez7 = complessivosezione2 from #Frontespizio


if (@possez7 >=0)
begin
	set  @strsez7= SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),@possez7)))	
				+ CONVERT(varchar(13),@possez7)
end
else 
begin 
   select @possez7 = -@possez7
   set @lastcharsez7= @possez7  % 10
   set @possez7 = ( @possez7 - @lastcharsez7) /10
   if (@lastcharsez7 =0 ) set @c1='p'
   if (@lastcharsez7 =1 ) set @c1='q'
   if (@lastcharsez7 =2 ) set @c1='r'
   if (@lastcharsez7 =3 ) set @c1='s'
   if (@lastcharsez7 =4 ) set @c1='t'
   if (@lastcharsez7 =5 ) set @c1='u'
   if (@lastcharsez7 =6 ) set @c1='v'
   if (@lastcharsez7 =7 ) set @c1='w'
   if (@lastcharsez7 =8 ) set @c1='x'
   if (@lastcharsez7 =9 ) set @c1='y'
   set @strsez7= SUBSTRING(REPLICATE('0',12),1, 12 - DATALENGTH(CONVERT(varchar(12),@possez7)))	
				+ CONVERT(varchar(12),@possez7) + @c1
    
end

-- 1. Descrizione del record frontespizio per elenchi INTRASTAT (contenente dettagli di sezione 1 e/o sezione 2 e/o sezione 3 e/o sezione 4).
INSERT INTO #trace (out_str)
SELECT 
	campofisso + 
	Piva_presentatore	+ 
	NumeroProgressivoelenco + 
	TipoRecord + 
	NumeroProgressivoRigaDettaglio + 

	tipoRiepilogo + 
	anno + 
	periodicita + 
	periodo +
	piva_contribuente + 
	casella1 + 
	casella2 + 
	piva_delegato +
	SUBSTRING(REPLICATE('0',5),	1,  5 - DATALENGTH(CONVERT(varchar(5), num_dett_sezione1)))		+ CONVERT(varchar(5) ,num_dett_sezione1)	+
	SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),complessivosezione1)))	+ CONVERT(varchar(13),complessivosezione1)	+
	SUBSTRING(REPLICATE('0',5),	1,  5 - DATALENGTH(CONVERT(varchar(5), num_dett_sezione2)))		+ CONVERT(varchar(5) ,num_dett_sezione2)	+	
	@strsez7+
	SUBSTRING(REPLICATE('0',5),	1,  5 - DATALENGTH(CONVERT(varchar(5), num_dett_sezione3)))		+ CONVERT(varchar(5) ,num_dett_sezione3)	+
	SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),complessivosezione3)))	+ CONVERT(varchar(13),complessivosezione3)	+
	SUBSTRING(REPLICATE('0',5),	1,  5 - DATALENGTH(CONVERT(varchar(5), num_dett_sezione4)))		+ CONVERT(varchar(5) ,num_dett_sezione4)	+
	SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),complessivosezione4)))	+ CONVERT(varchar(13),complessivosezione4)
FROM #Frontespizio



-- 2  sezione 1 CESSIONI DI BENI MENSILE   
IF (@tipoRiepilogo ='C' AND @periodicita ='M')
BEGIN
-- 2. Descrizione del record dettaglio della sezione 1 relativo al riepilogo delle cessioni di beni mensile
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		codiceIVA  + 
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		codTransazione + 
		codNomenclatura + 
		SUBSTRING(REPLICATE('0',10),1, 10 - DATALENGTH(CONVERT(varchar(10),massainkg))) + CONVERT(varchar(10),massainkg)+
		SUBSTRING(REPLICATE('0',10),1, 10 - DATALENGTH(CONVERT(varchar(10),unitasupp))) + CONVERT(varchar(10),unitasupp)+
		valorestatisticoinEuro + 
		codConsegna + 
		codTrasporto + 
		ISNULL(codDest_codProv,REPLICATE('0',2)) + 
		ISNULL(provOrigine_Dest,REPLICATE('0',2)) 
	FROM #RecordDettaglio1_BENI where TipoRecord='1'
END

-- 3 sezione 1 CESSIONI DI BENI TRIMETRALE 
IF (@tipoRiepilogo ='C' AND @periodicita ='T')
BEGIN
	--3. Descrizione del record dettaglio della sezione 1 relativo al riepilogo delle cessioni di beni trimestrale	
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		codiceIVA+ 
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		codTransazione + 
		codNomenclatura  
	FROM #RecordDettaglio1_BENI where TipoRecord='1'
END


-- 4 sezione 2   RETTIFICA   CESSIONI BENI MENSILI
IF (@tipoRiepilogo ='C' AND @periodicita ='M')
BEGIN
--4. Descrizione del record dettaglio della sezione 2 di rettifica a precedenti riepiloghi delle cessioni di beni mensili
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		
		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),meserif))) + CONVERT(varchar(2),meserif)+
		CONVERT(varchar(1),trimrif)+
		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),annorif % 100))) + CONVERT(varchar(2),annorif % 100)+

		codiceIVA  + 
		segno_variazione +
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+		
		codTransazione + 
		codNomenclatura + 
		valorestatisticoinEuro 
	FROM #RecordDettaglio1_BENI where TipoRecord='2'
END



--5  sezione 2 RETTIFICA CESSIONI BENI TRIMESTRALE
IF (@tipoRiepilogo ='C' AND @periodicita ='T')
BEGIN
--5. Descrizione del record dettaglio della sezione 2 di rettifica a precedenti riepiloghi delle cessioni di beni trimestrali
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),meserif))) + CONVERT(varchar(2),meserif)+
		CONVERT(varchar(1),trimrif)+
		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),annorif % 100))) + CONVERT(varchar(2),annorif % 100)+
		codiceIVA+ 
		segno_variazione +
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		codTransazione + 
		codNomenclatura  
	FROM #RecordDettaglio1_BENI where TipoRecord='2'
END

--6   sezione 3 SERVIZI RESI
IF (@tipoRiepilogo ='C')
BEGIN
--6. Descrizione del record dettaglio della sezione 3 relativo al riepilogo dei servizi resi
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		codiceIVA  + 
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		numerofattura + 
		datafattura + 
		codServizio + REPLICATE('0',6-DATALENGTH(codServizio)) +
		modErogazione + 
		modpagamento + 
		codPaesePagamento
	FROM #RecordDettaglio3_SERVIZI where TipoRecord='3'
END


--7. Descrizione del record dettaglio della sezione 4 di rettifica a precedenti riepiloghi dei servizi resi
-- NON GESTITO




-- 8  sezione 1 ACQUISTI DI BENI MENSILE
IF (@tipoRiepilogo ='A' AND @periodicita ='M')
BEGIN
--8. Descrizione del record dettaglio della sezione 1 relativo al riepilogo degli acquisti di beni mensile
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		codiceIVA +
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinValuta))) + CONVERT(varchar(13),ammontareinValuta)+
		codTransazione +
		codNomenclatura +
		SUBSTRING(REPLICATE('0',10),1, 10 - DATALENGTH(CONVERT(varchar(10),massainkg))) + CONVERT(varchar(10),massainkg)+
		SUBSTRING(REPLICATE('0',10),1, 10 - DATALENGTH(CONVERT(varchar(10),unitasupp))) + CONVERT(varchar(10),unitasupp)+
		valorestatisticoinEuro +
		codConsegna+
		codTrasporto+
		ISNULL(codDest_codProv,REPLICATE('0',2)) +
		ISNULL(codOrigineMerce,REPLICATE('0',2))+
		ISNULL(provOrigine_Dest,REPLICATE('0',2))
	FROM #RecordDettaglio1_BENI  where TipoRecord='1'
END


-- 9 sezione 1  ACQUISTI BENI  TRIMESTRALE
IF (@tipoRiepilogo ='A' AND @periodicita ='T')
BEGIN
--9. Descrizione del record dettaglio della sezione 1 relativo al riepilogo degli acquisti di beni trimestrale
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		codiceIVA +
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinValuta))) + CONVERT(varchar(13),ammontareinValuta)+
		codTransazione +
		codNomenclatura  
	FROM #RecordDettaglio1_BENI where TipoRecord='1'
END



--10  sezione 2 RETTIFICA ACQUISTI BENI MENSILE
IF (@tipoRiepilogo ='A' AND @periodicita ='M')
BEGIN


--10. Descrizione del record dettaglio della sezione 2 di rettifica a precedenti riepiloghi degli acquisti di beni mensili
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),meserif))) + CONVERT(varchar(2),meserif)+
		'0'+
		--CONVERT(varchar(1),trimrif)+
		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),annorif % 100))) + CONVERT(varchar(2),annorif % 100)+
		codiceIVA +
		segno_variazione +
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinValuta))) + CONVERT(varchar(13),ammontareinValuta)+
		codTransazione +
		codNomenclatura +
		valorestatisticoinEuro 
	FROM #RecordDettaglio1_BENI  where TipoRecord='2'
END

-- exp_mod_intrastat_unified {ts '2017-06-07 00:00:00.000'} ,'2017' ,'6' ,'2', 'A', 'M' ,'XXXX' ,'123456' ,'0' ,'V', '1', 'E', 'N', '(null)'


--11  sezione 2 RETTIFICA ACQUISTI BENI TRIMESTRALE
IF (@tipoRiepilogo ='A' AND @periodicita ='T')
BEGIN
--11. Descrizione del record dettaglio della sezione 2 di rettifica a precedenti riepiloghi degli acquisti di beni trimestrali
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		'00'+
		--SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),meserif))) + CONVERT(varchar(2),meserif)+
		CONVERT(varchar(1),trimrif)+
		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),annorif % 100))) + CONVERT(varchar(2),annorif % 100)+
		codiceIVA +
		segno_variazione +
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinValuta))) + CONVERT(varchar(13),ammontareinValuta)+
		codTransazione +
		codNomenclatura  
	FROM #RecordDettaglio1_BENI where TipoRecord='2'
END


--12  sezione 3  SERVIZI  RICEVUTI 
IF (@tipoRiepilogo ='A' )
BEGIN
--12. Descrizione del record dettaglio della sezione 3 relativo al riepilogo dei servizi ricevuti
	INSERT INTO #trace (out_str)
	SELECT 
		campofisso +
		Piva_presentatore +
		NumeroProgressivoelenco +
		TipoRecord + 
		NumeroProgressivoRigaDettaglio + 

		codiceIVA  + 
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro)+
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinValuta))) + CONVERT(varchar(13),ammontareinValuta)+
		numerofattura + 
		datafattura + 
		codServizio + REPLICATE('0',6-DATALENGTH(codServizio)) +
		modErogazione + 
		modpagamento + 
		codPaesePagamento
	FROM #RecordDettaglio3_SERVIZI where TipoRecord='3'
END
/*
select campofisso ,	Piva_presentatore ,		NumeroProgressivoelenco ,
		TipoRecord , 
		NUM ,

		codiceIVA  ,
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro),
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinValuta))) + CONVERT(varchar(13),ammontareinValuta),
		numerofattura ,
		datafattura ,
		codServizio ,
		modErogazione ,
		modpagamento ,
		codPaesePagamento from #RecordDettaglio3_SERVIZI


select  TipoRecord,
		campofisso ,
		Piva_presentatore ,
		NumeroProgressivoelenco ,
		TipoRecord ,
		NUM ,


		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),meserif))) + CONVERT(varchar(2),meserif),
		CONVERT(varchar(1),trimrif),
		SUBSTRING(REPLICATE('0',2),1, 2 - DATALENGTH(CONVERT(varchar(2),annorif % 100))) + CONVERT(varchar(2),annorif % 100),
		codiceIVA ,
		segno_variazione ,
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinEuro))) + CONVERT(varchar(13),ammontareinEuro),
		SUBSTRING(REPLICATE('0',13),1, 13 - DATALENGTH(CONVERT(varchar(13),ammontareinValuta))) + CONVERT(varchar(13),ammontareinValuta),
		codTransazione ,
		codNomenclatura  
		from #RecordDettaglio1_BENI
*/
--13. Descrizione del record dettaglio della sezione 4 di rettifica a precedenti riepiloghi dei servizi ricevuti
-- non gestibile





SELECT out_str 
FROM #trace

DROP TABLE #RecordDiTesta
DROP TABLE #RecordDettaglio1_BENI
DROP TABLE #Frontespizio

DROP TABLE #RecordDettaglio3_SERVIZI
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


