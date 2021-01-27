
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


-- CREAZIONE VISTA wageadditionworkpackageview
-- clear_table_info'wageadditionworkpackageview'
-- setuser'amm'
IF EXISTS(select * from sysobjects where id = object_id(N'[wageadditionworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wageadditionworkpackageview]
GO

CREATE        VIEW [wageadditionworkpackageview]
as
select 
	C.ycon, C.ncon, C.description as descriptionwageaddition,
	'Altri Compensi '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'wageadd' + '§' + convert(varchar(4), C.ycon) + '§'  +  convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	-- Legge il pagato
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensewageaddition EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	PC.idprogettocosto
from wageaddition C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensewageaddition EC on EC.ncon= C.ncon AND EC.ycon=C.ycon
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'wageadd' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PC.idexp = EL.idexp


 go
