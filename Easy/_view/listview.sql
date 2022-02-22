
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


-- CREAZIONE VISTA listview
IF EXISTS(select * from sysobjects where id = object_id(N'[listview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [listview]
GO




 --setuser 'amm'
 --select * from [listview]
 
CREATE VIEW [listview](
	idlist,
	description,
	intcode,
	intbarcode,
	extcode,
	extbarcode,
	validitystop,
	active,
	idpackage,
	package,
	idunit,
	unit,
	unitsforpackage,
	has_expiry,
	idlistclass,
	codelistclass,
	listclass,
	pic,
	timesupply,
	nmaxorder,
	authrequired,
	assetkind,
	assetkinddescr,
	flagvisiblekind,
	idinv,
	codeinv,
	inventorytree,
	codemotive,
	accmotive,
	price,
	insinfo,
	descrforuser,
	ntoreorder,
	idtassonomia, 
	tassonomia,
	codicetassonomia
)
AS 
SELECT 
	list.idlist,
	list.description,
	list.intcode,
	list.intbarcode,
	list.extcode,
	list.extbarcode,
	list.validitystop,
	list.active,
	list.idpackage,
	package.description,
	list.idunit,
	unit.description,
	list.unitsforpackage,
	list.has_expiry,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	list.pic,
	list.timesupply,
	list.nmaxorder,
	listclass.authrequired,
	listclass.assetkind,
	CASE listclass.assetkind
		WHEN 'A' THEN 'Inventariabile'
		WHEN 'P' THEN 'Aumento di Valore'
		WHEN 'S'  THEN 'Servizi'
		WHEN 'M' THEN 'Magazzino'
		WHEN 'O' THEN 'Altro'
	END,
	listclass.flagvisiblekind,
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.description,
	accmotive.codemotive,
	accmotive.title,
	list.price,
	list.insinfo,
	list.descrforuser,
	list.ntoreorder,
	list.idtassonomia,
	tassonomia_pagopa.title,
	tassonomia_pagopa.causale         
FROM list
JOIN listclass				ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN unit		ON list.idunit = unit.idunit
LEFT OUTER JOIN package		ON list.idpackage = package.idpackage
LEFT OUTER JOIN accmotive   ON accmotive.idaccmotive = listclass.idaccmotive
LEFT OUTER JOIN inventorytree		ON listclass.idinv = inventorytree.idinv
LEFT OUTER JOIN tassonomia_pagopa		ON tassonomia_pagopa.idtassonomia = list.idtassonomia
 



GO

