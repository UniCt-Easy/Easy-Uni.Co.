
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



/****** Object:  StoredProcedure [dbo].[exp_classificazioni_miur_siope]    Script Date: 27/11/2013 10.05.40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--- [exp_classificazioni_miur_siope] 'A.ammce'
CREATE PROCEDURE [dbo].[exp_classificazioni_miur_siope] 
(
	@bilancio varchar(120) 
)
AS BEGIN

/*
  string[] tracciato_classmov = new string[]{
            "tipo;Tipo movimento (E=Entrata,S=Spesa);Codificato;1;E|S",
            "nliv;Numero fase movimento;Intero;1",
            "descliv;Descrizione fase movimento;Stringa;50",
            "ymov;Esercizio movimento;Intero;4",
            "nmov;Numero movimento;Intero;8",
            "amount;Importo variazione;Numero;22",
            "codesorkind;Codice tipo classificazione;Stringa;20",
            "sortcode;Codice classificazione;Stringa;50",
            "description;Descrizione voce classificazione;Stringa;200",
            "ayear;Anno di imputazione della classificazione;Intero;4"
        };
        */
        
--  CREATE TABLE #tracciato_classificazioni
--(
--	 tipo			 char(1),		-- entrata o spesa M o R
--	 nliv			 int,			-- fase entrata o spesa
--	 descliv		 varchar(50),	-- Descrizione fase movimento
--	 ymov			 int,			-- anno movimento
--	 nmov			 int,			-- numero movimento
--	 amount			 decimal(19,2),	-- importo classificato
--	 codesorkind	 varchar(20),	-- codice tipo classificazione
--	 sortcode		 varchar(50),	-- codice voce classificazione
--	 description	 varchar(200),  -- descrizione voce classificazione
--	 ayear			 int			--esercizio classificazione
--	 )
	 
--	 -- si possono usare le stesse classficaziono SIOPE E MIUR come configurate in Easy
--INSERT INTO  #tracciato_classificazioni
--(
--	 tipo			,		-- entrata o spesa M o R
--	 nliv			,		-- fase entrata o spesa
--	 descliv		,		-- Descrizione fase movimento
--	 ymov			,		-- anno movimento
--	 nmov			,		-- numero movimento
--	 amount			,		-- importo classificato
--	 codesorkind	,		-- codice tipo classificazione
--	 sortcode		,		-- codice voce classificazione
--	 description	,		-- descrizione voce classificazione
--	 ayear					-- esercizio classificazione
--)

SELECT
'E' as tipo,
'1' nliv,
'PreAccertamento' as descliv,
lookup_movfin.ymov as ymov,
lookup_movfin.nmov as nmov,
CONVERT(decimal(19,2),CASE WHEN D_new.esercizio>=2002 then D_new.AMMONTARE else ROUND(D_new.ammontare/1936.27,2) end) AS amount,
'07E_MIUR' as codesorkind,
CONVERT(varchar, GRUPPO.chiave) as sortcode,
GRUPPO.DESCRIZIONE as description,
D.ESERCIZIO  as ayear
FROM CURR_DOCUMENTO_CONTABILE D
left outer JOIN  DOCUMENTO_CONTABILE D_new
	ON  D_new.bilancio = D.bilancio
         AND D_new.esercizio=D.esercizio 
         AND D_new.chiave_completa_documento=D.chiave_completa_documento 
JOIN lookup_movfin 
	ON  D.CHIAVE_COMPLETA_DOCUMENTO = lookup_movfin.CHIAVE_COMPLETA_DOCUMENTO
		AND D.BILANCIO = lookup_movfin.BILANCIO
		AND D.ESERCIZIO = lookup_movfin.ESERCIZIO
JOIN GRUPPO ON
D.CODICE_GESTIONALE  = GRUPPO.CHIAVE_COMPLETA
AND GRUPPO.CHIAVE_PIANO_GRUPPI = 'G' 
WHERE D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
AND D.CODICE_GESTIONALE is not null 
AND D.TIPO = 'ACCERTAMENTO'
AND lookup_movfin.nphase=1
AND lookup_movfin.kind='E'
--AND D_OLD.numero_versione=0
 AND NOT EXISTS (select * from DOCUMENTO_CONTABILE D1 where
       D1.chiave_completa_documento=D_new.chiave_completa_documento
       and D1.bilancio = D_new.bilancio
       and D1.esercizio=D_new.esercizio
       and D1.numero_versione > D_new.numero_versione)

UNION ALL

SELECT
'S' as tipo,
'1' nliv,
'PreImpegno' as descliv,
lookup_movfin.ymov as ymov,
lookup_movfin.nmov as nmov,
CONVERT(decimal(19,2),CASE WHEN D_new.esercizio>=2002 then D_new.AMMONTARE else ROUND(D_new.ammontare/1936.27,2) end) AS amount,
'07U_MIUR' as codesorkind,
CONVERT(varchar, GRUPPO.chiave) as sortcode,
GRUPPO.DESCRIZIONE as description,
D.ESERCIZIO  as ayear
FROM CURR_DOCUMENTO_CONTABILE D
JOIN GRUPPO 
		ON	D.CODICE_GESTIONALE  = GRUPPO.CHIAVE_COMPLETA
		AND GRUPPO.CHIAVE_PIANO_GRUPPI = 'G' 
left outer JOIN  DOCUMENTO_CONTABILE D_new
	ON  D_new.bilancio = D.bilancio
         AND D_new.esercizio=D.esercizio 
         AND D_new.chiave_completa_documento=D.chiave_completa_documento 
JOIN lookup_movfin 
	ON  D.CHIAVE_COMPLETA_DOCUMENTO = lookup_movfin.CHIAVE_COMPLETA_DOCUMENTO
		AND D.BILANCIO = lookup_movfin.BILANCIO
		AND D.ESERCIZIO = lookup_movfin.ESERCIZIO 
WHERE D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
AND D.CODICE_GESTIONALE is not null 
AND D.TIPO = 'IMPEGNO'
AND lookup_movfin.nphase=1
AND lookup_movfin.kind='S'
--AND D_OLD.numero_versione=0
 AND NOT EXISTS (select * from DOCUMENTO_CONTABILE D1 where
       D1.chiave_completa_documento=D_new.chiave_completa_documento
       and D1.bilancio = D_new.bilancio
       and D1.esercizio=D_new.esercizio
       and D1.numero_versione > D_new.numero_versione)

UNION ALL

SELECT
 'E'  as tipo,
 3 as nliv,
 'Incasso' as descliv,
LK.ymov as ymov,
LK.nmov as nmov,
CONVERT(decimal(19,2),CASE when RDD.esercizio>=2002 then RDD.AMMONTARE else ROUND(RDD.ammontare/1936.27,2) end) as amount, 
'07E_SIOPE' as codesorkind,
CONVERT(varchar, GRUPPO.chiave) as sortcode,
GRUPPO.DESCRIZIONE as description,
D.ESERCIZIO  as ayear
FROM CURR_DOCUMENTO_CONTABILE D
JOIN GRUPPO 
		ON	D.CODICE_GESTIONALE  = GRUPPO.CHIAVE_COMPLETA
		AND GRUPPO.CHIAVE_PIANO_GRUPPI = 'G' 
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND	  RDD.BILANCIO = D.BILANCIO
		AND	  RDD.STATO = 'A'
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
WHERE	D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
		AND D.TIPO  = 'REVERSALE' 
		AND D.CODICE_GESTIONALE is not null 
UNION ALL

SELECT
'S'  as tipo,
3 as nliv,
'Liquidazione' as descliv,
LK.ymov as ymov,
LK.nmov as nmov,
CONVERT(decimal(19,2),CASE when RDD.esercizio>=2002 then RDD.AMMONTARE else ROUND(RDD.ammontare/1936.27,2) end) as amount, 
'07U_SIOPE' as codesorkind,
CONVERT(varchar, GRUPPO.chiave) as sortcode,
GRUPPO.DESCRIZIONE as description,
D.ESERCIZIO  as ayear
FROM CURR_DOCUMENTO_CONTABILE D
JOIN GRUPPO 
		ON	D.CODICE_GESTIONALE  = GRUPPO.CHIAVE_COMPLETA
		AND GRUPPO.CHIAVE_PIANO_GRUPPI = 'G' 
LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
		ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = D.esercizio
		AND	  RDD.BILANCIO = D.BILANCIO
		AND	  RDD.STATO = 'A'
JOIN CURR_DOCUMENTO_CONTABILE PADRE
		ON    RDD.CHIAVE_COMPLETA_DOC_PADRE = PADRE.CHIAVE_COMPLETA_DOCUMENTO
		and   RDD.esercizio = PADRE.esercizio
		AND RDD.BILANCIO = PADRE.BILANCIO
JOIN lookup_movfin LK
		ON  D.CHIAVE_COMPLETA_DOCUMENTO = LK.CHIAVE_COMPLETA_DOCUMENTO
		AND RDD.CHIAVE_COMPLETA_DOC_PADRE =LK.CHIAVE_COMPLETA_PADRE
		AND D.BILANCIO = LK.BILANCIO
		AND D.ESERCIZIO = LK.ESERCIZIO 
		and LK.kind='S'
		AND LK.nphase = 3
WHERE	D.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
		AND D.TIPO  = 'MANDATO' 
		AND D.CODICE_GESTIONALE is not null
--ORDER BY D.TIPO, D.ESERCIZIO, D.CHIAVE_COMPLETA_DOCUMENTO

--SELECT * FROM #tracciato_classificazioni

END

GO

