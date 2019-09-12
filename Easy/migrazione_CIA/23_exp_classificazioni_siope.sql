
/****** Object:  StoredProcedure [dbo].[exp_classificazioni_siope]    Script Date: 27/11/2013 10.06.05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--- [exp_classificazioni_miur_siope] 'A.ammce'
CREATE PROCEDURE [dbo].[exp_classificazioni_siope] 
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
        
  CREATE TABLE #tracciato_classificazioni
(
	 tipo			 char(1),		-- entrata o spesa M o R
	 nliv			 int,			-- fase entrata o spesa
	 descliv		 varchar(50),	-- Descrizione fase movimento
	 ymov			 int,			-- anno movimento
	 nmov			 int,			-- numero movimento
	 amount			 decimal(19,2),	-- importo classificato
	 codesorkind	 varchar(20),	-- codice tipo classificazione
	 sortcode		 varchar(50),	-- codice voce classificazione
	 description	 varchar(200),  -- descrizione voce classificazione
	 ayear			 int			--esercizio classificazione
	 )
	 
	 -- si possono usare le stesse classficaziono SIOPE E MIUR come configurate in Easy
INSERT INTO  #tracciato_classificazioni
(
	 tipo			,		-- entrata o spesa M o R
	 nliv			,		-- fase entrata o spesa
	 descliv		,		-- Descrizione fase movimento
	 ymov			,		-- anno movimento
	 nmov			,		-- numero movimento
	 amount			,		-- importo classificato
	 codesorkind	,		-- codice tipo classificazione
	 sortcode		,		-- codice voce classificazione
	 description	,		-- descrizione voce classificazione
	 ayear					-- esercizio classificazione
)

SELECT
CASE	
	WHEN DOCUMENTO_CONTABILE.TIPO = 'ACCERTAMENTO'  THEN 'E'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'REVERSALE'     THEN 'E'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'IMPEGNO'		THEN 'S'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'MANDATO'       THEN 'S'
END,
CASE	
	WHEN DOCUMENTO_CONTABILE.TIPO = 'ACCERTAMENTO'  THEN 1
	WHEN DOCUMENTO_CONTABILE.TIPO = 'REVERSALE'     THEN 2
	WHEN DOCUMENTO_CONTABILE.TIPO = 'IMPEGNO'		THEN 1
	WHEN DOCUMENTO_CONTABILE.TIPO = 'MANDATO'       THEN 2
END,
CASE	
	WHEN DOCUMENTO_CONTABILE.TIPO = 'ACCERTAMENTO'  THEN 'ACCERTAMENTO'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'REVERSALE'     THEN 'RIGA DI REVERSALE'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'IMPEGNO'		THEN 'IMPEGNO'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'MANDATO'       THEN 'RIGA DI MANDATO'
END,
DOCUMENTO_CONTABILE.ESERCIZIO,
CONVERT(INT,SUBSTRING(DOCUMENTO_CONTABILE.CHIAVE, 6, LEN(DOCUMENTO_CONTABILE.CHIAVE) +1)),
CONVERT(DECIMAL(19,2),DOCUMENTO_CONTABILE.AMMONTARE),
CASE	
	WHEN DOCUMENTO_CONTABILE.TIPO = 'ACCERTAMENTO'  THEN '07E_MIUR'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'REVERSALE'     THEN '07E_SIOPE'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'IMPEGNO'		THEN '07U_MIUR'
	WHEN DOCUMENTO_CONTABILE.TIPO = 'MANDATO'       THEN '07U_SIOPE'
END,
CONVERT(varchar, GRUPPO.chiave),
GRUPPO.DESCRIZIONE,
DOCUMENTO_CONTABILE.ESERCIZIO 


FROM DOCUMENTO_CONTABILE
JOIN GRUPPO ON
DOCUMENTO_CONTABILE.CODICE_GESTIONALE  = GRUPPO.CHIAVE_COMPLETA
AND GRUPPO.CHIAVE_PIANO_GRUPPI = 'G' 
WHERE DOCUMENTO_CONTABILE.BILANCIO = @bilancio  -- estraggo solo i documenti di un dato dipartimento
AND CODICE_GESTIONALE is not null 
AND TIPO IN ('ACCERTAMENTO', 'REVERSALE','IMPEGNO','MANDATO')
 AND NOT EXISTS (select * from DOCUMENTO_CONTABILE D1 where
       D1.chiave_completa_documento=DOCUMENTO_CONTABILE.chiave_completa_documento
       and D1.bilancio = DOCUMENTO_CONTABILE.bilancio
       and D1.esercizio=DOCUMENTO_CONTABILE.esercizio
       and D1.numero_versione > DOCUMENTO_CONTABILE.numero_versione)
ORDER BY DOCUMENTO_CONTABILE.ESERCIZIO, DOCUMENTO_CONTABILE.CHIAVE_COMPLETA_DOCUMENTO
END

GO

