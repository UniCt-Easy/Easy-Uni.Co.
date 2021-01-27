
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_record08_verifica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_record08_verifica]
GO


/****** Object:  StoredProcedure [amministrazione].[exp_interscambio_csa_record08_verifica]    Script Date: 11/26/2014 11:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [exp_interscambio_csa_record08_verifica]
(
	@datagenerazione datetime,
	@ayear int,
	@ateneo varchar(5),
	@ente varchar(10),
	@start datetime,
	@stop datetime,
	@extmatricula varchar(40),
	@mask int   
)
 
/*	
	Esportazione per Napoli2 Vincenzo Boemio 
	Creare a partire da exp_interscambio_csa_record08
	Gianni 25/11/2014
*/

-- exec exp_interscambio_csa_record08 {ts '2014-12-31 01:02:03'} ,2014, '70049', 'U00003',{ts '2014-01-01 01:02:03'},{ts '2014-12-31 01:02:03'},null, 2
-- exec exp_interscambio_csa_record08 {ts '2011-12-31 01:02:03'} ,2011, '70049', 'U00003',{ts '2011-01-01 01:02:03'},{ts '2011-12-31 01:02:03'}, 2
-- exec exp_interscambio_csa_record08 {ts '2012-12-31 01:02:03'} ,2012, '70049', 'U00003',{ts '2012-01-01 01:02:03'},{ts '2012-12-31 01:02:03'},'3'
-- exec exp_interscambio_csa_record08 {ts '2013-12-31 01:02:03'} ,2013, '70049', 'U00003',{ts '2013-01-01 01:02:03'},{ts '2013-12-31 01:02:03'},'4'

AS 
 
BEGIN

IF @mask IS NULL RETURN

DECLARE @annoredditi int
SET @annoredditi = @ayear


CREATE TABLE #Compensi(
		departmentname varchar(500),
		reference varchar(60),-- iddb(50) + idexp(10)
		idregistrylegalstatus int,
		voce8000 varchar(4),
		voce8000refund_i varchar(4),
		voce8000refund_e varchar(4),
		capitolo varchar(20),
		importo decimal(19,2),
		idreg int,
		csa_compartment char(1),
		csa_role varchar(4), 
		extmatricula varchar(40),
		ymov int,
		nmov int,
		transmissiondate datetime,
		codeser varchar(20),
		service varchar(50),
		itinerationvisible char(1)
		)
 
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
			where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.exp_interscambio_compensi_csa'

		INSERT INTO #Compensi(
				idreg,
				csa_role,
				csa_compartment,
				extmatricula,
				departmentname,
				reference,
				voce8000,
				voce8000refund_i,
				voce8000refund_e,
				capitolo,
				importo,
				ymov,
				nmov,
				transmissiondate,
				codeser,
				service,
				itinerationvisible 
		)
		exec @dip_nomesp 	@datagenerazione, @ayear, @start, @stop, @extmatricula, @mask
		fetch next from @crsdepartment into @iddbdepartment
	
	END
	
	-- Record 00
CREATE TABLE #RecordTesta(
-- parte comune a tutti i record
    ProgrGen    varchar(6),        -- Progressivo generale del record all’interno del file. Viene incrementato ad ogni riga del file dati. Il record di testata ha progrGen='000000'
    TipoOperazione    char(1),     -- Tipo operazione da fare sul record    ‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
    SeparatoreChr    char(1),      -- Variabile (0, 1)    Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
    TotCampi    int ,              -- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
    TipoRecord    varchar(2),      -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec varchar(6),	   -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                                   -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto char(1),              -- Il comparto del dipendente. Nerl record di testa vale 0
    Ruolo    varchar (4),          -- Variabile (2..4)    Il ruolo del dipendente. Nel rcord di testa assume valore  '0000'
    Matricola    varchar(6),       -- La matricola del dipendente. Nel record di testa assume valore me il valore '000000'

-- parte del Record di Testa
    Ateneo    varchar(5),          -- Codice ateneo di origine  
    Data    datetime ,             -- Data generazione record    GG/MM/AAAA
    Ora        datetime,--(8),     -- Ora generazione record    HH.MM.SS
    CodFile    char(1),            -- Solo se trattasi di un file prodotto con la funzione di CSA “Estrazione dati dipendente Trasferito” si riporta ‘T’.
                                   -- CodFile= '0' va usato in tutti i casi in cui il file viene utilizzato per caricamenti “batch.    0
    InvioMatricola    char(1),     -- Indica se la matricola viene avvalorata nei vari record  oppure la si lascia al valore ‘000000’. Nel nostro caso deve valere 1
    InvioDatiAnagrafici    char(1) -- invioDatiAnagrafici. Nel nostro caso deve valere 1
)

INSERT INTO #RecordTesta(
-- parte comune a tutti i record
    TipoOperazione,
    TipoRecord,					  -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec,				  -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                                  -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto,					  -- Nel record di testa vale 0
    Ruolo,						  -- Nel rcord di testa assume valore  '0000'
    Matricola,					  -- Nel record di testa assume valore me il valore '000000'
    -- parte del Record di Testa
    Ateneo,                       -- Codice ateneo di origine    70049
    Data ,                        -- Data generazione record    GG/MM/AAAA
    --Ora    ,                    -- Ora generazione record    HH.MM.SS
    CodFile,          
    InvioMatricola,               -- Indica se la matricola viene avvalorata nei vari record  oppure la si lascia al valore ‘000000’. Nel nostro caso deve valere 1
    InvioDatiAnagrafici           -- invioDatiAnagrafici. Nel nostro caso deve valere 1
)
SELECT
    'I',						 -- Tipo Operazione
    '00',						 -- TipoRec
    REPLICATE('0',6),			 -- ProgrTipoRec
    '0',						 -- Comparto
    REPLICATE('0',4),			 -- Ruolo
    REPLICATE('0',6),			 -- Matricola
    SUBSTRING(REPLICATE('0',5),1,5 - DATALENGTH(SUBSTRING(convert(varchar(5),@ateneo),1,5))) + SUBSTRING(convert(varchar(5),@ateneo),1,5),      
    -- CONVERT(varchar(10),@datagenerazione,103)    -- data, sarà formattata dopo secondo le specifiche
    @datagenerazione,
    '0',						 -- CodFile
    '1',						 -- InvioMatricola, vale 1, anche se le matricole sono nuove
    '0'
	
	-- Record 08
CREATE TABLE #Record08(
-- parte comune a tutti i record
    ProgrGen    varchar(6),			-- Progressivo generale del record all’interno del file. Viene incrementato ad ogni riga del file dati. Il record di testata ha progrGen='000000'
    TipoOperazione    char(1),		-- Tipo operazione da fare sul record    ‘I’:  inserimento;’M’:modifica;'C': cancellazione. Assume valore 0 nel record di testa
    SeparatoreChr    char(1),		-- Variabile (0, 1)    Nel caso in cui nei dati da caricare in questa riga sia presente almeno un carattere '@'(separatore) è necessario sostituire '@' con '§'.
    TotCampi    int ,				-- Per ogni riga, indica il numero totale dei campi contenuti. Tale numero corrisponde esattamente al numero totale dei caratteri ‘@’.
    TipoRecord    varchar(2),       -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec varchar(6),		-- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
									-- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto char(1),				-- Il comparto del dipendente. Nerl record di testa vale 0
    Ruolo    varchar (4),			-- Variabile (2..4)    Il ruolo del dipendente. Nel rcord di testa assume valore  '0000'
    Matricola    varchar(6),        -- La matricola del dipendente. Nel record di testa assume valore me il valore '000000'

-- parte del Record 08 - PARTI VARIABILI
	Valido char(1), 
    Anno_Comp_Liq int,
    Mese_Comp_Liq int,
    Voce varchar(5),
    Progressivo varchar(2), -- Vedi convenzione su “Progressivo”
	Data_Comp_Voce datetime,
	Stato_Voce char(1),
	Provvedimento varchar(9),
	Aliquota  int, --decimal(19,5),
	Parti int, --decimal (10,3),
	Importo decimal(19,2),
	Tipo_Importo char(1),
	Importo_Convertito int, -- decimal(18,6),
	Divisa char(1),
	Ente varchar(6),
	Capitolo varchar(6),
	Oggetto Varchar(50),
	Nota varchar(1036),
	Rif_Liquidazione datetime,
	Riferimento varchar(30),
	Data_Ins datetime,
	Data_Mod datetime,
	Operatore varchar(10),
	Rif_Voce varchar(10),
	F_Adempimenti char(1)
)

INSERT INTO #Record08(
-- parte comune a tutti i record
    TipoOperazione,
    TipoRecord,         -- Tipo record (00-08; 90, 91, 92)
    ProgrTipoRec,       -- Il progressivo all’interno del tipo record. Viene incrementato ad ogni riga all’interno dello stesso tipo record e si azzera ad ogni cambio di tipo record.
                        -- Si azzera comunque al cambio di ogni matricola.    Inizia da 000000 fino a 999999
    Comparto,           -- Nel record di testa vale 0
    Ruolo,              -- Nel rcord di testa assume valore  '0000'
    Matricola,          -- Nel record di testa assume valore me il valore '000000'
    -- parte del Record 08
   	Valido, 
    Anno_Comp_Liq,
    Mese_Comp_Liq,
    Voce,
    Progressivo, -- Vedi convenzione su “Progressivo”
	Data_Comp_Voce,
	Stato_Voce,
	Provvedimento,
	Aliquota,
	Parti,
	Importo,
	Tipo_Importo,
	Importo_Convertito,
	Divisa,
	Ente,
	Capitolo,
	Oggetto,
	Nota,
	Rif_Liquidazione,
	Riferimento,
	Data_Ins,
	Data_Mod,
	Operatore,
	Rif_Voce,
	F_Adempimenti
)
SELECT
    'I',     -- Tipo Operazione
    '08',    -- TipoRec
    REPLICATE('0',6),   -- ProgrTipoRec
    ISNULL(csa_compartment,'0'),                -- Comparto
    ISNULL(csa_role,REPLICATE('0',4)),   -- Ruolo
    SUBSTRING(ISNULL(extmatricula,REPLICATE('0',6)),1,6),   -- Matricola
	null, 
    YEAR(transmissiondate),
    MONTH(transmissiondate),
    COALESCE(voce8000,voce8000refund_i,voce8000refund_e),
    '00', -- Vedi convenzione su “Progressivo”
	transmissiondate,
	'E',
	'000000000',
	0,
	0,
	importo,
	'0',
	0,
	'E',
	@ente,
	--CASE
	--	WHEN (@kind = 'I' AND  voce8000refund_i IS NULL AND voce8000refund_e IS NULL) THEN '017212'
	--	WHEN  voce8000refund_i IS NOT NULL THEN '017209'
	--	WHEN  voce8000refund_e IS NOT NULL THEN '017210' 
	--	ELSE null
	--END,
	capitolo,
	'000000',
	null,
	null,
	null,
	null,
	null,
	null,
	null,
	CASE csa_role
		WHEN 'NC' THEN '2'
		WHEN 'PE' THEN '2'
		ELSE null
	END
    FROM  #Compensi
    
    --SELECT 'Compensi',* FROM #Compensi
    --SELECT 'Record08',* FROM #Record08

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Da questo punto in poi la SP inizia a formare formare i dati con le @ per CINECA

CREATE TABLE #DATI(
--ProgrGen	varchar(600), Questa colonna viene aggiunta alla fine per come colonna identity
TipoOperazione	varchar(600),
Separatore	varchar(600),
TotCampi	varchar(600),
TipoRecord	varchar(600),
ProgrTipoRec	varchar(600),
Comparto	varchar(600),
Ruolo	varchar(600),
Matricola	varchar(600),
Valido	varchar(600),
AnnoCompLiq	varchar(600),
MeseCompLiq	varchar(600),
Voce	varchar(600),
Progressivo	varchar(600),
DatCompVoce	varchar(600),
StatoVoce	varchar(600),
Provvedimento	varchar(600),
Aliquota	varchar(600),
Parti	varchar(600),
Importo	varchar(600),
TipoImporto	varchar(600),
ImportoConvertito	varchar(600),
Divisa	varchar(600),
Ente	varchar(600),
Capitolo	varchar(600),
Oggetto	varchar(600),
Nota	varchar(600),
RifLiquidazione	varchar(600),
Riferimento	varchar(600),
DataIns	varchar(600),
DataMod	varchar(600),
Operatore	varchar(600)
)

insert into #DATI
SELECT
    TipoOperazione,
    '@', --> SeparatoreChr    char(1) Non mettiamo nulla, è come se avesse lunghezza 0
    convert (varchar(2),15),-- Tot. Campi
    TipoRecord,
    ProgrTipoRec,
    Comparto,
    Ruolo,
    Matricola,  
	-- parte del Record di Testa
    Ateneo,  
    -- Data generazione record    GG/MM/AAAA
    SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(data)))) +
        CONVERT(varchar(2),DAY(data)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(data)))) +
        CONVERT(varchar(2),MONTH(data))+'/'+
        +CONVERT(varchar(4),YEAR(data)),
	-- Ora della generazione
    SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DATEPART(hh,@datagenerazione)))) +
        CONVERT(varchar(2),DATEPART(hh,@datagenerazione)) + '.'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DATEPART(mi,@datagenerazione)))) +
        CONVERT(varchar(2),DATEPART(mi,@datagenerazione))+'.'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DATEPART(ss,@datagenerazione)))) +
        CONVERT(varchar(2),DATEPART(ss,@datagenerazione)),
    CodFile,
    InvioMatricola,
    InvioDatiAnagrafici,
    '','','','','','','','','','','','','','','','',''
	FROM #RecordTesta

insert into #DATI
SELECT 
    TipoOperazione,
    CASE WHEN SeparatoreChr is null    THEN  '@' ELSE SeparatoreChr + '@' END,
    convert (varchar(2),34),-- Tot. Campi
    TipoRecord,
    SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6), ROW_NUMBER() OVER(PARTITION BY Matricola
      ORDER BY  Matricola) -1 ),1,6))) + SUBSTRING(convert(varchar(6), ROW_NUMBER() OVER(PARTITION BY Matricola
      ORDER BY  Matricola) -1),1,6),
    --ProgrTipo Record
    CASE WHEN Comparto is null    THEN  '' ELSE Comparto END, 
    CASE WHEN Ruolo is null    THEN  '' ELSE Ruolo END, 
    CASE WHEN Matricola is null    THEN  '' ELSE  SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),Matricola),1,6))) + SUBSTRING(convert(varchar(6),Matricola),1,6) + '' END,
    CASE WHEN Valido is null    THEN  '' ELSE Valido + '' END,
    SUBSTRING('00',1,4 - DATALENGTH(CONVERT(varchar(4),Anno_Comp_Liq))) +
          CONVERT(varchar(4),Anno_Comp_Liq),
    SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),Mese_Comp_Liq))) +
          CONVERT(varchar(2),Mese_Comp_Liq),
    CASE WHEN Voce is null    THEN  '' ELSE  SUBSTRING(REPLICATE('0',5),1,5 - DATALENGTH(SUBSTRING(convert(varchar(5),Voce),1,5))) + SUBSTRING(convert(varchar(5),Voce),1,5)
	  END,
    CASE WHEN Progressivo is null    THEN  '' ELSE Progressivo END, -- + 
    SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(Data_Comp_Voce)))) +
        CONVERT(varchar(2),DAY(Data_Comp_Voce)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(Data_Comp_Voce)))) +
        CONVERT(varchar(2),MONTH(Data_Comp_Voce))+'/'+
        +CONVERT(varchar(4),YEAR(Data_Comp_Voce)), -- DataCompVoce
	
	CASE WHEN Stato_Voce is null    THEN  '' ELSE Stato_Voce END,   
    CASE WHEN Provvedimento is null    THEN  '' ELSE Provvedimento END,
    CASE WHEN CONVERT(varchar(24),Aliquota)   is null    THEN  '' ELSE CONVERT(varchar(24),Aliquota) END,
    CASE WHEN CONVERT(varchar(13),Parti)  is null    THEN  '' ELSE  CONVERT(varchar(13),Parti) END,
    CASE WHEN REPLACE(CONVERT(varchar(15),Importo),'.',',')   is null    THEN  '' ELSE REPLACE(CONVERT(varchar(15),Importo),'.',',') END,
    CASE WHEN Tipo_Importo is null    THEN  '' ELSE Tipo_Importo END,
    CASE WHEN CONVERT(varchar(10),Importo_Convertito)   is null    THEN  '' ELSE CONVERT(varchar(10),Importo_Convertito) END,
    CASE WHEN Divisa is null    THEN  '' ELSE Divisa END,
    CASE WHEN Ente is null    THEN  '' ELSE    SUBSTRING(REPLICATE('0',6),1,6 - DATALENGTH(SUBSTRING(convert(varchar(6),Ente),1,6))) + SUBSTRING(convert(varchar(6),Ente),1,6) + '' END,   
    CASE WHEN Capitolo is null    THEN  REPLICATE('0',6)  ELSE Capitolo END,
    CASE WHEN Oggetto is null    THEN  '' ELSE Oggetto END,
    CASE WHEN Nota is null    THEN  '' ELSE Nota END,
    CASE WHEN CONVERT(VARCHAR(1),Rif_Liquidazione)   is null    THEN  '' ELSE CONVERT(VARCHAR(1),Rif_Liquidazione) END,
    CASE WHEN Riferimento is null    THEN  '' ELSE Riferimento END,
    CASE WHEN Data_Ins is null   THEN  ''
	 ELSE  SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(Data_Ins)))) +
        CONVERT(varchar(2),DAY(Data_Ins)) + '/'+
        SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(Data_Ins)))) +
        CONVERT(varchar(2),MONTH(Data_Ins))+'/'+
        +CONVERT(varchar(4),YEAR(Data_Ins))
     END,
    CASE WHEN Data_Mod is null   THEN  ''
		   ELSE  SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),DAY(Data_Mod)))) +
			CONVERT(varchar(2),DAY(Data_Mod)) + '/'+
			SUBSTRING('00',1,2 - DATALENGTH(CONVERT(varchar(2),MONTH(Data_Mod)))) +
			CONVERT(varchar(2),MONTH(Data_Mod))+'/'+
			+CONVERT(varchar(4),YEAR(Data_Mod))
      END,
     CASE WHEN Operatore is null    THEN  '' ELSE Operatore END
	 
FROM #Record08
order by Matricola, Anno_Comp_Liq, Mese_Comp_Liq


ALTER TABLE #DATI  ADD ProgrGen INT IDENTITY(0,1)

CREATE TABLE #DATI_finali(
ProgrGen	varchar(600),
TipoOperazione	varchar(600),
Separatore	varchar(600),
TotCampi	varchar(600),
TipoRecord	varchar(600),
ProgrTipoRec	varchar(600),
Comparto	varchar(600),
Ruolo	varchar(600),
Matricola	varchar(600),
Valido	varchar(600),
AnnoCompLiq	varchar(600),
MeseCompLiq	varchar(600),
Voce	varchar(600),
Progressivo	varchar(600),
DatCompVoce	varchar(600),
StatoVoce	varchar(600),
Provvedimento	varchar(600),
Aliquota	varchar(600),
Parti	varchar(600),
Importo	varchar(600),
TipoImporto	varchar(600),
ImportoConvertito	varchar(600),
Divisa	varchar(600),
Ente	varchar(600),
Capitolo	varchar(600),
Oggetto	varchar(600),
Nota	varchar(600),
RifLiquidazione	varchar(600),
Riferimento	varchar(600),
DataIns	varchar(600),
DataMod	varchar(600),
Operatore	varchar(600),
F_Adempimenti varchar(600)
)

/*
insert into #dati_finali
select
'Pos0',
'Pos1',
'Pos2',
'Pos3',
'Pos4',
'Pos5',
'Pos6',
'Pos7',
'Pos8',
'Pos9',
'Pos10',
'Pos11',
'Pos12',
'Pos13',
'Pos14',
'Pos15',
'Pos16',
'Pos17',
'Pos18',
'Pos19',
'Pos20',
'Pos21',
'Pos22',
'Pos23',
'Pos24',
'Pos25',
'Pos26',
'Pos27',
'Pos28',
'Pos29',
'Pos30',
'Pos31'

insert into #dati_finali
select
'ProgrGen',
'TipoOperazione',
'Separatore',
'TotCampi',
'TipoRecord',
'ProgrTipoRec',
'Comparto',
'Ruolo',
'Matricola',
'Valido',
'AnnoCompLiq',
'MeseCompLiq',
'Voce',
'Progressivo',
'DatCompVoce',
'StatoVoce',
'Provvedimento',
'Aliquota',
'Parti',
'Importo',
'TipoImporto',
'ImportoConvertito',
'Divisa',
'Ente',
'Capitolo',
'Oggetto',
'Nota',
'RifLiquidazione',
'Riferimento',
'DataIns',
'DataMod',
'Operatore'
*/
insert into #dati_finali
(
ProgrGen
,TipoOperazione
,Separatore
,TotCampi
,TipoRecord
,ProgrTipoRec
,Comparto
,Ruolo
,Matricola
,Valido
,AnnoCompLiq
,MeseCompLiq
,Voce
,Progressivo
,DatCompVoce
,StatoVoce
,Provvedimento
,Aliquota
,Parti
,Importo
,TipoImporto
,ImportoConvertito
,Divisa
,Ente
,Capitolo
,Oggetto
,Nota
,RifLiquidazione
,Riferimento
,DataIns
,DataMod
,Operatore
,F_Adempimenti
)
SELECT 
ProgrGen
,TipoOperazione
,Separatore
,TotCampi
,TipoRecord
,ProgrTipoRec
,Comparto
,Ruolo
,Matricola
,Valido
,AnnoCompLiq
,MeseCompLiq
,Voce
,Progressivo
,DatCompVoce
,StatoVoce
,Provvedimento
,Aliquota
,Parti
,Importo
,TipoImporto
,ImportoConvertito
,Divisa
,Ente
,Capitolo
,Oggetto
,Nota
,RifLiquidazione
,Riferimento
,DataIns
,DataMod
,Operatore
,CASE Ruolo
  WHEN 'NC' THEN '2'
  WHEN 'PE' THEN '2'
  ELSE null END
FROM #DATI ORDER BY ProgrGen

select * from #dati_finali

END


