GO
-- CREAZIONE VISTA sdi_venditaview
IF EXISTS(select * from sysobjects where id = object_id(N'[sdi_venditaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [sdi_venditaview]
GO

 
-- clear_table_info 'sdi_venditaview'
-- select * from sdi_venditaview

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
	idinvkind, invoicekind,yinv, ninv,
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
	idsor05
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
	invoice.idinvkind, invoicekind.description, invoice.yinv, invoice.ninv,	
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
	coalesce(invoice.idsor05,sdi_rifamm.idsor05,ipa.idsor05)
FROM sdi_vendita
LEFT OUTER JOIN sdi_status (nolock)
	ON sdi_vendita.idsdi_status = sdi_status.idsdi_status
LEFT OUTER JOIN sdi_deliverystatus (nolock)
	ON sdi_vendita.idsdi_deliverystatus = sdi_deliverystatus.idsdi_deliverystatus
LEFT OUTER JOIN invoice (nolock)
	on sdi_vendita.idsdi_vendita = invoice.idsdi_vendita
LEFT OUTER JOIN invoicekind (nolock)
	on invoicekind.idinvkind = invoice.idinvkind
LEFT OUTER JOIN sdi_rifamm (nolock)
	on sdi_rifamm.idsdi_rifamm = sdi_vendita.idsdi_rifamm
LEFT OUTER JOIN ipa (nolock)
	on ipa.ipa_fe = sdi_vendita.ipa_fe



GO

