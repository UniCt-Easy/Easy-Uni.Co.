-- CREAZIONE TABELLA lookup_bilancio --
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_bilancio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_bilancio
END

CREATE TABLE lookup_bilancio
(
	chiave_completa varchar(50),
	codefin  varchar(50),
	finpart char(1)
	CONSTRAINT xpklookup_bilancio PRIMARY KEY (chiave_completa)
)
 

INSERT INTO lookup_bilancio
(
	chiave_completa,
	codefin,
	finpart
)
SELECT DISTINCT
CHIAVE_COMPLETA ,
substring(REPLACE(chiave_completa,'.',''),3,len(REPLACE(chiave_completa,'.',''))) AS CODEFIN,
SUBSTRING(CHIAVE_COMPLETA,3,1) AS FINPART
FROM conto_f
WHERE NUMERO_LIVELLO > 1
ORDER BY CHIAVE_COMPLETA 

UPDATE lookup_bilancio SET codefin =  SUBSTRING (chiave_completa,5,1) + '0000' WHERE chiave_completa IN 
(SELECT DISTINCT CHIAVE_COMPLETA FROM CONTO_F WHERE NUMERO_LIVELLO = 2 AND MASTRINO = 'Y' )


SELECT * FROM lookup_bilancio order by finpart, codefin