
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_upb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_upb
END
GO
CREATE TABLE lookup_upb
(
	bilancio varchar(120),
	chiave_completa varchar(120),
	codeupb  varchar(50),
	descrizione varchar(150)
	CONSTRAINT xpklookup_upb PRIMARY KEY (chiave_completa)
)
 
GO

 --exp_upb 'A.AMMCE'
 
declare @codice_root varchar(20)
set @codice_root = 'libero'

INSERT INTO lookup_upb
(
	bilancio,
	chiave_completa,
	codeupb,
	descrizione
)
	SELECT 
	UBILANCIO.IDENTIFICATIVO_BILANCIO,
	UBILANCIO.chiave_completa,
	case when  UBILANCIO.NUMERO_LIVELLO= 2  then @codice_root
		else   substring(UBILANCIO.CHIAVE_COMPLETA, LEN(UBILANCIO.IDENTIFICATIVO_BILANCIO) +2,len(UBILANCIO.chiave_completa)) 
	end ,
    ISNULL(UBILANCIO.DESCRIZIONE,UBILANCIO.NOME_UNITA)
    FROM UNITA_ORGANIZZATIVA UBILANCIO
    WHERE NOT EXISTS (SELECT * FROM   UNITA_ORGANIZZATIVA U1 WHERE 
U1.CHIAVE_COMPLETA = UBILANCIO.CHIAVE_COMPLETA AND
((U1.ESERCIZIO > UBILANCIO.ESERCIZIO) 
  OR
 ((U1.ESERCIZIO = UBILANCIO.ESERCIZIO) AND CONVERT(INT, U1.VERSIONE) > CONVERT(INT, UBILANCIO.VERSIONE))))
  AND UBILANCIO.NUMERO_LIVELLO > 1


--SELECT * FROM dbo.lookup_upb ORDER BY chiave_completa

