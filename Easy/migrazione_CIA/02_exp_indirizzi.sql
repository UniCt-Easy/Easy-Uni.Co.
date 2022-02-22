
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_indirizzi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_indirizzi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE [exp_indirizzi]

AS BEGIN
-- Leggiamo solo da ANAGRAFICO, perchè la tabell DIPEDENTI contiene i campi indirizzo_residenza, cap_residenza...indirizzo_fisclae, cap_fiscale, etc
-- quindi per i dipendenti importeremo gli indirizzi con l'importazione dell'anagrafica.

--string[] tracciato_indirizzi =
--    new string[]{
--                "codice;Codice anagrafica;Intero;10",
--                "codicetipoind;Codice tipo indirizzo;Stringa;20",
--                "descrtipoind;Descrizione tipo indirizzo;Stringa;60",
--                "datastart;Data inizio validità;Data;8",
--                "datastop;Data fine validità;Data;8",
--                "indirizzo;Indirizzo;Stringa;100",
--                "cap;CAP;Stringa;5",
--                "ufficio;Ufficio predefinito;Stringa;50",
--                "catastale_res;Codice catastale del comune o stato estero;Stringa;4",
--                "localita_res;Località;Stringa;50",
--                "nazione;Nazione estera (deve essere uguale ad una del programma se presente);Stringa;65",
--                "annotazioni;Annotazioni;Stringa;400",
--                "enteprovenienza;Ente provenienza (per anagrafe prestazioni);Stringa;50",
--                "attivo;Attivo;Codificato;1;S|N"
--    };

declare @len_indirizzo int
set @len_indirizzo = 100
declare @localita_res int
set @localita_res = 50
SELECT distinct -- in INDIRIZZI c'è anche il campo telefono, quindi per una stessa anagrafica potrebero esserci due righe, con lo stesso indirizzo che differiscono solo per il telefono.
	LKA.idreg as 'codice',
	case 
		when I.NUMERO_INDIRIZZO = 1 then '07_SW_DEF'
		else convert(varchar(10),I.NUMERO_INDIRIZZO)
	end as 'codicetipoind',
	case 
		when I.NUMERO_INDIRIZZO = 1 then 'Predefinito'
		else convert(varchar(10),I.NUMERO_INDIRIZZO) 
	end as 'descrtipoind',
	CONVERT(smalldatetime, '01-01-1900', 105)   as 'datastart',
	null as 'datastop',
	substring(I.via,1,100) as 'indirizzo',
	I.CAP as 'cap',
	null as 'ufficio',
	C.codice as 'catastale',
	case 
		when (I.frazione is not null) AND (I.citta is not null) and N.title is null
				AND (len(isnull(I.FRAZIONE,''))+ len('-')+len(isnull(citta,''))<=	@localita_res) 
		then isnull(I.frazione,'')+'-' + isnull(I.citta,'')+ substring(' '+I.NAZIONE, 1, @localita_res-len(isnull(I.frazione,'')+'-' + isnull(I.citta,''))-1)
		when i.frazione is not null and N.title is null then i.frazione + substring(' '+I.NAZIONE,1,@localita_res-len(i.frazione)-1) 
		when i.citta is not null and N.title is null then i.citta +  substring(' '+I.NAZIONE,1,@localita_res-len(I.CITTA)-1) 

		when (I.frazione is not null) AND (I.citta is not null) and N.title is not null
				AND (len(isnull(I.FRAZIONE,''))+ len('-')+len(isnull(citta,''))<=	@localita_res) 
		then isnull(I.frazione,'')+'-' + isnull(I.citta,'')
		when i.frazione is not null and N.title is not null then i.frazione 
		when i.citta is not null and N.title is not null then i.citta 

		else null
	end	 as 'localita',
	case when upper(N.title) <> 'ITALIA' then N.title 
	else null
	end
	AS 'NAZIONE',
/*	case 
		when I.NAZIONE ='.ITALIA' 
					then 'ITALIA'
		when I.NAZIONE in ('AE','NETHERLANDS','OLANDA','PAESI BASSI','ROTTERDAM','THE NETHERLANDS') 
					then 'OLANDA (PAESI BASSI)'
		when I.NAZIONE in ('FRANCE','FRANCESE','FRANCIA - PARIGI','PARIGI') 
					then 'FRANCIA'
		when I.NAZIONE in ('BARCELLONA','SALAMANCA','ESPANA','JAEN','MADRID SPAGNA','SPAGNA - MADRID','SPAIN') 
					then 'SPAGNA'
		when I.NAZIONE = 'AUSTRIA - VIENNA' 
					then 'AUSTRIA'
		when I.NAZIONE in ('BE','BELGIO - BRUXELLES','BELGIQUE','BELGIUM','BRUSSELES','LIEGE','UE') 
					then 'BELGIO'
		when I.NAZIONE in ('AMERICA','USA','CALIFORNIA, USA','CALIFORNIA','CALIFORNIA,  USA','2280 USA','4307 USA','FLORIDA','GEORGIA','GEORGIA , USA','WASHINGTON',
						'IOWA','MISSOURI 63108  -USA','STATI UNITI','STATI UNITI - NEW YORK -USA 10006','STATI UNITI D''AMERIC','U.S.A','U.S.A.','UNITED STATES','US',
						'USA 19428-2959','MICHIGAN') 
					then 'STATI UNITI D''AMERICA'
		when I.NAZIONE in ('UK','UNITED KINGDOM','UNITED KINDOM','LEICESTER  INGHILTERRA ','ENGLAND','ENGLAND, UK','GALLES','GB','GRAN BRETAGNA','GRAN BRETAGNA - LONDRA',
						'INGHILTERRA','OX5 1GB, U.K.','REGNO UNITO','SCOTLAND','SCOZIA','UNITED KINGDOM (GB)','WALES','REGNO UNITO DI GRAN BRETAGNA') 
					then 'REGNO UNITO DI GRAN BRETAGNA E IRLANDA DEL NORD'
		when I.NAZIONE in ('CANADA H4M 2X5','CANADA R3T 686','CANADA T3E7J9','M4E 2X7 CANADA') then 'CANADA'
		when I.NAZIONE in ('CHINA','CINA','HONG KONG','TAIWAN','TAIWAN, REPUBBLICA CINESE') then 'CINA REPUBBLICA POPOLARE'
		when I.NAZIONE in ('BRAZIL') then 'BRASILE'
		when I.NAZIONE in ('GINEVRA','SUISSE','SWITZERLAND') then 'SVIZZERA'
		when I.NAZIONE in ('CROATIA') then 'CROAZIA'
		when I.NAZIONE in ('DE','DENMARK','GERMANY','MONACO','REPUBBLICA FEDERALE DI GERMANIA')then 'GERMANIA'
		when I.NAZIONE in ('FINLAND','FLNLANDIA') then 'FINLANDIA'
		when I.NAZIONE in ('HUNGARY') then 'UNGHERIA'
		when I.NAZIONE in ('IRELAND','IRELAND ( UE )','NORTHERN IRELAND','REPUBLIC OF IRELAND','IRLANDA')then 'IRLANDA=EIRE'
		when I.NAZIONE in ('ISRAEL') then 'ISRAELE'
		when I.NAZIONE in ('JAPAN','TOKYO') then  'GIAPPONE'
		when I.NAZIONE in ('CZECH REPUBLIC','PRAGA','REP. CECA','REPUBLIC CZECH',' REPUBBLICA CECA') then'CECA REPUBBLICA'
		when I.NAZIONE in ('EMIRATI ARABI') then 'EMIRATI ARABI UNITI'
		when I.NAZIONE in ('NEW ZEALAND') then 'NUOVA ZELANDA'
		when I.NAZIONE in ('POLAND','POLONIA') then 'REPUBBLICA DI POLONIA'
		when I.NAZIONE  in ('PORTUGAL') then 'PORTOGALLO'
		when I.NAZIONE in ('REPUBBLICA SLOVACCA','SLOVAK REPUBLIC','SLOVAKIA') then 'SLOVACCHIA'
		when I.NAZIONE in ('RSM','REPUBBLICA DI SAN MARINO') then'SAN MARINO'
		when I.NAZIONE in ('RUSSIA','RUSSIA - FEDERAZIONE RUSSA') then'RUSSIA=FEDERAZIONE RUSSA'
		when I.NAZIONE in ('SWEDEN') then 'SVEZIA'
		when I.NAZIONE in ('TURKEY') then 'TURCHIA'
		when I.NAZIONE ='DANMARK' then 'DANIMARCA'
		when I.NAZIONE ='GREECE' then 'GRECIA'
		when I.NAZIONE='SOUTH KOREA'then 'COREA DEL SUD'
		else  I.NAZIONE 
	end AS 'NAZIONE',*/
	case when len(via)>100 then 'via:'+I.via + '.'+isnull(I.DESCRIZIONE,'')	-- Descrizione di solito contiene l'anagrafica, per alcuni 'Indirizzo principale' o 'Filiale'
	else I.DESCRIZIONE
	end as 'annotazioni',
	null as 'enteprovenienza',
    'S' as attivo
FROM ANAGRAFICO A
JOIN INDIRIZZO I
	ON A.codice = I.codice
JOIN lookup_anagrafica LKA
	ON LKA.codice = A.codice
LEFT OUTER JOIN COMUNI C
	ON I.citta = C.comune
LEFT OUTER JOIN geo_nation N
	ON N.title = I.NAZIONE 
WHERE LKA.tipo ='A' 

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


------------------------------------------------------------------------------------------------------------------------------------------------------------	

 EXEC exp_indirizzi


------------------------------------------------------------------------------------------------------------------------------------------------------------
