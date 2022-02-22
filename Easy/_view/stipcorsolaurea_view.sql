
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


-- CREAZIONE VISTA stockview
IF EXISTS(select * from sysobjects where id = object_id(N'[stip_corsolaureaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [stip_corsolaureaview]
GO




--clear_table_info'stip_corsolaureaview'
--setuser 'amm'
--select * from stip_corsolaureaview
create  VIEW [stip_corsolaureaview]
(
	idstipcorsolaurea,
		codicecorsolaurea,descrizionecorsolaurea,
		codicedipartimento,dipartimento,
		codicesede,sede,
		codicepercorso,percorso,
		anno,
		idupb,descrizione,
		ct,lt,cu,lu,
		codiceupb,upb,
		codicecausale,causale)
AS
SELECT
	idstipcorsolaurea,codicecorsolaurea,descrizionecorsolaurea,codicedipartimento,dipartimento,codicesede,sede,codicepercorso,percorso,anno,
		stip_corsolaurea.idupb,descrizione,
		stip_corsolaurea.ct,stip_corsolaurea.lt,stip_corsolaurea.cu,stip_corsolaurea.lu,
		upb.codeupb,upb.title,
		stip_corsolaurea.codicecausale,stip_corsolaurea.causale
FROM stip_corsolaurea
left outer join upb on stip_corsolaurea.idupb=upb.idupb
GO

