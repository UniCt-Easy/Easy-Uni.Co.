
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


GO
-- CREAZIONE VISTA sdi_acquistoipaview
IF EXISTS(select * from sysobjects where id = object_id(N'[sdi_acquistoipaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sdi_acquistoipaview]
GO

--setuser 'amm'
-- clear_table_info 'sdi_acquistoipaview'

CREATE VIEW sdi_acquistoipaview 
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
	ipa_fe,
	total,
	discount_amount,
	idinvkind, yinv, ninv,
	arrivalprotocolnum,
	rejectreason,
	existsinvoice,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	lu, 
	lt,
	utente_accettata,
	data_accettata,
	utente_rifiutata,
	data_rifiutata,
	tipodocumento,
	notcreacontabilita,
	notcreacontabilitareason,
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
	ipa.ipa_fe,
	sdi_acquisto.total,
	sdi_acquisto.discount_amount,
	invoice.idinvkind, invoice.yinv, invoice.ninv,	
	sdi_acquisto.arrivalprotocolnum,
	sdi_acquisto.rejectreason,
	case when invoice.idinvkind is not null then 'S' else 'N' end,
	ipa.idsor01,
	ipa.idsor02,
	ipa.idsor03,
	ipa.idsor04,
	ipa.idsor05,
	sdi_acquisto.lu, 
	sdi_acquisto.lt,
	sdi_acquisto.utente_accettata,
	sdi_acquisto.data_accettata,
	sdi_acquisto.utente_rifiutata,
	sdi_acquisto.data_rifiutata,
	sdi_acquisto.tipodocumento,
	sdi_acquisto.notcreacontabilita,
	sdi_acquisto.notcreacontabilitareason,
	sdi_acquisto.data_ricezione
FROM sdi_acquisto
LEFT OUTER JOIN ipa
	on sdi_acquisto.codice_ipa = ipa.ipa_fe
LEFT OUTER JOIN sdi_status
	ON sdi_acquisto.idsdi_status = sdi_status.idsdi_status
LEFT OUTER JOIN invoice
	on sdi_acquisto.idsdi_acquisto = invoice.idsdi_acquisto

GO


