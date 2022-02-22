
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


-- CREAZIONE VISTA [finmotiveusable]
IF EXISTS(select * from sysobjects where id = object_id(N'[finmotiveusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finmotiveusable]
GO


CREATE  VIEW [finmotiveusable]
(
	idfinmotive,
	paridaccmotive,
	codemotive,
	title,
	active,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	finmotive.idfinmotive,
	finmotive.paridfinmotive,
	finmotive.codemotive,
	finmotive.title,
	finmotive.active,
	finmotive.cu,
	finmotive.ct,
	finmotive.lu,
	finmotive.lt
	FROM finmotive (NOLOCK)
	WHERE (SELECT count(*) FROM finmotive b1
	WHERE b1.paridfinmotive = finmotive.idfinmotive )=0




GO
  
