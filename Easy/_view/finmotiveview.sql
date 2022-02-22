
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


-- CREAZIONE VISTA finmotiveview
IF EXISTS(select * from sysobjects where id = object_id(N'[finmotiveview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finmotiveview]
GO

 
CREATE   VIEW [finmotiveview]
(
	idfinmotive,
	active,
	codemotive,
	paridfinmotive,
	title,
	idfinmotive1,
	codemotive1,
	title1,
	idfinmotive2,
	codemotive2,
	title2,
	idfinmotive3,
	codemotive3,
	title3,
	idfinmotive4,
	codemotive4,
	title4,
	idfinmotive5,
	codemotive5,
	title5,
	idfinmotive6,
	codemotive6,
	title6,
	mergecode,
	cu,
	ct,
	lu,
	lt
)
AS
SELECT
	finmotive.idfinmotive,
	finmotive.active,
	finmotive.codemotive,
	finmotive.paridfinmotive,
	finmotive.title,
	finmotive1.idfinmotive,
	finmotive1.codemotive,
	finmotive1.title,
	finmotive2.idfinmotive,
	finmotive2.codemotive,
	finmotive2.title,
	finmotive3.idfinmotive,
	finmotive3.codemotive,
	finmotive3.title,
	finmotive4.idfinmotive,
	finmotive4.codemotive,
	finmotive4.title,
	finmotive5.idfinmotive,
	finmotive5.codemotive,
	finmotive5.title,
	finmotive6.idfinmotive,
	finmotive6.codemotive,
	finmotive6.title,
	ISNULL(finmotive6.codemotive,'') + ISNULL(finmotive5.codemotive,'') +
	ISNULL(finmotive4.codemotive,'') + ISNULL(finmotive3.codemotive,'') +
	ISNULL(finmotive2.codemotive,'') + ISNULL(finmotive1.codemotive,'') + 
	ISNULL(finmotive.codemotive,''),
	finmotive.cu,
	finmotive.ct,
	finmotive.lu,
	finmotive.lt
FROM finmotive
LEFT OUTER JOIN finmotive finmotive1
	ON finmotive1.idfinmotive = finmotive.paridfinmotive
LEFT OUTER JOIN finmotive finmotive2
	ON finmotive2.idfinmotive = finmotive1.paridfinmotive
LEFT OUTER JOIN finmotive finmotive3
	ON finmotive3.idfinmotive = finmotive2.paridfinmotive
LEFT OUTER JOIN finmotive finmotive4
	ON finmotive4.idfinmotive = finmotive3.paridfinmotive
LEFT OUTER JOIN finmotive finmotive5
	ON finmotive5.idfinmotive = finmotive4.paridfinmotive
LEFT OUTER JOIN finmotive finmotive6
	ON finmotive6.idfinmotive = finmotive5.paridfinmotive

GO
