
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


-- CREAZIONE VISTA csa_roleview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_roleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_roleview]
GO

CREATE    VIEW [csa_roleview]
(
	ruoloCSA,
	idreg,
	registry,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivecredit,
	codemotivecredit,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	C.ruoloCSA,
	C.idreg,
	R.title,
	C.idaccmotivedebit,
	accmotivedebit.codemotive,
	C.idaccmotivecredit,
	accmotivecredit.codemotive,
	C.cu,
	C.ct,
	C.lu,
	C.lt
FROM csa_role C 
LEFT OUTER JOIN registry R 
	ON R.idreg=C.idreg
LEFT OUTER JOIN accmotive accmotivedebit
	ON C.idaccmotivedebit = accmotivedebit.idaccmotive
LEFT OUTER JOIN accmotive accmotivecredit
	ON C.idaccmotivecredit = accmotivecredit.idaccmotive

GO

