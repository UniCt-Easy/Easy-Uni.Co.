
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


-- CREAZIONE VISTA finmotivedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[finmotivedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finmotivedetailview]
GO
 
CREATE VIEW [finmotivedetailview]
(
	idfinmotive,
	idfin,
	cu,
	ct,
	lu,
	lt,
	finpart,
	codefin,
	finance,
	ayear 
)
	AS SELECT
	finmotivedetail.idfinmotive,
	finmotivedetail.idfin,
	finmotivedetail.cu,
	finmotivedetail.ct,
	finmotivedetail.lu,
	finmotivedetail.lt,
	 CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.codefin,
	fin.title,
	fin.ayear
	FROM finmotivedetail (NOLOCK)
		JOIN fin  on fin.idfin= finmotivedetail.idfin
	





GO
 
 
