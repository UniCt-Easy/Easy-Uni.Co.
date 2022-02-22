
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


-- CREAZIONE VISTA estimateresidual
IF EXISTS(select * from sysobjects where id = object_id(N'[estimateresidual]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [estimateresidual]
GO




--setuser 'amm'
--clear_table_info 'estimateresidual'
--select * from estimateresidual 

--clear_table_info'estimateresidual'
CREATE     VIEW [estimateresidual]
	(
	idestimkind,	
	yestim,
	nestim,
	estimkind,
	description,
	idreg,
	idupb,
	idupb_iva,
	registry,
	taxabletotal,
	ivatotal,
	residual,
	linkedimpon,
	linkedimpos,
	linkedestim,
	active,
	upb,
	upb_iva,
	flagintracom,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cigcode,
	linktoinvoice

	)
	AS SELECT
	estimatedetail.idestimkind,
	estimatedetail.yestim,
	estimatedetail.nestim,
	estimatekind.description,
	estimate.description,
	estimatedetail.idreg,
	estimatedetail.idupb,
	estimatedetail.idupb_iva,
	registry.title,
	--taxabletotal,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
	   	     ROUND(estimatedetail.taxable * estimatedetail.number * 
	     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
	     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
	   ),0)
	),
	--ivatotal,
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
	   	     ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
	   ),0)
	),
	--residuo :somma dei dett. ordine non contabilizzati
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE --taxable null iva not null -> residuo = taxable
			WHEN (estimatedetail.idinc_taxable IS  NULL) AND (estimatedetail.idinc_iva IS  NOT NULL or (registry.flag_pa='S'))
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)

			WHEN ( estimatedetail.idinc_iva IS NULL AND (isnull(registry.flag_pa,'N')='N' )) AND (estimatedetail.idinc_taxable IS  NOT NULL)
			THEN
			      ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)

			WHEN ( estimatedetail.idinc_iva IS  NULL AND (isnull(registry.flag_pa,'N')='N')) AND (estimatedetail.idinc_taxable IS  NULL)
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
			     +
			     ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
			ELSE   0

		    END
		   ),0)
		),


		--linkedimpon,
-- (mov.movkind = '3' )
-- (mandatedetail.idexp_taxable IS NOT NULL 		AND (mandatedetail.idexp_iva IS NULL OR mandatedetail.idexp_taxable<>mandatedetail.idexp_iva)) 
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_taxable IS NOT NULL 
				AND (estimatedetail.idinc_iva IS NULL OR 
					(isnull(estimatedetail.idinc_taxable,0)<>isnull(estimatedetail.idinc_iva,0) AND (isnull(registry.flag_pa,'N')='N' )))) 
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
			ELSE   0
		    END
			
		   ),0)
		),

	--linkedimpos,
-- (mov.movkind = '2')
-- (mandatedetail.idexp_iva IS NOT NULL  AND  (mandatedetail.idexp_taxable IS NULL OR mandatedetail.idexp_taxable<>mandatedetail.idexp_iva)) 
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN ( (estimatedetail.idinc_iva IS NOT NULL OR (registry.flag_pa='S' ))
			      AND (estimatedetail.idinc_taxable IS NULL OR  (registry.flag_pa='S' ) OR
						(isnull(estimatedetail.idinc_taxable,0)<>isnull(estimatedetail.idinc_iva,0) AND (isnull(registry.flag_pa,'N')='N' )))) 
			THEN
			       ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
			ELSE   0
		    END
			
		   ),0)
		),

--	linkedestim,
--  (mov.movkind = '1' )
--- (mandatedetail.idexp_taxable IS NOT NULL AND mandatedetail.idexp_iva= mandatedetail.idexp_taxable)
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN (estimatedetail.idinc_taxable IS NOT NULL 
					AND estimatedetail.idinc_iva= estimatedetail.idinc_taxable
					AND   (isnull(registry.flag_pa,'N')='N' )
					)
			THEN
			     ROUND(estimatedetail.taxable * estimatedetail.number * 
		     	     CONVERT(decimal(19,6),estimate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
			     +
			     ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
			ELSE   0
		    END
			
		   ),0)
		),
	estimate.active,
	upb.title,
	upb_iva.title,
	estimate.flagintracom,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	isnull(estimatedetail.cigcode,estimate.cigcode),
	estimatekind.linktoinvoice
FROM estimatedetail (NOLOCK)
JOIN estimate (NOLOCK)			  	ON estimatedetail.idestimkind = estimate.idestimkind
										AND estimatedetail.yestim = estimate.yestim
  										AND estimatedetail.nestim = estimate.nestim
JOIN estimatekind					ON estimatekind.idestimkind = estimate.idestimkind
LEFT OUTER JOIN registry			ON registry.idreg = estimatedetail.idreg
LEFT OUTER JOIN upb					ON upb.idupb=estimatedetail.idupb
LEFT OUTER JOIN upb as upb_iva		ON upb_iva.idupb=estimatedetail.idupb_iva
WHERE estimatedetail.STOP is null
GROUP BY estimatedetail.idestimkind, estimatedetail.yestim, estimatedetail.nestim,
	estimate.idreg,estimatedetail.idreg,estimatedetail.idupb,estimatedetail.idupb_iva,
	estimatekind.description,estimate.description,
	estimate.active,upb.title, upb_iva.title, estimate.flagintracom,
	estimate.idsor01,
	estimate.idsor02,
	estimate.idsor03,
	estimate.idsor04,
	estimate.idsor05,
	 isnull(estimate.idreg,estimatedetail.idreg),
	 isnull(estimatedetail.cigcode,estimate.cigcode),
	 registry.title,
	 estimatekind.linktoinvoice





GO
--select  * from estimateresidual
