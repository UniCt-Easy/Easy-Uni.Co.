
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


-- CREAZIONE TABELLA lookup_bilancio --
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_movfin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_movfin
END

CREATE TABLE lookup_movfin
(
	tipomov int,
	kind char(1),
	chiave_completa_documento varchar(120),
	chiave_completa_padre varchar(120),
	bilancio varchar(120),
	esercizio int,
	nphase int,
	ymov int, 
	nmov int,
	nsub int
	--CONSTRAINT xpklookup_movfin PRIMARY KEY (nphase, chiave_completa_documento,bilancio, esercizio)
)
 
 
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1lookup_movfin' and id=object_id('lookup_movfin'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1lookup_movfin
     ON lookup_movfin
     (
			bilancio,chiave_completa_padre, chiave_completa_documento    
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1lookup_movfin
     ON lookup_movfin
     (
		 bilancio,chiave_completa_padre, chiave_completa_documento        
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2lookup_movfin' and id=object_id('lookup_movfin'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2lookup_movfin
     ON lookup_movfin
     (
			kind, chiave_completa_documento, bilancio, esercizio     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2lookup_movfin
     ON lookup_movfin
     (
		 kind, chiave_completa_documento, bilancio, esercizio         
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO


--fasi 1
-- ymov, nmov presi dal substring opportuno del campo CHIAVE di CURR_DOCUMENTO_CONTABILE
INSERT INTO lookup_movfin
(
	tipomov,
	kind,
	chiave_completa_documento,
	chiave_completa_padre,
	bilancio,
	esercizio,
	nphase,
	ymov, 
	nmov
)
SELECT 
1,
CASE
	WHEN  D.TIPO = 'ACCERTAMENTO' THEN 'E'
	ELSE   'S'  --IMPEGNO
END ,
D.CHIAVE_COMPLETA_DOCUMENTO,
null,
D.BILANCIO,
D.ESERCIZIO,
1,
 CONVERT(INT,SUBSTRING(D.CHIAVE, 1, 4)) as ymov,
 CONVERT(INT,SUBSTRING(D.CHIAVE, 6, LEN(D.CHIAVE))) as nmov
FROM  CURR_DOCUMENTO_CONTABILE D
WHERE D.TIPO  IN ( 'ACCERTAMENTO','IMPEGNO') 

GO

--fasi 2 
-- ymov= esercizio e numero progressivo in base a tipo/esercizio/bilancio
-- importo dalla relazione padre/figlio tra impegno e mandato
INSERT INTO lookup_movfin
(
	tipomov,
	kind,
	chiave_completa_documento, 	chiave_completa_padre,
	bilancio,	esercizio,	nphase,
	ymov, 	nmov,nsub
)
SELECT 
2,
CASE
	WHEN  D.TIPO = 'REVERSALE' THEN 'E'
	ELSE   'S'  --MANDATO
END ,
D.CHIAVE_COMPLETA_DOCUMENTO,RDD.CHIAVE_COMPLETA_DOC_PADRE,
D.BILANCIO,D.ESERCIZIO,2,
D.ESERCIZIO as ymov,
ROW_NUMBER() OVER(PARTITION BY D.TIPO, D.ESERCIZIO,  D.BILANCIO
      ORDER BY  RDD.esercizio,RDD.BILANCIO,RDD.CHIAVE_COMPLETA_DOC_PADRE ) AS nmov,
ROW_NUMBER() OVER(PARTITION BY D.TIPO, D.ESERCIZIO,  D.BILANCIO,D.CHIAVE_COMPLETA_DOCUMENTO
      ORDER BY  RDD.esercizio,RDD.BILANCIO,RDD.CHIAVE_COMPLETA_DOC_PADRE) AS nsub

		
FROM  CURR_DOCUMENTO_CONTABILE  D
	LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
			ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
			and   RDD.esercizio = D.esercizio
			AND RDD.BILANCIO = D.BILANCIO
WHERE D.TIPO  IN ( 'REVERSALE','MANDATO') 

GO


--- movimenti residui, creiamo le seconde fasi a partire
--  da accertamenti e impegni non stornati e con anagrafica valorizzata
--  nell'ultimo anno di esistenza

INSERT INTO lookup_movfin
(
		tipomov,		kind,
	chiave_completa_documento,	chiave_completa_padre,
	bilancio,	esercizio,	nphase,	ymov, 	nmov
)
SELECT 
  3, 'E' ,
D.CHIAVE_COMPLETA_DOCUMENTO,   D.CHIAVE_COMPLETA_DOCUMENTO,
D.BILANCIO,D.ESERCIZIO,2,D.ESERCIZIO as ymov,
isnull( (SELECT MAX(nmov) FROM lookup_movfin LK 
   WHERE LK.nphase =  2 
   AND   LK.bilancio  = D.bilancio 
   AND   LK.esercizio = D.esercizio
   AND   LK.kind = 'E'),0)
+
ROW_NUMBER() OVER(PARTITION BY  D.TIPO, D.ESERCIZIO,  D.BILANCIO    
 ORDER BY   D.CHIAVE_COMPLETA_DOCUMENTO) AS nmov
FROM  CURR_DOCUMENTO_CONTABILE  D
	LEFT OUTER JOIN CURR_DOCUMENTO_CONTABILE  DNEW
			ON  DNEW.BILANCIO = D.BILANCIO
			AND DNEW.ESERCIZIO = D.ESERCIZIO +1 
			AND DNEW.CHIAVE_COMPLETA_DOCUMENTO = D.CHIAVE_COMPLETA_DOCUMENTO 
WHERE D.TIPO  = 'ACCERTAMENTO' 
			AND DNEW.CHIAVE_COMPLETA_DOCUMENTO IS NULL 
			AND ISNULL(D.IMPORTO_RESIDUO,0) <> 0  
			AND D.DATA_STORNO IS NULL
			AND D.CODICE_ANAG IS NOT NULL

GO

INSERT INTO lookup_movfin
(
	tipomov,
	kind,
	chiave_completa_documento,
	chiave_completa_padre,
	bilancio,
	esercizio,
	nphase,
	ymov, 
	nmov
)
SELECT 
4,
 'S',  --MANDATO 
D.CHIAVE_COMPLETA_DOCUMENTO,
D.CHIAVE_COMPLETA_DOCUMENTO,
D.BILANCIO,
D.ESERCIZIO,
2,
D.ESERCIZIO as ymov,
isnull((SELECT MAX(nmov) FROM lookup_movfin LK 
   WHERE LK.nphase =  2 
   AND   LK.bilancio  = D.bilancio 
   AND   LK.esercizio = D.esercizio
   AND   LK.kind = 'S'),0)
+
ROW_NUMBER() OVER(PARTITION BY  D.TIPO, D.ESERCIZIO,  D.BILANCIO
      ORDER BY   D.CHIAVE_COMPLETA_DOCUMENTO) AS nmov
FROM  CURR_DOCUMENTO_CONTABILE  D
	LEFT OUTER JOIN CURR_DOCUMENTO_CONTABILE  DNEW
				ON DNEW.BILANCIO = D.BILANCIO
				AND DNEW.ESERCIZIO = D.ESERCIZIO +1 
				AND D.CHIAVE_COMPLETA_DOCUMENTO = DNEW.CHIAVE_COMPLETA_DOCUMENTO
WHERE D.TIPO  = 'IMPEGNO' 
		AND DNEW.CHIAVE_COMPLETA_DOCUMENTO IS NULL 
		AND COALESCE(D.RESIDUO_CORRETTO,D.IMPORTO_RESIDUO,0) <> 0  
		AND D.DATA_STORNO IS NULL
		AND D.CODICE_ANAG IS NOT NULL




		---terze fasi


INSERT INTO lookup_movfin
(
	tipomov,	kind,
	chiave_completa_documento,	chiave_completa_padre,
	bilancio,	esercizio,	nphase,	ymov, 	nmov,nsub
)
SELECT 
5,
CASE
	WHEN  D.TIPO = 'REVERSALE' THEN 'E'
	ELSE   'S'  --MANDATO
END ,
D.CHIAVE_COMPLETA_DOCUMENTO,RDD.CHIAVE_COMPLETA_DOC_PADRE,
D.BILANCIO,D.ESERCIZIO,3,
D.ESERCIZIO as ymov,
	ROW_NUMBER() OVER(PARTITION BY D.TIPO, D.ESERCIZIO,  D.BILANCIO
      ORDER BY  RDD.esercizio,RDD.BILANCIO,RDD.CHIAVE_COMPLETA_DOC_PADRE ) AS nmov,
ROW_NUMBER() OVER(PARTITION BY D.TIPO, D.ESERCIZIO,  D.BILANCIO,D.CHIAVE_COMPLETA_DOCUMENTO
      ORDER BY  RDD.esercizio,RDD.BILANCIO,RDD.CHIAVE_COMPLETA_DOC_PADRE) AS nsub
FROM  CURR_DOCUMENTO_CONTABILE  D
	LEFT  OUTER JOIN RELAZIONE_DCONT_DCONT RDD
			ON    RDD.CHIAVE_COMPLETA_DOC_FIGLIO = D.CHIAVE_COMPLETA_DOCUMENTO
			and   RDD.esercizio = D.esercizio
			AND RDD.BILANCIO = D.BILANCIO

WHERE D.TIPO  IN ( 'REVERSALE','MANDATO') 




--SELECT * FROM dbo.lookup_movfin WHERE NPHASE = 1 ORDER BY kind, chiave_completa_documento, bilancio, esercizio
--SELECT * FROM dbo.lookup_movfin WHERE NPHASE = 2 ORDER BY kind,  bilancio, esercizio, nmov
--SELECT * FROM dbo.lookup_movfin WHERE NPHASE = 3 ORDER BY kind, chiave_completa_documento, bilancio, esercizio

--DELETE  FROM dbo.lookup_movfin WHERE nphase IN (2,3)

GO
