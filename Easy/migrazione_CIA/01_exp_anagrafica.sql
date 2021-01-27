
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_anagrafica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_anagrafica]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_anagrafica]
( @bilancio varchar(50)  = null  --inutilizzato
)
AS BEGIN
DECLARE @len_note int
SET @len_note = 400


 --Esporta anagrafiche da ANAGRAFICO
;with TabCF(contatore, codice_fiscale) 
	as (select count(*), codice_fiscale
		FROM ANAGRAFICO 
		group by codice_fiscale
)

SELECT 
	LKA.idreg as 'codice',
-- 21: Società, enti commerciali, ditte individuali e studi associati. 
-- 22: Persona Fisica 
-- 23: Enti non commerciali ed istituzioni internazionali 
-- 24: Anagrafiche complementari 
-- 25: Non utilizzabile
	case
		when INDICATORE_ENTITA='F'  then 22	
		when INDICATORE_ENTITA='G'  then 21
		when INDICATORE_ENTITA='U'  then 21
		else 25 
	end as 'tipologia',
	case
		when ITALIANA_ESTERA = 1 then 'I'	-- Italiana
		when ITALIANA_ESTERA = 2 then 'X'		-- Extra UE
		when ITALIANA_ESTERA = 3 then 'J'		-- UE
	end as 'tiporesidenza',
	case 
		when indicatore_entita='F' then substring(rtrim(ltrim(cognome)),1, 50)+ ' ' + substring(rtrim(ltrim(nome)),1,50)
		when indicatore_entita='G'	then substring(rtrim(ltrim(ragione_sociale)),1,100)
		when indicatore_entita='U' then substring(rtrim(ltrim(nome_unita_organizzativa)),1,100)
	end	as 'denominazione',
	case when indicatore_entita='F' then substring(rtrim(ltrim(nome)),1,50)
		else null
	end as 'nome',
	case when indicatore_entita='F' then substring(rtrim(ltrim(cognome)),1, 50)
		else null
	end as 'cognome',
	case when indicatore_entita='F' then rtrim(ltrim(sesso))
		else null
	end as 'sesso',
	case when len(rtrim(ltrim(PARTITA_IVA)))> 15 then null
	else rtrim(ltrim(PARTITA_IVA))
	end  as p_iva,
	case when len(rtrim(ltrim(A.CODICE_FISCALE)))> 16 then null
	else rtrim(ltrim(A.CODICE_FISCALE))
	end  as cf,
	substring(rtrim(ltrim(CODICE_FISCALE_ESTERO)),1,20) as cf_ext,
	--GGMMAAA
	---day(data_nascita)+month(data_nascita)+year(data_nascita) as 'datanasc',
	case when year(data_nascita)<1800 then null
		else data_nascita 
	end	as 'datanasc',
	substring(rtrim(ltrim(LUOGO_NASCITA)),1,50) as 'localitanasc',
	case when len(rtrim(ltrim(A.CODICE_FISCALE))) = 16 then substring(rtrim(ltrim(A.CODICE_FISCALE)),12,4)
			else null
	end as 'catastalenasc',
	NULL as matricola,
	case
		when (  len(rtrim(ltrim(PARTITA_IVA)))> 15 AND len(rtrim(ltrim(A.CODICE_FISCALE)))> 16 
			AND ( len('p.iva:')+ len(rtrim(ltrim(PARTITA_IVA)))+ len('CF:') +len(rtrim(ltrim(A.CODICE_FISCALE)))+len(isnull(note,'')) <= @len_note))
		then ('p.iva:' + rtrim(ltrim(PARTITA_IVA))+  'CF:' + rtrim(ltrim(A.CODICE_FISCALE)) + isnull(note,''))

		when (  len(rtrim(ltrim(PARTITA_IVA)))> 15 AND ( len('p.iva:')+ len(rtrim(ltrim(PARTITA_IVA)))+ len(isnull(note,'')) <= @len_note))
		then ('p.iva:' + rtrim(ltrim(PARTITA_IVA))+  isnull(note,''))

		when (  len(rtrim(ltrim(A.CODICE_FISCALE)))> 16 AND ( len('CF:') +len(rtrim(ltrim(A.CODICE_FISCALE)))+len(isnull(note,'')) <= @len_note))
		then ('CF:' + rtrim(ltrim(A.CODICE_FISCALE)) + isnull(note,''))
	
		else note
	end as 'note',
	null as esenteeq,
/*	case when ((select count(*) from anagrafico A2 where A2.codice_fiscale = A.codice_fiscale)>1) then 'S'
			else 'N'
	end 'cfduplicato',*/
	case when isnull(TabCF.contatore,0)>1 then 'S' 
		else 'N'
	end as 'cfduplicato',
	case when (DATA_CANC is null ) then 'S'
		else 'N'
	end as 'attiva',
	null as dataind_res,
	null as indirizzo_res,
	null as cap_res,
	null as ufficio_res,
	null as catastale_res,
	null as localita_res,
	null as dataind_dom,
	null as indirizzo_dom,
	null as cap_dom,
	null as ufficio_dom,
	null as catastale_dom,
	null as localita_dom,
	null as tipomodpag,
	null as nomemod,
	null as abi,
	null as cab,
	null as cin,
	null as cc,
	null as delegato,
	null as valuta,
	null as tiposcadenza,
	null as ggscadenza,
	null as iban,
    null as datainizioposgiurid, --      datainizioposgiurid: Pos. 1376 lunghezza    8 Tipo:            Data Descrizione: Data Inizio Posizione giuridica
    null as imponpresunto, --            imponpresunto: Pos. 1384 lunghezza   22 Tipo:          Numero Descrizione: Imponibile presunto anno
    null as classestipendiale, --        classestipendiale: Pos. 1406 lunghezza    8 Tipo:          Intero Descrizione: Classe Stipendiale
    null as codicequalifica, --          codicequalifica: Pos. 1414 lunghezza   20 Tipo:         Stringa Descrizione: Codice Qualifica (deve corrispondere ad un codice già presente nel db)
    null as id_class_centralizzata, --   id_class_centralizzata: Pos. 1434 lunghezza   20 Tipo:         Stringa Descrizione: ID classificazione centralizzata
    null as descr_class_centralizzata, --descr_class_centralizzata: Pos. 1454 lunghezza   50 Tipo:         Stringa Descrizione: Descrizione class. centralizzata
    null as id_tipo_anagrafica, --       id_tipo_anagrafica: Pos. 1504 lunghezza   4  Tipo:          intero Descrizione: ID tipo anagrafica
    null as codice_tipo_anagrafica, --   codice_tipo_anagrafica: Pos. 1508 lunghezza   20 Tipo:         Stringa Descrizione: Codice tipo anagrafica
    null as descr_tipo_anagrafica, --    descr_tipo_anagrafica: Pos. 1528 lunghezza   50 Tipo:         Stringa Descrizione: descrizione tipo anagrafica
    null as idexternal --               idexternal: Pos. 1578 lunghezza    8 Tipo:          intero Descrizione: codice anagrafica esterno
FROM ANAGRAFICO A
JOIN lookup_anagrafica LKA
	ON LKA.codice = A.codice
LEFT OUTER JOIN TabCF
	ON A.codice_fiscale = TabCF.codice_fiscale
WHERE LKA.tipo ='A'

UNION

-- Esporta anagrafiche da DIPENDENTI
SELECT 
	LKA.idreg as 'codice',
	'22'as 'tipologia',
	case when isnull(D.nazione_residenza,'')='I'then 'I'	-- Italiana
		when isnull(D.nazione_residenza,'') in ('AT','BE','BG','CY','CZ','DE','DK','EE','EL','ES','FI','FR','GB','HR','HU','IE','IT','LT','LU','LV','MT','NL','PL','PT','RO','SE','SI','SK','SM') then 'J'
		else 'X'
	end as 'tiporesidenza',
	substring(rtrim(ltrim(D.cognome)),1,50)+ ' ' + substring(rtrim(ltrim(nome)),1,50) as 'denominazione',
	substring(rtrim(ltrim(D.nome)),1,50) as 'nome',
	substring(rtrim(ltrim(D.cognome)),1,50) as 'cognome',
	rtrim(ltrim(D.sesso)) as 'sesso',
	null as p_iva,
	substring(rtrim(ltrim(D.CODICE_FISCALE)),1,16) as cf,
	null as cf_ext,
	--GGMMAAA
	case when	(D.MM_NASCITA is not null and D.GG_NASCITA is not null and D.AAAA_NASCITA is not null)
		then	D.AAAA_NASCITA+'-'+D.MM_NASCITA + '-'+ D.GG_NASCITA
		else null
	end   as 'datanasc',
	substring(rtrim(ltrim(D.LUOGO_NASCITA)),1,50) as 'localitanasc',
	/*case when len(rtrim(ltrim(D.CODICE_FISCALE))) = 16 then substring(rtrim(ltrim(D.CODICE_FISCALE)),12,4)
			else null
	end as 'catastalenasc',*/
	case when len(rtrim(ltrim(comune_nascita))) = 4 then comune_nascita else null end as 'catastalenasc',
	NULL as 'matricola',
	null as 'note',
	null as 'esenteeq',
	'N'as 'cfduplicato',
	'S' as 'attiva',
	-- Domicilio RESIDENZA ------------------------------------------------
	case when D.luogo_residenza is not null then CONVERT(smalldatetime, '01-01-1900', 105) 
	else null
	end as 'dataind_res',
	substring(D.INDIRIZZO_RESIDENZA,1,100) as 'indirizzo_res',
	case when len(ltrim(rtrim(D.CAP_RESIDENZA))) = 5 then D.CAP_RESIDENZA else null end as 'cap_res',
	null as 'ufficio_res',
	case when len(rtrim(ltrim(C.codice)))= 4 then C.codice else null end as  'catastale_res',
	substring(luogo_residenza,1,50) as 'localita_res',
	-- Domicilio FISCALE ------------------------------------------------
	case when D.luogo_fiscale is not null then  CONVERT(smalldatetime, '01-01-1900', 105) 
	else null
	end as 'dataind_dom',
	substring(D.indirizzo_fiscale,1,100) as 'indirizzo_dom',
	case when len(rtrim(ltrim(cap_fiscale))) = 5 then rtrim(ltrim(cap_fiscale)) else null end as 'cap_dom',
	null as 'ufficio_dom',
	case when len(rtrim(ltrim(C2.codice)))=4 then rtrim(ltrim(C2.codice)) else null end as 'catastale_dom',
	substring(luogo_fiscale,1,50) as 'localita_dom',
	------------------------------------------------------------------------
	D.modalita_pagamento as 'tipomodpag',
	substring(RMP.descrizione,1,50) as 'nomemod',
	substring(ltrim(rtrim(D.abi)),1,10) as 'abi',
	substring(ltrim(rtrim(D.cab)),1,10) as 'cab',
	substring(ltrim(rtrim(D.cin)),1,5) as 'cin',
	substring(ltrim(rtrim(D.numero_conto)),1,30) as 'cc',
	null as 'delegato',
	null as 'valuta',
	null as 'tiposcadenza',
	null as 'ggscadenza',
	substring(ltrim(rtrim(D.iban)),1,50) as 'iban',
    null as datainizioposgiurid, --      datainizioposgiurid: Pos. 1376 lunghezza    8 Tipo:            Data Descrizione: Data Inizio Posizione giuridica
    null as imponpresunto, --            imponpresunto: Pos. 1384 lunghezza   22 Tipo:          Numero Descrizione: Imponibile presunto anno
    null as classestipendiale, --        classestipendiale: Pos. 1406 lunghezza    8 Tipo:          Intero Descrizione: Classe Stipendiale
    null as codicequalifica, --          codicequalifica: Pos. 1414 lunghezza   20 Tipo:         Stringa Descrizione: Codice Qualifica (deve corrispondere ad un codice già presente nel db)
    null as id_class_centralizzata, --   id_class_centralizzata: Pos. 1434 lunghezza   20 Tipo:         Stringa Descrizione: ID classificazione centralizzata
    null as descr_class_centralizzata, --descr_class_centralizzata: Pos. 1454 lunghezza   50 Tipo:         Stringa Descrizione: Descrizione class. centralizzata
    null as id_tipo_anagrafica, --       id_tipo_anagrafica: Pos. 1504 lunghezza   4  Tipo:          intero Descrizione: ID tipo anagrafica
    null as codice_tipo_anagrafica, --   codice_tipo_anagrafica: Pos. 1508 lunghezza   20 Tipo:         Stringa Descrizione: Codice tipo anagrafica
    null as descr_tipo_anagrafica, --    descr_tipo_anagrafica: Pos. 1528 lunghezza   50 Tipo:         Stringa Descrizione: descrizione tipo anagrafica
    null as idexternal --               idexternal: Pos. 1578 lunghezza    8 Tipo:          intero Descrizione: codice anagrafica esterno
FROM DIPENDENTI D
JOIN lookup_anagrafica LKA
	ON LKA.codice = D.codice
LEFT OUTER JOIN COMUNI C
	ON D.luogo_residenza = C.comune
LEFT OUTER JOIN COMUNI C2
	ON D.luogo_fiscale = C2.comune
LEFT OUTER JOIN RIF_MODALITA_PAGAMENTO RMP
  ON  RMP.CODICE = D.modalita_pagamento
WHERE LKA.tipo ='D' 

UNION

-- Esporta anagrafiche da CURR_DOCUMENTO_CONTABILE
SELECT DISTINCT
	LKA.idreg as 'codice',
	'22'as 'tipologia',
	'I'	as 'tiporesidenza',-- Italiana
	--case when (D.cognome is not null and D.nome is not null) then  substring(rtrim(ltrim(D.cognome)),1,50)+ ' ' + substring(rtrim(ltrim(nome)),1,50)
	--else substring(ltrim(rtrim(D.RAGIONE_SOCIALE)),1,100)
	--end
	(select top 1 (isnull(substring(ltrim(rtrim(D2.RAGIONE_SOCIALE)),1,100), substring(rtrim(ltrim(D2.cognome)),1,50)+ ' ' + substring(rtrim(ltrim(D2.nome)),1,50) ))
		from CURR_DOCUMENTO_CONTABILE D2
		where D.CODICE_ANAG = D2.CODICE_ANAG and D2.NOME is not null or D2.COGNOME is not null or D2.RAGIONE_SOCIALE is not null )
		as 'denominazione',
	(select top 1 substring(rtrim(ltrim(D2.nome)),1,50) from CURR_DOCUMENTO_CONTABILE D2
		where D.CODICE_ANAG = D2.CODICE_ANAG and D2.NOME is not null )as 'nome',
	(select top 1 substring(rtrim(ltrim(D2.cognome)),1,50) from CURR_DOCUMENTO_CONTABILE D2
		where D.CODICE_ANAG = D2.CODICE_ANAG and D2.cognome is not null ) as 'cognome',
	null as 'sesso',
	(select top 1 substring(ltrim(rtrim(D2.PARTITA_IVA)),1,15) from CURR_DOCUMENTO_CONTABILE D2
		where D.CODICE_ANAG = D2.CODICE_ANAG and D2.PARTITA_IVA is not null ) as p_iva,
	(select top 1 substring(rtrim(ltrim(D2.CODICE_FISCALE)),1,16) from CURR_DOCUMENTO_CONTABILE D2
		where D.CODICE_ANAG = D2.CODICE_ANAG and D2.CODICE_FISCALE is not null )as cf,
	null as cf_ext,
	null as 'datanasc',
	null as 'localitanasc',
	null as 'catastalenasc',
	NULL as 'matricola',
	null as 'note',
	null as 'esenteeq',
	'N'as 'cfduplicato',
	'S' as 'attiva',
	null as dataind_res,
	null as indirizzo_res,
	null as cap_res,
	null as ufficio_res,
	null as catastale_res,
	null as localita_res,
	null as dataind_dom,
	null as indirizzo_dom,
	null as cap_dom,
	null as ufficio_dom,
	null as catastale_dom,
	null as localita_dom,
	null as tipomodpag,
	null as nomemod,
	null as abi,
	null as cab,
	null as cin,
	null as cc,
	null as delegato,
	null as valuta,
	null as tiposcadenza,
	null as ggscadenza,
	null as iban,
    null as datainizioposgiurid, --      datainizioposgiurid: Pos. 1376 lunghezza    8 Tipo:            Data Descrizione: Data Inizio Posizione giuridica
    null as imponpresunto, --            imponpresunto: Pos. 1384 lunghezza   22 Tipo:          Numero Descrizione: Imponibile presunto anno
    null as classestipendiale, --        classestipendiale: Pos. 1406 lunghezza    8 Tipo:          Intero Descrizione: Classe Stipendiale
    null as codicequalifica, --          codicequalifica: Pos. 1414 lunghezza   20 Tipo:         Stringa Descrizione: Codice Qualifica (deve corrispondere ad un codice già presente nel db)
    null as id_class_centralizzata, --   id_class_centralizzata: Pos. 1434 lunghezza   20 Tipo:         Stringa Descrizione: ID classificazione centralizzata
    null as descr_class_centralizzata, --descr_class_centralizzata: Pos. 1454 lunghezza   50 Tipo:         Stringa Descrizione: Descrizione class. centralizzata
    null as id_tipo_anagrafica, --       id_tipo_anagrafica: Pos. 1504 lunghezza   4  Tipo:          intero Descrizione: ID tipo anagrafica
    null as codice_tipo_anagrafica, --   codice_tipo_anagrafica: Pos. 1508 lunghezza   20 Tipo:         Stringa Descrizione: Codice tipo anagrafica
    null as descr_tipo_anagrafica, --    descr_tipo_anagrafica: Pos. 1528 lunghezza   50 Tipo:         Stringa Descrizione: descrizione tipo anagrafica
    null as idexternal
FROM CURR_DOCUMENTO_CONTABILE D
JOIN lookup_anagrafica LKA
	ON LKA.codice = D.CODICE_ANAG
WHERE  (D.NOME is not null or D.COGNOME is not null or D.RAGIONE_SOCIALE is not null )
AND LKA.tipo ='U' 


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------	

--EXEC exp_anagrafica

------------------------------------------------------------------------------------------------------------------------------------------------------------
