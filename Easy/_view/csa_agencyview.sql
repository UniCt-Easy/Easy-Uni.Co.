
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


-- CREAZIONE VISTA csa_agencyview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_agencyview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_agencyview]
GO
 

CREATE       VIEW [csa_agencyview]
(
	idcsa_agency,
	ente,
	description,
	idreg,
	registry,
	isinternal,
	flag,
	annualpayment,
	nobill,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	A.idcsa_agency,
	A.ente,
	A.description,
	A.idreg,
	R.title,
	A.isinternal,
	A.flag, 
	CASE	WHEN (ISNULL(A.flag,0) & 1 <> 0) THEN 'S' ELSE 'N' END,
	CASE	WHEN (ISNULL(A.flag,0) & 2 <> 0) THEN 'S' ELSE 'N' END,
	A.cu,
	A.ct,
	A.lu,
	A.lt
FROM csa_agency A
LEFT OUTER JOIN registry R
ON A.idreg = R.idreg



GO

-- 
