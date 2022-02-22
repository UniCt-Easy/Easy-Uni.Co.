
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


-- CREAZIONE VISTA accountminusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountminusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accountminusable]
GO

CREATE VIEW [dbo].[accountminusable]
(
	idacc,
	ayear,
	codeacc,
	paridacc,
	nlevel,
	printingorder,
	title,
	idaccountkind,
	accountkind,
	flagda,
	flagregistry,
	flagupb,
	flagtransitory,
	flagenablebudgetprev,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	account.idacc,
	account.ayear,
	account.codeacc,
	account.paridacc,
	account.nlevel,
	account.printingorder,
	account.title,
	account.idaccountkind,
	accountkind.description,
	accountkind.flagda,
	account.flagregistry,
	account.flagupb,
	account.flagtransitory,
	account.flagenablebudgetprev,
	account.cu,
	account.ct,
	account.lu,
	account.lt
	FROM account (NOLOCK)
	JOIN accountlevel (NOLOCK) 
		ON accountlevel.ayear = account.ayear
		AND accountlevel.nlevel = account.nlevel
	left outer JOIN accountkind (NOLOCK) 
		on  accountkind.idaccountkind=account.idaccountkind
	WHERE account.nlevel = (SELECT min(nlevel) from accountlevel where ayear = account.ayear and (flagusable='S'))








GO


