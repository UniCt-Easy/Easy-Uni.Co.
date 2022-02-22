
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


-- CREAZIONE VISTA mandatedetail_extview
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetail_extview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetail_extview]
GO

--setuser 'amministrazione'
--clear_table_info'mandatedetail_extview'
/*
	select * from mandatedetail_extview where yman = 2021
 */

CREATE VIEW [mandatedetail_extview]
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mankind,
	idinv,
	codeinv,
	inventorytree,
  	idreg,
  	registry,
	detaildescription,
	annotations,
	number,
	taxable,
	taxrate,
	tax,
  	discount,
	assetkind,
	start,
	stop,
	idexp_taxable,
	idexp_iva,	
	taxable_euro,
	iva_euro,
	rowtotal,
	idupb,
	codeupb,
	upb,
	idupb_iva,
	codeupb_iva,
	upb_iva,
	cu,
	ct,
	lu,
	lt,
	idaccmotive,
	codemotive,
	idaccmotiveannulment,
	codemotiveannulment,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	idcostpartition,
	costpartitioncode,
	competencystart,
	competencystop,
	idivakind,
	ivakind,
	unabatable,
	flagmixed,
	toinvoice,
	exchangerate,
	description,
	linkedtoasset,
	notlinkedtoasset,
	linkedtoinvoice,
	notlinkedtoinvoice,
	cashed,
	tocash,
	flagactivity,
	ivanotes,
	idlist,
	intcode,
	idunit,		
	idpackage,	
	unitsforpackage,	
	npackage,
	idstore,
	store,
	flagto_unload,
	cupcode,
	cigcode,
	idsor01,idsor02,idsor03,idsor04,idsor05	,
	epkind,
	idepexp,
	yepexp,
	nepexp,
	yexpimpo,
	nexpimpo,
	yexpiva,
	nexpiva,
	idlocation,
	locationcode,
	location,
	idsor_siope,
	idman,
	list
)
	AS SELECT
	mandatedetail.idmankind,
	mandatedetail.yman,
	mandatedetail.nman,
	mandatedetail.rownum,
	mandatedetail.idgroup,
	mandatekind.description,
	mandatedetail.idinv,
	inventorytree.codeinv,
	inventorytree.description,
 	mandatedetail.idreg,
  	registry.title,
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	mandatedetail.taxable,
	mandatedetail.taxrate,
	mandatedetail.tax,
  	mandatedetail.discount,
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatedetail.idexp_taxable,
	mandatedetail.idexp_iva,
 	    ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number)* 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		),
	ROUND(mandatedetail.tax,2),
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number)* 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)+
	ROUND(mandatedetail.tax,2),
	mandatedetail.idupb,
	upb.codeupb,
	upb.title,
	mandatedetail.idupb_iva,
	upbiva.codeupb,
	upbiva.title,
	mandatedetail.cu,
	mandatedetail.ct,
	mandatedetail.lu,
	mandatedetail.lt,
	mandatedetail.idaccmotive,
	accmotive.codemotive,
	mandatedetail.idaccmotiveannulment,
	accmotiveannulment.codemotive,
	mandatedetail.idsor1,
	mandatedetail.idsor2,
	mandatedetail.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	costpartition.idcostpartition,
	costpartition.costpartitioncode,
	mandatedetail.competencystart,
	mandatedetail.competencystop,
	mandatedetail.idivakind,
	ivakind.description,
	mandatedetail.unabatable,
	mandatedetail.flagmixed,
	mandatedetail.toinvoice,
	mandate.exchangerate,
	mandate.description,
	-- linkedtoasset
	ISNULL(
		(SELECT SUM(number) FROM assetacquire AC
		WHERE AC.idmankind = mandatedetail.idmankind
			AND AC.yman = mandatedetail.yman
			AND AC.nman = mandatedetail.nman
			AND AC.rownum = mandatedetail.idgroup)
	,0),
	-- notlinkedtoasset
	ISNULL(mandatedetail.npackage,mandatedetail.number) -
	ISNULL(
		(SELECT SUM(number) FROM assetacquire AC
		WHERE AC.idmankind = mandatedetail.idmankind
			AND AC.yman = mandatedetail.yman
			AND AC.nman = mandatedetail.nman
			AND AC.rownum = mandatedetail.idgroup)
	,0),
	-- linkedtoinvoice
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT ISNULL(npackage,number) as number,idinvkind,yinv,ninv,idgroup
		FROM invoicedetail
		WHERE invoicedetail.idmankind = mandatedetail.idmankind AND
		     invoicedetail.yman = mandatedetail.yman AND
	         invoicedetail.nman = mandatedetail.nman AND
		     invoicedetail.manrownum = mandatedetail.rownum 	
		) 
		AS iv
	)
	,0),
	-- notlinkedtoinvoice
	ISNULL(mandatedetail.npackage,mandatedetail.number) -
	ISNULL(
		(SELECT  SUM (iv.number)
	FROM (SELECT DISTINCT ISNULL(npackage,number) as number,idinvkind,yinv,ninv,idgroup
		FROM invoicedetail
			WHERE invoicedetail.idmankind = mandatedetail.idmankind AND
		     invoicedetail.yman = mandatedetail.yman AND
	         invoicedetail.nman = mandatedetail.nman AND
		     invoicedetail.manrownum = mandatedetail.rownum 	
		) 
		AS iv
	)
	,0),
	--cashed,
	case 
		when ((select count(*) from expensephase) = 1) and (isnull(mandatekind.linktoinvoice,'N')='N') and (mandatedetail.idexp_taxable IS NOT NULL )
		then   ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
		else
		isnull((select sum(amount) from expenselastmandatedetail eld where 
			eld.idmankind=	mandatedetail.idmankind and
			eld.yman	=	mandatedetail.yman and
			eld.nman	=	mandatedetail.nman and
			eld.rownum	=	mandatedetail.rownum ),0)
	end	,
	--tocash,
	case when ((select count(*) from expensephase) = 1) and (isnull(mandatekind.linktoinvoice,'N')='N') and (mandatedetail.idexp_taxable IS NULL )
	then  ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
	ELSE
		ROUND(mandatedetail.taxable * mandatedetail.number * 
		  CONVERT(DECIMAL(19,6),mandate.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(mandatedetail.discount, 0.0))),2
		)-isnull((select sum(amount) from expenselastmandatedetail eld where 
			eld.idmankind=	mandatedetail.idmankind and
			eld.yman	=	mandatedetail.yman and
			eld.nman	=	mandatedetail.nman and
			eld.rownum	=	mandatedetail.rownum ),0)
		END	,
	mandatedetail.flagactivity,
	mandatedetail.ivanotes,
	mandatedetail.idlist,
	list.intcode,
	mandatedetail.idunit,		
	mandatedetail.idpackage,	
	mandatedetail.unitsforpackage,	
	mandatedetail.npackage,
	mandate.idstore,
	store.description,	
	mandatedetail.flagto_unload,
	mandatedetail.cupcode,
	isnull(mandatedetail.cigcode, mandate.cigcode),
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandatedetail.epkind,
	mandatedetail.idepexp,
	epexp.yepexp,
	epexp.nepexp,
	eimpo.ymov,
	eimpo.nmov,
	eiva.ymov,
	eiva.nmov,
	location.idlocation,
	location.locationcode,
	location.description,
	mandatedetail.idsor_siope,
	mandate.idman,
	list.description
FROM mandatedetail with (nolock)
JOIN mandatekind  with (nolock)		ON mandatekind.idmankind = mandatedetail.idmankind
JOIN ivakind with (nolock)			ON ivakind.idivakind = mandatedetail.idivakind
LEFT JOIN inventorytree with (nolock)	ON inventorytree.idinv = mandatedetail.idinv
JOIN mandate with (nolock)				ON mandate.yman = mandatedetail.yman
									AND mandate.nman = mandatedetail.nman
									AND mandate.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN registry with (nolock)		ON registry.idreg = mandatedetail.idreg
LEFT OUTER JOIN upb with (nolock)			ON upb.idupb = mandatedetail.idupb
LEFT OUTER JOIN upb as upbiva with (nolock)			ON upbiva.idupb = mandatedetail.idupb_iva
LEFT OUTER JOIN accmotive with (nolock)		ON accmotive.idaccmotive = mandatedetail.idaccmotive
LEFT OUTER JOIN accmotive accmotiveannulment with (nolock)
											ON accmotiveannulment.idaccmotive = mandatedetail.idaccmotiveannulment
LEFT OUTER JOIN sorting sorting1 with (nolock)		ON sorting1.idsor = mandatedetail.idsor1
LEFT OUTER JOIN sorting sorting2 with (nolock)		ON sorting2.idsor = mandatedetail.idsor2
LEFT OUTER JOIN sorting sorting3 with (nolock)		ON sorting3.idsor = mandatedetail.idsor3
LEFT OUTER JOIN list  with (nolock)					ON list.idlist = mandatedetail.idlist
LEFT OUTER JOIN store with (nolock)					ON store.idstore = mandate.idstore
LEFT OUTER JOIN costpartition  with (nolock)		ON costpartition.idcostpartition = mandatedetail.idcostpartition
LEFT OUTER JOIN  epexp with (nolock)				ON mandatedetail.idepexp= epexp.idepexp	
LEFT OUTER JOIN  expense eimpo					ON mandatedetail.idexp_taxable = eimpo.idexp
LEFT OUTER JOIN  expense eiva					ON mandatedetail.idexp_iva = eiva.idexp
LEFT OUTER JOIN location                        ON  location.idlocation=mandatedetail.idlocation

GO

