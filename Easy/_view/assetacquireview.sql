
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


-- CREAZIONE VISTA assetacquireview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetacquireview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetacquireview]
GO

 --clear_table_info'assetacquireview'
 --setuser 'amministrazione'
 --setuser 'amm'
 --select * from assetacquireview
CREATE VIEW [assetacquireview]
( 
	nassetacquire,
	idmankind,
	yman,
	nman,
	rownum,
  	idreg,
  	registry,
	idmot,
	assetloadmotive,
	idinv,
  	codeinv,
  	inventorytree,
	description,
	idinventory,
	codeinventory,
	inventory,
	idassetload,
	idassetloadkind,
	codeassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	ratificationdate,
 	number,
	taxable,
	abatable,
	tax,
	taxrate,
  	discount,
	cost,--taxabletotal,
	total,
	startnumber,
  	adate,
	flag,
	flagload,
	loadkind,
	ispieceacquire,
	transmitted,
	idupb,
	codeupb,
	upb,
	historicalvalue,
	idsor1,
	idsor2,
	idsor3,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
   	cu,
  	ct,
  	lu,
  	lt,
	idlist,
	intcode,
	list,
	yinv, ninv, idinvkind, invrownum, invoicekind,
	cost_discounted,
	inventorykind
  )
AS SELECT
	assetacquire.nassetacquire,
	assetacquire.idmankind,
	assetacquire.yman,
	assetacquire.nman,
	assetacquire.rownum,
  	assetacquire.idreg,
 	registry.title,
  	assetacquire.idmot,
  	assetloadmotive.description,
	assetacquire.idinv,
  	inventorytree.codeinv,
  	inventorytree.description,
	assetacquire.description,
	assetacquire.idinventory,
	inventory.codeinventory,
  	inventory.description,
	assetacquire.idassetload, 
	assetload.idassetloadkind,
	assetloadkind.codeassetloadkind,
  	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetload.ratificationdate,
  	assetacquire.number,
	assetacquire.taxable,
	assetacquire.abatable,
	assetacquire.tax,
	assetacquire.taxrate,
 	assetacquire.discount,
	/*CONVERT(decimal(19,2),ROUND(ISNULL(assetacquire.taxable,0)*
		(ISNULL(assetacquire.number,0))*
		(1+ISNULL(assetacquire.taxrate,0))*
		(1-ISNULL(assetacquire.discount,0)),2)),*/
		CASE	
			WHEN (inventorykind.flag & 1 <> 0)
			THEN	CONVERT(decimal(19,2),
						ROUND(ISNULL(assetacquire.taxable,0)	*(1- CONVERT(DECIMAL(19,6),ISNULL(assetacquire.discount,0.0))),2) *  (ISNULL(assetacquire.number,0))
						+ ROUND((ISNULL(assetacquire.tax,0.0)- ISNULL(assetacquire.abatable,0.0)),2))	
			ELSE  CONVERT(decimal(19,2),
						ROUND(ISNULL(assetacquire.taxable,0)	,2) *(ISNULL(assetacquire.number,0))
						+ ROUND((ISNULL(assetacquire.tax,0.0)- ISNULL(assetacquire.abatable,0.0)),2))	
			END
	,
	CASE	WHEN (inventorykind.flag & 1 <> 0)
		THEN	CONVERT(decimal(19,2),
				ROUND(		ISNULL(assetacquire.taxable,0)*(1- CONVERT(DECIMAL(19,6),ISNULL(assetacquire.discount,0.0))) 	,2)	*(ISNULL(assetacquire.number,0))
					+ ISNULL(assetacquire.tax,0.0))
		ELSE CONVERT(decimal(19,2),
				ROUND(		ISNULL(assetacquire.taxable,0)	,2)
					*(ISNULL(assetacquire.number,0))
					+ ISNULL(assetacquire.tax,0.0))
		END
	,

	



	assetacquire.startnumber,
  	assetacquire.adate,
	assetacquire.flag, 
	CASE
		WHEN assetacquire.flag & 1 <> 0 THEN 'S' 
		ELSE 'N'
	END,
	CASE
		WHEN assetacquire.flag & 2 <> 0 THEN 'R'
		ELSE 'N'
	END,
	CASE
		WHEN assetacquire.flag & 4 <> 0 THEN 'S'
		ELSE 'N'
	END,
	assetacquire.transmitted,
	assetacquire.idupb,
	upb.codeupb,
	upb.title,
	assetacquire.historicalvalue,
	assetacquire.idsor1,
	assetacquire.idsor2,
	assetacquire.idsor3,
	COALESCE(assetloadkind.idsor01, inventory.idsor01, upb.idsor01),
	COALESCE(assetloadkind.idsor02, inventory.idsor02, upb.idsor02),
	COALESCE(assetloadkind.idsor03, inventory.idsor03, upb.idsor03),
	COALESCE(assetloadkind.idsor04, inventory.idsor04, upb.idsor04),
	COALESCE(assetloadkind.idsor05, inventory.idsor05, upb.idsor05),
  	assetacquire.cu,
  	assetacquire.ct,
  	assetacquire.lu, 
  	assetacquire.lt,
	assetacquire.idlist,
	list.intcode,
	list.description,
	assetacquire.yinv, assetacquire.ninv, assetacquire.idinvkind, assetacquire.invrownum, invoicekind.description,
	CONVERT(decimal(19,2),
						ROUND(ISNULL(assetacquire.taxable,0)	*(1-ISNULL(assetacquire.discount,0)),2) *  (ISNULL(assetacquire.number,0))
						+ ROUND((ISNULL(assetacquire.tax,0.0)- ISNULL(assetacquire.abatable,0.0)),2)),
	inventorykind.description
FROM assetacquire			
LEFT OUTER JOIN inventory		(nolock)				ON inventory.idinventory = assetacquire.idinventory
left outer JOIN inventorykind	(nolock)	 		    ON inventory.idinventorykind= inventorykind.idinventorykind  
LEFT OUTER JOIN inventorytree	(nolock)				ON inventorytree.idinv = assetacquire.idinv
LEFT OUTER JOIN registry		(nolock)				ON registry.idreg = assetacquire.idreg 
LEFT OUTER JOIN assetloadmotive	(nolock)				ON assetloadmotive.idmot = assetacquire.idmot
LEFT OUTER JOIN assetload		(nolock)				ON assetload.idassetload = assetacquire.idassetload
LEFT OUTER JOIN assetloadkind	(nolock)				ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN upb				(nolock)				ON upb.idupb = assetacquire.idupb
LEFT OUTER JOIN list			(nolock)				ON list.idlist = assetacquire.idlist
LEFT OUTER JOIN invoicekind  (nolock)	ON invoicekind.idinvkind = assetacquire.idinvkind
GO
