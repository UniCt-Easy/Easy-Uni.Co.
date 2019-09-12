-- CREAZIONE TABELLA lookup_contoep --
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_bilancio]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_contoep
END

CREATE TABLE lookup_contoep
(
	chiave_completa varchar(50),
	codeacc  varchar(50)
	CONSTRAINT xpklookup_contoep PRIMARY KEY (chiave_completa)
)
 

INSERT INTO lookup_contoep
(
	chiave_completa,
	codeacc
)
SELECT DISTINCT
CHIAVE_COMPLETA ,
substring(REPLACE(chiave_completa,'.',''),2,len(REPLACE(chiave_completa,'.',''))) AS codeacc
FROM conto_ep
ORDER BY CHIAVE_COMPLETA 



SELECT * FROM lookup_contoep order by codeacc