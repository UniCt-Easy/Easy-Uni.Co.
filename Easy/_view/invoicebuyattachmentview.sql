
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


-- CREAZIONE VISTA invoicebuyattachmentview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicebuyattachmentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicebuyattachmentview]
GO

--setuser
--setuser 'amministrazione'
--setuser 'amm'

--DROP VIEW invoicebuyattachmentview
--select * from invoicebuyattachmentview
--select top 1 * from mandateattachment

CREATE VIEW invoicebuyattachmentview
	(
		kpay,
		idexp,
		idinvkind,
		yinv,
		ninv,
		idattachment
	)
	AS SELECT
		EL.kpay,
		E.idexp,
		I.idinvkind,
		I.yinv,
		I.ninv,
		IA.idattachment

	FROM expense E
	join expenselast EL on E.idexp = EL.idexp
	join expenseinvoice EI on EI.idexp = EL.idexp
	join invoice I on I.idinvkind = EI.idinvkind AND I.yinv = EI.yinv AND I.ninv = EI.ninv
	join (select idinvkind, yinv, ninv, idattachment from invoiceattachment) IA on IA.idinvkind = EI.idinvkind AND IA.yinv = EI.yinv AND IA.ninv = EI.ninv 


GO


