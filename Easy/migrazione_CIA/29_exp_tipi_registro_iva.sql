  if exists (select * from dbo.sysobjects where id = object_id(N'[exp_tipi_registro_iva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_tipi_registro_iva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--[exp_tipi_registro_iva] 


CREATE      PROCEDURE [exp_tipi_registro_iva]
 
AS BEGIN
SELECT DISTINCT
--codtiporegistroiva	0	20	Stringa		 Codice Tipo Registro IVA
--descrtiporegistroiva	20	50	Stringa		Descrizione Tipo Registro IVA
--tipoprotocollo	70	1	Codificato	A|V|P	Acquisto/Vendita/Protocollo Generale(A/V/P)
--attivita	71	1	Codificato	1|2|3|4	Tipo Attività Istituzionale / Commerciale / Promiscua / Qualsiasi (S/N)
--registrocorrispettivi	72	1	Codificato	S|N	Compensazione(S/N)
--codicecass	73	20	Stringa		Codice Cassiere collegato
	  CASE UPPER(FATTURA.TIPO_FATTURA)
		WHEN 'P' THEN FATTURA.SEZIONALE + ' ACQ/PROM' 
		WHEN 'C' THEN FATTURA.SEZIONALE + ' ACQ/COM' 
		WHEN 'I' THEN FATTURA.SEZIONALE + ' ACQ/IST' 
	END as codtiporegistroiva,

	CASE UPPER(FATTURA.TIPO_FATTURA)
		WHEN 'P' THEN FATTURA.SEZIONALE + ' ACQ/PROM' 
		WHEN 'C' THEN FATTURA.SEZIONALE + ' ACQ/COM' 
		WHEN 'I' THEN FATTURA.SEZIONALE + ' ACQ/IST' 
	END  as descrtiporegistroiva,
	'A' as tipoprotocollo,
	UPPER(FATTURA.TIPO_FATTURA) as attivita,
	'N' as registrocorrispettivi,
	null as codicecass
FROM FATTURA
  JOIN CONFIG_NUM_FATT_PAS CFP
  ON FATTURA.SEZIONALE = CFP.SUFFISSO
  JOIN LOOKUP_FATTURA LK
   ON 	 SUBSTRING(LK.codtipofatturacia,2,4)= CFP.SUFFISSO  
   AND   SUBSTRING(LK.codtipofatturacia,1,1)= FATTURA.TIPO_FATTURA  
 WHERE LEN (sezionale) = 4 AND 
 ((FATTURA.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
  AND
   ((FATTURA.TIPO_FATTURA = 'I' AND CFP.ISTITUZIONALE = 'S') OR
  (FATTURA.TIPO_FATTURA <> 'I' AND CFP.ISTITUZIONALE = 'N'))
 AND
 CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1 WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)  -- 88508

UNION ALL
SELECT DISTINCT
	  CASE UPPER(FATTURA.TIPO_FATTURA)
		WHEN 'P' THEN FATTURA.SEZIONALE + ' ACQ/PROM' 
		WHEN 'C' THEN FATTURA.SEZIONALE + ' ACQ/COM' 
		WHEN 'I' THEN FATTURA.SEZIONALE + ' ACQ/IST' 
	END as codtiporegistroiva,

	CASE UPPER(FATTURA.TIPO_FATTURA)
		WHEN 'P' THEN FATTURA.SEZIONALE + ' ACQ/PROM' 
		WHEN 'C' THEN FATTURA.SEZIONALE + ' ACQ/COM' 
		WHEN 'I' THEN FATTURA.SEZIONALE + ' ACQ/IST' 
	END  as descrtiporegistroiva,
	'A' as tipoprotocollo,
	 UPPER(FATTURA.TIPO_FATTURA) as attivita,
	'N' as registrocorrispettivi,
	null as codicecass
FROM FATTURA
  JOIN CONFIG_NUM_FATT_PAS CFP
  ON FATTURA.SEZIONALE = CFP.SUFFISSO
  JOIN LOOKUP_FATTURA LK
   ON 	 SUBSTRING(LK.codtipofatturacia,2,4)= CFP.SUFFISSO  
   AND   SUBSTRING(LK.codtipofatturacia,1,1)= FATTURA.TIPO_FATTURA  
 WHERE LEN (sezionale) = 3 AND 
 ((FATTURA.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
  AND
   ((FATTURA.TIPO_FATTURA = 'I' AND CFP.ISTITUZIONALE = 'S') OR
  (FATTURA.TIPO_FATTURA <> 'I' AND CFP.ISTITUZIONALE = 'N'))
 AND
 CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1
  WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)  -- 246

UNION ALL 
 
SELECT  DISTINCT
	CFA.tipo_fattura + ' VEN' as codtiporegistroiva,
	CFA.tipo_fattura + ' VEN' as descrtiporegistroiva,
	'V' as tipoprotocollo,
	'C' as attivita,
	CASE
	WHEN EXISTS (SELECT * FROM CORRISPETTIVO WHERE CFA.TIPO_FATTURA = CORRISPETTIVO.CODICE_SEZIONALE) THEN 'S' 
	ELSE 'N'
	END as registrocorrispettivi,
	null as codicecass
FROM   FATTURA_ATT 
JOIN   LOOKUP_FATTURA LK
	   ON FATTURA_ATT.TIPO_FATTURA = LK.codtipofatturacia
JOIN   CONFIG_NUM_FATT_ATT CFA
	ON   LK.codtipofatturacia = CFA.tipo_fattura
WHERE LK.A_V = 'V'
AND 
 ((FATTURA_ATT.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA_ATT.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
AND   NOT EXISTS (select * from CONFIG_NUM_FATT_ATT CFA1 where CFA1.tipo_fattura = CFA.tipo_fattura AND CFA1.esercizio > CFA.esercizio)
AND FATTURA_ATT.richiesta_fatturazione  = 'N'  AND LK.rich_fatturazione = 'N'  
 
UNION ALL -- AGGIUNGO I SEZIONALI  PER REVERSE CHARGE SEPARATI DAI NORMALI REGISTRI DI VENDITA, I CODICI INIZIANO CON 'P' ANZICHE' 'V'
	SELECT  DISTINCT
	'P'+ SUBSTRING(CFP.SUFFISSO,2,3) + ' VEN/REV_CHG' as codtiporegistroiva,
	'P'+ SUBSTRING(CFP.SUFFISSO,2,3) + ' VEN/REV_CHG'  as descrtiporegistroiva,
	'V' as tipoprotocollo,
	'C' as attivita,
	'N' as registrocorrispettivi,
	 null as codicecass
FROM FATTURA A 
JOIN  AUTO_FATTURA B
	ON  A.esercizio = B.esercizio
	AND A.bilancio = B.bilancio
	AND A.numero_fattura = B.numero_fattura
JOIN CONFIG_NUM_FATT_PAS CFP
   ON A.SEZIONALE = CFP.SUFFISSO
JOIN LOOKUP_FATTURA LK
    ON 	 SUBSTRING(LK.codtipofatturacia,2,4)= CFP.SUFFISSO  
   AND   SUBSTRING(LK.codtipofatturacia,1,1)= A.TIPO_FATTURA  
WHERE   LEN (sezionale) = 4   
AND 
 ((A.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (A.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
  AND
   ((A.TIPO_FATTURA = 'I' AND CFP.ISTITUZIONALE = 'S') OR
  (A.TIPO_FATTURA <> 'I' AND CFP.ISTITUZIONALE = 'N'))
  and 
CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1 WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)

UNION ALL -- AGGIUNGO I SEZIONALI  PER REVERSE CHARGE SEPARATI DAI NORMALI REGISTRI DI VENDITA, I CODICI INIZIANO CON 'P' ANZICHE' 'V'
	SELECT  DISTINCT
	'P'+ SUBSTRING(CFP.SUFFISSO,2,3) + ' VEN/REV_CHG' as codtiporegistroiva,
	SUBSTRING(  'VEN/REV_CHG ' + CFP.DESCRIZIONE, 1,50) as descrtiporegistroiva,
	'V' as tipoprotocollo,
	'C' as attivita,
	'N' as registrocorrispettivi,
	 null as codicecass
FROM FATTURA A 
JOIN  AUTO_FATTURA B
	ON  A.esercizio = B.esercizio
	AND A.bilancio = B.bilancio
	AND A.numero_fattura = B.numero_fattura
JOIN CONFIG_NUM_FATT_PAS CFP
   ON A.SEZIONALE = CFP.SUFFISSO
JOIN LOOKUP_FATTURA LK
    ON  SUBSTRING(LK.codtipofatturacia,2,4)= CFP.SUFFISSO  
   AND   SUBSTRING(LK.codtipofatturacia,1,1)= A.TIPO_FATTURA  
WHERE   LEN (sezionale) = 3   
AND 
 ((A.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (A.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
  AND
   ((A.TIPO_FATTURA = 'I' AND CFP.ISTITUZIONALE = 'S') OR
  (A.TIPO_FATTURA <> 'I' AND CFP.ISTITUZIONALE = 'N'))
  and 
CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1 WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)
	
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
