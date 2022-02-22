
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


-- CREAZIONE VISTA finview
IF EXISTS(select * from sysobjects where id = object_id(N'[finviewsimple]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finviewsimple]
GO



--select * from finviewsimple


CREATE  VIEW [finviewsimple]
(
	idfin,
	ayear,
	finpart,
	codefin,
	nlevel,
	leveldescr,
	paridfin,
	printingorder,
	title,
	expiration,
	flag,
	flagusable,	
	cupcode,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
SELECT fin.idfin, fin.ayear, 
   	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.codefin, 
    	fin.nlevel, finlevel.description, 
    	fin.paridfin,
    fin.printingorder,
    fin.title,
	finlast.expiration, 
	fin.flag,
   	CASE
		when (( finlevel.flag & 2)<>0) then 'S'
		else 'N'
	End,
	finlast.cupcode,
	fin.cu, 
	fin.ct, fin.lu, 
	fin.lt
	FROM fin 
	(NOLOCK) INNER JOIN finlevel
		ON finlevel.ayear = fin.ayear	
		AND finlevel.nlevel = fin.nlevel 
	LEFT OUTER JOIN finlast (NOLOCK)
		ON fin.idfin = finlast.idfin




GO

