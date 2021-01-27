
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


-- CREAZIONE VISTA csa_contractkindrulesview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_contractkindrulesview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_contractkindrulesview]
GO



--setuser 'amministrazione'

--select * from csa_contractkindrulesview


CREATE    VIEW [csa_contractkindrulesview]
(
	idcsa_contractkind,
	idcsa_rule,
	capitolocsa,
	ruolocsa,
	ayear,
	description,
	contractkindcode,
	flagcr,
	flagkeepalive,
	active,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.idcsa_contractkind,
	R.idcsa_rule,
	R.capitolocsa,
	R.ruolocsa,
	R.ayear,
	C.description,
	C.contractkindcode,
	C.flagcr,
	C.flagkeepalive,
	C.active,
	R.cu,
	R.ct,
	R.lu,
	R.lt
FROM csa_contractkindrules R
JOIN csa_contractkind C				ON C.idcsa_contractkind = R.idcsa_contractkind
JOIN csa_contractkindyear CY		ON C.idcsa_contractkind = CY.idcsa_contractkind AND R.ayear=CY.ayear


GO
