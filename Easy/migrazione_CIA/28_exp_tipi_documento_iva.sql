  if exists (select * from dbo.sysobjects where id = object_id(N'[exp_tipi_documento_iva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_tipi_documento_iva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--[exp_tipi_documento_iva] 'A.00000'


CREATE      PROCEDURE [exp_tipi_documento_iva]
 
AS BEGIN
SELECT DISTINCT
--codtipofattura	0	20	Stringa		 Codice Tipo Fattura
--descrtipofattura	20	50	Stringa		Descrizione Tipo Fattura
--acquisto_vendita	70	1	Codificato	A|V	Acquisto/Vendita(A/V)
--numerazioneautomatica	71	1	Codificato	S|N	Numerazione automatica(S/N)
--attivo	72	1	Codificato	S|N	Attivo(S/N)
--notadicredito	73	1	Codificato	S|N	Nota di Credito(S/N)
--codtipoautofattura	74	20	Stringa		Codice Tipo AutoFattura
--codstampa	94	20	Stringa		 Codice Stampa
--intestazionereport	114	150	Stringa		Intestazione Report
--indirizzo	264	150	Stringa		Indirizzo
--codice_ipa	414	6	Stringa		Indirizzo
--riferimento_amministrazione	420	20	Stringa		Indirizzo
--codtipoclass01	440	20	Stringa		Codice Tipo class. 01
--codclass01	460	50	Stringa		Codice class. 01
--codtipoclass02	510	20	Stringa		Codice Tipo class. 02
--codclass02	530	50	Stringa		Codice class. 02
--codtipoclass03	580	20	Stringa		Codice tipo class. 03
--codclass03	600	50	Stringa		Codice class. 03
--codtipoclass04	650	20	Stringa		Codice Tipo class. 04
--codclass04	670	50	Stringa		Codice class. 04
--codtipoclass05	720	20	Stringa		Codice Tipo class. 05
--codclass05	740	50	Stringa		Codice class. 05
	substring(codtipofatturaeasy,1,20) as codtipofattura,
	substring(codtipofatturaeasy ,1,50)  as descrtipofattura,
	'A' AS acquisto_vendita,
	'N' AS numerazioneautomatica,
	'S' AS attivo,
	LK.notadicredito AS notadicredito,
	NULL AS codtipoautofattura,
	codtipofatturaeasy as  codstampa,
	CFP.DESCRIZIONE AS  intestazionereport,
	NULL AS indirizzo,
	NULL AS  codice_ipa,
	NULL AS  riferimento_amministrazione,
	NULL AS codtipoclass01,
	NULL AS codclass01,
	NULL AS codtipoclass02,
	NULL AS codclass02,
	NULL AS codtipoclass03,
	NULL AS codclass03,
	NULL AS codtipoclass04,
	NULL AS codclass04,
	NULL AS codtipoclass05,
	NULL AS codclass05
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
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)  

UNION ALL
	SELECT DISTINCT
	substring(codtipofatturaeasy,1,20) as codtipofattura,
	substring(codtipofatturaeasy  ,1,50)  as descrtipofattura,
	'A' AS acquisto_vendita,
	'N' AS numerazioneautomatica,
	'S' AS attivo,
	LK.notadicredito AS notadicredito,
	NULL AS codtipoautofattura,
	codtipofatturaeasy as  codstampa,
	CFP.DESCRIZIONE AS  intestazionereport,
	NULL AS indirizzo,
	NULL AS  codice_ipa,
	NULL AS  riferimento_amministrazione,
	NULL AS codtipoclass01,
	NULL AS codclass01,
	NULL AS codtipoclass02,
	NULL AS codclass02,
	NULL AS codtipoclass03,
	NULL AS codclass03,
	NULL AS codtipoclass04,
	NULL AS codclass04,
	NULL AS codtipoclass05,
	NULL AS codclass05
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
 CFP.ESERCIZIO = (SELECT MAX(ESERCIZIO) FROM CONFIG_NUM_FATT_PAS CFP1 WHERE
CFP.PREFISSO = CFP1.PREFISSO AND CFP.SUFFISSO = CFP1.SUFFISSO)  -- 246


UNION  ALL
	SELECT DISTINCT
	substring(LK.codtipofatturaeasy ,1,20) as codtipofattura,
	substring(LK.codtipofatturaeasy ,1,50)  as descrtipofattura,
	'V' AS acquisto_vendita,
	'N' AS numerazioneautomatica,
	'S' AS attivo,
	LK.notadicredito AS notadicredito,
	NULL AS codtipoautofattura,
	codtipofatturaeasy as  codstampa,
	lookup_upb.DESCRIZIONE AS  intestazionereport,
	NULL AS indirizzo,
	NULL AS  codice_ipa,
	NULL AS  riferimento_amministrazione,
	NULL AS codtipoclass01,
	NULL AS codclass01,
	NULL AS codtipoclass02,
	NULL AS codclass02,
	NULL AS codtipoclass03,
	NULL AS codclass03,
	NULL AS codtipoclass04,
	NULL AS codclass04,
	NULL AS codtipoclass05,
	NULL AS codclass05
FROM   FATTURA_ATT 
JOIN   LOOKUP_FATTURA LK
	   ON FATTURA_ATT.TIPO_FATTURA = LK.codtipofatturacia
JOIN   CONFIG_NUM_FATT_ATT CFA
	ON   LK.codtipofatturacia = CFA.tipo_fattura
LEFT OUTER JOIN   lookup_upb
	ON  lookup_upb.chiave_completa = CFA.bilancio 
WHERE LK.A_V = 'V'
AND 
 ((FATTURA_ATT.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA_ATT.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
AND   NOT EXISTS (select * from CONFIG_NUM_FATT_ATT CFA1 where CFA1.tipo_fattura = CFA.tipo_fattura AND CFA1.esercizio > CFA.esercizio)
AND FATTURA_ATT.richiesta_fatturazione  = 'N'  AND LK.rich_fatturazione = 'N'  


UNION  ALL
	SELECT DISTINCT
	substring(LK.codtipofatturaeasy ,1,20) as codtipofattura,
	substring(LK.codtipofatturaeasy,1,50)  as descrtipofattura,
	'V' AS acquisto_vendita,
	'N' AS numerazioneautomatica,
	'S' AS attivo,
	LK.notadicredito AS notadicredito,
	NULL AS codtipoautofattura,
	codtipofatturaeasy as  codstampa,
	lookup_upb.DESCRIZIONE AS  intestazionereport,
	NULL AS indirizzo,
	NULL AS  codice_ipa,
	NULL AS  riferimento_amministrazione,
	NULL AS codtipoclass01,
	NULL AS codclass01,
	NULL AS codtipoclass02,
	NULL AS codclass02,
	NULL AS codtipoclass03,
	NULL AS codclass03,
	NULL AS codtipoclass04,
	NULL AS codclass04,
	NULL AS codtipoclass05,
	NULL AS codclass05
FROM   FATTURA_ATT 
JOIN   LOOKUP_FATTURA LK
	   ON FATTURA_ATT.TIPO_FATTURA = LK.codtipofatturacia
JOIN   CONFIG_NUM_FATT_ATT CFA
	ON   LK.codtipofatturacia = CFA.tipo_fattura
LEFT OUTER JOIN   lookup_upb
	ON  lookup_upb.chiave_completa = CFA.bilancio 
WHERE LK.A_V = 'V'
AND 
 ((FATTURA_ATT.NOTA_CREDITO_DEBITO = 'F' AND LK.notadicredito = 'N') OR
  (FATTURA_ATT.NOTA_CREDITO_DEBITO <> 'F' AND LK.notadicredito = 'S'))
AND   NOT EXISTS (select * from CONFIG_NUM_FATT_ATT CFA1 where CFA1.tipo_fattura = CFA.tipo_fattura AND CFA1.esercizio > CFA.esercizio)
AND FATTURA_ATT.richiesta_fatturazione  = 'Y'  AND LK.rich_fatturazione = 'S'  
		
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
