
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_varnormali]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_varnormali]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--	EXEC exp_varnormali 'A.AMMCE'

CREATE      PROCEDURE [exp_varnormali]
(
	@bilancio varchar(120) 
)

AS BEGIN


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
select 
 D.ESERCIZIO,D.CHIAVE_COMPLETA_DOCUMENTO, D.NUMERO_VERSIONE,
 lookup_movfin.kind as 'tipo',
 lookup_movfin.nphase as 'nliv',
 'PreAccertamento' as 'descliv',
 lookup_movfin.ymov as 'ymov',
 lookup_movfin.nmov as 'nmov',
  D.ESERCIZIO as 'yvar',
ROW_NUMBER() OVER(PARTITION BY  D.TIPO, lookup_movfin.nmov,lookup_movfin.ymov
      ORDER BY   D.CHIAVE_COMPLETA_DOCUMENTO, D.ESERCIZIO, D.NUMERO_VERSIONE) as 'nvar',
case when COALESCE(rtrim(ltrim(D.DESCRIZIONE)),rtrim(ltrim(D_OLD.DESCRIZIONE)),'Variazione') ='' then 'Variazione'
else COALESCE(rtrim(ltrim(D.DESCRIZIONE)),rtrim(ltrim(D_OLD.DESCRIZIONE)),'Variazione')
end AS 'description',
 NULL AS 'doc',
 NULL AS 'docdate',
 D.data_versione as 'adate',
 CONVERT(decimal(19,2),CASE 
	WHEN D.esercizio >= 2002 THEN (isnull(D.ammontare,0)  - ISNULL(D_OLD.AMMONTARE,0))
	ELSE   ROUND((ISNULL(D.ammontare,0)  - ISNULL(D_OLD.ammontare,0))/1936.27,2)
 END) as amount,
 null as 'numelenco'
FROM DOCUMENTO_CONTABILE  D   --(nuova versione)
JOIN  DOCUMENTO_CONTABILE D_OLD
	ON  D_OLD.bilancio = D.bilancio
         and D_OLD.esercizio=D.esercizio
         AND D_OLD.chiave_completa_documento=D.chiave_completa_documento 
         AND D_old.numero_versione  = D.numero_versione-1
 JOIN lookup_movfin
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = lookup_movfin.CHIAVE_COMPLETA_DOCUMENTO
		AND D.BILANCIO = lookup_movfin.BILANCIO
		AND D.ESERCIZIO = lookup_movfin.ESERCIZIO
		AND lookup_movfin.nphase = 1
		AND lookup_movfin.kind = 'E'
 WHERE  D.TIPO  = 'ACCERTAMENTO' 
		AND ISNULL(D_OLD.AMMONTARE,0) <> ISNULL(D.AMMONTARE,0)
		AND D.BILANCIO = @bilancio
 union all
select 
 D.ESERCIZIO,D.CHIAVE_COMPLETA_DOCUMENTO, D.NUMERO_VERSIONE,
 lookup_movfin.kind as 'tipo',
 lookup_movfin.nphase as 'nliv',
 'Impegno' as 'descliv',
 lookup_movfin.ymov as 'ymov',
 lookup_movfin.nmov as 'nmov',
 D.ESERCIZIO  as 'yvar',
ROW_NUMBER()  OVER(PARTITION BY  D.TIPO,  lookup_movfin.nmov,lookup_movfin.ymov
      ORDER BY   D.CHIAVE_COMPLETA_DOCUMENTO, D.ESERCIZIO, D.NUMERO_VERSIONE) as 'nvar',
case when COALESCE(rtrim(ltrim(D.DESCRIZIONE)),rtrim(ltrim(D_OLD.DESCRIZIONE)),'Variazione' ) ='' then 'Variazione'
else COALESCE(rtrim(ltrim(D.DESCRIZIONE)),rtrim(ltrim(D_OLD.DESCRIZIONE)),'Variazione' ) 
end AS 'description',
 NULL AS 'doc',
 NULL AS 'docdate',
 D.data_versione as 'adate',
 CONVERT(decimal(19,2),CASE 
	WHEN D.esercizio >= 2002 THEN (isnull(D.ammontare,0)  - ISNULL(D_OLD.AMMONTARE,0))
	ELSE	ROUND((ISNULL(D.ammontare,0)  - ISNULL(D_OLD.ammontare,0))/1936.27,2)
 END) as amount,
 null as 'numelenco'
FROM DOCUMENTO_CONTABILE  D
JOIN  DOCUMENTO_CONTABILE D_OLD
	ON  D_OLD.bilancio = D.bilancio
         and D_OLD.esercizio=D.esercizio
         AND D_OLD.chiave_completa_documento=D.chiave_completa_documento 
         AND D_old.numero_versione  = D.numero_versione-1
 JOIN lookup_movfin
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = lookup_movfin.CHIAVE_COMPLETA_DOCUMENTO
		AND D.BILANCIO = lookup_movfin.BILANCIO
		AND D.ESERCIZIO = lookup_movfin.ESERCIZIO
		AND lookup_movfin.nphase = 1
		AND lookup_movfin.kind = 'S'
 WHERE  D.TIPO  = 'IMPEGNO' 
 AND ISNULL(D_OLD.AMMONTARE,0) <> ISNULL(D.AMMONTARE,0)
 AND D.BILANCIO = @bilancio 
 --AND lookup_movfin.nmov = 3525 and  lookup_movfin.ymov = 2000
 
 ORDER BY   D.ESERCIZIO, D.CHIAVE_COMPLETA_DOCUMENTO, D.NUMERO_VERSIONE
 
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
