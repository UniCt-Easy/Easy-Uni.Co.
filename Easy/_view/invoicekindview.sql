
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


-- CREAZIONE VISTA invoicekindview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicekindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicekindview]
GO 
 
CREATE VIEW invoicekindview
(
	description,
	codeinvkind,
	idinvkind,
	flag,
	flag_registrounico,
	flag_autodocnumbering,
	formatstring,
	active,
	idinvkind_auto,
	printingcode,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	address,
	header,
	notes1,
	notes2,
	notes3,
	ipa_fe,
	riferimento_amministrazione,
	enable_fe,
	enable_fe_estera
)
AS SELECT 	
	description,
	codeinvkind,
	idinvkind,
	flag,
	CASE
		when ((flag & 64) = 0) then 'N' else 'S' --flag protocolla nel registro unico
	END,
	flag_autodocnumbering,
	formatstring,
	active,
	idinvkind_auto,
	printingcode,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	address,
	header,
	notes1,
	notes2,
	notes3,
	ipa_fe,
	riferimento_amministrazione,
	enable_fe,
	enable_fe_estera
FROM invoicekind

GO
 
