
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


-- CREAZIONE VISTA mandateview
IF EXISTS(select * from sysobjects where id = object_id(N'[mandateview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandateview]
GO
-- setuser 'amm'
-- clear_table_info'mandateview'
-- select * from mandateview
CREATE VIEW [mandateview]
(
	idmankind,
	yman,
	nman,
	mankind,
	idreg,
	registry,
	registryreference,
	description,
	idman,
	manager,
	deliveryexpiration,
	deliveryaddress,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	taxable_euro,
	iva_euro,
	total,
	active,
	flagintracom,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivedebit_crg,
	codemotivedebit_crg,
	idaccmotivedebit_datacrg,
	applierannotations,
	idmandatestatus,
	mandatestatus,
	idstore,
	store,
	statusimage,
	listingorder,
	linkedtotal,
	isrequest,
	cigcode,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	idconsipkind,
	consipkind,
	idconsipkind_ext,
	consipkind_ext,
	consipmotive,
	flagdanger,
	mankind_origin,
	idmankind_origin,
	yman_origin,
	nman_origin,
	mankind_dest,
	idmankind_dest,
	yman_dest,
	nman_dest,
	subappropriation,
	finsubappropriation,
	adatesubappropriation,
	arrivalprotocolnum,
	arrivaldate,
	annotations,
	iduniqueregister,
	resendingpcc,
	ipa_fe,
	expirationkind,
	expiration	/*,
	expensekind,
	expensekinddescription*/
	, external_reference,
	officecode,
	officedescription,
	officetitle,
	flagtenderresult,
	motiveassignment,
	anacreduced,
	idreg_rupanac,
	rupanac,
	tenderresult,
	tenderkind,
	tenderkinddescr,
	publishdate,
	publishdatekind,
	publishdatekinddescr,
	requested_doc,
	flagbit
	)
AS SELECT
	mandate.idmankind,
	mandate.yman,
	mandate.nman,
	mandatekind.description,
	mandate.idreg,
	registry.title,
	mandate.registryreference,
	mandate.description,
	mandate.idman,
	manager.title,
	mandate.deliveryexpiration,
	mandate.deliveryaddress,
	mandate.paymentexpiring,
	mandate.idexpirationkind,
	mandate.idcurrency,
	currency.codecurrency,
	currency.description,
	mandate.exchangerate,
	mandate.doc,
	mandate.docdate,
	mandate.adate,
	mandate.officiallyprinted,
	mandate.txt,
	mandate.cu, 
	mandate.ct, 
	mandate.lu, 
	mandate.lt,
	-- taxable_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
					CONVERT(decimal(19,6), m.exchangerate) *
					(1 - CONVERT(decimal(19,6), ISNULL(mandatedetail.discount, 0.0)))
				,2)
			)
		FROM mandatedetail
		JOIN mandate m
			ON mandatedetail.idmankind = mandate.idmankind
			AND mandatedetail.yman = mandate.yman
			AND mandatedetail.nman = mandate.nman
		WHERE m.idmankind = mandate.idmankind
			AND m.yman = mandate.yman
			AND m.nman = mandate.nman
			AND mandatedetail.stop IS NULL
		)
	,0),
	-- iva_euro
	ISNULL(
		(SELECT
			SUM(
				ROUND(mandatedetail.tax ,2)
			)
		FROM mandatedetail
		JOIN mandate m
			ON mandatedetail.idmankind = mandate.idmankind
			AND mandatedetail.yman = mandate.yman
			AND mandatedetail.nman = mandate.nman
		WHERE m.idmankind = mandate.idmankind
			AND m.yman = mandate.yman
			AND m.nman = mandate.nman
			AND mandatedetail.stop IS NULL
		)
	,0),
	-- total
	ISNULL(
		(SELECT
			SUM(
				ISNULL(
					ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
						CONVERT(decimal(19,6), m.exchangerate) *
						(1 - CONVERT(decimal(19,6), ISNULL(mandatedetail.discount, 0.0)))
					,2)
				,0) +
				ISNULL(
					ROUND(mandatedetail.tax,2)
				,0)
			)
		FROM mandatedetail
		JOIN mandate m
			ON mandatedetail.idmankind = mandate.idmankind
			AND mandatedetail.yman = mandate.yman
			AND mandatedetail.nman = mandate.nman
		WHERE m.idmankind = mandate.idmankind
			AND m.yman = mandate.yman
			AND m.nman = mandate.nman
			AND mandatedetail.stop IS NULL
		)
	,0),
	mandate.active,
	mandate.flagintracom,
	AD.idaccmotive,
	AD.codemotive,
	ADCRG.idaccmotive,
	ADCRG.codemotive,
	mandate.idaccmotivedebit_datacrg,
	mandate.applierannotations,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandate.idstore,
	store.description,
	(case when mandate.idmandatestatus=1 then '<center><img src="Immagini/bozza.png" title="Bozza" alt="Bozza"/></center>'
		  when mandate.idmandatestatus=2 then '<center><img src="Immagini/richiesta.png" title="Richiesta" alt="Richiesta"/></center>'
		  when mandate.idmandatestatus=3 then '<center><img src="Immagini/dacorreggere.png" title="Da Correggere" alt="Da Correggere"/></center>'
		  when mandate.idmandatestatus=4 then '<center><img src="Immagini/inserito.png" title="Inserito" alt="Inserito"/></center>'
		  when mandate.idmandatestatus=5 then '<center><img src="Immagini/approvato.png" title="Approvato" alt="Approvato"/></center>'
		  when mandate.idmandatestatus=6 then '<center><img src="Immagini/annullato.png" title="Annullato" alt="Annullato"/></center>'
		  when mandate.idmandatestatus=null then ''
		  end
		  ),
	mandatestatus.listingorder,
	ISNULL(

	CONVERT(DECIMAL(19,2),
		(SELECT SUM(
		    CASE 
			WHEN (mandatedetail.idexp_taxable IS NOT NULL) AND ( mandatedetail.idexp_iva IS NULL)
			THEN
			     ROUND(
						ISNULL(mandatedetail.taxable,0) * 
							ISNULL(mandatedetail.npackage,mandatedetail.number)*
					CONVERT(decimal(19,6),md.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0)))

					,2)
			WHEN ( mandatedetail.idexp_iva IS NOT NULL) AND (mandatedetail.idexp_taxable IS  NULL)
			THEN
			     ROUND( ISNULL(mandatedetail.tax,0)  ,2)
			WHEN ( mandatedetail.idexp_iva IS NOT NULL) AND (mandatedetail.idexp_taxable IS NOT NULL)
			THEN
			     ROUND((ISNULL(mandatedetail.taxable,0) * ISNULL(mandatedetail.npackage,mandatedetail.number)* 
						CONVERT(decimal(19,6),md.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0)))
					
				 + ISNULL(mandatedetail.tax,0))  ,2)
			ELSE   0
		    END
		   )
		FROM mandatedetail 
			join mandate md on (
				mandatedetail.idmankind = md.idmankind
				AND  mandatedetail.yman = md.yman
				AND  mandatedetail.nman = md.nman
			)
				WHERE mandatedetail.idmankind = mandate.idmankind
				AND  mandatedetail.yman = mandate.yman
				AND  mandatedetail.nman = mandate.nman
			AND mandatedetail.stop is null
			)
			)			
		,0)
 
	AS linkedtotal,
	mandatekind.isrequest,
	mandate.cigcode,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandate.idconsipkind,
	CONSIP.description,
	mandate.idconsipkind_ext,
	CONSIP_EXT.description,
	mandate.consipmotive,
	isnull(mandate.flagdanger,'N'),
	mandatekind_origin.description,
	mandate.idmankind_origin,
	mandate.yman_origin,
	mandate.nman_origin,
	mandatekind_dest.description,
	m_dest.idmankind,
	m_dest.yman,
	m_dest.nman,
	mandate.subappropriation,
	mandate.finsubappropriation,
	mandate.adatesubappropriation,
	mandate.arrivalprotocolnum,
	mandate.arrivaldate,
	mandate.annotations,
	uniqueregister.iduniqueregister,
	mandate.resendingpcc,
	mandatekind.ipa_fe,
	expirationkind.description,
	dateadd(day,isnull(mandate.paymentexpiring,0),
	case 
		when (mandate.idexpirationkind=1) then mandate.adate
		when (mandate.idexpirationkind=2) then mandate.docdate
		when (mandate.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(mandate.docdate) ,mandate.docdate)))
		when (mandate.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(mandate.adate) ,mandate.adate)))
		when (mandate.idexpirationkind=5) then mandate.adate
		when (mandate.idexpirationkind=6) then mandate.arrivaldate
	end
	)/*,
	mandate.expensekind,
	case 
		when mandate.expensekind='CO' then 'Spesa corrente'
		when mandate.expensekind='CA' then 'Conto capitale'
		else null
	end*/
	,mandate.external_reference,
	office.code,
	office.description,
	office.title,
	mandate.flagtenderresult,
	mandate.motiveassignment,
	mandate.anacreduced,
	mandate.idreg_rupanac,
	RUP.title,
	CASE mandate.flagtenderresult
		 WHEN 'A' THEN 'Aggiudicata'
		 WHEN 'D' THEN 'Andata deserta'
		 WHEN 'N' THEN 'Senza esito per offerte non congrue'
		ELSE NULL
	END,
	mandate.tenderkind,
	case mandate.tenderkind 
		WHEN 'B' THEN 'Bando'
		WHEN 'AV' THEN 'Avviso'
		WHEN 'AF' THEN 'Affidamento'
		WHEN 'DE' THEN 'Determina (art. 32 comma 2 dlgs 50/2016)'
	   ELSE NULL
	END,
	mandate.publishdate,
	mandate.publishdatekind,
	case mandate.publishdatekind
		WHEN 'C' THEN 'data perfezionamento contratto'
		WHEN 'Q' THEN 'data perfezionamento adesione ad accordo quadro'
		WHEN 'V' THEN 'data convenzione'
		WHEN 'M' THEN 'data acquisto su MEPA'
	 ELSE NULL
	END,
	mandate.requested_doc,
	mandate.flagbit
FROM mandate with (nolock)
JOIN mandatekind with (nolock)  	ON mandatekind.idmankind = mandate.idmankind
LEFT OUTER JOIN mandatekind mandatekind_origin with (nolock) 	ON mandatekind_origin.idmankind = mandate.idmankind_origin
LEFT OUTER JOIN mandate m_dest with (nolock) 	ON m_dest.idmankind_origin = mandate.idmankind
						AND m_dest.yman_origin = mandate.yman
						AND m_dest.nman_origin = mandate.nman
LEFT OUTER JOIN mandatekind mandatekind_dest with (nolock)	ON mandatekind_dest.idmankind = m_dest.idmankind
LEFT OUTER JOIN registry with (nolock)						ON registry.idreg = mandate.idreg
LEFT OUTER JOIN currency with (nolock)						ON currency.idcurrency = mandate.idcurrency
LEFT OUTER JOIN manager with (nolock)						ON manager.idman = mandate.idman
LEFT OUTER JOIN accmotive AD with (nolock)					ON AD.idaccmotive = mandate.idaccmotivedebit
LEFT OUTER JOIN accmotive ADCRG with (nolock)				ON ADCRG.idaccmotive = mandate.idaccmotivedebit_crg
LEFT OUTER JOIN mandatestatus with (nolock)					ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN store  with (nolock)						ON store.idstore = mandate.idstore
LEFT OUTER JOIN uniqueregister
	on uniqueregister.idmankind = mandate.idmankind
	and uniqueregister.yman = mandate.yman
	and uniqueregister.nman = mandate.nman
LEFT OUTER JOIN expirationkind								ON mandate.idexpirationkind = expirationkind.idexpirationkind
LEFT OUTER JOIN office										on office.idoffice = mandate.idoffice
LEFT OUTER JOIN registry as RUP								ON RUP.idreg = mandate.idreg_rupanac
LEFT OUTER JOIN consipkind as CONSIP						ON CONSIP.idconsipkind = mandate.idconsipkind
LEFT OUTER JOIN consipkind_ext as CONSIP_EXT				ON CONSIP_EXT.idconsipkind = mandate.idconsipkind_ext
GO

 
