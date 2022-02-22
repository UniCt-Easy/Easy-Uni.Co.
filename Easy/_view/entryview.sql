
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


-- CREAZIONE VISTA entryview
IF EXISTS(select * from sysobjects where id = object_id(N'[entryview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW entryview
GO

--select * from entrykind
--select * from entry
--select * from entryview


CREATE    VIEW entryview
(
	yentry,
	nentry,
	adate,
	identrykind,
	entrykind,
	description,
	doc,
	docdate,
	locked,
	credit , 
	debit,
	idrelated,
	official,
	lt,lu,ct,cu,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
)
AS SELECT
e.yentry,
e.nentry,
e.adate,
e.identrykind,
	ek.description,
	e.description,
	e.doc,
	e.docdate,
	e.locked,
	-isnull( (SELECT SUM(amount) FROM entrydetail ed where  ed.yentry=e.yentry and ed.nentry=e.nentry and amount<0) ,0),
	isnull( (SELECT SUM(amount) FROM entrydetail ed where ed.yentry=e.yentry and ed.nentry=e.nentry and amount>0) , 0),
	e.idrelated,
	e.official,
	e.lt,e.lu,e.ct,e.cu,
	e.idsor01,
	e.idsor02,
	e.idsor03,
	e.idsor04,
	e.idsor05
FROM  entry e
LEFT OUTER JOIN entrykind  ek with (nolock)  
	on e.identrykind=ek.identrykind
GO

 

