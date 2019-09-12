if exists (select * from dbo.sysobjects where id = object_id(N'[exp_varazzeramento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_varazzeramento]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--	EXEC exp_varazzeramento 'A.AMMCE'
--  EXEC exp_varazzeramento  null

/*
   "tipo;Tipo var. movimento (E=Var.Entrata,S=Var.Spesa);Codificato;1;E|S",
            "nliv;Numero fase movimento;Intero;1",
            "descliv;Descrizione fase movimento;Stringa;50",
            "ymov;Esercizio movimento;Intero;4",
            "nmov;Numero movimento;Intero;8",
            "yvar;Esercizio variazione;Intero;4",
            "nvar;Numero variazione;Intero;8",
            "description;Descrizione;Stringa;150",
            "doc;Documento;Stringa;35",
            "docdate;Data documento;Data;8",
            "adate;Data Contabile;Data;8",
            "amount;Importo variazione;Numero;22",
            "numelenco;Numero elenco di trasmissione;Intero;6",
            "datatrasmissione;Data documento;Data;8",
*/
CREATE      PROCEDURE [exp_varazzeramento]
(
	@bilancio varchar(120) 
)

AS BEGIN

;with numerovariazione (numvar, esercizio, bilancio, CHIAVE_COMPLETA_DOCUMENTO)
as 
(select count(*)+1, D.esercizio, D.bilancio, D.CHIAVE_COMPLETA_DOCUMENTO
from DOCUMENTO_CONTABILE D
where bilancio = @bilancio
AND exists (select *  from documento_contabile D2 
      where		D2.chiave_completa_documento  = D.chiave_completa_documento
			and D2.bilancio = D.bilancio 
			and D2.esercizio=D.esercizio
			AND D2.numero_versione = D.numero_versione +1
			and isnull(D2.ammontare,0) <> isnull(D.AMMONTARE,0))
group by D.esercizio, D.bilancio, D.CHIAVE_COMPLETA_DOCUMENTO
)
 --Variazioni di Azzeramento 1 ° fase ENTRATA/SPESA
select 
	LK.kind as 'tipo',
	LK.nphase as 'nliv',
	CASE
		WHEN D.TIPO = 'ACCERTAMENTO' THEN 'PreAccertamento' 
		WHEN D.TIPO = 'IMPEGNO' THEN 'Impegno' 
	END as 'descliv',
	LK.ymov as 'ymov',
	LK.nmov as 'nmov',
	D.ESERCIZIO as 'yvar',
	ISNULL(NV.numvar,1) as 'nvar',
	ISNULL(D.DESCRIZIONE,'Variazione di Azzeramento') AS 'description',
	NULL AS 'doc',
	NULL AS 'docdate',
	D.data_storno as 'adate',
	CONVERT(decimal(19,2),CASE WHEN D.esercizio>=2002 THEN - isnull(D.ammontare,0)
	ELSE ROUND(isnull(-D.ammontare,0)/1936.27,2) END) 
	AS 'amount',
	null  as numelenco,
	null  as datatrasmissione
from curr_documento_contabile D  
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
			AND D.BILANCIO = LK.BILANCIO
			AND D.ESERCIZIO = LK.ESERCIZIO
			AND LK.nphase = 1
LEFT OUTER JOIN numerovariazione NV
		on NV.chiave_completa_documento = D.chiave_completa_documento
		and NV.bilancio = D.bilancio 
		and NV.esercizio = D.esercizio
 where 
	D.data_storno is not null
	and isnull(D.ammontare,0)<>0
	AND D.BILANCIO = @bilancio 

UNION ALL
-- Variazioni di Azzeramento 2 ° fase ENTRATA
select 
	LK.kind as 'tipo',
	LK.nphase as 'nliv',
	'Accertamento' as descliv,
	LK.ymov as 'ymov',
	LK.nmov as 'nmov',
	D.ESERCIZIO as 'yvar',
	ISNULL(NV.numvar,1)  as 'nvar',
	ISNULL(D.DESCRIZIONE,'Variazione di Azzeramento') AS 'description',
	NULL AS 'doc',
	NULL AS 'docdate',
	D.data_storno as 'adate',
	CONVERT(decimal(19,2),CASE WHEN RDD.esercizio>=2002 THEN - isnull(RDD.ammontare,0)
	ELSE ROUND(isnull(-RDD.ammontare,0)/1936.27,2) END) 
	AS 'amount',
	null  as numelenco,
	null  as datatrasmissione
FROM  CURR_DOCUMENTO_CONTABILE D
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND RDD.BILANCIO = D.BILANCIO
JOIN CURR_DOCUMENTO_CONTABILE PADRE
		ON    RDD.CHIAVE_COMPLETA_DOC_PADRE = PADRE.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = PADRE.esercizio
		AND RDD.BILANCIO = PADRE.BILANCIO
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RDD.CHIAVE_COMPLETA_DOC_PADRE = LK.CHIAVE_COMPLETA_PADRE
		AND D.BILANCIO = LK.BILANCIO
		AND D.ESERCIZIO = LK.ESERCIZIO 
		AND LK.nphase = 2
		and LK.kind='E'
LEFT OUTER JOIN numerovariazione NV
		on NV.chiave_completa_documento = D.chiave_completa_documento
		and NV.bilancio = D.bilancio 
		and NV.esercizio = D.esercizio
WHERE   D.BILANCIO = @bilancio  
		AND D.TIPO  = 'REVERSALE' 
		AND D.data_storno is not null
		and isnull(RDD.ammontare,0)<>0

UNION ALL
-- Variazioni di Azzeramento 2 ° fase SPESA
select 
	LK.kind as 'tipo',
	LK.nphase as 'nliv',
	'Liquidazione' as descliv,
	LK.ymov as 'ymov',
	LK.nmov as 'nmov',
	LK.ymov as 'yvar',
	ISNULL(NV.numvar,1)  as 'nvar',
	ISNULL(D.DESCRIZIONE,'Variazione di Azzeramento') AS 'description',
	NULL AS 'doc',
	NULL AS 'docdate',
	D.data_storno as 'adate',
	CONVERT(decimal(19,2),CASE WHEN RDD.esercizio>=2002 THEN - isnull(RDD.ammontare,0)
	ELSE ROUND(isnull(-RDD.ammontare,0)/1936.27,2) END) 
	AS 'amount',
	null  as numelenco,
	null  as datatrasmissione
FROM  CURR_DOCUMENTO_CONTABILE D
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND RDD.BILANCIO = D.BILANCIO
JOIN CURR_DOCUMENTO_CONTABILE PADRE
		ON    RDD.CHIAVE_COMPLETA_DOC_PADRE = PADRE.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = PADRE.esercizio
		AND RDD.BILANCIO = PADRE.BILANCIO
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RDD.CHIAVE_COMPLETA_DOC_PADRE = LK.CHIAVE_COMPLETA_PADRE
		AND D.BILANCIO = LK.BILANCIO
		AND D.ESERCIZIO = LK.ESERCIZIO 
		AND LK.nphase = 2
		and LK.kind='S'
LEFT OUTER JOIN numerovariazione NV
		on NV.chiave_completa_documento = D.chiave_completa_documento
		and NV.bilancio = D.bilancio 
		and NV.esercizio = D.esercizio
WHERE   D.BILANCIO = @bilancio  
		AND D.TIPO  = 'MANDATO' 
		AND	D.data_storno is not null
		and isnull(RDD.ammontare,0)<>0

UNION ALL
-- Variazioni di Azzeramento 3  fase ENTRATA
select 
	LK.kind as 'tipo',
	LK.nphase as 'nliv',
	'Incasso' as descliv,
	LK.ymov as 'ymov',
	LK.nmov as 'nmov',
	LK.ymov as 'yvar',
	ISNULL(NV.numvar,1)  as 'nvar',
	ISNULL(D.DESCRIZIONE,'Variazione di Azzeramento') AS 'description',
	NULL AS 'doc',
	NULL AS 'docdate',
	D.data_storno as 'adate',
	CONVERT(decimal(19,2),CASE WHEN RDD.esercizio>=2002 THEN - isnull(RDD.ammontare,0)
	ELSE ROUND(isnull(-RDD.ammontare,0)/1936.27,2) END) 
	AS 'amount',
	(select top 1 chiave from distinta T  
		where D.bilancio = T.bilancio 
		AND D.esercizio = T.esercizio 
		AND  T.DACR >= D.DATA_STORNO
		AND D.DATA_STORNO IS NOT NULL
		AND D.DATA_TRASMISSIONE IS NOT NULL
		AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_S_ENTRATE)  <>0
     order by CONVERT (INT,T.CHIAVE) asc
	 )  as numelenco,
	 (select top 1 ISNULL(T.DATA,T.DACR) from distinta T  
		where D.bilancio = T.bilancio 
		AND D.esercizio = T.esercizio 
		AND  T.DACR >= D.DATA_STORNO
		AND D.DATA_STORNO IS NOT NULL
		AND D.DATA_TRASMISSIONE IS NOT NULL
		AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_S_ENTRATE)  <>0
     order by CONVERT (INT,T.CHIAVE) asc
	 )  as datatrasmissione
FROM  CURR_DOCUMENTO_CONTABILE D
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND RDD.BILANCIO = D.BILANCIO
JOIN CURR_DOCUMENTO_CONTABILE PADRE
		ON    RDD.CHIAVE_COMPLETA_DOC_PADRE = PADRE.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = PADRE.esercizio
		AND RDD.BILANCIO = PADRE.BILANCIO
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RDD.CHIAVE_COMPLETA_DOC_PADRE = LK.CHIAVE_COMPLETA_PADRE
		AND D.BILANCIO = LK.BILANCIO
		AND D.ESERCIZIO = LK.ESERCIZIO 
		AND LK.nphase = 3
		and LK.kind='E'
LEFT OUTER JOIN numerovariazione NV
		on NV.chiave_completa_documento = D.chiave_completa_documento
		and NV.bilancio = D.bilancio 
		and NV.esercizio = D.esercizio
WHERE   D.BILANCIO = @bilancio
		AND D.TIPO  = 'REVERSALE' 
		AND D.data_storno is not null
		and isnull(RDD.ammontare,0)<>0
UNION ALL
-- Variazioni di Azzeramento 3°  fase SPESA
select 
	LK.kind as 'tipo',
	LK.nphase as 'nliv',
	'Pagamento' as descliv,
	LK.ymov as 'ymov',
	LK.nmov as 'nmov',
	LK.ymov as 'yvar',
	ISNULL(NV.numvar,1)  as 'nvar',
	ISNULL(D.DESCRIZIONE,'Variazione di Azzeramento') AS 'description',
	NULL AS 'doc',
	NULL AS 'docdate',
	D.data_storno as 'adate',
	CONVERT(decimal(19,2),CASE WHEN RDD.esercizio>=2002 THEN - isnull(RDD.ammontare,0)
	ELSE ROUND(isnull(-RDD.ammontare,0)/1936.27,2) END) 
	AS 'amount',
	(select top 1 chiave from distinta T  
		where D.bilancio = T.bilancio 
		AND D.esercizio = T.esercizio 
		AND  T.DACR >= D.DATA_STORNO
		AND D.DATA_STORNO IS NOT NULL
		AND D.DATA_TRASMISSIONE IS NOT NULL
		AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_S_SPESE)  <>0
     order by CONVERT (INT,T.CHIAVE) asc
	 )  as numelenco,
	 (select top 1 ISNULL(T.DATA,T.DACR) from distinta T  
		where D.bilancio = T.bilancio 
		AND D.esercizio = T.esercizio 
		AND  T.DACR >= D.DATA_STORNO
		AND D.DATA_STORNO IS NOT NULL
		AND D.DATA_TRASMISSIONE IS NOT NULL
		AND CONVERT(DECIMAL(19,2), T.TOTALE_GIORNATA_S_SPESE)  <>0
     order by CONVERT (INT,T.CHIAVE) asc
	 )  as datatrasmissione
FROM  CURR_DOCUMENTO_CONTABILE D
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND RDD.BILANCIO = D.BILANCIO
JOIN CURR_DOCUMENTO_CONTABILE PADRE
		ON    RDD.CHIAVE_COMPLETA_DOC_PADRE = PADRE.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = PADRE.esercizio
		AND RDD.BILANCIO = PADRE.BILANCIO
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RDD.CHIAVE_COMPLETA_DOC_PADRE = LK.CHIAVE_COMPLETA_PADRE
		AND D.BILANCIO = LK.BILANCIO
		AND D.ESERCIZIO = LK.ESERCIZIO 
		AND LK.nphase = 3
		and LK.kind='S'
LEFT OUTER JOIN numerovariazione NV
		on NV.chiave_completa_documento = D.chiave_completa_documento
		and NV.bilancio = D.bilancio 
		and NV.esercizio = D.esercizio
WHERE   D.BILANCIO = @bilancio 
		AND D.TIPO  = 'MANDATO' 
		AND D.data_storno is not null
		and isnull(RDD.ammontare,0)<>0
order by 	LK.kind, LK.nphase, LK.ymov, LK.nmov
END

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*                           tipo: Pos.    0 lunghezza    1 Tipo:      Codificato Codifica:E|S Descrizione: Tipo var. movimento (E=Var.Entrata,S=Var.Spesa)
                          nliv: Pos.    1 lunghezza    1 Tipo:          Intero Descrizione: Numero fase movimento
                       descliv: Pos.    2 lunghezza   50 Tipo:         Stringa Descrizione: Descrizione fase movimento
                          ymov: Pos.   52 lunghezza    4 Tipo:          Intero Descrizione: Esercizio movimento
                          nmov: Pos.   56 lunghezza    8 Tipo:          Intero Descrizione: Numero movimento
                          yvar: Pos.   64 lunghezza    4 Tipo:          Intero Descrizione: Esercizio variazione
                          nvar: Pos.   68 lunghezza    8 Tipo:          Intero Descrizione: Numero variazione
                   description: Pos.   76 lunghezza  150 Tipo:         Stringa Descrizione: Descrizione
                           doc: Pos.  226 lunghezza   35 Tipo:         Stringa Descrizione: Documento
                       docdate: Pos.  261 lunghezza    8 Tipo:            Data Descrizione: Data documento
                         adate: Pos.  269 lunghezza    8 Tipo:            Data Descrizione: Data Contabile
                        amount: Pos.  277 lunghezza   22 Tipo:          Numero Descrizione: Importo variazione
                     numelenco: Pos.  299 lunghezza    6 Tipo:          Intero Descrizione: Numero elenco di trasmissione
*/