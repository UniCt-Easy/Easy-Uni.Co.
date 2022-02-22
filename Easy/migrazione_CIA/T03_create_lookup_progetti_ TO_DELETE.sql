
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
IF  EXISTS(select * from sysobjects where id = object_id(N'[lookup_progetti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE lookup_progetti
END

CREATE TABLE lookup_progetti
(	bilancio varchar(60), 
	codice_progetto varchar(50),
	codeupb varchar(50) 
	CONSTRAINT xpklookup_progetti PRIMARY KEY (bilancio, codice_progetto)
)

INSERT INTO lookup_progetti
(
	bilancio,
	codice_progetto,
	codeupb
)
SELECT  
    count(*),
	PROGETTO.bilancio,
	PROGETTO.codice_progetto 
	--,substring(UO.chiave_completa, 3,len(UO.chiave_completa))
from PROGETTO
join  unita_organizzativa UO 
		on  UO.chiave=codice_progetto 
		and UO.IDENTIFICATIVO_BILANCIO = PROGETTO.bilancio 		
where UO.PROGETTO ='Y'
	and not exists(select * from unita_organizzativa UO2  WHERE 
                      convert(int,UO2.esercizio)>convert(int,UO.esercizio)                                                
                       AND UO2.IDENTIFICATIVO_BILANCIO= UO.IDENTIFICATIVO_BILANCIO        
                       AND UO2.chiave= UO.chiave            
					)
    and not exists(select * from unita_organizzativa UO2  WHERE 
                      ( convert(int,UO2.esercizio)>convert(int,UO.esercizio)  OR
                         (convert(int,UO2.esercizio)=convert(int,UO.esercizio) AND UO2.versione>UO.versione) 
                      ) 
                      AND UO2.chiave_completa= UO.chiave_completa            
					)					
	and not UO.chiave_completa_padre like '%.'+UO.chiave
group by 		PROGETTO.bilancio,
	PROGETTO.codice_progetto
having count(*)>1
ORDER BY progetto.bilancio,progetto.CODICE_PROGETTO 


			 select UNITA_ORGANIZZATIVA, * from Ordine_dettaglio		
					

select * from lookup_progetti
