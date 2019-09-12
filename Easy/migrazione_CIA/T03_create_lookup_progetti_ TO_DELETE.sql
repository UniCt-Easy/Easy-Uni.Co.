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