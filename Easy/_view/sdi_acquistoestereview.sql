
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
-- CREAZIONE VISTA sdi_acquistoestereview
IF EXISTS(select * from sysobjects where id = object_id(N'[sdi_acquistoestereview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sdi_acquistoestereview]
GO

 
-- clear_table_info 'sdi_acquistoestereview'
-- select * from sdi_acquistoestereview
-- setuser 'amm'

CREATE VIEW sdi_acquistoestereview 
(
	idsdi_acquistoestere,
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
	--ne_prot,
	--dt_prot,
	--at_prot,
	signedxmlfilename
)
AS SELECT
	sdi_acquistoestere.idsdi_acquistoestere,
	sdi_acquistoestere.filename,
	sdi_acquistoestere.zipfilename,
	sdi_acquistoestere.adate,
	sdi_acquistoestere.identificativo_sdi,
	sdi_acquistoestere.flag_unseen,
	sdi_acquistoestere.idsdi_status,
	sdi_status.description,
	sdi_acquistoestere.position,
	ipa.codiceufficio,
	sdi_rifamm.codiceufficio,
	case when flag_unseen&1<>0 then 'S' else'N' end,
	case when flag_unseen&2<>0 then 'S' else'N' end,
	case when flag_unseen&4<>0 then 'S' else'N' end,
	invoice.idinvkind, invoicekind.description, invoice.yinv, invoice.ninv,	invoice.adate,		invoice.docdate,	
	sdi_acquistoestere.idsdi_deliverystatus,
	sdi_deliverystatus.description,
	sdi_acquistoestere.lu, 
	sdi_acquistoestere.lt,
	sdi_acquistoestere.issigned,
	sdi_acquistoestere.signedxml,
	coalesce(invoice.idsor01,sdi_rifamm.idsor01,ipa.idsor01),
	coalesce(invoice.idsor02,sdi_rifamm.idsor02,ipa.idsor02),
	coalesce(invoice.idsor03,sdi_rifamm.idsor03,ipa.idsor03),
	coalesce(invoice.idsor04,sdi_rifamm.idsor04,ipa.idsor04),
	coalesce(invoice.idsor05,sdi_rifamm.idsor05,ipa.idsor05),
	sdi_acquistoestere.idsdi_rifamm,
	sdi_acquistoestere.ipa_fe,
	sdi_acquistoestere.exported,
	sdi_acquistoestere.arrivalprotocolnum,
	sdi_acquistoestere.ns_prot,
	sdi_acquistoestere.mc_prot,
	sdi_acquistoestere.rc_prot,
	sdi_acquistoestere.signedxmlfilename
FROM sdi_acquistoestere
LEFT OUTER JOIN sdi_status (nolock)	ON sdi_acquistoestere.idsdi_status = sdi_status.idsdi_status
LEFT OUTER JOIN sdi_deliverystatus (nolock)	ON sdi_acquistoestere.idsdi_deliverystatus = sdi_deliverystatus.idsdi_deliverystatus
LEFT OUTER JOIN invoice (nolock)	on sdi_acquistoestere.idsdi_acquistoestere = invoice.idsdi_acquistoestere
LEFT OUTER JOIN invoicekind (nolock)	on invoicekind.idinvkind = invoice.idinvkind
LEFT OUTER JOIN sdi_rifamm (nolock)	on sdi_rifamm.idsdi_rifamm = sdi_acquistoestere.idsdi_rifamm
LEFT OUTER JOIN ipa (nolock)	on ipa.ipa_fe = sdi_acquistoestere.ipa_fe



GO

