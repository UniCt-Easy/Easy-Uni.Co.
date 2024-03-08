
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_nuoveanagrafiche]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_nuoveanagrafiche]
GO
 
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
 
CREATE PROCEDURE exp_interscambio_csa_nuoveanagrafiche
(
    @datagenerazione datetime,
    @ateneo varchar(5)
)
AS

--Le anagrafiche interessate da questa procedura dovranno rispettare congiuntamente le seguenti condizioni:
--1)    L’anagrafica di Easy non dovrà avere il numero di matricola e dovrà avere la valorizzazione del codice fiscale.
--2)    L’anagrafica di Easy è stata utilizzata nel form Banca Data Incarichi con opzione su “Dipendenti di altri Enti Pubblici” o “Dipendenti dello stesso Ente”.
--3)    Nella vista Easy_Anagrafiche non esiste il codice fiscale delle anagrafiche che rispettano le condizioni 1) e 2).
--4)    La condizione 3) viene sostituita da una condizione sulla nuova vista Easy_Anagrafiche_8000 allo scopo di poter verificare la presenza
-- dell'anagrafica in una delle due procedure CSA attualmente in uso

/*
exec exp_interscambio_csa_nuoveanagrafiche {ts '2012-12-31 01:02:03'}, '70136'
*/
BEGIN
   
CREATE TABLE #error (message varchar(400))
   
CREATE TABLE #Anagrafiche
(
    idreg int,
    cf varchar(16),
    matricola varchar(40),
    employkind char(1),
    toinsert char(1)
)

INSERT INTO #Anagrafiche  -- IN QUESTA TABELLA ANDIAMO A INSERIRE LE NUOVE ANAGRAFICHE  NON CENSITE IN CSA
(   
    idreg,
    cf,
    employkind,
    toinsert
)
SELECT DISTINCT
    R.idreg,
    R.cf,
    S.employkind,
    'S'
FROM registry  R
JOIN  serviceregistry S
  ON R.idreg = S.idreg
WHERE ISNULL(R.extmatricula,'') = ''
AND R.cf IS NOT NULL
AND S.employkind in ('A', 'D')
ORDER BY R.cf, S.employkind

-- Ciclo per determinare se le anagrafiche ottenute sono censite in Easy. Se sono già censite, le escludo dalla presente importazione
CREATE TABLE #count_cf_in_csa (count_cf int)
DECLARE         @cf varchar(20)
DECLARE         @employkind char(1)
DECLARE         @count_cf INT
DECLARE      rowcursor INSENSITIVE CURSOR FOR
SELECT  cf, employkind
FROM    #Anagrafiche
FOR READ ONLY
 
OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO @cf , @employkind
WHILE @@FETCH_STATUS = 0
BEGIN
    -- CHIAMA LA SP DI VERIFICA DEL CODICE FISCALE CHE LEGGE IL DATO DALLA VISTA EASY_ANAGRAFICHE
    INSERT INTO #count_cf_in_csa EXEC    verifica_cf_in_csa @cf, @employkind 
    SELECT  @count_cf = count_cf FROM #count_cf_in_csa
   
    IF  ISNULL(@count_cf,0) > 0   UPDATE #Anagrafiche SET toinsert = 'N' WHERE cf = @cf AND employkind =  @employkind
   
    FETCH NEXT FROM rowcursor
    INTO @cf, @employkind 
END
DEALLOCATE rowcursor


-- CANCELLO LE ANAGRAFICHE GIA' CENSITE IN CSA
DELETE #Anagrafiche WHERE toinsert = 'N'
-- 1. Controllo se ci sono Anagrafiche da inserire
IF NOT EXISTS((SELECT * FROM #Anagrafiche))
BEGIN
    INSERT INTO #error (message)
    SELECT 'Non ci sono anagrafiche da inserire'
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
    SELECT * FROM #error
    RETURN
END
--IDENTITY [ (seed , increment) ]
DECLARE @count_A  int
SELECT  @count_A =  COUNT(*) FROM #Anagrafiche WHERE employkind = 'A'
ALTER TABLE #Anagrafiche ADD ind int identity (1,1)  -- aggiungo l'indice relativo per il calcolo progressivo della nuova matricola


CREATE TABLE #maxmatriculacsa
(
     matricola int,
     employkind char(1)
)

-- CHIAMA LA SP DI CALCOLO DELL'ULTIMO NUMERO DI MATRICOLA, CHE LEGGE IL DATO DALLA VISTA EASY_ANAGRAFICHE_8000

INSERT INTO #maxmatriculacsa(matricola, employkind) 
EXEC calc_matricola_csa

DECLARE @maxmatriculacsa_A INT
SELECT  @maxmatriculacsa_A = matricola FROM #maxmatriculacsa WHERE employkind = 'A'

DECLARE @maxmatriculacsa_D INT
SELECT  @maxmatriculacsa_D = matricola FROM #maxmatriculacsa WHERE employkind = 'D'

UPDATE #Anagrafiche SET matricola = CONVERT(varchar(40),@maxmatriculacsa_A + ind) WHERE employkind = 'A'
UPDATE #Anagrafiche SET matricola = CONVERT(varchar(40),@maxmatriculacsa_D + ind - @count_A) WHERE employkind = 'D'

--select * from #Anagrafiche
--select * from #maxmatriculacsa

----------------------------------------------
------------  LETTURA DEGLI INDIRIZZI --------
----------------------------------------------

DECLARE @codenostand varchar(20)
SET @codenostand = '07_SW_DOM' -- DOMICILIO FISCALE

DECLARE @codestand varchar(20)
SET @codestand = '07_SW_DEF' -- RESIDENZA

DECLARE @STAND int
SELECT @STAND = idaddress FROM address WHERE codeaddress = @codestand

DECLARE @NOSTAND int
SELECT @NOSTAND = idaddress FROM address WHERE codeaddress = @codenostand

DECLARE @dateindi datetime
SET @dateindi = @datagenerazione -- data generazione del flusso, data validità dell'indirizzo considerato


CREATE TABLE #address
(
    idaddresskind int,
    codeaddress varchar(20),
    idreg int,
    address varchar(100),
    location varchar(116),
    cap varchar(15),
    province varchar(2),
    idcity int,
    idnation int,
    nation varchar(65),
    start datetime,
    stop datetime,
	rif_address char(1)
)

INSERT INTO #address
(
    idaddresskind,
    codeaddress,
    idreg,
    address,
    location,
    cap,
    province,
    idcity,
    idnation,
    nation,
    start,
    stop
)
SELECT
    idaddresskind,
    codeaddress,
    idreg,
    registryaddress.address,
    ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
    registryaddress.cap,
    geo_country.province,
    registryaddress.idcity,
    CASE
        WHEN flagforeign = 'N' THEN 1
        ELSE geo_nation.idnation
    END,
    CASE
        WHEN flagforeign = 'N' THEN 'ITALIA'
        ELSE geo_nation.title
    END,
    registryaddress.start,
    registryaddress.stop
FROM registryaddress
LEFT OUTER JOIN geo_city
    ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
    ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
    ON geo_nation.idnation = registryaddress.idnation
JOIN  address
    ON address.idaddress = registryaddress.idaddresskind
WHERE
registryaddress.active <>'N'
    AND registryaddress.start =
    (SELECT MAX(cdi.start)
    FROM registryaddress cdi
    WHERE cdi.idaddresskind = registryaddress.idaddresskind
        AND cdi.active <>'N'
        AND ((cdi.stop IS NULL) OR (cdi.stop >= @dateindi))
        AND cdi.idreg = registryaddress.idreg)
       
        AND idreg IN (SELECT DISTINCT idreg FROM #Anagrafiche)
   
 
DELETE #address
WHERE #address.idaddresskind NOT IN (@nostand, @stand)
    AND EXISTS(
        SELECT * FROM #address r2
        WHERE #address.idreg = r2.idreg
            AND (r2.idaddresskind = @stand
            OR r2.idaddresskind = @nostand)
    )

UPDATE #address SET rif_address = 'S' 
WHERE  #address.nation = 'ITALIA'
AND    #address.idaddresskind = @nostand


UPDATE #address SET rif_address = 'S' 
WHERE  #address.nation = 'ITALIA'
AND    #address.idaddresskind NOT IN (@nostand, @stand)
AND NOT  EXISTS(
        SELECT * FROM #address r2
        WHERE #address.idreg = r2.idreg AND
        r2.rif_address = 'S'
    )
	  
--select * from #address

UPDATE #address SET rif_address = 'S' 
WHERE  #address.nation = 'ITALIA'
AND    #address.idaddresskind = @nostand
 AND   EXISTS(
        SELECT * FROM #address r2
        WHERE #address.idreg = r2.idreg
            AND (r2.idaddresskind = @stand
            OR r2.idaddresskind = @nostand)
    )


-- 2. Ogni anagrafica deve avere almeno un indirizzo associato
IF EXISTS(
    (SELECT * FROM #Anagrafiche WHERE idreg NOT IN
        (SELECT DISTINCT idreg FROM #address ind)))
BEGIN
    INSERT INTO #error (message)
    (SELECT 'L''anagrafica ' + registry.title +
    + ' non ha un indirizzo valido associato '
    FROM #Anagrafiche
    join registry ON #Anagrafiche.idreg = registry.idreg
    WHERE #Anagrafiche.idreg NOT IN
        (SELECT idreg FROM #address ind)
    )
END

IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
    SELECT * FROM #error
    RETURN
END

-- IMP: I dati all’interno dello stesso tipo record devono essere ordinati per matricola.    00
-- CODICE ATENEO 70049
--000000@I@@0@00@000000@0@0000@000000@70049@15/04/2014@10.10.12@0@1@1@
--000001@I@§@72@01@000000@0@0000@057377@ROSSI@Antonio@C@@M@22/09/1972@AFRAGOLA@A064@I;@Via Monti, n. 6@80021@000;A064@@I;IT@@00000@000;0000@@0000@057377@@NP@@@Antonio.ROSSI§unina2.it@12/09/1995@07/07/2011@ADMINSYS@000000@000000@0@0@0@0@0815667023@00@@@@000@00@0@@00@@@0@@@@I@PF@@@0@@000@@@@@@@
--000002@I@@18@02@000000@0@0000@057377@01/01/1990@02/02/2222@RSSNTN72P22A064T@VIA Trento, 6 @80021@000;A064@01/01/2011@@CINECA@

-- Record 00
CREATE TABLE #RecordTesta(
-- parte comune a tutti i record
    ProgrGen    varchar(6),        -- Progressivo generale del record all’interno del file. Viene incrementato ad ogni riga del file dati. Il record di testata ha progrGen='000000'
    TipoOperazione    char(1),    -- Tipo operazione da fare sul record    ‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
    SeparatoreChr    char(1),    -- Variabile (0, 1)    Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
    TotCampi    int ,            -- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
    TipoRecord    varchar(2),        -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec varchar(6),    -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                                -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto char(1),            -- Il comparto del dipendente. Nerl record di testa vale 0
    Ruolo    varchar (4),        -- Variabile (2..4)    Il ruolo del dipendente. Nel rcord di testa assume valore  '0000'
    Matricola    varchar(6),        -- La matricola del dipendente. Nel record di testa assume valore me il valore '000000'

-- parte del Record di Testa
    Ateneo    varchar(5),            -- Codice ateneo di origine   
    Data    datetime ,            -- Data generazione record    GG/MM/AAAA
    Ora        datetime,--(8),        -- Ora generazione record    HH.MM.SS
    CodFile    char(1),            -- Solo se trattasi di un file prodotto con la funzione di CSA “Estrazione dati dipendente Trasferito” si riporta ‘T’.
                                -- CodFile= '0' va usato in tutti i casi in cui il file viene utilizzato per caricamenti “batch.    0
    InvioMatricola    char(1),    -- Indica se la matricola viene avvalorata nei vari record  oppure la si lascia al valore ‘000000’. Nel nostro caso deve valere 1
    InvioDatiAnagrafici    char(1) -- invioDatiAnagrafici. Nel nostro caso deve valere 1
)

INSERT INTO #RecordTesta(
-- parte comune a tutti i record
    TipoOperazione,
    TipoRecord,            -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec,        -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                        -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto,            -- Nel record di testa vale 0
    Ruolo,                -- Nel rcord di testa assume valore  '0000'
    Matricola,            -- Nel record di testa assume valore me il valore '000000'
    -- parte del Record di Testa
    Ateneo,                    -- Codice ateneo di origine    70049
    Data ,                    -- Data generazione record    GG/MM/AAAA
    --Ora    ,                -- Ora generazione record    HH.MM.SS
    CodFile,           
    InvioMatricola,            -- Indica se la matricola viene avvalorata nei vari record  oppure la si lascia al valore ‘000000’. Nel nostro caso deve valere 1
    InvioDatiAnagrafici        -- invioDatiAnagrafici. Nel nostro caso deve valere 1
)
SELECT
    'I',        -- Tipo Operazione
    '00',        -- TipoRec
    REPLICATE('0',6),    -- ProgrTipoRec
    '0',                -- Comparto
    REPLICATE('0',4),    -- Ruolo
    REPLICATE('0',6),    -- Matricola
    SUBSTRING(REPLICATE('0',5),1,5 - DATALENGTH(SUBSTRING(convert(varchar(5),@ateneo),1,5))) + SUBSTRING(convert(varchar(5),@ateneo),1,5),       
    -- CONVERT(varchar(10),@datagenerazione,103)    -- data, sarà formattata dopo secondo le specifiche
    @datagenerazione,
    '0',        -- CodFile
    '1',        -- InvioMatricola, vale 1, anche se le matricole sono nuove
    '1'
   
--Esempio record di testata:
--000000@I@@15@00@000000@0@0000@000000@70002@09/11/2001@11.00.00@0@1@0@
-- Esempio di record 01 dati anagrafici
--000001@I@§@72@01@000000@0@0000@057377@ROSSI@Antonio@C@@M@22/09/1972@AFRAGOLA@A064@I;@Via Monti, n. 6@80021@000;A064@@I;IT@@00000@000;0000@@0000@057377@@NP@@@Antonio.ROSSI§unina2.it@12/09/1995@07/07/2011@ADMINSYS@000000@000000@0@0@0@0@0815667023@00@@@@000@00@0@@00@@@0@@@@I@PF@@@0@@000@@@@@@@
CREATE TABLE #Record01( -- Dati anagrafici
    -- parte comune a tutti i record
    TipoOperazione    char(1),    -- Tipo operazione da fare sul record    ‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
    SeparatoreChr    char(1),     -- Variabile (0, 1)    Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
    TotCampi    int ,             -- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
    TipoRecord    varchar(2),     -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec varchar(6),      -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                                  -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto char(1),             -- Il comparto del dipendente. Nerl record di testa vale 0
    Ruolo    varchar (4),         -- Variabile (2..4)    Il ruolo del dipendente. Nel rcord di testa assume valore  '0000'
    Matricola    varchar(6),      -- La matricola del dipendente. Nel record di testa assume valore me il valore '000000'
    Cognome    varchar(10),       -- 10
    Nome    varchar(11),          -- 11
    Stato_civ     varchar(50),    -- 12 C(1)  valore codificato   
    Cognome_acq    varchar(24) ,  -- 13 
    Sesso    char(1),             -- 14 codificato
    Data_Nasc datetime,           -- 15  D(10)   
    Loc_Nasc varchar(40),         -- 16 C(40)
    Comune_Nasc     varchar(4),   -- 17 C(4) Codice catastale del comune
    Naz_Nasc    varchar(4),       -- 18 C(3) Codice nazione CSA ;  Codice ISO nazione *3* *4*
    Ind_Res        varchar(100),  -- 19 C(100) Indirizzo di residenza
    Cap_Res        varchar(5),    -- 20 C(5)
    Cap_Res_Progr varchar(3),
    Cd_Catasto_Res    varchar(4), -- 21  C(3) - C(4) Progressivo CAP di CSA ; Codice catastale del comune *3* *4*
    Tel_Res        varchar(25),   -- 22  C(25) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Nazionalita    varchar(4),    -- 23  C(3) Codice nazione CSA;Codice ISO nazione 
    Ind_Rif        varchar(100),  -- 24  C(100) Indirizzo di riferimento
    Cap_Rif        varchar(5),    -- 25  C(5)
    Cap_Rif_Progr    varchar(3),  -- 26  C(3) C(4) Progressivo CAP di CSA ; Codice catastale del comune
    Cd_catasto_Rif varchar(4),
    Tel_Rif     varchar(25),      -- 27  C(25) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Onorifico   char(4),          -- 28 C(4) Codice titolo onorifico 
    Matricola_Sp varchar(6),	  -- 29 C(6)
    Badge         varchar(10),    -- 30 C(10)
    Cat_Protetta varchar(2),	  -- 31 C(2) Codice categoria protetta 
    Nota         varchar(250),    -- 32 C(250)
    Data_Ass_Pubb datetime,       -- 33 D(10)
    E_Mail    varchar(100),       -- 34 C(100)
    Data_Ins datetime,            -- 35 D(10)
    Data_Mod datetime,            -- 36 D(10)
    Operatore    varchar(10),     -- 37 C(10)
	ASL_Res        varchar(6),    -- 38 C(6) 
    ASL_Rif        varchar(6),    -- 39 C(6) 
    F_Esonero_Obbligo_Res char(1),			--	40 C(1)
    Perc_Cat_Protetta    int,		--	41
    Addetto_Primo_Soccorso    char(1),		--	C(1) 42
    Addetto_Prev_Incendi    char(1),        --	43 C(1)
    Tel_Interno        varchar(25),			--	44 C(25)
    Doc_Rif_Tipo    varchar(2),				--	45 C(2)
    Doc_Rif_Numero    varchar(10),			--	46 C(20)
    Doc_Rif_Data_Rilascio datetime,			--	47 D(10)
    Doc_Rif_Ente_Rilascio    varchar(100),	--	48 C(100)
    Ordine_professionale    varchar(3),		--  49 C(3) Non valorizzato se dati estratti da U-Gov (vedi record 53) *4*
    Ordine_Professionale_Prov varchar(2),	--  50 C(2) Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Cat_Protetta_F_Assunzione    char(1),	--  51
    Cat_Protetta_Dal datetime,				--	52 D(10)
    Ordine_Professionale_Regione  varchar(2),	--  53  C(2) Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Ordine_Professionale_Num varchar(8),		--	54  C(8) numero di iscrizione all’ordine professionale Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Ordine_Professionale_Data datetime,			--	55 D(10) data di iscrizione all’ordine professionale Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Addetto_Divieto_Fumo char(1),				--	56 C(1)
    Fax varchar(25),							--	57   C(25)  Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Url varchar(150),							--  58 C(150) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    E_Mail_Privata varchar(100),				--	59 C(100) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Lingua char(1),								--	C(1)60  Lingua per cedolino/matricolare I = Italiano / T = Tedesco
    Tipo_Anagrafica varchar(10),				--  61 C(10) Di norma usare sempre ‘PF’ PF persona fisica DI ditta individuale SC soggetto collettivo
    Part_Iva varchar(11),						--	62 C(11) indicare se TIPO_ANAGRAFICA <> ‘PF’
    Denominazione varchar(255),					--	63   indicare se TIPO_ANAGRAFICA <> ‘PF’ 
    Permesso_Soggiorno_Stato    char(1),		--  64    C(1) Se non significativo indicare ‘0’
    Permesso_Soggiorno_Num_Doc    varchar(15),	--	65 C(15)
    Permesso_Soggiorno_Motivo    varchar(10),	--	66 C(10)   Se non significativo indicare @@
    Permesso_Soggiorno_Data_In datetime,		--	67 D(10)
    Permesso_Soggiorno_Data_Fin    datetime,    --	68 D(10)
    Permesso_Soggiorno_Note     varchar(255),   --	69 C(255)
    Permesso_Soggiorno_Data_Pres datetime,		--	70 D(10)
    Permesso_Soggiorno_Questura varchar(5),		--	71 C(5)   Se non significativoindicare @@
    Ordine_Professionale_Data_Fin datetime		--	72 D(10) (AC01_PER_ORDPROF.DT_FINE_ALBO in ambiente UGov) Non valorizzato se dati estratti da U-Gov (vedi record 53)
)
--000001@I@§@72@01@000000@0@0000@057377@ROSSI@Antonio@C@@M@22/09/1972@AFRAGOLA@A064@I;@Via Monti, n. 6@80021@000;A064@@I;IT@@00000@000;0000@@0000@057377@@NP@@@Antonio.ROSSI§unina2.it@12/09/1995@07/07/2011@ADMINSYS@000000@000000@0@0@0@0@0815667023@00@@@@000@00@0@@00@@@0@@@@I@PF@@@0@@000@@@@@@@

DECLARE @data_infinito   datetime
SET @data_infinito = '02/02/2222'

--SELECT * FROM #address
INSERT INTO #Record01
(
-- parte comune a tutti i record
   TipoOperazione,
   SeparatoreChr,     -- Variabile (0, 1)    Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
   TotCampi      ,  
   TipoRecord,            -- Tipo record (00-08; 90, 91, 92)
   ProgrTipoRec,        -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                        -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto,            -- Nel record di testa vale 0
    Ruolo,                -- Nel rcord di testa assume valore  '0000'
    Matricola,            -- Nel record di testa assume valore me il valore '000000'
    Cognome,            -- 10
    Nome,                -- 11
    Stato_civ,            -- 12 C(1)  valore codificato   
    Cognome_acq    ,        -- 13 
    Sesso,                -- 14 codificato
    Data_Nasc,            -- 15  D(10)   
    Loc_Nasc,            -- 16 C(40)
    Comune_Nasc,        -- 17 C(4) Codice catastale del comune
    Naz_Nasc,           -- 18 C(3) Codice nazione CSA ;  Codice ISO nazione *3* *4*
    Ind_Res,            -- 19 C(100) Indirizzo di residenza
    Cap_Res,            -- 20 C(5)
    Cap_Res_Progr,
    Cd_Catasto_Res,    -- 21  C(3) - C(4) Progressivo CAP di CSA ; Codice catastale del comune *3* *4*
    Tel_Res,            --22   C(25) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Nazionalita,        --23 C(3) Codice nazione CSA;Codice ISO nazione 
    Ind_Rif,            --24  C(100) Indirizzo di riferimento
    Cap_Rif    ,            --25  C(5)
    Cap_Rif_Progr,
    Cd_catasto_Rif, --26  C(3) C(4) Progressivo CAP di CSA ; Codice catastale del comune
    Tel_Rif,            --27  C(25) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Onorifico,            --28 C(4) Codice titolo onorifico 
    Matricola_Sp,        --29 C(6)
    Badge,                --30 C(10)
    Cat_Protetta,        --31 C(2) Codice categoria protetta 
    Nota,                --32 C(250)
    Data_Ass_Pubb,        --33 D(10)
    E_Mail,                --34 C(100)
    Data_Ins,            --35 D(10)
    Data_Mod,            --36 D(10)
	Operatore,            --37 C(10)
    ASL_Res,            --38 C(6) 
    ASL_Rif,            --39 C(6) 
    F_Esonero_Obbligo_Res,        --40 C(1)
    Perc_Cat_Protetta,            --41
    Addetto_Primo_Soccorso,        --C(1) 42
    Addetto_Prev_Incendi,        --43  C(1)
    Tel_Interno,                --44 C(25)
    Doc_Rif_Tipo,                --45C(2)
    Doc_Rif_Numero,                --46 C(20)
    Doc_Rif_Data_Rilascio,        --47 D(10)
    Doc_Rif_Ente_Rilascio,        --48  C(100)
    Ordine_professionale,        --49   C(3) Non valorizzato se dati estratti da U-Gov (vedi record 53) *4*
    Ordine_Professionale_Prov , --50   C(2) Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Cat_Protetta_F_Assunzione , --51
    Cat_Protetta_Dal,            --52 D(10)
    Ordine_Professionale_Regione, -- 53  C(2) Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Ordine_Professionale_Num ,      --54  C(8) numero di iscrizione all’ordine professionale Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Ordine_Professionale_Data,      --55 D(10) data di iscrizione all’ordine professionale Non valorizzato se dati estratti da U-Gov (vedi record 53)
    Addetto_Divieto_Fumo,          --56 C(1)
    Fax,                          --57  Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Url,                          --58 C(150) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    E_Mail_Privata,                  --59 C(100) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    Lingua,                          --C(1)60  Lingua per cedolino/matricolare I = Italiano / T = Tedesco
    Tipo_Anagrafica,              --61 C(10) Di norma usare sempre ‘PF’ PF persona fisica DI ditta individuale SC soggetto collettivo
    Part_Iva,                      --62 C(11) indicare se TIPO_ANAGRAFICA <> ‘PF’
    Denominazione,                  --63   indicare se TIPO_ANAGRAFICA <> ‘PF’ 
    Permesso_Soggiorno_Stato,      --64    C(1) Se non significativo indicare ‘0’
    Permesso_Soggiorno_Num_Doc,      --65  C(15)
    Permesso_Soggiorno_Motivo,    --66   C(10)   Se non significativo indicare @@
    Permesso_Soggiorno_Data_In,   --67 D(10)
    Permesso_Soggiorno_Data_Fin,  --68 D(10)
    Permesso_Soggiorno_Note,      --69 C(255)
    Permesso_Soggiorno_Data_Pres, --70 D(10)
    Permesso_Soggiorno_Questura,  --71 C(5)   Se non significativoindicare @@
    Ordine_Professionale_Data_Fin --72 D(10)
)
SELECT    
    'I',        -- Tipo Operazione
	'§',		-- Separatore
	'72',       -- TotCampi
    '01',       -- TipoRec
    A.ind-1,      -- ProgrTipoRec
    '1',        -- Comparto ??
    '0000',		-- Ruolo ??
    SUBSTRING(A.matricola,1,6),    -- Matricola da noi calcolata
    SUBSTRING(R.surname, 1,10),
    SUBSTRING(R.forename, 1,11),
    CASE idmaritalstatus 
         WHEN 1  THEN   'N' -- CELIBE
         WHEN 2  THEN   'N' -- NUBILE
         WHEN 3  THEN   'V' -- VEDOVO
         WHEN 4  THEN   'V' -- VEDOVA
         WHEN 5  THEN   'C' -- CONIUGATO
         ELSE '0' -- NON ASSEGNATO
    END,  
    SUBSTRING(R.maritalsurname,1,24) ,    -- 13 
    R.gender,     -- 14 codificato
    R.birthdate,  -- 15  D(10)   
    SUBSTRING(R.location,1,40),   -- 16 C(40)
    G.value,      -- 17 C(4) Codice catastale del comune
    'I;' +ISNULL(N1.value,'IT'),          -- 18 C(3) Codice nazione CSA ;  Codice ISO nazione *3* *4*
    ----------------------------------------------------------------
    ---------- DATI RELATIVI ALL'INDIRIZZO DI RESIDENZA ------------
    ----------------------------------------------------------------
    SUBSTRING(I.address,1,100),    -- 19 C(100) Indirizzo di residenza
    SUBSTRING(isnull(I.cap,CAP.CAP), 1, 5),        -- 20 C(5)
	ISNULL(CAP.CAP_PROGR,'000'),
    G1.value, -- -- codice catastale del comune di residenza ma deve essere preceduto da un progressivo CAP di CSA che ignoriamo
    SUBSTRING(REF.phonenumber,1,25),
	'I;' +ISNULL(N1.value,'IT'),	-- C(3) Codice nazione CSA ;  Codice ISO nazione *3* *4*
    SUBSTRING(I1.address,1,100),    -- 19 C(100) Indirizzo di riferimento (può essere solo in Italia)
    SUBSTRING(ISNULL(I1.cap,ISNULL(CAP2.CAP,'00000')), 1, 5),        -- 20 C(5)  ma deve essere seguito da un progressivo CAP di CSA che ignoriamo
    ISNULL(CAP2.CAP_PROGR,'000'),
    ISNULL(G2.value,'0000'), -- -- codice catastale del comune di riferimento
    null, -- telefono di riferimento
    '0000', --TITOLO ONORIFICO C(4)
    SUBSTRING(A.matricola,1,6), -- matricola_sp
    SUBSTRING(R.badgecode,1,10),
    'NP',---- CODICE CATEGORIA PROTETTA, CAMPO CODIFICATO AVENTE LUNGHEZZA 2  METTO NP COME DEFAULT
    SUBSTRING(CONVERT(VARCHAR,R.txt),1,250), -- NOTE
    null,
    REPLACE(SUBSTRING(REF.email,1,100),'@','§'), -- email
    @datagenerazione, -- data_ins
    null, -- data_mod
    'ImportAnag', -- operatore
    '000000', -- ASL_RES, lunghezza 6
    '000000', -- ASL_RIF, lunghezza 6
    '0', -- F_ESONERO_OBBLIGO_RES
    '0', -- PERC_CAT_PROTETTA
    '0', -- ADDETTO_PRIMO_SOCCORSO
    '0', -- ADDETTO_PREV_INCENDI
    null, -- TEL_INTERNO
    '00', -- OBBLIGATORIO DOC_RIF_TIPO C(2) *4*
    null, -- DOC_RIF_NUMERO C(20)
    null, -- DOC_RIF_DATA_RILASCIO
    null, -- DOC_RIF_ENTE_RILASCIO
    '000', -- OBBLIGATORIO ORDINE_PROFESSIONALE C(3)  *4*
    '00', -- OBBLIGATORIO ORDINE_PROFESSIONALE_PROV C(2)   *4*
    '0', -- CAT_PROTETTA_F_ASSUNZIONE C(1)
    null, -- CAT_PROTETTA_DAL D(10)
    '00', -- OBBLIGATORIO ORDINE_PROFESSIONALE_REGIONE C(2)  *4*
    null, -- ORDINE_PROFESSIONALE_NUM
    null, -- Ordine_Professionale_Data,    --55 D(10) data di iscrizione all’ordine professionale Non valorizzato se dati estratti da U-Gov (vedi record 53)
    null, -- Addetto_Divieto_Fumo,         --56 C(1)
    SUBSTRING(REF.faxnumber,1,25),         --57  Non valorizzato se dati estratti da U-Gov (vedi record 52)
    null, --Url                  --58 C(150) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    null, --E_Mail_Privata,                  --59 C(100) Non valorizzato se dati estratti da U-Gov (vedi record 52)
    'I', --Lingua,                          --C(1)60  Lingua per cedolino/matricolare I = Italiano / T = Tedesco
    CASE R.idregistryclass  ---- Tipo_Anagrafica --61 C(10) Di norma usare sempre ‘PF’ PF persona fisica DI ditta individuale SC soggetto collettivo
         WHEN 22 THEN 'PF'
         WHEN 21 THEN 'DI' -- ??, verificare perchè le ditte non sono individuali
         WHEN 23 THEN 'SC' -- chiedere a cosa corrispondono
    END,                            
    CASE  R.idregistryclass   -- Part_Iva --62 C(11) indicare se TIPO_ANAGRAFICA <> ‘PF’
        WHEN '22' THEN  NULL
        ELSE SUBSTRING(R.p_iva,1,11)
    END,                   
    CASE  R.idregistryclass      -- Part_Iva --62 C(11) indicare se TIPO_ANAGRAFICA <> ‘PF’
        WHEN '22' THEN NULL   -- Denominazione     --63   indicare se TIPO_ANAGRAFICA <> ‘PF’ 
		ELSE R.title 
	END,
    '0',    --Permesso_Soggiorno_Stato,      --64    C(1) Se non significativo indicare ‘0’
    null,   --Permesso_Soggiorno_Num_Doc,      --65  C(15)
    null,   --Permesso_Soggiorno_Motivo,      --66   C(10)   Se non significativo indicare @@
    null,    --Permesso_Soggiorno_Data_In,      --67 D(10)
    null,   --Permesso_Soggiorno_Data_Fin,  --68 D(10)
    null,   --Permesso_Soggiorno_Note,      --69 C(255)
    null,    --Permesso_Soggiorno_Data_Pres, --70 D(10)
    null,    --Permesso_Soggiorno_Questura,  --71 C(5)   Se non significativoindicare @@
    null   --Ordine_Professionale_Data_Fin --72 D(10)
FROM #Anagrafiche A
JOIN registry R ON R.idreg = A.idreg
LEFT OUTER JOIN geo_city_agency G
    ON  G.idcity = R.idcity
    AND G.idagency = 1 and G.idcode = 1
LEFT OUTER JOIN geo_nation_agency N
    ON N.idnation = R.idnation
    AND N.idagency = 6 -- ente ISO           
    AND N.idcode = 1 -- codifica nazioni ISO
    AND N.version = 1
    AND N.stop IS NULL
LEFT OUTER JOIN #address I
    ON I.idreg = A.idreg
    AND I.idaddresskind = @stand
LEFT OUTER JOIN geo_city_agency G1
    ON  G1.idcity = I.idcity
    AND G1.idagency = 1 and G1.idcode = 1
LEFT OUTER JOIN EASY_CAP  CAP
    ON  G1.value = CAP.codice_catastale
	AND I.cap =  CAP.CAP
LEFT OUTER JOIN geo_nation_agency N1 -- eventuale nazione di residenza, se estero
    ON N1.idnation = I.idnation
    AND N1.idagency = 6 -- ente ISO           
    AND N1.idcode = 1 -- codifica nazioni ISO
    AND N1.version = 1
    AND N1.stop IS NULL
LEFT OUTER JOIN registryreference REF
    ON REF.idreg = R.idreg AND REF.flagdefault = 'S' -- contatto predefinito
LEFT OUTER JOIN #address I1 -- indirizzo  predefinito ma può essere solo in Italia
    ON I1.idreg = A.idreg
	AND I.idaddresskind = @stand 
    AND I1.rif_address = 'S'
LEFT OUTER JOIN geo_city_agency G2
    ON  G2.idcity = I1.idcity
    AND G2.idagency = 1 and G2.idcode = 1
LEFT OUTER JOIN EASY_CAP  CAP2
    ON  G2.value = CAP2.codice_catastale
	AND I.cap =  CAP.CAP
LEFT OUTER JOIN title  T
    ON T.idtitle = R.idtitle
  ORDER BY A.IND

--RECORD 02
--DATA_IN 10 D(10)
--DATA_FIN 11 D(10) 02/02/2222 se infinito
--COD_FISC 12 C(16)
--DOM_FISC 13 C(100) Indirizzo domicilio fiscale
--CAP_DOM 14  C(5)
--CAP_DOM_PROGR CD_CATASTO 15 C(3) C(4) Progressivo CAP di CSA ; Codice catastale del comune
--DATA_INS 16 D(10)
--DATA_MOD 17 D(10)
--OPERATORE 18 C(10)

-- Record 02
CREATE TABLE #Record02( -- Dati fiscali
-- parte comune a tutti i record
    ProgrGen    varchar(6),        -- Progressivo generale del record all’interno del file. Viene incrementato ad ogni riga del file dati. Il record di testata ha progrGen='000000'
    TipoOperazione    char(1),     -- Tipo operazione da fare sul record    ‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
    SeparatoreChr    char(1),      -- Variabile (0, 1)    Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
    TotCampi    int ,              -- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
    TipoRecord    varchar(2),      -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec varchar(6),       -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                                   -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto char(1),              -- Il comparto del dipendente. Nerl record di testa vale 0
    Ruolo    varchar (4),          -- Variabile (2..4)    Il ruolo del dipendente. Nel rcord di testa assume valore  '0000'
    Matricola    varchar(6),       -- La matricola del dipendente. Nel record di testa assume valore me il valore '000000'
    Data_In datetime,              -- 10 D(10)
    Data_Fin datetime,             -- 11 D(10) 02/02/2222 se infinito
    Cod_FIsc varchar(16),          -- 12 C(16)
    Dom_Fisc varchar(100),         -- 13 C(100) Indirizzo domicilio fiscale
    Cap_Dom  varchar(5),           --  14  C(5)
    Cap_Dom_Progr_Cd_Catasto varchar(7), -- 15 C(3) C(4) Progressivo CAP di CSA ; Codice catastale del comune
    Data_Ins datetime,             -- 16 D(10)
    Data_Mod datetime,             -- 17 D(10)
    Operatore varchar(10)          -- 18 C(10)
)

INSERT INTO #Record02
(
-- parte comune a tutti i record
    TipoOperazione,
    TipoRecord,          -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec,        -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                        -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto,            -- Nel record di testa vale 0
    Ruolo,                -- Nel rcord di testa assume valore  '0000'
    Matricola,            -- Nel record di testa assume valore me il valore '000000'
    Data_In,            -- 10 D(10)
    Data_Fin,            -- 11 D(10) 02/02/2222 se infinito
    Cod_FIsc,            -- 12 C(16)
    Dom_Fisc,            -- 13 C(100) Indirizzo domicilio fiscale
    Cap_Dom,            -- 14  C(5)
    Cap_Dom_Progr_Cd_Catasto, --  15 C(3) C(4) Progressivo CAP di CSA ; Codice catastale del comune
    Data_Ins,            -- 16 D(10)
    Data_Mod,            -- 17 D(10)
    Operatore            -- 18 C(10)
    )
SELECT
    'I',        -- Tipo Operazione
    '02',        -- TipoRec
    A.ind-1,        -- ProgrTipoRec
    '1',                -- Comparto ??
    'PE',    -- Ruolo ??
    SUBSTRING(A.matricola,1,6),    -- Matricola
    ISNULL(I.start,I1.start) ,
    ISNULL(I.STOP,ISNULL(I1.STOP,@data_infinito)),
    R.cf,
    SUBSTRING(ISNULL(I.address,I1.address),1,100),
    SUBSTRING(ISNULL(I.cap,ISNULL(I1.cap,'00000')), 1, 5),        
    ISNULL(G.value,G1.value),
    @datagenerazione,
    null,
    null
FROM #Anagrafiche A
JOIN registry R ON R.idreg = A.idreg
LEFT OUTER JOIN #address I
    ON I.idreg = A.idreg
    AND I.idaddresskind = @nostand
    AND I.idcity is not null
LEFT OUTER  JOIN #address I1
    ON I1.idreg = A.idreg
    AND I1.idaddresskind = @stand
    AND I1.idcity is not null
LEFT OUTER JOIN geo_city_agency G
    ON  G.idcity = I.idcity
    AND G.idagency = 1 and G.idcode = 1
LEFT OUTER JOIN geo_city_agency G1
    ON  G1.idcity = I1.idcity
    AND G1.idagency = 1 and G1.idcode = 1



   
-- Tabella di output
CREATE TABLE #tracciato(
    --ProgGen int identity(0,1),
    TipoRecord    varchar(2),        -- Tipo record (00-01-02)
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
    +'@'+ --> SeparatoreChr    char(1) Non mettiamo nulla, è come se avesse lunghezza 0
    +'@'+ convert (varchar(2),15)-- Tot. Campi
    +'@'+ TipoRecord
    +'@'+ ProgrTipoRec
    +'@'+ Comparto
    +'@'+ Ruolo   
    +'@'+ Matricola   
-- parte del Record di Testa
    +'@'+ Ateneo --> Al momento è posto come parametro di input DA FARE!!!
    -- Data generazione record    GG/MM/AAAA
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
        CONVERT(varchar(2),DATEPART(ss,@datagenerazione))+    --'.'+
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
     '@'+ 
	TipoOperazione
    +'@'+ 
	SeparatoreChr     
    +'@'+ 
	'72'   -- TotCampi   
    +'@'+ 
	TipoRecord
    +'@'+ 
	SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6))) + SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6)
    +'@'+ 
	isnull(Comparto,'1')
    -- Ruolo    varchar (4),        -- Variabile (2..4)    Il ruolo del dipendente. Nel record di testa assume valore  '0000'
    +'@'+ 
	isnull(Ruolo,'0000')
    -- Matricola    vachar(6)        --    La matricola del dipendente. Nel record di testa assume valore me il valore '000000'
    +'@'
	+ SUBSTRING(REPLICATE('0',6),1,6 - ISNULL(DATALENGTH(SUBSTRING(isnull(Matricola,''),1,6)),0)) + SUBSTRING(isnull(Matricola,''),1,6)

-- parte del record 01
    +'@'
	+ 
	CASE WHEN cognome is null    THEN  '@' ELSE cognome + '@' END + 
	CASE WHEN nome is null    THEN  '@' ELSE nome + '@' END + 
	CASE WHEN stato_civ is null    THEN  '@' ELSE stato_civ + '@' END + 
	CASE WHEN cognome_acq is null    THEN  '@' ELSE cognome_acq + '@' END + 
	CASE WHEN sesso is null    THEN  '@' ELSE sesso + '@' END + 
 
     SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(data_nasc)))) +
        CONVERT(varchar(2),DAY(data_nasc)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(data_nasc)))) +
        CONVERT(varchar(2),MONTH(data_nasc))+'/'+
        +CONVERT(varchar(4),YEAR(data_nasc)) +'@'+

	CASE WHEN loc_nasc is null    THEN  '@' ELSE loc_nasc + '@' END + 
	CASE WHEN comune_nasc is null    THEN  '@' ELSE comune_nasc + '@' END + 
	CASE WHEN naz_nasc is null    THEN  '@' ELSE naz_nasc + '@' END + 
	CASE WHEN ind_res is null    THEN  '@' ELSE ind_res + '@' END + 
	CASE WHEN cap_res is null    THEN  '@' ELSE cap_res + '@' END + 
	CASE WHEN cap_res_progr is null    THEN  '@' ELSE cap_res_progr + ';' END + 
	CASE WHEN Cd_Catasto_Res is not null    THEN   Cd_Catasto_Res + '@' END + 
	CASE WHEN tel_res is null    THEN  '@' ELSE tel_res + '@' END + 
	CASE WHEN nazionalita is null    THEN  '@' ELSE nazionalita + '@' END + 
	CASE WHEN ind_rif is null    THEN  '@' ELSE ind_rif + '@' END + 
	CASE WHEN cap_rif is null    THEN  '@' ELSE cap_rif + '@' END + 
	CASE WHEN cap_rif_progr is null    THEN  '@' ELSE cap_rif_progr + ';' END + 
	CASE WHEN Cd_catasto_Rif is not null    THEN  Cd_catasto_Rif + '@' END + 
	CASE WHEN tel_rif is null    THEN  '@' ELSE tel_rif + '@' END + 
	CASE WHEN onorifico is null    THEN  '@' ELSE onorifico + '@' END + 
	CASE WHEN matricola_sp is null    THEN  '@' ELSE matricola_sp + '@' END + 
	CASE WHEN badge is null    THEN  '@' ELSE badge + '@' END + 
	CASE WHEN cat_protetta is null    THEN  '@' ELSE cat_protetta + '@' END + 
	CASE WHEN nota is null    THEN  '@' ELSE nota + '@' END + 
	CASE WHEN data_ass_pubb is null    THEN  '@' ELSE   SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(data_ass_pubb)))) +
        CONVERT(varchar(2),DAY(data_ass_pubb)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(data_ass_pubb)))) +
        CONVERT(varchar(2),MONTH(data_ass_pubb))+'/'+
        +CONVERT(varchar(4),YEAR(data_ass_pubb)) + '@' END + 

	CASE WHEN e_mail is null    THEN  '@' ELSE e_mail + '@' END + 

	CASE WHEN data_ins is null    THEN  '@' ELSE SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(data_ins)))) +
        CONVERT(varchar(2),DAY(data_ins)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(data_ins)))) +
        CONVERT(varchar(2),MONTH(data_ins))+'/'+
        +CONVERT(varchar(4),YEAR(data_ins)) + '@' END + 

	CASE WHEN data_mod is null    THEN  '@' ELSE CONVERT(VARCHAR(10),data_mod) + '@' END + 
	'ImportAnagr'   +'@'+
	CASE WHEN asl_res is null    THEN  '@' ELSE asl_res + '@' END + 
	CASE WHEN asl_rif is null    THEN  '@' ELSE asl_rif + '@' END + 
	CASE WHEN f_esonero_obbligo_res is null    THEN  '@' ELSE f_esonero_obbligo_res + '@' END + 
	CASE WHEN perc_cat_protetta is null    THEN  '@' ELSE CONVERT(VARCHAR(10),perc_cat_protetta) + '@' END + 
	CASE WHEN addetto_primo_soccorso is null    THEN  '@' ELSE  addetto_primo_soccorso + '@' END + 
	CASE WHEN addetto_prev_incendi is null    THEN  '@' ELSE  addetto_prev_incendi + '@' END + 
	CASE WHEN tel_interno is null    THEN  '@' ELSE  tel_interno + '@' END + 
	CASE WHEN doc_rif_tipo is null    THEN  '@' ELSE  doc_rif_tipo + '@' END + 
	CASE WHEN doc_rif_numero is null    THEN  '@' ELSE  doc_rif_numero + '@' END + 
	CASE WHEN doc_rif_data_rilascio is null    THEN  '@' ELSE   SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(doc_rif_data_rilascio)))) +
        CONVERT(varchar(2),DAY(doc_rif_data_rilascio)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(doc_rif_data_rilascio)))) +
        CONVERT(varchar(2),MONTH(doc_rif_data_rilascio))+'/'+
        +CONVERT(varchar(4),YEAR(doc_rif_data_rilascio)) + '@' END  + 
	CASE WHEN doc_rif_ente_rilascio is null    THEN  '@' ELSE  doc_rif_ente_rilascio + '@' END + 
 	CASE WHEN ordine_professionale is null    THEN  '@' ELSE  ordine_professionale + '@' END + 
	CASE WHEN ordine_professionale_prov is null    THEN  '@' ELSE  ordine_professionale_prov + '@' END + 
	CASE WHEN cat_protetta_f_assunzione is null    THEN  '@' ELSE  cat_protetta_f_assunzione + '@' END + 

	CASE WHEN cat_protetta_dal is null    THEN  '@' ELSE SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(cat_protetta_dal)))) +
        CONVERT(varchar(2),DAY(cat_protetta_dal)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(cat_protetta_dal)))) +
        CONVERT(varchar(2),MONTH(cat_protetta_dal))+'/'+
        +CONVERT(varchar(4),YEAR(cat_protetta_dal)) + '@' END  + 

	CASE WHEN ordine_professionale_regione is null    THEN  '@' ELSE ordine_professionale_regione + '@' END +
	CASE WHEN ordine_professionale_num is null    THEN  '@' ELSE ordine_professionale_num + '@' END +
	CASE WHEN ordine_professionale_data is null    THEN  '@' ELSE SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(ordine_professionale_data)))) +
        CONVERT(varchar(2),DAY(ordine_professionale_data)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(ordine_professionale_data)))) +
        CONVERT(varchar(2),MONTH(ordine_professionale_data))+'/'+
        +CONVERT(varchar(4),YEAR(ordine_professionale_data)) + '@' END  + 

	CASE WHEN addetto_divieto_fumo is null    THEN  '@' ELSE addetto_divieto_fumo + '@' END +
	CASE WHEN fax is null    THEN  '@' ELSE fax + '@' END +
    CASE WHEN url is null    THEN  '@' ELSE url + '@' END +
	CASE WHEN e_mail_privata is null    THEN  '@' ELSE e_mail_privata + '@' END +
	CASE WHEN lingua is null    THEN  '@' ELSE lingua + '@' END +
	CASE WHEN tipo_anagrafica is null    THEN  '@' ELSE tipo_anagrafica + '@' END +
	CASE WHEN part_iva is null    THEN  '@' ELSE part_iva + '@' END +
	CASE WHEN denominazione is null    THEN  '@' ELSE denominazione + '@' END +
	CASE WHEN permesso_soggiorno_stato is null    THEN  '@' ELSE permesso_soggiorno_stato + '@' END +
	CASE WHEN permesso_soggiorno_num_doc is null  THEN  '@' ELSE permesso_soggiorno_num_doc + '@' END +
	CASE WHEN permesso_soggiorno_motivo is null   THEN  '@' ELSE permesso_soggiorno_motivo + '@' END +
	CASE WHEN permesso_soggiorno_data_in is null  THEN  '@' ELSE SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(permesso_soggiorno_data_in)))) +
        CONVERT(varchar(2),DAY(permesso_soggiorno_data_in)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(permesso_soggiorno_data_in)))) +
        CONVERT(varchar(2),MONTH(permesso_soggiorno_data_in))+'/'+
        +CONVERT(varchar(4),YEAR(permesso_soggiorno_data_in)) + '@' END  + 

	CASE WHEN permesso_soggiorno_data_fin is null THEN  '@' ELSE SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(permesso_soggiorno_data_fin)))) +
        CONVERT(varchar(2),DAY(permesso_soggiorno_data_fin)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(permesso_soggiorno_data_fin)))) +
        CONVERT(varchar(2),MONTH(permesso_soggiorno_data_fin))+'/'+
        +CONVERT(varchar(4),YEAR(permesso_soggiorno_data_fin)) + '@' END  + 

	CASE WHEN permesso_soggiorno_note is null	  THEN  '@' ELSE permesso_soggiorno_note + '@' END +
	CASE WHEN permesso_soggiorno_data_pres is null THEN  '@' ELSE 
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(permesso_soggiorno_data_pres)))) +
        CONVERT(varchar(2),DAY(permesso_soggiorno_data_pres)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(permesso_soggiorno_data_pres)))) +
        CONVERT(varchar(2),MONTH(permesso_soggiorno_data_pres))+'/'+
        +CONVERT(varchar(4),YEAR(permesso_soggiorno_data_pres)) + '@' END  +

	CASE WHEN permesso_soggiorno_questura is null	  THEN  '@' ELSE permesso_soggiorno_questura + '@' END +
 	CASE WHEN ordine_professionale_data_fin is null THEN  '@' ELSE 
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(ordine_professionale_data_fin)))) +
        CONVERT(varchar(2),DAY(ordine_professionale_data_fin)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(ordine_professionale_data_fin)))) +
        CONVERT(varchar(2),MONTH(ordine_professionale_data_fin))+'/'+
        +CONVERT(varchar(4),YEAR(ordine_professionale_data_fin)) + '@' END  
FROM #Record01



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
    +'@'+ --> SeparatoreChr    char(1) Non mettiamo nulla, è come se avesse lunghezza 0
    +'@'+ '18' +  -- TotCampi   
    +'@'+ TipoRecord
    +'@'+ SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6))) + SUBSTRING(convert(varchar(6),ProgrTipoRec),1,6)
    +'@'+ Comparto
    -- Ruolo    varchar (4),        -- Variabile (2..4)    Il ruolo del dipendente. Nel record di testa assume valore  '0000'
    +'@'+ isnull(Ruolo,'0000')
    -- Matricola    vachar(6)        --    La matricola del dipendente. Nel record di testa assume valore me il valore '000000'
    +'@'+ SUBSTRING(REPLICATE('0',6),1,6 - ISNULL(DATALENGTH(SUBSTRING(isnull(Matricola,''),1,6)),0)) + SUBSTRING(isnull(Matricola,''),1,6)

-- parte del Record 02
    +'@'+ 
		CASE WHEN Data_In is null THEN  '@' ELSE 
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(Data_In)))) +
        CONVERT(varchar(2),DAY(Data_In)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(Data_In)))) +
        CONVERT(varchar(2),MONTH(Data_In))+'/'+
        +CONVERT(varchar(4),YEAR(Data_In)) + '@' END  + 
		CASE WHEN Data_Fin is null THEN  '@' ELSE 
		SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(Data_Fin)))) +
        CONVERT(varchar(2),DAY(Data_Fin)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(Data_Fin)))) +
        CONVERT(varchar(2),MONTH(Data_Fin))+'/'+
        +CONVERT(varchar(4),YEAR(Data_Fin)) + '@' END  + 
		CASE WHEN Cod_FIsc is null    THEN  '@' ELSE Cod_FIsc + '@' END +
		CASE WHEN Dom_Fisc is null    THEN  '@' ELSE Dom_Fisc + '@' END +
		CASE WHEN Cap_Dom is null     THEN  '@' ELSE Cap_Dom + '@' END +	
 		CASE WHEN Cap_Dom_Progr_Cd_Catasto is null     THEN  '@' ELSE Cap_Dom_Progr_Cd_Catasto + '@' END +	
		CASE WHEN Data_Ins is null THEN  '@' ELSE 
	    SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(Data_Ins)))) +
        CONVERT(varchar(2),DAY(Data_Ins)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(Data_Ins)))) +
        CONVERT(varchar(2),MONTH(Data_Ins))+'/'+
        +CONVERT(varchar(4),YEAR(Data_Ins))+ '@' END  +   
		CASE WHEN Data_Mod is null THEN  '@' ELSE 
	    SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(Data_Mod)))) +
        CONVERT(varchar(2),DAY(Data_Mod)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(Data_Mod)))) +
        CONVERT(varchar(2),MONTH(Data_Mod))+'/'+
        +CONVERT(varchar(4),YEAR(Data_Mod))+ '@' END  + 
		'ImportAnagr'+ 
		'@'
FROM #Record02

-- CONCATENA I RECORD 01 E RECORD 02
 
CREATE TABLE #tracciato_finale(
    TipoRecord    varchar(2), -- Tipo record (00-01-02) 
    stringa varchar(600) COLLATE SQL_Latin1_General_CP1_CI_AS
)

INSERT INTO #tracciato_finale
SELECT
    TipoRecord,
	stringa as out_str
FROM #tracciato
ORDER BY Matricola, TipoRecord, ProgrTipoRec

--DECLARE @TipoRecord varchar(2)
--DECLARE @TipoRecordPrec varchar(2)
--DECLARE @StringaRecord varchar(600)
--DECLARE @StringaFinale_01 varchar(4000)
--DECLARE @StringaFinale_02 varchar(4000)

--DECLARE rowcursor INSENSITIVE CURSOR FOR
--SELECT tiporecord,  stringa
--FROM #tracciato
--WHERE tiporecord IN ('01','02')
--ORDER BY TipoRecord,ProgrTipoRec
--FOR READ ONLY

--OPEN rowcursor
--FETCH NEXT FROM rowcursor
--INTO @TipoRecord, @StringaRecord
--WHILE @@FETCH_STATUS = 0
--BEGIN 
--	IF (@TipoRecord = '01')
--	BEGIN
--		IF (@StringaFinale_01 IS NULL)  SET @StringaFinale_01 = @StringaRecord
--		ELSE SET @StringaFinale_01 = @StringaFinale_01 + @StringaRecord
--	END
--	ELSE
--	BEGIN
--		IF (@StringaFinale_02 IS NULL)  SET @StringaFinale_02 = @StringaRecord
--		ELSE SET @StringaFinale_02 = @StringaFinale_02 + @StringaRecord
--	END

--	FETCH NEXT FROM rowcursor
--	INTO @TipoRecord, @StringaRecord
--END 
--INSERT INTO #tracciato_finale (TipoRecord, stringa) SELECT '00', stringa FROM #tracciato WHERE TipoRecord = '00'
--INSERT INTO #tracciato_finale (TipoRecord, stringa) SELECT '01', @StringaFinale_01
--INSERT INTO #tracciato_finale (TipoRecord, stringa) SELECT '02', @StringaFinale_02
--DEALLOCATE rowcursor


-- tabella dove memorizziamo la matricola ultima trovata, serve nel caso dobbiamo annullare l'update che noi facciamo
-- registry qualora l'importazione non sia andata a buon fine
         --create table importAnagrRecord8000
 
 ---------------------------------------------------------------
 ---------------  PER IL MOMENTO COMMENTIAMO -------------------
 ---------------------------------------------------------------
UPDATE  registry
SET        extmatricula = matricola, lu = 'ImportAnagr' + Convert(varchar(30),GetDate())
FROM    #Anagrafiche
WHERE   #Anagrafiche.idreg = registry.idreg

INSERT INTO importAnagrRecord8000 (kind, lastmatr, ct, cu,lt,lu)
VALUES
('A',@maxmatriculacsa_A, GetDate(),'ImportAnagr',GetDate(),'ImportAnagr')

INSERT INTO importAnagrRecord8000 (kind, lastmatr, ct, cu,lt,lu)
VALUES
('D',@maxmatriculacsa_D, GetDate(),'ImportAnagr',GetDate(),'ImportAnagr')

 
 ---------------------------------------------------------------
 ---------------  FINE COMMENTO --------------------------------
 ---------------------------------------------------------------
ALTER TABLE #tracciato_finale  ADD ProgGen INT IDENTITY(0,1)
SELECT
    SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),ProgGen),1,6))) + SUBSTRING(convert(varchar(6),ProgGen),1,6)
    + stringa as out_str
FROM #tracciato_finale
ORDER BY  ProgGen

END
GO
 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
