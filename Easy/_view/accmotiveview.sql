
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


-- CREAZIONE VISTA accmotiveview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotiveview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accmotiveview]
GO


CREATE   VIEW [dbo].[accmotiveview]
(
	idaccmotive,
	active,
	codemotive,
	paridaccmotive,
	title,
	flagdep,
	flagamm,
	idaccmotive1,
	codemotive1,
	title1,
	idaccmotive2,
	codemotive2,
	title2,
	idaccmotive3,
	codemotive3,
	title3,
	idaccmotive4,
	codemotive4,
	title4,
	idaccmotive5,
	codemotive5,
	title5,
	idaccmotive6,
	codemotive6,
	title6,
	mergecode,
	expensekind,
	cu,
	ct,
	lu,
	lt,
	flag
)
AS
SELECT
	accmotive.idaccmotive,
	accmotive.active,
	accmotive.codemotive,
	accmotive.paridaccmotive,
	accmotive.title,
	accmotive.flagdep,
	accmotive.flagamm,
	accmotive1.idaccmotive,
	accmotive1.codemotive,
	accmotive1.title,
	accmotive2.idaccmotive,
	accmotive2.codemotive,
	accmotive2.title,
	accmotive3.idaccmotive,
	accmotive3.codemotive,
	accmotive3.title,
	accmotive4.idaccmotive,
	accmotive4.codemotive,
	accmotive4.title,
	accmotive5.idaccmotive,
	accmotive5.codemotive,
	accmotive5.title,
	accmotive6.idaccmotive,
	accmotive6.codemotive,
	accmotive6.title,
	ISNULL(accmotive6.codemotive,'') + ISNULL(accmotive5.codemotive,'') +
	ISNULL(accmotive4.codemotive,'') + ISNULL(accmotive3.codemotive,'') +
	ISNULL(accmotive2.codemotive,'') + ISNULL(accmotive1.codemotive,'') + 
	ISNULL(accmotive.codemotive,''),
	accmotive.expensekind,
	accmotive.cu,
	accmotive.ct,
	accmotive.lu,
	accmotive.lt,
	accmotive.flag
FROM accmotive
LEFT OUTER JOIN accmotive accmotive1
	ON accmotive1.idaccmotive = accmotive.paridaccmotive
LEFT OUTER JOIN accmotive accmotive2
	ON accmotive2.idaccmotive = accmotive1.paridaccmotive
LEFT OUTER JOIN accmotive accmotive3
	ON accmotive3.idaccmotive = accmotive2.paridaccmotive
LEFT OUTER JOIN accmotive accmotive4
	ON accmotive4.idaccmotive = accmotive3.paridaccmotive
LEFT OUTER JOIN accmotive accmotive5
	ON accmotive5.idaccmotive = accmotive4.paridaccmotive
LEFT OUTER JOIN accmotive accmotive6
	ON accmotive6.idaccmotive = accmotive5.paridaccmotive

GO
