
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


-- CREAZIONE VISTA csa_importriepview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_importriepepexpview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_importriepepexpview]
GO


CREATE       VIEW [csa_importriepepexpview]
(
	idcsa_import,
	idriep,
	ndetail,
	idepexp,
	quota,	
	lu,	lt,cu,ct,
	yepexp,nepexp,idrelated,paridepexp,nphase
)
AS SELECT 
	RE.idcsa_import,
	RE.idriep,
	RE.ndetail,
	RE.idepexp,
	RE.quota,	
	RE.lu,	RE.lt,RE.cu,RE.ct,
	E.yepexp,E.nepexp,E.idrelated,E.paridepexp,E.nphase
FROM csa_importriep_epexp RE
	JOIN epexp E on RE.idepexp=E.idepexp
	

GO
--setuser 'amm'
--clear_table_info 'csa_importriepepexpview'
--select * from csa_importriepepexpview
 
