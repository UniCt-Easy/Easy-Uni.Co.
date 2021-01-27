
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


-- CREAZIONE VISTA taxview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxview]
GO



CREATE   VIEW taxview 
(
	taxcode,
	taxref,
	active,
	appliancebasis,
	description,
	fiscaltaxcode,
	fiscaltaxcodecredit,
	flagunabatable,
	geoappliance,
	idaccmotive_cost,
	idaccmotive_debit,
	idaccmotive_pay,
	taxablecode,
	taxkind,
	maintaxcode,
	maintaxref,
	maintaxdescription,
	insuranceagencycode,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	tax.taxcode,
	tax.taxref,
	tax.active,
	tax.appliancebasis,
	tax.description,
	tax.fiscaltaxcode,
	tax.fiscaltaxcodecredit,
	tax.flagunabatable,
	tax.geoappliance,
	tax.idaccmotive_cost,
	tax.idaccmotive_debit,
	tax.idaccmotive_pay,
	tax.taxablecode,
	tax.taxkind,
	tax.maintaxcode,
	ISNULL(maintax.taxref,tax.taxref),
	ISNULL(maintax.description,tax.description),
	tax.insuranceagencycode,
	tax.ct,
	tax.cu,
	tax.lt,
	tax.lu
FROM tax
LEFT OUTER JOIN tax maintax
ON tax.maintaxcode = maintax.taxcode

GO 
