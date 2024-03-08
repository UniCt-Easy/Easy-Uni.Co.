
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


if exists (select * from dbo.sysobjects where id = object_id(N'[emisti_crea_riepiloghi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [emisti_crea_riepiloghi]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 --  setuser setuser 'amministrazione'

 -- exec emisti_crea_riepiloghi 9
CREATE procedure [emisti_crea_riepiloghi] 
@idemisti_import INT
as
begin
CREATE TABLE  #em_Riepiloghi (
	[RUOLO] [nvarchar](50) NULL,
	[CAPITOLO] [nvarchar](90) NULL,
	[COMPETENZA] [nvarchar](4) NULL,
	[MATRICOLA] [varchar](8) NULL,
	[CodiceFiscale] varchar(16) NULL,
	[NOME] [nvarchar](61) NOT NULL,
	[LORDO] [decimal](19, 2) NULL,
	[RITENUTE_PREV] [decimal](19, 2) NULL,
	[IMPONIBILERATAANNOCORRENTE] [decimal](19, 2) NULL,
	[IRPEFTOTALENETTA] [decimal](19, 2) NULL,
	[IMPORTOMENSILENETTO] [decimal](19, 2) NULL,
	[IRPEFRATAANNOCORRENTE] [decimal](19, 2) NULL,
	[IRPEFARRETRATIANNOPRECEDENTE] [decimal](19, 2) NULL,
	[IRPEFARRETRATIANNOCORRENTE] [decimal](19, 2) NULL,
	[IMPORTOIRPEF13MA] [decimal](19, 2) NULL,
	[IRPEFACCESSORIEAC] [decimal](19, 2) NULL,
	[IRPEFACCESSORIEAP] [decimal](19, 2) NULL,
	[TOTALEDETRAZIONI] [decimal](19, 2) NULL,
	[IMPORTOMENSILELORDO] [decimal](19, 2) NULL,
	[CREDITOIRPEF] [decimal](19, 2) NULL
) ON [PRIMARY]

INSERT INTO #em_Riepiloghi  (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, CodiceFiscale, NOME, LORDO, RITENUTE_PREV
,IMPONIBILERATAANNOCORRENTE,IRPEFTOTALENETTA,IMPORTOMENSILENETTO,IRPEFRATAANNOCORRENTE,IRPEFARRETRATIANNOPRECEDENTE
,IRPEFARRETRATIANNOCORRENTE, IMPORTOIRPEF13MA,IRPEFACCESSORIEAC,IRPEFACCESSORIEAP,TOTALEDETRAZIONI,IMPORTOMENSILELORDO,CREDITOIRPEF    )
SELECT R1.Qualifica  as RUOLO,
CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R2.CodiceAssegno as nvarchar) + ' - ' + ISNULL(C.DescrizioneCodice,'') as  CAPITOLO, -- + '/' +cast(R2.SottocodiceAssegno as nvarchar) 
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA,R1.CodiceFiscale , 
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
cast(R2.ImportoLordoRata as float)/100 - ISNULL(cast(R2.ImportoRiduzionePT as float),0)/100 - ISNULL(cast(R2.ImportoRiduzioneTE as float),0)/100 as LORDO,
cast(R2.ImportoRitPrev as float)/100 as RITENUTE_PREV,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IMPONIBILERATAANNOCORRENTE as float)/100 
	ELSE 0 
	END as IMPONIBILERATAANNOCORRENTE,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IRPEFTOTALENETTA as float)/100 
	ELSE 0 
	END as IRPEFTOTALENETTA,
CASE  
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IMPORTOMENSILENETTO as float)/100 
	ELSE 0 
	END as IMPORTOMENSILENETTO,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IRPEFRATAANNOCORRENTE as float)/100 
	ELSE 0 
	END as IRPEFRATAANNOCORRENTE,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IRPEFARRETRATIANNOPRECEDENTE as float)/100 
	ELSE 0 
	END as IRPEFARRETRATIANNOPRECEDENTE,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IRPEFARRETRATIANNOCORRENTE as float)/100 
	ELSE 0 
	END as IRPEFARRETRATIANNOCORRENTE,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IMPORTOIRPEF13MA as float)/100 
	ELSE 0 
	END as IMPORTOIRPEF13MA,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IRPEFACCESSORIEAC as   float)/100 
	ELSE 0 
	END as IRPEFACCESSORIEAC,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IRPEFACCESSORIEAP as float)/100 
	ELSE 0 
	END as IRPEFACCESSORIEAP,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.TOTALEDETRAZIONI as float)/100 
	ELSE 0 
	END as TOTALEDETRAZIONI,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.IMPORTOMENSILELORDO as float)/100 
	ELSE 0 
	END as IMPORTOMENSILELORDO,
CASE 
	WHEN cast(R2.CodiceAssegno as nvarchar) = '1' THEN cast(R1.CREDITOIRPEF as float)/100 
	ELSE 0 
	END as CREDITOIRPEF -- valutare se eliminare
from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_02] as R2 ON R1.nrec = R2.progressivo_rec_01 AND  R1.idemisti_import = R2.idemisti_import
left join  [emisti_codici] as C ON C.codice =   R2.CodiceAssegno  and C.tiporecord = 'Record2'
WHERE   R1.idemisti_import = @idemisti_import

-- Record 6
insert into  #em_Riepiloghi (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA,CodiceFiscale, NOME, LORDO, RITENUTE_PREV, 
IMPONIBILERATAANNOCORRENTE,IRPEFRATAANNOCORRENTE,IRPEFARRETRATIANNOPRECEDENTE,IRPEFARRETRATIANNOCORRENTE,IRPEFTOTALENETTA,
IMPORTOMENSILELORDO,IMPORTOMENSILENETTO,IMPORTOIRPEF13MA,IRPEFACCESSORIEAC,IRPEFACCESSORIEAP,TOTALEDETRAZIONI)
SELECT R1.Qualifica  as RUOLO,
CASE 
-- CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R6.CodiceAssegno as nvarchar) + ' - ' + C.DescrizioneCodice 
	WHEN cast(R6.CodiceAssegno as nvarchar) = '800' 
		THEN  CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R6.CodiceAssegno as nvarchar) +  ' - ' + ISNULL(C.DescrizioneCodice,'')   
	WHEN cast(R6.CodiceAssegno as nvarchar) = '806'
		THEN  CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R6.CodiceAssegno as nvarchar)  +  ' - ' + ISNULL(C.DescrizioneCodice,'') 
END AS CAPITOLO,
R6.AnnoRIferimento as COMPETENZA,
R1.iscrizione as MATRICOLA,R1.CodiceFiscale , 
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,

CASE  -- ImportoLordoRata - ImportoRiduzionePT - ImportoRiduzioneTE – ImportoRitenute
	WHEN cast(R6.CodiceAssegno as nvarchar) = '800' AND cast(R6.ImportoLordoRata as float)/100 = 0
			AND (cast(R6.ImportoRiduzionePT as float)/100<>0 OR cast(R6.ImportoRiduzioneTE as float)/100<>0) 
	-- Siccome il lordo è pari a zero e viene specificata una riduzione di un debito, allora trattasi di debito negativo, quindi è un credito a favore del dipendente, 
	-- quindi è un Lordo Positivo
			THEN (cast(R6.ImportoRiduzionePT as float)/100 + cast(R6.ImportoRiduzioneTE as float)/100)
	WHEN cast(R6.CodiceAssegno as nvarchar) = '806' AND cast(R6.ImportoLordoRata as float)/100 = 0
			AND (cast(R6.ImportoRiduzionePT as float)/100<>0 OR cast(R6.ImportoRiduzioneTE as float)/100<>0) 
	-- Siccome il lordo è pari a zero e viene specificata una riduzione di un credito, allora trattasi di credito negativo, quindi è un debito del dipendente, 
	-- quindi è un Lordo Nositivo
			THEN -(cast(R6.ImportoRiduzionePT as float)/100 + cast(R6.ImportoRiduzioneTE as float)/100)

	WHEN cast(R6.CodiceAssegno as nvarchar) = '800' AND cast(R6.ImportoLordoRata as float)/100 <> 0-- DEBITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 > 0 -- Debito Positivo = LORDO negativo perchè deve restituire
			THEN -(cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100  )
	WHEN cast(R6.CodiceAssegno as nvarchar) = '800' AND cast(R6.ImportoLordoRata as float)/100 <> 0 -- DEBITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 < 0 -- Debito Negativo = LORDO positivo perchè diventa un suo credito	
			THEN (cast(R6.ImportoLordoRata as float )/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100)
	
	WHEN cast(R6.CodiceAssegno as nvarchar) = '806' -- CREDITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 > 0 -- Credito Positivo = LORDO positivo perchè rimane un suo credito	
			THEN  (cast(R6.ImportoLordoRata as float)/100  - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100)
	WHEN cast(R6.CodiceAssegno as nvarchar) = '806' -- CREDITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 < 0 -- Credito Negativo = LORDO negativo, quindi è un debito e pertanto deve restituire	
			THEN -(cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100)
	ELSE 0
	END AS LORDO,
CASE  
	WHEN cast(R6.CodiceAssegno as nvarchar) = '800' -- DEBITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 > 0 -- Debito Positivo = LORDO negativo perchè deve restituire
			THEN -( cast(R6.ImportoRitenute as float)/100  )
	WHEN cast(R6.CodiceAssegno as nvarchar) = '800' -- DEBITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 < 0 -- Debito Negativo = LORDO positivo perchè diventa un suo credito	
			THEN - cast(R6.ImportoRitenute as float)/100 
	WHEN cast(R6.CodiceAssegno as nvarchar) = '806' -- CREDITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 > 0 -- Credito Positivo = LORDO positivo perchè rimane un suo credito	
			THEN  - cast(R6.ImportoRitenute as float)/100   
	WHEN cast(R6.CodiceAssegno as nvarchar) = '806' -- CREDITO
			AND cast(R6.ImportoLordoRata as float)/100 - cast(R6.ImportoRiduzionePT as float)/100 - cast(R6.ImportoRiduzioneTE as float)/100 - cast(R6.ImportoRitenute as float)/100 < 0 -- Credito Negativo = LORDO negativo, quindi è un debito e pertanto deve restituire	
			THEN  (cast(R6.ImportoRitenute as float)/100   )
	END AS Ritenuta,

0 as IMPONIBILERATAANNOCORRENTE,
0 as IRPEFRATAANNOCORRENTE,
0 as IRPEFARRETRATIANNOPRECEDENTE,
0 as IRPEFARRETRATIANNOCORRENTE,
0 as IRPEFTOTALENETTA,
0 as IMPORTOMENSILELORDO,
0 as IMPORTOMENSILENETTO,
0 as IMPORTOIRPEF13MA,
0 as IRPEFACCESSORIEAC,
0 as IRPEFACCESSORIEAP,
0 as TOTALEDETRAZIONI
from  [Emisti_Rec_01] as R1 
join  [Emisti_Rec_06] as R6 ON R1.nrec = R6.progressivo_rec_01 AND  R1.idemisti_import = R6.idemisti_import
left join  [emisti_codici] as C ON C.codice =   R6.CodiceAssegno  and C.tiporecord = 'Record6'
WHERE  R1.idemisti_import = @idemisti_import
AND R6.codicearretrato NOT IN ('ERM','ERI','159','163', '267', 'A14', 'A15', 'A16', 'A17', 'CCC', 'CCG', 'G15', 'G18','G63','J63')  -- Questi li devo trattare come ritenute negative e non Lordi

-- Record 7 ELIMINATO perchè queste ritenute sono già esposte nel record 6
--insert into  [em_Riepiloghi] (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, NOME, LORDO, RITENUTE_PREV, MeseRiferimento,
--IMPONIBILERATAANNOCORRENTE,IRPEFRATAANNOCORRENTE,IRPEFARRETRATIANNOPRECEDENTE,IRPEFARRETRATIANNOCORRENTE,IRPEFTOTALENETTA,
--IMPORTOMENSILELORDO,IMPORTOMENSILENETTO,IMPORTOIRPEF13MA,IRPEFACCESSORIEAC,IRPEFACCESSORIEAP,TOTALEDETRAZIONI)
--select R1.Qualifica as RUOLO,
--'Rit.Arr.'+cast(R7.CodRitPrevAss as nvarchar) AS CAPITOLO,
--substring(R7.Rata, 1, 4) as COMPETENZA ,
--R1.CodiceFiscale as MATRICOLA,
--concat(trim(R1.Cognome1), ' ', trim(R1.Nome1)) as NOME,
--0       as LORDO,
--cast(R7.ImportoRitLavoratore as float)/100     AS Ritenuta,
--substring(R1.Rata, 6, 2) as MeseRiferimento, 
--0 as IMPONIBILERATAANNOCORRENTE,
--0 as IRPEFRATAANNOCORRENTE,
--0 as IRPEFARRETRATIANNOPRECEDENTE,
--0 as IRPEFARRETRATIANNOCORRENTE,
--0 as IRPEFTOTALENETTA,
--0 as IMPORTOMENSILELORDO,
--0 as IMPORTOMENSILENETTO,
--0 as IMPORTOIRPEF13MA,
--0 as IRPEFACCESSORIEAC,
--0 as IRPEFACCESSORIEAP,
--0 as TOTALEDETRAZIONI
--from  [Emisti_Rec_01] as R1 join  [Emisti_Rec_07] as R7
--on R1.nrec = R7.nrec


-- Record 8
insert into  #em_Riepiloghi (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA,CodiceFiscale, NOME, LORDO, RITENUTE_PREV, 
IMPONIBILERATAANNOCORRENTE,IRPEFRATAANNOCORRENTE,IRPEFARRETRATIANNOPRECEDENTE,IRPEFARRETRATIANNOCORRENTE,IRPEFTOTALENETTA,
IMPORTOMENSILELORDO,IMPORTOMENSILENETTO, IMPORTOIRPEF13MA,IRPEFACCESSORIEAC,IRPEFACCESSORIEAP,TOTALEDETRAZIONI)
SELECT R1.Qualifica + '-' + CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) as RUOLO,
-- CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) + ' - '+ cast(R8.Compenso as nvarchar) + ' - ' + C.DescrizioneCodice 

'Accessori'+R8.Compenso + '-' + CONVERT(VARCHAR(4),R1.[CapitoloSpesa]) as CAPITOLO,
substring(R1.Rata, 1, 4) as COMPETENZA,
R1.iscrizione as MATRICOLA,R1.CodiceFiscale , 
concat(ltrim(rtrim(R1.Cognome1)), ' ', ltrim(rtrim(R1.Nome1))) as NOME,
cast(R8.Importo as float)/100 as LORDO,
cast(R8.ImportoRitenute as float)/100 as Ritenuta,
0 as IMPONIBILERATAANNOCORRENTE,
0 as IRPEFRATAANNOCORRENTE,
0 as IRPEFARRETRATIANNOPRECEDENTE,
0 as IRPEFARRETRATIANNOCORRENTE,
0 as IRPEFTOTALENETTA,
0 as IMPORTOMENSILELORDO,
0 as IMPORTOMENSILENETTO,
0 as IMPORTOIRPEF13MA,
0 as IRPEFACCESSORIEAC,
0 as IRPEFACCESSORIEAP,
0 as TOTALEDETRAZIONI
from  [Emisti_Rec_01] as R1 join  [Emisti_Rec_08] as R8 on R1.nrec = R8.progressivo_rec_01 AND  R1.idemisti_import = R8.idemisti_import
left join  [emisti_codici] as C ON C.codice = R8.Compenso and C.tiporecord = 'Record8'

WHERE   R1.idemisti_import = @idemisti_import


/*
DEFINIZIONI
IRPEFTOTALENETTA = IRPEFRATAANNOCORRENTE + IRPEFARRETRATIANNOCORRENTE + IRPEFACCESSORIEAC- TOTALEDETRAZIONI 
IMPORTOMENSILENETTO = LORDO - RITENUTE_PREV - IRPEFTOTALENETTA 
*/


select * from  #em_Riepiloghi
--where CAPITOLO like '% 806 - ARRETRATO CREDITO'
--and  MATRICOLA like '%PSCGPP61P30A662V%'
order by MATRICOLA,  CAPITOLO



/*

 -- Record 3
insert into  [em_Riepiloghi] (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, NOME, LORDO, RITENUTE_PREV, MeseRiferimento)
select R1.Qualifica as RUOLO,
'Rec03 '+cast(R3.CodiceAssegno as nvarchar) + '/'+ cast(R3.CodRitPrevAss as nvarchar) CAPITOLO,
0 as COMPETENZA,
R1.CodiceFiscale as MATRICOLA,
concat(trim(R1.Cognome1), ' ', trim(R1.Nome1)) as NOME,
cast(R3.IMPONIBILE as float)/100 as LORDO,
cast(R3.ImportoRitenuta as float)/100  AS Ritenuta,
substring(R1.Rata, 6, 2) as MeseRiferimento 
from  [Emisti_Rec_01] as R1 join  Emisti_Rec_03 as R3
on R1.nrec = R3.nrec

-- Record 4
insert into  [em_Riepiloghi] (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, NOME, LORDO, RITENUTE_PREV, MeseRiferimento,
IRPEFARRETRATIANNOPRECEDENTE)
select R1.Qualifica as RUOLO,
'Rec04 Cod. Rit. '+cast(R4.CodiceRitenuta as nvarchar) + '/Tipo Rit.'+ cast(R4.TipoRitenuta as nvarchar) CAPITOLO,
0 as COMPETENZA,
R1.CodiceFiscale as MATRICOLA,
concat(trim(R1.Cognome1), ' ', trim(R1.Nome1)) as NOME,
0 as LORDO,
cast(R4.ImportoRitenuta as float)/100  AS Ritenuta,
substring(R1.Rata, 6, 2) as MeseRiferimento, 
cast(R4.ImportoRitNetto as float)/100 as IRPEFARRETRATIANNOPRECEDENTE -- Valore appoggiato su questo campo per capire che cosa contiene
from  [Emisti_Rec_01] as R1 join  Emisti_Rec_04 as R4
on R1.nrec = R4.nrec

-- Record 7
insert into  [em_Riepiloghi] (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, NOME, LORDO, RITENUTE_PREV, MeseRiferimento)
select R1.Qualifica as RUOLO,
'Rec07 '+cast(R7.CodiceAssegno as nvarchar) + '/'+ cast(R7.CodiceArretrato as nvarchar)+ '/Cod. Rit. '+ cast(R7.CodRitPrevAss as nvarchar) CAPITOLO,
0 as COMPETENZA,
R1.CodiceFiscale as MATRICOLA,
concat(trim(R1.Cognome1), ' ', trim(R1.Nome1)) as NOME,
cast(R7.IMPONIBILE as float)/100 as LORDO,
cast(R7.ImportoRitLavoratore as float)/100  AS Ritenuta,
substring(R1.Rata, 6, 2) as MeseRiferimento
from  [Emisti_Rec_01] as R1 join  Emisti_Rec_07 as R7
on R1.nrec = R7.nrec

-- Record 9
insert into  [em_Riepiloghi] (RUOLO, CAPITOLO, COMPETENZA, MATRICOLA, NOME, LORDO, RITENUTE_PREV, MeseRiferimento)
select R1.Qualifica as RUOLO,
'Rec09 '+cast(R9.Compenso as nvarchar) + '/ Cod. Rit.'+ cast(R9.CodRitPrevAss as nvarchar) CAPITOLO,
0 as COMPETENZA,
R1.CodiceFiscale as MATRICOLA,
concat(trim(R1.Cognome1), ' ', trim(R1.Nome1)) as NOME,
cast(R9.IMPONIBILE as float)/100 as LORDO,
cast(R9.ImportoRitLavoratore as float)/100  AS Ritenuta,
substring(R1.Rata, 6, 2) as MeseRiferimento
from  [Emisti_Rec_01] as R1 join  Emisti_Rec_09 as R9
on R1.nrec = R9.nrec
*/


END
GO


