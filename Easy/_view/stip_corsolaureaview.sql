
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


 -- CREAZIONE VISTA stip_decodificaview
IF EXISTS(select * from sysobjects where id = object_id(N'[stip_corsolaureaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stip_corsolaureaview]
GO
--select * from [stip_corsolaureaview]
--sp_help stip_corsolaurea 
--setuser'amm'
CREATE  VIEW [stip_corsolaureaview]
(
	idstipcorsolaurea,
	codicecorsolaurea,
	descrizionecorsolaurea,
	codicedipartimento,
	dipartimento,
	codicesede,
	sede,
	codicepercorso,
	percorso,
	anno,
	idupb,
	codeupb,
	upb,
	descrizione,
	codicecausale,
	causale,
	idstiptassa,
	codicetassa,
	tassa,
	idstipvoce,
	codicevoce,
	voce,
	idsor1,
	idsor2,
	idsor3,
	sortcode1,
	sortcode2,
	sortcode3,
	ct,
	cu,
	lt,
	lu
)
AS  SELECT
	stip_corsolaurea.idstipcorsolaurea,
	stip_corsolaurea.codicecorsolaurea,
	stip_corsolaurea.descrizionecorsolaurea,
	stip_corsolaurea.codicedipartimento,
	stip_corsolaurea.dipartimento,
	stip_corsolaurea.codicesede,
	stip_corsolaurea.sede,
	stip_corsolaurea.codicepercorso,
	stip_corsolaurea.percorso,
	stip_corsolaurea.anno,
	stip_corsolaurea.idupb,
	upb.codeupb,
	upb.title,
	stip_corsolaurea.descrizione,
	stip_corsolaurea.codicecausale,
	stip_corsolaurea.causale,
	stip_tassa.idstiptassa,
	stip_tassa.codicetassa,
	stip_tassa.descrizione,
	stip_voce.idstipvoce,
	stip_voce.codicevoce,
	stip_voce.descrizione,
	stip_corsolaurea.idsor1,
	stip_corsolaurea.idsor2,
	stip_corsolaurea.idsor3,
	sorting1.sortcode,
	sorting2.sortcode,
	sorting3.sortcode,
	stip_corsolaurea.ct,
	stip_corsolaurea.cu,
	stip_corsolaurea.lt,
	stip_corsolaurea.lu
FROM stip_corsolaurea
	LEFT OUTER JOIN stip_tassa ON stip_tassa.idstiptassa = stip_corsolaurea.idstiptassa
	LEFT OUTER JOIN stip_voce  ON stip_voce.idstipvoce  = stip_corsolaurea.idstipvoce
	LEFT OUTER JOIN upb  ON upb.idupb  = stip_corsolaurea.idupb
	LEFT OUTER JOIN sorting sorting1 WITH (NOLOCK)		ON sorting1.idsor = stip_corsolaurea.idsor1
	LEFT OUTER JOIN sorting sorting2 WITH (NOLOCK)		ON sorting2.idsor = stip_corsolaurea.idsor2
	LEFT OUTER JOIN sorting sorting3 WITH (NOLOCK)		ON sorting3.idsor = stip_corsolaurea.idsor3
 

GO


