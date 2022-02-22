
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


-- CREAZIONE VISTA assetloadview
--clear_table_info'assetloadview'

IF EXISTS(select * from sysobjects where id = object_id(N'[assetloadview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetloadview]
GO



CREATE   VIEW assetloadview
(
	idassetload, 
	idassetloadkind,
	codeassetloadkind,
	assetloadkind,
	yassetload,
	nassetload,
	idreg,
	registry,
	idmot,
	codemot,
	assetloadmotive,
	doc,
	docdate,
	description,
	enactment,
	enactmentdate,
	adate,
	printdate,
	ratificationdate,
	transmitted,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	cu,
	ct,
	lu,
	lt,
	totalassetacquire,
	assetamortizationamount,
	totalassetload
)
AS SELECT
	assetload.idassetload,
	assetload.idassetloadkind,
	assetloadkind.codeassetloadkind,
	assetloadkind.description,
	assetload.yassetload,
	assetload.nassetload,
	assetload.idreg,
	registry.title,
	assetload.idmot,
	assetloadmotive.codemot,
	assetloadmotive.description,
	assetload.doc,
	assetload.docdate,
	assetload.description,
	assetload.enactment,
	assetload.enactmentdate,
	assetload.adate,
	assetload.printdate,
	assetload.ratificationdate,
	assetload.transmitted,
	assetloadkind.idsor01,
	assetloadkind.idsor02,
	assetloadkind.idsor03,
	assetloadkind.idsor04,
	assetloadkind.idsor05,
	assetload.cu,
	assetload.ct,
	assetload.lu,
	assetload.lt,
	-- totalassetacquire
	(select sum(assetacquireview.total) FROM assetacquireview WHERE assetacquireview.idassetload= assetload.idassetload	),
	-- assetamortizationamount
	( select sum( CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) * ISNULL(assetamortization.amortizationquota, 0)) )
	from assetamortization
	where assetamortization.idassetload = assetload.idassetload),
	-- totalassetload
	isnull( (select sum(assetacquireview.total) FROM assetacquireview WHERE assetacquireview.idassetload= assetload.idassetload	),0)
	+
	isnull(( select sum( CONVERT(DECIMAL(19,2),ISNULL(assetamortization.assetvalue, 0) * ISNULL(assetamortization.amortizationquota, 0)) )
	from assetamortization
	where assetamortization.idassetload = assetload.idassetload),0)
FROM assetload
JOIN assetloadkind
	ON assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN registry
	ON registry.idreg = assetload.idreg
LEFT OUTER JOIN assetloadmotive
	ON assetloadmotive.idmot = assetload.idmot










GO
