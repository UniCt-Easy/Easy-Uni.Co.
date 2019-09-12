-- CREAZIONE TABELLA lookup_bilancio --
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_dipartimento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_dipartimento
END

go

CREATE TABLE lookup_dipartimento
(
	chiave_completa varchar(50),
	codeupb  varchar(50),
	descrizione varchar(150)
	CONSTRAINT xpklookup_dipartimento PRIMARY KEY (chiave_completa)
)
 
go

INSERT INTO lookup_dipartimento
(
	chiave_completa,
	codeupb,
	descrizione
)
	SELECT 
	UBILANCIO.chiave_completa,
   	substring(substring(UBILANCIO.CHIAVE_COMPLETA, 3,len(UBILANCIO.CHIAVE_COMPLETA)),1,20) ,
    ISNULL(UBILANCIO.DESCRIZIONE,UBILANCIO.NOME_UNITA)
    FROM UNITA_ORGANIZZATIVA UBILANCIO
    JOIN BILANCIO_CASSIERE ON
    UBILANCIO.CHIAVE_COMPLETA = BILANCIO_CASSIERE.CODICE_BILANCIO
    WHERE NOT EXISTS (SELECT * FROM   UNITA_ORGANIZZATIVA U1 WHERE 
U1.CHIAVE_COMPLETA = UBILANCIO.CHIAVE_COMPLETA AND
((U1.ESERCIZIO > UBILANCIO.ESERCIZIO) 
  OR
 ((U1.ESERCIZIO = UBILANCIO.ESERCIZIO) AND CONVERT(INT, U1.VERSIONE) > CONVERT(INT, UBILANCIO.VERSIONE))))
    


--SELECT * FROM lookup_dipartimento ORDER BY chiave_completa

