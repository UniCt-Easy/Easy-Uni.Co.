
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


-- CREAZIONE VISTA taxworkpackageview
-- clear_table_info'taxworkpackageview'
-- setuser'amm'

IF EXISTS(select * from sysobjects where id = object_id(N'[taxworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxworkpackageview]
GO

CREATE        VIEW [taxworkpackageview]
as
select 
	T.taxcode, 
	expense.ymov,
	T.description as tax,
	expensetax.competencydate,
	expenseyear.idupb,
	null as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PTT.idprogettotipocosto as idprogettotipocosto,
	EL.idexp as idexppayed,
	expensetax.admintax,
	PC.idprogettocosto
from tax T 
JOIN progettotipocostotax PTT 	
	on T.taxcode = PTT.taxcode 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PTT.idprogetto   and  PTC.idprogettotipocosto = PTT.idprogettotipocosto
JOIN progetto P 
	on PTT.idprogetto = P.idprogetto

join expensetax  	ON T.taxcode = expensetax.taxcode
JOIN expense 	ON expensetax.idexp = expense.idexp
JOIN expenselast EL	ON expense.idexp = EL.idexp 
join expenseyear on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = expenseyear.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
left outer join progettocosto PC
	on expensetax.idexp = PC.idexp
 go

