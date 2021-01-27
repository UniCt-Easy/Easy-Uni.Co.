
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


-- CREAZIONE VISTA mandatedetailavailable
IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailavailable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailavailable]
GO






--setuser 'amm'
--clear_table_info 'mandatedetailavailable'
-- select * from mandatedetailavailable
CREATE  VIEW [mandatedetailavailable]
(
	idmankind,
	yman,
	nman,
	idgroup,
	mankind,
	codeinv,
	inventorytree,
	registry,
	detaildescription,
	ordered,
	loaded,
	residual,
	assetkind,
	start,
	stop,
	linktoinvoice,
	linktoasset,
	multireg,
	flagactivity,
	idmandatestatus,
	mandatestatus,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	idreg,
	idinv,
	idlist,
	exchangerate,
	taxable,
	discount,
	taxrate,
	idlocation,
	locationcode,
	location
)
AS SELECT DISTINCT 
	mandatedetail.idmankind,
	mandatedetail.yman, 
	mandatedetail.nman, 
	mandatedetail.idgroup,
	mandatekind.description,
	inventorytree.codeinv, 
	inventorytree.description,
	registry.title, 	
	mandatedetail.detaildescription, 
	mandatedetail.number,	--ordered
	(SELECT ISNULL(SUM(number), 0)
		FROM assetacquire
		WHERE mandatedetail.idmankind = assetacquire.idmankind
		AND mandatedetail.yman = assetacquire.yman
		AND mandatedetail.nman = assetacquire.nman
		AND mandatedetail.idgroup = assetacquire.rownum), --loaded
	ISNULL(mandatedetail.number, 0) -
	(SELECT ISNULL(SUM(number), 0)
		FROM assetacquire
		WHERE mandatedetail.idmankind = assetacquire.idmankind
		AND mandatedetail.yman = assetacquire.yman
		AND mandatedetail.nman = assetacquire.nman
		AND mandatedetail.idgroup = assetacquire.rownum), --residual
	mandatedetail.assetkind,
	mandatedetail.start,
	mandatedetail.stop,
	mandatekind.linktoinvoice,
	mandatekind.linktoasset,
	mandatekind.multireg,
	mandatedetail.flagactivity,
	mandate.idmandatestatus,
	mandatestatus.description,
	mandate.idsor01,
	mandate.idsor02,
	mandate.idsor03,
	mandate.idsor04,
	mandate.idsor05,
	mandatedetail.idreg,
	mandatedetail.idinv,
	mandatedetail.idlist,
	mandate.exchangerate,
	--mandatedetail.taxable,	
	(SELECT  ISNULL(SUM(MD1.taxable),0)
	FROM mandatedetail MD1
	JOIN mandate M1			ON M1.yman = MD1.yman AND M1.nman = MD1.nman AND M1.idmankind = MD1.idmankind
	WHERE M1.idmankind = mandatedetail.idmankind
		AND M1.yman = mandatedetail.yman 
		AND M1.nman = mandatedetail.nman 
		AND MD1.idgroup = mandatedetail.idgroup)  	 
	,
	mandatedetail.discount,
	mandatedetail.taxrate,
	location.idlocation,
	location.locationcode,
	location.description

FROM mandatedetail (nolock)
JOIN mandatekind with (nolock)	ON mandatekind.idmankind = mandatedetail.idmankind
LEFT OUTER JOIN inventorytree  ON inventorytree.idinv = mandatedetail.idinv
INNER JOIN mandate	(nolock)	ON mandate.idmankind = mandatedetail.idmankind
									AND mandate.yman = mandatedetail.yman
									AND mandate.nman = mandatedetail.nman
left outer join registry  on registry.idreg = mandatedetail.idreg
--INNER JOIN registry WITH (NOLOCK) ON registry.idreg = mandate.idreg
LEFT OUTER JOIN mandatestatus (NOLOCK)		ON mandatestatus.idmandatestatus = mandate.idmandatestatus
LEFT OUTER JOIN location                        ON location.idlocation=mandatedetail.idlocation

WHERE mandatedetail.stop is null
       





GO

