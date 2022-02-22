
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


if exists (select * from dbo.sysobjects where id = object_id(N'[import_anagrafiche_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [import_anagrafiche_csa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [import_anagrafiche_csa](
	@LinkedServer nvarchar(4000)
)
AS BEGIN

DECLARE @OPENQUERY nvarchar(4000)
SET @OPENQUERY = ' OPENQUERY('+ @LinkedServer + ','''

CREATE TABLE #anagrafiche
(
	--------------------------------------------------------------
	-----------------------INFORMAZIONI ANAGRAFICHE---------------
	--------------------------------------------------------------
	codice int,   					--
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
	dataind_res	datetime,	-- inizio validità predefinito/residenza
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
	---------------------------------------------------------------
	---------------------MODALITA' DI PAGAMENTO--------------------
	---------------------------------------------------------------
	idpaymethod int,		-- tipo codificato della modalità di pagamento
	nomemod   varchar(50),	-- nome della modalità di pagamento
	abi	 varchar(20),		-- codice ABI Ist. Bancario
	cab	varchar(20), 		-- codice CAB Sportello
	cc	varchar(30),		-- codice del conto corrente
	cin	varchar(20),		-- codice CIN deve essere di 5 caratteri
	delegato int,			-- codice di un delegato (riferito ad altra REAL_ANAGRAFICA)
	valuta varchar(3), 		-- codice ISO 4217 della valuta
	tiposcadenza int,	 	-- tipo scadenza codificato
	ggscadenza	int,		-- numero dei giorni scadenza
	iban		varchar(50)	-- codice IBAN
)

-- Prendiamo SOLO le anagrafiche
DECLARE @SGE_INTERVALLI_PLUS nvarchar(4000)
SET @SGE_INTERVALLI_PLUS = 'SELECT * FROM SGE_INTERVALLI_PLUS'')' 

DECLARE @CARRIERE nvarchar(4000)
SET @CARRIERE = 'SELECT * FROM CARRIERE'')' 

DECLARE @query_ANAGRAFICA nvarchar(4000)
SET @query_ANAGRAFICA = '
INSERT INTO #anagrafiche
(
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
	localita_res,	
	---------------------------------------------------------------
	----------DOMICILIO FISCALE OVE DIVERSO DAL PREDEFINITO--------
	---------------------------------------------------------------
	dataind_dom,	
	indirizzo_dom,	
	cap_dom,	
	ufficio_dom,	
	catastale_dom,	
	localita_dom	
)
SELECT DISTINCT 
	matricola,		
	''22'',					
	''I'',					
	cognome + '' '' +  nome,	
	cognome,	
	nome,		
	SESSO,			
	NULL,					
	COD_FISC,		
	NULL,					
	data_nasc,		
	comune_nasc_descr,		
	comune_nasc,
	matricola,		
	''N'',					
	''N'',					
	''S'',		
	----------INDIRIZZO PREDEFINITO/RESIDENZA----------------------			
	{ts ''2008-01-01 00:00:00''},
	ind_res,	
	cap_res,	
	NULL,						
	comune_res,						
	comune_res_descr,					
	----------DOMICILIO FISCALE OVE DIVERSO DAL PREDEFINITO--------	
	NULL,--ANA_DF.data_in,
	NULL,--ANA_DF.dom_fisc,
	NULL,--CAP_DOM.cap,	
	NULL,			
	NULL,--CAP_DOM.comune,			
	NULL 			
FROM ' + @OPENQUERY + @SGE_INTERVALLI_PLUS + ' as A
WHERE A.data_in = (SELECT MAX(data_in) FROM ' +  @OPENQUERY + @SGE_INTERVALLI_PLUS + ' as A2 WHERE A2.COD_FISC = A.COD_FISC)
	AND EXISTS (SELECT C.matricola FROM '+  @OPENQUERY  + @CARRIERE + 'as C 
		WHERE   C.comparto = A.comparto AND  C.ruolo = A.ruolo AND  C.inquadr = A.inquadr AND C.matricola = A.matricola)'

EXEC (@query_ANAGRAFICA)
-- In REAL_REAL_ANA_DATI_FISC, contiente il CF, per ogni matricola possono più righe o perchè ci sono più CF, o perchè ci sono + indirizzi
-- selezionando SOLO la riga con data inzio MAX si ha per ogni matricola un CF, e viceversa
-- Ma in SGE_INTERVALLI_PLUS per la stessa persona ci sono + righe, perchè la persona può avere + ruoli,  + inquadramenti
-- possiamo fare il distinct perchè stiamo importando solo i dati anagrafici

-----------------------------------------------------------------------------------------------------------------------------------------------------

SELECT 
	 tipologia,
	 tiporesidenza,
	 denominazione,
	 cognome,
	 nome,
	 sesso,
	 p_iva,
	 cf ,
	 cf_ext,
	 datanasc,
	 localitanasc,
	 catastalenasc,
	 A.matricola,
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
	 localita_res,
	---------------------------------------------------------------
	----------DOMICILIO FISCALE OVE DIVERSO DAL PREDEFINITO--------
	---------------------------------------------------------------
	 dataind_dom,
	 indirizzo_dom,
	 cap_dom,
	 ufficio_dom,
	 catastale_dom,
	 localita_dom
FROM #anagrafiche A
ORDER BY A.matricola
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

