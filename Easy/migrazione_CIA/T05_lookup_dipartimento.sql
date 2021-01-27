
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

