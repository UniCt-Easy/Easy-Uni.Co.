
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


 -- CREAZIONE VISTA stip_decodificaview
IF EXISTS(select * from sysobjects where id = object_id(N'[stip_decodificaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stip_decodificaview]
GO

--setuser'amm'
--select * from stip_decodificaview
CREATE  VIEW [stip_decodificaview]
(
	idstipdecodifica,
	idstiptassa,
	codicetassa,
	tassa,
	idstipvoce,
	codicevoce,
	voce,
	idstipcorsolaurea,
	codicecorsolaurea,
	corsolaurea,
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
	idestimkind,
	estimatekind,
	ct,
	cu,
	lt,
	lu
)
AS  SELECT
	stip_decodifica.idstipdecodifica,
	stip_decodifica.idstiptassa,
	stip_tassa.codicetassa,
	stip_tassa.descrizione,
	stip_decodifica.idstipvoce,
	stip_voce.codicevoce,
	stip_voce.descrizione,
	stip_corsolaurea.idstipcorsolaurea,
	stip_corsolaurea.codicecorsolaurea,
	stip_corsolaurea.descrizione,
	stip_decodifica.idaccmotiverevenue,
	accmotiverevenue.codemotive,
	accmotiverevenue.title,
	stip_decodifica.idaccmotivecredit,
	accmotivecredit.codemotive,
	accmotivecredit.title,
	stip_decodifica.idfinmotive,
	finmotive.codemotive,
	finmotive.title,
	stip_decodifica.idaccmotiveundotax,
	accmotiveundotax.codemotive,
	accmotiveundotax.title,
	stip_decodifica.idaccmotiveundotaxpost,
	accmotiveundotaxpost.codemotive,
	accmotiveundotaxpost.title,
	stip_decodifica.idestimkind,
	estimatekind.description,
	stip_decodifica.ct,
	stip_decodifica.cu,
	stip_decodifica.lt,
	stip_decodifica.lu
FROM stip_decodifica
	JOIN stip_tassa ON stip_tassa.idstiptassa = stip_decodifica.idstiptassa 
	JOIN stip_voce  ON stip_voce.idstipvoce  = stip_decodifica.idstipvoce
	LEFT OUTER JOIN stip_corsolaurea  ON stip_corsolaurea.idstipcorsolaurea  = stip_decodifica.idstipcorsolaurea
	LEFT OUTER JOIN finmotive ON finmotive.idfinmotive  = stip_decodifica.idfinmotive 
	LEFT OUTER JOIN accmotive accmotiverevenue ON accmotiverevenue.idaccmotive  = stip_decodifica.idaccmotiverevenue
	LEFT OUTER JOIN accmotive accmotivecredit ON accmotivecredit.idaccmotive  = stip_decodifica.idaccmotivecredit
	LEFT OUTER JOIN accmotive accmotiveundotax ON accmotiveundotax.idaccmotive  = stip_decodifica.idaccmotiveundotax
	LEFT OUTER JOIN accmotive accmotiveundotaxpost ON accmotiveundotaxpost.idaccmotive  = stip_decodifica.idaccmotiveundotaxpost
	LEFT OUTER JOIN estimatekind  ON estimatekind.idestimkind  = stip_decodifica.idestimkind

GO


