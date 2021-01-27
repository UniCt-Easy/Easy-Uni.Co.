
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


-- CREAZIONE VISTA invoiceview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoiceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoiceview]
GO

-- setuser 'amm' 
-- clear_table_info'invoiceview'
-- select * from  invoiceview
CREATE  VIEW [invoiceview]
(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	ipa_fe,
	cf,
	p_iva,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	protocoldate,
	packinglistnum,
	packinglistdate,
	officiallyprinted,
	flagdeferred,
	taxable,
	tax,
	unabatable,
	total,
	active,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	ycon,
	ncon,
	idintrastatnation_origin,
	intrastatnation_origin,
	idintrastatnation_provenance,	
	intrastatnation_provenance,
	idintrastatnation_destination,
	intrastatnation_destination,
	idcountry_origin,
	country_origin,
	idcountry_destination,
	country_destination,
	flagintracom,
	idintrastatkind,
	intrastatkind,
	idintrastatnation_payment,
	intrastatnation_payment,
	idintrastatpaymethod,
	intrastatpaymethod,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	flag_invoice,
	totransmit,
	idblacklist,
	idblnation,
	blnation,
	blcode,
	idinvkind_real,
	invkind_real,
	yinv_real, 
	ninv_real,
	autoinvoice,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	nelectronicinvoice,
	yelectronicinvoice,
	idfepaymethodcondition,
	idfepaymethod,
	idtreasurer,
	iduniqueregister,
	annotations,
	arrivalprotocolnum,
	toincludeinpaymentindicator,
	resendingpcc,
	--expensekind,
	--expensekinddescription,
	touniqueregister,
	expirationkind,
	expiring,
	idstampkind,
	flag_enable_split_payment,
	flag_auto_split_payment,
	flag_reverse_charge,
	idsdi_acquisto,
	sdi_codice_ipa,
	sdi_riferimento_amministrazione,
	idsdi_status,
	sdi_status,
	flag_unseen,
	sdi_se,	-- Solo acquisto
	sdi_ns, -- Solo vendita
	sdi_mc, -- Solo vendita
	sdi_rc, -- Solo vendita
	sdi_ne, -- Solo vendita
	sdi_at, -- Solo vendita
	sdi_dt, -- acquisto e ventia
	idsdi_vendita,
	idsdi_deliverystatus,
	ipa_acq,
	rifamm_acq,
	ipa_ven_emittente,
	rifamm_ven_emittente,
	ipa_ven_cliente,
	rifamm_ven_cliente,
	email_ven_cliente,
	pec_ven_cliente,
	rounding,
	ssntipospesa,
	ssnflagtipospesa,
	idinvkind_forwarder,
	codeinvkind_forwarder,
	invkind_forwarder,
	yinv_forwarder,
	ninv_forwarder,
	flag_bolladoganale,
	flag_fattspedizioniere,
	escludiinvio,
	flagbit,
	requested_doc,
	idreg_sostituto,
	registry_sostituto,
	forename_sostituto,
	surname_sostituto,
	cf_sostituto,
	p_iva_sostituto,
	flaghuman_sostituto,
	cc_dedicato,visura_camerale,durc,
	flag_ddt,
	idnocigmotive
	)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	registry.ipa_fe,
	registry.cf,
	registry.p_iva,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.idcurrency,
	currency.codecurrency,
	currency.description,
	invoice.exchangerate,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	invoice.protocoldate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	--invoice.flagintra,
	invoice.officiallyprinted,
	invoice.flagdeferred,
	ISNULL(
		(SELECT
 	    	SUM(
			ROUND(D.taxable * ISNULL(D.npackage,D.number) * CONVERT(decimal(19,10),M.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(D.discount, 0.0)))
			,2)
		)
		FROM invoicedetail D
		JOIN invoice M
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	ISNULL(
		(SELECT SUM(ROUND(D.tax ,2))
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	ISNULL(
		(SELECT
		SUM(ROUND(D.unabatable ,2))
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	ISNULL(
		(SELECT
 	    	SUM(
			ROUND(D.taxable * ISNULL(D.npackage,D.number)* CONVERT(decimal(19,10),M.exchangerate) *
				(1 - CONVERT(decimal(19,6),ISNULL(D.discount, 0.0)))
			,2)
		)
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0) +
	ISNULL(
		(SELECT SUM(ROUND(D.tax,2))
		FROM invoicedetail D
		JOIN invoice M 
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv)
	, 0),
	invoice.active,
	invoice.txt,
	invoice.cu, 
	invoice.ct, 
	invoice.lu,
	invoice.lt,
	null,
	null,
	invoice.iso_origin,
	ination_origin.description,
	invoice.iso_provenance,
	ination_provenance.description,
	invoice.iso_destination,
	ination_destination.description,
	invoice.idcountry_origin,
	country_origin.title,
	idcountry_destination,
	country_destination.title,
	invoice.flagintracom,
	invoice.idintrastatkind,
	intrastatkind.description,
	invoice.iso_payment,
	ination_payment.description,
	intrastatpaymethod.idintrastatpaymethod,
	intrastatpaymethod.description,
	AD.idaccmotive,
	AD.codemotive,
	ADCRG.idaccmotive,
	ADCRG.codemotive,
	invoice.idaccmotivedebit_datacrg,
	invoice.flag,
	CASE
		WHEN (invoice.flag=0) THEN 'S' 
		WHEN (invoice.flag=1) THEN 'N' 
		WHEN (invoice.flag=2) THEN 'Non Spec.' 
	END, 
	invoice.idblacklist,
	blacklist.idnation,
	blacklist.description,
	blacklist.blcode,
	invoice.idinvkind_real,
	M.description,
	invoice.yinv_real, 
	invoice.ninv_real,
	invoice.autoinvoice,
	isnull(invoice.idsor01,invoicekind.idsor01),
	isnull(invoice.idsor02,invoicekind.idsor02),
	isnull(invoice.idsor03,invoicekind.idsor03),
	isnull(invoice.idsor04,invoicekind.idsor04),
	isnull(invoice.idsor05,invoicekind.idsor05)	,
	invoice.nelectronicinvoice,
	invoice.yelectronicinvoice,
	invoice.idfepaymethodcondition,
	invoice.idfepaymethod ,
	invoice.idtreasurer,
	uniqueregister.iduniqueregister,
	invoice.annotations,
	invoice.arrivalprotocolnum,
	invoice.toincludeinpaymentindicator,
	invoice.resendingpcc,
	/*invoice.expensekind,
	case 
		when invoice.expensekind='CO' then 'Spesa corrente'
		when invoice.expensekind='CA' then 'Conto capitale'
		else null
	end,*/
	invoice.touniqueregister,
	expirationkind.description,
	dateadd(day,isnull(invoice.paymentexpiring,0),
	case 
		when (invoice.idexpirationkind=1) then invoice.adate
		when (invoice.idexpirationkind=2) then invoice.docdate
		when (invoice.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.docdate) ,invoice.docdate)))
		when (invoice.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.adate) ,invoice.adate)))
		when (invoice.idexpirationkind=5) then invoice.adate
		when (invoice.idexpirationkind=6) then invoice.protocoldate
	end
	),
	invoice.idstampkind,
	flag_enable_split_payment,
	flag_auto_split_payment,
	flag_reverse_charge,
	sdi_acquisto.idsdi_acquisto,
	sdi_acquisto.codice_ipa,
	sdi_acquisto.riferimento_amministrazione,
	CASE
		WHEN ((invoicekind.flag&1)=0 ) THEN sdi_acquisto.idsdi_status
		when ((invoicekind.flag&1)<>0) then sdi_vendita.idsdi_status
		else null
	END,
	CASE
		WHEN ((invoicekind.flag&1)=0 ) THEN status_acq.description
		when ((invoicekind.flag&1)<>0) then status_ven.description
		else null
	END,
	isnull(sdi_acquisto.flag_unseen,sdi_vendita.flag_unseen),
	-- Solo acquisto
	case when sdi_acquisto.flag_unseen&4<>0 then 'Notifica di scarto esito Committente'else null end, --SE
	-- case when  sdi_acquisto.flag_unseen&8<>0 then 'Notifica decorrenza termini'else null end, -- DT

	-- Solo vendita
	case when sdi_vendita.flag_unseen&1<>0 then 'Notifica di scarto' else null end, -- NS
	case when sdi_vendita.flag_unseen&2<>0 then 'Notifica di mancata consegna' else null end, --MC
	case when sdi_vendita.flag_unseen&4<>0 then 'Ricevuta di consegna' else null end, --RC
	case when sdi_vendita.flag_unseen&8<>0 then 'Notifica esito cedente / prestatore' else null end, -- NE
	-- case when sdi_vendita.flag_unseen&16<>0 then 'Notifica decorrenza termini' else null end, -- DT
	case when sdi_vendita.flag_unseen&32<>0 then 'Attestazione di avvenuta trasmissione con impossibilità di recapito' else null end, -- AT
	
	-- Acquisto e vendita
	CASE
		WHEN ((invoicekind.flag&1)=0 and sdi_acquisto.flag_unseen&8<>0 ) OR ((invoicekind.flag&1)<>0 and sdi_vendita.flag_unseen&16<>0 ) THEN 'Notifica decorrenza termini'
		else null
	END,--DT
	sdi_vendita.idsdi_vendita,
	sdi_vendita.idsdi_deliverystatus,
	invoice.ipa_acq,
	invoice.rifamm_acq,
	invoice.ipa_ven_emittente,
	invoice.rifamm_ven_emittente,
	invoice.ipa_ven_cliente,
	invoice.rifamm_ven_cliente,	
	invoice.email_ven_cliente,
	invoice.pec_ven_cliente,
	ISNULL(
		(SELECT
 	    	SUM(
			ROUND(D.taxable * ISNULL(D.npackage,D.number) * CONVERT(decimal(19,10),M.exchangerate) *
			(1 - CONVERT(decimal(19,6),ISNULL(D.discount, 0.0)))
			,2)
		)
		FROM invoicedetail D
		JOIN invoice M
		ON D.idinvkind = M.idinvkind
		AND D.yinv = M.yinv
		AND D.ninv = M.ninv
		WHERE D.idinvkind = invoice.idinvkind
		AND D.yinv = invoice.yinv
		AND D.ninv = invoice.ninv
		AND (ISNULL(D.rounding,'N') ='S'   OR (isnull(D.flagbit,0) & 4)<>0)
		)
	, 0),--rounding : arrotondamenti e costi di incasso
	invoice.ssntipospesa,
	invoice.ssnflagtipospesa,
	invoice.idinvkind_forwarder,
	Forwarder.codeinvkind,
	Forwarder.description,
	invoice.yinv_forwarder,
	invoice.ninv_forwarder,
	 --flag_bolladoganale,
	CASE 	when (invoice.flagbit & 1 <>0) THEN 'S' 	else 'N'	END,
	--flag_fattspedizioniere
	CASE	when (invoice.flagbit & 2 <>0) THEN 'S' 	else 'N'	END,
	CASE	when (invoice.flagbit & 8 <>0) THEN 'S' 	else 'N'	END,
	flagbit,
	invoice.requested_doc,
	registry_sostituto.idreg,
	registry_sostituto.title,
	registry_sostituto.forename,
	registry_sostituto.surname,
	registry_sostituto.cf,
	registry_sostituto.p_iva,
	registryclass.flaghuman,
	case when invoice.requested_doc & 1 <> 0 then 'S' else 'N' end,
	case when invoice.requested_doc & 2 <> 0 then 'S' else 'N' end,
	case when invoice.requested_doc & 4 <> 0 then 'S' else 'N' end,
	invoice.flag_ddt,
	invoice.idnocigmotive

	
FROM invoice WITH (NOLOCK)
JOIN invoicekind WITH (NOLOCK)										ON invoicekind.idinvkind = invoice.idinvkind
JOIN registry  WITH (NOLOCK)										ON registry.idreg = invoice.idreg
LEFT OUTER JOIN currency  WITH (NOLOCK)								ON currency.idcurrency = invoice.idcurrency
LEFT OUTER JOIN intrastatnation ination_origin  WITH (NOLOCK)	ON ination_origin.idintrastatnation= invoice.iso_origin
LEFT OUTER JOIN intrastatnation ination_provenance  WITH (NOLOCK)	ON ination_provenance.idintrastatnation= invoice.iso_provenance
LEFT OUTER JOIN intrastatnation ination_destination  WITH (NOLOCK)	ON ination_destination.idintrastatnation= invoice.iso_destination
LEFT OUTER JOIN geo_country country_origin WITH (NOLOCK)			ON country_origin.idcountry= invoice.idcountry_origin
LEFT OUTER JOIN geo_country country_destination WITH (NOLOCK)		ON country_destination.idcountry= invoice.idcountry_destination
LEFT OUTER JOIN intrastatnation ination_payment  WITH (NOLOCK)		ON ination_payment.idintrastatnation= invoice.iso_payment
LEFT OUTER JOIN intrastatpaymethod WITH (NOLOCK)					ON invoice.idintrastatpaymethod = intrastatpaymethod.idintrastatpaymethod
LEFT OUTER JOIN intrastatkind WITH (NOLOCK)							ON intrastatkind.idintrastatkind= invoice.idintrastatkind
LEFT OUTER JOIN accmotive AD WITH (NOLOCK)							ON AD.idaccmotive = invoice.idaccmotivedebit
LEFT OUTER JOIN accmotive ADCRG WITH (NOLOCK)						ON ADCRG.idaccmotive = invoice.idaccmotivedebit_crg
LEFT OUTER JOIN blacklist WITH (NOLOCK)								ON blacklist.idblacklist = invoice.idblacklist
LEFT OUTER JOIN invoicekind M WITH (NOLOCK)							ON M.idinvkind = invoice.idinvkind_real
LEFT OUTER JOIN uniqueregister										ON uniqueregister.idinvkind = invoice.idinvkind
																		AND uniqueregister.ninv = invoice.ninv	AND uniqueregister.yinv = invoice.yinv	
LEFT OUTER JOIN expirationkind										ON invoice.idexpirationkind = expirationkind.idexpirationkind
LEFT OUTER JOIN sdi_acquisto										on sdi_acquisto.idsdi_acquisto = invoice.idsdi_acquisto
LEFT OUTER JOIN sdi_status status_acq								ON sdi_acquisto.idsdi_status = status_acq.idsdi_status
LEFT OUTER JOIN sdi_vendita											on sdi_vendita.idsdi_vendita = invoice.idsdi_vendita
LEFT OUTER JOIN sdi_status status_ven								ON sdi_vendita.idsdi_status = status_ven.idsdi_status
LEFT OUTER JOIN invoicekind Forwarder								ON Forwarder.idinvkind = invoice.idinvkind_forwarder
LEFT OUTER JOIN registry registry_sostituto							ON registry_sostituto.idreg = invoice.idreg_sostituto	
LEFT OUTER JOIN registryclass										ON registryclass.idregistryclass = registry_sostituto.idregistryclass
GO



 
