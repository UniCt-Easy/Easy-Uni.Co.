
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
-- CREAZIONE VISTA sdi_venditaview
IF EXISTS(select * from sysobjects where id = object_id(N'[sdi_venditaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sdi_venditaview]
GO

 
-- clear_table_info 'sdi_venditaview'
-- select * from sdi_venditaview
-- setuser 'amm'

CREATE VIEW sdi_venditaview 
(
	idsdi_vendita,
	filename,
	zipfilename,
	adate,
	identificativo_sdi,
	flag_unseen,
	idsdi_status,
	sdi_status,
	position,
	codice_ufficio_ipa,
	codice_ufficio_rifamm,
	exist_ns,
	exist_mc,
	exist_rc,
	exist_ne,
	exist_dt,
	exist_at,
	idinvkind, invoicekind,yinv, ninv,invoiceadate,invoicedocdate,
	idsdi_deliverystatus,
	sdi_deliverystatus,
	lu, 
	lt,
	issigned,
	signedxml,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	idsdi_rifamm,
	ipa_fe,
	exported,
	arrivalprotocolnum,
	ns_prot,
	mc_prot,
	rc_prot,
	ne_prot,
	dt_prot,
	at_prot,
	signedxmlfilename
)
AS SELECT
	sdi_vendita.idsdi_vendita,
	sdi_vendita.filename,
	sdi_vendita.zipfilename,
	sdi_vendita.adate,
	sdi_vendita.identificativo_sdi,
	sdi_vendita.flag_unseen,
	sdi_vendita.idsdi_status,
	sdi_status.description,
	sdi_vendita.position,
	ipa.codiceufficio,
	sdi_rifamm.codiceufficio,
	case when flag_unseen&1<>0 then 'S' else'N' end,
	case when flag_unseen&2<>0 then 'S' else'N' end,
	case when flag_unseen&4<>0 then 'S' else'N' end,
	case when flag_unseen&8<>0 then 'S' else'N' end,
	case when flag_unseen&16<>0 then 'S' else'N' end,
	case when flag_unseen&32<>0 then 'S' else'N' end,
	invoice.idinvkind, invoicekind.description, invoice.yinv, invoice.ninv,	invoice.adate,		invoice.docdate,	
	sdi_vendita.idsdi_deliverystatus,
	sdi_deliverystatus.description,
	sdi_vendita.lu, 
	sdi_vendita.lt,
	sdi_vendita.issigned,
	sdi_vendita.signedxml,
	coalesce(invoice.idsor01,sdi_rifamm.idsor01,ipa.idsor01),
	coalesce(invoice.idsor02,sdi_rifamm.idsor02,ipa.idsor02),
	coalesce(invoice.idsor03,sdi_rifamm.idsor03,ipa.idsor03),
	coalesce(invoice.idsor04,sdi_rifamm.idsor04,ipa.idsor04),
	coalesce(invoice.idsor05,sdi_rifamm.idsor05,ipa.idsor05),
	sdi_vendita.idsdi_rifamm,
	sdi_vendita.ipa_fe,
	sdi_vendita.exported,
	sdi_vendita.arrivalprotocolnum,
	sdi_vendita.ns_prot,
	sdi_vendita.mc_prot,
	sdi_vendita.rc_prot,
	sdi_vendita.ne_prot,
	sdi_vendita.dt_prot,
	sdi_vendita.at_prot,
	sdi_vendita.signedxmlfilename
FROM sdi_vendita
LEFT OUTER JOIN sdi_status (nolock)	ON sdi_vendita.idsdi_status = sdi_status.idsdi_status
LEFT OUTER JOIN sdi_deliverystatus (nolock)	ON sdi_vendita.idsdi_deliverystatus = sdi_deliverystatus.idsdi_deliverystatus
LEFT OUTER JOIN invoice (nolock)	on sdi_vendita.idsdi_vendita = invoice.idsdi_vendita
LEFT OUTER JOIN invoicekind (nolock)	on invoicekind.idinvkind = invoice.idinvkind
LEFT OUTER JOIN sdi_rifamm (nolock)	on sdi_rifamm.idsdi_rifamm = sdi_vendita.idsdi_rifamm
LEFT OUTER JOIN ipa (nolock)	on ipa.ipa_fe = sdi_vendita.ipa_fe



GO

