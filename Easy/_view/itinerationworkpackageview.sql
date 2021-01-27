
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


-- CREAZIONE VISTA itinerationworkpackageview
-- clear_table_info'itinerationworkpackageview'
-- setuser'amm'
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationworkpackageview]
GO

--select  * from itinerationworkpackageview

CREATE        VIEW [itinerationworkpackageview]
as
select 
	C.iditineration,
	C.yitineration, C.nitineration, C.description as descriptionitineration,
	'Mis.  '+ convert(varchar(4), C.yitineration) + '/' + convert(varchar(10), C.nitineration) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.totalgross,
	EL.idexp as idexppayed,
	isnull(EY.amount,0) AS exppayedamount,
	null as idpettycash, 
	null as yoperation, 
	null as noperation,
	null as  pettycashpayedamount,
	PC.idprogettocosto
from itineration C 
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
-- Legge il pagato con i movimenti di spesa
left outer join expenseitineration EC on EC.iditineration = C.iditineration
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration)= PC.idrelated
	and PC.idexp = EL.idexp	 
UNION all
select 
	C.iditineration,
	C.yitineration, C.nitineration, C.description as descriptionitineration,
	'Mis.  '+ convert(varchar(4), C.yitineration) + '/' + convert(varchar(10), C.nitineration) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.totalgross,
	NULL as idexppayed,
	NULL AS exppayedamount,
	PCO.idpettycash, PCO.yoperation, PCO.noperation,
	isnull(PO.amount,0)  as pettycashpayedamount,
	PC.idprogettocosto
from itineration C 
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
--- Legge il pagato con la piccola spesa
LEFT OUTER join  pettycashoperationitineration PCO ON PCO.iditineration = C.iditineration
left outer JOIN pettycashoperation PO ON PCO.idpettycash = PO.idpettycash AND PCO.yoperation = PO.yoperation AND PCO.noperation = PO.noperation    
left outer join progettocosto PC
	on 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration)= PC.idrelated
	and PCO.idpettycash = PC.idpettycash AND PCO.yoperation = PC.yoperation AND PCO.noperation = PC.noperation    	 
 go

  
