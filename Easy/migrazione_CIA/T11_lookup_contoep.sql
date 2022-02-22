
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
