
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


-- CREAZIONE VISTA electronicinvoiceview
IF EXISTS(select * from sysobjects where id = object_id(N'[electronicinvoiceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [electronicinvoiceview]
GO

-- select * from  [electronicinvoiceview]
CREATE VIEW [electronicinvoiceview]
AS
SELECT  
	electronicinvoice.nelectronicinvoice,
	electronicinvoice.yelectronicinvoice,
	electronicinvoice.idtreasurer,
	treasurer.departmentname_fe,
	registry.idreg,
	registry.title as registry,
	electronicinvoice.idsor01,
	electronicinvoice.idsor02,
	electronicinvoice.idsor03,
	electronicinvoice.idsor04,
	electronicinvoice.idsor05,
	electronicinvoice.ipa_ven_emittente,
	electronicinvoice.rifamm_ven_emittente,
	electronicinvoice.ipa_ven_cliente,
	electronicinvoice.rifamm_ven_cliente,
	electronicinvoice.email_ven_cliente,
	electronicinvoice.pec_ven_cliente
FROM electronicinvoice 
LEFT OUTER JOIN registry 
	ON electronicinvoice.idreg = registry.idreg
LEFT OUTER JOIN treasurer
	ON electronicinvoice.idtreasurer = treasurer.idtreasurer



	

GO
