
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


--clear_table_info'stip_gompview'

-- CREAZIONE VISTA stip_gompview
IF EXISTS(select * from sysobjects where id = object_id(N'[stip_gompview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stip_gompview]
GO


--setuser'amm'
--select * from stip_gompview

CREATE VIEW [stip_gompview]
(
	idstip_gomp,
	codicecausale,
	annoregolamento,
	fuoricorso,

	idaccmotiverevenue,
	codemotiverevenue,
	accmotiverevenue,
	idaccmotivecredit,
	codemotivecredit,
	accmotivecredit,
	idfinmotive,
	codefinmotive,
	finmotive,
	idaccmotiveundotax,
	codemotiveundotax,
	accmotiveundotax,
	idaccmotiveundotaxpost,
	codemotiveundotaxpost,
	accmotiveundotaxpost,
	tipologiacorso,
	descrizione,
	idestimkind,
	estimatekind,
	ct,
	cu,
	lt,
	lu
)
AS  SELECT
	stip_gomp.idstip_gomp,
	stip_gomp.codicecausale,
	stip_gomp.annoregolamento,
	stip_gomp.fuoricorso,

	stip_gomp.idaccmotiverevenue,
	accmotiverevenue.codemotive,
	accmotiverevenue.title,
	stip_gomp.idaccmotivecredit,
	accmotivecredit.codemotive,
	accmotivecredit.title,
	stip_gomp.idfinmotive,
	finmotive.codemotive,
	finmotive.title,
	stip_gomp.idaccmotiveundotax,
	accmotiveundotax.codemotive,
	accmotiveundotax.title,
	stip_gomp.idaccmotiveundotaxpost,
	accmotiveundotaxpost.codemotive,
	accmotiveundotaxpost.title,
	stip_gomp.tipologiacorso,
	stip_gomp.descrizione,
	stip_gomp.idestimkind,
	estimatekind.description,
	stip_gomp.ct,
	stip_gomp.cu,
	stip_gomp.lt,
	stip_gomp.lu
FROM stip_gomp
	LEFT OUTER JOIN finmotive ON finmotive.idfinmotive  = stip_gomp.idfinmotive 
	LEFT OUTER JOIN accmotive accmotiverevenue ON accmotiverevenue.idaccmotive  = stip_gomp.idaccmotiverevenue
	LEFT OUTER JOIN accmotive accmotivecredit ON accmotivecredit.idaccmotive  = stip_gomp.idaccmotivecredit
	LEFT OUTER JOIN accmotive accmotiveundotax ON accmotiveundotax.idaccmotive  = stip_gomp.idaccmotiveundotax
	LEFT OUTER JOIN accmotive accmotiveundotaxpost ON accmotiveundotaxpost.idaccmotive  = stip_gomp.idaccmotiveundotaxpost
	LEFT OUTER JOIN estimatekind  ON estimatekind.idestimkind  = stip_gomp.idestimkind



GO
