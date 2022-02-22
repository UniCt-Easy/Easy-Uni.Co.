
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


-- CREAZIONE VISTA casualcontractworkpackageview
-- clear_table_info'casualcontractworkpackageview'
-- setuser'amm'

IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractworkpackageview]
GO

CREATE        VIEW [casualcontractworkpackageview]
as
select 
	C.ycon, C.ncon, C.description as descriptioncasualcontract,
	substring('Contratto Occasionale '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon),1,35)  as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	--Calcola il pagato con i Mov. di spesa
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensecasualcontract EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	null as idpettycash, null as yoperation, null as noperation,
	null as pettycashpayedamount,
	PC.idprogettocosto
from casualcontract C 
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
left outer join expensecasualcontract EC on EC.ncon= C.ncon AND EC.ycon=C.ycon
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PC.idexp = EL.idexp	 
UNION all
select 
	C.ycon, C.ncon, C.description as descriptioncasualcontract,
	'Contratto Occasionale '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	null as idexppayed,
	null AS exppayedamount,
	PCO.idpettycash, PCO.yoperation, PCO.noperation,
	-- Calcola il pagato col fondo economale
	isnull(PO.amount,0)  as pettycashpayedamount,
	PC.idprogettocosto
from casualcontract C 
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
LEFT OUTER join  pettycashoperationcasualcontract PCO ON PCO.ycon = C.ycon AND PCO.ncon = C.ncon
left outer JOIN pettycashoperation PO ON PCO.idpettycash = PO.idpettycash AND PCO.yoperation = PO.yoperation AND PCO.noperation = PO.noperation    
left outer join progettocosto PC
	on 'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PCO.idpettycash = PC.idpettycash AND PCO.yoperation = PC.yoperation AND PCO.noperation = PC.noperation    	 
 go
