
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


if exists (select * from dbo.sysobjects where id = object_id(N'[import_anagrafiche_isidata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [import_anagrafiche_isidata]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [import_anagrafiche_isidata]

AS BEGIN


CREATE TABLE #anagrafiche
(
	--------------------------------------------------------------
	-----------------------INFORMAZIONI ANAGRAFICHE---------------
	--------------------------------------------------------------
	codice int, --tempid int identity(1,1) ,  					--
	tipologia  varchar(2),			--tipologia lunghezza 2
	tiporesidenza	char,			--tipo residenza I J X poi sarà char
	denominazione varchar(100),   	--denominazione
	cognome varchar(50),			--cognome
	nome varchar(50),				--nome
	sesso char,						--sesso
	p_iva	varchar(15),			--partita iva
	cf      varchar(16),			--codice fiscale
	cf_ext varchar(40),				--codice fiscale estero dovrà avere lunghezza 20 nel tracciato	
	datanasc datetime,				--data di nascita
	localitanasc varchar(50),		--località nascita
	catastalenasc varchar(4),		--generalmente sono gli ultimi 4 caratteri del codice fiscale
	matricola  varchar(40),			--numero di matricola
	esenteeq char,					--S/N
	cfduplicato  char,				--S/N
	attiva		char,				--S/N
	---------------------------------------------------------------
	----------INDIRIZZO PREDEFINITO/RESIDENZA----------------------
	---------------------------------------------------------------
	dataind_res	varchar(8),	-- inizio validità predefinito/residenza
	indirizzo_res	varchar(100),	-- indirizzo predefinito/residenza
	cap_res		varchar(20),	-- CAP predefinito/residenza
	ufficio_res	varchar(50),	-- nome ufficio predefinito/residenza
	catastale_res 	varchar(4),	-- codice catastale predefinito/residenza
	localita_res	varchar(50),	-- localita dell'indirizzo di residenza
	---------------------------------------------------------------
	----------DOMICILIO FISCALE OVE DIVERSO DAL PREDEFINITO--------
	---------------------------------------------------------------
	dataind_dom	datetime,	-- inizio validità domicilio fiscale
	indirizzo_dom	varchar(100),	-- indirizzo  domicilio fiscale
	cap_dom		varchar(20),	-- CAP  domicilio fiscale
	ufficio_dom 	varchar(50),	-- nome ufficio  domicilio fiscale
	catastale_dom 	varchar(4),	-- codice catastale  domicilio fiscale
	localita_dom	varchar(50),	-- localita dell'indirizzo di residenza
	           
	datainizioposgiurid datetime, --Data Inizio Posizione giuridica
	imponpresunto decimal(19,2), --Imponibile presunto anno
	classestipendiale int,--Classe Stipendiale
	codicequalifica varchar(20), --Codice Qualifica (deve corrispondere ad un codice già presente nel db)
	id_class_centralizzata  varchar(20), -- ID classificazione centralizzata
	descr_class_centralizzata varchar(50), -- Descrizione: Descrizione class. centralizzata
	id_tipo_anagrafica int,  --ID tipo anagrafica
	codice_tipo_anagrafica  varchar(20), -- Codice tipo anagrafica
	descr_tipo_anagrafica varchar(50), -- descrizione tipo anagrafica
	idexternal int ,-- codice anagrafica esterno
	bancaditalia char(1), -- S|N  Regolarizza Riscossioni presso TPS Banca d'Italia
	entepubblico char(1) -- ente pubblico

)


INSERT INTO #anagrafiche(
	codice,
	tipologia,		
	tiporesidenza,		
	denominazione,   	
	cognome,		
	nome,		
	sesso,			
	p_iva,		
	cf,		
	cf_ext,		
	datanasc,		
	localitanasc,		
	catastalenasc,	
	matricola,		
	esenteeq,			
	cfduplicato,		
	attiva,			
	---------------------------------------------------------------
	----------INDIRIZZO PREDEFINITO/RESIDENZA----------------------
	---------------------------------------------------------------
	dataind_res,	
	indirizzo_res,	
	cap_res,	
	ufficio_res,	
	catastale_res,	
	localita_res	
	---------------------------------------------------------------
	----------DOMICILIO FISCALE OVE DIVERSO DAL PREDEFINITO--------
	---------------------------------------------------------------
	--dataind_dom,	
	--indirizzo_dom,	
	--cap_dom,	
	--ufficio_dom,	
	--catastale_dom,	
	--localita_dom	
)
SELECT DISTINCT 
	anagraficalookup.newidreg,
	
	 '25' ,
	 'I' ,
	 anagraficalookup.denominazione ,
	 null ,
	 null ,
	 null ,
	 PIVA ,
	 CFISC ,
	 null ,
	 null ,-- datanasc,
	 null ,--localitanasc,
	 null ,-- catastalenasc,
	 null , --NORD ,-- matricola, NORD forse si riferisce alle operazioni e non alle anagrafiche, perchè ci sono anagrafiche uguali con NORD diverso. Quindi non lo consideriamo.
	null ,-- 	 esenteeq,
	null ,--  cfduplicato,
	'N' ,-- attiva,
	---------------------------------------------------------------
	----------INDIRIZZO PREDEFINITO/RESIDENZA----------------------
	---------------------------------------------------------------
	case when  len(INDIRIZZO)>0 then '01011900'	else null	end ,--  dataind_res,--{d '1900-01-01'}
	case when len(INDIRIZZO)>0 then INDIRIZZO 	else null	end	,-- indirizzo_res,
	case when len(CAP)>0 then CAP 	else null	end	 ,-- cap_res,
	 null ,--  ufficio_res,
	 null ,--  catastale_res,
	 case when len(LOCALITA)>0 then LOCALITA 	else null	end	  -- localita_res
	---------------------------------------------------------------
	----------DOMICILIO FISCALE OVE DIVERSO DAL PREDEFINITO--------
	---------------------------------------------------------------
	 --dataind_dom,
	 --indirizzo_dom,
	 --cap_dom,
	 --ufficio_dom,
	 --catastale_dom,
	 --localita_dom
FROM GIORNALE 
join anagraficalookup 
	on ltrim(rtrim(GIORNALE.COGNNOME)) = anagraficalookup.denominazione

SELECT 	* FROM #anagrafiche A
where indirizzo_res is not null

drop table #anagrafiche

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec import_anagrafiche_isidata
