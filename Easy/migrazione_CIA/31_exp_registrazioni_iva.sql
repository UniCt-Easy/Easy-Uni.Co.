  if exists (select * from dbo.sysobjects where id = object_id(N'[exp_registrazioni_iva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_registrazioni_iva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
CREATE      PROCEDURE [exp_registrazioni_iva]   -- 91865
 (
 @bilancio varchar(120) 
 )
AS BEGIN
--annoregistrazione	0	4	Intero		Anno Registrazione
--numregistrazione	4	8	Intero		Numero Registrazione
--codtipofattura	12	20	Stringa		 Codice Tipo Fattura
--codtiporegistroiva	32	20	Stringa		 Codice Tipo Registro IVA
--annofattura	52	4	Intero		Anno
--numfattura	56	8	Intero		Numero Fattura
--numprotocollo	64	8	Intero		Numero Protocollo

--select esercizio, NUMERO_FATTURA, sezionale, tipo_fattura, data_registrazione from fattura
--select esercizio, NUMERO_FATTURA,  tipo_fattura, data_registrazione from fattura_att where DATA_REGISTRAZIONE is not null
SELECT   
FATTURA.esercizio as annoregistrazione,
CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 5)) AS numregistrazione,
 LK.codtipofatturaeasy as codtipofattura,
 CASE FATTURA.TIPO_FATTURA
	WHEN 'P' THEN FATTURA.SEZIONALE + ' ACQ/PROM' 
	WHEN 'C' THEN FATTURA.SEZIONALE + ' ACQ/COM' 
	WHEN 'I' THEN FATTURA.SEZIONALE + ' ACQ/IST' 
 END as codtiporegistroiva,
 FATTURA.esercizio as annofattura,
 CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 5)) AS numfattura,
 CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 5)) AS numprotocollo
FROM FATTURA
  JOIN CONFIG_NUM_FATT_PAS CFP
  ON FATTURA.SEZIONALE = CFP.SUFFISSO
  JOIN LOOKUP_FATTURA LK
   ON 	 SUBSTRING(LK.codtipofatturacia,2,4)= CFP.SUFFISSO  
   AND   SUBSTRING(LK.codtipofatturacia,1,1)= FATTURA.TIPO_FATTURA  
 WHERE FATTURA.bilancio = @bilancio
 AND LEN (sezionale) = 4 AND 
 ((FATTURA.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
  AND
   ((FATTURA.TIPO_FATTURA = 'I' AND CFP.ISTITUZIONALE = 'S') OR
  (FATTURA.TIPO_FATTURA <> 'I' AND CFP.ISTITUZIONALE = 'N'))
 AND
 CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1 WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)  -- 88508
UNION all
SELECT   
FATTURA.esercizio as annoregistrazione,
CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 6)) AS numregistrazione,
 LK.codtipofatturaeasy as codtipofattura,
  CASE FATTURA.TIPO_FATTURA
	WHEN 'P' THEN FATTURA.SEZIONALE + ' ACQ/PROM' 
	WHEN 'C' THEN FATTURA.SEZIONALE + ' ACQ/COM' 
	WHEN 'I' THEN FATTURA.SEZIONALE + ' ACQ/IST' 
 END as codtiporegistroiva,
 FATTURA.esercizio as annofattura,
 CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 6)) AS numfattura,
 CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 6)) AS numprotocollo
FROM FATTURA
  JOIN CONFIG_NUM_FATT_PAS CFP
  ON FATTURA.SEZIONALE = CFP.SUFFISSO
  JOIN LOOKUP_FATTURA LK
   ON 	 SUBSTRING(LK.codtipofatturacia,2,4)= CFP.SUFFISSO  
   AND   SUBSTRING(LK.codtipofatturacia,1,1)= FATTURA.TIPO_FATTURA  
 WHERE FATTURA.bilancio = @bilancio
 AND LEN (sezionale) = 3 AND 
 ((FATTURA.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
  AND
   ((FATTURA.TIPO_FATTURA = 'I' AND CFP.ISTITUZIONALE = 'S') OR
  (FATTURA.TIPO_FATTURA <> 'I' AND CFP.ISTITUZIONALE = 'N'))
 AND
 CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1 WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)  -- 246

UNION ALL
	SELECT  
	FATTURA_ATT.esercizio as annoregistrazione,
	CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 5)) AS numregistrazione,
	LK.codtipofatturaeasy as codtipofattura,
	CFA.tipo_fattura + ' VEN' as codtiporegistroiva,
	FATTURA_ATT.esercizio as annofattura,
	CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 5)) AS numfattura,
	CONVERT(INT, SUBSTRING(NUMERO_FATTURA, 2, 5)) AS numprotocollo
FROM   FATTURA_ATT 
JOIN   LOOKUP_FATTURA LK
	   ON FATTURA_ATT.TIPO_FATTURA = LK.codtipofatturacia
JOIN   CONFIG_NUM_FATT_ATT CFA
	ON   LK.codtipofatturacia = CFA.tipo_fattura
WHERE FATTURA_ATT.bilancio = @bilancio
 AND LK.A_V = 'V'
AND 
 ((FATTURA_ATT.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA_ATT.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
AND   NOT EXISTS (select * from CONFIG_NUM_FATT_ATT CFA1 where CFA1.tipo_fattura = CFA.tipo_fattura AND CFA1.esercizio > CFA.esercizio)
AND FATTURA_ATT.richiesta_fatturazione  = 'N'  AND LK.rich_fatturazione = 'N'  

UNION  ALL -- AGGIUNGO I SEZIONALI  PER REVERSE CHARGE SEPARATI DAI NORMALI REGISTRI DI VENDITA, I CODICI INIZIANO CON 'P' ANZICHE' 'V'
	SELECT  
	A.esercizio as annoregistrazione,
    CONVERT(INT, SUBSTRING(A.NUMERO_FATTURA, 2, 5)) AS numregistrazione,
	LK.codtipofatturaeasy as codtipofattura,
	'P'+ SUBSTRING(CFP.SUFFISSO,2,3) + ' VEN/REV_CHG' as codtiporegistroiva,
	A.esercizio as annofattura,
	CONVERT(INT, SUBSTRING(A.NUMERO_FATTURA, 2, 5)) AS numfattura,
	CONVERT(INT, SUBSTRING(A.NUMERO_FATTURA, 2, 5)) AS numprotocollo
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
WHERE A.bilancio = @bilancio
 AND  LEN (sezionale) = 4   
AND 
 ((A.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (A.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
  AND
   ((A.TIPO_FATTURA = 'I' AND CFP.ISTITUZIONALE = 'S') OR
  (A.TIPO_FATTURA <> 'I' AND CFP.ISTITUZIONALE = 'N'))
  and 
CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1 WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)

UNION  ALL -- AGGIUNGO I SEZIONALI  PER REVERSE CHARGE SEPARATI DAI NORMALI REGISTRI DI VENDITA, I CODICI INIZIANO CON 'P' ANZICHE' 'V'
	SELECT  
	A.esercizio as annoregistrazione,
    CONVERT(INT, SUBSTRING(A.NUMERO_FATTURA, 2, 6)) AS numregistrazione,
	LK.codtipofatturaeasy as codtipofattura,
	'P'+ SUBSTRING(CFP.SUFFISSO,2,3) + ' VEN/REV_CHG' as codtiporegistroiva,
	A.esercizio as annofattura,
	CONVERT(INT, SUBSTRING(A.NUMERO_FATTURA, 2, 6)) AS numfattura,
	CONVERT(INT, SUBSTRING(A.NUMERO_FATTURA, 2, 6)) AS numprotocollo
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
WHERE A.bilancio = @bilancio
 AND  LEN (sezionale) = 3   
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


 