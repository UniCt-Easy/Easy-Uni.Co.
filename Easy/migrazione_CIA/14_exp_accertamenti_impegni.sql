
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_accertamenti_impegni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_accertamenti_impegni]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--- [exp_accertamenti_impegni] 'A.00000'
CREATE PROCEDURE exp_accertamenti_impegni 
(
	@bilancio varchar(120) 
)
AS BEGIN
/*
		 string[] tracciato_movfin = new string[]{
            "tipo;Tipo movimento (E=Entrata,S=Spesa);Codificato;1;E|S",
            "nliv;Numero fase;Intero;1",
            "descliv;Descrizione fase;Stringa;50",
            "last;Ultima fase;Codificato;1;S|N",
            "ymov;Esercizio movimento;Intero;4",
            "nmov;Numero movimento;Intero;8",
            "parentymov;Esercizio movimento Parent;Intero;4",
            "parentnmov;Numero movimento Parent;Intero;8",
            "description;Descrizione;Stringa;150",
            "doc;Documento;Stringa;35",
            "docdate;Data documento;Data;8",
            "adate;Data Contabile;Data;8",
            "idreg;Codice di anagrafica;Intero;10",
            "resp;Responsabile;Stringa;150",
            "ayear;Anno imputazione;Intero;4",
            "amount;Importo iniziale anno;Numero;22",
            "codiceupb;Codice upb;Stringa;50",
            "codicebil;Codice bilancio;Stringa;50",
            "nmanrev;Numero di mandato o reversale (solo ult.fasi);Intero;8",
            "cc;Numero di conto corrente (solo ult.fase spesa);Stringa;30",
            "cin;Cin (solo ult.fase spesa);Stringa;2",
            "iban;IBAN (solo ult.fase spesa);Stringa;50",
            "idbank;ABI (solo ult.fase spesa);Stringa;20",
            "idcab;CAB (solo ult.fase spesa);Stringa;20",
            "paymentdescr;Descrizione pagamento (solo ult.fase spesa);Stringa;150",
            "note;Note;Stringa;400",
            "nbill;Numero carta contabile;Intero;7"
        };
            */

SELECT
 'E' as  tipo,
 CURR_DOCUMENTO_CONTABILE.TIPO as fase_cia, 
 lookup_movfin.nphase as nliv,
 'PreAccertamento' as descliv,
 'N' as last,
 lookup_movfin.ymov as ymov,
 lookup_movfin.nmov as nmov,
 null as parentymov,
 null as parentnmov,
 isnull( CURR_DOCUMENTO_CONTABILE.DESCRIZIONE, '.') AS description, 
 --CASE
	--	WHEN F.numero_fattura  IS NOT NULL THEN  'Fatt. ' +  F.numero_fattura + '/' + CONVERT(varchar(4),F.esercizio)
	--	ELSE NULL 
 --END AS doc,
 --CASE
	--	WHEN  f.numero_fattura IS NOT NULL THEN F.DATA_REGISTRAZIONE
	--	ELSE NULL 
 --END AS docdate,
 null as doc,
 null as docdate,
 CURR_DOCUMENTO_CONTABILE.DATA_CONTABILIZZAZIONE as adate,
 --lookup_anagrafica.idreg as idreg,
 null as idreg,
 null as resp,
 CURR_DOCUMENTO_CONTABILE.ESERCIZIO as ayear,
 case when D_OLD.esercizio>=2002 then D_OLD.AMMONTARE else ROUND(D_OLD.ammontare/1936.27,2) end as amount,
 lookup_upb.codeupb AS codiceupb,
 lookup_bilancio.codefin AS codicebil,
 null AS manrev,
 null AS cc,
 null AS cin,
 null AS iban,
 null AS idbank,
 null AS idcab,
 null AS paymentdescr,
 null AS NOTE,
 null AS nbill,
 substring(ltrim(rtrim(CURR_DOCUMENTO_CONTABILE.cig)),1,10) as cig ,
 substring(ltrim(rtrim(CURR_DOCUMENTO_CONTABILE.cup)),1,15) as cup
FROM  CURR_DOCUMENTO_CONTABILE 
left outer JOIN  DOCUMENTO_CONTABILE D_OLD
	ON  D_OLD.bilancio = CURR_DOCUMENTO_CONTABILE.bilancio
         and D_OLD.esercizio=CURR_DOCUMENTO_CONTABILE.esercizio 
         AND D_OLD.chiave_completa_documento=CURR_DOCUMENTO_CONTABILE.chiave_completa_documento 
JOIN lookup_movfin 
		ON  CURR_DOCUMENTO_CONTABILE.CHIAVE_COMPLETA_DOCUMENTO = lookup_movfin.CHIAVE_COMPLETA_DOCUMENTO
			AND CURR_DOCUMENTO_CONTABILE.BILANCIO = lookup_movfin.BILANCIO
			AND CURR_DOCUMENTO_CONTABILE.ESERCIZIO = lookup_movfin.ESERCIZIO
LEFT OUTER JOIN   lookup_anagrafica
		ON  lookup_anagrafica.codice = CURR_DOCUMENTO_CONTABILE.CODICE_ANAG
LEFT OUTER JOIN   lookup_bilancio
		ON  lookup_bilancio.chiave_completa = CURR_DOCUMENTO_CONTABILE.CHIAVE_CONTO
LEFT OUTER JOIN   lookup_upb
		ON  lookup_upb.chiave_completa = CURR_DOCUMENTO_CONTABILE.UNITA_ORGANIZZATIVA
-- l'associazione non è univoca
--LEFT OUTER JOIN FATTURA_ATT F 
--	on F.bilancio = CURR_DOCUMENTO_CONTABILE.bilancio 
--	and F.esercizio = CURR_DOCUMENTO_CONTABILE.esercizio
--	and EXISTS ( select * FROM    fattura_ATT_dettaglio DETTFATT
--	where  F.esercizio  = DETTFATT.esercizio AND F.bilancio  = DETTFATT.bilancio 
--	and  F.NUMERO_FATTURA = DETTFATT.NUMERO_FATTURA
--	AND DETTFATT.chiave_ACCERTAMENTO = CURR_DOCUMENTO_CONTABILE.CHIAVE_COMPLETA_DOCUMENTO )
WHERE CURR_DOCUMENTO_CONTABILE.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
		AND CURR_DOCUMENTO_CONTABILE.TIPO  = 'ACCERTAMENTO' 
		AND lookup_movfin.nphase=1
		AND lookup_movfin.kind='E'
		AND D_OLD.numero_versione=0
		AND lookup_upb.BILANCIO=@bilancio
UNION ALL


SELECT
'S' as tipo,
 CURR_DOCUMENTO_CONTABILE.TIPO as fase_cia, 
 lookup_movfin.nphase as nliv,
 'Impegno' as descliv,
 'N' as last,
 lookup_movfin.ymov as ymov,
 lookup_movfin.nmov as nmov,
 null as parentymov,
 null as parentnmov,
 isnull(CURR_DOCUMENTO_CONTABILE.DESCRIZIONE, '.') AS description, 
 --CASE
	--	WHEN  f.numero_fattura IS NOT NULL THEN  'Fatt.' + convert(varchar(10), f.numero_fattura) + '/' + CONVERT(varchar(4),f.esercizio)
	--	WHEN O.numero_ordine IS   NOT NULL THEN  'Ord.' + convert(varchar(10), O.numero_ordine) + '/' +  CONVERT(varchar(4),O.esercizio)
	--	ELSE NULL 
 --END AS doc,
 --CASE
	--	WHEN  f.numero_fattura IS NOT NULL THEN F.DATA_REGISTRAZIONE 
	--	WHEN O.numero_ordine IS   NOT NULL THEN O.DATA_EMISSIONE
	--	ELSE NULL 
 --END AS docdate,
 null as doc,
 null as docdate,
 CURR_DOCUMENTO_CONTABILE.DATA_CONTABILIZZAZIONE as adate,
 --lookup_anagrafica.idreg as idreg,
 null as idreg,
 null as resp,
 CURR_DOCUMENTO_CONTABILE.ESERCIZIO as ayear,
 case when D_OLD.esercizio>=2002 then D_OLD.AMMONTARE else ROUND(D_OLD.ammontare/1936.27,2) end as amount,
 lookup_upb.codeupb AS codiceupb,
 lookup_bilancio.codefin AS codicebil,
 null AS manrev,
 null AS cc,
 null AS cin,
 null AS iban,
 null AS idbank,
 null AS idcab,
 null AS paymentdescr,
 null AS NOTE,
 null AS nbill,
 substring(ltrim(rtrim(CURR_DOCUMENTO_CONTABILE.cig)),1,10) as cig ,
 substring(ltrim(rtrim(CURR_DOCUMENTO_CONTABILE.cup)),1,15) as cup
 
FROM  CURR_DOCUMENTO_CONTABILE 
left outer JOIN  DOCUMENTO_CONTABILE D_OLD
	ON  D_OLD.bilancio = CURR_DOCUMENTO_CONTABILE.bilancio
         and D_OLD.esercizio=CURR_DOCUMENTO_CONTABILE.esercizio 
         AND D_OLD.chiave_completa_documento=CURR_DOCUMENTO_CONTABILE.chiave_completa_documento 
JOIN lookup_movfin
		ON  CURR_DOCUMENTO_CONTABILE.CHIAVE_COMPLETA_DOCUMENTO = lookup_movfin.CHIAVE_COMPLETA_DOCUMENTO
		AND CURR_DOCUMENTO_CONTABILE.BILANCIO = lookup_movfin.BILANCIO
		AND CURR_DOCUMENTO_CONTABILE.ESERCIZIO = lookup_movfin.ESERCIZIO
LEFT OUTER JOIN   lookup_anagrafica
			ON  lookup_anagrafica.codice = CURR_DOCUMENTO_CONTABILE.CODICE_ANAG
LEFT OUTER JOIN   lookup_bilancio
			ON  lookup_bilancio.chiave_completa = CURR_DOCUMENTO_CONTABILE.CHIAVE_CONTO
LEFT OUTER JOIN   lookup_upb
			ON  lookup_upb.chiave_completa = CURR_DOCUMENTO_CONTABILE.UNITA_ORGANIZZATIVA
--LEFT OUTER JOIN ORDINE O
--on O.bilancio = CURR_DOCUMENTO_CONTABILE.bilancio 
--	and O.esercizio = CURR_DOCUMENTO_CONTABILE.esercizio
--	and exists (SELECT * FROM  ordine_dettaglio DETTORD
--	WHERE O.esercizio  = DETTORD.esercizio AND O.bilancio  = DETTORD.bilancio 
--	AND O.NUMERO_ORDINE = DETTORD.NUMERO_ORDINE
--	AND DETTORD.chiave_impegno = CURR_DOCUMENTO_CONTABILE.CHIAVE_COMPLETA_DOCUMENTO )
	
--LEFT OUTER JOIN FATTURA F 
--	on F.bilancio = CURR_DOCUMENTO_CONTABILE.bilancio 
--	and F.esercizio = CURR_DOCUMENTO_CONTABILE.esercizio
	
--	and exists ( select * from fattura_dettaglio DETTFATT
--	where  F.esercizio  = DETTFATT.esercizio AND F.bilancio  = DETTFATT.bilancio 
--	and  F.NUMERO_FATTURA = DETTFATT.NUMERO_FATTURA
--	AND DETTFATT.chiave_impegno = CURR_DOCUMENTO_CONTABILE.CHIAVE_COMPLETA_DOCUMENTO )
 
WHERE CURR_DOCUMENTO_CONTABILE.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
	AND CURR_DOCUMENTO_CONTABILE.TIPO  = 'IMPEGNO' 
	AND lookup_movfin.nphase=1
	AND lookup_movfin.kind='S'
	AND D_OLD.numero_versione=0		
	AND lookup_upb.BILANCIO=@bilancio
	order by 
	CURR_DOCUMENTO_CONTABILE.TIPO, 
	CURR_DOCUMENTO_CONTABILE.ESERCIZIO,
	lookup_movfin.ymov, 
	lookup_movfin.nmov
END

 
GO

