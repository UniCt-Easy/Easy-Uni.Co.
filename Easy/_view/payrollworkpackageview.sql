
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


-- CREAZIONE VISTA payrollworkpackageview
-- clear_table_info'payrollworkpackageview'
-- setuser'amm'
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollworkpackageview]
GO
-- select  * from payrollworkpackageview
CREATE        VIEW [payrollworkpackageview]
as
select 
C.idpayroll,
	CC.ycon, CC.ncon,
	CC.duty as description,
	'Cedolino ' + convert(varchar(4), C.fiscalyear) + '/' + convert(varchar(10), C.npayroll) +
	' contr.' +	convert(varchar(4), CC.ycon) + '/' + convert(varchar(10), CC.ncon) 	 as doc,
	disbursementdate as docdate,
	C.start, C.stop,
	C.idupb,
	'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 	convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll) as idrelated,
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
	   ISNULL((SELECT SUM(V1.amount)     FROM expensepayroll EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	PC.idprogettocosto
from payroll C 
join parasubcontract CC ON C.idcon = CC.idcon and C.flagbalance='N'
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = CC.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensepayroll EC on EC.idpayroll= C.idpayroll
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 	convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll) = PC.idrelated
	and PC.idexp = EL.idexp

	

 go
