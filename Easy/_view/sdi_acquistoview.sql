
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


GO
-- CREAZIONE VISTA sdi_acquistoview
IF EXISTS(select * from sysobjects where id = object_id(N'[sdi_acquistoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sdi_acquistoview]
GO

--setuser 'amm'
-- clear_table_info 'sdi_acquistoview'
-- select * from sdi_acquistoview
CREATE VIEW sdi_acquistoview 
(
	idsdi_acquisto,
	filename,
	zipfilename,
	adate,
	protocoldate,
	identificativo_sdi,
	ec_sent,
	flag_unseen,
	idsdi_status,
	sdi_status,
	position,
	ec_number,
	exist_mt,
	exist_ec,
	exist_se,
	exist_dt,
	title,
	description,
	ninvoice,
	riferimento_amministrazione,
	codice_ipa,
	ipa,
	total,
	discount_amount,
	idinvkind, yinv, ninv,
	arrivalprotocolnum,
	rejectreason,
	existsinvoice,
	tipodocumento,
	lu, 
	lt,
	utente_accettata,
	data_accettata,
	utente_rifiutata,
	data_rifiutata,
	notcreacontabilita,
	data_ricezione
)
AS SELECT
	sdi_acquisto.idsdi_acquisto,
	sdi_acquisto.filename,
	sdi_acquisto.zipfilename,
	sdi_acquisto.adate,
	sdi_acquisto.protocoldate,
	sdi_acquisto.identificativo_sdi,
	sdi_acquisto.ec_sent,
	sdi_acquisto.flag_unseen,
	sdi_acquisto.idsdi_status,
	sdi_status.description,
	sdi_acquisto.position,
	sdi_acquisto.ec_number,
	case when flag_unseen&1<>0 then 'S' else'N' end,
	case when flag_unseen&2<>0 then 'S' else'N' end,
	case when flag_unseen&4<>0 then 'S' else'N' end,
	case when flag_unseen&8<>0 then 'S' else'N' end,
	sdi_acquisto.title,
	sdi_acquisto.description,
	sdi_acquisto.ninvoice,
	sdi_acquisto.riferimento_amministrazione,
	sdi_acquisto.codice_ipa,
	IPA.officename,
	sdi_acquisto.total,
	sdi_acquisto.discount_amount,
	invoice.idinvkind, invoice.yinv, invoice.ninv,	
	sdi_acquisto.arrivalprotocolnum,
	sdi_acquisto.rejectreason,
	case when invoice.idinvkind is not null then 'S' else 'N' end,
	sdi_acquisto.tipodocumento,
	sdi_acquisto.lu, 
	sdi_acquisto.lt,
	sdi_acquisto.utente_accettata,
	sdi_acquisto.data_accettata,
	sdi_acquisto.utente_rifiutata,
	sdi_acquisto.data_rifiutata,
	sdi_acquisto.notcreacontabilita,
	sdi_acquisto.data_ricezione
FROM sdi_acquisto
LEFT OUTER JOIN sdi_status			ON sdi_acquisto.idsdi_status = sdi_status.idsdi_status
LEFT OUTER JOIN invoice				on sdi_acquisto.idsdi_acquisto = invoice.idsdi_acquisto
LEFT OUTER JOIN IPA					on sdi_acquisto.codice_ipa = IPA.ipa_fe


GO

 
