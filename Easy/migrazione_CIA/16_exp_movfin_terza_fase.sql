if exists (select * from dbo.sysobjects where id = object_id(N'[exp_movfin_terza_fase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_movfin_terza_fase]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--- [exp_movfin_terza_fase] 'A.ammce'
CREATE PROCEDURE [exp_movfin_terza_fase] 
(
	@bilancio varchar(120) 
)
AS BEGIN
/*
		prende bilancio, upb da prima fase
		prende anagrafica da seconda fase
		prende importo da relazione 
		prende numero parent da lookup della prima fase
				
		
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
 'E'  as tipo,
 3 as nliv,
 'Incasso' as descliv,
 'S' as last,
  LK.ymov as ymov,
 LK.nmov,
 LK_padre.ymov as parentymov,
 LK_padre.nmov as parentnmov,
 isnull( D.DESCRIZIONE, '.') AS description,   
 NULL AS doc,
 NULL AS docdate,
 D.DATA_CONTABILIZZAZIONE as adate,
 lookup_anagrafica.idreg as idreg,
 null as resp,
 D.ESERCIZIO as ayear,
 CONVERT(decimal(19,2),CASE when RDD.esercizio>=2002 then RDD.AMMONTARE else ROUND(RDD.ammontare/1936.27,2) end) as amount, 
 lookup_upb.codeupb AS codiceupb,
 lookup_bilancio.codefin  as codicebil,
 CONVERT(INT,SUBSTRING(D.CHIAVE , 6, LEN(D.CHIAVE))) AS nmanrev,
 null AS cc,
 null AS cin,
 null AS iban,
 null AS idbank,
 null AS idcab,
 null AS paymentdescr,
 null AS note,
 null AS nbill,
 substring(ltrim(rtrim(D.cig)),1,10) as cig ,
 substring(ltrim(rtrim(D.cup)),1,15) as cup,
 lk.nsub as nsub
 
FROM  CURR_DOCUMENTO_CONTABILE D
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND	  RDD.BILANCIO = D.BILANCIO
JOIN CURR_DOCUMENTO_CONTABILE PADRE
		ON    RDD.CHIAVE_COMPLETA_DOC_PADRE = PADRE.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = PADRE.esercizio
		AND RDD.BILANCIO = PADRE.BILANCIO
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RDD.CHIAVE_COMPLETA_DOC_PADRE =LK.CHIAVE_COMPLETA_PADRE
		AND D.BILANCIO = LK.BILANCIO
		AND D.ESERCIZIO = LK.ESERCIZIO 
		and LK.kind='E'
		AND LK.nphase = 3
JOIN lookup_movfin LK_padre
		ON	LK.CHIAVE_COMPLETA_DOCUMENTO = LK_padre.CHIAVE_COMPLETA_DOCUMENTO
			AND	LK.CHIAVE_COMPLETA_PADRE =LK_padre.CHIAVE_COMPLETA_PADRE
			AND LK.BILANCIO = LK_padre.BILANCIO
			AND LK.ESERCIZIO = LK_padre.ESERCIZIO 
			and LK_padre.kind='E'
			AND LK_padre.nphase = 2		
LEFT OUTER JOIN   lookup_anagrafica
		ON  lookup_anagrafica.codice = D.CODICE_ANAG
LEFT OUTER JOIN   lookup_bilancio
		ON  lookup_bilancio.chiave_completa = PADRE.CHIAVE_CONTO
LEFT OUTER JOIN   lookup_upb
		ON  lookup_upb.chiave_completa = PADRE.UNITA_ORGANIZZATIVA
WHERE	D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
		AND D.TIPO  = 'REVERSALE' 


UNION ALL

SELECT
 'S'  as tipo,
 3 as nliv,
 'Pagamento' as descliv,
 'S' as last,
  LK.ymov as ymov,  
 LK.nmov,
 LK_padre.ymov as parentymov,
 LK_padre.nmov as parentnmov,
 isnull( D.DESCRIZIONE, '.') AS description, 
 NULL AS doc,
 NULL AS docdate,
 D.DATA_CONTABILIZZAZIONE as adate,
 lookup_anagrafica.idreg as idreg,
 null as resp,
 D.ESERCIZIO as ayear,
 CONVERT(decimal(19,2),CASE WHEN RDD.esercizio>=2002 then RDD.AMMONTARE else ROUND(RDD.ammontare/1936.27,2) end) AS amount,
 lookup_upb.codeupb AS codiceupb,
 lookup_bilancio.codefin  as codicebil,
 CONVERT(INT,SUBSTRING(D.CHIAVE,6, LEN(D.CHIAVE ))) as nmanrev,
 D.numero_conto_cliente_fornitore  AS cc,
 D.CIN  AS cin,
 D.IBAN  AS iban,
 D.abi_cliente_fornitore AS idbank,
 D.cab_cliente_fornitore AS idcab,
 D.MODALITA_PAGAMENTO AS paymentdescr,
 null AS note,
 null AS nbill,
 substring(ltrim(rtrim(D.cig)),1,10) as cig ,
 substring(ltrim(rtrim(D.cup)),1,15) as cup,
 lk.nsub as nsub
FROM  CURR_DOCUMENTO_CONTABILE D
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND	  RDD.BILANCIO = D.BILANCIO
JOIN  CURR_DOCUMENTO_CONTABILE PADRE
		ON    RDD.CHIAVE_COMPLETA_DOC_PADRE = PADRE.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = PADRE.esercizio
		AND	  RDD.BILANCIO = PADRE.BILANCIO
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RDD.CHIAVE_COMPLETA_DOC_PADRE =LK.CHIAVE_COMPLETA_PADRE
		AND D.BILANCIO = LK.BILANCIO
		AND D.ESERCIZIO = LK.ESERCIZIO 
		and LK.kind='S'
		AND LK.nphase = 3
JOIN lookup_movfin LK_padre
		ON	LK.CHIAVE_COMPLETA_DOCUMENTO = LK_padre.CHIAVE_COMPLETA_DOCUMENTO
			AND	LK.CHIAVE_COMPLETA_PADRE =LK_padre.CHIAVE_COMPLETA_PADRE
			AND LK.BILANCIO = LK_padre.BILANCIO
			AND LK.ESERCIZIO = LK_padre.ESERCIZIO 
			and LK_padre.kind='S'
			AND LK_padre.nphase = 2		
LEFT OUTER JOIN   lookup_anagrafica
		ON  lookup_anagrafica.codice = D.CODICE_ANAG
LEFT OUTER JOIN   lookup_bilancio
		ON  lookup_bilancio.chiave_completa = PADRE.CHIAVE_CONTO
LEFT OUTER JOIN   lookup_upb
		ON  lookup_upb.chiave_completa = PADRE.UNITA_ORGANIZZATIVA
WHERE	D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
		AND D.TIPO  = 'MANDATO' 
 ORDER BY tipo, D.ESERCIZIO, D.DATA_CONTABILIZZAZIONE


END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 