
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


IF EXISTS(select * from sysobjects where id = object_id(N'[mandatedetailexpworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mandatedetailexpworkpackageview]
GO

-- Per mandatedetail è sufficiente che progettocosto vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [mandatedetailexpworkpackageview]
as
select 
	I.idmankind, I.yman, I.nman,
	I.description as descriptionmandate,
	substring('Doc.CP:' + I.doc,1,35) as doc,
	I.docdate,
	DET.rownum,
	DET.idupb,
	'man' + '§' + convert(varchar(4), DET.idmankind) + '§'  + convert(varchar(4), DET.yman) + '§'  + convert(varchar(14),DET.nman)+ '§'  + convert(varchar(10),DET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	v.idexp as idexppayed,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(DET.taxable * ISNULL(DET.npackage, DET.number) * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(DET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(DET.tax,2))
			 as iva_euro,
-- Calcola il pagato
	ISNULL(v.amount,0) AS payedamount,
	PC.idprogettocosto
from mandate I 
JOIN mandatekind 		
	ON mandatekind.idmankind = I.idmankind
join mandatedetail DET 
	ON I.idmankind = DET.idmankind  and I.yman = DET.yman and I.nman = DET.nman
join progettotipocostoaccmotive PM 	
	on PM.idaccmotive = DET.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
left outer join expenselastmandatedetail v 
	on v.idmankind = DET.idmankind AND v.yman = DET.yman AND v.nman = DET.nman AND v.rownum = DET.rownum 

join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = DET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage

left outer join progettocosto PC
	on 'man' + '§' + convert(varchar(4), DET.idmankind) + '§'  + convert(varchar(4), DET.yman) + '§'  + convert(varchar(14),DET.nman)+ '§'  + convert(varchar(10),DET.rownum) = PC.idrelated
WHERE mandatekind.linktoinvoice = 'N'
 go
 
 --select * from mandatedetailexpworkpackageview
 
