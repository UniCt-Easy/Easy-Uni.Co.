
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


-- CREAZIONE VISTA estimatedetailtoinvoice
IF EXISTS(select * from sysobjects where id = object_id(N'[estimatedetailtoinvoice]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimatedetailtoinvoice]
GO


--setuser 'amm'
--clear_table_info 'estimatedetailtoinvoice'
--select * from estimatedetailtoinvoice
CREATE  VIEW [estimatedetailtoinvoice]
(
	idestimkind,
	yestim,
	nestim,
	rownum,
	idgroup,
	estimatekind,
	idreg,
	registry,
	idcurrency,
	codecurrency, 
	detaildescription,
	ordered,
	invoiced,
	residual,
	taxrate,
	taxable,
	tax,
	discount,
	start,
	stop,
	competencystart,
	competencystop,
	idupb,
	idupb_iva,
	idsor1,
	idsor2,
	idsor3,
	idaccmotive,
	idivakind,
	ivakind,
	toinvoice,
	linktoinvoice,
	multireg,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	epkind,exchangerate,
	idepacc,
	idlist,
	cigcode,
	idfinmotive, 
	idfinmotive_iva,
	iduniqueformcode,
	nform,
	idsor_siope,
	idtassonomia,
	cupcode
)
AS SELECT 
	estimatedetail.idestimkind,
	estimatedetail.yestim, 
	estimatedetail.nestim, 
	estimatedetail.rownum, 
	estimatedetail.idgroup,
	estimatekind.description,
	estimatedetail.idreg,	
	registry.title, 	
	estimate.idcurrency,
	currency.codecurrency,
	estimatedetail.detaildescription, 
	estimatedetail.number,		-- ordered
	/*(SELECT ISNULL(SUM(number), 0)
		FROM invoicedetail
		WHERE estimatedetail.idestimkind = invoicedetail.idestimkind
		AND estimatedetail.yestim = invoicedetail.yestim
		AND estimatedetail.nestim = invoicedetail.nestim
		AND estimatedetail.rownum = invoicedetail.estimrownum), 	*/
	ISNULL(
	(SELECT SUM(iv.number)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  --invoicedetail.idgroup as invidgroup,
				      invoicedetail.number,invoicedetail.idestimkind,invoicedetail.yestim,
				      invoicedetail.nestim, estimatedetail2.idgroup as estimidgroup
		FROM invoicedetail 
        JOIN estimatedetail estimatedetail2
		  ON invoicedetail.idestimkind = estimatedetail2.idestimkind AND
		     invoicedetail.yestim = estimatedetail2.yestim AND
	         invoicedetail.nestim = estimatedetail2.nestim AND
		     invoicedetail.estimrownum = estimatedetail2.rownum 
		    WHERE  invoicedetail.idestimkind = estimatedetail.idestimkind AND
	               invoicedetail.yestim = estimatedetail.yestim AND
		           invoicedetail.nestim = estimatedetail.nestim AND
			       estimatedetail2.idgroup = estimatedetail.idgroup 
			) AS iv )  ,0),		-- invoiced
	
	ISNULL(estimatedetail.number, 0) 
	- 
	ISNULL(
	(SELECT SUM(iv.number)
	  FROM (SELECT DISTINCT 
					  invoicedetail.idinvkind, invoicedetail.yinv, invoicedetail.ninv,
					  --invoicedetail.idgroup as invidgroup,
				      invoicedetail.number,invoicedetail.idestimkind,invoicedetail.yestim,
				      invoicedetail.nestim, estimatedetail2.idgroup as estimidgroup
		FROM invoicedetail 
        JOIN estimatedetail estimatedetail2
		  ON invoicedetail.idestimkind = estimatedetail2.idestimkind AND
		     invoicedetail.yestim = estimatedetail2.yestim AND
	         invoicedetail.nestim = estimatedetail2.nestim AND
		     invoicedetail.estimrownum = estimatedetail2.rownum 
		    WHERE  invoicedetail.idestimkind = estimatedetail.idestimkind AND
	               invoicedetail.yestim = estimatedetail.yestim AND
		           invoicedetail.nestim = estimatedetail.nestim AND
			       estimatedetail2.idgroup = estimatedetail.idgroup 
			) AS iv )  ,0)
	/*(SELECT  SUM (iv.number)
   	   FROM (SELECT DISTINCT number,idestimkind,yestim,nestim,estimrownum,idgroup
		FROM invoicedetail) 
		AS iv
	  WHERE estimatedetail.idestimkind = iv.idestimkind
		AND estimatedetail.yestim = iv.yestim
		AND estimatedetail.nestim = iv.nestim
		AND estimatedetail.rownum = iv.estimrownum 
	)*/, 	-- residual
	estimatedetail.taxrate,
	estimatedetail.taxable,
	estimatedetail.tax,
	estimatedetail.discount,
	estimatedetail.start,
	estimatedetail.stop,
	estimatedetail.competencystart,
	estimatedetail.competencystop,
	estimatedetail.idupb,
	estimatedetail.idupb_iva,
	estimatedetail.idsor1,
	estimatedetail.idsor2,
	estimatedetail.idsor3,
	estimatedetail.idaccmotive,
	estimatedetail.idivakind,
	ivakind.description,
	estimatedetail.toinvoice,
	estimatekind.linktoinvoice,
	estimatekind.multireg,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	estimatedetail.epkind,
	estimate.exchangerate,
	estimatedetail.idepacc,
	estimatedetail.idlist,
	isnull(estimatedetail.cigcode,estimate.cigcode),
	estimatedetail.idfinmotive, 
	estimatedetail.idfinmotive_iva,
	estimatedetail.iduniqueformcode,
	estimatedetail.nform,
	estimatedetail.idsor_siope,
	estimatedetail.idtassonomia,
	estimatedetail.cupcode
	FROM estimatedetail WITH (NOLOCK)
	JOIN estimatekind WITH (NOLOCK)					ON estimatekind.idestimkind = estimatedetail.idestimkind
	INNER JOIN estimate WITH (NOLOCK)				ON estimate.idestimkind = estimatedetail.idestimkind
												AND estimate.yestim = estimatedetail.yestim
												AND estimate.nestim = estimatedetail.nestim
	left outer JOIN registry WITH (NOLOCK) ON registry.idreg = estimatedetail.idreg
	LEFT OUTER JOIN ivakind WITH (NOLOCK)			ON ivakind.idivakind = estimatedetail.idivakind
	LEFT OUTER JOIN currency WITH (NOLOCK)			ON currency.idcurrency = estimate.idcurrency
	WHERE estimatedetail.stop is null


GO

 
