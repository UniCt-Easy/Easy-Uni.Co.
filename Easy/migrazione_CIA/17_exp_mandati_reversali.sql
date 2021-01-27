
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mandati_reversali]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mandati_reversali]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--- [exp_mandati_reversali] 'A.ammce'
CREATE PROCEDURE [exp_mandati_reversali] 
(
	@bilancio varchar(120) 
)
AS BEGIN

/* prende i dati della fase 2 di CIA, il bilancio dalla fase 1 presumendo ci sia coerenza tra fase 1 e 2
   il numero della distinta è scelto in base alla data di trasmissione ed alla data di creazione della distinta
   l'anagrafica è presa dalla fase 2 di CIA
   il numero del mandato è preso dal substring della chiave_documento

*/

/*
			"tipo;M=Mandato, R=Reversali;Codificato;1;M|R",
            "anno;Anno;Intero;4",
            "num;Numero;Intero;7",
            "natura;C=Competenza,R=residui,M=misto;Codificato;1;C|M|R",
            "codicecass;Codice Cassiere;Stringa;20",
            "descrcass;Descrizione Cassiere;Stringa;150",
            "codice;Codice Anagrafica;Stringa;10",
            "codicebil;Codice Bilancio;Stringa;50",
            "codbollo;Codice Trattamento Bollo;Stringa;4",
            "descrbollo;Descr. Trattamento Bollo;Stringa;50",
            "flagfrutt;Fruttifero S/N (solo per reversali);Codificato;1;S|N",
            "datacont;Data contabile;Data;8",
            "resp;Responsabile;Stringa;150",
            "numelenco;Numero elenco di trasmissione;Intero;6"
			"datatrasmissione;Data trasmissione;Data;8",
			"dataannullamento;Data annullamento;Data;8",
            "datastampa;Data stampa;Data;8"
            */
            
SELECT
 'R'  as tipo,
D.ESERCIZIO as anno,
CONVERT(INT,SUBSTRING(D.CHIAVE, 6, LEN(D.CHIAVE))) as num,
D.COMPETENZA_RESIDUI as natura,
lookup_dipartimento.codeupb as codicecass,
lookup_dipartimento.descrizione as descrcass,
lookup_anagrafica.idreg as codice,
lookup_bilancio.codefin as codicebil,
CASE 
	WHEN isnull(D.IMPORTO_BOLLO,0)=0  THEN 'ESE'
	ELSE 'NONESE'
END as codbollo,
CASE 
	WHEN isnull(D.IMPORTO_BOLLO,0)=0  THEN 'Esente Bollo'
	ELSE 'Esigere Bollo'
END as descrbollo,
  'S'  as flagfrutt,
D.DATA_CONTABILIZZAZIONE as datacont,
null as resp,
 
(select top 1 chiave from distinta T  where D.bilancio = T.bilancio AND
		D.esercizio = T.esercizio AND  T.DACR >= D.DATA_TRASMISSIONE
		AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_ENTRATE)  <>0
		order by CONVERT (INT,T.CHIAVE) asc) 
    as numelenco,
(select top 1  ISNULL(t.DATA,T.DACR)  from distinta T  where D.bilancio = T.bilancio AND
		D.esercizio = T.esercizio AND  T.DACR >= D.DATA_TRASMISSIONE
		AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_ENTRATE)  <>0
		order by CONVERT (INT,T.CHIAVE) asc) 
    as datatrasmissione,
D.DATA_STAMPA as datastampa,
D.DATA_STORNO as dataannullamento
FROM  CURR_DOCUMENTO_CONTABILE  D
LEFT OUTER JOIN   lookup_anagrafica
	ON  lookup_anagrafica.codice = D.CODICE_ANAG
LEFT OUTER JOIN   lookup_dipartimento
	ON  lookup_dipartimento.chiave_completa = D.bilancio
LEFT OUTER JOIN   lookup_bilancio
	ON  lookup_bilancio.chiave_completa = D.CHIAVE_CONTO
WHERE D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
	 AND D.TIPO  = 'REVERSALE' 

UNION ALL
SELECT
 'M' as tipo,
	D.ESERCIZIO as anno,
	CONVERT(INT,SUBSTRING(D.CHIAVE, 6, LEN(D.CHIAVE))) as num,
	D.COMPETENZA_RESIDUI as natura,
lookup_dipartimento.codeupb as codicecass,
lookup_dipartimento.descrizione as descrcass,
lookup_anagrafica.idreg as codice,
lookup_bilancio.codefin as codicebil,
CASE 
	WHEN isnull(D.IMPORTO_BOLLO,0)=0  THEN 'ESE'
	ELSE 'NONESE'
END as codbollo,
CASE 
	WHEN isnull(D.IMPORTO_BOLLO,0)=0  THEN 'Esente Bollo'
	ELSE 'Esigere Bollo'
END as descrbollo,
NULL as flagfrutt,
D.DATA_CONTABILIZZAZIONE as datacont,
null as resp,
 
 (select top 1 chiave from distinta T  where D.bilancio = T.bilancio AND
		   D.esercizio = T.esercizio AND  T.DACR >= D.DATA_TRASMISSIONE
		    AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_SPESE)  <>0
		   order by CONVERT (INT,T.CHIAVE) asc) 
 as numelenco,
 (select top 1 ISNULL(T.DATA,T.DACR)  from distinta T  where D.bilancio = T.bilancio AND
		D.esercizio = T.esercizio AND  T.DACR >= D.DATA_TRASMISSIONE
		AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_SPESE)  <>0
		order by CONVERT (INT,T.CHIAVE) asc) 
    as datatrasmissione,
D.DATA_STAMPA as datastampa,
D.DATA_STORNO as dataannullamento
FROM  CURR_DOCUMENTO_CONTABILE D
LEFT OUTER JOIN   lookup_anagrafica
ON  lookup_anagrafica.codice = D.CODICE_ANAG
LEFT OUTER JOIN   lookup_dipartimento
ON  lookup_dipartimento.chiave_completa = D.bilancio
LEFT OUTER JOIN   lookup_bilancio
ON  lookup_bilancio.chiave_completa = D.CHIAVE_CONTO
WHERE D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
 AND D.TIPO = 'MANDATO' 
 
 
END

