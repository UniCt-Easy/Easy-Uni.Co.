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


/*-
Cosa fa, in breve (per orientarti)

Legge corso e opzioni dell�istanza (istanza, istanza_imm)

AnalisiCalcoloDebitiStudenti_St�

Recupera ISEE da dichiar_isee (anno = LEFT(@aa,4)) e seleziona la fascia configurata per quel versamento

AnalisiCalcoloDebitiStudenti_St�

Seleziona le righe di tassaiscrizioneconf con un ranking pi� robusto (match pi� specifico vince)

AnalisiCalcoloDebitiStudenti_St�

Calcola importi per rata/causale da ratadef + costoscontodefdettaglio (importo fisso o formula)

AnalisiCalcoloDebitiStudenti_St�

Aggiunge esoneri come righe negative usando esonerostudente + esonero (data-driven)

AnalisiCalcoloDebitiStudenti_St�

Aggiunge mora (30/60) se @dataCalcolo supera scadenza

5044-Decreto-n.-3483-Regolament�

Supporta part-time (riduce i �contributi� del 50%)

5044-Decreto-n.-3483-Regolament�

 e opzione secondo corso (-20% sui contributi)
*/

ALTER PROCEDURE dbo.usp_CalcolaDebitoStudenteAFAM
(
    @idreg        INT,
    @idistanza    INT,
    @aa           VARCHAR(9),   -- es: '2024/2025'
    @user         SYSNAME = NULL,
    @dataCalcolo  DATE = NULL,  -- default: GETDATE()
    @flagFuoriCorso BIT = 0,    -- se non hai info certa, lascia 0 (in corso)
    @isSecondCourse BIT = 0     -- per doppia iscrizione (riduz. 20% su contributi del 2� corso)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF @dataCalcolo IS NULL SET @dataCalcolo = CONVERT(date, GETDATE());

    /* =========================
       1) Lettura istanza / corso
       ========================= */
    DECLARE
        @idcorsostudio      INT,
        @iddidprog          INT,
        @iddidprogcurr      INT,
        @iddidprogori       INT,
        @parttime           BIT,
        @idiscrizione       INT;

    SELECT
        @idcorsostudio = i.idcorsostudio,
        @iddidprog     = i.iddidprog,
        @idiscrizione  = i.idiscrizione
    FROM dbo.istanza i
    WHERE i.idistanza = @idistanza
      AND i.idreg_studenti = @idreg
      AND i.aa = @aa;
	  
    -- Estensione �istanza di immatricolazione� (se esiste record)
    SELECT
        @iddidprogcurr = iim.iddidprogcurr,
		@idcorsostudio = iim.idcorsostudio,
        @iddidprogori  = iim.iddidprogori,
        @parttime      = CASE WHEN iim.parttime = 'S' THEN 1 WHEN iim.parttime = 'N' THEN 0 ELSE iim.parttime END
    FROM dbo.istanza_imm iim
    WHERE iim.idistanza = @idistanza
      AND iim.idreg_studenti = @idreg;

    IF @parttime IS NULL SET @parttime = 0;

    /* =========================
       2) Lettura ISEE (anno solare di riferimento)
       - dal tuo input: dichiar_isee(iddichiar,idreg,anno,isee)
       ========================= */
    DECLARE @annoIsee INT = TRY_CONVERT(INT, LEFT(@aa, 4));
    DECLARE @isee DECIMAL(18,2);

    SELECT TOP (1)
        @isee = d.isee
    FROM dbo.dichiar_isee d
    WHERE d.idreg = @idreg
      AND d.anno = @annoIsee
    ORDER BY d.iddichiar DESC;

	-- Leggiamo l'anno di iscrizione perchè dopo servirà per capire se Fuori Corso
	declare @annoiscrizione int
	select @annoiscrizione = anno
	from iscrizione I
	where I.idiscrizione = @idiscrizione

	declare @idcorsostudiokind int 
	select @idcorsostudiokind = idcorsostudiokind
	from corsostudio
	where idcorsostudio = @idcorsostudio

	declare @idstruttura int
	select @idstruttura = idstruttura
	from corsostudiostruttura cs 
	where cs.idcorsostudio = @idcorsostudio
			
	declare @annoFuoriCorso int
	set @annoFuoriCorso = (select top 1 isnull(ia.annofc,0) 
				from iscrizioneanno ia
				where ia.idreg = @idreg and ia.idiscrizione = @idiscrizione and ia.idcorsostudio = @idcorsostudio and ia.iddidprog = @iddidprog
				order by ia.annofc desc )

	if(@annoFuoriCorso>0)
		Begin
			set @flagFuoriCorso = 1	
		End
-- Per test
--set @flagFuoriCorso = 1	
--set @annoFuoriCorso = 1
    /* ==========================================================
       3) Selezione tassaiscrizioneconf con ranking �robusto�
       - un corso pu� matchare pi� configurazioni: scegliamo le pi� specifiche
       - score pi� alto = match pi� specifico (corsostudio, didprog, curr, ori, ecc.)
       ========================================================== */

    IF OBJECT_ID('tempdb..#CalcList') IS NOT NULL DROP TABLE #CalcList;
    CREATE TABLE #CalcList
    (
        idcostoscontodef INT NOT NULL,
        sorgente         VARCHAR(20) NOT NULL,  -- 'VERSAMENTO' | 'ESONERO' | 'INDENNIZZO'
        segno            INT NOT NULL            -- +1 / -1 (esoneri tipicamente -1)
    );



    -- Creo tabella temporanea per VersamentiSelezionati
    IF OBJECT_ID('tempdb..#VersamentiSelezionati') IS NOT NULL DROP TABLE #VersamentiSelezionati;
/*
==================================================================
RANKING MIGLIORATO per selezione tassaiscrizioneconf
==================================================================
Miglioramenti rispetto alla versione originale:
1. Pesi differenziati per importanza dei match
2. Gestione annomin/annomax per studenti in corso
3. Gestione annofcmin/annofcmax per studenti fuori corso
4. Match su idcorsostudiokind (tipo corso accademico)
5. Match su idstruttura (dipartimento/scuola)
6. Filtro su aa con range corretto
7. Commenti esplicativi per manutenibilità
==================================================================
*/

-- Variabili necessarie (già presenti nella SP):
-- @idreg, @idistanza, @aa, @idcorsostudio, @iddidprog, @iddidprogcurr, @iddidprogori
-- @flagFuoriCorso (BIT) - indica se lo studente è fuori corso
-- @annoIscrizione (INT) - anno di iscrizione dello studente (1, 2, 3, ecc.)
-- @annoFuoriCorso (INT) - se fuori corso, quanti anni oltre la durata normale

-- Creo tabella temporanea per VersamentiSelezionati
IF OBJECT_ID('tempdb..#VersamentiSelezionati') IS NOT NULL DROP TABLE #VersamentiSelezionati;

;WITH MatchScores AS (
    /*
    Calcola un punteggio (Score) per ogni configurazione tassaiscrizioneconf.
    I pesi sono assegnati in base alla specificità del match:
    - Match esatto su corso specifico = peso maggiore
    - Match su tipologia corso = peso minore (fallback generico)
    
    Gerarchia dei pesi:
    - idcorsostudio:     100 (match esatto sul corso)
    - iddidprog:          50 (match sulla didattica programmata)
    - iddidprogcurr:      30 (match sul curriculum)
    - iddidprogori:       30 (match sull'orientamento)
    - idstruttura:        20 (match sul dipartimento/scuola)
    - idcorsostudiokind:  10 (match sulla tipologia corso - fallback)
    - aa esatto:           5 (match sull'anno accademico esatto)
    */
    SELECT
        tic.idtassaiscrizioneconf,
        tic.idcostoscontodef,
        tic.title,
        -- Calcolo Score con pesi differenziati
        (CASE WHEN tic.idcorsostudio IS NOT NULL AND tic.idcorsostudio = @idcorsostudio THEN 100 ELSE 0 END) +
        (CASE WHEN tic.iddidprog IS NOT NULL AND tic.iddidprog = @iddidprog THEN 50 ELSE 0 END) +
		--(case when @annoiscrizione is not null and @annoiscrizione between tic.annofcmin and tic.annofcmax then 50 ELSE 0 END)+ /*Lo gestiamo nella WHERE*/
        (CASE WHEN tic.iddidprogcurr IS NOT NULL AND tic.iddidprogcurr = @iddidprogcurr THEN 30 ELSE 0 END) +
        (CASE WHEN tic.iddidprogori IS NOT NULL AND tic.iddidprogori = @iddidprogori THEN 30 ELSE 0 END) +
        (CASE WHEN tic.idstruttura IS NOT NULL AND tic.idstruttura = @idstruttura THEN 20 ELSE 0 END) +
        (CASE WHEN tic.idcorsostudiokind IS NOT NULL AND tic.idcorsostudiokind = @idcorsostudiokind THEN 10 ELSE 0 END) +
        (CASE WHEN tic.aa = @aa THEN 5 ELSE 0 END)
        AS MatchScore
    FROM dbo.tassaiscrizioneconf tic
    WHERE 
        -- =====================================================
        -- FILTRO ANNO ACCADEMICO (range o esatto)
        -- =====================================================
        (
            tic.aa = @aa 
            OR (
                CAST(LEFT(@aa, 4) AS INT) 
                BETWEEN CAST(LEFT(ISNULL(tic.aamin, '1900/0000'), 4) AS INT) 
                    AND CAST(LEFT(ISNULL(tic.aamax, '2100/0000'), 4) AS INT)
            )
            OR (tic.aa IS NULL AND tic.aamin IS NULL AND tic.aamax IS NULL)
        )
        -- =====================================================
        -- FILTRO CORSO (match esatto o NULL = tutti i corsi)
        -- =====================================================
        AND (tic.idcorsostudio IS NULL OR tic.idcorsostudio = @idcorsostudio)
        AND (tic.iddidprog IS NULL OR tic.iddidprog = @iddidprog)
        AND (tic.iddidprogcurr IS NULL OR tic.iddidprogcurr = @iddidprogcurr)
        AND (tic.iddidprogori IS NULL OR tic.iddidprogori = @iddidprogori)
        AND (tic.idstruttura IS NULL OR tic.idstruttura = @idstruttura)
        AND (tic.idcorsostudiokind IS NULL OR tic.idcorsostudiokind = @idcorsostudiokind)
        -- =====================================================
        -- FILTRO ANNO ISCRIZIONE (per studenti IN CORSO)
        -- annomin/annomax: se valorizzati, lo studente deve essere in quell'anno
        -- Es: annomin=1, annomax=1 = solo matricole
        -- Es: annomin=2, annomax=NULL = dal secondo anno in poi
        -- =====================================================
        AND (
            @flagFuoriCorso = 1  -- se fuori corso, ignora questo filtro
            OR (
                (tic.annomin IS NULL OR @annoIscrizione >= tic.annomin)
                AND (tic.annomax IS NULL OR @annoIscrizione <= tic.annomax)
            )
        )
        -- =====================================================
        -- FILTRO ANNI FUORI CORSO
        -- annofcmin/annofcmax: se valorizzati, la config è per fuori corso
        -- Se lo studente è IN CORSO, deve matchare config con annofcmin IS NULL
        -- Se lo studente è FUORI CORSO, deve matchare config con annofcmin valorizzato
        -- =====================================================
        AND (
            -- Studente IN CORSO: prende solo config senza annofcmin
            (@flagFuoriCorso = 0 AND tic.annofcmin IS NULL)
            OR
            -- Studente FUORI CORSO: prende config con annofcmin nel range
            (@flagFuoriCorso = 1 
             AND tic.annofcmin IS NOT NULL
             AND @annoFuoriCorso >= tic.annofcmin
             AND (@annoFuoriCorso <= tic.annofcmax OR tic.annofcmax IS NULL)
            )
        )
),
RankedMatches AS (
    /*
    Assegna un Rank a ogni configurazione per lo stesso idcostoscontodef.
    Se esistono più configurazioni per lo stesso versamento, 
    prende quella con MatchScore più alto (più specifica).
    */
    SELECT
        ms.idtassaiscrizioneconf,
        ms.idcostoscontodef,
        ms.title,
        ms.MatchScore,
        ROW_NUMBER() OVER (
            PARTITION BY ms.idcostoscontodef  -- Per ogni tipo di versamento
            ORDER BY ms.MatchScore DESC,      -- Priorità al match più specifico
                     ms.idtassaiscrizioneconf DESC  -- A parità, il più recente
        ) AS rn
    FROM MatchScores ms
)
-- Materializzo in tabella temporanea solo le configurazioni con rank 1
SELECT
    rm.idtassaiscrizioneconf,
    rm.idcostoscontodef,
    rm.title,
    rm.MatchScore
INTO #VersamentiSelezionati
FROM RankedMatches rm
WHERE rm.rn = 1;

---- Debug: visualizza le configurazioni selezionate (commentare in produzione)
	--SELECT '#VersamentiSelezionati-Pre',* FROM #VersamentiSelezionati ORDER BY idcostoscontodef;
	
	-- TOLGO LE RIGHE CHE SI RIFERISCONO ALLA MORA, perchè verranno aggiunte dopo
 delete from #VersamentiSelezionati where
				idcostoscontodef in (select idcostoscontodef 
						from costoscontodef where idcostoscontodefkind=3)
	 --SELECT '#VersamentiSelezionati-Post',* FROM #VersamentiSelezionati ORDER BY idcostoscontodef;
/*
==================================================================
NOTE IMPORTANTI:
==================================================================

1. VARIABILI DA RECUPERARE PRIMA DI QUESTO BLOCCO:
   - @idcorsostudio: dal campo istanza.idcorsostudio
   - @iddidprog: dal campo istanza.iddidprog
   - @iddidprogcurr: dal campo istanza_immatricolazione.iddidprogcurr
   - @iddidprogori: dal campo istanza_immatricolazione.iddidprogori
   - @idstruttura: da corsostudio JOIN corsostudiostruttura
   - @idcorsostudiokind: da corsostudio.idcorsostudiokind
   - @annoIscrizione: anno corrente di iscrizione (1, 2, 3...)
   - @flagFuoriCorso: 1 se studente fuori corso, 0 altrimenti
   - @annoFuoriCorso: quanti anni oltre la durata normale (se fuori corso)

2. LOGICA DI PRIORITÀ:
   Una configurazione specifica per un corso batte sempre 
   una configurazione generica per tipologia corso.
   
   Esempio:
   - Config A: idcorsostudio=5, idcorsostudiokind=NULL → Score 100
   - Config B: idcorsostudio=NULL, idcorsostudiokind=1 → Score 10
   → Viene scelta Config A

3. GESTIONE FUORI CORSO:
   - Studente IN CORSO (flagFuoriCorso=0): 
     Prende SOLO configurazioni con annofcmin IS NULL
   - Studente FUORI CORSO (flagFuoriCorso=1):
     Prende SOLO configurazioni con annofcmin valorizzato
   
   Questo garantisce che i fuori corso abbiano tariffe diverse.

4. MANUTENIBILITÀ:
   Se aggiungi nuovi criteri di match in tassaiscrizioneconf,
   aggiungi il relativo peso nella sezione MatchScore.

==================================================================
*/

----------------------------------------------------------------SELECT  * FROM #VersamentiSelezionati
    /* ==========================================================
       4) Costruzione «lista calcoli»:
          - righe di costoscontodef del corso (versamenti)
          - + righe di esonero associate allo studente (come costoscontodefkind=2)
          - + eventuali indennizzi/rimborsi (costoscontodefkind=4) se configurati nel corso
       ========================================================== */
	   --select  * from esoneroanskind
	

    -- Versamenti «positivi»
    INSERT INTO #CalcList(idcostoscontodef, sorgente, segno)
    SELECT DISTINCT vs.idcostoscontodef, 'VERSAMENTO', +1
    FROM #VersamentiSelezionati vs;

    -- Esoneri dello studente (data-driven):
    INSERT INTO #CalcList(idcostoscontodef, sorgente, segno)
    SELECT DISTINCT e.idcostoscontodef, 'ESONERO', -1
    FROM dbo.esonerostudente es
    JOIN dbo.esonero e
      ON e.idesonero = es.idesonero
     AND e.aa = @aa
    WHERE es.idreg = @idreg
      AND (es.esito = 'S' OR es.esito = 1)
      AND (es.idiscrizione IS NULL OR es.idiscrizione = @idiscrizione);

    -- Indennizzi/rimborsi
    INSERT INTO #CalcList(idcostoscontodef, sorgente, segno)
    SELECT DISTINCT vs.idcostoscontodef, 'INDENNIZZO', +1
    FROM #VersamentiSelezionati vs
    JOIN dbo.costoscontodef c ON c.idcostoscontodef = vs.idcostoscontodef
    WHERE c.idcostoscontodefkind = 4;

--select '#CalcList',*  FROM #CalcList CC 
--SELECT 'COSTI E ESONERI',D.title as costoscontodef,CC.* FROM #CalcList CC 
--join costoscontodef D on CC.idcostoscontodef = D.idcostoscontodef


    /* ==========================================================
       5) Scelta fascia ISEE applicabile per ogni costoscontodef
       - se ISEE mancante => fascia �pi� alta� tra quelle configurate per quel versamento
       ========================================================== */

    IF OBJECT_ID('tempdb..#FasciaScelta') IS NOT NULL DROP TABLE #FasciaScelta;
    CREATE TABLE #FasciaScelta
    (
        idcostoscontodef  INT NOT NULL,
        idfasciaiseedef   INT NULL,
        idfasciaisee      VARCHAR(50) NULL
    );
	
	--select '#CalcList',* from #CalcList

    INSERT INTO #FasciaScelta(idcostoscontodef, idfasciaiseedef, idfasciaisee)
    SELECT
        cl.idcostoscontodef,
        fs.idfasciaiseedef,
        fs.idfasciaisee
    FROM #CalcList cl
    OUTER APPLY
    (
        SELECT TOP (1)
            fid.idfasciaiseedef,
            fi.idfasciaisee
        FROM dbo.fasciaiseedef fid
        JOIN dbo.fasciaisee fi
          ON fi.idfasciaisee = fid.idfasciaisee
        WHERE fid.idcostoscontodef = cl.idcostoscontodef
          --AND (fi.flagfuoricorso IS NULL OR fi.flagfuoricorso = @flagFuoriCorso)
          AND
          (
              @isee IS NULL
			  or fi.idfasciaisee = 'SENZA_FASCIA'
              OR ( @isee >= fi.redditomin AND @isee <= fi.redditomax)
          )
        ORDER BY
            CASE WHEN @isee IS NULL THEN fi.numero END DESC,
            CASE WHEN @isee IS NOT NULL THEN fi.numero END ASC,
            fi.numero DESC
    ) fs;


----------------------------------------------------------------
--SELECT 'tab FasciaScelta', D.title as costoscontodef,F.* 
--FROM 	#FasciaScelta F
--left outer join costoscontodef D on F.idcostoscontodef = D.idcostoscontodef

--SELECT 'tab FasciaScelta', * 
--FROM 	#FasciaScelta F


    /* ==========================================================
       6) Rate applicabili (ratadef) e dettagli (costoscontodefdettaglio)
          Calcolo importo:
          - se importo fisso -> usa importo
          - altrimenti se percentuale valorizzata -> percentuale su (ISEE - paramB) con moltiplicatori
          - altrimenti formula: [paramA*(ISEE-paramB)+paramC]*paramD
       ========================================================== */

    IF OBJECT_ID('tempdb..#Dettagli') IS NOT NULL DROP TABLE #Dettagli;
    CREATE TABLE #Dettagli
    (
        sorgente                      VARCHAR(20),
        idcostoscontodef              INT,
        idratadef                     INT NULL,
        idratakind                    VARCHAR(20) NULL,
        rata_title                    NVARCHAR(200) NULL,
        decorrenza                    DATE NULL,
        scadenza                      DATE NULL,
        idcostoscontodefdettagliokind INT,
        causale_codice                NVARCHAR(50) NULL,
        causale_title                 NVARCHAR(400) NULL,
        importo_calcolato             DECIMAL(18,2) NOT NULL
    );

	/* ==========================================================
   6) Calcolo dettagli per rata/causale
      - FIX: per costoscontodefkind=2 con percentuale valorizzata
             la percentuale si applica al TOTALE versamento (kind=1),
             non all'ISEE.
   ========================================================== */

-- FASE A: inserisco tutto TRANNE riduzioni(kind=2) percentuali e 3 = Mora
INSERT INTO #Dettagli
(
    sorgente, idcostoscontodef, idratadef, idratakind, rata_title, decorrenza, scadenza,
    idcostoscontodefdettagliokind, causale_codice, causale_title, importo_calcolato
)
SELECT
    cl.sorgente,
    cl.idcostoscontodef,
    rd.idratadef,
    rd.idratakind,
    rk.title AS rata_title,
    rd.decorrenza,
    rd.scadenza,
    d.idcostoscontodefdettagliokind,
    dk.codice,
    dk.title,
    CAST(
        cl.segno *
        (
            CASE
                -- 1) Importo fisso
                WHEN d.importo IS NOT NULL THEN d.importo

                -- 2) Formula parametrica: [(ISEE - B) * A + C] * D
                WHEN d.parama IS NOT NULL AND d.paramb IS NOT NULL AND d.paramc IS NOT NULL AND d.paramd IS NOT NULL THEN
                    (
                        ( (CASE WHEN @isee IS NULL THEN 0.0 ELSE (@isee - d.paramb) END) * d.parama ) + d.paramc
                    ) * d.paramd

                -- 3) Percentuale (regola standard): % sull'ISEE
                --    (vale per versamenti kind=1 o riduzioni non-percentuali sul totale)>>>>>>>>>>>>>>>>>> NO, la % si applica all'importo del versamento finale
                --WHEN d.percentuale IS NOT NULL THEN
                --    (CASE WHEN @isee IS NULL THEN 0.0 ELSE @isee END) * (d.percentuale / 100.0)

                ELSE 0.0
            END
        )
    AS DECIMAL(18,2)) AS importo_calcolato
FROM #CalcList cl
JOIN dbo.costoscontodef cdef
  ON cdef.idcostoscontodef = cl.idcostoscontodef
LEFT JOIN #FasciaScelta fs
  ON fs.idcostoscontodef = cl.idcostoscontodef
left JOIN dbo.ratadef rd
  ON rd.idcostoscontodef = cl.idcostoscontodef
 AND (rd.idfasciaiseedef = fs.idfasciaiseedef OR rd.idfasciaiseedef IS NULL)
left JOIN dbo.ratakind rk
  ON rk.idratakind = rd.idratakind
JOIN dbo.costoscontodefdettaglio d
  ON d.idcostoscontodef = cl.idcostoscontodef
 AND (d.idratadef = rd.idratadef OR d.idratadef IS NULL)---------------> idratadef fa parte della chiave, per cui non ha senso confrontare col null 
 AND (d.idfasciaiseedef = fs.idfasciaiseedef OR d.idfasciaiseedef IS NULL)
JOIN dbo.costoscontodefdettagliokind dk
  ON dk.idcostoscontodefdettagliokind = d.idcostoscontodefdettagliokind
WHERE NOT (
    cdef.idcostoscontodefkind in( 2,3)
    AND d.percentuale IS NOT NULL
    -- se vuoi essere più restrittivo: AND d.importo IS NULL AND d.parama IS NULL AND d.paramb IS NULL AND d.paramc IS NULL
);
--	select '#Dettagli-1', * from #Dettagli
-- FASE B: riduzioni/esoneri percentuali (kind=2) calcolate come % del totale versamento finale
IF OBJECT_ID('tempdb..#TotVersamentoRata') IS NOT NULL DROP TABLE #TotVersamentoRata;

SELECT
    d.idratadef,
    dVers.idcostoscontodef AS idcostoscontodef_versamento,
    SUM(d.importo_calcolato) AS totale_versamento_rata
INTO #TotVersamentoRata
FROM #Dettagli d
JOIN dbo.costoscontodef dVers
  ON dVers.idcostoscontodef = d.idcostoscontodef
WHERE dVers.idcostoscontodefkind = 1  -- solo versamenti base
GROUP BY d.idratadef, dVers.idcostoscontodef;

-- Inserisco le righe di riduzione percentuale applicandole al totale del versamento "padre"
/*
Note importanti (per evitare sorprese)

Il legame “riduzione %” → “versamento su cui applicarla” l’ho fatto con:
costoscontodef (riduzione).paridcostoscontodef = idcostoscontodef (versamento padre)
Se nel tuo DB il legame è diverso, dimmelo e lo adeguo, ma questo è quello più coerente col tuo modello.

cl.segno resta valido:

per esoneri inseriti in #CalcList con segno -1 ⇒ la riduzione va in negativo (decurta).

se per qualche motivo hai riduzioni con segno +1, funzionano uguale.

La percentuale ora è sul totale versamento per rata (dopo eventuali calcoli ISEE/formule).
È quello che mi hai chiesto: “percentuale applicata all’importo finale calcolato”.
*/
--select '#TotVersamentoRata',* from #TotVersamentoRata

INSERT INTO #Dettagli
(
    sorgente, idcostoscontodef, idratadef, idratakind, rata_title, decorrenza, scadenza,
    idcostoscontodefdettagliokind, causale_codice, causale_title, importo_calcolato
)
SELECT
    cl.sorgente,
    cl.idcostoscontodef,
    rd.idratadef,
    rd.idratakind,
    rk.title AS rata_title,
    rd.decorrenza,
    rd.scadenza,
    dett.idcostoscontodefdettagliokind,
    dk.codice,
    dk.title,

    CAST(
        cl.segno *
        (
            ISNULL(tv.totale_versamento_rata, 0.0)
            * (dett.percentuale / 100.0)
            * ISNULL(dett.paramd, 1.0)   -- se vuoi “dimezzare” su 2 rate, lo fai in config via paramD
        )
    AS DECIMAL(18,2)) AS importo_calcolato
FROM #CalcList cl
JOIN dbo.costoscontodef cRid
  ON cRid.idcostoscontodef = cl.idcostoscontodef
 AND cRid.idcostoscontodefkind = 2
LEFT JOIN #FasciaScelta fs
  ON fs.idcostoscontodef = cl.idcostoscontodef
LEFT JOIN dbo.ratadef rd
  ON rd.idcostoscontodef = cl.idcostoscontodef
 AND (rd.idfasciaiseedef = fs.idfasciaiseedef OR rd.idfasciaiseedef IS NULL)
LEFT JOIN dbo.ratakind rk
  ON rk.idratakind = rd.idratakind
JOIN dbo.costoscontodefdettaglio dett
  ON dett.idcostoscontodef = cl.idcostoscontodef
 --AND (dett.idratadef = rd.idratadef OR dett.idratadef IS NULL)
 --AND (dett.idfasciaiseedef = fs.idfasciaiseedef OR dett.idfasciaiseedef IS NULL)
left JOIN dbo.costoscontodefdettagliokind dk
  ON dk.idcostoscontodefdettagliokind = dett.idcostoscontodefdettagliokind
LEFT JOIN #TotVersamentoRata tv
  ON /*tv.idratadef = rd.idratadef
 AND */tv.idcostoscontodef_versamento = cRid.paridcostoscontodef   -- padre del versamento
WHERE dett.percentuale IS NOT NULL;

--select * from #Dettagli

    /* ==========================================================
       7) Riduzioni �di regime� (part-time / doppia iscrizione)
          - part-time: -50% contributo di istituto (solo quota contributi)
          - doppia iscrizione (secondo corso): -20% su contributi del secondo corso
          NB: qui lo applichiamo �per keyword� sulla causale, perch� nel modello non c�� un flag strutturale.
       ========================================================== */
    UPDATE d
       SET d.importo_calcolato = ROUND(d.importo_calcolato * 0.5, 2)
    FROM #Dettagli d
    WHERE @parttime = 1
      AND (UPPER(d.causale_title) LIKE '%CONTRIBUTO%' OR UPPER(d.causale_title) LIKE '%CONTRIBUTI%');

    UPDATE d
       SET d.importo_calcolato = ROUND(d.importo_calcolato * 0.8, 2)
    FROM #Dettagli d
    WHERE @isSecondCourse = 1
      AND (UPPER(d.causale_title) LIKE '%CONTRIBUTO%' OR UPPER(d.causale_title) LIKE '%CONTRIBUTI%');

    /* ==========================================================
       8) Mora (costoscontodefkind = 3) se dataCalcolo > scadenza
          - fino a 30gg: 30�
          - oltre 30gg: 60�
          La mora � una riga separata.
       ========================================================== */

    DECLARE @idMora30 INT, @idMora60 INT;

    -- Qui assumiamo che in costoscontodef (kind=3) esistano due definizioni con dettagli importo fisso
    SELECT TOP (1) @idMora30 = c.idcostoscontodef
    FROM dbo.costoscontodef c
    WHERE c.idcostoscontodefkind = 3
      AND (UPPER(c.title) LIKE '%FINO%' OR UPPER(c.title) LIKE '%30%')
    ORDER BY c.idcostoscontodef DESC;

    SELECT TOP (1) @idMora60 = c.idcostoscontodef
    FROM dbo.costoscontodef c
    WHERE c.idcostoscontodefkind = 3
      AND (UPPER(c.title) LIKE '%OLTRE%' OR UPPER(c.title) LIKE '%60%')
    ORDER BY c.idcostoscontodef DESC;

				

    IF @idMora30 IS NOT NULL OR @idMora60 IS NOT NULL
    BEGIN
        ;WITH Scadute AS
        (
            SELECT DISTINCT
                d.idratadef,
                d.idratakind,
                d.rata_title,
                d.scadenza,
                GiorniRitardo = DATEDIFF(DAY, d.scadenza, @dataCalcolo)
            FROM #Dettagli d
            WHERE d.scadenza IS NOT NULL
              AND @dataCalcolo > d.scadenza
              AND d.sorgente = 'VERSAMENTO'
			  and d.causale_codice<>'BOLLO' --> Sta aggiungendo le eventuali More sui versamenti calcolati, ma non deve farlo sul versamento BOLLO
              AND d.importo_calcolato > 0
        )
		
        INSERT INTO #Dettagli
        (
            sorgente, idcostoscontodef, idratadef, idratakind, rata_title, decorrenza, scadenza,
            idcostoscontodefdettagliokind, causale_codice, causale_title, importo_calcolato
        )
        SELECT
            'MORA',
            CASE WHEN s.GiorniRitardo <= 30 THEN @idMora30 ELSE @idMora60 END,
            s.idratadef,
            s.idratakind,
            s.rata_title,
            NULL,
            s.scadenza,
            dk.idcostoscontodefdettagliokind,
            dk.codice,
            dk.title,
            CAST( ISNULL(dd.importo, 0.0) AS DECIMAL(18,2) )
        FROM Scadute s
        CROSS APPLY
        (
            SELECT TOP (1) d2.*
            FROM dbo.costoscontodefdettaglio d2
            WHERE d2.idcostoscontodef = CASE WHEN s.GiorniRitardo <= 30 THEN @idMora30 ELSE @idMora60 END
            ORDER BY d2.idcostoscontodefdettaglio DESC
        ) dd
        JOIN dbo.costoscontodefdettagliokind dk
          ON dk.idcostoscontodefdettagliokind = dd.idcostoscontodefdettagliokind;
    END;



    /* ==========================================================
       9) TODO RIMBORSI �automatici� da regolamento (es. 80%)
          - qui serve una tabella/flag che dica: sospensione, trasferimento, data richiesta, esito, ecc.
          - se me la indichi, inseriamo righe negative qui.
       ========================================================== */

    /* =========================
       10) Output (dettaglio)
       ========================= */
    SELECT
        @idreg            AS idreg,
        @idistanza        AS idistanza,
        @aa               AS aa,
        @isee             AS isee,
        d.sorgente        AS tipo_riga,        -- VERSAMENTO / ESONERO / INDENNIZZO / MORA
        d.idcostoscontodef,
        d.idratadef,
        d.idratakind,
        d.rata_title,
        d.decorrenza,
        d.scadenza,
        d.idcostoscontodefdettagliokind,
        d.causale_codice,
        d.causale_title,
        d.importo_calcolato AS importo
    FROM #Dettagli d
   WHERE d.importo_calcolato <> 0
    ORDER BY
        CASE d.sorgente
            WHEN 'VERSAMENTO' THEN 1
            WHEN 'ESONERO' THEN 2
            WHEN 'INDENNIZZO' THEN 3
            WHEN 'MORA' THEN 4
            ELSE 9
        END,
        d.scadenza,
        d.idratadef,
        d.causale_title;
END;
GO
