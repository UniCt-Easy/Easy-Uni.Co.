
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


-- CREAZIONE VISTA mandateattachmentview
IF EXISTS(select * from sysobjects where id = object_id(N'[mandateattachmentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandateattachmentview]
GO

--setuser
--setuser 'amministrazione'
--setuser 'amm'

--DROP VIEW mandateattachmentview

CREATE VIEW mandateattachmentview
	(
		kpay,
		idexp,
		idmankind,
		yman,
		nman,
		idattachment
	)
	AS SELECT
		EL.kpay,
		E.idexp,
		M.idmankind,
		M.yman,
		M.nman,
		MA.idattachment

	FROM expense E
	join expenselast EL on E.idexp = EL.idexp
	join expenselink ELK on ELK.idchild = EL.idexp
	join expensemandate EM on EM.idexp = ELK.idparent
	join mandate M on M.idmankind = EM.idmankind AND M.yman = EM.yman AND M.nman = EM.nman
	join (select idmankind, yman, nman, idattachment from mandateattachment) MA on MA.idmankind = M.idmankind AND MA.yman = M.yman AND MA.nman = M.nman 

GO


