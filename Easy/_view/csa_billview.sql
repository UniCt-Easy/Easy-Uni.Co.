
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


-- CREAZIONE VISTA csa_billview
IF EXISTS(select * from sysobjects where id = object_id(N'[csa_billview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [csa_billview]
GO
--setuser 'amm'
--setuser'amministrazione'
--select * from csa_billview
CREATE       VIEW [csa_billview]
(
	idcsa_import,
	idcsa_bill,
	ybill,
	nbill,
	motive,
	adate,
	description,
	idreg,
	registry,
	amount,
	cu,
	ct,
	lu,
	lt
)
AS SELECT 
	I.idcsa_import,
	A.idcsa_bill,
	B.ybill,
	B.nbill,
	B.motive,
	B.adate,
	I.description,
	A.idreg,
	R.title,
	A.amount,
	A.cu,
	A.ct,
	A.lu,
	A.lt
FROM csa_bill A
LEFT OUTER JOIN registry R
ON A.idreg = R.idreg
LEFT OUTER JOIN csa_import I
ON A.idcsa_import = I.idcsa_import
JOIN bill B
ON B.ybill = I.yimport
AND B.nbill = A.nbill
AND B.billkind = 'D'
GO
